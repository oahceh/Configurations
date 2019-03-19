// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.HorizontalOrVerticalLayoutGroup
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE35C8E8-4ADC-4570-9159-4A7CFC6ED9E1
// Assembly location: D:\Unity\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>Abstract base class for HorizontalLayoutGroup and VerticalLayoutGroup.</para>
  /// </summary>
  public abstract class HorizontalOrVerticalLayoutGroup : LayoutGroup
  {
    [SerializeField]
    protected float m_Spacing = 0.0f;
    [SerializeField]
    protected bool m_ChildForceExpandWidth = true;
    [SerializeField]
    protected bool m_ChildForceExpandHeight = true;
    [SerializeField]
    protected bool m_ChildControlWidth = true;
    [SerializeField]
    protected bool m_ChildControlHeight = true;

    /// <summary>
    ///   <para>The spacing to use between layout elements in the layout group.</para>
    /// </summary>
    public float spacing
    {
      get
      {
        return this.m_Spacing;
      }
      set
      {
        this.SetProperty<float>(ref this.m_Spacing, value);
      }
    }

    /// <summary>
    ///   <para>Whether to force the children to expand to fill additional available horizontal space.</para>
    /// </summary>
    public bool childForceExpandWidth
    {
      get
      {
        return this.m_ChildForceExpandWidth;
      }
      set
      {
        this.SetProperty<bool>(ref this.m_ChildForceExpandWidth, value);
      }
    }

    /// <summary>
    ///   <para>Whether to force the children to expand to fill additional available vertical space.</para>
    /// </summary>
    public bool childForceExpandHeight
    {
      get
      {
        return this.m_ChildForceExpandHeight;
      }
      set
      {
        this.SetProperty<bool>(ref this.m_ChildForceExpandHeight, value);
      }
    }

    /// <summary>
    ///   <para>Returns true if the Layout Group controls the widths of its children. Returns false if children control their own widths.</para>
    /// </summary>
    public bool childControlWidth
    {
      get
      {
        return this.m_ChildControlWidth;
      }
      set
      {
        this.SetProperty<bool>(ref this.m_ChildControlWidth, value);
      }
    }

    /// <summary>
    ///   <para>Returns true if the Layout Group controls the heights of its children. Returns false if children control their own heights.</para>
    /// </summary>
    public bool childControlHeight
    {
      get
      {
        return this.m_ChildControlHeight;
      }
      set
      {
        this.SetProperty<bool>(ref this.m_ChildControlHeight, value);
      }
    }

    /// <summary>
    ///   <para>Calculate the layout element properties for this layout element along the given axis.</para>
    /// </summary>
    /// <param name="axis">The axis to calculate for. 0 is horizontal and 1 is vertical.</param>
    /// <param name="isVertical">Is this group a vertical group?</param>
    protected void CalcAlongAxis(int axis, bool isVertical)
    {
      float num1 = axis != 0 ? (float) this.padding.vertical : (float) this.padding.horizontal;
      bool controlSize = axis != 0 ? this.m_ChildControlHeight : this.m_ChildControlWidth;
      bool childForceExpand = axis != 0 ? this.childForceExpandHeight : this.childForceExpandWidth;
      float num2 = num1;
      float b = num1;
      float num3 = 0.0f;
      bool flag = isVertical ^ axis == 1;
      for (int index = 0; index < this.rectChildren.Count; ++index)
      {
        float min;
        float preferred;
        float flexible;
        this.GetChildSizes(this.rectChildren[index], axis, controlSize, childForceExpand, out min, out preferred, out flexible);
        if (flag)
        {
          num2 = Mathf.Max(min + num1, num2);
          b = Mathf.Max(preferred + num1, b);
          num3 = Mathf.Max(flexible, num3);
        }
        else
        {
          num2 += min + this.spacing;
          b += preferred + this.spacing;
          num3 += flexible;
        }
      }
      if (!flag && this.rectChildren.Count > 0)
      {
        num2 -= this.spacing;
        b -= this.spacing;
      }
      float totalPreferred = Mathf.Max(num2, b);
      this.SetLayoutInputForAxis(num2, totalPreferred, num3, axis);
    }

    /// <summary>
    ///   <para>Set the positions and sizes of the child layout elements for the given axis.</para>
    /// </summary>
    /// <param name="axis">The axis to handle. 0 is horizontal and 1 is vertical.</param>
    /// <param name="isVertical">Is this group a vertical group?</param>
    protected void SetChildrenAlongAxis(int axis, bool isVertical)
    {
      float num1 = this.rectTransform.rect.size[axis];
      bool controlSize = axis != 0 ? this.m_ChildControlHeight : this.m_ChildControlWidth;
      bool childForceExpand = axis != 0 ? this.childForceExpandHeight : this.childForceExpandWidth;
      float alignmentOnAxis = this.GetAlignmentOnAxis(axis);
      if (isVertical ^ axis == 1)
      {
        float num2 = num1 - (axis != 0 ? (float) this.padding.vertical : (float) this.padding.horizontal);
        for (int index = 0; index < this.rectChildren.Count; ++index)
        {
          RectTransform rectChild = this.rectChildren[index];
          float min;
          float preferred;
          float flexible;
          this.GetChildSizes(rectChild, axis, controlSize, childForceExpand, out min, out preferred, out flexible);
          float num3 = Mathf.Clamp(num2, min, (double) flexible <= 0.0 ? preferred : num1);
          float startOffset = this.GetStartOffset(axis, num3);
          if (controlSize)
          {
            this.SetChildAlongAxis(rectChild, axis, startOffset, num3);
          }
          else
          {
            float num4 = (num3 - rectChild.sizeDelta[axis]) * alignmentOnAxis;
            this.SetChildAlongAxis(rectChild, axis, startOffset + num4);
          }
        }
      }
      else
      {
        float pos = axis != 0 ? (float) this.padding.top : (float) this.padding.left;
        if ((double) this.GetTotalFlexibleSize(axis) == 0.0 && (double) this.GetTotalPreferredSize(axis) < (double) num1)
          pos = this.GetStartOffset(axis, this.GetTotalPreferredSize(axis) - (axis != 0 ? (float) this.padding.vertical : (float) this.padding.horizontal));
        float t = 0.0f;
        if ((double) this.GetTotalMinSize(axis) != (double) this.GetTotalPreferredSize(axis))
          t = Mathf.Clamp01((float) (((double) num1 - (double) this.GetTotalMinSize(axis)) / ((double) this.GetTotalPreferredSize(axis) - (double) this.GetTotalMinSize(axis))));
        float num2 = 0.0f;
        if ((double) num1 > (double) this.GetTotalPreferredSize(axis) && (double) this.GetTotalFlexibleSize(axis) > 0.0)
          num2 = (num1 - this.GetTotalPreferredSize(axis)) / this.GetTotalFlexibleSize(axis);
        for (int index = 0; index < this.rectChildren.Count; ++index)
        {
          RectTransform rectChild = this.rectChildren[index];
          float min;
          float preferred;
          float flexible;
          this.GetChildSizes(rectChild, axis, controlSize, childForceExpand, out min, out preferred, out flexible);
          float size = Mathf.Lerp(min, preferred, t) + flexible * num2;
          if (controlSize)
          {
            this.SetChildAlongAxis(rectChild, axis, pos, size);
          }
          else
          {
            float num3 = (size - rectChild.sizeDelta[axis]) * alignmentOnAxis;
            this.SetChildAlongAxis(rectChild, axis, pos + num3);
          }
          pos += size + this.spacing;
        }
      }
    }

    private void GetChildSizes(RectTransform child, int axis, bool controlSize, bool childForceExpand, out float min, out float preferred, out float flexible)
    {
      if (!controlSize)
      {
        min = child.sizeDelta[axis];
        preferred = min;
        flexible = 0.0f;
      }
      else
      {
        min = LayoutUtility.GetMinSize(child, axis);
        preferred = LayoutUtility.GetPreferredSize(child, axis);
        flexible = LayoutUtility.GetFlexibleSize(child, axis);
      }
      if (!childForceExpand)
        return;
      flexible = Mathf.Max(flexible, 1f);
    }

    protected override void Reset()
    {
      base.Reset();
      this.m_ChildControlWidth = false;
      this.m_ChildControlHeight = false;
    }
  }
}
