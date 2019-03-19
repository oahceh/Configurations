// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.IClipper
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE35C8E8-4ADC-4570-9159-4A7CFC6ED9E1
// Assembly location: D:\Unity\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

namespace UnityEngine.UI
{
  public interface IClipper
  {
    /// <summary>
    ///   <para>Called after layout and before Graphic update of the Canvas update loop.</para>
    /// </summary>
    void PerformClipping();
  }
}
