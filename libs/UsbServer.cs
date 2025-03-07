// Decompiled with JetBrains decompiler
// Type: DriverLib.UsbServer
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DriverLib
{
  public class UsbServer
  {
    private static UsbServer.OnUsbDataReceived onUsbDataReceived;
    private static UsbServer.OnDataReceived onDataReceived;

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_Thread();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_Start(
      StringBuilder inputEndpoint,
      StringBuilder outputEndpoint,
      UsbServer.OnUsbDataReceived onUsbDataReceived);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_Exit();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadEncryption();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_SetPCDriverStatus(bool isActived);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadOnLine();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadBatteryLevel();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_SetClearSetting();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadVersion();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadFalshData(int startAddress, int length);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadAllFlashData();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadConfig();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_EnterDonglePair();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_EnterDonglePairWithCidMid(byte cid, byte mid);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_EnterDonglePairOnlyCid(byte cid);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadDonglePairStatus();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_SetVidPid(int vid, int pid);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_SetDeviceDescriptorString(
      StringBuilder DeviceDescriptorString);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_EnterUsbUpdateMode();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_SetCurrentConfig(int configId);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadCidMid();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_EnterMTKMode();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public static extern string[] CS_UsbServer_GetCurrentDevice();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadCurrentDPI();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadReportRate();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadDPILed();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_UsbServer_ReadLedBar();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_UsbServer_SetBatteryOptimizeEnable(bool enable);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_UsbServer_SetBatteryOptimizeLastBattery(
      int _elapsedSeconds,
      byte lastBatPercent);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_UsbServer_SetBatteryOptimizeParam(
      int _supportBatteryReplacement,
      int _smoothChangesInterval,
      int _smoothChangesIntervalInCharge85_100);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_UsbServer_SetBatteryOptimizeSection(int[] _BatVoltage);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_UsbServer_ReStartBatteryOptimize();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_ProtocolDataCompareUpdate(
      IntPtr writeFashDataMap,
      IntPtr compareFashDataMap);

    //[DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    //private static extern void CS_UsbServer_Set4KDongleRGB(ref DongleRGB dongleRGB);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void UsbServer_Get4KDongleRGBValue();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_UsbServer_SetLongRangeMode(bool enable);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_UsbServer_GetLongRangeMode();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void UsbServer_GetSlaveVersion();

    public static void UsbServer_Thread()
    {
      if (UsbFinder.isX64System())
        UsbServer.CS_UsbServer_Thread();
      else
        UsbServer.CS_UsbServer_Thread();
    }

    public static void Start(
      string inputEndpoint,
      string outputEndpoint,
      UsbServer.OnDataReceived _onDataReceived)
    {
      StringBuilder inputEndpoint1 = new StringBuilder();
      inputEndpoint1.Append(inputEndpoint);
      StringBuilder outputEndpoint1 = new StringBuilder();
      outputEndpoint1.Append(outputEndpoint);
      UsbServer.onUsbDataReceived = new UsbServer.OnUsbDataReceived(UsbServer.UserUsbDataReceived);
      UsbServer.onDataReceived = _onDataReceived;
        UsbServer.CS_UsbServer_Start(inputEndpoint1, outputEndpoint1, UsbServer.onUsbDataReceived);
    }

    public static void UserUsbDataReceived(
      IntPtr pcmd,
      int cmdLength,
      IntPtr pdata,
      int dataLength)
    {
      byte[] destination = new byte[cmdLength];
      Marshal.Copy(pcmd, destination, 0, cmdLength);
      UsbCommand command = new UsbCommand();
      command.ReportId = destination[0];
      command.id = destination[1];
      command.CommandStatus = destination[2];
      command.address = (int) destination[3] << 8 | (int) destination[4];
      int length = 10;
      command.command = new byte[length];
      Array.Copy((Array) destination, 6, (Array) command.command, 0, length);
      if (dataLength > 0)
      {
        command.receivedData = new byte[dataLength];
        Marshal.Copy(pdata, command.receivedData, 0, dataLength);
      }
      else
        command.command = (byte[]) null;
      UsbServer.onDataReceived(command);
    }

    public static void Exit()
    {
        UsbServer.CS_UsbServer_Exit();
    }

    public static void ReadEncryptedData()
    {
        UsbServer.CS_UsbServer_ReadEncryption();
    }

    public static void SetPCDriverStatus(bool isActived)
    {
        UsbServer.CS_UsbServer_SetPCDriverStatus(isActived);
    }

    public static void ReadOnLine()
    {
        UsbServer.CS_UsbServer_ReadOnLine();
    }

    public static void ReadBatteryLevel()
    {
        UsbServer.CS_UsbServer_ReadBatteryLevel();
    }

    public static void EnterDonglePair()
    {
        UsbServer.CS_UsbServer_EnterDonglePair();
    }

    public static void EnterDonglePairWithCidMid(byte cid, byte mid)
    {
        UsbServer.CS_UsbServer_EnterDonglePairWithCidMid(cid, mid);
    }

    public static void EnterDonglePairOnlyCid(byte cid)
    {
        UsbServer.CS_UsbServer_EnterDonglePairOnlyCid(cid);
    }

    public static void ReadDonglePairStatus()
    {
        UsbServer.CS_UsbServer_ReadDonglePairStatus();
    }

    public static void SetVidPid(int vid, int pid)
    {
        UsbServer.CS_UsbServer_SetVidPid(vid, pid);
    }

    public static void SetDeviceDescriptorString(string DeviceDescriptorString)
    {
      StringBuilder DeviceDescriptorString1 = new StringBuilder();
      DeviceDescriptorString1.Append(DeviceDescriptorString);
        UsbServer.CS_UsbServer_SetDeviceDescriptorString(DeviceDescriptorString1);
    }

    public static void EnterUsbUpdateMode()
    {
        UsbServer.CS_UsbServer_EnterUsbUpdateMode();
    }

    public static void SetClearSetting()
    {
        UsbServer.CS_UsbServer_SetClearSetting();
    }

    public static void ReadVersion()
    {
        UsbServer.CS_UsbServer_ReadVersion();
    }

    public static void ReadFalshData(int address, int length)
    {
        UsbServer.CS_UsbServer_ReadFalshData(address, length);
    }

    public static void ReadAllFlashData()
    {
        UsbServer.CS_UsbServer_ReadAllFlashData();
    }

    public static void ReadConfig()
    {
        UsbServer.CS_UsbServer_ReadConfig();
    }

    public static void SetCurrentConfig(int configid)
    {
        UsbServer.CS_UsbServer_SetCurrentConfig(configid);
    }

    public static string GetCurrentEndPointPath()
    {
      string[] strArray = UsbServer.CS_UsbServer_GetCurrentDevice();
      return strArray != null ? strArray[0] : "";
    }

    public static void ReadCidMid()
    {
        UsbServer.CS_UsbServer_ReadCidMid();
    }

    public static void EnterMTKMode()
    {
        UsbServer.CS_UsbServer_EnterMTKMode();
    }

    public static void ReadCurrentDPI()
    {
        UsbServer.CS_UsbServer_ReadCurrentDPI();
    }

    public static void ReadReportRate()
    {
        UsbServer.CS_UsbServer_ReadReportRate();
    }

    public static void ReadDPILed()
    {
        UsbServer.CS_UsbServer_ReadDPILed();
    }

    public static void ReadLedBar()
    {
        UsbServer.CS_UsbServer_ReadLedBar();
    }

    public static void SetBatteryOptimizeEnable(bool enable)
    {
        UsbServer.CS_UsbServer_SetBatteryOptimizeEnable(enable);
    }

    public static void SetBatteryOptimizeLastBattery(int _elapsedSeconds, byte lastBatPercent)
    {
        UsbServer.CS_UsbServer_SetBatteryOptimizeLastBattery(_elapsedSeconds, lastBatPercent);
    }

    public static void SetBatteryOptimizeParam(
      int _supportBatteryReplacement,
      int _smoothChangesInterval,
      int _smoothChangesIntervalInCharge85_100)
    {
        UsbServer.CS_UsbServer_SetBatteryOptimizeParam(_supportBatteryReplacement, _smoothChangesInterval, _smoothChangesIntervalInCharge85_100);
    }

    public static void SetBatteryOptimizeSection(int[] _BatVoltage)
    {
        UsbServer.CS_UsbServer_SetBatteryOptimizeSection(_BatVoltage);
    }

    public static void ReStartBatteryOptimize()
    {
        UsbServer.CS_UsbServer_ReStartBatteryOptimize();
    }

    /*public static void ProtocolDataCompareUpdate(
      FlashDataMap writeFlashDataMap,
      FlashDataMap compareFlashDataMap)
    {
      IntPtr num1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (FlashDataMap)));
      IntPtr num2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (FlashDataMap)));
      Marshal.StructureToPtr<FlashDataMap>((M0) writeFlashDataMap, num1, true);
      Marshal.StructureToPtr<FlashDataMap>((M0) compareFlashDataMap, num2, true);
      if (UsbFinder.isX64System())
        UsbServer.CS_ProtocolDataCompareUpdate(num1, num2);
      else
        UsbServer32.CS_ProtocolDataCompareUpdate(num1, num2);
      Marshal.FreeHGlobal(num1);
      Marshal.FreeHGlobal(num2);
    }*/

    /*public static void Set4KDongleRGB(ref DongleRGB dongleRGB)
    {
      if (UsbFinder.isX64System())
        UsbServer.CS_UsbServer_Set4KDongleRGB(ref dongleRGB);
      else
        UsbServer32.CS_UsbServer_Set4KDongleRGB(ref dongleRGB);
    }*/

    /*public static void Get4KDongleRGBValue()
    {
      if (UsbFinder.isX64System())
        UsbServer.UsbServer_Get4KDongleRGBValue();
      else
        UsbServer32.UsbServer_Get4KDongleRGBValue();
    }*/

    /*public static void SetLongRangeMode(bool enable)
    {
      if (UsbFinder.isX64System())
        UsbServer.CS_UsbServer_SetLongRangeMode(enable);
      else
        UsbServer32.CS_UsbServer_SetLongRangeMode(enable);
    }

    public static void GetLongRangeMode()
    {
      if (UsbFinder.isX64System())
        UsbServer.CS_UsbServer_GetLongRangeMode();
      else
        UsbServer32.CS_UsbServer_GetLongRangeMode();
    }*/

    public static void GetSlaveVersion()
    {
        UsbServer.UsbServer_GetSlaveVersion();
    }

    public delegate void OnUsbDataReceived(
      IntPtr pcmd,
      int cmdLength,
      IntPtr pdata,
      int dataLength);

    public delegate void OnDataReceived(UsbCommand command);
  }
}
