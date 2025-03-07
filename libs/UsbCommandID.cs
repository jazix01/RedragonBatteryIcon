// Decompiled with JetBrains decompiler
// Type: DriverLib.UsbCommandID
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

namespace DriverLib
{
  public enum UsbCommandID
  {
    EncryptionData = 1,
    PCDriverStatus = 2,
    DeviceOnLine = 3,
    BatteryLevel = 4,
    DongleEnterPair = 5,
    GetPairState = 6,
    WriteFlashData = 7,
    ReadFlashData = 8,
    ClearSetting = 9,
    StatusChanged = 10, // 0x0000000A
    SetDeviceVidPid = 11, // 0x0000000B
    SetDeviceDescriptorString = 12, // 0x0000000C
    EnterUsbUpdateMode = 13, // 0x0000000D
    GetCurrentConfig = 14, // 0x0000000E
    SetCurrentConfig = 15, // 0x0000000F
    ReadCIDMID = 16, // 0x00000010
    EnterMTKMode = 17, // 0x00000011
    ReadVersionID = 18, // 0x00000012
    Set4KDongleRGB = 20, // 0x00000014
    Get4KDongleRGBValue = 21, // 0x00000015
    SetLongRangeMode = 22, // 0x00000016
    GetLongRangeMode = 23, // 0x00000017
    WriteKBCIdMID = 240, // 0x000000F0
    ReadKBCIdMID = 241, // 0x000000F1
  }
}
