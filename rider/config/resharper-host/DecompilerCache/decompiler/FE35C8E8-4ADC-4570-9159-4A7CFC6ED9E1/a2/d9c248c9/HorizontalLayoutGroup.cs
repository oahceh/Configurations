// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.HorizontalLayoutGroup
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE35C8E8-4ADC-4570-9159-4A7CFC6ED9E1
// Assembly location: D:\Unity\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>Layout child layout elements side by side.</para>
  /// </summary>
  [AddComponentMenu("Layout/Horizontal Layout Group", 150)]
  public class HorizontalLayoutGroup : HorizontalOrVerticalLayoutGroup
  {
    protected HorizontalLayoutGroup()
    {
    }

    /// <summary>
    ///   <para>Called by the layout system.</para>
    /// </summary>
    public override void CalculateLayoutInputHorizontal()
    {
      base.CalculateLayoutInputHorizontal();
      this.CalcAlongAxis(0, false);
    }

    /// <summary>
    ///   <para>Called by the layout system.</para>
    /// </summary>
    public override void CalculateLayoutInputVertical()
    {
      this.CalcAlongAxis(1, false);
    }

    /// <summary>
    ///   <para>Called by the layout system.</para>
    /// </summary>
    public override void SetLayoutHorizontal()
    {
      this.SetChildrenAlongAxis(0, false);
    }

    /// <summary>
    ///   <para>Called by the layout system.</para>
    /// </summary>
    public override void SetLayoutVertical()
    {
      this.SetChildrenAlongAxis(1, false);
    }
  }
}
