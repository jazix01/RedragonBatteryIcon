using DriverLib;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RedragonBatteryIcon
{
    public abstract class BatteryIcon
    {
        #region Variable Setup
        private static readonly string DeviceName = ConfigurationManager.AppSettings["DeviceName"];
        private static readonly string DeviceStringWired = ConfigurationManager.AppSettings["DeviceStringWired"];
        private static readonly string DeviceStringWireless = ConfigurationManager.AppSettings["DeviceStringWireless"];

        private static readonly NotifyIcon BatteryTray = new NotifyIcon();
        private const string IconFileDefault = "battery_";
        private const string iconFileExtension = ".png";
        private const string iconTextCharging = " (Charging)";
        private const string iconTextDisconnected = " (Disconnected)";

        private static string currentIconFile = IconFileDefault + "unknown" + iconFileExtension;
        private static string currentDevice = string.Empty;
        private static bool currentOnlineStatus = true;
        private static byte currentLevel;
        private static bool currentCharging;

        private static DeviceInfo wiredInfo;
        private static DeviceInfo wirelessInfo;
        private static System.Threading.Timer onlineCheck;
        private static BatteryStatus bs;
        private static readonly BatteryInfoDisplay batteryDisplay = new BatteryInfoDisplay();

        private static Point trayPosition;
        private static readonly Timer trayTimer = new Timer();
        #endregion

        private static void Main()
        {
            LogEntry("Starting up");

            UsbFinder.StartUsbChanged(OnUsbChangedEvent, 600);  // Assign a listener for any USB device changes
            onlineCheck = new System.Threading.Timer(CheckOnlineStatus, null, 1000, 5000);   // Start a thread that checks for device connection changes
            trayTimer.Tick += TrayTickEvent;    // Assign a tick event for the tray timer

            // Setup the tray icon and battery info panel
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("Exit", ExitHandler);

            BatteryTray.ContextMenu = menu;
            BatteryTray.MouseClick += TrayClickHandler;
            BatteryTray.MouseMove += TrayMoveHandler;
            BatteryTray.Visible = true;

            Bitmap bitmapIcon = GetIcon(currentIconFile);

            if (bitmapIcon != null)
            {
                BatteryTray.Icon = Icon.FromHandle(bitmapIcon.GetHicon());
                batteryDisplay.ChangeBatteryImage(bitmapIcon);
            }
            // ---

            Application.Run();
        }

        #region Events and Handlers
        /// <summary>
        /// Any time a USB event happens, run this method so we can detect if the mouse has been plugged in or unplugged
        /// </summary>
        private static void OnUsbChangedEvent(bool isPlug)
        {
            try
            {
                // Try to grab info on both the wireless and wired devices, and compare it to our stored values
                // Since this event fires on any USB device change system-wide, this comparison makes sure we only run logic when the mouse device info has changed
                UsbFinder.GetDeviceInfo(DeviceStringWired, out DeviceInfo wi);
                UsbFinder.GetDeviceInfo(DeviceStringWireless, out DeviceInfo wli);

                // Uncomment and step through these bits to find the hardware Ids for your devices
                //string[] dWireless = UsbFinder.FindHidDevicesByDefaultDeviceId(ConfigurationManager.AppSettings["VendorId"], ConfigurationManager.AppSettings["ProductIdWireless"]);
                //string[] dWired = UsbFinder.FindHidDevicesByDefaultDeviceId(ConfigurationManager.AppSettings["VendorId"], ConfigurationManager.AppSettings["ProductIdWired"]);

                if (wi.CID != wiredInfo.CID || wli.CID != wirelessInfo.CID)
                {
                    string device = string.Empty;
                    wiredInfo = wi;
                    wirelessInfo = wli;

                    if (wiredInfo.CID.Equals(0) && wirelessInfo.CID.Equals(0))
                    {
                        SetDisconnected();
                    }
                    else
                    {
                        if (wiredInfo.CID > 0)
                        {
                            device = DeviceStringWired;
                            currentOnlineStatus = true;
                        }
                        else
                        {
                            device = DeviceStringWireless;
                        }
                    }


                    if (string.IsNullOrEmpty(currentDevice) || device != currentDevice)
                    {
                        currentDevice = device;

                        UsbServer.Exit();   // Stop any existing UsbServer's before starting a new one for the chosen device
                        UsbServer.Start(currentDevice, currentDevice, onUsbDataReceived);
                    }
                }
            }
            catch (Exception ex)
            {
                LogEntry("OnUsbChangedEvent -> " + ex);
            }
        }

        /// <summary>
        /// For battery updates, determine which icon and hover text to show based on current battery level and charge state
        /// </summary>
        private static void onUsbDataReceived(UsbCommand command)
        {
            try
            {
                if (((UsbCommandID)command.id).Equals(UsbCommandID.BatteryLevel))
                {
                    bs = DataParser.GetDeviceBatteryStatus(command.receivedData);
                    bool charging = bs.isCharging.Equals(1);
                    string iconFile = IconFileDefault;

                    if (bs.level <= 10)
                    {
                        iconFile += "0";
                    }
                    else if (bs.level <= 35)
                    {
                        iconFile += "25";
                    }
                    else if (bs.level <= 50)
                    {
                        iconFile += "50";
                    }
                    else if (bs.level <= 75)
                    {
                        iconFile += "75";
                    }
                    else
                    {
                        iconFile += "100";
                    }

                    if (charging)
                    {
                        iconFile += "c";
                    }

                    iconFile += iconFileExtension;

                    if (bs.level != currentLevel || charging != currentCharging)
                    {
                        currentLevel = bs.level;
                        currentCharging = charging;

                        string newText = bs.level + "%";
                        string newTextCharging = string.Empty;

                        if (charging)
                        {
                            newTextCharging = iconTextCharging;
                        }

                        BatteryTray.Text = DeviceName + @" > " + newText + newTextCharging;
                        IAsyncResult batteryDisplayInvoke = batteryDisplay.BeginInvoke((MethodInvoker)delegate { batteryDisplay.ChangeChargeText(newText, newTextCharging); });
                        batteryDisplay.EndInvoke(batteryDisplayInvoke);
                    }

                    if (iconFile != currentIconFile)
                    {
                        Bitmap newIconBmp = GetIcon(iconFile);

                        if (newIconBmp != null)
                        {
                            currentIconFile = iconFile;
                            BatteryTray.Icon = Icon.FromHandle(newIconBmp.GetHicon());
                            IAsyncResult batteryDisplayInvoke = batteryDisplay.BeginInvoke((MethodInvoker)delegate { batteryDisplay.ChangeBatteryImage(newIconBmp); });
                            batteryDisplay.EndInvoke(batteryDisplayInvoke);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogEntry("onUsbDataReceived -> " + ex);
            }
        }

        /// <summary>
        /// Dispose of the tray icon and tasks, then exit the application
        /// </summary>
        private static void ExitHandler(object sender, EventArgs target)
        {
            LogEntry("Exiting");
            BatteryTray.Dispose();
            onlineCheck.Dispose();
            Application.Exit();
        }

        /// <summary>   
        /// Show the battery info panel when the tray icon is left clicked
        /// </summary>
        private static void TrayClickHandler(object sender, MouseEventArgs args)
        {
            if (args.Button == MouseButtons.Left && !batteryDisplay.Visible)
            {
                batteryDisplay.UpdateLocation(true);    // Update the form's location every time it's shown, as Windows 11 doesn't remember resolution when a monitor is disconnected
            }
        }

        /// <summary>
        /// Used to keep track of the mouse cursor when it's over the tray icon so we don't ` the battery info panel when it's clicked
        /// </summary>
        private static void TrayMoveHandler(object sender, MouseEventArgs args)
        {
            trayPosition = Cursor.Position;

            if (!trayTimer.Enabled)
            {
                batteryDisplay.UpdateMouseTrayPosition(true);
                trayTimer.Start();
            }
        }

        /// <summary>
        /// When the cursor is moved away from the tray icon, allow it to be closed again when a click is detected
        /// </summary>
        private static void TrayTickEvent(object sender, EventArgs e)
        {
            if (Cursor.Position != trayPosition)
            {
                batteryDisplay.UpdateMouseTrayPosition(false);
                trayTimer.Stop();
                trayTimer.Enabled = false;
            }
        }
        #endregion

        #region Timers
        /// <summary>
        /// Check to see if the device we're currently connected to is online or not, and record that status
        /// If the device has lost connection, set a disconnected icon and text
        /// If it's come back online, force a battery level read to trigger onUsbDataReceived
        /// </summary>
        private static void CheckOnlineStatus(object timerState)
        {
            try
            {
                // If for some reason we haven't found a device yet, manually trigger the USB change event to look for one
                if (string.IsNullOrEmpty(currentDevice))
                {
                    OnUsbChangedEvent(false);
                    return;
                }

                bool isOnline = UsbFinder.GetDeviceOnLine(currentDevice);

                if (isOnline != currentOnlineStatus)
                {
                    currentOnlineStatus = isOnline;

                    if (currentOnlineStatus)
                    {
                        UsbServer.ReadBatteryLevel();
                        BatteryTray.Text = BatteryTray.Text.Replace(iconTextDisconnected, string.Empty);
                        IAsyncResult batteryDisplayInvoke = batteryDisplay.BeginInvoke((MethodInvoker)delegate { batteryDisplay.RemoveConnectionStatus(); });
                        batteryDisplay.EndInvoke(batteryDisplayInvoke);
                    }
                    else
                    {
                        SetDisconnected();
                    }
                }
            }
            catch (Exception ex)
            {
                LogEntry("CheckOnlineStatus -> " + ex);
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Set the device to offline and not charging, and change the tray icon and text to show this
        /// </summary>
        private static void SetDisconnected()
        {
            try
            {
                currentOnlineStatus = false;
                currentCharging = false;

                if (!currentIconFile.Contains("unknown"))
                {
                    currentIconFile = currentIconFile.Replace("c.", ".").Replace("d.", ".").Replace(".", "d.");
                }

                Bitmap newIconBmp = GetIcon(currentIconFile);
                string newText = currentLevel + "%";

                if (newIconBmp != null)
                {
                    BatteryTray.Icon = Icon.FromHandle(newIconBmp.GetHicon());
                }
                
                BatteryTray.Text = DeviceName + @" > " + newText + iconTextDisconnected;

                IAsyncResult batteryDisplayInvoke = batteryDisplay.BeginInvoke((MethodInvoker)delegate
                {
                    if (newIconBmp != null)
                    {
                        batteryDisplay.ChangeBatteryImage(newIconBmp);
                    }
                    
                    batteryDisplay.ChangeChargeText(newText, iconTextDisconnected);
                });
                batteryDisplay.EndInvoke(batteryDisplayInvoke);
            }
            catch (Exception ex)
            {
                LogEntry("SetDisconnected -> " + currentIconFile + " -> " + ex);
            }
        }

        /// <summary>
        /// Write a timestamped entry in the designated log file
        /// </summary>
        private static void LogEntry(string msg)
        {
            using (StreamWriter logFile = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "RedragonBatteryIcon.log"), true))
            {
                logFile.WriteLine(DateTime.Now + " -- " + msg);
            }

        }

        /// <summary>
        /// Build a Bitmap object from an image filename
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static Bitmap GetIcon(string fileName)
        {
            Bitmap icon = null;

            try
            {
                if (File.Exists($"icons/{fileName}"))
                {
                    icon = new Bitmap($"icons/{fileName}");
                }
            }
            catch (Exception ex)
            {
                LogEntry($"GetIcon({fileName}) -> {ex}");
            }

            return icon;
        }
        #endregion
    }
}