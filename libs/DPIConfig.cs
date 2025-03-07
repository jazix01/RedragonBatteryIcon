// Decompiled with JetBrains decompiler
// Type: DriverLib.DPIConfig
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

using System.Runtime.InteropServices;

namespace DriverLib
{
  public struct DPIConfig
  {
    public byte xDPI;
    public byte yDPI;
    public byte DPIex;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public byte[] color;
  }
}
