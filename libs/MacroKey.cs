// Decompiled with JetBrains decompiler
// Type: DriverLib.MacroKey
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

using System.Runtime.InteropServices;

namespace DriverLib
{
  public struct MacroKey
  {
    public byte nameLength;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
    public byte[] name;
    public byte contextCount;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
    public MacroContext[] context;

    public MacroKey(int key)
    {
      this.nameLength = (byte) 0;
      this.name = new byte[30];
      this.contextCount = (byte) 0;
      this.context = new MacroContext[70];
      for (int index = 0; index < 70; ++index)
        this.context[index] = new MacroContext(0);
    }
  }
}
