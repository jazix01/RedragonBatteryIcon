using System;
using System.Runtime.InteropServices;

namespace DriverLib
{
  public class DataParser
  {
    public const int MAX_DPI_CONFIG = 8;
    public const int MAX_KEY_COUNT = 16;
    public const int MAX_KEY_MACRO_COUNT = 70;
    public const int MAX_MACRO_NAME_LENGTH = 30;
    public const int MAX_FLASH_SIZE = 6912;
    public const int MAX_MACRO_COUNT = 70;
    public const int MAX_NAME_LENGTH = 30;
    public const int MAX_SHURTCUT_ACTION_COUNT = 6;
    public const int USB_PACKET_DATA_SIZE = 10;
    public const int USB_PACKET_SIZE = 17;

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_GetCidMid(byte[] data, IntPtr deviceCidMid);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.I1)]
    private static extern bool CS_isDeviceOnLine(byte[] data);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_GetDeviceBatteryStatus(byte[] data, IntPtr batteryStatus);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_GetDeviceStatusChanged(byte[] data, IntPtr deviceStatusChanged);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CS_GetDeviceVersion(byte[] data);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_ProtocolDataParser(byte[] data, IntPtr fashDataMap);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_ProtocolDataUpdate(IntPtr fashDataMap);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_BufferToDPILed(byte[] data, IntPtr dpiLed);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_BufferToLedBar(byte[] data, IntPtr ledBar);

    /*[DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CS_SetDllProtocolData(in FlashDataMap flashDataMap);*/

    /*public static DeviceInfo GetDeviceInfo(byte[] buffer)
    {
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (DeviceInfo)));
        DataParser.CS_GetCidMid(buffer, num);
      DeviceInfo structure = (DeviceInfo) Marshal.PtrToStructure(num, typeof (DeviceInfo));
      Marshal.FreeHGlobal(num);
      return structure;
    }*/

    public static bool isDeviceOnLine(byte[] buffer) => DataParser.CS_isDeviceOnLine(buffer);

    public static BatteryStatus GetDeviceBatteryStatus(byte[] buffer)
    {
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (BatteryStatus)));
        DataParser.CS_GetDeviceBatteryStatus(buffer, num);
      BatteryStatus structure = (BatteryStatus) Marshal.PtrToStructure(num, typeof (BatteryStatus));
      Marshal.FreeHGlobal(num);
      return structure;
    }

    public static int GetDeviceVersion(byte[] buffer) => DataParser.CS_GetDeviceVersion(buffer);

    /*public static void ProtocolParser(byte[] buffer, ref FlashDataMap flashDataMap)
    {
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (FlashDataMap)));
        DataParser.CS_ProtocolDataParser(buffer, num);
      flashDataMap = (FlashDataMap) Marshal.PtrToStructure(num, typeof (FlashDataMap));
      Marshal.FreeHGlobal(num);
    }*/

    /*public static void Update(FlashDataMap flashDataMap)
    {
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (FlashDataMap)));
      Marshal.StructureToPtr<FlashDataMap>((M0) flashDataMap, num, true);
        DataParser.CS_ProtocolDataUpdate(num);
      Marshal.FreeHGlobal(num);
    }*/

    /*public static void BufferToDPILed(byte[] data, ref DPILed dpiLed)
    {
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (DPILed)));
      if (UsbFinder.isX64System())
        DataParser.CS_BufferToDPILed(data, num);
      else
        DataParser32.CS_BufferToDPILed(data, num);
      dpiLed = (DPILed) Marshal.PtrToStructure(num, typeof (DPILed));
      Marshal.FreeHGlobal(num);
    }

    public static void BufferToLedBar(byte[] data, ref LedBar ledBar)
    {
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (LedBar)));
      if (UsbFinder.isX64System())
        DataParser.CS_BufferToLedBar(data, num);
      else
        DataParser32.CS_BufferToLedBar(data, num);
      ledBar = (LedBar) Marshal.PtrToStructure(num, typeof (LedBar));
      Marshal.FreeHGlobal(num);
    }

    public static void SetDllProtocolData(in FlashDataMap flashDataMap)
    {
      if (UsbFinder.isX64System())
        DataParser.CS_SetDllProtocolData(in flashDataMap);
      else
        DataParser32.CS_SetDllProtocolData(in flashDataMap);
    }*/
  }
}
