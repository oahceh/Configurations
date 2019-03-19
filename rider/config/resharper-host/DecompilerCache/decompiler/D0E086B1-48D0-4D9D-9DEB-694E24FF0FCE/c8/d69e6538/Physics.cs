// Decompiled with JetBrains decompiler
// Type: UnityEngine.Physics
// Assembly: UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D0E086B1-48D0-4D9D-9DEB-694E24FF0FCE
// Assembly location: C:\Program Files\Unity2018.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.PhysicsModule.dll

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Global physics properties and helper methods.</para>
  /// </summary>
  [NativeHeader("Runtime/Dynamics/PhysicsManager.h")]
  [StaticAccessor("GetPhysicsManager()", StaticAccessorType.Dot)]
  public class Physics
  {
    internal const float k_MaxFloatMinusEpsilon = 3.402823E+38f;
    /// <summary>
    ///   <para>Layer mask constant to select ignore raycast layer.</para>
    /// </summary>
    public const int IgnoreRaycastLayer = 4;
    /// <summary>
    ///   <para>Layer mask constant to select default raycast layers.</para>
    /// </summary>
    public const int DefaultRaycastLayers = -5;
    /// <summary>
    ///   <para>Layer mask constant to select all layers.</para>
    /// </summary>
    public const int AllLayers = -1;
    [Obsolete("Please use Physics.IgnoreRaycastLayer instead. (UnityUpgradable) -> IgnoreRaycastLayer", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public const int kIgnoreRaycastLayer = 4;
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Please use Physics.DefaultRaycastLayers instead. (UnityUpgradable) -> DefaultRaycastLayers", true)]
    public const int kDefaultRaycastLayers = -5;
    [Obsolete("Please use Physics.AllLayers instead. (UnityUpgradable) -> AllLayers", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public const int kAllLayers = -1;

    /// <summary>
    ///   <para>The minimum contact penetration value in order to apply a penalty force (default 0.05). Must be positive.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use Physics.defaultContactOffset or Collider.contactOffset instead.", true)]
    public static float minPenetrationForPenalty
    {
      get
      {
        return 0.0f;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>The gravity applied to all rigid bodies in the Scene.</para>
    /// </summary>
    public static Vector3 gravity
    {
      [ThreadSafe] get
      {
        Vector3 ret;
        Physics.get_gravity_Injected(out ret);
        return ret;
      }
      set
      {
        Physics.set_gravity_Injected(ref value);
      }
    }

    /// <summary>
    ///   <para>The default contact offset of the newly created colliders.</para>
    /// </summary>
    public static extern float defaultContactOffset { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The mass-normalized energy threshold, below which objects start going to sleep.</para>
    /// </summary>
    public static extern float sleepThreshold { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Specifies whether queries (raycasts, spherecasts, overlap tests, etc.) hit Triggers by default.</para>
    /// </summary>
    public static extern bool queriesHitTriggers { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Whether physics queries should hit back-face triangles.</para>
    /// </summary>
    public static extern bool queriesHitBackfaces { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Two colliding objects with a relative velocity below this will not bounce (default 2). Must be positive.</para>
    /// </summary>
    public static extern float bounceThreshold { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The defaultSolverIterations determines how accurately Rigidbody joints and collision contacts are resolved. (default 6). Must be positive.</para>
    /// </summary>
    public static extern int defaultSolverIterations { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The defaultSolverVelocityIterations affects how accurately the Rigidbody joints and collision contacts are resolved. (default 1). Must be positive.</para>
    /// </summary>
    public static extern int defaultSolverVelocityIterations { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("Please use bounceThreshold instead.")]
    public static float bounceTreshold
    {
      get
      {
        return Physics.bounceThreshold;
      }
      set
      {
        Physics.bounceThreshold = value;
      }
    }

    /// <summary>
    ///   <para>The default linear velocity, below which objects start going to sleep (default 0.15). Must be positive.</para>
    /// </summary>
    [Obsolete("The sleepVelocity is no longer supported. Use sleepThreshold. Note that sleepThreshold is energy but not velocity.")]
    public static float sleepVelocity
    {
      get
      {
        return 0.0f;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>The default angular velocity, below which objects start sleeping (default 0.14). Must be positive.</para>
    /// </summary>
    [Obsolete("The sleepAngularVelocity is no longer supported. Use sleepThreshold. Note that sleepThreshold is energy but not velocity.")]
    public static float sleepAngularVelocity
    {
      get
      {
        return 0.0f;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>The default maximum angular velocity permitted for any rigid bodies (default 7). Must be positive.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use Rigidbody.maxAngularVelocity instead.", true)]
    public static float maxAngularVelocity
    {
      get
      {
        return 0.0f;
      }
      set
      {
      }
    }

    [Obsolete("Please use Physics.defaultSolverIterations instead. (UnityUpgradable) -> defaultSolverIterations")]
    public static int solverIterationCount
    {
      get
      {
        return Physics.defaultSolverIterations;
      }
      set
      {
        Physics.defaultSolverIterations = value;
      }
    }

    [Obsolete("Please use Physics.defaultSolverVelocityIterations instead. (UnityUpgradable) -> defaultSolverVelocityIterations")]
    public static int solverVelocityIterationCount
    {
      get
      {
        return Physics.defaultSolverVelocityIterations;
      }
      set
      {
        Physics.defaultSolverVelocityIterations = value;
      }
    }

    [Obsolete("penetrationPenaltyForce has no effect.")]
    public static float penetrationPenaltyForce
    {
      get
      {
        return 0.0f;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>The PhysicsScene automatically created when Unity starts.</para>
    /// </summary>
    [NativeProperty("DefaultPhysicsSceneHandle")]
    public static PhysicsScene defaultPhysicsScene
    {
      get
      {
        PhysicsScene ret;
        Physics.get_defaultPhysicsScene_Injected(out ret);
        return ret;
      }
    }

    /// <summary>
    ///   <para>Makes the collision detection system ignore all collisions between collider1 and collider2.</para>
    /// </summary>
    /// <param name="collider1">Starting point of the collider.</param>
    /// <param name="collider2">End point of the collider.</param>
    /// <param name="ignore">Ignore collision.</param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void IgnoreCollision(Collider collider1, Collider collider2, [DefaultValue("true")] bool ignore);

    [ExcludeFromDocs]
    public static void IgnoreCollision(Collider collider1, Collider collider2)
    {
      Physics.IgnoreCollision(collider1, collider2, true);
    }

    /// <summary>
    ///         <para>Makes the collision detection system ignore all collisions between any collider in layer1 and any collider in layer2.
    /// 
    /// Note that IgnoreLayerCollision will reset the trigger state of affected colliders, so you might receive OnTriggerExit and OnTriggerEnter messages in response to calling this.</para>
    ///       </summary>
    /// <param name="layer1"></param>
    /// <param name="layer2"></param>
    /// <param name="ignore"></param>
    [NativeName("IgnoreCollision")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void IgnoreLayerCollision(int layer1, int layer2, [DefaultValue("true")] bool ignore);

    [ExcludeFromDocs]
    public static void IgnoreLayerCollision(int layer1, int layer2)
    {
      Physics.IgnoreLayerCollision(layer1, layer2, true);
    }

    /// <summary>
    ///   <para>Are collisions between layer1 and layer2 being ignored?</para>
    /// </summary>
    /// <param name="layer1"></param>
    /// <param name="layer2"></param>
    [NativeName("GetIgnoreCollision")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool GetIgnoreLayerCollision(int layer1, int layer2);

    /// <summary>
    ///   <para>Casts a ray, from point origin, in direction direction, of length maxDistance, against all colliders in the Scene.</para>
    /// </summary>
    /// <param name="origin">The starting point of the ray in world coordinates.</param>
    /// <param name="direction">The direction of the ray.</param>
    /// <param name="maxDistance">The max distance the ray should check for collisions.</param>
    /// <param name="layerMask">A that is used to selectively ignore Colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>True if the ray intersects with a Collider, otherwise false.</para>
    /// </returns>
    public static bool Raycast(
      Vector3 origin,
      Vector3 direction,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool Raycast(
      Vector3 origin,
      Vector3 direction,
      float maxDistance,
      int layerMask)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool Raycast(Vector3 origin, Vector3 direction)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    public static bool Raycast(
      Vector3 origin,
      Vector3 direction,
      out RaycastHit hitInfo,
      float maxDistance,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    [RequiredByNativeCode]
    public static bool Raycast(
      Vector3 origin,
      Vector3 direction,
      out RaycastHit hitInfo,
      float maxDistance,
      int layerMask)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool Raycast(
      Vector3 origin,
      Vector3 direction,
      out RaycastHit hitInfo,
      float maxDistance)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    /// <summary>
    ///   <para>Same as above using ray.origin and ray.direction instead of origin and direction.</para>
    /// </summary>
    /// <param name="ray">The starting point and direction of the ray.</param>
    /// <param name="maxDistance">The max distance the ray should check for collisions.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>True when the ray intersects any collider, otherwise false.</para>
    /// </returns>
    public static bool Raycast(
      Ray ray,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool Raycast(Ray ray, float maxDistance, int layerMask)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool Raycast(Ray ray, float maxDistance)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool Raycast(Ray ray)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    public static bool Raycast(
      Ray ray,
      out RaycastHit hitInfo,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool Raycast(Ray ray, out RaycastHit hitInfo)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    /// <summary>
    ///   <para>Returns true if there is any collider intersecting the line between start and end.</para>
    /// </summary>
    /// <param name="start">Start point.</param>
    /// <param name="end">End point.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    public static bool Linecast(
      Vector3 start,
      Vector3 end,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      Vector3 direction = end - start;
      return Physics.defaultPhysicsScene.Raycast(start, direction, direction.magnitude, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool Linecast(Vector3 start, Vector3 end, int layerMask)
    {
      return Physics.Linecast(start, end, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool Linecast(Vector3 start, Vector3 end)
    {
      return Physics.Linecast(start, end, -5, QueryTriggerInteraction.UseGlobal);
    }

    public static bool Linecast(
      Vector3 start,
      Vector3 end,
      out RaycastHit hitInfo,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      Vector3 direction = end - start;
      return Physics.defaultPhysicsScene.Raycast(start, direction, out hitInfo, direction.magnitude, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, int layerMask)
    {
      return Physics.Linecast(start, end, out hitInfo, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo)
    {
      return Physics.Linecast(start, end, out hitInfo, -5, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("CapsuleCast")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()", StaticAccessorType.Dot)]
    private static bool Query_CapsuleCast(
      PhysicsScene physicsScene,
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      float maxDistance,
      ref RaycastHit hitInfo,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Query_CapsuleCast_Injected(ref physicsScene, ref point1, ref point2, radius, ref direction, maxDistance, ref hitInfo, layerMask, queryTriggerInteraction);
    }

    private static bool Internal_CapsuleCast(
      PhysicsScene physicsScene,
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      out RaycastHit hitInfo,
      float maxDistance,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      float magnitude = direction.magnitude;
      hitInfo = new RaycastHit();
      if ((double) magnitude <= 1.40129846432482E-45)
        return false;
      Vector3 direction1 = direction / magnitude;
      return Physics.Query_CapsuleCast(physicsScene, point1, point2, radius, direction1, maxDistance, ref hitInfo, layerMask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Casts a capsule against all colliders in the Scene and returns detailed information on what was hit.</para>
    /// </summary>
    /// <param name="point1">The center of the sphere at the start of the capsule.</param>
    /// <param name="point2">The center of the sphere at the end of the capsule.</param>
    /// <param name="radius">The radius of the capsule.</param>
    /// <param name="direction">The direction into which to sweep the capsule.</param>
    /// <param name="maxDistance">The max length of the sweep.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>True when the capsule sweep intersects any collider, otherwise false.</para>
    /// </returns>
    public static bool CapsuleCast(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      RaycastHit hitInfo;
      return Physics.Internal_CapsuleCast(Physics.defaultPhysicsScene, point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool CapsuleCast(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      float maxDistance,
      int layerMask)
    {
      return Physics.CapsuleCast(point1, point2, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool CapsuleCast(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      float maxDistance)
    {
      return Physics.CapsuleCast(point1, point2, radius, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool CapsuleCast(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction)
    {
      return Physics.CapsuleCast(point1, point2, radius, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    public static bool CapsuleCast(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      out RaycastHit hitInfo,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Internal_CapsuleCast(Physics.defaultPhysicsScene, point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool CapsuleCast(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      out RaycastHit hitInfo,
      float maxDistance,
      int layerMask)
    {
      return Physics.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool CapsuleCast(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      out RaycastHit hitInfo,
      float maxDistance)
    {
      return Physics.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool CapsuleCast(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      out RaycastHit hitInfo)
    {
      return Physics.CapsuleCast(point1, point2, radius, direction, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("SphereCast")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()", StaticAccessorType.Dot)]
    private static bool Query_SphereCast(
      PhysicsScene physicsScene,
      Vector3 origin,
      float radius,
      Vector3 direction,
      float maxDistance,
      ref RaycastHit hitInfo,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Query_SphereCast_Injected(ref physicsScene, ref origin, radius, ref direction, maxDistance, ref hitInfo, layerMask, queryTriggerInteraction);
    }

    private static bool Internal_SphereCast(
      PhysicsScene physicsScene,
      Vector3 origin,
      float radius,
      Vector3 direction,
      out RaycastHit hitInfo,
      float maxDistance,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      float magnitude = direction.magnitude;
      hitInfo = new RaycastHit();
      if ((double) magnitude <= 1.40129846432482E-45)
        return false;
      Vector3 direction1 = direction / magnitude;
      return Physics.Query_SphereCast(physicsScene, origin, radius, direction1, maxDistance, ref hitInfo, layerMask, queryTriggerInteraction);
    }

    public static bool SphereCast(
      Vector3 origin,
      float radius,
      Vector3 direction,
      out RaycastHit hitInfo,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Internal_SphereCast(Physics.defaultPhysicsScene, origin, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool SphereCast(
      Vector3 origin,
      float radius,
      Vector3 direction,
      out RaycastHit hitInfo,
      float maxDistance,
      int layerMask)
    {
      return Physics.SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool SphereCast(
      Vector3 origin,
      float radius,
      Vector3 direction,
      out RaycastHit hitInfo,
      float maxDistance)
    {
      return Physics.SphereCast(origin, radius, direction, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool SphereCast(
      Vector3 origin,
      float radius,
      Vector3 direction,
      out RaycastHit hitInfo)
    {
      return Physics.SphereCast(origin, radius, direction, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    /// <summary>
    ///   <para>Casts a sphere along a ray and returns detailed information on what was hit.</para>
    /// </summary>
    /// <param name="ray">The starting point and direction of the ray into which the sphere sweep is cast.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="maxDistance">The max length of the cast.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>True when the sphere sweep intersects any collider, otherwise false.</para>
    /// </returns>
    public static bool SphereCast(
      Ray ray,
      float radius,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      RaycastHit hitInfo;
      return Physics.Internal_SphereCast(Physics.defaultPhysicsScene, ray.origin, radius, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool SphereCast(Ray ray, float radius, float maxDistance, int layerMask)
    {
      return Physics.SphereCast(ray, radius, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool SphereCast(Ray ray, float radius, float maxDistance)
    {
      return Physics.SphereCast(ray, radius, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool SphereCast(Ray ray, float radius)
    {
      return Physics.SphereCast(ray, radius, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    public static bool SphereCast(
      Ray ray,
      float radius,
      out RaycastHit hitInfo,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Internal_SphereCast(Physics.defaultPhysicsScene, ray.origin, radius, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool SphereCast(
      Ray ray,
      float radius,
      out RaycastHit hitInfo,
      float maxDistance,
      int layerMask)
    {
      return Physics.SphereCast(ray, radius, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool SphereCast(
      Ray ray,
      float radius,
      out RaycastHit hitInfo,
      float maxDistance)
    {
      return Physics.SphereCast(ray, radius, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo)
    {
      return Physics.SphereCast(ray, radius, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("BoxCast")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()", StaticAccessorType.Dot)]
    private static bool Query_BoxCast(
      PhysicsScene physicsScene,
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      Quaternion orientation,
      float maxDistance,
      ref RaycastHit outHit,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Query_BoxCast_Injected(ref physicsScene, ref center, ref halfExtents, ref direction, ref orientation, maxDistance, ref outHit, layerMask, queryTriggerInteraction);
    }

    private static bool Internal_BoxCast(
      PhysicsScene physicsScene,
      Vector3 center,
      Vector3 halfExtents,
      Quaternion orientation,
      Vector3 direction,
      out RaycastHit hitInfo,
      float maxDistance,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      float magnitude = direction.magnitude;
      hitInfo = new RaycastHit();
      if ((double) magnitude <= 1.40129846432482E-45)
        return false;
      Vector3 direction1 = direction / magnitude;
      return Physics.Query_BoxCast(physicsScene, center, halfExtents, direction1, orientation, maxDistance, ref hitInfo, layerMask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Casts the box along a ray and returns detailed information on what was hit.</para>
    /// </summary>
    /// <param name="center">Center of the box.</param>
    /// <param name="halfExtents">Half the size of the box in each dimension.</param>
    /// <param name="direction">The direction in which to cast the box.</param>
    /// <param name="orientation">Rotation of the box.</param>
    /// <param name="maxDistance">The max length of the cast.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>True, if any intersections were found.</para>
    /// </returns>
    public static bool BoxCast(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      [DefaultValue("Quaternion.identity")] Quaternion orientation,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      RaycastHit hitInfo;
      return Physics.Internal_BoxCast(Physics.defaultPhysicsScene, center, halfExtents, orientation, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool BoxCast(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      Quaternion orientation,
      float maxDistance,
      int layerMask)
    {
      return Physics.BoxCast(center, halfExtents, direction, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool BoxCast(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      Quaternion orientation,
      float maxDistance)
    {
      return Physics.BoxCast(center, halfExtents, direction, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool BoxCast(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      Quaternion orientation)
    {
      return Physics.BoxCast(center, halfExtents, direction, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction)
    {
      return Physics.BoxCast(center, halfExtents, direction, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    public static bool BoxCast(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      out RaycastHit hitInfo,
      [DefaultValue("Quaternion.identity")] Quaternion orientation,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Internal_BoxCast(Physics.defaultPhysicsScene, center, halfExtents, orientation, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool BoxCast(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      out RaycastHit hitInfo,
      Quaternion orientation,
      float maxDistance,
      int layerMask)
    {
      return Physics.BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool BoxCast(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      out RaycastHit hitInfo,
      Quaternion orientation,
      float maxDistance)
    {
      return Physics.BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool BoxCast(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      out RaycastHit hitInfo,
      Quaternion orientation)
    {
      return Physics.BoxCast(center, halfExtents, direction, out hitInfo, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool BoxCast(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      out RaycastHit hitInfo)
    {
      return Physics.BoxCast(center, halfExtents, direction, out hitInfo, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()", StaticAccessorType.Dot)]
    [NativeName("RaycastAll")]
    private static RaycastHit[] Internal_RaycastAll(
      PhysicsScene physicsScene,
      Ray ray,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Internal_RaycastAll_Injected(ref physicsScene, ref ray, maxDistance, mask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>See Also: Raycast.</para>
    /// </summary>
    /// <param name="origin">The starting point of the ray in world coordinates.</param>
    /// <param name="direction">The direction of the ray.</param>
    /// <param name="maxDistance">The max distance the rayhit is allowed to be from the start of the ray.</param>
    /// <param name="layermask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <param name="layerMask"></param>
    public static RaycastHit[] RaycastAll(
      Vector3 origin,
      Vector3 direction,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      float magnitude = direction.magnitude;
      if ((double) magnitude <= 1.40129846432482E-45)
        return new RaycastHit[0];
      Vector3 direction1 = direction / magnitude;
      return Physics.Internal_RaycastAll(Physics.defaultPhysicsScene, new Ray(origin, direction1), maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] RaycastAll(
      Vector3 origin,
      Vector3 direction,
      float maxDistance,
      int layerMask)
    {
      return Physics.RaycastAll(origin, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] RaycastAll(
      Vector3 origin,
      Vector3 direction,
      float maxDistance)
    {
      return Physics.RaycastAll(origin, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction)
    {
      return Physics.RaycastAll(origin, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    /// <summary>
    ///   <para>Casts a ray through the Scene and returns all hits. Note that order is not guaranteed.</para>
    /// </summary>
    /// <param name="ray">The starting point and direction of the ray.</param>
    /// <param name="maxDistance">The max distance the rayhit is allowed to be from the start of the ray.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    public static RaycastHit[] RaycastAll(
      Ray ray,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.RaycastAll(ray.origin, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    [RequiredByNativeCode]
    public static RaycastHit[] RaycastAll(Ray ray, float maxDistance, int layerMask)
    {
      return Physics.RaycastAll(ray.origin, ray.direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] RaycastAll(Ray ray, float maxDistance)
    {
      return Physics.RaycastAll(ray.origin, ray.direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] RaycastAll(Ray ray)
    {
      return Physics.RaycastAll(ray.origin, ray.direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    /// <summary>
    ///   <para>Cast a ray through the Scene and store the hits into the buffer.</para>
    /// </summary>
    /// <param name="ray">The starting point and direction of the ray.</param>
    /// <param name="results">The buffer to store the hits into.</param>
    /// <param name="maxDistance">The max distance the rayhit is allowed to be from the start of the ray.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>The amount of hits stored into the results buffer.</para>
    /// </returns>
    public static int RaycastNonAlloc(
      Ray ray,
      RaycastHit[] results,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, results, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static int RaycastNonAlloc(
      Ray ray,
      RaycastHit[] results,
      float maxDistance,
      int layerMask)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int RaycastNonAlloc(Ray ray, RaycastHit[] results)
    {
      return Physics.defaultPhysicsScene.Raycast(ray.origin, ray.direction, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    /// <summary>
    ///   <para>Cast a ray through the Scene and store the hits into the buffer.</para>
    /// </summary>
    /// <param name="origin">The starting point and direction of the ray.</param>
    /// <param name="results">The buffer to store the hits into.</param>
    /// <param name="direction">The direction of the ray.</param>
    /// <param name="maxDistance">The max distance the rayhit is allowed to be from the start of the ray.</param>
    /// <param name="layermask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <param name="layerMask"></param>
    /// <returns>
    ///   <para>The amount of hits stored into the results buffer.</para>
    /// </returns>
    public static int RaycastNonAlloc(
      Vector3 origin,
      Vector3 direction,
      RaycastHit[] results,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, results, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static int RaycastNonAlloc(
      Vector3 origin,
      Vector3 direction,
      RaycastHit[] results,
      float maxDistance,
      int layerMask)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int RaycastNonAlloc(
      Vector3 origin,
      Vector3 direction,
      RaycastHit[] results,
      float maxDistance)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results)
    {
      return Physics.defaultPhysicsScene.Raycast(origin, direction, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("CapsuleCastAll")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()", StaticAccessorType.Dot)]
    private static RaycastHit[] Query_CapsuleCastAll(
      PhysicsScene physicsScene,
      Vector3 p0,
      Vector3 p1,
      float radius,
      Vector3 direction,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Query_CapsuleCastAll_Injected(ref physicsScene, ref p0, ref p1, radius, ref direction, maxDistance, mask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Like Physics.CapsuleCast, but this function will return all hits the capsule sweep intersects.</para>
    /// </summary>
    /// <param name="point1">The center of the sphere at the start of the capsule.</param>
    /// <param name="point2">The center of the sphere at the end of the capsule.</param>
    /// <param name="radius">The radius of the capsule.</param>
    /// <param name="direction">The direction into which to sweep the capsule.</param>
    /// <param name="maxDistance">The max length of the sweep.</param>
    /// <param name="layermask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <param name="layerMask"></param>
    /// <returns>
    ///   <para>An array of all colliders hit in the sweep.</para>
    /// </returns>
    public static RaycastHit[] CapsuleCastAll(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      float magnitude = direction.magnitude;
      if ((double) magnitude <= 1.40129846432482E-45)
        return new RaycastHit[0];
      Vector3 direction1 = direction / magnitude;
      return Physics.Query_CapsuleCastAll(Physics.defaultPhysicsScene, point1, point2, radius, direction1, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] CapsuleCastAll(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      float maxDistance,
      int layerMask)
    {
      return Physics.CapsuleCastAll(point1, point2, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] CapsuleCastAll(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      float maxDistance)
    {
      return Physics.CapsuleCastAll(point1, point2, radius, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] CapsuleCastAll(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction)
    {
      return Physics.CapsuleCastAll(point1, point2, radius, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("SphereCastAll")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()", StaticAccessorType.Dot)]
    private static RaycastHit[] Query_SphereCastAll(
      PhysicsScene physicsScene,
      Vector3 origin,
      float radius,
      Vector3 direction,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Query_SphereCastAll_Injected(ref physicsScene, ref origin, radius, ref direction, maxDistance, mask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Like Physics.SphereCast, but this function will return all hits the sphere sweep intersects.</para>
    /// </summary>
    /// <param name="origin">The center of the sphere at the start of the sweep.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="direction">The direction in which to sweep the sphere.</param>
    /// <param name="maxDistance">The max length of the sweep.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a sphere.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>An array of all colliders hit in the sweep.</para>
    /// </returns>
    public static RaycastHit[] SphereCastAll(
      Vector3 origin,
      float radius,
      Vector3 direction,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      float magnitude = direction.magnitude;
      if ((double) magnitude <= 1.40129846432482E-45)
        return new RaycastHit[0];
      Vector3 direction1 = direction / magnitude;
      return Physics.Query_SphereCastAll(Physics.defaultPhysicsScene, origin, radius, direction1, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] SphereCastAll(
      Vector3 origin,
      float radius,
      Vector3 direction,
      float maxDistance,
      int layerMask)
    {
      return Physics.SphereCastAll(origin, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] SphereCastAll(
      Vector3 origin,
      float radius,
      Vector3 direction,
      float maxDistance)
    {
      return Physics.SphereCastAll(origin, radius, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] SphereCastAll(
      Vector3 origin,
      float radius,
      Vector3 direction)
    {
      return Physics.SphereCastAll(origin, radius, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    /// <summary>
    ///   <para>Like Physics.SphereCast, but this function will return all hits the sphere sweep intersects.</para>
    /// </summary>
    /// <param name="ray">The starting point and direction of the ray into which the sphere sweep is cast.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="maxDistance">The max length of the sweep.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a sphere.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    public static RaycastHit[] SphereCastAll(
      Ray ray,
      float radius,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.SphereCastAll(ray.origin, radius, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] SphereCastAll(
      Ray ray,
      float radius,
      float maxDistance,
      int layerMask)
    {
      return Physics.SphereCastAll(ray, radius, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance)
    {
      return Physics.SphereCastAll(ray, radius, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] SphereCastAll(Ray ray, float radius)
    {
      return Physics.SphereCastAll(ray, radius, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("OverlapCapsule")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()", StaticAccessorType.Dot)]
    private static Collider[] OverlapCapsule_Internal(
      PhysicsScene physicsScene,
      Vector3 point0,
      Vector3 point1,
      float radius,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapCapsule_Internal_Injected(ref physicsScene, ref point0, ref point1, radius, layerMask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Check the given capsule against the physics world and return all overlapping colliders.</para>
    /// </summary>
    /// <param name="point0">The center of the sphere at the start of the capsule.</param>
    /// <param name="point1">The center of the sphere at the end of the capsule.</param>
    /// <param name="radius">The radius of the capsule.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>Colliders touching or inside the capsule.</para>
    /// </returns>
    public static Collider[] OverlapCapsule(
      Vector3 point0,
      Vector3 point1,
      float radius,
      [DefaultValue("AllLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapCapsule_Internal(Physics.defaultPhysicsScene, point0, point1, radius, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static Collider[] OverlapCapsule(
      Vector3 point0,
      Vector3 point1,
      float radius,
      int layerMask)
    {
      return Physics.OverlapCapsule(point0, point1, radius, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius)
    {
      return Physics.OverlapCapsule(point0, point1, radius, -1, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("OverlapSphere")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()", StaticAccessorType.Dot)]
    private static Collider[] OverlapSphere_Internal(
      PhysicsScene physicsScene,
      Vector3 position,
      float radius,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapSphere_Internal_Injected(ref physicsScene, ref position, radius, layerMask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Returns an array with all colliders touching or inside the sphere.</para>
    /// </summary>
    /// <param name="position">Center of the sphere.</param>
    /// <param name="radius">Radius of the sphere.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    public static Collider[] OverlapSphere(
      Vector3 position,
      float radius,
      [DefaultValue("AllLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapSphere_Internal(Physics.defaultPhysicsScene, position, radius, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static Collider[] OverlapSphere(Vector3 position, float radius, int layerMask)
    {
      return Physics.OverlapSphere(position, radius, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static Collider[] OverlapSphere(Vector3 position, float radius)
    {
      return Physics.OverlapSphere(position, radius, -1, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("Simulate")]
    internal static void Simulate_Internal(PhysicsScene physicsScene, float step)
    {
      Physics.Simulate_Internal_Injected(ref physicsScene, step);
    }

    /// <summary>
    ///   <para>Simulate physics in the Scene.</para>
    /// </summary>
    /// <param name="step">The time to advance physics by.</param>
    public static void Simulate(float step)
    {
      if (Physics.autoSimulation)
        Debug.LogWarning((object) "Physics.Simulate(...) was called but auto simulation is active. You should disable auto simulation first before calling this function therefore the simulation was not run.");
      else
        Physics.Simulate_Internal(Physics.defaultPhysicsScene, step);
    }

    /// <summary>
    ///   <para>Sets whether the physics should be simulated automatically or not.</para>
    /// </summary>
    public static extern bool autoSimulation { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Apply Transform changes to the physics engine.</para>
    /// </summary>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SyncTransforms();

    /// <summary>
    ///   <para>Whether or not to automatically sync transform changes with the physics system whenever a Transform component changes.</para>
    /// </summary>
    public static extern bool autoSyncTransforms { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Determines whether the garbage collector should reuse only a single instance of a Collision type for all collision callbacks.</para>
    /// </summary>
    public static extern bool reuseCollisionCallbacks { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

    [NativeName("ComputePenetration")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    private static bool Query_ComputePenetration(
      [NotNull] Collider colliderA,
      Vector3 positionA,
      Quaternion rotationA,
      [NotNull] Collider colliderB,
      Vector3 positionB,
      Quaternion rotationB,
      ref Vector3 direction,
      ref float distance)
    {
      return Physics.Query_ComputePenetration_Injected(colliderA, ref positionA, ref rotationA, colliderB, ref positionB, ref rotationB, ref direction, ref distance);
    }

    public static bool ComputePenetration(
      Collider colliderA,
      Vector3 positionA,
      Quaternion rotationA,
      Collider colliderB,
      Vector3 positionB,
      Quaternion rotationB,
      out Vector3 direction,
      out float distance)
    {
      direction = Vector3.zero;
      distance = 0.0f;
      return Physics.Query_ComputePenetration(colliderA, positionA, rotationA, colliderB, positionB, rotationB, ref direction, ref distance);
    }

    [NativeName("ClosestPoint")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    private static Vector3 Query_ClosestPoint(
      [NotNull] Collider collider,
      Vector3 position,
      Quaternion rotation,
      Vector3 point)
    {
      Vector3 ret;
      Physics.Query_ClosestPoint_Injected(collider, ref position, ref rotation, ref point, out ret);
      return ret;
    }

    /// <summary>
    ///   <para>Returns a point on the given collider that is closest to the specified location.</para>
    /// </summary>
    /// <param name="point">Location you want to find the closest point to.</param>
    /// <param name="collider">The collider that you find the closest point on.</param>
    /// <param name="position">The position of the collider.</param>
    /// <param name="rotation">The rotation of the collider.</param>
    /// <returns>
    ///   <para>The point on the collider that is closest to the specified location.</para>
    /// </returns>
    public static Vector3 ClosestPoint(
      Vector3 point,
      Collider collider,
      Vector3 position,
      Quaternion rotation)
    {
      return Physics.Query_ClosestPoint(collider, position, rotation, point);
    }

    /// <summary>
    ///   <para>Sets the minimum separation distance for cloth inter-collision.</para>
    /// </summary>
    [StaticAccessor("GetPhysicsManager()")]
    public static extern float interCollisionDistance { [NativeName("GetClothInterCollisionDistance"), MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetClothInterCollisionDistance"), MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets the cloth inter-collision stiffness.</para>
    /// </summary>
    [StaticAccessor("GetPhysicsManager()")]
    public static extern float interCollisionStiffness { [NativeName("GetClothInterCollisionStiffness"), MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetClothInterCollisionStiffness"), MethodImpl(MethodImplOptions.InternalCall)] set; }

    [StaticAccessor("GetPhysicsManager()")]
    public static extern bool interCollisionSettingsToggle { [NativeName("GetClothInterCollisionSettingsToggle"), MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetClothInterCollisionSettingsToggle"), MethodImpl(MethodImplOptions.InternalCall)] set; }

    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    [NativeName("OverlapSphereNonAlloc")]
    private static int OverlapSphereNonAlloc_Internal(
      PhysicsScene physicsScene,
      Vector3 position,
      float radius,
      Collider[] results,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapSphereNonAlloc_Internal_Injected(ref physicsScene, ref position, radius, results, layerMask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Computes and stores colliders touching or inside the sphere into the provided buffer.</para>
    /// </summary>
    /// <param name="position">Center of the sphere.</param>
    /// <param name="radius">Radius of the sphere.</param>
    /// <param name="results">The buffer to store the results into.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>The amount of colliders stored into the results buffer.</para>
    /// </returns>
    public static int OverlapSphereNonAlloc(
      Vector3 position,
      float radius,
      Collider[] results,
      [DefaultValue("AllLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapSphereNonAlloc_Internal(Physics.defaultPhysicsScene, position, radius, results, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static int OverlapSphereNonAlloc(
      Vector3 position,
      float radius,
      Collider[] results,
      int layerMask)
    {
      return Physics.OverlapSphereNonAlloc(position, radius, results, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results)
    {
      return Physics.OverlapSphereNonAlloc(position, radius, results, -1, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("SphereTest")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    private static bool CheckSphere_Internal(
      PhysicsScene physicsScene,
      Vector3 position,
      float radius,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.CheckSphere_Internal_Injected(ref physicsScene, ref position, radius, layerMask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Returns true if there are any colliders overlapping the sphere defined by position and radius in world coordinates.</para>
    /// </summary>
    /// <param name="position">Center of the sphere.</param>
    /// <param name="radius">Radius of the sphere.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    public static bool CheckSphere(
      Vector3 position,
      float radius,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.CheckSphere_Internal(Physics.defaultPhysicsScene, position, radius, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool CheckSphere(Vector3 position, float radius, int layerMask)
    {
      return Physics.CheckSphere(position, radius, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool CheckSphere(Vector3 position, float radius)
    {
      return Physics.CheckSphere(position, radius, -5, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("CapsuleCastNonAlloc")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    private static int Internal_CapsuleCastNonAlloc(
      PhysicsScene physicsScene,
      Vector3 p0,
      Vector3 p1,
      float radius,
      Vector3 direction,
      RaycastHit[] raycastHits,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Internal_CapsuleCastNonAlloc_Injected(ref physicsScene, ref p0, ref p1, radius, ref direction, raycastHits, maxDistance, mask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Casts a capsule against all colliders in the Scene and returns detailed information on what was hit into the buffer.</para>
    /// </summary>
    /// <param name="point1">The center of the sphere at the start of the capsule.</param>
    /// <param name="point2">The center of the sphere at the end of the capsule.</param>
    /// <param name="radius">The radius of the capsule.</param>
    /// <param name="direction">The direction into which to sweep the capsule.</param>
    /// <param name="results">The buffer to store the hits into.</param>
    /// <param name="maxDistance">The max length of the sweep.</param>
    /// <param name="layermask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <param name="layerMask"></param>
    /// <returns>
    ///   <para>The amount of hits stored into the buffer.</para>
    /// </returns>
    public static int CapsuleCastNonAlloc(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      RaycastHit[] results,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      if ((double) direction.magnitude > 1.40129846432482E-45)
        return Physics.Internal_CapsuleCastNonAlloc(Physics.defaultPhysicsScene, point1, point2, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
      return 0;
    }

    [ExcludeFromDocs]
    public static int CapsuleCastNonAlloc(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      RaycastHit[] results,
      float maxDistance,
      int layerMask)
    {
      return Physics.CapsuleCastNonAlloc(point1, point2, radius, direction, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int CapsuleCastNonAlloc(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      RaycastHit[] results,
      float maxDistance)
    {
      return Physics.CapsuleCastNonAlloc(point1, point2, radius, direction, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int CapsuleCastNonAlloc(
      Vector3 point1,
      Vector3 point2,
      float radius,
      Vector3 direction,
      RaycastHit[] results)
    {
      return Physics.CapsuleCastNonAlloc(point1, point2, radius, direction, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("SphereCastNonAlloc")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    private static int Internal_SphereCastNonAlloc(
      PhysicsScene physicsScene,
      Vector3 origin,
      float radius,
      Vector3 direction,
      RaycastHit[] raycastHits,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Internal_SphereCastNonAlloc_Injected(ref physicsScene, ref origin, radius, ref direction, raycastHits, maxDistance, mask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Cast sphere along the direction and store the results into buffer.</para>
    /// </summary>
    /// <param name="origin">The center of the sphere at the start of the sweep.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="direction">The direction in which to sweep the sphere.</param>
    /// <param name="results">The buffer to save the hits into.</param>
    /// <param name="maxDistance">The max length of the sweep.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a sphere.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>The amount of hits stored into the results buffer.</para>
    /// </returns>
    public static int SphereCastNonAlloc(
      Vector3 origin,
      float radius,
      Vector3 direction,
      RaycastHit[] results,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      if ((double) direction.magnitude > 1.40129846432482E-45)
        return Physics.Internal_SphereCastNonAlloc(Physics.defaultPhysicsScene, origin, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
      return 0;
    }

    [ExcludeFromDocs]
    public static int SphereCastNonAlloc(
      Vector3 origin,
      float radius,
      Vector3 direction,
      RaycastHit[] results,
      float maxDistance,
      int layerMask)
    {
      return Physics.SphereCastNonAlloc(origin, radius, direction, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int SphereCastNonAlloc(
      Vector3 origin,
      float radius,
      Vector3 direction,
      RaycastHit[] results,
      float maxDistance)
    {
      return Physics.SphereCastNonAlloc(origin, radius, direction, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int SphereCastNonAlloc(
      Vector3 origin,
      float radius,
      Vector3 direction,
      RaycastHit[] results)
    {
      return Physics.SphereCastNonAlloc(origin, radius, direction, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    /// <summary>
    ///   <para>Cast sphere along the direction and store the results into buffer.</para>
    /// </summary>
    /// <param name="ray">The starting point and direction of the ray into which the sphere sweep is cast.</param>
    /// <param name="radius">The radius of the sphere.</param>
    /// <param name="results">The buffer to save the results to.</param>
    /// <param name="maxDistance">The max length of the sweep.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a sphere.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>The amount of hits stored into the results buffer.</para>
    /// </returns>
    public static int SphereCastNonAlloc(
      Ray ray,
      float radius,
      RaycastHit[] results,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.SphereCastNonAlloc(ray.origin, radius, ray.direction, results, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static int SphereCastNonAlloc(
      Ray ray,
      float radius,
      RaycastHit[] results,
      float maxDistance,
      int layerMask)
    {
      return Physics.SphereCastNonAlloc(ray, radius, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int SphereCastNonAlloc(
      Ray ray,
      float radius,
      RaycastHit[] results,
      float maxDistance)
    {
      return Physics.SphereCastNonAlloc(ray, radius, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results)
    {
      return Physics.SphereCastNonAlloc(ray, radius, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    [NativeName("CapsuleTest")]
    private static bool CheckCapsule_Internal(
      PhysicsScene physicsScene,
      Vector3 start,
      Vector3 end,
      float radius,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.CheckCapsule_Internal_Injected(ref physicsScene, ref start, ref end, radius, layerMask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Checks if any colliders overlap a capsule-shaped volume in world space.</para>
    /// </summary>
    /// <param name="start">The center of the sphere at the start of the capsule.</param>
    /// <param name="end">The center of the sphere at the end of the capsule.</param>
    /// <param name="radius">The radius of the capsule.</param>
    /// <param name="layermask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <param name="layerMask"></param>
    public static bool CheckCapsule(
      Vector3 start,
      Vector3 end,
      float radius,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.CheckCapsule_Internal(Physics.defaultPhysicsScene, start, end, radius, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layerMask)
    {
      return Physics.CheckCapsule(start, end, radius, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool CheckCapsule(Vector3 start, Vector3 end, float radius)
    {
      return Physics.CheckCapsule(start, end, radius, -5, QueryTriggerInteraction.UseGlobal);
    }

    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    [NativeName("BoxTest")]
    private static bool CheckBox_Internal(
      PhysicsScene physicsScene,
      Vector3 center,
      Vector3 halfExtents,
      Quaternion orientation,
      int layermask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.CheckBox_Internal_Injected(ref physicsScene, ref center, ref halfExtents, ref orientation, layermask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Check whether the given box overlaps with other colliders or not.</para>
    /// </summary>
    /// <param name="center">Center of the box.</param>
    /// <param name="halfExtents">Half the size of the box in each dimension.</param>
    /// <param name="orientation">Rotation of the box.</param>
    /// <param name="layermask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>True, if the box overlaps with any colliders.</para>
    /// </returns>
    public static bool CheckBox(
      Vector3 center,
      Vector3 halfExtents,
      [DefaultValue("Quaternion.identity")] Quaternion orientation,
      [DefaultValue("DefaultRaycastLayers")] int layermask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.CheckBox_Internal(Physics.defaultPhysicsScene, center, halfExtents, orientation, layermask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static bool CheckBox(
      Vector3 center,
      Vector3 halfExtents,
      Quaternion orientation,
      int layerMask)
    {
      return Physics.CheckBox(center, halfExtents, orientation, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation)
    {
      return Physics.CheckBox(center, halfExtents, orientation, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static bool CheckBox(Vector3 center, Vector3 halfExtents)
    {
      return Physics.CheckBox(center, halfExtents, Quaternion.identity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("OverlapBox")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    private static Collider[] OverlapBox_Internal(
      PhysicsScene physicsScene,
      Vector3 center,
      Vector3 halfExtents,
      Quaternion orientation,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapBox_Internal_Injected(ref physicsScene, ref center, ref halfExtents, ref orientation, layerMask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Find all colliders touching or inside of the given box.</para>
    /// </summary>
    /// <param name="center">Center of the box.</param>
    /// <param name="halfExtents">Half of the size of the box in each dimension.</param>
    /// <param name="orientation">Rotation of the box.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>Colliders that overlap with the given box.</para>
    /// </returns>
    public static Collider[] OverlapBox(
      Vector3 center,
      Vector3 halfExtents,
      [DefaultValue("Quaternion.identity")] Quaternion orientation,
      [DefaultValue("AllLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapBox_Internal(Physics.defaultPhysicsScene, center, halfExtents, orientation, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static Collider[] OverlapBox(
      Vector3 center,
      Vector3 halfExtents,
      Quaternion orientation,
      int layerMask)
    {
      return Physics.OverlapBox(center, halfExtents, orientation, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static Collider[] OverlapBox(
      Vector3 center,
      Vector3 halfExtents,
      Quaternion orientation)
    {
      return Physics.OverlapBox(center, halfExtents, orientation, -1, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents)
    {
      return Physics.OverlapBox(center, halfExtents, Quaternion.identity, -1, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("OverlapBoxNonAlloc")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    private static int OverlapBoxNonAlloc_Internal(
      PhysicsScene physicsScene,
      Vector3 center,
      Vector3 halfExtents,
      Collider[] results,
      Quaternion orientation,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapBoxNonAlloc_Internal_Injected(ref physicsScene, ref center, ref halfExtents, results, ref orientation, mask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Find all colliders touching or inside of the given box, and store them into the buffer.</para>
    /// </summary>
    /// <param name="center">Center of the box.</param>
    /// <param name="halfExtents">Half of the size of the box in each dimension.</param>
    /// <param name="results">The buffer to store the results in.</param>
    /// <param name="orientation">Rotation of the box.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a ray.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <param name="mask"></param>
    /// <returns>
    ///   <para>The amount of colliders stored in results.</para>
    /// </returns>
    public static int OverlapBoxNonAlloc(
      Vector3 center,
      Vector3 halfExtents,
      Collider[] results,
      [DefaultValue("Quaternion.identity")] Quaternion orientation,
      [DefaultValue("AllLayers")] int mask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapBoxNonAlloc_Internal(Physics.defaultPhysicsScene, center, halfExtents, results, orientation, mask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static int OverlapBoxNonAlloc(
      Vector3 center,
      Vector3 halfExtents,
      Collider[] results,
      Quaternion orientation,
      int mask)
    {
      return Physics.OverlapBoxNonAlloc(center, halfExtents, results, orientation, mask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int OverlapBoxNonAlloc(
      Vector3 center,
      Vector3 halfExtents,
      Collider[] results,
      Quaternion orientation)
    {
      return Physics.OverlapBoxNonAlloc(center, halfExtents, results, orientation, -1, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results)
    {
      return Physics.OverlapBoxNonAlloc(center, halfExtents, results, Quaternion.identity, -1, QueryTriggerInteraction.UseGlobal);
    }

    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    [NativeName("BoxCastNonAlloc")]
    private static int Internal_BoxCastNonAlloc(
      PhysicsScene physicsScene,
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      RaycastHit[] raycastHits,
      Quaternion orientation,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Internal_BoxCastNonAlloc_Injected(ref physicsScene, ref center, ref halfExtents, ref direction, raycastHits, ref orientation, maxDistance, mask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Cast the box along the direction, and store hits in the provided buffer.</para>
    /// </summary>
    /// <param name="center">Center of the box.</param>
    /// <param name="halfExtents">Half the size of the box in each dimension.</param>
    /// <param name="direction">The direction in which to cast the box.</param>
    /// <param name="results">The buffer to store the results in.</param>
    /// <param name="orientation">Rotation of the box.</param>
    /// <param name="maxDistance">The max length of the cast.</param>
    /// <param name="layermask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <param name="layerMask"></param>
    /// <returns>
    ///   <para>The amount of hits stored to the results buffer.</para>
    /// </returns>
    public static int BoxCastNonAlloc(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      RaycastHit[] results,
      [DefaultValue("Quaternion.identity")] Quaternion orientation,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      if ((double) direction.magnitude > 1.40129846432482E-45)
        return Physics.Internal_BoxCastNonAlloc(Physics.defaultPhysicsScene, center, halfExtents, direction, results, orientation, maxDistance, layerMask, queryTriggerInteraction);
      return 0;
    }

    [ExcludeFromDocs]
    public static int BoxCastNonAlloc(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      RaycastHit[] results,
      Quaternion orientation)
    {
      return Physics.BoxCastNonAlloc(center, halfExtents, direction, results, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int BoxCastNonAlloc(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      RaycastHit[] results,
      Quaternion orientation,
      float maxDistance)
    {
      return Physics.BoxCastNonAlloc(center, halfExtents, direction, results, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int BoxCastNonAlloc(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      RaycastHit[] results,
      Quaternion orientation,
      float maxDistance,
      int layerMask)
    {
      return Physics.BoxCastNonAlloc(center, halfExtents, direction, results, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int BoxCastNonAlloc(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      RaycastHit[] results)
    {
      return Physics.BoxCastNonAlloc(center, halfExtents, direction, results, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    [NativeName("BoxCastAll")]
    private static RaycastHit[] Internal_BoxCastAll(
      PhysicsScene physicsScene,
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      Quaternion orientation,
      float maxDistance,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.Internal_BoxCastAll_Injected(ref physicsScene, ref center, ref halfExtents, ref direction, ref orientation, maxDistance, layerMask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Like Physics.BoxCast, but returns all hits.</para>
    /// </summary>
    /// <param name="center">Center of the box.</param>
    /// <param name="halfExtents">Half the size of the box in each dimension.</param>
    /// <param name="direction">The direction in which to cast the box.</param>
    /// <param name="orientation">Rotation of the box.</param>
    /// <param name="maxDistance">The max length of the cast.</param>
    /// <param name="layermask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <param name="layerMask"></param>
    /// <returns>
    ///   <para>All colliders that were hit.</para>
    /// </returns>
    public static RaycastHit[] BoxCastAll(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      [DefaultValue("Quaternion.identity")] Quaternion orientation,
      [DefaultValue("Mathf.Infinity")] float maxDistance,
      [DefaultValue("DefaultRaycastLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      float magnitude = direction.magnitude;
      if ((double) magnitude <= 1.40129846432482E-45)
        return new RaycastHit[0];
      Vector3 direction1 = direction / magnitude;
      return Physics.Internal_BoxCastAll(Physics.defaultPhysicsScene, center, halfExtents, direction1, orientation, maxDistance, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] BoxCastAll(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      Quaternion orientation,
      float maxDistance,
      int layerMask)
    {
      return Physics.BoxCastAll(center, halfExtents, direction, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] BoxCastAll(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      Quaternion orientation,
      float maxDistance)
    {
      return Physics.BoxCastAll(center, halfExtents, direction, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] BoxCastAll(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction,
      Quaternion orientation)
    {
      return Physics.BoxCastAll(center, halfExtents, direction, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static RaycastHit[] BoxCastAll(
      Vector3 center,
      Vector3 halfExtents,
      Vector3 direction)
    {
      return Physics.BoxCastAll(center, halfExtents, direction, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    [NativeName("OverlapCapsuleNonAlloc")]
    [StaticAccessor("GetPhysicsManager().GetPhysicsQuery()")]
    private static int OverlapCapsuleNonAlloc_Internal(
      PhysicsScene physicsScene,
      Vector3 point0,
      Vector3 point1,
      float radius,
      Collider[] results,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapCapsuleNonAlloc_Internal_Injected(ref physicsScene, ref point0, ref point1, radius, results, layerMask, queryTriggerInteraction);
    }

    /// <summary>
    ///   <para>Check the given capsule against the physics world and return all overlapping colliders in the user-provided buffer.</para>
    /// </summary>
    /// <param name="point0">The center of the sphere at the start of the capsule.</param>
    /// <param name="point1">The center of the sphere at the end of the capsule.</param>
    /// <param name="radius">The radius of the capsule.</param>
    /// <param name="results">The buffer to store the results into.</param>
    /// <param name="layerMask">A that is used to selectively ignore colliders when casting a capsule.</param>
    /// <param name="queryTriggerInteraction">Specifies whether this query should hit Triggers.</param>
    /// <returns>
    ///   <para>The amount of entries written to the buffer.</para>
    /// </returns>
    public static int OverlapCapsuleNonAlloc(
      Vector3 point0,
      Vector3 point1,
      float radius,
      Collider[] results,
      [DefaultValue("AllLayers")] int layerMask,
      [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction)
    {
      return Physics.OverlapCapsuleNonAlloc_Internal(Physics.defaultPhysicsScene, point0, point1, radius, results, layerMask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static int OverlapCapsuleNonAlloc(
      Vector3 point0,
      Vector3 point1,
      float radius,
      Collider[] results,
      int layerMask)
    {
      return Physics.OverlapCapsuleNonAlloc(point0, point1, radius, results, layerMask, QueryTriggerInteraction.UseGlobal);
    }

    [ExcludeFromDocs]
    public static int OverlapCapsuleNonAlloc(
      Vector3 point0,
      Vector3 point1,
      float radius,
      Collider[] results)
    {
      return Physics.OverlapCapsuleNonAlloc(point0, point1, radius, results, -1, QueryTriggerInteraction.UseGlobal);
    }

    [StaticAccessor("GetPhysicsManager()")]
    [NativeName("RebuildBroadphaseRegions")]
    private static void Internal_RebuildBroadphaseRegions(Bounds bounds, int subdivisions)
    {
      Physics.Internal_RebuildBroadphaseRegions_Injected(ref bounds, subdivisions);
    }

    /// <summary>
    ///   <para>Rebuild the broadphase interest regions as well as set the world boundaries.</para>
    /// </summary>
    /// <param name="worldBounds">Boundaries of the physics world.</param>
    /// <param name="subdivisions">How many cells to create along x and z axis.</param>
    public static void RebuildBroadphaseRegions(Bounds worldBounds, int subdivisions)
    {
      if (subdivisions < 1 || subdivisions > 16)
        throw new ArgumentException("Physics.RebuildBroadphaseRegions requires the subdivisions to be greater than zero and less than 17.");
      if ((double) worldBounds.extents.x < 0.0 || (double) worldBounds.extents.y < 0.0 || (double) worldBounds.extents.z < 0.0)
        throw new ArgumentException("Physics.RebuildBroadphaseRegions requires the world bounds to be non-empty, and have positive extents.");
      Physics.Internal_RebuildBroadphaseRegions(worldBounds, subdivisions);
    }

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void get_gravity_Injected(out Vector3 ret);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void set_gravity_Injected(ref Vector3 value);

    [SpecialName]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void get_defaultPhysicsScene_Injected(out PhysicsScene ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool Query_CapsuleCast_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 point1,
      ref Vector3 point2,
      float radius,
      ref Vector3 direction,
      float maxDistance,
      ref RaycastHit hitInfo,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool Query_SphereCast_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 origin,
      float radius,
      ref Vector3 direction,
      float maxDistance,
      ref RaycastHit hitInfo,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool Query_BoxCast_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 center,
      ref Vector3 halfExtents,
      ref Vector3 direction,
      ref Quaternion orientation,
      float maxDistance,
      ref RaycastHit outHit,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern RaycastHit[] Internal_RaycastAll_Injected(
      ref PhysicsScene physicsScene,
      ref Ray ray,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern RaycastHit[] Query_CapsuleCastAll_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 p0,
      ref Vector3 p1,
      float radius,
      ref Vector3 direction,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern RaycastHit[] Query_SphereCastAll_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 origin,
      float radius,
      ref Vector3 direction,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Collider[] OverlapCapsule_Internal_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 point0,
      ref Vector3 point1,
      float radius,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Collider[] OverlapSphere_Internal_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 position,
      float radius,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Simulate_Internal_Injected(ref PhysicsScene physicsScene, float step);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool Query_ComputePenetration_Injected(
      Collider colliderA,
      ref Vector3 positionA,
      ref Quaternion rotationA,
      Collider colliderB,
      ref Vector3 positionB,
      ref Quaternion rotationB,
      ref Vector3 direction,
      ref float distance);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Query_ClosestPoint_Injected(
      Collider collider,
      ref Vector3 position,
      ref Quaternion rotation,
      ref Vector3 point,
      out Vector3 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int OverlapSphereNonAlloc_Internal_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 position,
      float radius,
      Collider[] results,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool CheckSphere_Internal_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 position,
      float radius,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Internal_CapsuleCastNonAlloc_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 p0,
      ref Vector3 p1,
      float radius,
      ref Vector3 direction,
      RaycastHit[] raycastHits,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Internal_SphereCastNonAlloc_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 origin,
      float radius,
      ref Vector3 direction,
      RaycastHit[] raycastHits,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool CheckCapsule_Internal_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 start,
      ref Vector3 end,
      float radius,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool CheckBox_Internal_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 center,
      ref Vector3 halfExtents,
      ref Quaternion orientation,
      int layermask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Collider[] OverlapBox_Internal_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 center,
      ref Vector3 halfExtents,
      ref Quaternion orientation,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int OverlapBoxNonAlloc_Internal_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 center,
      ref Vector3 halfExtents,
      Collider[] results,
      ref Quaternion orientation,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Internal_BoxCastNonAlloc_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 center,
      ref Vector3 halfExtents,
      ref Vector3 direction,
      RaycastHit[] raycastHits,
      ref Quaternion orientation,
      float maxDistance,
      int mask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern RaycastHit[] Internal_BoxCastAll_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 center,
      ref Vector3 halfExtents,
      ref Vector3 direction,
      ref Quaternion orientation,
      float maxDistance,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int OverlapCapsuleNonAlloc_Internal_Injected(
      ref PhysicsScene physicsScene,
      ref Vector3 point0,
      ref Vector3 point1,
      float radius,
      Collider[] results,
      int layerMask,
      QueryTriggerInteraction queryTriggerInteraction);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_RebuildBroadphaseRegions_Injected(
      ref Bounds bounds,
      int subdivisions);
  }
}
