// Decompiled with JetBrains decompiler
// Type: DriverLib.UsbCommand
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

namespace DriverLib
{
  public struct UsbCommand
  {
    public byte ReportId;
    public byte id;
    public byte CommandStatus;
    public int address;
    public byte[] command;
    public byte[] receivedData;
  }
}
