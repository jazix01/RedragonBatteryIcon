// Decompiled with JetBrains decompiler
// Type: DriverLib.FlashDataMap
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

using System.Runtime.InteropServices;

namespace DriverLib
{
  public struct FlashDataMap
  {
    public MouseConfig mouseConfig;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public DPIConfig[] dpiConfig;
    public DPILed dpiLed;
    public LedBar ledBar;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public KeyFunMap[] keys;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public ShortCutKey[] shortCutKey;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public MacroKey[] macroKey;

    public FlashDataMap(int key)
    {
      this.mouseConfig = new MouseConfig();
      this.dpiConfig = new DPIConfig[8];
      this.dpiLed = new DPILed();
      this.ledBar = new LedBar();
      this.keys = new KeyFunMap[16];
      this.shortCutKey = new ShortCutKey[16];
      this.macroKey = new MacroKey[16];
    }
  }
}
