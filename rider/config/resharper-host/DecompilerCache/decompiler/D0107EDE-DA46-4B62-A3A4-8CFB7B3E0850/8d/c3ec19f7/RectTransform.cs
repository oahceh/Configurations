// Decompiled with JetBrains decompiler
// Type: UnityEngine.RectTransform
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D0107EDE-DA46-4B62-A3A4-8CFB7B3E0850
// Assembly location: C:\Program Files\Unity2018.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Position, size, anchor and pivot information for a rectangle.</para>
  /// </summary>
  [NativeHeader("Runtime/Transform/RectTransform.h")]
  [NativeClass("UI::RectTransform")]
  public sealed class RectTransform : Transform
  {
    public static event RectTransform.ReapplyDrivenProperties reapplyDrivenProperties;

    /// <summary>
    ///   <para>The calculated rectangle in the local space of the Transform.</para>
    /// </summary>
    public Rect rect
    {
      get
      {
        Rect ret;
        this.get_rect_Injected(out ret);
        return ret;
      }
    }

    /// <summary>
    ///   <para>The normalized position in the parent RectTransform that the lower left corner is anchored to.</para>
    /// </summary>
    public Vector2 anchorMin
    {
      get
      {
        Vector2 ret;
        this.get_anchorMin_Injected(out ret);
        return ret;
      }
      set
      {
        this.set_anchorMin_Injected(ref value);
      }
    }

    /// <summary>
    ///   <para>The normalized position in the parent RectTransform that the upper right corner is anchored to.</para>
    /// </summary>
    public Vector2 anchorMax
    {
      get
      {
        Vector2 ret;
        this.get_anchorMax_Injected(out ret);
        return ret;
      }
      set
      {
        this.set_anchorMax_Injected(ref value);
      }
    }

    /// <summary>
    ///   <para>The position of the pivot of this RectTransform relative to the anchor reference point.</para>
    /// </summary>
    public Vector2 anchoredPosition
    {
      get
      {
        Vector2 ret;
        this.get_anchoredPosition_Injected(out ret);
        return ret;
      }
      set
      {
        this.set_anchoredPosition_Injected(ref value);
      }
    }

    /// <summary>
    ///   <para>The size of this RectTransform relative to the distances between the anchors.</para>
    /// </summary>
    public Vector2 sizeDelta
    {
      get
      {
        Vector2 ret;
        this.get_sizeDelta_Injected(out ret);
        return ret;
      }
      set
      {
        this.set_sizeDelta_Injected(ref value);
      }
    }

    /// <summary>
    ///   <para>The normalized position in this RectTransform that it rotates around.</para>
    /// </summary>
    public Vector2 pivot
    {
      get
      {
        Vector2 ret;
        this.get_pivot_Injected(out ret);
        return ret;
      }
      set
      {
        this.set_pivot_Injected(ref value);
      }
    }

    /// <summary>
    ///   <para>The 3D position of the pivot of this RectTransform relative to the anchor reference point.</para>
    /// </summary>
    public Vector3 anchoredPosition3D
    {
      get
      {
        Vector2 anchoredPosition = this.anchoredPosition;
        return new Vector3(anchoredPosition.x, anchoredPosition.y, this.localPosition.z);
      }
      set
      {
        this.anchoredPosition = new Vector2(value.x, value.y);
        Vector3 localPosition = this.localPosition;
        localPosition.z = value.z;
        this.localPosition = localPosition;
      }
    }

    /// <summary>
    ///   <para>The offset of the lower left corner of the rectangle relative to the lower left anchor.</para>
    /// </summary>
    public Vector2 offsetMin
    {
      get
      {
        return this.anchoredPosition - Vector2.Scale(this.sizeDelta, this.pivot);
      }
      set
      {
        Vector2 a = value - (this.anchoredPosition - Vector2.Scale(this.sizeDelta, this.pivot));
        this.sizeDelta -= a;
        this.anchoredPosition += Vector2.Scale(a, Vector2.one - this.pivot);
      }
    }

    /// <summary>
    ///   <para>The offset of the upper right corner of the rectangle relative to the upper right anchor.</para>
    /// </summary>
    public Vector2 offsetMax
    {
      get
      {
        return this.anchoredPosition + Vector2.Scale(this.sizeDelta, Vector2.one - this.pivot);
      }
      set
      {
        Vector2 a = value - (this.anchoredPosition + Vector2.Scale(this.sizeDelta, Vector2.one - this.pivot));
        this.sizeDelta += a;
        this.anchoredPosition += Vector2.Scale(a, this.pivot);
      }
    }

    internal extern Object drivenByObject { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    internal extern DrivenTransformProperties drivenProperties { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Force the recalculation of RectTransforms internal data.</para>
    /// </summary>
    [NativeMethod("UpdateIfTransformDispatchIsDirty")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void ForceUpdateRectTransforms();

    /// <summary>
    ///   <para>Get the corners of the calculated rectangle in the local space of its Transform.</para>
    /// </summary>
    /// <param name="fourCornersArray">The array that corners are filled into.</param>
    public void GetLocalCorners(Vector3[] fourCornersArray)
    {
      if (fourCornersArray == null || fourCornersArray.Length < 4)
      {
        Debug.LogError((object) "Calling GetLocalCorners with an array that is null or has less than 4 elements.");
      }
      else
      {
        Rect rect = this.rect;
        float x = rect.x;
        float y = rect.y;
        float xMax = rect.xMax;
        float yMax = rect.yMax;
        fourCornersArray[0] = new Vector3(x, y, 0.0f);
        fourCornersArray[1] = new Vector3(x, yMax, 0.0f);
        fourCornersArray[2] = new Vector3(xMax, yMax, 0.0f);
        fourCornersArray[3] = new Vector3(xMax, y, 0.0f);
      }
    }

    /// <summary>
    ///   <para>Get the corners of the calculated rectangle in world space.</para>
    /// </summary>
    /// <param name="fourCornersArray">The array that corners are filled into.</param>
    public void GetWorldCorners(Vector3[] fourCornersArray)
    {
      if (fourCornersArray == null || fourCornersArray.Length < 4)
      {
        Debug.LogError((object) "Calling GetWorldCorners with an array that is null or has less than 4 elements.");
      }
      else
      {
        this.GetLocalCorners(fourCornersArray);
        Matrix4x4 localToWorldMatrix = this.transform.localToWorldMatrix;
        for (int index = 0; index < 4; ++index)
          fourCornersArray[index] = localToWorldMatrix.MultiplyPoint(fourCornersArray[index]);
      }
    }

    public void SetInsetAndSizeFromParentEdge(RectTransform.Edge edge, float inset, float size)
    {
      int index = edge == RectTransform.Edge.Top || edge == RectTransform.Edge.Bottom ? 1 : 0;
      bool flag = edge == RectTransform.Edge.Top || edge == RectTransform.Edge.Right;
      float num = !flag ? 0.0f : 1f;
      Vector2 anchorMin = this.anchorMin;
      anchorMin[index] = num;
      this.anchorMin = anchorMin;
      Vector2 anchorMax = this.anchorMax;
      anchorMax[index] = num;
      this.anchorMax = anchorMax;
      Vector2 sizeDelta = this.sizeDelta;
      sizeDelta[index] = size;
      this.sizeDelta = sizeDelta;
      Vector2 anchoredPosition = this.anchoredPosition;
      anchoredPosition[index] = !flag ? inset + size * this.pivot[index] : (float) (-(double) inset - (double) size * (1.0 - (double) this.pivot[index]));
      this.anchoredPosition = anchoredPosition;
    }

    public void SetSizeWithCurrentAnchors(RectTransform.Axis axis, float size)
    {
      int index = (int) axis;
      Vector2 sizeDelta = this.sizeDelta;
      sizeDelta[index] = size - this.GetParentSize()[index] * (this.anchorMax[index] - this.anchorMin[index]);
      this.sizeDelta = sizeDelta;
    }

    [RequiredByNativeCode]
    internal static void SendReapplyDrivenProperties(RectTransform driven)
    {
      if (RectTransform.reapplyDrivenProperties == null)
        return;
      RectTransform.reapplyDrivenProperties(driven);
    }

    internal Rect GetRectInParentSpace()
    {
      Rect rect = this.rect;
      Vector2 vector2 = this.offsetMin + Vector2.Scale(this.pivot, rect.size);
      if ((bool) ((Object) this.transform.parent))
      {
        RectTransform component = this.transform.parent.GetComponent<RectTransform>();
        if ((bool) ((Object) component))
          vector2 += Vector2.Scale(this.anchorMin, component.rect.size);
      }
      rect.x += vector2.x;
      rect.y += vector2.y;
      return rect;
    }

    private Vector2 GetParentSize()
    {
      RectTransform parent = this.parent as RectTransform;
      if (!(bool) ((Object) parent))
        return Vector2.zero;
      return parent.rect.size;
    }

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void get_rect_Injected(out Rect ret);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void get_anchorMin_Injected(out Vector2 ret);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void set_anchorMin_Injected(ref Vector2 value);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void get_anchorMax_Injected(out Vector2 ret);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void set_anchorMax_Injected(ref Vector2 value);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void get_anchoredPosition_Injected(out Vector2 ret);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void set_anchoredPosition_Injected(ref Vector2 value);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void get_sizeDelta_Injected(out Vector2 ret);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void set_sizeDelta_Injected(ref Vector2 value);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void get_pivot_Injected(out Vector2 ret);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void set_pivot_Injected(ref Vector2 value);

    /// <summary>
    ///   <para>Enum used to specify one edge of a rectangle.</para>
    /// </summary>
    public enum Edge
    {
      /// <summary>
      ///   <para>The left edge.</para>
      /// </summary>
      Left,
      /// <summary>
      ///   <para>The right edge.</para>
      /// </summary>
      Right,
      /// <summary>
      ///   <para>The top edge.</para>
      /// </summary>
      Top,
      /// <summary>
      ///   <para>The bottom edge.</para>
      /// </summary>
      Bottom,
    }

    /// <summary>
    ///   <para>An axis that can be horizontal or vertical.</para>
    /// </summary>
    public enum Axis
    {
      /// <summary>
      ///   <para>Horizontal.</para>
      /// </summary>
      Horizontal,
      /// <summary>
      ///   <para>Vertical.</para>
      /// </summary>
      Vertical,
    }

    /// <summary>
    ///   <para>Delegate used for the reapplyDrivenProperties event.</para>
    /// </summary>
    /// <param name="driven"></param>
    public delegate void ReapplyDrivenProperties(RectTransform driven);
  }
}
