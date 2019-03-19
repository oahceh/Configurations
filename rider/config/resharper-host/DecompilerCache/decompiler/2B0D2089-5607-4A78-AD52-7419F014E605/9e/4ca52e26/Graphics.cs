// Decompiled with JetBrains decompiler
// Type: UnityEngine.Graphics
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2B0D2089-5607-4A78-AD52-7419F014E605
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Raw interface to Unity's drawing functions.</para>
  /// </summary>
  public sealed class Graphics
  {
    internal static readonly int kMaxDrawMeshInstanceCount = Graphics.Internal_GetMaxDrawMeshInstanceCount();

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows, bool receiveShadows)
    {
      bool useLightProbes = true;
      Graphics.DrawMesh(mesh, position, rotation, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows)
    {
      bool useLightProbes = true;
      bool receiveShadows = true;
      Graphics.DrawMesh(mesh, position, rotation, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties)
    {
      bool useLightProbes = true;
      bool receiveShadows = true;
      bool castShadows = true;
      Graphics.DrawMesh(mesh, position, rotation, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex)
    {
      bool useLightProbes = true;
      bool receiveShadows = true;
      bool castShadows = true;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      Graphics.DrawMesh(mesh, position, rotation, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera)
    {
      bool useLightProbes = true;
      bool receiveShadows = true;
      bool castShadows = true;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      int submeshIndex = 0;
      Graphics.DrawMesh(mesh, position, rotation, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer)
    {
      bool useLightProbes = true;
      bool receiveShadows = true;
      bool castShadows = true;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      int submeshIndex = 0;
      Camera camera = (Camera) null;
      Graphics.DrawMesh(mesh, position, rotation, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, [DefaultValue("null")] Camera camera, [DefaultValue("0")] int submeshIndex, [DefaultValue("null")] MaterialPropertyBlock properties, [DefaultValue("true")] bool castShadows, [DefaultValue("true")] bool receiveShadows, [DefaultValue("true")] bool useLightProbes)
    {
      Graphics.DrawMesh(mesh, position, rotation, material, layer, camera, submeshIndex, properties, !castShadows ? ShadowCastingMode.Off : ShadowCastingMode.On, receiveShadows, (Transform) null, useLightProbes);
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, Transform probeAnchor)
    {
      bool useLightProbes = true;
      Graphics.DrawMesh(mesh, position, rotation, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, probeAnchor, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows)
    {
      bool useLightProbes = true;
      Transform probeAnchor = (Transform) null;
      Graphics.DrawMesh(mesh, position, rotation, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, probeAnchor, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows)
    {
      bool useLightProbes = true;
      Transform probeAnchor = (Transform) null;
      bool receiveShadows = true;
      Graphics.DrawMesh(mesh, position, rotation, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, probeAnchor, useLightProbes);
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, [DefaultValue("true")] bool receiveShadows, [DefaultValue("null")] Transform probeAnchor, [DefaultValue("true")] bool useLightProbes)
    {
      Graphics.DrawMeshImpl(mesh, Matrix4x4.TRS(position, rotation, Vector3.one), material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, probeAnchor, useLightProbes);
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows, bool receiveShadows)
    {
      bool useLightProbes = true;
      Graphics.DrawMesh(mesh, matrix, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows)
    {
      bool useLightProbes = true;
      bool receiveShadows = true;
      Graphics.DrawMesh(mesh, matrix, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties)
    {
      bool useLightProbes = true;
      bool receiveShadows = true;
      bool castShadows = true;
      Graphics.DrawMesh(mesh, matrix, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex)
    {
      bool useLightProbes = true;
      bool receiveShadows = true;
      bool castShadows = true;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      Graphics.DrawMesh(mesh, matrix, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera)
    {
      bool useLightProbes = true;
      bool receiveShadows = true;
      bool castShadows = true;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      int submeshIndex = 0;
      Graphics.DrawMesh(mesh, matrix, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer)
    {
      bool useLightProbes = true;
      bool receiveShadows = true;
      bool castShadows = true;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      int submeshIndex = 0;
      Camera camera = (Camera) null;
      Graphics.DrawMesh(mesh, matrix, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, useLightProbes);
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, [DefaultValue("null")] Camera camera, [DefaultValue("0")] int submeshIndex, [DefaultValue("null")] MaterialPropertyBlock properties, [DefaultValue("true")] bool castShadows, [DefaultValue("true")] bool receiveShadows, [DefaultValue("true")] bool useLightProbes)
    {
      Graphics.DrawMeshImpl(mesh, matrix, material, layer, camera, submeshIndex, properties, !castShadows ? ShadowCastingMode.Off : ShadowCastingMode.On, receiveShadows, (Transform) null, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, Transform probeAnchor)
    {
      bool useLightProbes = true;
      Graphics.DrawMesh(mesh, matrix, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, probeAnchor, useLightProbes);
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows)
    {
      bool useLightProbes = true;
      Transform probeAnchor = (Transform) null;
      Graphics.DrawMesh(mesh, matrix, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, probeAnchor, useLightProbes);
    }

    [ExcludeFromDocs]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows)
    {
      bool useLightProbes = true;
      Transform probeAnchor = (Transform) null;
      bool receiveShadows = true;
      Graphics.DrawMesh(mesh, matrix, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, probeAnchor, useLightProbes);
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, [DefaultValue("true")] bool receiveShadows, [DefaultValue("null")] Transform probeAnchor, [DefaultValue("true")] bool useLightProbes)
    {
      Graphics.DrawMeshImpl(mesh, matrix, material, layer, camera, submeshIndex, properties, castShadows, receiveShadows, probeAnchor, useLightProbes);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_DrawMeshMatrix(ref Internal_DrawMeshMatrixArguments arguments, MaterialPropertyBlock properties, Material material, Mesh mesh, Camera camera);

    private static void Internal_DrawMeshNow1(Mesh mesh, int subsetIndex, Vector3 position, Quaternion rotation)
    {
      Graphics.INTERNAL_CALL_Internal_DrawMeshNow1(mesh, subsetIndex, ref position, ref rotation);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Internal_DrawMeshNow1(Mesh mesh, int subsetIndex, ref Vector3 position, ref Quaternion rotation);

    private static void Internal_DrawMeshNow2(Mesh mesh, int subsetIndex, Matrix4x4 matrix)
    {
      Graphics.INTERNAL_CALL_Internal_DrawMeshNow2(mesh, subsetIndex, ref matrix);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Internal_DrawMeshNow2(Mesh mesh, int subsetIndex, ref Matrix4x4 matrix);

    /// <summary>
    ///   <para>Draws a fully procedural geometry on the GPU.</para>
    /// </summary>
    /// <param name="topology"></param>
    /// <param name="vertexCount"></param>
    /// <param name="instanceCount"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DrawProcedural(MeshTopology topology, int vertexCount, [DefaultValue("1")] int instanceCount);

    [ExcludeFromDocs]
    public static void DrawProcedural(MeshTopology topology, int vertexCount)
    {
      int instanceCount = 1;
      Graphics.DrawProcedural(topology, vertexCount, instanceCount);
    }

    /// <summary>
    ///   <para>Draws a fully procedural geometry on the GPU.</para>
    /// </summary>
    /// <param name="topology">Topology of the procedural geometry.</param>
    /// <param name="bufferWithArgs">Buffer with draw arguments.</param>
    /// <param name="argsOffset">Byte offset where in the buffer the draw arguments are.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DrawProceduralIndirect(MeshTopology topology, ComputeBuffer bufferWithArgs, [DefaultValue("0")] int argsOffset);

    [ExcludeFromDocs]
    public static void DrawProceduralIndirect(MeshTopology topology, ComputeBuffer bufferWithArgs)
    {
      int argsOffset = 0;
      Graphics.DrawProceduralIndirect(topology, bufferWithArgs, argsOffset);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Internal_GetMaxDrawMeshInstanceCount();

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer)
    {
      Camera camera = (Camera) null;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, count, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, count, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, count, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      ShadowCastingMode castShadows = ShadowCastingMode.On;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, count, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      ShadowCastingMode castShadows = ShadowCastingMode.On;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, count, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      ShadowCastingMode castShadows = ShadowCastingMode.On;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      int length = matrices.Length;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, length, properties, castShadows, receiveShadows, layer, camera);
    }

    /// <summary>
    ///   <para>Draw the same mesh multiple times using GPU instancing.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="material">Material to use.</param>
    /// <param name="matrices">The array of object transformation matrices.</param>
    /// <param name="count">The number of instances to be drawn.</param>
    /// <param name="properties">Additional material properties to apply. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be drawn in the given camera only.</param>
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, [DefaultValue("matrices.Length")] int count, [DefaultValue("null")] MaterialPropertyBlock properties, [DefaultValue("ShadowCastingMode.On")] ShadowCastingMode castShadows, [DefaultValue("true")] bool receiveShadows, [DefaultValue("0")] int layer, [DefaultValue("null")] Camera camera)
    {
      Graphics.DrawMeshInstancedImpl(mesh, submeshIndex, material, matrices, count, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer)
    {
      Camera camera = (Camera) null;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties, ShadowCastingMode castShadows)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      ShadowCastingMode castShadows = ShadowCastingMode.On;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      ShadowCastingMode castShadows = ShadowCastingMode.On;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      Graphics.DrawMeshInstanced(mesh, submeshIndex, material, matrices, properties, castShadows, receiveShadows, layer, camera);
    }

    public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, [DefaultValue("null")] MaterialPropertyBlock properties, [DefaultValue("ShadowCastingMode.On")] ShadowCastingMode castShadows, [DefaultValue("true")] bool receiveShadows, [DefaultValue("0")] int layer, [DefaultValue("null")] Camera camera)
    {
      Graphics.DrawMeshInstancedImpl(mesh, submeshIndex, material, matrices, properties, castShadows, receiveShadows, layer, camera);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera);

    [ExcludeFromDocs]
    public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer)
    {
      Camera camera = (Camera) null;
      Graphics.DrawMeshInstancedIndirect(mesh, submeshIndex, material, bounds, bufferWithArgs, argsOffset, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      Graphics.DrawMeshInstancedIndirect(mesh, submeshIndex, material, bounds, bufferWithArgs, argsOffset, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties, ShadowCastingMode castShadows)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      Graphics.DrawMeshInstancedIndirect(mesh, submeshIndex, material, bounds, bufferWithArgs, argsOffset, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      ShadowCastingMode castShadows = ShadowCastingMode.On;
      Graphics.DrawMeshInstancedIndirect(mesh, submeshIndex, material, bounds, bufferWithArgs, argsOffset, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, int argsOffset)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      ShadowCastingMode castShadows = ShadowCastingMode.On;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      Graphics.DrawMeshInstancedIndirect(mesh, submeshIndex, material, bounds, bufferWithArgs, argsOffset, properties, castShadows, receiveShadows, layer, camera);
    }

    [ExcludeFromDocs]
    public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs)
    {
      Camera camera = (Camera) null;
      int layer = 0;
      bool receiveShadows = true;
      ShadowCastingMode castShadows = ShadowCastingMode.On;
      MaterialPropertyBlock properties = (MaterialPropertyBlock) null;
      int argsOffset = 0;
      Graphics.DrawMeshInstancedIndirect(mesh, submeshIndex, material, bounds, bufferWithArgs, argsOffset, properties, castShadows, receiveShadows, layer, camera);
    }

    /// <summary>
    ///   <para>Draw the same mesh multiple times using GPU instancing.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="material">Material to use.</param>
    /// <param name="bounds">The bounding volume surrounding the instances you intend to draw.</param>
    /// <param name="bufferWithArgs">The GPU buffer containing the arguments for how many instances of this mesh to draw.</param>
    /// <param name="argsOffset">The byte offset into the buffer, where the draw arguments start.</param>
    /// <param name="properties">Additional material properties to apply. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be drawn in the given camera only.</param>
    public static void DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, [DefaultValue("0")] int argsOffset, [DefaultValue("null")] MaterialPropertyBlock properties, [DefaultValue("ShadowCastingMode.On")] ShadowCastingMode castShadows, [DefaultValue("true")] bool receiveShadows, [DefaultValue("0")] int layer, [DefaultValue("null")] Camera camera)
    {
      Graphics.DrawMeshInstancedIndirectImpl(mesh, submeshIndex, material, bounds, bufferWithArgs, argsOffset, properties, castShadows, receiveShadows, layer, camera);
    }

    private static void Internal_DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera)
    {
      Graphics.INTERNAL_CALL_Internal_DrawMeshInstancedIndirect(mesh, submeshIndex, material, ref bounds, bufferWithArgs, argsOffset, properties, castShadows, receiveShadows, layer, camera);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Internal_DrawMeshInstancedIndirect(Mesh mesh, int submeshIndex, Material material, ref Bounds bounds, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera);

    /// <summary>
    ///   <para>Draw a texture in screen coordinates.</para>
    /// </summary>
    /// <param name="screenRect">Rectangle on the screen to use for the texture. In pixel coordinates with (0,0) in the upper-left corner.</param>
    /// <param name="texture">Texture to draw.</param>
    /// <param name="sourceRect">Region of the texture to use. In normalized coordinates with (0,0) in the bottom-left corner.</param>
    /// <param name="leftBorder">Number of pixels from the left that are not affected by scale.</param>
    /// <param name="rightBorder">Number of pixels from the right that are not affected by scale.</param>
    /// <param name="topBorder">Number of pixels from the top that are not affected by scale.</param>
    /// <param name="bottomBorder">Number of pixels from the bottom that are not affected by scale.</param>
    /// <param name="color">Color that modulates the output. The neutral value is (0.5, 0.5, 0.5, 0.5). Set as vertex color for the shader.</param>
    /// <param name="mat">Custom Material that can be used to draw the texture. If null is passed, a default material with the Internal-GUITexture.shader is used.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    [ExcludeFromDocs]
    public static void DrawTexture(Rect screenRect, Texture texture, Material mat)
    {
      int pass = -1;
      Graphics.DrawTexture(screenRect, texture, mat, pass);
    }

    [ExcludeFromDocs]
    public static void DrawTexture(Rect screenRect, Texture texture)
    {
      int pass = -1;
      Material mat = (Material) null;
      Graphics.DrawTexture(screenRect, texture, mat, pass);
    }

    /// <summary>
    ///   <para>Draw a texture in screen coordinates.</para>
    /// </summary>
    /// <param name="screenRect">Rectangle on the screen to use for the texture. In pixel coordinates with (0,0) in the upper-left corner.</param>
    /// <param name="texture">Texture to draw.</param>
    /// <param name="sourceRect">Region of the texture to use. In normalized coordinates with (0,0) in the bottom-left corner.</param>
    /// <param name="leftBorder">Number of pixels from the left that are not affected by scale.</param>
    /// <param name="rightBorder">Number of pixels from the right that are not affected by scale.</param>
    /// <param name="topBorder">Number of pixels from the top that are not affected by scale.</param>
    /// <param name="bottomBorder">Number of pixels from the bottom that are not affected by scale.</param>
    /// <param name="color">Color that modulates the output. The neutral value is (0.5, 0.5, 0.5, 0.5). Set as vertex color for the shader.</param>
    /// <param name="mat">Custom Material that can be used to draw the texture. If null is passed, a default material with the Internal-GUITexture.shader is used.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    public static void DrawTexture(Rect screenRect, Texture texture, [DefaultValue("null")] Material mat, [DefaultValue("-1")] int pass)
    {
      Graphics.DrawTexture(screenRect, texture, 0, 0, 0, 0, mat, pass);
    }

    /// <summary>
    ///   <para>Draw a texture in screen coordinates.</para>
    /// </summary>
    /// <param name="screenRect">Rectangle on the screen to use for the texture. In pixel coordinates with (0,0) in the upper-left corner.</param>
    /// <param name="texture">Texture to draw.</param>
    /// <param name="sourceRect">Region of the texture to use. In normalized coordinates with (0,0) in the bottom-left corner.</param>
    /// <param name="leftBorder">Number of pixels from the left that are not affected by scale.</param>
    /// <param name="rightBorder">Number of pixels from the right that are not affected by scale.</param>
    /// <param name="topBorder">Number of pixels from the top that are not affected by scale.</param>
    /// <param name="bottomBorder">Number of pixels from the bottom that are not affected by scale.</param>
    /// <param name="color">Color that modulates the output. The neutral value is (0.5, 0.5, 0.5, 0.5). Set as vertex color for the shader.</param>
    /// <param name="mat">Custom Material that can be used to draw the texture. If null is passed, a default material with the Internal-GUITexture.shader is used.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    [ExcludeFromDocs]
    public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat)
    {
      int pass = -1;
      Graphics.DrawTexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat, pass);
    }

    [ExcludeFromDocs]
    public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder)
    {
      int pass = -1;
      Material mat = (Material) null;
      Graphics.DrawTexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat, pass);
    }

    /// <summary>
    ///   <para>Draw a texture in screen coordinates.</para>
    /// </summary>
    /// <param name="screenRect">Rectangle on the screen to use for the texture. In pixel coordinates with (0,0) in the upper-left corner.</param>
    /// <param name="texture">Texture to draw.</param>
    /// <param name="sourceRect">Region of the texture to use. In normalized coordinates with (0,0) in the bottom-left corner.</param>
    /// <param name="leftBorder">Number of pixels from the left that are not affected by scale.</param>
    /// <param name="rightBorder">Number of pixels from the right that are not affected by scale.</param>
    /// <param name="topBorder">Number of pixels from the top that are not affected by scale.</param>
    /// <param name="bottomBorder">Number of pixels from the bottom that are not affected by scale.</param>
    /// <param name="color">Color that modulates the output. The neutral value is (0.5, 0.5, 0.5, 0.5). Set as vertex color for the shader.</param>
    /// <param name="mat">Custom Material that can be used to draw the texture. If null is passed, a default material with the Internal-GUITexture.shader is used.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    public static void DrawTexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, [DefaultValue("null")] Material mat, [DefaultValue("-1")] int pass)
    {
      Graphics.DrawTexture(screenRect, texture, new Rect(0.0f, 0.0f, 1f, 1f), leftBorder, rightBorder, topBorder, bottomBorder, mat, pass);
    }

    /// <summary>
    ///   <para>Draw a texture in screen coordinates.</para>
    /// </summary>
    /// <param name="screenRect">Rectangle on the screen to use for the texture. In pixel coordinates with (0,0) in the upper-left corner.</param>
    /// <param name="texture">Texture to draw.</param>
    /// <param name="sourceRect">Region of the texture to use. In normalized coordinates with (0,0) in the bottom-left corner.</param>
    /// <param name="leftBorder">Number of pixels from the left that are not affected by scale.</param>
    /// <param name="rightBorder">Number of pixels from the right that are not affected by scale.</param>
    /// <param name="topBorder">Number of pixels from the top that are not affected by scale.</param>
    /// <param name="bottomBorder">Number of pixels from the bottom that are not affected by scale.</param>
    /// <param name="color">Color that modulates the output. The neutral value is (0.5, 0.5, 0.5, 0.5). Set as vertex color for the shader.</param>
    /// <param name="mat">Custom Material that can be used to draw the texture. If null is passed, a default material with the Internal-GUITexture.shader is used.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    [ExcludeFromDocs]
    public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat)
    {
      int pass = -1;
      Graphics.DrawTexture(screenRect, texture, sourceRect, leftBorder, rightBorder, topBorder, bottomBorder, mat, pass);
    }

    [ExcludeFromDocs]
    public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder)
    {
      int pass = -1;
      Material mat = (Material) null;
      Graphics.DrawTexture(screenRect, texture, sourceRect, leftBorder, rightBorder, topBorder, bottomBorder, mat, pass);
    }

    /// <summary>
    ///   <para>Draw a texture in screen coordinates.</para>
    /// </summary>
    /// <param name="screenRect">Rectangle on the screen to use for the texture. In pixel coordinates with (0,0) in the upper-left corner.</param>
    /// <param name="texture">Texture to draw.</param>
    /// <param name="sourceRect">Region of the texture to use. In normalized coordinates with (0,0) in the bottom-left corner.</param>
    /// <param name="leftBorder">Number of pixels from the left that are not affected by scale.</param>
    /// <param name="rightBorder">Number of pixels from the right that are not affected by scale.</param>
    /// <param name="topBorder">Number of pixels from the top that are not affected by scale.</param>
    /// <param name="bottomBorder">Number of pixels from the bottom that are not affected by scale.</param>
    /// <param name="color">Color that modulates the output. The neutral value is (0.5, 0.5, 0.5, 0.5). Set as vertex color for the shader.</param>
    /// <param name="mat">Custom Material that can be used to draw the texture. If null is passed, a default material with the Internal-GUITexture.shader is used.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, [DefaultValue("null")] Material mat, [DefaultValue("-1")] int pass)
    {
      Color32 color32 = new Color32((byte) 128, (byte) 128, (byte) 128, (byte) 128);
      Graphics.DrawTextureImpl(screenRect, texture, sourceRect, leftBorder, rightBorder, topBorder, bottomBorder, (Color) color32, mat, pass);
    }

    /// <summary>
    ///   <para>Draw a texture in screen coordinates.</para>
    /// </summary>
    /// <param name="screenRect">Rectangle on the screen to use for the texture. In pixel coordinates with (0,0) in the upper-left corner.</param>
    /// <param name="texture">Texture to draw.</param>
    /// <param name="sourceRect">Region of the texture to use. In normalized coordinates with (0,0) in the bottom-left corner.</param>
    /// <param name="leftBorder">Number of pixels from the left that are not affected by scale.</param>
    /// <param name="rightBorder">Number of pixels from the right that are not affected by scale.</param>
    /// <param name="topBorder">Number of pixels from the top that are not affected by scale.</param>
    /// <param name="bottomBorder">Number of pixels from the bottom that are not affected by scale.</param>
    /// <param name="color">Color that modulates the output. The neutral value is (0.5, 0.5, 0.5, 0.5). Set as vertex color for the shader.</param>
    /// <param name="mat">Custom Material that can be used to draw the texture. If null is passed, a default material with the Internal-GUITexture.shader is used.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    [ExcludeFromDocs]
    public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Color color, Material mat)
    {
      int pass = -1;
      Graphics.DrawTexture(screenRect, texture, sourceRect, leftBorder, rightBorder, topBorder, bottomBorder, color, mat, pass);
    }

    [ExcludeFromDocs]
    public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Color color)
    {
      int pass = -1;
      Material mat = (Material) null;
      Graphics.DrawTexture(screenRect, texture, sourceRect, leftBorder, rightBorder, topBorder, bottomBorder, color, mat, pass);
    }

    /// <summary>
    ///   <para>Draw a texture in screen coordinates.</para>
    /// </summary>
    /// <param name="screenRect">Rectangle on the screen to use for the texture. In pixel coordinates with (0,0) in the upper-left corner.</param>
    /// <param name="texture">Texture to draw.</param>
    /// <param name="sourceRect">Region of the texture to use. In normalized coordinates with (0,0) in the bottom-left corner.</param>
    /// <param name="leftBorder">Number of pixels from the left that are not affected by scale.</param>
    /// <param name="rightBorder">Number of pixels from the right that are not affected by scale.</param>
    /// <param name="topBorder">Number of pixels from the top that are not affected by scale.</param>
    /// <param name="bottomBorder">Number of pixels from the bottom that are not affected by scale.</param>
    /// <param name="color">Color that modulates the output. The neutral value is (0.5, 0.5, 0.5, 0.5). Set as vertex color for the shader.</param>
    /// <param name="mat">Custom Material that can be used to draw the texture. If null is passed, a default material with the Internal-GUITexture.shader is used.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    public static void DrawTexture(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Color color, [DefaultValue("null")] Material mat, [DefaultValue("-1")] int pass)
    {
      Graphics.DrawTextureImpl(screenRect, texture, sourceRect, leftBorder, rightBorder, topBorder, bottomBorder, color, mat, pass);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Internal_DrawTexture(ref Internal_DrawTextureArguments args);

    [ExcludeFromDocs]
    public static GPUFence CreateGPUFence()
    {
      return Graphics.CreateGPUFence(SynchronisationStage.PixelProcessing);
    }

    /// <summary>
    ///   <para>Creates a GPUFence which will be passed after the last Blit, Clear, Draw, Dispatch or Texture Copy command prior to this call has been completed on the GPU.</para>
    /// </summary>
    /// <param name="stage">On some platforms there is a significant gap between the vertex processing completing and the pixel processing begining for a given draw call. This parameter allows for the fence to be passed after either the vertex or pixel processing for the proceeding draw has completed. If a compute shader dispatch was the last task submitted then this parameter is ignored.</param>
    /// <returns>
    ///   <para>Returns a new GPUFence.</para>
    /// </returns>
    public static GPUFence CreateGPUFence([DefaultValue("SynchronisationStage.PixelProcessing")] SynchronisationStage stage)
    {
      GPUFence gpuFence = new GPUFence();
      gpuFence.m_Ptr = Graphics.Internal_CreateGPUFence(stage);
      gpuFence.InitPostAllocation();
      gpuFence.Validate();
      return gpuFence;
    }

    private static IntPtr Internal_CreateGPUFence(SynchronisationStage stage)
    {
      IntPtr num;
      Graphics.INTERNAL_CALL_Internal_CreateGPUFence(stage, out num);
      return num;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Internal_CreateGPUFence(SynchronisationStage stage, out IntPtr value);

    [ExcludeFromDocs]
    public static void WaitOnGPUFence(GPUFence fence)
    {
      SynchronisationStage stage = SynchronisationStage.VertexProcessing;
      Graphics.WaitOnGPUFence(fence, stage);
    }

    /// <summary>
    ///   <para>Instructs the GPU's processing of the graphics queue to wait until the given GPUFence is passed.</para>
    /// </summary>
    /// <param name="fence">The GPUFence that the GPU will be instructed to wait upon before proceeding with its processing of the graphics queue.</param>
    /// <param name="stage">On some platforms there is a significant gap between the vertex processing completing and the pixel processing begining for a given draw call. This parameter allows for requested wait to be before the next items vertex or pixel processing begins. If a compute shader dispatch is the next item to be submitted then this parameter is ignored.</param>
    public static void WaitOnGPUFence(GPUFence fence, [DefaultValue("SynchronisationStage.VertexProcessing")] SynchronisationStage stage)
    {
      fence.Validate();
      if (!fence.IsFencePending())
        return;
      Graphics.WaitOnGPUFence_Internal(fence.m_Ptr, stage);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void WaitOnGPUFence_Internal(IntPtr fencePtr, SynchronisationStage stage);

    /// <summary>
    ///   <para>Execute a command buffer.</para>
    /// </summary>
    /// <param name="buffer">The buffer to execute.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ExecuteCommandBuffer(CommandBuffer buffer);

    /// <summary>
    ///         <para>Executes a command buffer on an async compute queue with the queue selected based on the ComputeQueueType parameter passed.
    /// 
    /// It is required that all of the commands within the command buffer be of a type suitable for execution on the async compute queues. If the buffer contains any commands that are not appropriate then an error will be logged and displayed in the editor window.  Specifically the following commands are permitted in a CommandBuffer intended for async execution:
    /// 
    /// CommandBuffer.BeginSample
    /// 
    /// CommandBuffer.CopyCounterValue
    /// 
    /// CommandBuffer.CopyTexture
    /// 
    /// CommandBuffer.CreateGPUFence
    /// 
    /// CommandBuffer.DispatchCompute
    /// 
    /// CommandBuffer.EndSample
    /// 
    /// CommandBuffer.IssuePluginEvent
    /// 
    /// CommandBuffer.SetComputeBufferParam
    /// 
    /// CommandBuffer.SetComputeFloatParam
    /// 
    /// CommandBuffer.SetComputeFloatParams
    /// 
    /// CommandBuffer.SetComputeTextureParam
    /// 
    /// CommandBuffer.SetComputeVectorParam
    /// 
    /// CommandBuffer.WaitOnGPUFence
    /// 
    /// All of the commands within the buffer are guaranteed to be executed on the same queue. If the target platform does not support async compute queues then the work is dispatched on the graphics queue.</para>
    ///       </summary>
    /// <param name="buffer">The CommandBuffer to be executed.</param>
    /// <param name="queueType">Describes the desired async compute queue the suuplied CommandBuffer should be executed on.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ExecuteCommandBufferAsync(CommandBuffer buffer, ComputeQueueType queueType);

    /// <summary>
    ///   <para>Copies source texture into destination render texture with a shader.</para>
    /// </summary>
    /// <param name="source">Source texture.</param>
    /// <param name="dest">The destination RenderTexture. Set this to null to blit directly to screen. See description for more information.</param>
    /// <param name="mat">Material to use. Material's shader could do some post-processing effect, for example.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    /// <param name="offset">Offset applied to the source texture coordinate.</param>
    /// <param name="scale">Scale applied to the source texture coordinate.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Blit(Texture source, RenderTexture dest);

    /// <summary>
    ///   <para>Copies source texture into destination render texture with a shader.</para>
    /// </summary>
    /// <param name="source">Source texture.</param>
    /// <param name="dest">The destination RenderTexture. Set this to null to blit directly to screen. See description for more information.</param>
    /// <param name="mat">Material to use. Material's shader could do some post-processing effect, for example.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    /// <param name="offset">Offset applied to the source texture coordinate.</param>
    /// <param name="scale">Scale applied to the source texture coordinate.</param>
    public static void Blit(Texture source, RenderTexture dest, Vector2 scale, Vector2 offset)
    {
      Graphics.INTERNAL_CALL_Blit(source, dest, ref scale, ref offset);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Blit(Texture source, RenderTexture dest, ref Vector2 scale, ref Vector2 offset);

    [ExcludeFromDocs]
    public static void Blit(Texture source, RenderTexture dest, Material mat)
    {
      int pass = -1;
      Graphics.Blit(source, dest, mat, pass);
    }

    /// <summary>
    ///   <para>Copies source texture into destination render texture with a shader.</para>
    /// </summary>
    /// <param name="source">Source texture.</param>
    /// <param name="dest">The destination RenderTexture. Set this to null to blit directly to screen. See description for more information.</param>
    /// <param name="mat">Material to use. Material's shader could do some post-processing effect, for example.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    /// <param name="offset">Offset applied to the source texture coordinate.</param>
    /// <param name="scale">Scale applied to the source texture coordinate.</param>
    public static void Blit(Texture source, RenderTexture dest, Material mat, [DefaultValue("-1")] int pass)
    {
      Graphics.Internal_BlitMaterial(source, dest, mat, pass, true, new Vector2(1f, 1f), new Vector2(0.0f, 0.0f));
    }

    [ExcludeFromDocs]
    public static void Blit(Texture source, Material mat)
    {
      int pass = -1;
      Graphics.Blit(source, mat, pass);
    }

    /// <summary>
    ///   <para>Copies source texture into destination render texture with a shader.</para>
    /// </summary>
    /// <param name="source">Source texture.</param>
    /// <param name="dest">The destination RenderTexture. Set this to null to blit directly to screen. See description for more information.</param>
    /// <param name="mat">Material to use. Material's shader could do some post-processing effect, for example.</param>
    /// <param name="pass">If -1 (default), draws all passes in the material. Otherwise, draws given pass only.</param>
    /// <param name="offset">Offset applied to the source texture coordinate.</param>
    /// <param name="scale">Scale applied to the source texture coordinate.</param>
    public static void Blit(Texture source, Material mat, [DefaultValue("-1")] int pass)
    {
      Graphics.Internal_BlitMaterial(source, (RenderTexture) null, mat, pass, false, new Vector2(1f, 1f), new Vector2(0.0f, 0.0f));
    }

    private static void Internal_BlitMaterial(Texture source, RenderTexture dest, Material mat, int pass, bool setRT, Vector2 scale, Vector2 offset)
    {
      Graphics.INTERNAL_CALL_Internal_BlitMaterial(source, dest, mat, pass, setRT, ref scale, ref offset);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Internal_BlitMaterial(Texture source, RenderTexture dest, Material mat, int pass, bool setRT, ref Vector2 scale, ref Vector2 offset);

    /// <summary>
    ///   <para>Copies source texture into destination, for multi-tap shader.</para>
    /// </summary>
    /// <param name="source">Source texture.</param>
    /// <param name="dest">Destination RenderTexture, or null to blit directly to screen.</param>
    /// <param name="mat">Material to use for copying. Material's shader should do some post-processing effect.</param>
    /// <param name="offsets">Variable number of filtering offsets. Offsets are given in pixels.</param>
    public static void BlitMultiTap(Texture source, RenderTexture dest, Material mat, params Vector2[] offsets)
    {
      Graphics.Internal_BlitMultiTap(source, dest, mat, offsets);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_BlitMultiTap(Texture source, RenderTexture dest, Material mat, Vector2[] offsets);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void CopyTexture_Full(Texture src, Texture dst);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void CopyTexture_Slice_AllMips(Texture src, int srcElement, Texture dst, int dstElement);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void CopyTexture_Slice(Texture src, int srcElement, int srcMip, Texture dst, int dstElement, int dstMip);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void CopyTexture_Region(Texture src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, Texture dst, int dstElement, int dstMip, int dstX, int dstY);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool ConvertTexture_Full(Texture src, Texture dst);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool ConvertTexture_Slice(Texture src, int srcElement, Texture dst, int dstElement);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_SetNullRT();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_SetRTSimple(out RenderBuffer color, out RenderBuffer depth, int mip, CubemapFace face, int depthSlice);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_SetMRTFullSetup(RenderBuffer[] colorSA, out RenderBuffer depth, int mip, CubemapFace face, int depthSlice, RenderBufferLoadAction[] colorLoadSA, RenderBufferStoreAction[] colorStoreSA, RenderBufferLoadAction depthLoad, RenderBufferStoreAction depthStore);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_SetMRTSimple(RenderBuffer[] colorSA, out RenderBuffer depth, int mip, CubemapFace face, int depthSlice);

    /// <summary>
    ///   <para>Currently active color buffer (Read Only).</para>
    /// </summary>
    public static RenderBuffer activeColorBuffer
    {
      get
      {
        RenderBuffer res;
        Graphics.GetActiveColorBuffer(out res);
        return res;
      }
    }

    /// <summary>
    ///   <para>Currently active depth/stencil buffer (Read Only).</para>
    /// </summary>
    public static RenderBuffer activeDepthBuffer
    {
      get
      {
        RenderBuffer res;
        Graphics.GetActiveDepthBuffer(out res);
        return res;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void GetActiveColorBuffer(out RenderBuffer res);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void GetActiveDepthBuffer(out RenderBuffer res);

    /// <summary>
    ///   <para>Set random write target for level pixel shaders.</para>
    /// </summary>
    /// <param name="index">Index of the random write target in the shader.</param>
    /// <param name="uav">RenderTexture to set as write target.</param>
    /// <param name="preserveCounterValue">Whether to leave the append/consume counter value unchanged.</param>
    public static void SetRandomWriteTarget(int index, RenderTexture uav)
    {
      Graphics.Internal_SetRandomWriteTargetRT(index, uav);
    }

    [ExcludeFromDocs]
    public static void SetRandomWriteTarget(int index, ComputeBuffer uav)
    {
      bool preserveCounterValue = false;
      Graphics.SetRandomWriteTarget(index, uav, preserveCounterValue);
    }

    /// <summary>
    ///   <para>Set random write target for level pixel shaders.</para>
    /// </summary>
    /// <param name="index">Index of the random write target in the shader.</param>
    /// <param name="uav">RenderTexture to set as write target.</param>
    /// <param name="preserveCounterValue">Whether to leave the append/consume counter value unchanged.</param>
    public static void SetRandomWriteTarget(int index, ComputeBuffer uav, [DefaultValue("false")] bool preserveCounterValue)
    {
      if (uav == null)
        throw new ArgumentNullException(nameof (uav));
      if (uav.m_Ptr == IntPtr.Zero)
        throw new ObjectDisposedException(nameof (uav));
      Graphics.Internal_SetRandomWriteTargetBuffer(index, uav, preserveCounterValue);
    }

    /// <summary>
    ///   <para>Clear random write targets for level pixel shaders.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ClearRandomWriteTargets();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_SetRandomWriteTargetRT(int index, RenderTexture uav);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_SetRandomWriteTargetBuffer(int index, ComputeBuffer uav, bool preserveCounterValue);

    /// <summary>
    ///         <para>Graphics Tier classification for current device.
    /// Changing this value affects any subsequently loaded shaders. Initially this value is auto-detected from the hardware in use.</para>
    ///       </summary>
    public static extern GraphicsTier activeTier { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns the currently active color gamut.</para>
    /// </summary>
    public static extern ColorGamut activeColorGamut { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static void CheckLoadActionValid(RenderBufferLoadAction load, string bufferType)
    {
      if (load != RenderBufferLoadAction.Load && load != RenderBufferLoadAction.DontCare)
        throw new ArgumentException(UnityString.Format("Bad {0} LoadAction provided.", (object) bufferType));
    }

    internal static void CheckStoreActionValid(RenderBufferStoreAction store, string bufferType)
    {
      if (store != RenderBufferStoreAction.Store && store != RenderBufferStoreAction.DontCare)
        throw new ArgumentException(UnityString.Format("Bad {0} StoreAction provided.", (object) bufferType));
    }

    internal static void SetRenderTargetImpl(RenderTargetSetup setup)
    {
      if (setup.color.Length == 0)
        throw new ArgumentException("Invalid color buffer count for SetRenderTarget");
      if (setup.color.Length != setup.colorLoad.Length)
        throw new ArgumentException("Color LoadAction and Buffer arrays have different sizes");
      if (setup.color.Length != setup.colorStore.Length)
        throw new ArgumentException("Color StoreAction and Buffer arrays have different sizes");
      foreach (RenderBufferLoadAction load in setup.colorLoad)
        Graphics.CheckLoadActionValid(load, "Color");
      foreach (RenderBufferStoreAction store in setup.colorStore)
        Graphics.CheckStoreActionValid(store, "Color");
      Graphics.CheckLoadActionValid(setup.depthLoad, "Depth");
      Graphics.CheckStoreActionValid(setup.depthStore, "Depth");
      if (setup.cubemapFace < CubemapFace.Unknown || setup.cubemapFace > CubemapFace.NegativeZ)
        throw new ArgumentException("Bad CubemapFace provided");
      Graphics.Internal_SetMRTFullSetup(setup.color, out setup.depth, setup.mipLevel, setup.cubemapFace, setup.depthSlice, setup.colorLoad, setup.colorStore, setup.depthLoad, setup.depthStore);
    }

    internal static void SetRenderTargetImpl(RenderBuffer colorBuffer, RenderBuffer depthBuffer, int mipLevel, CubemapFace face, int depthSlice)
    {
      RenderBuffer color = colorBuffer;
      RenderBuffer depth = depthBuffer;
      Graphics.Internal_SetRTSimple(out color, out depth, mipLevel, face, depthSlice);
    }

    internal static void SetRenderTargetImpl(RenderTexture rt, int mipLevel, CubemapFace face, int depthSlice)
    {
      if ((bool) ((Object) rt))
        Graphics.SetRenderTargetImpl(rt.colorBuffer, rt.depthBuffer, mipLevel, face, depthSlice);
      else
        Graphics.Internal_SetNullRT();
    }

    internal static void SetRenderTargetImpl(RenderBuffer[] colorBuffers, RenderBuffer depthBuffer, int mipLevel, CubemapFace face, int depthSlice)
    {
      RenderBuffer depth = depthBuffer;
      Graphics.Internal_SetMRTSimple(colorBuffers, out depth, mipLevel, face, depthSlice);
    }

    /// <summary>
    ///   <para>Sets current render target.</para>
    /// </summary>
    /// <param name="rt">RenderTexture to set as active render target.</param>
    /// <param name="mipLevel">Mipmap level to render into (use 0 if not mipmapped).</param>
    /// <param name="face">Cubemap face to render into (use Unknown if not a cubemap).</param>
    /// <param name="depthSlice">Depth slice to render into (use 0 if not a 3D or 2DArray render target).</param>
    /// <param name="colorBuffer">Color buffer to render into.</param>
    /// <param name="depthBuffer">Depth buffer to render into.</param>
    /// <param name="colorBuffers">
    /// Color buffers to render into (for multiple render target effects).</param>
    /// <param name="setup">Full render target setup information.</param>
    public static void SetRenderTarget(RenderTexture rt)
    {
      Graphics.SetRenderTargetImpl(rt, 0, CubemapFace.Unknown, 0);
    }

    /// <summary>
    ///   <para>Sets current render target.</para>
    /// </summary>
    /// <param name="rt">RenderTexture to set as active render target.</param>
    /// <param name="mipLevel">Mipmap level to render into (use 0 if not mipmapped).</param>
    /// <param name="face">Cubemap face to render into (use Unknown if not a cubemap).</param>
    /// <param name="depthSlice">Depth slice to render into (use 0 if not a 3D or 2DArray render target).</param>
    /// <param name="colorBuffer">Color buffer to render into.</param>
    /// <param name="depthBuffer">Depth buffer to render into.</param>
    /// <param name="colorBuffers">
    /// Color buffers to render into (for multiple render target effects).</param>
    /// <param name="setup">Full render target setup information.</param>
    public static void SetRenderTarget(RenderTexture rt, int mipLevel)
    {
      Graphics.SetRenderTargetImpl(rt, mipLevel, CubemapFace.Unknown, 0);
    }

    /// <summary>
    ///   <para>Sets current render target.</para>
    /// </summary>
    /// <param name="rt">RenderTexture to set as active render target.</param>
    /// <param name="mipLevel">Mipmap level to render into (use 0 if not mipmapped).</param>
    /// <param name="face">Cubemap face to render into (use Unknown if not a cubemap).</param>
    /// <param name="depthSlice">Depth slice to render into (use 0 if not a 3D or 2DArray render target).</param>
    /// <param name="colorBuffer">Color buffer to render into.</param>
    /// <param name="depthBuffer">Depth buffer to render into.</param>
    /// <param name="colorBuffers">
    /// Color buffers to render into (for multiple render target effects).</param>
    /// <param name="setup">Full render target setup information.</param>
    public static void SetRenderTarget(RenderTexture rt, int mipLevel, CubemapFace face)
    {
      Graphics.SetRenderTargetImpl(rt, mipLevel, face, 0);
    }

    /// <summary>
    ///   <para>Sets current render target.</para>
    /// </summary>
    /// <param name="rt">RenderTexture to set as active render target.</param>
    /// <param name="mipLevel">Mipmap level to render into (use 0 if not mipmapped).</param>
    /// <param name="face">Cubemap face to render into (use Unknown if not a cubemap).</param>
    /// <param name="depthSlice">Depth slice to render into (use 0 if not a 3D or 2DArray render target).</param>
    /// <param name="colorBuffer">Color buffer to render into.</param>
    /// <param name="depthBuffer">Depth buffer to render into.</param>
    /// <param name="colorBuffers">
    /// Color buffers to render into (for multiple render target effects).</param>
    /// <param name="setup">Full render target setup information.</param>
    public static void SetRenderTarget(RenderTexture rt, int mipLevel, CubemapFace face, int depthSlice)
    {
      Graphics.SetRenderTargetImpl(rt, mipLevel, face, depthSlice);
    }

    /// <summary>
    ///   <para>Sets current render target.</para>
    /// </summary>
    /// <param name="rt">RenderTexture to set as active render target.</param>
    /// <param name="mipLevel">Mipmap level to render into (use 0 if not mipmapped).</param>
    /// <param name="face">Cubemap face to render into (use Unknown if not a cubemap).</param>
    /// <param name="depthSlice">Depth slice to render into (use 0 if not a 3D or 2DArray render target).</param>
    /// <param name="colorBuffer">Color buffer to render into.</param>
    /// <param name="depthBuffer">Depth buffer to render into.</param>
    /// <param name="colorBuffers">
    /// Color buffers to render into (for multiple render target effects).</param>
    /// <param name="setup">Full render target setup information.</param>
    public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer)
    {
      Graphics.SetRenderTargetImpl(colorBuffer, depthBuffer, 0, CubemapFace.Unknown, 0);
    }

    /// <summary>
    ///   <para>Sets current render target.</para>
    /// </summary>
    /// <param name="rt">RenderTexture to set as active render target.</param>
    /// <param name="mipLevel">Mipmap level to render into (use 0 if not mipmapped).</param>
    /// <param name="face">Cubemap face to render into (use Unknown if not a cubemap).</param>
    /// <param name="depthSlice">Depth slice to render into (use 0 if not a 3D or 2DArray render target).</param>
    /// <param name="colorBuffer">Color buffer to render into.</param>
    /// <param name="depthBuffer">Depth buffer to render into.</param>
    /// <param name="colorBuffers">
    /// Color buffers to render into (for multiple render target effects).</param>
    /// <param name="setup">Full render target setup information.</param>
    public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer, int mipLevel)
    {
      Graphics.SetRenderTargetImpl(colorBuffer, depthBuffer, mipLevel, CubemapFace.Unknown, 0);
    }

    /// <summary>
    ///   <para>Sets current render target.</para>
    /// </summary>
    /// <param name="rt">RenderTexture to set as active render target.</param>
    /// <param name="mipLevel">Mipmap level to render into (use 0 if not mipmapped).</param>
    /// <param name="face">Cubemap face to render into (use Unknown if not a cubemap).</param>
    /// <param name="depthSlice">Depth slice to render into (use 0 if not a 3D or 2DArray render target).</param>
    /// <param name="colorBuffer">Color buffer to render into.</param>
    /// <param name="depthBuffer">Depth buffer to render into.</param>
    /// <param name="colorBuffers">
    /// Color buffers to render into (for multiple render target effects).</param>
    /// <param name="setup">Full render target setup information.</param>
    public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer, int mipLevel, CubemapFace face)
    {
      Graphics.SetRenderTargetImpl(colorBuffer, depthBuffer, mipLevel, face, 0);
    }

    /// <summary>
    ///   <para>Sets current render target.</para>
    /// </summary>
    /// <param name="rt">RenderTexture to set as active render target.</param>
    /// <param name="mipLevel">Mipmap level to render into (use 0 if not mipmapped).</param>
    /// <param name="face">Cubemap face to render into (use Unknown if not a cubemap).</param>
    /// <param name="depthSlice">Depth slice to render into (use 0 if not a 3D or 2DArray render target).</param>
    /// <param name="colorBuffer">Color buffer to render into.</param>
    /// <param name="depthBuffer">Depth buffer to render into.</param>
    /// <param name="colorBuffers">
    /// Color buffers to render into (for multiple render target effects).</param>
    /// <param name="setup">Full render target setup information.</param>
    public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer, int mipLevel, CubemapFace face, int depthSlice)
    {
      Graphics.SetRenderTargetImpl(colorBuffer, depthBuffer, mipLevel, face, depthSlice);
    }

    /// <summary>
    ///   <para>Sets current render target.</para>
    /// </summary>
    /// <param name="rt">RenderTexture to set as active render target.</param>
    /// <param name="mipLevel">Mipmap level to render into (use 0 if not mipmapped).</param>
    /// <param name="face">Cubemap face to render into (use Unknown if not a cubemap).</param>
    /// <param name="depthSlice">Depth slice to render into (use 0 if not a 3D or 2DArray render target).</param>
    /// <param name="colorBuffer">Color buffer to render into.</param>
    /// <param name="depthBuffer">Depth buffer to render into.</param>
    /// <param name="colorBuffers">
    /// Color buffers to render into (for multiple render target effects).</param>
    /// <param name="setup">Full render target setup information.</param>
    public static void SetRenderTarget(RenderBuffer[] colorBuffers, RenderBuffer depthBuffer)
    {
      Graphics.SetRenderTargetImpl(colorBuffers, depthBuffer, 0, CubemapFace.Unknown, 0);
    }

    /// <summary>
    ///   <para>Sets current render target.</para>
    /// </summary>
    /// <param name="rt">RenderTexture to set as active render target.</param>
    /// <param name="mipLevel">Mipmap level to render into (use 0 if not mipmapped).</param>
    /// <param name="face">Cubemap face to render into (use Unknown if not a cubemap).</param>
    /// <param name="depthSlice">Depth slice to render into (use 0 if not a 3D or 2DArray render target).</param>
    /// <param name="colorBuffer">Color buffer to render into.</param>
    /// <param name="depthBuffer">Depth buffer to render into.</param>
    /// <param name="colorBuffers">
    /// Color buffers to render into (for multiple render target effects).</param>
    /// <param name="setup">Full render target setup information.</param>
    public static void SetRenderTarget(RenderTargetSetup setup)
    {
      Graphics.SetRenderTargetImpl(setup);
    }

    /// <summary>
    ///   <para>Copy texture contents.</para>
    /// </summary>
    /// <param name="src">Source texture.</param>
    /// <param name="dst">Destination texture.</param>
    /// <param name="srcElement">Source texture element (cubemap face, texture array layer or 3D texture depth slice).</param>
    /// <param name="srcMip">Source texture mipmap level.</param>
    /// <param name="dstElement">Destination texture element (cubemap face, texture array layer or 3D texture depth slice).</param>
    /// <param name="dstMip">Destination texture mipmap level.</param>
    /// <param name="srcX">X coordinate of source texture region to copy (left side is zero).</param>
    /// <param name="srcY">Y coordinate of source texture region to copy (bottom is zero).</param>
    /// <param name="srcWidth">Width of source texture region to copy.</param>
    /// <param name="srcHeight">Height of source texture region to copy.</param>
    /// <param name="dstX">X coordinate of where to copy region in destination texture (left side is zero).</param>
    /// <param name="dstY">Y coordinate of where to copy region in destination texture (bottom is zero).</param>
    public static void CopyTexture(Texture src, Texture dst)
    {
      Graphics.CopyTexture_Full(src, dst);
    }

    public static void CopyTexture(Texture src, int srcElement, Texture dst, int dstElement)
    {
      Graphics.CopyTexture_Slice_AllMips(src, srcElement, dst, dstElement);
    }

    /// <summary>
    ///   <para>Copy texture contents.</para>
    /// </summary>
    /// <param name="src">Source texture.</param>
    /// <param name="dst">Destination texture.</param>
    /// <param name="srcElement">Source texture element (cubemap face, texture array layer or 3D texture depth slice).</param>
    /// <param name="srcMip">Source texture mipmap level.</param>
    /// <param name="dstElement">Destination texture element (cubemap face, texture array layer or 3D texture depth slice).</param>
    /// <param name="dstMip">Destination texture mipmap level.</param>
    /// <param name="srcX">X coordinate of source texture region to copy (left side is zero).</param>
    /// <param name="srcY">Y coordinate of source texture region to copy (bottom is zero).</param>
    /// <param name="srcWidth">Width of source texture region to copy.</param>
    /// <param name="srcHeight">Height of source texture region to copy.</param>
    /// <param name="dstX">X coordinate of where to copy region in destination texture (left side is zero).</param>
    /// <param name="dstY">Y coordinate of where to copy region in destination texture (bottom is zero).</param>
    public static void CopyTexture(Texture src, int srcElement, int srcMip, Texture dst, int dstElement, int dstMip)
    {
      Graphics.CopyTexture_Slice(src, srcElement, srcMip, dst, dstElement, dstMip);
    }

    /// <summary>
    ///   <para>Copy texture contents.</para>
    /// </summary>
    /// <param name="src">Source texture.</param>
    /// <param name="dst">Destination texture.</param>
    /// <param name="srcElement">Source texture element (cubemap face, texture array layer or 3D texture depth slice).</param>
    /// <param name="srcMip">Source texture mipmap level.</param>
    /// <param name="dstElement">Destination texture element (cubemap face, texture array layer or 3D texture depth slice).</param>
    /// <param name="dstMip">Destination texture mipmap level.</param>
    /// <param name="srcX">X coordinate of source texture region to copy (left side is zero).</param>
    /// <param name="srcY">Y coordinate of source texture region to copy (bottom is zero).</param>
    /// <param name="srcWidth">Width of source texture region to copy.</param>
    /// <param name="srcHeight">Height of source texture region to copy.</param>
    /// <param name="dstX">X coordinate of where to copy region in destination texture (left side is zero).</param>
    /// <param name="dstY">Y coordinate of where to copy region in destination texture (bottom is zero).</param>
    public static void CopyTexture(Texture src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, Texture dst, int dstElement, int dstMip, int dstX, int dstY)
    {
      Graphics.CopyTexture_Region(src, srcElement, srcMip, srcX, srcY, srcWidth, srcHeight, dst, dstElement, dstMip, dstX, dstY);
    }

    /// <summary>
    ///         <para>This function provides an efficient way to convert between textures of different formats and dimensions.
    /// The destination texture format should be uncompressed and correspond to a supported RenderTextureFormat.</para>
    ///       </summary>
    /// <param name="src">Source texture.</param>
    /// <param name="dst">Destination texture.</param>
    /// <param name="srcElement">Source element (e.g. cubemap face).  Set this to 0 for 2d source textures.</param>
    /// <param name="dstElement">Destination element (e.g. cubemap face or texture array element).</param>
    /// <returns>
    ///   <para>True if the call succeeded.</para>
    /// </returns>
    public static bool ConvertTexture(Texture src, Texture dst)
    {
      return Graphics.ConvertTexture_Full(src, dst);
    }

    /// <summary>
    ///         <para>This function provides an efficient way to convert between textures of different formats and dimensions.
    /// The destination texture format should be uncompressed and correspond to a supported RenderTextureFormat.</para>
    ///       </summary>
    /// <param name="src">Source texture.</param>
    /// <param name="dst">Destination texture.</param>
    /// <param name="srcElement">Source element (e.g. cubemap face).  Set this to 0 for 2d source textures.</param>
    /// <param name="dstElement">Destination element (e.g. cubemap face or texture array element).</param>
    /// <returns>
    ///   <para>True if the call succeeded.</para>
    /// </returns>
    public static bool ConvertTexture(Texture src, int srcElement, Texture dst, int dstElement)
    {
      return Graphics.ConvertTexture_Slice(src, srcElement, dst, dstElement);
    }

    private static void DrawMeshImpl(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, Transform probeAnchor, bool useLightProbes)
    {
      Graphics.Internal_DrawMeshMatrix(ref new Internal_DrawMeshMatrixArguments()
      {
        layer = layer,
        submeshIndex = submeshIndex,
        matrix = matrix,
        castShadows = (int) castShadows,
        receiveShadows = !receiveShadows ? 0 : 1,
        reflectionProbeAnchorInstanceID = !((Object) probeAnchor != (Object) null) ? 0 : probeAnchor.GetInstanceID(),
        useLightProbes = useLightProbes
      }, properties, material, mesh, camera);
    }

    private static void DrawTextureImpl(Rect screenRect, Texture texture, Rect sourceRect, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Color color, Material mat, int pass)
    {
      Graphics.Internal_DrawTexture(ref new Internal_DrawTextureArguments()
      {
        screenRect = screenRect,
        sourceRect = sourceRect,
        leftBorder = leftBorder,
        rightBorder = rightBorder,
        topBorder = topBorder,
        bottomBorder = bottomBorder,
        color = (Color32) color,
        pass = pass,
        texture = texture,
        mat = mat
      });
    }

    /// <summary>
    ///   <para>Draw a mesh immediately.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations). Note that the mesh will not be displayed correctly if matrix has negative scale.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    public static void DrawMeshNow(Mesh mesh, Vector3 position, Quaternion rotation)
    {
      Graphics.DrawMeshNow(mesh, position, rotation, -1);
    }

    /// <summary>
    ///   <para>Draw a mesh immediately.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations). Note that the mesh will not be displayed correctly if matrix has negative scale.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    public static void DrawMeshNow(Mesh mesh, Vector3 position, Quaternion rotation, int materialIndex)
    {
      if ((Object) mesh == (Object) null)
        throw new ArgumentNullException(nameof (mesh));
      Graphics.Internal_DrawMeshNow1(mesh, materialIndex, position, rotation);
    }

    /// <summary>
    ///   <para>Draw a mesh immediately.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations). Note that the mesh will not be displayed correctly if matrix has negative scale.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    public static void DrawMeshNow(Mesh mesh, Matrix4x4 matrix)
    {
      Graphics.DrawMeshNow(mesh, matrix, -1);
    }

    /// <summary>
    ///   <para>Draw a mesh immediately.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations). Note that the mesh will not be displayed correctly if matrix has negative scale.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    public static void DrawMeshNow(Mesh mesh, Matrix4x4 matrix, int materialIndex)
    {
      if ((Object) mesh == (Object) null)
        throw new ArgumentNullException(nameof (mesh));
      Graphics.Internal_DrawMeshNow2(mesh, materialIndex, matrix);
    }

    private static void DrawMeshInstancedImpl(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera)
    {
      if (!SystemInfo.supportsInstancing)
        throw new InvalidOperationException("Instancing is not supported.");
      if ((Object) mesh == (Object) null)
        throw new ArgumentNullException(nameof (mesh));
      if (submeshIndex < 0 || submeshIndex >= mesh.subMeshCount)
        throw new ArgumentOutOfRangeException(nameof (submeshIndex), "submeshIndex out of range.");
      if ((Object) material == (Object) null)
        throw new ArgumentNullException(nameof (material));
      if (!material.enableInstancing)
        throw new InvalidOperationException("Material needs to enable instancing for use with DrawMeshInstanced.");
      if (matrices == null)
        throw new ArgumentNullException(nameof (matrices));
      if (count < 0 || count > Mathf.Min(Graphics.kMaxDrawMeshInstanceCount, matrices.Length))
        throw new ArgumentOutOfRangeException(nameof (count), string.Format("Count must be in the range of 0 to {0}.", (object) Mathf.Min(Graphics.kMaxDrawMeshInstanceCount, matrices.Length)));
      if (count <= 0)
        return;
      Graphics.Internal_DrawMeshInstanced(mesh, submeshIndex, material, matrices, count, properties, castShadows, receiveShadows, layer, camera);
    }

    private static void DrawMeshInstancedImpl(Mesh mesh, int submeshIndex, Material material, List<Matrix4x4> matrices, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera)
    {
      if (matrices == null)
        throw new ArgumentNullException(nameof (matrices));
      if (matrices.Count > Graphics.kMaxDrawMeshInstanceCount)
        throw new ArgumentOutOfRangeException(nameof (matrices), string.Format("Matrix list count must be in the range of 0 to {0}.", (object) Graphics.kMaxDrawMeshInstanceCount));
      Graphics.DrawMeshInstancedImpl(mesh, submeshIndex, material, (Matrix4x4[]) NoAllocHelpers.ExtractArrayFromList((object) matrices), matrices.Count, properties, castShadows, receiveShadows, layer, camera);
    }

    private static void DrawMeshInstancedIndirectImpl(Mesh mesh, int submeshIndex, Material material, Bounds bounds, ComputeBuffer bufferWithArgs, int argsOffset, MaterialPropertyBlock properties, ShadowCastingMode castShadows, bool receiveShadows, int layer, Camera camera)
    {
      if (!SystemInfo.supportsInstancing)
        throw new InvalidOperationException("Instancing is not supported.");
      if ((Object) mesh == (Object) null)
        throw new ArgumentNullException(nameof (mesh));
      if (submeshIndex < 0 || submeshIndex >= mesh.subMeshCount)
        throw new ArgumentOutOfRangeException(nameof (submeshIndex), "submeshIndex out of range.");
      if ((Object) material == (Object) null)
        throw new ArgumentNullException(nameof (material));
      if (bufferWithArgs == null)
        throw new ArgumentNullException(nameof (bufferWithArgs));
      Graphics.Internal_DrawMeshInstancedIndirect(mesh, submeshIndex, material, bounds, bufferWithArgs, argsOffset, properties, castShadows, receiveShadows, layer, camera);
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Method DrawMesh has been deprecated. Use Graphics.DrawMeshNow instead (UnityUpgradable) -> DrawMeshNow(*)", true)]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation)
    {
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Method DrawMesh has been deprecated. Use Graphics.DrawMeshNow instead (UnityUpgradable) -> DrawMeshNow(*)", true)]
    public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, int materialIndex)
    {
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Method DrawMesh has been deprecated. Use Graphics.DrawMeshNow instead (UnityUpgradable) -> DrawMeshNow(*)", true)]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix)
    {
    }

    /// <summary>
    ///   <para>Draw a mesh.</para>
    /// </summary>
    /// <param name="mesh">The Mesh to draw.</param>
    /// <param name="position">Position of the mesh.</param>
    /// <param name="rotation">Rotation of the mesh.</param>
    /// <param name="materialIndex">Subset of the mesh to draw.</param>
    /// <param name="matrix">Transformation matrix of the mesh (combines position, rotation and other transformations).</param>
    /// <param name="material">Material to use.</param>
    /// <param name="layer"> to use.</param>
    /// <param name="camera">If null (default), the mesh will be drawn in all cameras. Otherwise it will be rendered in the given camera only.</param>
    /// <param name="submeshIndex">Which subset of the mesh to draw. This applies only to meshes that are composed of several materials.</param>
    /// <param name="properties">Additional material properties to apply onto material just before this mesh will be drawn. See MaterialPropertyBlock.</param>
    /// <param name="castShadows">Should the mesh cast shadows?</param>
    /// <param name="receiveShadows">Should the mesh receive shadows?</param>
    /// <param name="useLightProbes">Should the mesh use light probes?</param>
    /// <param name="probeAnchor">If used, the mesh will use this Transform's position to sample light probes and find the matching reflection probe.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Method DrawMesh has been deprecated. Use Graphics.DrawMeshNow instead (UnityUpgradable) -> DrawMeshNow(*)", true)]
    public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, int materialIndex)
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Property deviceName has been deprecated. Use SystemInfo.graphicsDeviceName instead (UnityUpgradable) -> UnityEngine.SystemInfo.graphicsDeviceName", true)]
    public static string deviceName
    {
      get
      {
        return SystemInfo.graphicsDeviceName;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Property deviceVendor has been deprecated. Use SystemInfo.graphicsDeviceVendor instead (UnityUpgradable) -> UnityEngine.SystemInfo.graphicsDeviceVendor", true)]
    public static string deviceVendor
    {
      get
      {
        return SystemInfo.graphicsDeviceVendor;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Property deviceVersion has been deprecated. Use SystemInfo.graphicsDeviceVersion instead (UnityUpgradable) -> UnityEngine.SystemInfo.graphicsDeviceVersion", true)]
    public static string deviceVersion
    {
      get
      {
        return SystemInfo.graphicsDeviceVersion;
      }
    }
  }
}
