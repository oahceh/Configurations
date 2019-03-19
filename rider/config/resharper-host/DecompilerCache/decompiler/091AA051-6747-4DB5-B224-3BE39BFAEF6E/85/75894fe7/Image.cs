// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.Image
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 091AA051-6747-4DB5-B224-3BE39BFAEF6E
// Assembly location: C:\Program Files\Unity2018.3.6f1\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine.Sprites;
using UnityEngine.U2D;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>Displays a Sprite for the UI System.</para>
  /// </summary>
  [AddComponentMenu("UI/Image", 11)]
  public class Image : MaskableGraphic, ISerializationCallbackReceiver, ILayoutElement, ICanvasRaycastFilter
  {
    protected static Material s_ETC1DefaultUI = (Material) null;
    private static readonly Vector2[] s_VertScratch = new Vector2[4];
    private static readonly Vector2[] s_UVScratch = new Vector2[4];
    private static readonly Vector3[] s_Xy = new Vector3[4];
    private static readonly Vector3[] s_Uv = new Vector3[4];
    private static List<Image> m_TrackedTexturelessImages = new List<Image>();
    [SerializeField]
    private Image.Type m_Type = Image.Type.Simple;
    [SerializeField]
    private bool m_PreserveAspect = false;
    [SerializeField]
    private bool m_FillCenter = true;
    [SerializeField]
    private Image.FillMethod m_FillMethod = Image.FillMethod.Radial360;
    [Range(0.0f, 1f)]
    [SerializeField]
    private float m_FillAmount = 1f;
    [SerializeField]
    private bool m_FillClockwise = true;
    private float m_AlphaHitTestMinimumThreshold = 0.0f;
    private bool m_Tracked = false;
    [FormerlySerializedAs("m_Frame")]
    [SerializeField]
    private Sprite m_Sprite;
    [NonSerialized]
    private Sprite m_OverrideSprite;
    [SerializeField]
    private int m_FillOrigin;
    [SerializeField]
    private bool m_UseSpriteMesh;
    private static bool s_Initialized;

    protected Image()
    {
      this.useLegacyMeshGeneration = false;
    }

    /// <summary>
    ///   <para>The sprite that is used to render this image.</para>
    /// </summary>
    public Sprite sprite
    {
      get
      {
        return this.m_Sprite;
      }
      set
      {
        if (!SetPropertyUtility.SetClass<Sprite>(ref this.m_Sprite, value))
          return;
        this.SetAllDirty();
        this.TrackSprite();
      }
    }

    /// <summary>
    ///   <para>Set an override sprite to be used for rendering.</para>
    /// </summary>
    public Sprite overrideSprite
    {
      get
      {
        return this.activeSprite;
      }
      set
      {
        if (!SetPropertyUtility.SetClass<Sprite>(ref this.m_OverrideSprite, value))
          return;
        this.SetAllDirty();
        this.TrackSprite();
      }
    }

    private Sprite activeSprite
    {
      get
      {
        return !((UnityEngine.Object) this.m_OverrideSprite != (UnityEngine.Object) null) ? this.sprite : this.m_OverrideSprite;
      }
    }

    /// <summary>
    ///   <para>How to display the image.</para>
    /// </summary>
    public Image.Type type
    {
      get
      {
        return this.m_Type;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<Image.Type>(ref this.m_Type, value))
          return;
        this.SetVerticesDirty();
      }
    }

    /// <summary>
    ///   <para>Whether this image should preserve its Sprite aspect ratio.</para>
    /// </summary>
    public bool preserveAspect
    {
      get
      {
        return this.m_PreserveAspect;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<bool>(ref this.m_PreserveAspect, value))
          return;
        this.SetVerticesDirty();
      }
    }

    /// <summary>
    ///   <para>Whether or not to render the center of a Tiled or Sliced image.</para>
    /// </summary>
    public bool fillCenter
    {
      get
      {
        return this.m_FillCenter;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<bool>(ref this.m_FillCenter, value))
          return;
        this.SetVerticesDirty();
      }
    }

    /// <summary>
    ///   <para>What type of fill method to use.</para>
    /// </summary>
    public Image.FillMethod fillMethod
    {
      get
      {
        return this.m_FillMethod;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<Image.FillMethod>(ref this.m_FillMethod, value))
          return;
        this.SetVerticesDirty();
        this.m_FillOrigin = 0;
      }
    }

    /// <summary>
    ///   <para>Amount of the Image shown when the Image.type is set to Image.Type.Filled.</para>
    /// </summary>
    public float fillAmount
    {
      get
      {
        return this.m_FillAmount;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<float>(ref this.m_FillAmount, Mathf.Clamp01(value)))
          return;
        this.SetVerticesDirty();
      }
    }

    /// <summary>
    ///   <para>Whether the Image should be filled clockwise (true) or counter-clockwise (false).</para>
    /// </summary>
    public bool fillClockwise
    {
      get
      {
        return this.m_FillClockwise;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<bool>(ref this.m_FillClockwise, value))
          return;
        this.SetVerticesDirty();
      }
    }

    /// <summary>
    ///   <para>Controls the origin point of the Fill process. Value means different things with each fill method.</para>
    /// </summary>
    public int fillOrigin
    {
      get
      {
        return this.m_FillOrigin;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<int>(ref this.m_FillOrigin, value))
          return;
        this.SetVerticesDirty();
      }
    }

    /// <summary>
    ///   <para>The alpha threshold specifies the minimum alpha a pixel must have for the event to considered a "hit" on the Image.</para>
    /// </summary>
    [Obsolete("eventAlphaThreshold has been deprecated. Use eventMinimumAlphaThreshold instead (UnityUpgradable) -> alphaHitTestMinimumThreshold")]
    public float eventAlphaThreshold
    {
      get
      {
        return 1f - this.alphaHitTestMinimumThreshold;
      }
      set
      {
        this.alphaHitTestMinimumThreshold = 1f - value;
      }
    }

    /// <summary>
    ///   <para>The alpha threshold specifies the minimum alpha a pixel must have for the event to considered a "hit" on the Image.</para>
    /// </summary>
    public float alphaHitTestMinimumThreshold
    {
      get
      {
        return this.m_AlphaHitTestMinimumThreshold;
      }
      set
      {
        this.m_AlphaHitTestMinimumThreshold = value;
      }
    }

    /// <summary>
    ///   <para>Allows you to specify whether the UI Image should be displayed using the mesh generated by the TextureImporter, or by a simple quad mesh.</para>
    /// </summary>
    public bool useSpriteMesh
    {
      get
      {
        return this.m_UseSpriteMesh;
      }
      set
      {
        if (!SetPropertyUtility.SetStruct<bool>(ref this.m_UseSpriteMesh, value))
          return;
        this.SetVerticesDirty();
      }
    }

    /// <summary>
    ///   <para>Cache of the default Canvas Ericsson Texture Compression 1 (ETC1) and alpha Material.</para>
    /// </summary>
    public static Material defaultETC1GraphicMaterial
    {
      get
      {
        if ((UnityEngine.Object) Image.s_ETC1DefaultUI == (UnityEngine.Object) null)
          Image.s_ETC1DefaultUI = Canvas.GetETC1SupportedCanvasMaterial();
        return Image.s_ETC1DefaultUI;
      }
    }

    /// <summary>
    ///   <para>The image's texture. (ReadOnly).</para>
    /// </summary>
    public override Texture mainTexture
    {
      get
      {
        if (!((UnityEngine.Object) this.activeSprite == (UnityEngine.Object) null))
          return (Texture) this.activeSprite.texture;
        if ((UnityEngine.Object) this.material != (UnityEngine.Object) null && (UnityEngine.Object) this.material.mainTexture != (UnityEngine.Object) null)
          return this.material.mainTexture;
        return (Texture) Graphic.s_WhiteTexture;
      }
    }

    /// <summary>
    ///   <para>True if the sprite used has borders.</para>
    /// </summary>
    public bool hasBorder
    {
      get
      {
        if ((UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null)
          return (double) this.activeSprite.border.sqrMagnitude > 0.0;
        return false;
      }
    }

    public float pixelsPerUnit
    {
      get
      {
        float num1 = 100f;
        if ((bool) ((UnityEngine.Object) this.activeSprite))
          num1 = this.activeSprite.pixelsPerUnit;
        float num2 = 100f;
        if ((bool) ((UnityEngine.Object) this.canvas))
          num2 = this.canvas.referencePixelsPerUnit;
        return num1 / num2;
      }
    }

    /// <summary>
    ///   <para>The specified Material used by this Image. The default Material is used instead if one wasn't specified.</para>
    /// </summary>
    public override Material material
    {
      get
      {
        if ((UnityEngine.Object) this.m_Material != (UnityEngine.Object) null)
          return this.m_Material;
        if (Application.isPlaying && (bool) ((UnityEngine.Object) this.activeSprite) && (UnityEngine.Object) this.activeSprite.associatedAlphaSplitTexture != (UnityEngine.Object) null)
          return Image.defaultETC1GraphicMaterial;
        return this.defaultMaterial;
      }
      set
      {
        base.material = value;
      }
    }

    /// <summary>
    ///   <para>Serialization Callback.</para>
    /// </summary>
    public virtual void OnBeforeSerialize()
    {
    }

    /// <summary>
    ///   <para>Serialization Callback.</para>
    /// </summary>
    public virtual void OnAfterDeserialize()
    {
      if (this.m_FillOrigin < 0)
        this.m_FillOrigin = 0;
      else if (this.m_FillMethod == Image.FillMethod.Horizontal && this.m_FillOrigin > 1)
        this.m_FillOrigin = 0;
      else if (this.m_FillMethod == Image.FillMethod.Vertical && this.m_FillOrigin > 1)
        this.m_FillOrigin = 0;
      else if (this.m_FillOrigin > 3)
        this.m_FillOrigin = 0;
      this.m_FillAmount = Mathf.Clamp(this.m_FillAmount, 0.0f, 1f);
    }

    private void PreserveSpriteAspectRatio(ref Rect rect, Vector2 spriteSize)
    {
      float num1 = spriteSize.x / spriteSize.y;
      float num2 = rect.width / rect.height;
      if ((double) num1 > (double) num2)
      {
        float height = rect.height;
        rect.height = rect.width * (1f / num1);
        rect.y += (height - rect.height) * this.rectTransform.pivot.y;
      }
      else
      {
        float width = rect.width;
        rect.width = rect.height * num1;
        rect.x += (width - rect.width) * this.rectTransform.pivot.x;
      }
    }

    private Vector4 GetDrawingDimensions(bool shouldPreserveAspect)
    {
      Vector4 vector4_1 = !((UnityEngine.Object) this.activeSprite == (UnityEngine.Object) null) ? DataUtility.GetPadding(this.activeSprite) : Vector4.zero;
      Vector2 spriteSize = !((UnityEngine.Object) this.activeSprite == (UnityEngine.Object) null) ? new Vector2(this.activeSprite.rect.width, this.activeSprite.rect.height) : Vector2.zero;
      Rect pixelAdjustedRect = this.GetPixelAdjustedRect();
      int num1 = Mathf.RoundToInt(spriteSize.x);
      int num2 = Mathf.RoundToInt(spriteSize.y);
      Vector4 vector4_2 = new Vector4(vector4_1.x / (float) num1, vector4_1.y / (float) num2, ((float) num1 - vector4_1.z) / (float) num1, ((float) num2 - vector4_1.w) / (float) num2);
      if (shouldPreserveAspect && (double) spriteSize.sqrMagnitude > 0.0)
        this.PreserveSpriteAspectRatio(ref pixelAdjustedRect, spriteSize);
      vector4_2 = new Vector4(pixelAdjustedRect.x + pixelAdjustedRect.width * vector4_2.x, pixelAdjustedRect.y + pixelAdjustedRect.height * vector4_2.y, pixelAdjustedRect.x + pixelAdjustedRect.width * vector4_2.z, pixelAdjustedRect.y + pixelAdjustedRect.height * vector4_2.w);
      return vector4_2;
    }

    /// <summary>
    ///   <para>Adjusts the image size to make it pixel-perfect.</para>
    /// </summary>
    public override void SetNativeSize()
    {
      if (!((UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null))
        return;
      float x = this.activeSprite.rect.width / this.pixelsPerUnit;
      float y = this.activeSprite.rect.height / this.pixelsPerUnit;
      this.rectTransform.anchorMax = this.rectTransform.anchorMin;
      this.rectTransform.sizeDelta = new Vector2(x, y);
      this.SetAllDirty();
    }

    protected override void OnPopulateMesh(VertexHelper toFill)
    {
      if ((UnityEngine.Object) this.activeSprite == (UnityEngine.Object) null)
      {
        base.OnPopulateMesh(toFill);
      }
      else
      {
        switch (this.type)
        {
          case Image.Type.Simple:
            if (!this.useSpriteMesh)
            {
              this.GenerateSimpleSprite(toFill, this.m_PreserveAspect);
              break;
            }
            this.GenerateSprite(toFill, this.m_PreserveAspect);
            break;
          case Image.Type.Sliced:
            this.GenerateSlicedSprite(toFill);
            break;
          case Image.Type.Tiled:
            this.GenerateTiledSprite(toFill);
            break;
          case Image.Type.Filled:
            this.GenerateFilledSprite(toFill, this.m_PreserveAspect);
            break;
        }
      }
    }

    private void TrackSprite()
    {
      if (!((UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null) || !((UnityEngine.Object) this.activeSprite.texture == (UnityEngine.Object) null))
        return;
      Image.TrackImage(this);
      this.m_Tracked = true;
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      this.TrackSprite();
    }

    protected override void OnDisable()
    {
      base.OnDisable();
      if (!this.m_Tracked)
        return;
      Image.UnTrackImage(this);
    }

    protected override void UpdateMaterial()
    {
      base.UpdateMaterial();
      if ((UnityEngine.Object) this.activeSprite == (UnityEngine.Object) null)
      {
        this.canvasRenderer.SetAlphaTexture((Texture) null);
      }
      else
      {
        Texture2D alphaSplitTexture = this.activeSprite.associatedAlphaSplitTexture;
        if (!((UnityEngine.Object) alphaSplitTexture != (UnityEngine.Object) null))
          return;
        this.canvasRenderer.SetAlphaTexture((Texture) alphaSplitTexture);
      }
    }

    private void GenerateSimpleSprite(VertexHelper vh, bool lPreserveAspect)
    {
      Vector4 drawingDimensions = this.GetDrawingDimensions(lPreserveAspect);
      Vector4 vector4 = !((UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null) ? Vector4.zero : DataUtility.GetOuterUV(this.activeSprite);
      Color color = this.color;
      vh.Clear();
      vh.AddVert(new Vector3(drawingDimensions.x, drawingDimensions.y), (Color32) color, new Vector2(vector4.x, vector4.y));
      vh.AddVert(new Vector3(drawingDimensions.x, drawingDimensions.w), (Color32) color, new Vector2(vector4.x, vector4.w));
      vh.AddVert(new Vector3(drawingDimensions.z, drawingDimensions.w), (Color32) color, new Vector2(vector4.z, vector4.w));
      vh.AddVert(new Vector3(drawingDimensions.z, drawingDimensions.y), (Color32) color, new Vector2(vector4.z, vector4.y));
      vh.AddTriangle(0, 1, 2);
      vh.AddTriangle(2, 3, 0);
    }

    private void GenerateSprite(VertexHelper vh, bool lPreserveAspect)
    {
      Vector2 spriteSize = new Vector2(this.activeSprite.rect.width, this.activeSprite.rect.height);
      Vector2 vector2_1 = this.activeSprite.pivot / spriteSize;
      Vector2 pivot = this.rectTransform.pivot;
      Rect pixelAdjustedRect = this.GetPixelAdjustedRect();
      if (lPreserveAspect & (double) spriteSize.sqrMagnitude > 0.0)
        this.PreserveSpriteAspectRatio(ref pixelAdjustedRect, spriteSize);
      Vector2 vector2_2 = new Vector2(pixelAdjustedRect.width, pixelAdjustedRect.height);
      Vector3 size = this.activeSprite.bounds.size;
      Vector2 vector2_3 = (pivot - vector2_1) * vector2_2;
      Color color = this.color;
      vh.Clear();
      Vector2[] vertices = this.activeSprite.vertices;
      Vector2[] uv = this.activeSprite.uv;
      for (int index = 0; index < vertices.Length; ++index)
        vh.AddVert(new Vector3(vertices[index].x / size.x * vector2_2.x - vector2_3.x, vertices[index].y / size.y * vector2_2.y - vector2_3.y), (Color32) color, new Vector2(uv[index].x, uv[index].y));
      ushort[] triangles = this.activeSprite.triangles;
      for (int index = 0; index < triangles.Length; index += 3)
        vh.AddTriangle((int) triangles[index], (int) triangles[index + 1], (int) triangles[index + 2]);
    }

    private void GenerateSlicedSprite(VertexHelper toFill)
    {
      if (!this.hasBorder)
      {
        this.GenerateSimpleSprite(toFill, false);
      }
      else
      {
        Vector4 vector4_1;
        Vector4 vector4_2;
        Vector4 vector4_3;
        Vector4 vector4_4;
        if ((UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null)
        {
          vector4_1 = DataUtility.GetOuterUV(this.activeSprite);
          vector4_2 = DataUtility.GetInnerUV(this.activeSprite);
          vector4_3 = DataUtility.GetPadding(this.activeSprite);
          vector4_4 = this.activeSprite.border;
        }
        else
        {
          vector4_1 = Vector4.zero;
          vector4_2 = Vector4.zero;
          vector4_3 = Vector4.zero;
          vector4_4 = Vector4.zero;
        }
        Rect pixelAdjustedRect = this.GetPixelAdjustedRect();
        Vector4 adjustedBorders = this.GetAdjustedBorders(vector4_4 / this.pixelsPerUnit, pixelAdjustedRect);
        Vector4 vector4_5 = vector4_3 / this.pixelsPerUnit;
        Image.s_VertScratch[0] = new Vector2(vector4_5.x, vector4_5.y);
        Image.s_VertScratch[3] = new Vector2(pixelAdjustedRect.width - vector4_5.z, pixelAdjustedRect.height - vector4_5.w);
        Image.s_VertScratch[1].x = adjustedBorders.x;
        Image.s_VertScratch[1].y = adjustedBorders.y;
        Image.s_VertScratch[2].x = pixelAdjustedRect.width - adjustedBorders.z;
        Image.s_VertScratch[2].y = pixelAdjustedRect.height - adjustedBorders.w;
        for (int index = 0; index < 4; ++index)
        {
          Image.s_VertScratch[index].x += pixelAdjustedRect.x;
          Image.s_VertScratch[index].y += pixelAdjustedRect.y;
        }
        Image.s_UVScratch[0] = new Vector2(vector4_1.x, vector4_1.y);
        Image.s_UVScratch[1] = new Vector2(vector4_2.x, vector4_2.y);
        Image.s_UVScratch[2] = new Vector2(vector4_2.z, vector4_2.w);
        Image.s_UVScratch[3] = new Vector2(vector4_1.z, vector4_1.w);
        toFill.Clear();
        for (int index1 = 0; index1 < 3; ++index1)
        {
          int index2 = index1 + 1;
          for (int index3 = 0; index3 < 3; ++index3)
          {
            if (this.m_FillCenter || index1 != 1 || index3 != 1)
            {
              int index4 = index3 + 1;
              Image.AddQuad(toFill, new Vector2(Image.s_VertScratch[index1].x, Image.s_VertScratch[index3].y), new Vector2(Image.s_VertScratch[index2].x, Image.s_VertScratch[index4].y), (Color32) this.color, new Vector2(Image.s_UVScratch[index1].x, Image.s_UVScratch[index3].y), new Vector2(Image.s_UVScratch[index2].x, Image.s_UVScratch[index4].y));
            }
          }
        }
      }
    }

    private void GenerateTiledSprite(VertexHelper toFill)
    {
      Vector4 vector4_1;
      Vector4 vector4_2;
      Vector4 vector4_3;
      Vector2 vector2_1;
      if ((UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null)
      {
        vector4_1 = DataUtility.GetOuterUV(this.activeSprite);
        vector4_2 = DataUtility.GetInnerUV(this.activeSprite);
        vector4_3 = this.activeSprite.border;
        vector2_1 = this.activeSprite.rect.size;
      }
      else
      {
        vector4_1 = Vector4.zero;
        vector4_2 = Vector4.zero;
        vector4_3 = Vector4.zero;
        vector2_1 = Vector2.one * 100f;
      }
      Rect pixelAdjustedRect = this.GetPixelAdjustedRect();
      float num1 = (vector2_1.x - vector4_3.x - vector4_3.z) / this.pixelsPerUnit;
      float num2 = (vector2_1.y - vector4_3.y - vector4_3.w) / this.pixelsPerUnit;
      vector4_3 = this.GetAdjustedBorders(vector4_3 / this.pixelsPerUnit, pixelAdjustedRect);
      Vector2 vector2_2 = new Vector2(vector4_2.x, vector4_2.y);
      Vector2 a = new Vector2(vector4_2.z, vector4_2.w);
      float x1 = vector4_3.x;
      float x2 = pixelAdjustedRect.width - vector4_3.z;
      float y1 = vector4_3.y;
      float y2 = pixelAdjustedRect.height - vector4_3.w;
      toFill.Clear();
      Vector2 uvMax = a;
      if ((double) num1 <= 0.0)
        num1 = x2 - x1;
      if ((double) num2 <= 0.0)
        num2 = y2 - y1;
      if ((UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null && (this.hasBorder || this.activeSprite.packed || this.activeSprite.texture.wrapMode != TextureWrapMode.Repeat))
      {
        long num3;
        long num4;
        if (this.m_FillCenter)
        {
          num3 = (long) Math.Ceiling(((double) x2 - (double) x1) / (double) num1);
          num4 = (long) Math.Ceiling(((double) y2 - (double) y1) / (double) num2);
          if ((!this.hasBorder ? (double) (num3 * num4) * 4.0 : ((double) num3 + 2.0) * ((double) num4 + 2.0) * 4.0) > 65000.0)
          {
            Debug.LogError((object) ("Too many sprite tiles on Image \"" + this.name + "\". The tile size will be increased. To remove the limit on the number of tiles, convert the Sprite to an Advanced texture, remove the borders, clear the Packing tag and set the Wrap mode to Repeat."), (UnityEngine.Object) this);
            double num5 = 16250.0;
            double num6 = !this.hasBorder ? (double) num3 / (double) num4 : ((double) num3 + 2.0) / ((double) num4 + 2.0);
            double d1 = Math.Sqrt(num5 / num6);
            double d2 = d1 * num6;
            if (this.hasBorder)
            {
              d1 -= 2.0;
              d2 -= 2.0;
            }
            num3 = (long) Math.Floor(d1);
            num4 = (long) Math.Floor(d2);
            num1 = (x2 - x1) / (float) num3;
            num2 = (y2 - y1) / (float) num4;
          }
        }
        else if (this.hasBorder)
        {
          num3 = (long) Math.Ceiling(((double) x2 - (double) x1) / (double) num1);
          num4 = (long) Math.Ceiling(((double) y2 - (double) y1) / (double) num2);
          if (((double) (num4 + num3) + 2.0) * 2.0 * 4.0 > 65000.0)
          {
            Debug.LogError((object) ("Too many sprite tiles on Image \"" + this.name + "\". The tile size will be increased. To remove the limit on the number of tiles, convert the Sprite to an Advanced texture, remove the borders, clear the Packing tag and set the Wrap mode to Repeat."), (UnityEngine.Object) this);
            double num5 = 16250.0;
            double num6 = (double) num3 / (double) num4;
            double d1 = (num5 - 4.0) / (2.0 * (1.0 + num6));
            double d2 = d1 * num6;
            num3 = (long) Math.Floor(d1);
            num4 = (long) Math.Floor(d2);
            num1 = (x2 - x1) / (float) num3;
            num2 = (y2 - y1) / (float) num4;
          }
        }
        else
          num4 = num3 = 0L;
        if (this.m_FillCenter)
        {
          for (long index1 = 0; index1 < num4; ++index1)
          {
            float y3 = y1 + (float) index1 * num2;
            float y4 = y1 + (float) (index1 + 1L) * num2;
            if ((double) y4 > (double) y2)
            {
              uvMax.y = vector2_2.y + (float) (((double) a.y - (double) vector2_2.y) * ((double) y2 - (double) y3) / ((double) y4 - (double) y3));
              y4 = y2;
            }
            uvMax.x = a.x;
            for (long index2 = 0; index2 < num3; ++index2)
            {
              float x3 = x1 + (float) index2 * num1;
              float x4 = x1 + (float) (index2 + 1L) * num1;
              if ((double) x4 > (double) x2)
              {
                uvMax.x = vector2_2.x + (float) (((double) a.x - (double) vector2_2.x) * ((double) x2 - (double) x3) / ((double) x4 - (double) x3));
                x4 = x2;
              }
              Image.AddQuad(toFill, new Vector2(x3, y3) + pixelAdjustedRect.position, new Vector2(x4, y4) + pixelAdjustedRect.position, (Color32) this.color, vector2_2, uvMax);
            }
          }
        }
        if (!this.hasBorder)
          return;
        uvMax = a;
        for (long index = 0; index < num4; ++index)
        {
          float y3 = y1 + (float) index * num2;
          float y4 = y1 + (float) (index + 1L) * num2;
          if ((double) y4 > (double) y2)
          {
            uvMax.y = vector2_2.y + (float) (((double) a.y - (double) vector2_2.y) * ((double) y2 - (double) y3) / ((double) y4 - (double) y3));
            y4 = y2;
          }
          Image.AddQuad(toFill, new Vector2(0.0f, y3) + pixelAdjustedRect.position, new Vector2(x1, y4) + pixelAdjustedRect.position, (Color32) this.color, new Vector2(vector4_1.x, vector2_2.y), new Vector2(vector2_2.x, uvMax.y));
          Image.AddQuad(toFill, new Vector2(x2, y3) + pixelAdjustedRect.position, new Vector2(pixelAdjustedRect.width, y4) + pixelAdjustedRect.position, (Color32) this.color, new Vector2(a.x, vector2_2.y), new Vector2(vector4_1.z, uvMax.y));
        }
        uvMax = a;
        for (long index = 0; index < num3; ++index)
        {
          float x3 = x1 + (float) index * num1;
          float x4 = x1 + (float) (index + 1L) * num1;
          if ((double) x4 > (double) x2)
          {
            uvMax.x = vector2_2.x + (float) (((double) a.x - (double) vector2_2.x) * ((double) x2 - (double) x3) / ((double) x4 - (double) x3));
            x4 = x2;
          }
          Image.AddQuad(toFill, new Vector2(x3, 0.0f) + pixelAdjustedRect.position, new Vector2(x4, y1) + pixelAdjustedRect.position, (Color32) this.color, new Vector2(vector2_2.x, vector4_1.y), new Vector2(uvMax.x, vector2_2.y));
          Image.AddQuad(toFill, new Vector2(x3, y2) + pixelAdjustedRect.position, new Vector2(x4, pixelAdjustedRect.height) + pixelAdjustedRect.position, (Color32) this.color, new Vector2(vector2_2.x, a.y), new Vector2(uvMax.x, vector4_1.w));
        }
        Image.AddQuad(toFill, new Vector2(0.0f, 0.0f) + pixelAdjustedRect.position, new Vector2(x1, y1) + pixelAdjustedRect.position, (Color32) this.color, new Vector2(vector4_1.x, vector4_1.y), new Vector2(vector2_2.x, vector2_2.y));
        Image.AddQuad(toFill, new Vector2(x2, 0.0f) + pixelAdjustedRect.position, new Vector2(pixelAdjustedRect.width, y1) + pixelAdjustedRect.position, (Color32) this.color, new Vector2(a.x, vector4_1.y), new Vector2(vector4_1.z, vector2_2.y));
        Image.AddQuad(toFill, new Vector2(0.0f, y2) + pixelAdjustedRect.position, new Vector2(x1, pixelAdjustedRect.height) + pixelAdjustedRect.position, (Color32) this.color, new Vector2(vector4_1.x, a.y), new Vector2(vector2_2.x, vector4_1.w));
        Image.AddQuad(toFill, new Vector2(x2, y2) + pixelAdjustedRect.position, new Vector2(pixelAdjustedRect.width, pixelAdjustedRect.height) + pixelAdjustedRect.position, (Color32) this.color, new Vector2(a.x, a.y), new Vector2(vector4_1.z, vector4_1.w));
      }
      else
      {
        Vector2 b = new Vector2((x2 - x1) / num1, (y2 - y1) / num2);
        if (this.m_FillCenter)
          Image.AddQuad(toFill, new Vector2(x1, y1) + pixelAdjustedRect.position, new Vector2(x2, y2) + pixelAdjustedRect.position, (Color32) this.color, Vector2.Scale(vector2_2, b), Vector2.Scale(a, b));
      }
    }

    private static void AddQuad(
      VertexHelper vertexHelper,
      Vector3[] quadPositions,
      Color32 color,
      Vector3[] quadUVs)
    {
      int currentVertCount = vertexHelper.currentVertCount;
      for (int index = 0; index < 4; ++index)
        vertexHelper.AddVert(quadPositions[index], color, (Vector2) quadUVs[index]);
      vertexHelper.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
      vertexHelper.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
    }

    private static void AddQuad(
      VertexHelper vertexHelper,
      Vector2 posMin,
      Vector2 posMax,
      Color32 color,
      Vector2 uvMin,
      Vector2 uvMax)
    {
      int currentVertCount = vertexHelper.currentVertCount;
      vertexHelper.AddVert(new Vector3(posMin.x, posMin.y, 0.0f), color, new Vector2(uvMin.x, uvMin.y));
      vertexHelper.AddVert(new Vector3(posMin.x, posMax.y, 0.0f), color, new Vector2(uvMin.x, uvMax.y));
      vertexHelper.AddVert(new Vector3(posMax.x, posMax.y, 0.0f), color, new Vector2(uvMax.x, uvMax.y));
      vertexHelper.AddVert(new Vector3(posMax.x, posMin.y, 0.0f), color, new Vector2(uvMax.x, uvMin.y));
      vertexHelper.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
      vertexHelper.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
    }

    private Vector4 GetAdjustedBorders(Vector4 border, Rect adjustedRect)
    {
      Rect rect = this.rectTransform.rect;
      for (int index = 0; index <= 1; ++index)
      {
        if ((double) rect.size[index] != 0.0)
        {
          float num = adjustedRect.size[index] / rect.size[index];
          border[index] *= num;
          border[index + 2] *= num;
        }
        float num1 = border[index] + border[index + 2];
        if ((double) adjustedRect.size[index] < (double) num1 && (double) num1 != 0.0)
        {
          float num2 = adjustedRect.size[index] / num1;
          border[index] *= num2;
          border[index + 2] *= num2;
        }
      }
      return border;
    }

    private void GenerateFilledSprite(VertexHelper toFill, bool preserveAspect)
    {
      toFill.Clear();
      if ((double) this.m_FillAmount < 1.0 / 1000.0)
        return;
      Vector4 drawingDimensions = this.GetDrawingDimensions(preserveAspect);
      Vector4 vector4 = !((UnityEngine.Object) this.activeSprite != (UnityEngine.Object) null) ? Vector4.zero : DataUtility.GetOuterUV(this.activeSprite);
      UIVertex.simpleVert.color = (Color32) this.color;
      float num1 = vector4.x;
      float num2 = vector4.y;
      float num3 = vector4.z;
      float num4 = vector4.w;
      if (this.m_FillMethod == Image.FillMethod.Horizontal || this.m_FillMethod == Image.FillMethod.Vertical)
      {
        if (this.fillMethod == Image.FillMethod.Horizontal)
        {
          float num5 = (num3 - num1) * this.m_FillAmount;
          if (this.m_FillOrigin == 1)
          {
            drawingDimensions.x = drawingDimensions.z - (drawingDimensions.z - drawingDimensions.x) * this.m_FillAmount;
            num1 = num3 - num5;
          }
          else
          {
            drawingDimensions.z = drawingDimensions.x + (drawingDimensions.z - drawingDimensions.x) * this.m_FillAmount;
            num3 = num1 + num5;
          }
        }
        else if (this.fillMethod == Image.FillMethod.Vertical)
        {
          float num5 = (num4 - num2) * this.m_FillAmount;
          if (this.m_FillOrigin == 1)
          {
            drawingDimensions.y = drawingDimensions.w - (drawingDimensions.w - drawingDimensions.y) * this.m_FillAmount;
            num2 = num4 - num5;
          }
          else
          {
            drawingDimensions.w = drawingDimensions.y + (drawingDimensions.w - drawingDimensions.y) * this.m_FillAmount;
            num4 = num2 + num5;
          }
        }
      }
      Image.s_Xy[0] = (Vector3) new Vector2(drawingDimensions.x, drawingDimensions.y);
      Image.s_Xy[1] = (Vector3) new Vector2(drawingDimensions.x, drawingDimensions.w);
      Image.s_Xy[2] = (Vector3) new Vector2(drawingDimensions.z, drawingDimensions.w);
      Image.s_Xy[3] = (Vector3) new Vector2(drawingDimensions.z, drawingDimensions.y);
      Image.s_Uv[0] = (Vector3) new Vector2(num1, num2);
      Image.s_Uv[1] = (Vector3) new Vector2(num1, num4);
      Image.s_Uv[2] = (Vector3) new Vector2(num3, num4);
      Image.s_Uv[3] = (Vector3) new Vector2(num3, num2);
      if ((double) this.m_FillAmount < 1.0 && this.m_FillMethod != Image.FillMethod.Horizontal && this.m_FillMethod != Image.FillMethod.Vertical)
      {
        if (this.fillMethod == Image.FillMethod.Radial90)
        {
          if (Image.RadialCut(Image.s_Xy, Image.s_Uv, this.m_FillAmount, this.m_FillClockwise, this.m_FillOrigin))
            Image.AddQuad(toFill, Image.s_Xy, (Color32) this.color, Image.s_Uv);
        }
        else if (this.fillMethod == Image.FillMethod.Radial180)
        {
          for (int index = 0; index < 2; ++index)
          {
            int num5 = this.m_FillOrigin <= 1 ? 0 : 1;
            float t1;
            float t2;
            float t3;
            float t4;
            if (this.m_FillOrigin == 0 || this.m_FillOrigin == 2)
            {
              t1 = 0.0f;
              t2 = 1f;
              if (index == num5)
              {
                t3 = 0.0f;
                t4 = 0.5f;
              }
              else
              {
                t3 = 0.5f;
                t4 = 1f;
              }
            }
            else
            {
              t3 = 0.0f;
              t4 = 1f;
              if (index == num5)
              {
                t1 = 0.5f;
                t2 = 1f;
              }
              else
              {
                t1 = 0.0f;
                t2 = 0.5f;
              }
            }
            Image.s_Xy[0].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t3);
            Image.s_Xy[1].x = Image.s_Xy[0].x;
            Image.s_Xy[2].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t4);
            Image.s_Xy[3].x = Image.s_Xy[2].x;
            Image.s_Xy[0].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t1);
            Image.s_Xy[1].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t2);
            Image.s_Xy[2].y = Image.s_Xy[1].y;
            Image.s_Xy[3].y = Image.s_Xy[0].y;
            Image.s_Uv[0].x = Mathf.Lerp(num1, num3, t3);
            Image.s_Uv[1].x = Image.s_Uv[0].x;
            Image.s_Uv[2].x = Mathf.Lerp(num1, num3, t4);
            Image.s_Uv[3].x = Image.s_Uv[2].x;
            Image.s_Uv[0].y = Mathf.Lerp(num2, num4, t1);
            Image.s_Uv[1].y = Mathf.Lerp(num2, num4, t2);
            Image.s_Uv[2].y = Image.s_Uv[1].y;
            Image.s_Uv[3].y = Image.s_Uv[0].y;
            float num6 = !this.m_FillClockwise ? this.m_FillAmount * 2f - (float) (1 - index) : this.fillAmount * 2f - (float) index;
            if (Image.RadialCut(Image.s_Xy, Image.s_Uv, Mathf.Clamp01(num6), this.m_FillClockwise, (index + this.m_FillOrigin + 3) % 4))
              Image.AddQuad(toFill, Image.s_Xy, (Color32) this.color, Image.s_Uv);
          }
        }
        else if (this.fillMethod == Image.FillMethod.Radial360)
        {
          for (int index = 0; index < 4; ++index)
          {
            float t1;
            float t2;
            if (index < 2)
            {
              t1 = 0.0f;
              t2 = 0.5f;
            }
            else
            {
              t1 = 0.5f;
              t2 = 1f;
            }
            float t3;
            float t4;
            if (index == 0 || index == 3)
            {
              t3 = 0.0f;
              t4 = 0.5f;
            }
            else
            {
              t3 = 0.5f;
              t4 = 1f;
            }
            Image.s_Xy[0].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t1);
            Image.s_Xy[1].x = Image.s_Xy[0].x;
            Image.s_Xy[2].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t2);
            Image.s_Xy[3].x = Image.s_Xy[2].x;
            Image.s_Xy[0].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t3);
            Image.s_Xy[1].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t4);
            Image.s_Xy[2].y = Image.s_Xy[1].y;
            Image.s_Xy[3].y = Image.s_Xy[0].y;
            Image.s_Uv[0].x = Mathf.Lerp(num1, num3, t1);
            Image.s_Uv[1].x = Image.s_Uv[0].x;
            Image.s_Uv[2].x = Mathf.Lerp(num1, num3, t2);
            Image.s_Uv[3].x = Image.s_Uv[2].x;
            Image.s_Uv[0].y = Mathf.Lerp(num2, num4, t3);
            Image.s_Uv[1].y = Mathf.Lerp(num2, num4, t4);
            Image.s_Uv[2].y = Image.s_Uv[1].y;
            Image.s_Uv[3].y = Image.s_Uv[0].y;
            float num5 = !this.m_FillClockwise ? this.m_FillAmount * 4f - (float) (3 - (index + this.m_FillOrigin) % 4) : this.m_FillAmount * 4f - (float) ((index + this.m_FillOrigin) % 4);
            if (Image.RadialCut(Image.s_Xy, Image.s_Uv, Mathf.Clamp01(num5), this.m_FillClockwise, (index + 2) % 4))
              Image.AddQuad(toFill, Image.s_Xy, (Color32) this.color, Image.s_Uv);
          }
        }
      }
      else
        Image.AddQuad(toFill, Image.s_Xy, (Color32) this.color, Image.s_Uv);
    }

    private static bool RadialCut(
      Vector3[] xy,
      Vector3[] uv,
      float fill,
      bool invert,
      int corner)
    {
      if ((double) fill < 1.0 / 1000.0)
        return false;
      if ((corner & 1) == 1)
        invert = !invert;
      if (!invert && (double) fill > 0.999000012874603)
        return true;
      float num = Mathf.Clamp01(fill);
      if (invert)
        num = 1f - num;
      float f = num * 1.570796f;
      float cos = Mathf.Cos(f);
      float sin = Mathf.Sin(f);
      Image.RadialCut(xy, cos, sin, invert, corner);
      Image.RadialCut(uv, cos, sin, invert, corner);
      return true;
    }

    private static void RadialCut(Vector3[] xy, float cos, float sin, bool invert, int corner)
    {
      int index1 = corner;
      int index2 = (corner + 1) % 4;
      int index3 = (corner + 2) % 4;
      int index4 = (corner + 3) % 4;
      if ((corner & 1) == 1)
      {
        if ((double) sin > (double) cos)
        {
          cos /= sin;
          sin = 1f;
          if (invert)
          {
            xy[index2].x = Mathf.Lerp(xy[index1].x, xy[index3].x, cos);
            xy[index3].x = xy[index2].x;
          }
        }
        else if ((double) cos > (double) sin)
        {
          sin /= cos;
          cos = 1f;
          if (!invert)
          {
            xy[index3].y = Mathf.Lerp(xy[index1].y, xy[index3].y, sin);
            xy[index4].y = xy[index3].y;
          }
        }
        else
        {
          cos = 1f;
          sin = 1f;
        }
        if (!invert)
          xy[index4].x = Mathf.Lerp(xy[index1].x, xy[index3].x, cos);
        else
          xy[index2].y = Mathf.Lerp(xy[index1].y, xy[index3].y, sin);
      }
      else
      {
        if ((double) cos > (double) sin)
        {
          sin /= cos;
          cos = 1f;
          if (!invert)
          {
            xy[index2].y = Mathf.Lerp(xy[index1].y, xy[index3].y, sin);
            xy[index3].y = xy[index2].y;
          }
        }
        else if ((double) sin > (double) cos)
        {
          cos /= sin;
          sin = 1f;
          if (invert)
          {
            xy[index3].x = Mathf.Lerp(xy[index1].x, xy[index3].x, cos);
            xy[index4].x = xy[index3].x;
          }
        }
        else
        {
          cos = 1f;
          sin = 1f;
        }
        if (invert)
          xy[index4].y = Mathf.Lerp(xy[index1].y, xy[index3].y, sin);
        else
          xy[index2].x = Mathf.Lerp(xy[index1].x, xy[index3].x, cos);
      }
    }

    /// <summary>
    ///   <para>See ILayoutElement.CalculateLayoutInputHorizontal.</para>
    /// </summary>
    public virtual void CalculateLayoutInputHorizontal()
    {
    }

    /// <summary>
    ///   <para>See ILayoutElement.CalculateLayoutInputVertical.</para>
    /// </summary>
    public virtual void CalculateLayoutInputVertical()
    {
    }

    /// <summary>
    ///   <para>See ILayoutElement.minWidth.</para>
    /// </summary>
    public virtual float minWidth
    {
      get
      {
        return 0.0f;
      }
    }

    /// <summary>
    ///   <para>See ILayoutElement.preferredWidth.</para>
    /// </summary>
    public virtual float preferredWidth
    {
      get
      {
        if ((UnityEngine.Object) this.activeSprite == (UnityEngine.Object) null)
          return 0.0f;
        if (this.type == Image.Type.Sliced || this.type == Image.Type.Tiled)
          return DataUtility.GetMinSize(this.activeSprite).x / this.pixelsPerUnit;
        return this.activeSprite.rect.size.x / this.pixelsPerUnit;
      }
    }

    /// <summary>
    ///   <para>See ILayoutElement.flexibleWidth.</para>
    /// </summary>
    public virtual float flexibleWidth
    {
      get
      {
        return -1f;
      }
    }

    /// <summary>
    ///   <para>See ILayoutElement.minHeight.</para>
    /// </summary>
    public virtual float minHeight
    {
      get
      {
        return 0.0f;
      }
    }

    /// <summary>
    ///   <para>See ILayoutElement.preferredHeight.</para>
    /// </summary>
    public virtual float preferredHeight
    {
      get
      {
        if ((UnityEngine.Object) this.activeSprite == (UnityEngine.Object) null)
          return 0.0f;
        if (this.type == Image.Type.Sliced || this.type == Image.Type.Tiled)
          return DataUtility.GetMinSize(this.activeSprite).y / this.pixelsPerUnit;
        return this.activeSprite.rect.size.y / this.pixelsPerUnit;
      }
    }

    /// <summary>
    ///   <para>See ILayoutElement.flexibleHeight.</para>
    /// </summary>
    public virtual float flexibleHeight
    {
      get
      {
        return -1f;
      }
    }

    /// <summary>
    ///   <para>See ILayoutElement.layoutPriority.</para>
    /// </summary>
    public virtual int layoutPriority
    {
      get
      {
        return 0;
      }
    }

    /// <summary>
    ///   <para>See:ICanvasRaycastFilter.</para>
    /// </summary>
    /// <param name="screenPoint"></param>
    /// <param name="eventCamera"></param>
    public virtual bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {
      if ((double) this.alphaHitTestMinimumThreshold <= 0.0)
        return true;
      if ((double) this.alphaHitTestMinimumThreshold > 1.0)
        return false;
      if ((UnityEngine.Object) this.activeSprite == (UnityEngine.Object) null)
        return true;
      Vector2 localPoint;
      if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(this.rectTransform, screenPoint, eventCamera, out localPoint))
        return false;
      Rect pixelAdjustedRect = this.GetPixelAdjustedRect();
      localPoint.x += this.rectTransform.pivot.x * pixelAdjustedRect.width;
      localPoint.y += this.rectTransform.pivot.y * pixelAdjustedRect.height;
      localPoint = this.MapCoordinate(localPoint, pixelAdjustedRect);
      Rect textureRect = this.activeSprite.textureRect;
      Vector2 vector2 = new Vector2(localPoint.x / textureRect.width, localPoint.y / textureRect.height);
      float x = Mathf.Lerp(textureRect.x, textureRect.xMax, vector2.x) / (float) this.activeSprite.texture.width;
      float y = Mathf.Lerp(textureRect.y, textureRect.yMax, vector2.y) / (float) this.activeSprite.texture.height;
      try
      {
        return (double) this.activeSprite.texture.GetPixelBilinear(x, y).a >= (double) this.alphaHitTestMinimumThreshold;
      }
      catch (UnityException ex)
      {
        Debug.LogError((object) ("Using alphaHitTestMinimumThreshold greater than 0 on Image whose sprite texture cannot be read. " + ex.Message + " Also make sure to disable sprite packing for this sprite."), (UnityEngine.Object) this);
        return true;
      }
    }

    private Vector2 MapCoordinate(Vector2 local, Rect rect)
    {
      Rect rect1 = this.activeSprite.rect;
      if (this.type == Image.Type.Simple || this.type == Image.Type.Filled)
        return new Vector2(local.x * rect1.width / rect.width, local.y * rect1.height / rect.height);
      Vector4 border = this.activeSprite.border;
      Vector4 adjustedBorders = this.GetAdjustedBorders(border / this.pixelsPerUnit, rect);
      for (int index1 = 0; index1 < 2; ++index1)
      {
        if ((double) local[index1] > (double) adjustedBorders[index1])
        {
          if ((double) rect.size[index1] - (double) local[index1] <= (double) adjustedBorders[index1 + 2])
          {
            // ISSUE: variable of a reference type
            Vector2& local1;
            int index2;
            // ISSUE: explicit reference operation
            double num = (double) (^(local1 = ref local))[index2 = index1] - ((double) rect.size[index1] - (double) rect1.size[index1]);
            local1[index2] = (float) num;
          }
          else if (this.type == Image.Type.Sliced)
          {
            float t = Mathf.InverseLerp(adjustedBorders[index1], rect.size[index1] - adjustedBorders[index1 + 2], local[index1]);
            local[index1] = Mathf.Lerp(border[index1], rect1.size[index1] - border[index1 + 2], t);
          }
          else
          {
            local[index1] -= adjustedBorders[index1];
            local[index1] = Mathf.Repeat(local[index1], rect1.size[index1] - border[index1] - border[index1 + 2]);
            local[index1] += border[index1];
          }
        }
      }
      return local;
    }

    private static void RebuildImage(SpriteAtlas spriteAtlas)
    {
      for (int index = Image.m_TrackedTexturelessImages.Count - 1; index >= 0; --index)
      {
        Image texturelessImage = Image.m_TrackedTexturelessImages[index];
        if (spriteAtlas.CanBindTo(texturelessImage.activeSprite))
        {
          texturelessImage.SetAllDirty();
          Image.m_TrackedTexturelessImages.RemoveAt(index);
        }
      }
    }

    private static void TrackImage(Image g)
    {
      if (!Image.s_Initialized)
      {
        // ISSUE: reference to a compiler-generated field
        if (Image.\u003C\u003Ef__mg\u0024cache0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Image.\u003C\u003Ef__mg\u0024cache0 = new Action<SpriteAtlas>(Image.RebuildImage);
        }
        // ISSUE: reference to a compiler-generated field
        SpriteAtlasManager.atlasRegistered += Image.\u003C\u003Ef__mg\u0024cache0;
        Image.s_Initialized = true;
      }
      Image.m_TrackedTexturelessImages.Add(g);
    }

    private static void UnTrackImage(Image g)
    {
      Image.m_TrackedTexturelessImages.Remove(g);
    }

    /// <summary>
    ///   <para>Image Type.</para>
    /// </summary>
    public enum Type
    {
      /// <summary>
      ///   <para>Displays the full Image.</para>
      /// </summary>
      Simple,
      /// <summary>
      ///   <para>Displays the Image as a 9-sliced graphic.</para>
      /// </summary>
      Sliced,
      /// <summary>
      ///   <para>Displays a sliced Sprite with its resizable sections tiled instead of stretched.</para>
      /// </summary>
      Tiled,
      /// <summary>
      ///   <para>Displays only a portion of the Image.</para>
      /// </summary>
      Filled,
    }

    /// <summary>
    ///   <para>Fill method to be used by the UI.Image.</para>
    /// </summary>
    public enum FillMethod
    {
      /// <summary>
      ///   <para>The Image will be filled Horizontally.</para>
      /// </summary>
      Horizontal,
      /// <summary>
      ///   <para>The Image will be filled Vertically.</para>
      /// </summary>
      Vertical,
      /// <summary>
      ///   <para>The Image will be filled Radially with the radial center in one of the corners.</para>
      /// </summary>
      Radial90,
      /// <summary>
      ///   <para>The Image will be filled Radially with the radial center in one of the edges.</para>
      /// </summary>
      Radial180,
      /// <summary>
      ///   <para>The Image will be filled Radially with the radial center at the center.</para>
      /// </summary>
      Radial360,
    }

    /// <summary>
    ///   <para>Origin for the Image.FillMethod.Horizontal.</para>
    /// </summary>
    public enum OriginHorizontal
    {
      /// <summary>
      ///   <para>Origin at the Left side.</para>
      /// </summary>
      Left,
      /// <summary>
      ///   <para>Origin at the Right side.</para>
      /// </summary>
      Right,
    }

    /// <summary>
    ///   <para>Origin for the Image.FillMethod.Vertical.</para>
    /// </summary>
    public enum OriginVertical
    {
      /// <summary>
      ///   <para>Origin at the Bottom edge.</para>
      /// </summary>
      Bottom,
      /// <summary>
      ///   <para>Origin at the Top edge.</para>
      /// </summary>
      Top,
    }

    /// <summary>
    ///   <para>Origin for the Image.FillMethod.Radial90.</para>
    /// </summary>
    public enum Origin90
    {
      /// <summary>
      ///   <para>Radial starting at the Bottom Left corner.</para>
      /// </summary>
      BottomLeft,
      /// <summary>
      ///   <para>Radial starting at the Top Left corner.</para>
      /// </summary>
      TopLeft,
      /// <summary>
      ///   <para>Radial starting at the Top Right corner.</para>
      /// </summary>
      TopRight,
      /// <summary>
      ///   <para>Radial starting at the Bottom Right corner.</para>
      /// </summary>
      BottomRight,
    }

    /// <summary>
    ///   <para>Origin for the Image.FillMethod.Radial180.</para>
    /// </summary>
    public enum Origin180
    {
      /// <summary>
      ///   <para>Center of the radial at the center of the Bottom edge.</para>
      /// </summary>
      Bottom,
      /// <summary>
      ///   <para>Center of the radial at the center of the Left edge.</para>
      /// </summary>
      Left,
      /// <summary>
      ///   <para>Center of the radial at the center of the Top edge.</para>
      /// </summary>
      Top,
      /// <summary>
      ///   <para>Center of the radial at the center of the Right edge.</para>
      /// </summary>
      Right,
    }

    /// <summary>
    ///   <para>One of the points of the Arc for the Image.FillMethod.Radial360.</para>
    /// </summary>
    public enum Origin360
    {
      /// <summary>
      ///   <para>Arc starting at the center of the Bottom edge.</para>
      /// </summary>
      Bottom,
      /// <summary>
      ///   <para>Arc starting at the center of the Right edge.</para>
      /// </summary>
      Right,
      /// <summary>
      ///   <para>Arc starting at the center of the Top edge.</para>
      /// </summary>
      Top,
      /// <summary>
      ///   <para>Arc starting at the center of the Left edge.</para>
      /// </summary>
      Left,
    }
  }
}
