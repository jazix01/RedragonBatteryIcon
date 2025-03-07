// Decompiled with JetBrains decompiler
// Type: DriverLib.MacroContext
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

using System.Runtime.InteropServices;

namespace DriverLib
{
  public struct MacroContext
  {
    public byte keyState;
    public byte type;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public byte[] value;
    public uint delay;

    public MacroContext(int key)
    {
      this.keyState = (byte) 1;
      this.type = (byte) 1;
      this.value = new byte[2];
      this.value[0] = (byte) 0;
      this.value[1] = (byte) 0;
      this.delay = 0U;
    }
  }
}
