// Decompiled with JetBrains decompiler
// Type: DriverLib.ShortCutKey
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

using System.Runtime.InteropServices;

namespace DriverLib
{
  public struct ShortCutKey
  {
    public byte contextCount;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
    public MacroContext[] context;

    public ShortCutKey(int key)
    {
      this.contextCount = (byte) 0;
      this.context = new MacroContext[6];
      for (int index = 0; index < 6; ++index)
        this.context[index] = new MacroContext(0);
    }
  }
}
