// Decompiled with JetBrains decompiler
// Type: DriverLib.UsbFinder
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DriverLib
{
  public class UsbFinder
  {
    private static UsbFinder.OnUsbChanged onUsbChangedDll;
    private static UsbFinder.OnUsbChanged onUsbChangedApp;
    private static UsbFinder.OnUsbUpgradeDataReceived onUsbUpgradeDataReceived;
    private static UsbFinder.OnUpgradeDataReceived onUpgradeDataReceived;

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    private static extern string[] CS_UsbFinder_GetDllVersion();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_StartUsbChanged(
      UsbFinder.OnUsbChanged onUsbChanged,
      int delayTimeout_ms);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_StopUsbChanged();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void CS_SetUsbChangedCallBack(
      UsbFinder.OnUsbChanged usbChangedCallBack,
      int delayTimeout_ms);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public static extern string[] CS_UsbFinder_EnumHidDeviceList();

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public static extern string[] CS_UsbFinder_FindHidDevices(StringBuilder vid, StringBuilder pid);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public static extern string[] CS_UsbFinder_FindHidDevicesByKey(StringBuilder inputEndPoint);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public static extern string[] CS_UsbFinder_FindHidDevicesByDefaultDeviceId(
      StringBuilder vid,
      StringBuilder pid);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public static extern string[] CS_UsbFinder_FindHidDevicesByDeviceId(
      StringBuilder vid,
      StringBuilder pid,
      int interfaceId,
      int deviceId);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int CS_UsbFinder_GetDeviceInfo(
      StringBuilder endpoint,
      out DeviceInfo deviceInfo);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CS_UsbFinder_ReadCidMid(
      StringBuilder endpoint,
      out DeviceInfo deviceInfo);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CS_UsbFinder_WriteCidMid(
      StringBuilder endpoint,
      byte cid,
      byte mid,
      byte deviceType,
      out DeviceInfo deviceInfo);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int CS_UsbFinder_GetVersion(StringBuilder endpoint);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CS_UsbFinder_GetDeviceOnLine(StringBuilder endpoint);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
    private static extern byte[] CS_UsbFinder_GetDeviceOnLineWithUsbAddress(StringBuilder endpoint);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CS_UsbUpgrade_Start(
      byte[] binFile,
      UsbFinder.OnUsbUpgradeDataReceived onUsbUpgradeDataReceived,
      int waitTimeout);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public static extern string[] CS_UsbUpgrade_FindBootDevices(byte[] binFile, int binArraySize);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]
    public static extern string[] CS_UsbUpgrade_GetLogs();

        /*[DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CS_UsbFinder_GetUsbDeviceAttribute(
          StringBuilder endpoint,
          out HIDD_ATTRIBUTES hidd_attributes);*/

        [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CS_UsbFinder_GetSlaveVersion(
      StringBuilder endpoint,
      out int slaveVersion);

    /*[DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte CS_UsbFinder_Set4KDongleRGB(
      StringBuilder endpoint,
      ref DongleRGB dongleRGB);

    [DllImport("hidusb32.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CS_UsbFinder_Get4KDongleRGBValue(
      StringBuilder endpoint,
      out DongleRGB dongleRGB);*/

    public static bool isWindow7() => Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1;

    //public static bool isX64System() => Environment.Is64BitOperatingSystem;

    public static string[] GetDllVersion() => UsbFinder.CS_UsbFinder_GetDllVersion();

    public static void StartUsbChanged(UsbFinder.OnUsbChanged onUsbChanged, int delayTimeout_ms)
    {
      UsbFinder.onUsbChangedDll = new UsbFinder.OnUsbChanged(UsbFinder.OnUserUsbChanged);
      UsbFinder.onUsbChangedApp = onUsbChanged;
        UsbFinder.CS_StartUsbChanged(UsbFinder.onUsbChangedDll, delayTimeout_ms);
    }

    public static void OnUserUsbChanged(bool isUsbPluged) => UsbFinder.onUsbChangedApp(isUsbPluged);

    public static void StopUsbChanged()
    {
        UsbFinder.CS_StopUsbChanged();
    }

    public static void SetUsbChangedCallBack(
      UsbFinder.OnUsbChanged usbChangedCallBack,
      int delayTimeout_ms)
    {
        UsbFinder.CS_SetUsbChangedCallBack(usbChangedCallBack, delayTimeout_ms);
    }

    public static string[] EnumHidDeviceList() => UsbFinder.CS_UsbFinder_EnumHidDeviceList();

    public static string[] FindHidDevices(string vid, string pid)
    {
      StringBuilder vid1 = new StringBuilder();
      vid1.Append(vid);
      StringBuilder pid1 = new StringBuilder();
      pid1.Append(pid);
      return UsbFinder.CS_UsbFinder_FindHidDevices(vid1, pid1);
    }

    public static string[] FindHidDevices(string inputEndpoint)
    {
      StringBuilder inputEndPoint = new StringBuilder();
      inputEndPoint.Append(inputEndpoint);
      return UsbFinder.CS_UsbFinder_FindHidDevicesByKey(inputEndPoint);
    }

    public static string[] FindHidDevicesByDefaultDeviceId(string vid, string pid)
    {
      StringBuilder vid1 = new StringBuilder();
      vid1.Append(vid);
      StringBuilder pid1 = new StringBuilder();
      pid1.Append(pid);
      return UsbFinder.CS_UsbFinder_FindHidDevicesByDefaultDeviceId(vid1, pid1);
    }

    public static string[] FindHidDevicesByDeviceId(
      string vid,
      string pid,
      int interfaceId,
      int deviceId)
    {
      StringBuilder vid1 = new StringBuilder();
      vid1.Append(vid);
      StringBuilder pid1 = new StringBuilder();
      pid1.Append(pid);
      return UsbFinder.CS_UsbFinder_FindHidDevicesByDeviceId(vid1, pid1, interfaceId, deviceId);
    }

    public static void GetDeviceInfo(string endPoint, out DeviceInfo deviceInfo)
    {
      StringBuilder endpoint = new StringBuilder();
      endpoint.Append(endPoint);
        UsbFinder.CS_UsbFinder_GetDeviceInfo(endpoint, out deviceInfo);
    }

    public static int GetVersion(string endPoint)
    {
      StringBuilder endpoint = new StringBuilder();
      endpoint.Append(endPoint);
      return UsbFinder.CS_UsbFinder_GetVersion(endpoint);
    }

    public static bool GetDeviceOnLine(string endPoint)
    {
      StringBuilder endpoint = new StringBuilder();
      endpoint.Append(endPoint);
      return UsbFinder.CS_UsbFinder_GetDeviceOnLine(endpoint);
    }

    public static byte[] GetDeviceOnLineWithAddress(string endPoint)
    {
      byte[] numArray = new byte[32];
      StringBuilder endpoint = new StringBuilder();
      endpoint.Append(endPoint);
      return UsbFinder.CS_UsbFinder_GetDeviceOnLineWithUsbAddress(endpoint);
    }

    /*public static void GetUsbDeviceAttribute(string endpoint, out HIDD_ATTRIBUTES hidd_attributes)
    {
      StringBuilder endpoint1 = new StringBuilder();
      endpoint1.Append(endpoint);
        UsbFinder.CS_UsbFinder_GetUsbDeviceAttribute(endpoint1, out hidd_attributes);
    }*/

    public static IntPtr BytesToIntptr(byte[] bytes)
    {
      int length = bytes.Length;
      IntPtr num = Marshal.AllocHGlobal(length);
      try
      {
        Marshal.Copy(bytes, 0, num, length);
        return num;
      }
      finally
      {
        Marshal.FreeHGlobal(num);
      }
    }

    public static bool UsbUpgrade_Start(
      byte[] binFile,
      UsbFinder.OnUpgradeDataReceived _onUsbUpgradeDataReceived,
      int waitTimeout)
    {
      UsbFinder.onUsbUpgradeDataReceived = new UsbFinder.OnUsbUpgradeDataReceived(UsbFinder.UserUsbUpgradeDataReceived);
      UsbFinder.onUpgradeDataReceived = _onUsbUpgradeDataReceived;
      return UsbFinder.CS_UsbUpgrade_Start(binFile, UsbFinder.onUsbUpgradeDataReceived, waitTimeout);
    }

    public static void UserUsbUpgradeDataReceived(IntPtr pcmd, int cmdLength)
    {
      byte[] numArray = new byte[cmdLength];
      Marshal.Copy(pcmd, numArray, 0, cmdLength);
      UsbFinder.onUpgradeDataReceived(numArray);
    }

    public static string[] FindBootDevices(byte[] binFile) => UsbFinder.CS_UsbUpgrade_FindBootDevices(binFile, binFile.Length);

    public static string[] UsbUpgrade_GetLogs() => UsbFinder.CS_UsbUpgrade_GetLogs();

    public static void ReadCidMid(string endPoint, out DeviceInfo deviceInfo)
    {
      StringBuilder endpoint = new StringBuilder();
      endpoint.Append(endPoint);
        UsbFinder.CS_UsbFinder_ReadCidMid(endpoint, out deviceInfo);
    }

    public static void WriteCidMid(
      string endPoint,
      byte cid,
      byte mid,
      byte deviceType,
      out DeviceInfo deviceInfo)
    {
      StringBuilder endpoint = new StringBuilder();
      endpoint.Append(endPoint);
        UsbFinder.CS_UsbFinder_WriteCidMid(endpoint, cid, mid, deviceType, out deviceInfo);
    }

    public static bool GetSlaveVersion(string endPoint, out int slaveVersion)
    {
      StringBuilder endpoint = new StringBuilder();
      endpoint.Append(endPoint);
      return UsbFinder.CS_UsbFinder_GetSlaveVersion(endpoint, out slaveVersion);
    }

    public delegate void OnUsbChanged(bool isUsbPluged);

    public delegate void OnUsbUpgradeDataReceived(IntPtr pcmd, int cmdLength);

    public delegate void OnUpgradeDataReceived(byte[] command);

    public enum HID_CODE_TYPE
    {
      Modify,
      Normal,
      Media,
      Power,
      Mouse,
    }
  }
}
