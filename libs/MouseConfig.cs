// Decompiled with JetBrains decompiler
// Type: DriverLib.MouseConfig
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

namespace DriverLib
{
  public struct MouseConfig
  {
    public byte reportRate;
    public byte maxDPI;
    public byte currentDPI;
    public byte xSpindown;
    public byte ySpindown;
    public byte silenceHeight;
    public byte keyDebounceTime;
    public byte motionSyncEnable;
    public byte allLedOffTime;
    public byte linearCorrectionEnable;
    public byte rippleControlEnable;
    public byte moveOffLedEnable;
    public byte sensorCustomSleepTimeEnable;
    public byte sensorSleepTime;
    public byte sensorPowerSavingModeEnable;
  }
}
