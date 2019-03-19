// Decompiled with JetBrains decompiler
// Type: UnityEngine.UIVertex
// Assembly: UnityEngine.TextRenderingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2BE048EB-E9A9-4185-9094-D907E173402C
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.TextRenderingModule.dll

using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Vertex class used by a Canvas for managing vertices.</para>
  /// </summary>
  [UsedByNativeCode]
  public struct UIVertex
  {
    private static readonly Color32 s_DefaultColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
    private static readonly Vector4 s_DefaultTangent = new Vector4(1f, 0.0f, 0.0f, -1f);
    /// <summary>
    ///   <para>Simple UIVertex with sensible settings for use in the UI system.</para>
    /// </summary>
    public static UIVertex simpleVert = new UIVertex()
    {
      position = Vector3.zero,
      normal = Vector3.back,
      tangent = UIVertex.s_DefaultTangent,
      color = UIVertex.s_DefaultColor,
      uv0 = Vector2.zero,
      uv1 = Vector2.zero,
      uv2 = Vector2.zero,
      uv3 = Vector2.zero
    };
    /// <summary>
    ///   <para>Vertex position.</para>
    /// </summary>
    public Vector3 position;
    /// <summary>
    ///   <para>Normal.</para>
    /// </summary>
    public Vector3 normal;
    /// <summary>
    ///   <para>Vertex color.</para>
    /// </summary>
    public Color32 color;
    /// <summary>
    ///   <para>The first texture coordinate set of the mesh. Used by UI elements by default.</para>
    /// </summary>
    public Vector2 uv0;
    /// <summary>
    ///   <para>The second texture coordinate set of the mesh, if present.</para>
    /// </summary>
    public Vector2 uv1;
    /// <summary>
    ///   <para>The Third texture coordinate set of the mesh, if present.</para>
    /// </summary>
    public Vector2 uv2;
    /// <summary>
    ///   <para>The forth texture coordinate set of the mesh, if present.</para>
    /// </summary>
    public Vector2 uv3;
    /// <summary>
    ///   <para>Tangent.</para>
    /// </summary>
    public Vector4 tangent;
  }
}
