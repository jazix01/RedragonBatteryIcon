using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedragonBatteryIcon
{
    public partial class BatteryInfoDisplay : Form
    {
        private static bool mouseInsideControl;
        private static bool mouseInsideTray;
        private readonly AutoResetEvent _are = new AutoResetEvent(false);

        /// <summary>
        /// Create a modal-style box that shows the current battery level and status, along with the device name
        /// </summary>
        public BatteryInfoDisplay()
        {
            InitializeComponent();

            UpdateLocation();
            lblDeviceName.Text = ConfigurationManager.AppSettings["DeviceName"];

            // Setup a few events to listen to mouse clicks and keep track of whether the mouse is inside the control area or not
            // These let the application hide this control when any click happens outside the display area
            // I tried using LostFocus but it only works ~90% of the time, and global mouse click listener libraries like MouseKeyHook cause mouse stutters ocassionally
            // Starting a Task when the form is shown that detects clicks is the easiest way that does not impact the system
            VisibleChanged += VisibleChangeEvent;
            MouseLeave += MouseLeaveEvent;
            MouseEnter += MouseEnterEvent;
            // ---
        }

        #region Public Methods
        public void ChangeBatteryImage(Image img)
        {
            picIcon.Image = img;
        }

        public void ChangeChargeText(string chargeText, string connectionStatus = "")
        {
            lblChargeLevel.Text = chargeText;
            lblConnectionStatus.Text = connectionStatus.Trim();
        }

        public void RemoveConnectionStatus()
        {
            lblConnectionStatus.Text = string.Empty;
        }

        public void UpdateMouseTrayPosition(bool inside)
        {
            mouseInsideTray = inside;
        }

        /// <summary>
        /// Update the location the battery modal will display; needed for monitor status change as Windows isn't great at remembering resolution
        /// </summary>
        /// <param name="show">If true, show the modal after updating it's location</param>
        public void UpdateLocation(bool show = false)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

            if (show)
            {
                Show();
            }
        }
        #endregion

        #region Events
        private void VisibleChangeEvent(object sender, EventArgs e)
        {
            _are.Reset();

            if (Visible)
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        if (_are.WaitOne(20)) break;

                        if (MouseButtons.Equals(MouseButtons.Right) && !mouseInsideControl || (MouseButtons.Equals(MouseButtons.Left) && !mouseInsideControl && !mouseInsideTray))
                        {
                            IAsyncResult batteryDisplayInvoke = BeginInvoke((MethodInvoker)Hide);
                            EndInvoke(batteryDisplayInvoke);
                            break;
                        }
                    }
                });
                //Hook.GlobalEvents().MouseClick += MouseClickEvent;
                //Select();
            }
            /*else
            {
                Hook.GlobalEvents().MouseClick -= MouseClickEvent;
            }*/
        }

        /*private void FocusLost(object sender, EventArgs e)
        {
            if (Visible)
            {
                Hide();
            }
        }*/

        private void MouseLeaveEvent(object sender, EventArgs e)
        {
            if (!ClientRectangle.Contains(PointToClient(MousePosition)))
            {
                mouseInsideControl = false;
            }
        }

        private void MouseEnterEvent(object sender, EventArgs e)
        {
            if (ClientRectangle.Contains(PointToClient(MousePosition)))
            {
                mouseInsideControl = true;
            }
        }

        /*private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (Visible)
            {
                if (e.Button.Equals(MouseButtons.Right) && !mouseInsideControl || (e.Button.Equals(MouseButtons.Left) && !mouseInsideControl && !mouseInsideTray))
                {
                    Hide();
                }
            }
        }*/
        #endregion
    }
}
