// Decompiled with JetBrains decompiler
// Type: UnityEngine.CanvasRenderer
// Assembly: UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 19F579AC-FFD9-4B72-A29B-FFCAB6079269
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.UIModule.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>A component that will render to the screen after all normal rendering has completed when attached to a Canvas. Designed for GUI application.</para>
  /// </summary>
  public sealed class CanvasRenderer : Component
  {
    /// <summary>
    ///   <para>Set the color of the renderer. Will be multiplied with the UIVertex color and the Canvas color.</para>
    /// </summary>
    /// <param name="color">Renderer multiply color.</param>
    public void SetColor(Color color)
    {
      CanvasRenderer.INTERNAL_CALL_SetColor(this, ref color);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetColor(CanvasRenderer self, ref Color color);

    /// <summary>
    ///   <para>Get the current color of the renderer.</para>
    /// </summary>
    public Color GetColor()
    {
      Color color;
      CanvasRenderer.INTERNAL_CALL_GetColor(this, out color);
      return color;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_GetColor(CanvasRenderer self, out Color value);

    /// <summary>
    ///   <para>Get the current alpha of the renderer.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern float GetAlpha();

    /// <summary>
    ///   <para>Set the alpha of the renderer. Will be multiplied with the UIVertex alpha and the Canvas alpha.</para>
    /// </summary>
    /// <param name="alpha">Alpha.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetAlpha(float alpha);

    /// <summary>
    ///   <para>Is the UIRenderer a mask component.</para>
    /// </summary>
    [Obsolete("isMask is no longer supported. See EnableClipping for vertex clipping configuration")]
    public extern bool isMask { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("UI System now uses meshes. Generate a mesh and use 'SetMesh' instead")]
    public void SetVertices(List<UIVertex> vertices)
    {
      this.SetVertices(vertices.ToArray(), vertices.Count);
    }

    /// <summary>
    ///   <para>Set the vertices for the UIRenderer.</para>
    /// </summary>
    /// <param name="vertices">Array of vertices to set.</param>
    /// <param name="size">Number of vertices to set.</param>
    [Obsolete("UI System now uses meshes. Generate a mesh and use 'SetMesh' instead")]
    public void SetVertices(UIVertex[] vertices, int size)
    {
      Mesh mesh = new Mesh();
      List<Vector3> inVertices = new List<Vector3>();
      List<Color32> inColors = new List<Color32>();
      List<Vector2> uvs1 = new List<Vector2>();
      List<Vector2> uvs2 = new List<Vector2>();
      List<Vector2> uvs3 = new List<Vector2>();
      List<Vector2> uvs4 = new List<Vector2>();
      List<Vector3> inNormals = new List<Vector3>();
      List<Vector4> inTangents = new List<Vector4>();
      List<int> intList = new List<int>();
      int num = 0;
      while (num < size)
      {
        for (int index = 0; index < 4; ++index)
        {
          inVertices.Add(vertices[num + index].position);
          inColors.Add(vertices[num + index].color);
          uvs1.Add(vertices[num + index].uv0);
          uvs2.Add(vertices[num + index].uv1);
          uvs3.Add(vertices[num + index].uv2);
          uvs4.Add(vertices[num + index].uv3);
          inNormals.Add(vertices[num + index].normal);
          inTangents.Add(vertices[num + index].tangent);
        }
        intList.Add(num);
        intList.Add(num + 1);
        intList.Add(num + 2);
        intList.Add(num + 2);
        intList.Add(num + 3);
        intList.Add(num);
        num += 4;
      }
      mesh.SetVertices(inVertices);
      mesh.SetColors(inColors);
      mesh.SetNormals(inNormals);
      mesh.SetTangents(inTangents);
      mesh.SetUVs(0, uvs1);
      mesh.SetUVs(1, uvs2);
      mesh.SetUVs(2, uvs3);
      mesh.SetUVs(3, uvs4);
      mesh.SetIndices(intList.ToArray(), MeshTopology.Triangles, 0);
      this.SetMesh(mesh);
      Object.DestroyImmediate((Object) mesh);
    }

    /// <summary>
    ///   <para>Enables rect clipping on the CanvasRendered. Geometry outside of the specified rect will be clipped (not rendered).</para>
    /// </summary>
    /// <param name="rect"></param>
    public void EnableRectClipping(Rect rect)
    {
      CanvasRenderer.INTERNAL_CALL_EnableRectClipping(this, ref rect);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_EnableRectClipping(CanvasRenderer self, ref Rect rect);

    /// <summary>
    ///   <para>Disables rectangle clipping for this CanvasRenderer.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void DisableRectClipping();

    /// <summary>
    ///         <para>True if rect clipping has been enabled on this renderer.
    /// See Also: CanvasRenderer.EnableRectClipping, CanvasRenderer.DisableRectClipping.</para>
    ///       </summary>
    public extern bool hasRectClipping { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Enable 'render stack' pop draw call.</para>
    /// </summary>
    public extern bool hasPopInstruction { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The number of materials usable by this renderer.</para>
    /// </summary>
    public extern int materialCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///         <para>Set the material for the canvas renderer. If a texture is specified then it will be used as the 'MainTex' instead of the material's 'MainTex'.
    /// See Also: CanvasRenderer.SetMaterialCount, CanvasRenderer.SetTexture.</para>
    ///       </summary>
    /// <param name="material">Material for rendering.</param>
    /// <param name="texture">Material texture overide.</param>
    /// <param name="index">Material index.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetMaterial(Material material, int index);

    /// <summary>
    ///         <para>Set the material for the canvas renderer. If a texture is specified then it will be used as the 'MainTex' instead of the material's 'MainTex'.
    /// See Also: CanvasRenderer.SetMaterialCount, CanvasRenderer.SetTexture.</para>
    ///       </summary>
    /// <param name="material">Material for rendering.</param>
    /// <param name="texture">Material texture overide.</param>
    /// <param name="index">Material index.</param>
    public void SetMaterial(Material material, Texture texture)
    {
      this.materialCount = Math.Max(1, this.materialCount);
      this.SetMaterial(material, 0);
      this.SetTexture(texture);
    }

    /// <summary>
    ///   <para>Gets the current Material assigned to the CanvasRenderer.</para>
    /// </summary>
    /// <param name="index">The material index to retrieve (0 if this parameter is omitted).</param>
    /// <returns>
    ///   <para>Result.</para>
    /// </returns>
    public Material GetMaterial()
    {
      return this.GetMaterial(0);
    }

    /// <summary>
    ///   <para>Gets the current Material assigned to the CanvasRenderer.</para>
    /// </summary>
    /// <param name="index">The material index to retrieve (0 if this parameter is omitted).</param>
    /// <returns>
    ///   <para>Result.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Material GetMaterial(int index);

    /// <summary>
    ///   <para>The number of materials usable by this renderer. Used internally for masking.</para>
    /// </summary>
    public extern int popMaterialCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Set the material for the canvas renderer. Used internally for masking.</para>
    /// </summary>
    /// <param name="material"></param>
    /// <param name="index"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetPopMaterial(Material material, int index);

    /// <summary>
    ///   <para>Gets the current Material assigned to the CanvasRenderer. Used internally for masking.</para>
    /// </summary>
    /// <param name="index"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Material GetPopMaterial(int index);

    /// <summary>
    ///   <para>Sets the texture used by this renderer's material.</para>
    /// </summary>
    /// <param name="texture"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetTexture(Texture texture);

    /// <summary>
    ///   <para>The Alpha Texture that will be passed to the Shader under the _AlphaTex property.</para>
    /// </summary>
    /// <param name="texture">The Texture to be passed.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetAlphaTexture(Texture texture);

    /// <summary>
    ///   <para>Sets the Mesh used by this renderer.</para>
    /// </summary>
    /// <param name="mesh"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetMesh(Mesh mesh);

    /// <summary>
    ///   <para>Remove all cached vertices.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Clear();

    public static void SplitUIVertexStreams(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector2> uv0S, List<Vector2> uv1S, List<Vector3> normals, List<Vector4> tangents, List<int> indices)
    {
      CanvasRenderer.SplitUIVertexStreams(verts, positions, colors, uv0S, uv1S, new List<Vector2>(), new List<Vector2>(), normals, tangents, indices);
    }

    public static void SplitUIVertexStreams(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector2> uv0S, List<Vector2> uv1S, List<Vector2> uv2S, List<Vector2> uv3S, List<Vector3> normals, List<Vector4> tangents, List<int> indices)
    {
      CanvasRenderer.SplitUIVertexStreamsInternal((object) verts, (object) positions, (object) colors, (object) uv0S, (object) uv1S, (object) uv2S, (object) uv3S, (object) normals, (object) tangents);
      CanvasRenderer.SplitIndicesStreamsInternal((object) verts, (object) indices);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SplitUIVertexStreamsInternal(object verts, object positions, object colors, object uv0S, object uv1S, object uv2S, object uv3S, object normals, object tangents);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SplitIndicesStreamsInternal(object verts, object indices);

    public static void CreateUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector2> uv0S, List<Vector2> uv1S, List<Vector3> normals, List<Vector4> tangents, List<int> indices)
    {
      CanvasRenderer.CreateUIVertexStream(verts, positions, colors, uv0S, uv1S, new List<Vector2>(), new List<Vector2>(), normals, tangents, indices);
    }

    public static void CreateUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector2> uv0S, List<Vector2> uv1S, List<Vector2> uv2S, List<Vector2> uv3S, List<Vector3> normals, List<Vector4> tangents, List<int> indices)
    {
      CanvasRenderer.CreateUIVertexStreamInternal((object) verts, (object) positions, (object) colors, (object) uv0S, (object) uv1S, (object) uv2S, (object) uv3S, (object) normals, (object) tangents, (object) indices);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void CreateUIVertexStreamInternal(object verts, object positions, object colors, object uv0S, object uv1S, object uv2S, object uv3S, object normals, object tangents, object indices);

    public static void AddUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector2> uv0S, List<Vector2> uv1S, List<Vector3> normals, List<Vector4> tangents)
    {
      CanvasRenderer.AddUIVertexStream(verts, positions, colors, uv0S, uv1S, new List<Vector2>(), new List<Vector2>(), normals, tangents);
    }

    public static void AddUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector2> uv0S, List<Vector2> uv1S, List<Vector2> uv2S, List<Vector2> uv3S, List<Vector3> normals, List<Vector4> tangents)
    {
      CanvasRenderer.SplitUIVertexStreamsInternal((object) verts, (object) positions, (object) colors, (object) uv0S, (object) uv1S, (object) uv2S, (object) uv3S, (object) normals, (object) tangents);
    }

    /// <summary>
    ///   <para>Depth of the renderer realative to the parent canvas.</para>
    /// </summary>
    public extern int relativeDepth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Indicates whether geometry emitted by this renderer is ignored.</para>
    /// </summary>
    public extern bool cull { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Depth of the renderer relative to the root canvas.</para>
    /// </summary>
    public extern int absoluteDepth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>True if any change has occured that would invalidate the positions of generated geometry.</para>
    /// </summary>
    public extern bool hasMoved { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public static event CanvasRenderer.OnRequestRebuild onRequestRebuild;

    [RequiredByNativeCode]
    private static void RequestRefresh()
    {
      // ISSUE: reference to a compiler-generated field
      if (CanvasRenderer.onRequestRebuild == null)
        return;
      // ISSUE: reference to a compiler-generated field
      CanvasRenderer.onRequestRebuild();
    }

    public delegate void OnRequestRebuild();
  }
}
