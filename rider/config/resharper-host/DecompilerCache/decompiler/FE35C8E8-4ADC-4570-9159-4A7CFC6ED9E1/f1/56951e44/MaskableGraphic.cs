// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.MaskableGraphic
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE35C8E8-4ADC-4570-9159-4A7CFC6ED9E1
// Assembly location: D:\Unity\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>A Graphic that is capable of being masked out.</para>
  /// </summary>
  public abstract class MaskableGraphic : Graphic, IClippable, IMaskable, IMaterialModifier
  {
    [NonSerialized]
    protected bool m_ShouldRecalculateStencil = true;
    [NonSerialized]
    private bool m_Maskable = true;
    [Obsolete("Not used anymore.", true)]
    [NonSerialized]
    protected bool m_IncludeForMasking = false;
    [SerializeField]
    private MaskableGraphic.CullStateChangedEvent m_OnCullStateChanged = new MaskableGraphic.CullStateChangedEvent();
    [Obsolete("Not used anymore", true)]
    [NonSerialized]
    protected bool m_ShouldRecalculate = true;
    private readonly Vector3[] m_Corners = new Vector3[4];
    [NonSerialized]
    protected Material m_MaskMaterial;
    [NonSerialized]
    private RectMask2D m_ParentMask;
    [NonSerialized]
    protected int m_StencilValue;

    /// <summary>
    ///   <para>Callback issued when culling changes.</para>
    /// </summary>
    public MaskableGraphic.CullStateChangedEvent onCullStateChanged
    {
      get
      {
        return this.m_OnCullStateChanged;
      }
      set
      {
        this.m_OnCullStateChanged = value;
      }
    }

    /// <summary>
    ///   <para>Does this graphic allow masking.</para>
    /// </summary>
    public bool maskable
    {
      get
      {
        return this.m_Maskable;
      }
      set
      {
        if (value == this.m_Maskable)
          return;
        this.m_Maskable = value;
        this.m_ShouldRecalculateStencil = true;
        this.SetMaterialDirty();
      }
    }

    /// <summary>
    ///   <para>See IMaterialModifier.GetModifiedMaterial.</para>
    /// </summary>
    /// <param name="baseMaterial"></param>
    public virtual Material GetModifiedMaterial(Material baseMaterial)
    {
      Material baseMat = baseMaterial;
      if (this.m_ShouldRecalculateStencil)
      {
        this.m_StencilValue = !this.maskable ? 0 : MaskUtilities.GetStencilDepth(this.transform, MaskUtilities.FindRootSortOverrideCanvas(this.transform));
        this.m_ShouldRecalculateStencil = false;
      }
      Mask component = this.GetComponent<Mask>();
      if (this.m_StencilValue > 0 && ((UnityEngine.Object) component == (UnityEngine.Object) null || !component.IsActive()))
      {
        Material material = StencilMaterial.Add(baseMat, (1 << this.m_StencilValue) - 1, StencilOp.Keep, CompareFunction.Equal, ColorWriteMask.All, (1 << this.m_StencilValue) - 1, 0);
        StencilMaterial.Remove(this.m_MaskMaterial);
        this.m_MaskMaterial = material;
        baseMat = this.m_MaskMaterial;
      }
      return baseMat;
    }

    /// <summary>
    ///   <para>See IClippable.Cull.</para>
    /// </summary>
    /// <param name="clipRect"></param>
    /// <param name="validRect"></param>
    public virtual void Cull(Rect clipRect, bool validRect)
    {
      this.UpdateCull(!validRect || !clipRect.Overlaps(this.rootCanvasRect, true));
    }

    private void UpdateCull(bool cull)
    {
      if (this.canvasRenderer.cull == cull)
        return;
      this.canvasRenderer.cull = cull;
      UISystemProfilerApi.AddMarker("MaskableGraphic.cullingChanged", (UnityEngine.Object) this);
      this.m_OnCullStateChanged.Invoke(cull);
      this.OnCullingChanged();
    }

    /// <summary>
    ///   <para>See IClippable.SetClipRect.</para>
    /// </summary>
    /// <param name="clipRect"></param>
    /// <param name="validRect"></param>
    public virtual void SetClipRect(Rect clipRect, bool validRect)
    {
      if (validRect)
        this.canvasRenderer.EnableRectClipping(clipRect);
      else
        this.canvasRenderer.DisableRectClipping();
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      this.m_ShouldRecalculateStencil = true;
      this.UpdateClipParent();
      this.SetMaterialDirty();
      if (!((UnityEngine.Object) this.GetComponent<Mask>() != (UnityEngine.Object) null))
        return;
      MaskUtilities.NotifyStencilStateChanged((Component) this);
    }

    /// <summary>
    ///   <para>See MonoBehaviour.OnDisable.</para>
    /// </summary>
    protected override void OnDisable()
    {
      base.OnDisable();
      this.m_ShouldRecalculateStencil = true;
      this.SetMaterialDirty();
      this.UpdateClipParent();
      StencilMaterial.Remove(this.m_MaskMaterial);
      this.m_MaskMaterial = (Material) null;
      if (!((UnityEngine.Object) this.GetComponent<Mask>() != (UnityEngine.Object) null))
        return;
      MaskUtilities.NotifyStencilStateChanged((Component) this);
    }

    protected override void OnValidate()
    {
      base.OnValidate();
      this.m_ShouldRecalculateStencil = true;
      this.UpdateClipParent();
      this.SetMaterialDirty();
    }

    protected override void OnTransformParentChanged()
    {
      base.OnTransformParentChanged();
      if (!this.isActiveAndEnabled)
        return;
      this.m_ShouldRecalculateStencil = true;
      this.UpdateClipParent();
      this.SetMaterialDirty();
    }

    /// <summary>
    ///   <para>See: IMaskable.</para>
    /// </summary>
    [Obsolete("Not used anymore.", true)]
    public virtual void ParentMaskStateChanged()
    {
    }

    protected override void OnCanvasHierarchyChanged()
    {
      base.OnCanvasHierarchyChanged();
      if (!this.isActiveAndEnabled)
        return;
      this.m_ShouldRecalculateStencil = true;
      this.UpdateClipParent();
      this.SetMaterialDirty();
    }

    private Rect rootCanvasRect
    {
      get
      {
        this.rectTransform.GetWorldCorners(this.m_Corners);
        if ((bool) ((UnityEngine.Object) this.canvas))
        {
          Matrix4x4 worldToLocalMatrix = this.canvas.rootCanvas.transform.worldToLocalMatrix;
          for (int index = 0; index < 4; ++index)
            this.m_Corners[index] = worldToLocalMatrix.MultiplyPoint(this.m_Corners[index]);
        }
        return new Rect(this.m_Corners[0].x, this.m_Corners[0].y, this.m_Corners[2].x - this.m_Corners[0].x, this.m_Corners[2].y - this.m_Corners[0].y);
      }
    }

    private void UpdateClipParent()
    {
      RectMask2D rectMask2D = !this.maskable || !this.IsActive() ? (RectMask2D) null : MaskUtilities.GetRectMaskForClippable((IClippable) this);
      if ((UnityEngine.Object) this.m_ParentMask != (UnityEngine.Object) null && ((UnityEngine.Object) rectMask2D != (UnityEngine.Object) this.m_ParentMask || !rectMask2D.IsActive()))
      {
        this.m_ParentMask.RemoveClippable((IClippable) this);
        this.UpdateCull(false);
      }
      if ((UnityEngine.Object) rectMask2D != (UnityEngine.Object) null && rectMask2D.IsActive())
        rectMask2D.AddClippable((IClippable) this);
      this.m_ParentMask = rectMask2D;
    }

    /// <summary>
    ///   <para>See: IClippable.RecalculateClipping.</para>
    /// </summary>
    public virtual void RecalculateClipping()
    {
      this.UpdateClipParent();
    }

    /// <summary>
    ///   <para>See: IMaskable.RecalculateMasking.</para>
    /// </summary>
    public virtual void RecalculateMasking()
    {
      this.m_ShouldRecalculateStencil = true;
      this.SetMaterialDirty();
    }

    GameObject IClippable.get_gameObject()
    {
      return this.gameObject;
    }

    [Serializable]
    public class CullStateChangedEvent : UnityEvent<bool>
    {
    }
  }
}
