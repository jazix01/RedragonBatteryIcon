// Decompiled with JetBrains decompiler
// Type: DriverLib.KeyFunMap
// Assembly: Mouse Drive Beta, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 11FD092E-E418-445C-BC4F-CF7BDC20D682
// Assembly location: C:\Program Files (x86)\Redragon M916-PRO-1K\Mouse Drive Beta.exe

namespace DriverLib
{
  public struct KeyFunMap
  {
    public byte type;
    public byte param1;
    public byte param2;

    public KeyFunMap(int key)
    {
      this.type = (byte) 0;
      this.param1 = (byte) 0;
      this.param2 = (byte) 0;
    }
  }
}
