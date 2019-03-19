// Decompiled with JetBrains decompiler
// Type: UnityEngine.Sprite
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2B0D2089-5607-4A78-AD52-7419F014E605
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Represents a Sprite object for use in 2D gameplay.</para>
  /// </summary>
  [NativeHeader("Runtime/2D/Common/ScriptBindings/SpritesMarshalling.h")]
  [NativeType("Runtime/Graphics/SpriteFrame.h")]
  public sealed class Sprite : Object
  {
    /// <summary>
    ///   <para>Create a new Sprite object.</para>
    /// </summary>
    /// <param name="texture">Texture from which to obtain the sprite graphic.</param>
    /// <param name="rect">Rectangular section of the texture to use for the sprite.</param>
    /// <param name="pivot">Sprite's pivot point relative to its graphic rectangle.</param>
    /// <param name="pixelsPerUnit">The number of pixels in the sprite that correspond to one unit in world space.</param>
    /// <param name="extrude">Amount by which the sprite mesh should be expanded outwards.</param>
    /// <param name="meshType">Controls the type of mesh generated for the sprite.</param>
    /// <param name="border">The border sizes of the sprite (X=left, Y=bottom, Z=right, W=top).</param>
    /// <param name="generateFallbackPhysicsShape">Generates a default physics shape for the sprite.</param>
    public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, [DefaultValue("100.0f")] float pixelsPerUnit, [DefaultValue("0")] uint extrude, [DefaultValue("SpriteMeshType.Tight")] SpriteMeshType meshType, [DefaultValue("Vector4.zero")] Vector4 border, [DefaultValue("false")] bool generateFallbackPhysicsShape)
    {
      return Sprite.INTERNAL_CALL_Create(texture, ref rect, ref pivot, pixelsPerUnit, extrude, meshType, ref border, generateFallbackPhysicsShape);
    }

    /// <summary>
    ///   <para>Create a new Sprite object.</para>
    /// </summary>
    /// <param name="texture">Texture from which to obtain the sprite graphic.</param>
    /// <param name="rect">Rectangular section of the texture to use for the sprite.</param>
    /// <param name="pivot">Sprite's pivot point relative to its graphic rectangle.</param>
    /// <param name="pixelsPerUnit">The number of pixels in the sprite that correspond to one unit in world space.</param>
    /// <param name="extrude">Amount by which the sprite mesh should be expanded outwards.</param>
    /// <param name="meshType">Controls the type of mesh generated for the sprite.</param>
    /// <param name="border">The border sizes of the sprite (X=left, Y=bottom, Z=right, W=top).</param>
    /// <param name="generateFallbackPhysicsShape">Generates a default physics shape for the sprite.</param>
    [ExcludeFromDocs]
    public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border)
    {
      bool generateFallbackPhysicsShape = false;
      return Sprite.INTERNAL_CALL_Create(texture, ref rect, ref pivot, pixelsPerUnit, extrude, meshType, ref border, generateFallbackPhysicsShape);
    }

    /// <summary>
    ///   <para>Create a new Sprite object.</para>
    /// </summary>
    /// <param name="texture">Texture from which to obtain the sprite graphic.</param>
    /// <param name="rect">Rectangular section of the texture to use for the sprite.</param>
    /// <param name="pivot">Sprite's pivot point relative to its graphic rectangle.</param>
    /// <param name="pixelsPerUnit">The number of pixels in the sprite that correspond to one unit in world space.</param>
    /// <param name="extrude">Amount by which the sprite mesh should be expanded outwards.</param>
    /// <param name="meshType">Controls the type of mesh generated for the sprite.</param>
    /// <param name="border">The border sizes of the sprite (X=left, Y=bottom, Z=right, W=top).</param>
    /// <param name="generateFallbackPhysicsShape">Generates a default physics shape for the sprite.</param>
    [ExcludeFromDocs]
    public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType)
    {
      bool generateFallbackPhysicsShape = false;
      Vector4 zero = Vector4.zero;
      return Sprite.INTERNAL_CALL_Create(texture, ref rect, ref pivot, pixelsPerUnit, extrude, meshType, ref zero, generateFallbackPhysicsShape);
    }

    /// <summary>
    ///   <para>Create a new Sprite object.</para>
    /// </summary>
    /// <param name="texture">Texture from which to obtain the sprite graphic.</param>
    /// <param name="rect">Rectangular section of the texture to use for the sprite.</param>
    /// <param name="pivot">Sprite's pivot point relative to its graphic rectangle.</param>
    /// <param name="pixelsPerUnit">The number of pixels in the sprite that correspond to one unit in world space.</param>
    /// <param name="extrude">Amount by which the sprite mesh should be expanded outwards.</param>
    /// <param name="meshType">Controls the type of mesh generated for the sprite.</param>
    /// <param name="border">The border sizes of the sprite (X=left, Y=bottom, Z=right, W=top).</param>
    /// <param name="generateFallbackPhysicsShape">Generates a default physics shape for the sprite.</param>
    [ExcludeFromDocs]
    public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude)
    {
      bool generateFallbackPhysicsShape = false;
      Vector4 zero = Vector4.zero;
      SpriteMeshType meshType = SpriteMeshType.Tight;
      return Sprite.INTERNAL_CALL_Create(texture, ref rect, ref pivot, pixelsPerUnit, extrude, meshType, ref zero, generateFallbackPhysicsShape);
    }

    /// <summary>
    ///   <para>Create a new Sprite object.</para>
    /// </summary>
    /// <param name="texture">Texture from which to obtain the sprite graphic.</param>
    /// <param name="rect">Rectangular section of the texture to use for the sprite.</param>
    /// <param name="pivot">Sprite's pivot point relative to its graphic rectangle.</param>
    /// <param name="pixelsPerUnit">The number of pixels in the sprite that correspond to one unit in world space.</param>
    /// <param name="extrude">Amount by which the sprite mesh should be expanded outwards.</param>
    /// <param name="meshType">Controls the type of mesh generated for the sprite.</param>
    /// <param name="border">The border sizes of the sprite (X=left, Y=bottom, Z=right, W=top).</param>
    /// <param name="generateFallbackPhysicsShape">Generates a default physics shape for the sprite.</param>
    [ExcludeFromDocs]
    public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit)
    {
      bool generateFallbackPhysicsShape = false;
      Vector4 zero = Vector4.zero;
      SpriteMeshType meshType = SpriteMeshType.Tight;
      uint extrude = 0;
      return Sprite.INTERNAL_CALL_Create(texture, ref rect, ref pivot, pixelsPerUnit, extrude, meshType, ref zero, generateFallbackPhysicsShape);
    }

    /// <summary>
    ///   <para>Create a new Sprite object.</para>
    /// </summary>
    /// <param name="texture">Texture from which to obtain the sprite graphic.</param>
    /// <param name="rect">Rectangular section of the texture to use for the sprite.</param>
    /// <param name="pivot">Sprite's pivot point relative to its graphic rectangle.</param>
    /// <param name="pixelsPerUnit">The number of pixels in the sprite that correspond to one unit in world space.</param>
    /// <param name="extrude">Amount by which the sprite mesh should be expanded outwards.</param>
    /// <param name="meshType">Controls the type of mesh generated for the sprite.</param>
    /// <param name="border">The border sizes of the sprite (X=left, Y=bottom, Z=right, W=top).</param>
    /// <param name="generateFallbackPhysicsShape">Generates a default physics shape for the sprite.</param>
    [ExcludeFromDocs]
    public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot)
    {
      bool generateFallbackPhysicsShape = false;
      Vector4 zero = Vector4.zero;
      SpriteMeshType meshType = SpriteMeshType.Tight;
      uint extrude = 0;
      float pixelsPerUnit = 100f;
      return Sprite.INTERNAL_CALL_Create(texture, ref rect, ref pivot, pixelsPerUnit, extrude, meshType, ref zero, generateFallbackPhysicsShape);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Sprite INTERNAL_CALL_Create(Texture2D texture, ref Rect rect, ref Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, ref Vector4 border, bool generateFallbackPhysicsShape);

    /// <summary>
    ///   <para>Bounds of the Sprite, specified by its center and extents in world space units.</para>
    /// </summary>
    public Bounds bounds
    {
      get
      {
        Bounds bounds;
        this.INTERNAL_get_bounds(out bounds);
        return bounds;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_bounds(out Bounds value);

    /// <summary>
    ///   <para>Location of the Sprite on the original Texture, specified in pixels.</para>
    /// </summary>
    public Rect rect
    {
      get
      {
        Rect rect;
        this.INTERNAL_get_rect(out rect);
        return rect;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_rect(out Rect value);

    /// <summary>
    ///   <para>Get the reference to the used texture. If packed this will point to the atlas, if not packed will point to the source sprite.</para>
    /// </summary>
    public extern Texture2D texture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///         <para>Returns the texture that contains the alpha channel from the source texture. Unity generates this texture under the hood for sprites that have alpha in the source, and need to be compressed using techniques like ETC1.
    /// 
    /// Returns NULL if there is no associated alpha texture for the source sprite. This is the case if the sprite has not been setup to use ETC1 compression.</para>
    ///       </summary>
    public extern Texture2D associatedAlphaSplitTexture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Get the rectangle this sprite uses on its texture. Raises an exception if this sprite is tightly packed in an atlas.</para>
    /// </summary>
    public Rect textureRect
    {
      get
      {
        Rect rect;
        this.INTERNAL_get_textureRect(out rect);
        return rect;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_textureRect(out Rect value);

    /// <summary>
    ///   <para>Gets the offset of the rectangle this sprite uses on its texture to the original sprite bounds. If sprite mesh type is FullRect, offset is zero.</para>
    /// </summary>
    public Vector2 textureRectOffset
    {
      get
      {
        Vector2 output;
        Sprite.Internal_GetTextureRectOffset(this, out output);
        return output;
      }
    }

    /// <summary>
    ///   <para>Returns true if this Sprite is packed in an atlas.</para>
    /// </summary>
    public extern bool packed { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>If Sprite is packed (see Sprite.packed), returns its SpritePackingMode.</para>
    /// </summary>
    public extern SpritePackingMode packingMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>If Sprite is packed (see Sprite.packed), returns its SpritePackingRotation.</para>
    /// </summary>
    public extern SpritePackingRotation packingRotation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_GetTextureRectOffset(Sprite sprite, out Vector2 output);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_GetPivot(Sprite sprite, out Vector2 output);

    /// <summary>
    ///   <para>Location of the Sprite's center point in the Rect on the original Texture, specified in pixels.</para>
    /// </summary>
    public Vector2 pivot
    {
      get
      {
        Vector2 output;
        Sprite.Internal_GetPivot(this, out output);
        return output;
      }
    }

    /// <summary>
    ///   <para>Returns the border sizes of the sprite.</para>
    /// </summary>
    public Vector4 border
    {
      get
      {
        Vector4 vector4;
        this.INTERNAL_get_border(out vector4);
        return vector4;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_border(out Vector4 value);

    /// <summary>
    ///   <para>Returns a copy of the array containing sprite mesh vertex positions.</para>
    /// </summary>
    public extern Vector2[] vertices { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns a copy of the array containing sprite mesh triangles.</para>
    /// </summary>
    public extern ushort[] triangles { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The base texture coordinates of the sprite mesh.</para>
    /// </summary>
    public extern Vector2[] uv { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Sets up new Sprite geometry.</para>
    /// </summary>
    /// <param name="vertices">Array of vertex positions in Sprite Rect space.</param>
    /// <param name="triangles">Array of sprite mesh triangle indices.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void OverrideGeometry(Vector2[] vertices, ushort[] triangles);

    /// <summary>
    ///   <para>The number of pixels in the sprite that correspond to one unit in world space. (Read Only)</para>
    /// </summary>
    public extern float pixelsPerUnit { [NativeMethod("GetPixelsToUnits"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The number of physics shapes for the Sprite.</para>
    /// </summary>
    /// <returns>
    ///   <para>The number of physics shapes for the Sprite.</para>
    /// </returns>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetPhysicsShapeCount();

    /// <summary>
    ///   <para>The number of points in the selected physics shape for the Sprite.</para>
    /// </summary>
    /// <param name="shapeIdx">The index of the physics shape to retrieve the number of points from.</param>
    /// <returns>
    ///   <para>The number of points in the selected physics shape for the Sprite.</para>
    /// </returns>
    public int GetPhysicsShapePointCount(int shapeIdx)
    {
      int physicsShapeCount = this.GetPhysicsShapeCount();
      if (shapeIdx < 0 || shapeIdx >= physicsShapeCount)
        throw new IndexOutOfRangeException(string.Format("Index({0}) is out of bounds(0 - {1})", (object) shapeIdx, (object) (physicsShapeCount - 1)));
      return this.Internal_GetPhysicsShapePointCount(shapeIdx);
    }

    [NativeMethod("GetPhysicsShapePointCount")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern int Internal_GetPhysicsShapePointCount(int shapeIdx);

    public int GetPhysicsShape(int shapeIdx, List<Vector2> physicsShape)
    {
      int physicsShapeCount = this.GetPhysicsShapeCount();
      if (shapeIdx < 0 || shapeIdx >= physicsShapeCount)
        throw new IndexOutOfRangeException(string.Format("Index({0}) is out of bounds(0 - {1})", (object) shapeIdx, (object) (physicsShapeCount - 1)));
      Sprite.GetPhysicsShapeImpl(this, shapeIdx, physicsShape);
      return physicsShape.Count;
    }

    [FreeFunction("SpritesBindings::GetPhysicsShape", ThrowsException = true)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void GetPhysicsShapeImpl(Sprite sprite, int shapeIdx, List<Vector2> physicsShape);

    public void OverridePhysicsShape(IList<Vector2[]> physicsShapes)
    {
      for (int index = 0; index < physicsShapes.Count; ++index)
      {
        Vector2[] physicsShape = physicsShapes[index];
        if (physicsShape == null)
          throw new ArgumentNullException(string.Format("Physics Shape at {0} is null.", (object) index));
        if (physicsShape.Length < 3)
          throw new ArgumentException(string.Format("Physics Shape at {0} has less than 3 vertices ({1}).", (object) index, (object) physicsShape.Length));
      }
      Sprite.OverridePhysicsShapeCount(this, physicsShapes.Count);
      for (int idx = 0; idx < physicsShapes.Count; ++idx)
        Sprite.OverridePhysicsShape(this, physicsShapes[idx], idx);
    }

    [FreeFunction("SpritesBindings::OverridePhysicsShapeCount")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void OverridePhysicsShapeCount(Sprite sprite, int physicsShapeCount);

    [FreeFunction("SpritesBindings::OverridePhysicsShape", ThrowsException = true)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void OverridePhysicsShape(Sprite sprite, Vector2[] physicsShape, int idx);
  }
}
