// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.RectMask2D
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 091AA051-6747-4DB5-B224-3BE39BFAEF6E
// Assembly location: C:\Program Files\Unity2018.3.6f1\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>A 2D rectangular mask that allows for clipping / masking of areas outside the mask.</para>
  /// </summary>
  [AddComponentMenu("UI/Rect Mask 2D", 13)]
  [ExecuteAlways]
  [DisallowMultipleComponent]
  [RequireComponent(typeof (RectTransform))]
  public class RectMask2D : UIBehaviour, IClipper, ICanvasRaycastFilter
  {
    [NonSerialized]
    private readonly RectangularVertexClipper m_VertexClipper = new RectangularVertexClipper();
    [NonSerialized]
    private HashSet<IClippable> m_ClipTargets = new HashSet<IClippable>();
    [NonSerialized]
    private List<RectMask2D> m_Clippers = new List<RectMask2D>();
    private Vector3[] m_Corners = new Vector3[4];
    [NonSerialized]
    private RectTransform m_RectTransform;
    [NonSerialized]
    private bool m_ShouldRecalculateClipRects;
    [NonSerialized]
    private Rect m_LastClipRectCanvasSpace;
    [NonSerialized]
    private bool m_ForceClip;
    [NonSerialized]
    private Canvas m_Canvas;

    protected RectMask2D()
    {
    }

    private Canvas Canvas
    {
      get
      {
        if ((UnityEngine.Object) this.m_Canvas == (UnityEngine.Object) null)
        {
          List<Canvas> canvasList = ListPool<Canvas>.Get();
          this.gameObject.GetComponentsInParent<Canvas>(false, canvasList);
          this.m_Canvas = canvasList.Count <= 0 ? (Canvas) null : canvasList[canvasList.Count - 1];
          ListPool<Canvas>.Release(canvasList);
        }
        return this.m_Canvas;
      }
    }

    /// <summary>
    ///   <para>Get the Rect for the mask in canvas space.</para>
    /// </summary>
    public Rect canvasRect
    {
      get
      {
        return this.m_VertexClipper.GetCanvasRect(this.rectTransform, this.Canvas);
      }
    }

    /// <summary>
    ///   <para>Get the RectTransform for the mask.</para>
    /// </summary>
    public RectTransform rectTransform
    {
      get
      {
        return this.m_RectTransform ?? (this.m_RectTransform = this.GetComponent<RectTransform>());
      }
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      this.m_ShouldRecalculateClipRects = true;
      ClipperRegistry.Register((IClipper) this);
      MaskUtilities.Notify2DMaskStateChanged((Component) this);
    }

    protected override void OnDisable()
    {
      base.OnDisable();
      this.m_ClipTargets.Clear();
      this.m_Clippers.Clear();
      ClipperRegistry.Unregister((IClipper) this);
      MaskUtilities.Notify2DMaskStateChanged((Component) this);
    }

    protected override void OnValidate()
    {
      base.OnValidate();
      this.m_ShouldRecalculateClipRects = true;
      if (!this.IsActive())
        return;
      MaskUtilities.Notify2DMaskStateChanged((Component) this);
    }

    /// <summary>
    ///   <para>See:ICanvasRaycastFilter.</para>
    /// </summary>
    /// <param name="sp"></param>
    /// <param name="eventCamera"></param>
    public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
      if (!this.isActiveAndEnabled)
        return true;
      return RectTransformUtility.RectangleContainsScreenPoint(this.rectTransform, sp, eventCamera);
    }

    private Rect rootCanvasRect
    {
      get
      {
        this.rectTransform.GetWorldCorners(this.m_Corners);
        if (!object.ReferenceEquals((object) this.Canvas, (object) null))
        {
          Canvas rootCanvas = this.Canvas.rootCanvas;
          for (int index = 0; index < 4; ++index)
            this.m_Corners[index] = rootCanvas.transform.InverseTransformPoint(this.m_Corners[index]);
        }
        return new Rect(this.m_Corners[0].x, this.m_Corners[0].y, this.m_Corners[2].x - this.m_Corners[0].x, this.m_Corners[2].y - this.m_Corners[0].y);
      }
    }

    /// <summary>
    ///   <para>See: IClipper.PerformClipping.</para>
    /// </summary>
    public virtual void PerformClipping()
    {
      if (object.ReferenceEquals((object) this.Canvas, (object) null))
        return;
      if (this.m_ShouldRecalculateClipRects)
      {
        MaskUtilities.GetRectMasksForClip(this, this.m_Clippers);
        this.m_ShouldRecalculateClipRects = false;
      }
      bool validRect = true;
      Rect andClipWorldRect = Clipping.FindCullAndClipWorldRect(this.m_Clippers, out validRect);
      int num;
      switch (this.Canvas.rootCanvas.renderMode)
      {
        case RenderMode.ScreenSpaceOverlay:
        case RenderMode.ScreenSpaceCamera:
          num = !andClipWorldRect.Overlaps(this.rootCanvasRect, true) ? 1 : 0;
          break;
        default:
          num = 0;
          break;
      }
      bool flag1 = num != 0;
      bool flag2 = andClipWorldRect != this.m_LastClipRectCanvasSpace;
      bool forceClip = this.m_ForceClip;
      foreach (IClippable clipTarget in this.m_ClipTargets)
      {
        if (flag2 || forceClip)
          clipTarget.SetClipRect(andClipWorldRect, validRect);
        MaskableGraphic maskableGraphic = clipTarget as MaskableGraphic;
        if (!((UnityEngine.Object) maskableGraphic != (UnityEngine.Object) null) || maskableGraphic.canvasRenderer.hasMoved || flag2)
          clipTarget.Cull(!flag1 ? andClipWorldRect : Rect.zero, !flag1 && validRect);
      }
      this.m_LastClipRectCanvasSpace = andClipWorldRect;
      this.m_ForceClip = false;
    }

    /// <summary>
    ///   <para>Add a [IClippable]] to be tracked by the mask.</para>
    /// </summary>
    /// <param name="clippable"></param>
    public void AddClippable(IClippable clippable)
    {
      if (clippable == null)
        return;
      this.m_ShouldRecalculateClipRects = true;
      if (!this.m_ClipTargets.Contains(clippable))
        this.m_ClipTargets.Add(clippable);
      this.m_ForceClip = true;
    }

    /// <summary>
    ///   <para>Remove an IClippable from being tracked by the mask.</para>
    /// </summary>
    /// <param name="clippable"></param>
    public void RemoveClippable(IClippable clippable)
    {
      if (clippable == null)
        return;
      this.m_ShouldRecalculateClipRects = true;
      clippable.SetClipRect(new Rect(), false);
      this.m_ClipTargets.Remove(clippable);
      this.m_ForceClip = true;
    }

    protected override void OnTransformParentChanged()
    {
      base.OnTransformParentChanged();
      this.m_ShouldRecalculateClipRects = true;
    }

    protected override void OnCanvasHierarchyChanged()
    {
      this.m_Canvas = (Canvas) null;
      base.OnCanvasHierarchyChanged();
      this.m_ShouldRecalculateClipRects = true;
    }
  }
}
