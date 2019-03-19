// Decompiled with JetBrains decompiler
// Type: UnityEngine.Animator
// Assembly: UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 414D86F4-4390-4E53-9FEC-5A745F333083
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.AnimationModule.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;
using UnityEngine.Playables;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Interface to control the Mecanim animation system.</para>
  /// </summary>
  [UsedByNativeCode]
  public sealed class Animator : Behaviour
  {
    /// <summary>
    ///   <para>Returns true if the current rig is optimizable with AnimatorUtility.OptimizeTransformHierarchy.</para>
    /// </summary>
    public extern bool isOptimizable { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns true if the current rig is humanoid, false if it is generic.</para>
    /// </summary>
    public extern bool isHuman { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns true if the current rig has root motion.</para>
    /// </summary>
    public extern bool hasRootMotion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal extern bool isRootPositionOrRotationControlledByCurves { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns the scale of the current Avatar for a humanoid rig, (1 by default if the rig is generic).</para>
    /// </summary>
    public extern float humanScale { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns whether the animator is initialized successfully.</para>
    /// </summary>
    public extern bool isInitialized { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns the value of the given float parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    /// <returns>
    ///   <para>The value of the parameter.</para>
    /// </returns>
    public float GetFloat(string name)
    {
      return this.GetFloatString(name);
    }

    /// <summary>
    ///   <para>Returns the value of the given float parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    /// <returns>
    ///   <para>The value of the parameter.</para>
    /// </returns>
    public float GetFloat(int id)
    {
      return this.GetFloatID(id);
    }

    /// <summary>
    ///   <para>Send float values to the Animator to affect transitions.</para>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="dampTime"></param>
    /// <param name="deltaTime"></param>
    /// <param name="id"></param>
    public void SetFloat(string name, float value)
    {
      this.SetFloatString(name, value);
    }

    /// <summary>
    ///   <para>Send float values to the Animator to affect transitions.</para>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="dampTime"></param>
    /// <param name="deltaTime"></param>
    /// <param name="id"></param>
    public void SetFloat(string name, float value, float dampTime, float deltaTime)
    {
      this.SetFloatStringDamp(name, value, dampTime, deltaTime);
    }

    /// <summary>
    ///   <para>Send float values to the Animator to affect transitions.</para>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="dampTime"></param>
    /// <param name="deltaTime"></param>
    /// <param name="id"></param>
    public void SetFloat(int id, float value)
    {
      this.SetFloatID(id, value);
    }

    /// <summary>
    ///   <para>Send float values to the Animator to affect transitions.</para>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="dampTime"></param>
    /// <param name="deltaTime"></param>
    /// <param name="id"></param>
    public void SetFloat(int id, float value, float dampTime, float deltaTime)
    {
      this.SetFloatIDDamp(id, value, dampTime, deltaTime);
    }

    /// <summary>
    ///   <para>Returns the value of the given boolean parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    /// <returns>
    ///   <para>The value of the parameter.</para>
    /// </returns>
    public bool GetBool(string name)
    {
      return this.GetBoolString(name);
    }

    /// <summary>
    ///   <para>Returns the value of the given boolean parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    /// <returns>
    ///   <para>The value of the parameter.</para>
    /// </returns>
    public bool GetBool(int id)
    {
      return this.GetBoolID(id);
    }

    /// <summary>
    ///   <para>Sets an Animator bool parameter.</para>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="id"></param>
    public void SetBool(string name, bool value)
    {
      this.SetBoolString(name, value);
    }

    /// <summary>
    ///   <para>Sets an Animator bool parameter.</para>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="id"></param>
    public void SetBool(int id, bool value)
    {
      this.SetBoolID(id, value);
    }

    /// <summary>
    ///   <para>Returns the value of the given integer parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    /// <returns>
    ///   <para>The value of the parameter.</para>
    /// </returns>
    public int GetInteger(string name)
    {
      return this.GetIntegerString(name);
    }

    /// <summary>
    ///   <para>Returns the value of the given integer parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    /// <returns>
    ///   <para>The value of the parameter.</para>
    /// </returns>
    public int GetInteger(int id)
    {
      return this.GetIntegerID(id);
    }

    /// <summary>
    ///   <para>Sets the value of the given integer parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    /// <param name="value">The new parameter value.</param>
    public void SetInteger(string name, int value)
    {
      this.SetIntegerString(name, value);
    }

    /// <summary>
    ///   <para>Sets the value of the given integer parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    /// <param name="value">The new parameter value.</param>
    public void SetInteger(int id, int value)
    {
      this.SetIntegerID(id, value);
    }

    /// <summary>
    ///   <para>Sets the value of the given trigger parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    public void SetTrigger(string name)
    {
      this.SetTriggerString(name);
    }

    /// <summary>
    ///   <para>Sets the value of the given trigger parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    public void SetTrigger(int id)
    {
      this.SetTriggerID(id);
    }

    /// <summary>
    ///   <para>Resets the value of the given trigger parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    public void ResetTrigger(string name)
    {
      this.ResetTriggerString(name);
    }

    /// <summary>
    ///   <para>Resets the value of the given trigger parameter.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    public void ResetTrigger(int id)
    {
      this.ResetTriggerID(id);
    }

    /// <summary>
    ///   <para>Returns true if the parameter is controlled by a curve, false otherwise.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    /// <returns>
    ///   <para>True if the parameter is controlled by a curve, false otherwise.</para>
    /// </returns>
    public bool IsParameterControlledByCurve(string name)
    {
      return this.IsParameterControlledByCurveString(name);
    }

    /// <summary>
    ///   <para>Returns true if the parameter is controlled by a curve, false otherwise.</para>
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="id">The parameter ID.</param>
    /// <returns>
    ///   <para>True if the parameter is controlled by a curve, false otherwise.</para>
    /// </returns>
    public bool IsParameterControlledByCurve(int id)
    {
      return this.IsParameterControlledByCurveID(id);
    }

    /// <summary>
    ///   <para>Gets the avatar delta position for the last evaluated frame.</para>
    /// </summary>
    public Vector3 deltaPosition
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_deltaPosition(out vector3);
        return vector3;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_deltaPosition(out Vector3 value);

    /// <summary>
    ///   <para>Gets the avatar delta rotation for the last evaluated frame.</para>
    /// </summary>
    public Quaternion deltaRotation
    {
      get
      {
        Quaternion quaternion;
        this.INTERNAL_get_deltaRotation(out quaternion);
        return quaternion;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_deltaRotation(out Quaternion value);

    /// <summary>
    ///   <para>Gets the avatar velocity  for the last evaluated frame.</para>
    /// </summary>
    public Vector3 velocity
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_velocity(out vector3);
        return vector3;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_velocity(out Vector3 value);

    /// <summary>
    ///   <para>Gets the avatar angular velocity for the last evaluated frame.</para>
    /// </summary>
    public Vector3 angularVelocity
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_angularVelocity(out vector3);
        return vector3;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_angularVelocity(out Vector3 value);

    /// <summary>
    ///   <para>The root position, the position of the game object.</para>
    /// </summary>
    public Vector3 rootPosition
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_rootPosition(out vector3);
        return vector3;
      }
      set
      {
        this.INTERNAL_set_rootPosition(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_rootPosition(out Vector3 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_rootPosition(ref Vector3 value);

    /// <summary>
    ///   <para>The root rotation, the rotation of the game object.</para>
    /// </summary>
    public Quaternion rootRotation
    {
      get
      {
        Quaternion quaternion;
        this.INTERNAL_get_rootRotation(out quaternion);
        return quaternion;
      }
      set
      {
        this.INTERNAL_set_rootRotation(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_rootRotation(out Quaternion value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_rootRotation(ref Quaternion value);

    /// <summary>
    ///   <para>Should root motion be applied?</para>
    /// </summary>
    public extern bool applyRootMotion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>When linearVelocityBlending is set to true, the root motion velocity and angular velocity will be blended linearly.</para>
    /// </summary>
    public extern bool linearVelocityBlending { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>When turned on, animations will be executed in the physics loop. This is only useful in conjunction with kinematic rigidbodies.</para>
    /// </summary>
    [Obsolete("Use Animator.updateMode instead")]
    public bool animatePhysics
    {
      get
      {
        return this.updateMode == AnimatorUpdateMode.AnimatePhysics;
      }
      set
      {
        this.updateMode = !value ? AnimatorUpdateMode.Normal : AnimatorUpdateMode.AnimatePhysics;
      }
    }

    /// <summary>
    ///   <para>Specifies the update mode of the Animator.</para>
    /// </summary>
    public extern AnimatorUpdateMode updateMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns true if the object has a transform hierarchy.</para>
    /// </summary>
    public extern bool hasTransformHierarchy { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal extern bool allowConstantClipSamplingOptimization { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The current gravity weight based on current animations that are played.</para>
    /// </summary>
    public extern float gravityWeight { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The position of the body center of mass.</para>
    /// </summary>
    public Vector3 bodyPosition
    {
      get
      {
        this.CheckIfInIKPass();
        return this.GetBodyPositionInternal();
      }
      set
      {
        this.CheckIfInIKPass();
        this.SetBodyPositionInternal(value);
      }
    }

    internal Vector3 GetBodyPositionInternal()
    {
      Vector3 vector3;
      Animator.INTERNAL_CALL_GetBodyPositionInternal(this, out vector3);
      return vector3;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_GetBodyPositionInternal(Animator self, out Vector3 value);

    internal void SetBodyPositionInternal(Vector3 bodyPosition)
    {
      Animator.INTERNAL_CALL_SetBodyPositionInternal(this, ref bodyPosition);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetBodyPositionInternal(Animator self, ref Vector3 bodyPosition);

    /// <summary>
    ///   <para>The rotation of the body center of mass.</para>
    /// </summary>
    public Quaternion bodyRotation
    {
      get
      {
        this.CheckIfInIKPass();
        return this.GetBodyRotationInternal();
      }
      set
      {
        this.CheckIfInIKPass();
        this.SetBodyRotationInternal(value);
      }
    }

    internal Quaternion GetBodyRotationInternal()
    {
      Quaternion quaternion;
      Animator.INTERNAL_CALL_GetBodyRotationInternal(this, out quaternion);
      return quaternion;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_GetBodyRotationInternal(Animator self, out Quaternion value);

    internal void SetBodyRotationInternal(Quaternion bodyRotation)
    {
      Animator.INTERNAL_CALL_SetBodyRotationInternal(this, ref bodyRotation);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetBodyRotationInternal(Animator self, ref Quaternion bodyRotation);

    /// <summary>
    ///   <para>Gets the position of an IK goal.</para>
    /// </summary>
    /// <param name="goal">The AvatarIKGoal that is queried.</param>
    /// <returns>
    ///   <para>Return the current position of this IK goal in world space.</para>
    /// </returns>
    public Vector3 GetIKPosition(AvatarIKGoal goal)
    {
      this.CheckIfInIKPass();
      return this.GetIKPositionInternal(goal);
    }

    internal Vector3 GetIKPositionInternal(AvatarIKGoal goal)
    {
      Vector3 vector3;
      Animator.INTERNAL_CALL_GetIKPositionInternal(this, goal, out vector3);
      return vector3;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_GetIKPositionInternal(Animator self, AvatarIKGoal goal, out Vector3 value);

    /// <summary>
    ///   <para>Sets the position of an IK goal.</para>
    /// </summary>
    /// <param name="goal">The AvatarIKGoal that is set.</param>
    /// <param name="goalPosition">The position in world space.</param>
    public void SetIKPosition(AvatarIKGoal goal, Vector3 goalPosition)
    {
      this.CheckIfInIKPass();
      this.SetIKPositionInternal(goal, goalPosition);
    }

    internal void SetIKPositionInternal(AvatarIKGoal goal, Vector3 goalPosition)
    {
      Animator.INTERNAL_CALL_SetIKPositionInternal(this, goal, ref goalPosition);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetIKPositionInternal(Animator self, AvatarIKGoal goal, ref Vector3 goalPosition);

    /// <summary>
    ///   <para>Gets the rotation of an IK goal.</para>
    /// </summary>
    /// <param name="goal">The AvatarIKGoal that is is queried.</param>
    public Quaternion GetIKRotation(AvatarIKGoal goal)
    {
      this.CheckIfInIKPass();
      return this.GetIKRotationInternal(goal);
    }

    internal Quaternion GetIKRotationInternal(AvatarIKGoal goal)
    {
      Quaternion quaternion;
      Animator.INTERNAL_CALL_GetIKRotationInternal(this, goal, out quaternion);
      return quaternion;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_GetIKRotationInternal(Animator self, AvatarIKGoal goal, out Quaternion value);

    /// <summary>
    ///   <para>Sets the rotation of an IK goal.</para>
    /// </summary>
    /// <param name="goal">The AvatarIKGoal that is set.</param>
    /// <param name="goalRotation">The rotation in world space.</param>
    public void SetIKRotation(AvatarIKGoal goal, Quaternion goalRotation)
    {
      this.CheckIfInIKPass();
      this.SetIKRotationInternal(goal, goalRotation);
    }

    internal void SetIKRotationInternal(AvatarIKGoal goal, Quaternion goalRotation)
    {
      Animator.INTERNAL_CALL_SetIKRotationInternal(this, goal, ref goalRotation);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetIKRotationInternal(Animator self, AvatarIKGoal goal, ref Quaternion goalRotation);

    /// <summary>
    ///   <para>Gets the translative weight of an IK goal (0 = at the original animation before IK, 1 = at the goal).</para>
    /// </summary>
    /// <param name="goal">The AvatarIKGoal that is queried.</param>
    public float GetIKPositionWeight(AvatarIKGoal goal)
    {
      this.CheckIfInIKPass();
      return this.GetIKPositionWeightInternal(goal);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern float GetIKPositionWeightInternal(AvatarIKGoal goal);

    /// <summary>
    ///   <para>Sets the translative weight of an IK goal (0 = at the original animation before IK, 1 = at the goal).</para>
    /// </summary>
    /// <param name="goal">The AvatarIKGoal that is set.</param>
    /// <param name="value">The translative weight.</param>
    public void SetIKPositionWeight(AvatarIKGoal goal, float value)
    {
      this.CheckIfInIKPass();
      this.SetIKPositionWeightInternal(goal, value);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void SetIKPositionWeightInternal(AvatarIKGoal goal, float value);

    /// <summary>
    ///   <para>Gets the rotational weight of an IK goal (0 = rotation before IK, 1 = rotation at the IK goal).</para>
    /// </summary>
    /// <param name="goal">The AvatarIKGoal that is queried.</param>
    public float GetIKRotationWeight(AvatarIKGoal goal)
    {
      this.CheckIfInIKPass();
      return this.GetIKRotationWeightInternal(goal);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern float GetIKRotationWeightInternal(AvatarIKGoal goal);

    /// <summary>
    ///   <para>Sets the rotational weight of an IK goal (0 = rotation before IK, 1 = rotation at the IK goal).</para>
    /// </summary>
    /// <param name="goal">The AvatarIKGoal that is set.</param>
    /// <param name="value">The rotational weight.</param>
    public void SetIKRotationWeight(AvatarIKGoal goal, float value)
    {
      this.CheckIfInIKPass();
      this.SetIKRotationWeightInternal(goal, value);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void SetIKRotationWeightInternal(AvatarIKGoal goal, float value);

    /// <summary>
    ///   <para>Gets the position of an IK hint.</para>
    /// </summary>
    /// <param name="hint">The AvatarIKHint that is queried.</param>
    /// <returns>
    ///   <para>Return the current position of this IK hint in world space.</para>
    /// </returns>
    public Vector3 GetIKHintPosition(AvatarIKHint hint)
    {
      this.CheckIfInIKPass();
      return this.GetIKHintPositionInternal(hint);
    }

    internal Vector3 GetIKHintPositionInternal(AvatarIKHint hint)
    {
      Vector3 vector3;
      Animator.INTERNAL_CALL_GetIKHintPositionInternal(this, hint, out vector3);
      return vector3;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_GetIKHintPositionInternal(Animator self, AvatarIKHint hint, out Vector3 value);

    /// <summary>
    ///   <para>Sets the position of an IK hint.</para>
    /// </summary>
    /// <param name="hint">The AvatarIKHint that is set.</param>
    /// <param name="hintPosition">The position in world space.</param>
    public void SetIKHintPosition(AvatarIKHint hint, Vector3 hintPosition)
    {
      this.CheckIfInIKPass();
      this.SetIKHintPositionInternal(hint, hintPosition);
    }

    internal void SetIKHintPositionInternal(AvatarIKHint hint, Vector3 hintPosition)
    {
      Animator.INTERNAL_CALL_SetIKHintPositionInternal(this, hint, ref hintPosition);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetIKHintPositionInternal(Animator self, AvatarIKHint hint, ref Vector3 hintPosition);

    /// <summary>
    ///   <para>Gets the translative weight of an IK Hint (0 = at the original animation before IK, 1 = at the hint).</para>
    /// </summary>
    /// <param name="hint">The AvatarIKHint that is queried.</param>
    /// <returns>
    ///   <para>Return translative weight.</para>
    /// </returns>
    public float GetIKHintPositionWeight(AvatarIKHint hint)
    {
      this.CheckIfInIKPass();
      return this.GetHintWeightPositionInternal(hint);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern float GetHintWeightPositionInternal(AvatarIKHint hint);

    /// <summary>
    ///   <para>Sets the translative weight of an IK hint (0 = at the original animation before IK, 1 = at the hint).</para>
    /// </summary>
    /// <param name="hint">The AvatarIKHint that is set.</param>
    /// <param name="value">The translative weight.</param>
    public void SetIKHintPositionWeight(AvatarIKHint hint, float value)
    {
      this.CheckIfInIKPass();
      this.SetIKHintPositionWeightInternal(hint, value);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void SetIKHintPositionWeightInternal(AvatarIKHint hint, float value);

    /// <summary>
    ///   <para>Sets the look at position.</para>
    /// </summary>
    /// <param name="lookAtPosition">The position to lookAt.</param>
    public void SetLookAtPosition(Vector3 lookAtPosition)
    {
      this.CheckIfInIKPass();
      this.SetLookAtPositionInternal(lookAtPosition);
    }

    internal void SetLookAtPositionInternal(Vector3 lookAtPosition)
    {
      Animator.INTERNAL_CALL_SetLookAtPositionInternal(this, ref lookAtPosition);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetLookAtPositionInternal(Animator self, ref Vector3 lookAtPosition);

    /// <summary>
    ///   <para>Set look at weights.</para>
    /// </summary>
    /// <param name="weight">(0-1) the global weight of the LookAt, multiplier for other parameters.</param>
    /// <param name="bodyWeight">(0-1) determines how much the body is involved in the LookAt.</param>
    /// <param name="headWeight">(0-1) determines how much the head is involved in the LookAt.</param>
    /// <param name="eyesWeight">(0-1) determines how much the eyes are involved in the LookAt.</param>
    /// <param name="clampWeight">(0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees).</param>
    [ExcludeFromDocs]
    public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight)
    {
      float clampWeight = 0.5f;
      this.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
    }

    /// <summary>
    ///   <para>Set look at weights.</para>
    /// </summary>
    /// <param name="weight">(0-1) the global weight of the LookAt, multiplier for other parameters.</param>
    /// <param name="bodyWeight">(0-1) determines how much the body is involved in the LookAt.</param>
    /// <param name="headWeight">(0-1) determines how much the head is involved in the LookAt.</param>
    /// <param name="eyesWeight">(0-1) determines how much the eyes are involved in the LookAt.</param>
    /// <param name="clampWeight">(0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees).</param>
    [ExcludeFromDocs]
    public void SetLookAtWeight(float weight, float bodyWeight, float headWeight)
    {
      float clampWeight = 0.5f;
      float eyesWeight = 0.0f;
      this.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
    }

    /// <summary>
    ///   <para>Set look at weights.</para>
    /// </summary>
    /// <param name="weight">(0-1) the global weight of the LookAt, multiplier for other parameters.</param>
    /// <param name="bodyWeight">(0-1) determines how much the body is involved in the LookAt.</param>
    /// <param name="headWeight">(0-1) determines how much the head is involved in the LookAt.</param>
    /// <param name="eyesWeight">(0-1) determines how much the eyes are involved in the LookAt.</param>
    /// <param name="clampWeight">(0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees).</param>
    [ExcludeFromDocs]
    public void SetLookAtWeight(float weight, float bodyWeight)
    {
      float clampWeight = 0.5f;
      float eyesWeight = 0.0f;
      float headWeight = 1f;
      this.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
    }

    /// <summary>
    ///   <para>Set look at weights.</para>
    /// </summary>
    /// <param name="weight">(0-1) the global weight of the LookAt, multiplier for other parameters.</param>
    /// <param name="bodyWeight">(0-1) determines how much the body is involved in the LookAt.</param>
    /// <param name="headWeight">(0-1) determines how much the head is involved in the LookAt.</param>
    /// <param name="eyesWeight">(0-1) determines how much the eyes are involved in the LookAt.</param>
    /// <param name="clampWeight">(0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees).</param>
    [ExcludeFromDocs]
    public void SetLookAtWeight(float weight)
    {
      float clampWeight = 0.5f;
      float eyesWeight = 0.0f;
      float headWeight = 1f;
      float bodyWeight = 0.0f;
      this.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
    }

    /// <summary>
    ///   <para>Set look at weights.</para>
    /// </summary>
    /// <param name="weight">(0-1) the global weight of the LookAt, multiplier for other parameters.</param>
    /// <param name="bodyWeight">(0-1) determines how much the body is involved in the LookAt.</param>
    /// <param name="headWeight">(0-1) determines how much the head is involved in the LookAt.</param>
    /// <param name="eyesWeight">(0-1) determines how much the eyes are involved in the LookAt.</param>
    /// <param name="clampWeight">(0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees).</param>
    public void SetLookAtWeight(float weight, [DefaultValue("0.00f")] float bodyWeight, [DefaultValue("1.00f")] float headWeight, [DefaultValue("0.00f")] float eyesWeight, [DefaultValue("0.50f")] float clampWeight)
    {
      this.CheckIfInIKPass();
      this.SetLookAtWeightInternal(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void SetLookAtWeightInternal(float weight, [DefaultValue("0.00f")] float bodyWeight, [DefaultValue("1.00f")] float headWeight, [DefaultValue("0.00f")] float eyesWeight, [DefaultValue("0.50f")] float clampWeight);

    [ExcludeFromDocs]
    internal void SetLookAtWeightInternal(float weight, float bodyWeight, float headWeight, float eyesWeight)
    {
      float clampWeight = 0.5f;
      this.SetLookAtWeightInternal(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
    }

    [ExcludeFromDocs]
    internal void SetLookAtWeightInternal(float weight, float bodyWeight, float headWeight)
    {
      float clampWeight = 0.5f;
      float eyesWeight = 0.0f;
      this.SetLookAtWeightInternal(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
    }

    [ExcludeFromDocs]
    internal void SetLookAtWeightInternal(float weight, float bodyWeight)
    {
      float clampWeight = 0.5f;
      float eyesWeight = 0.0f;
      float headWeight = 1f;
      this.SetLookAtWeightInternal(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
    }

    [ExcludeFromDocs]
    internal void SetLookAtWeightInternal(float weight)
    {
      float clampWeight = 0.5f;
      float eyesWeight = 0.0f;
      float headWeight = 1f;
      float bodyWeight = 0.0f;
      this.SetLookAtWeightInternal(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
    }

    /// <summary>
    ///   <para>Sets local rotation of a human bone during a IK pass.</para>
    /// </summary>
    /// <param name="humanBoneId">The human bone Id.</param>
    /// <param name="rotation">The local rotation.</param>
    public void SetBoneLocalRotation(HumanBodyBones humanBoneId, Quaternion rotation)
    {
      this.CheckIfInIKPass();
      this.SetBoneLocalRotationInternal((int) humanBoneId, rotation);
    }

    internal void SetBoneLocalRotationInternal(int humanBoneId, Quaternion rotation)
    {
      Animator.INTERNAL_CALL_SetBoneLocalRotationInternal(this, humanBoneId, ref rotation);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetBoneLocalRotationInternal(Animator self, int humanBoneId, ref Quaternion rotation);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern ScriptableObject GetBehaviour(System.Type type);

    public T GetBehaviour<T>() where T : StateMachineBehaviour
    {
      return this.GetBehaviour(typeof (T)) as T;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern ScriptableObject[] InternalGetBehaviours(System.Type type);

    internal static T[] ConvertStateMachineBehaviour<T>(ScriptableObject[] rawObjects) where T : StateMachineBehaviour
    {
      if (rawObjects == null)
        return (T[]) null;
      T[] objArray = new T[rawObjects.Length];
      for (int index = 0; index < objArray.Length; ++index)
        objArray[index] = (T) rawObjects[index];
      return objArray;
    }

    public T[] GetBehaviours<T>() where T : StateMachineBehaviour
    {
      return Animator.ConvertStateMachineBehaviour<T>(this.InternalGetBehaviours(typeof (T)));
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern StateMachineBehaviour[] InternalGetBehavioursByKey(int fullPathHash, int layerIndex, System.Type type);

    public StateMachineBehaviour[] GetBehaviours(int fullPathHash, int layerIndex)
    {
      return this.InternalGetBehavioursByKey(fullPathHash, layerIndex, typeof (StateMachineBehaviour));
    }

    /// <summary>
    ///   <para>Automatic stabilization of feet during transition and blending.</para>
    /// </summary>
    public extern bool stabilizeFeet { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns the number of layers in the controller.</para>
    /// </summary>
    public extern int layerCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns the layer name.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <returns>
    ///   <para>The layer name.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern string GetLayerName(int layerIndex);

    /// <summary>
    ///   <para>Returns the index of the layer with the given name.</para>
    /// </summary>
    /// <param name="layerName">The layer name.</param>
    /// <returns>
    ///   <para>The layer index.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetLayerIndex(string layerName);

    /// <summary>
    ///   <para>Returns the weight of the layer at the specified index.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <returns>
    ///   <para>The layer weight.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern float GetLayerWeight(int layerIndex);

    /// <summary>
    ///   <para>Sets the weight of the layer at the given index.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <param name="weight">The new layer weight.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetLayerWeight(int layerIndex, float weight);

    /// <summary>
    ///   <para>Returns an AnimatorStateInfo with the information on the current state.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <returns>
    ///   <para>An AnimatorStateInfo with the information on the current state.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex);

    /// <summary>
    ///   <para>Returns an AnimatorStateInfo with the information on the next state.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <returns>
    ///   <para>An AnimatorStateInfo with the information on the next state.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex);

    /// <summary>
    ///   <para>Returns an AnimatorTransitionInfo with the informations on the current transition.</para>
    /// </summary>
    /// <param name="layerIndex">The layer's index.</param>
    /// <returns>
    ///   <para>An AnimatorTransitionInfo with the informations on the current transition.</para>
    /// </returns>
    public AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex)
    {
      AnimatorTransitionInfo info;
      this.GetAnimatorTransitionInfo(layerIndex, out info);
      return info;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetAnimatorTransitionInfo(int layerIndex, out AnimatorTransitionInfo info);

    /// <summary>
    ///   <para>Returns the number of AnimatorClipInfo in the current state.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <returns>
    ///   <para>The number of AnimatorClipInfo in the current state.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetCurrentAnimatorClipInfoCount(int layerIndex);

    /// <summary>
    ///   <para>Returns an array of all the AnimatorClipInfo in the current state of the given layer.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <returns>
    ///   <para>An array of all the AnimatorClipInfo in the current state.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern AnimatorClipInfo[] GetCurrentAnimatorClipInfo(int layerIndex);

    public void GetCurrentAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
    {
      if (clips == null)
        throw new ArgumentNullException(nameof (clips));
      this.GetAnimatorClipInfoInternal(layerIndex, true, (object) clips);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetAnimatorClipInfoInternal(int layerIndex, bool isCurrent, object clips);

    /// <summary>
    ///   <para>Returns the number of AnimatorClipInfo in the next state.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <returns>
    ///   <para>The number of AnimatorClipInfo in the next state.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetNextAnimatorClipInfoCount(int layerIndex);

    /// <summary>
    ///   <para>Returns an array of all the AnimatorClipInfo in the next state of the given layer.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <returns>
    ///   <para>An array of all the AnimatorClipInfo in the next state.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern AnimatorClipInfo[] GetNextAnimatorClipInfo(int layerIndex);

    public void GetNextAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
    {
      if (clips == null)
        throw new ArgumentNullException(nameof (clips));
      this.GetAnimatorClipInfoInternal(layerIndex, false, (object) clips);
    }

    /// <summary>
    ///   <para>Returns true if there is a transition on the given layer, false otherwise.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <returns>
    ///   <para>True if there is a transition on the given layer, false otherwise.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool IsInTransition(int layerIndex);

    /// <summary>
    ///   <para>Read only acces to the AnimatorControllerParameters used by the animator.</para>
    /// </summary>
    public extern AnimatorControllerParameter[] parameters { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns the number of parameters in the controller.</para>
    /// </summary>
    public extern int parameterCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>See AnimatorController.parameters.</para>
    /// </summary>
    /// <param name="index"></param>
    public AnimatorControllerParameter GetParameter(int index)
    {
      AnimatorControllerParameter[] parameters = this.parameters;
      if (index < 0 && index >= this.parameters.Length)
        throw new IndexOutOfRangeException("Index must be between 0 and " + (object) this.parameters.Length);
      return parameters[index];
    }

    /// <summary>
    ///   <para>Blends pivot point between body center of mass and feet pivot. At 0%, the blending point is body center of mass. At 100%, the blending point is feet pivot.</para>
    /// </summary>
    public extern float feetPivotActive { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Gets the pivot weight.</para>
    /// </summary>
    public extern float pivotWeight { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Get the current position of the pivot.</para>
    /// </summary>
    public Vector3 pivotPosition
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_pivotPosition(out vector3);
        return vector3;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_pivotPosition(out Vector3 value);

    /// <summary>
    ///   <para>Automatically adjust the gameobject position and rotation so that the AvatarTarget reaches the matchPosition when the current state is at the specified progress.</para>
    /// </summary>
    /// <param name="matchPosition">The position we want the body part to reach.</param>
    /// <param name="matchRotation">The rotation in which we want the body part to be.</param>
    /// <param name="targetBodyPart">The body part that is involved in the match.</param>
    /// <param name="weightMask">Structure that contains weights for matching position and rotation.</param>
    /// <param name="startNormalizedTime">Start time within the animation clip (0 - beginning of clip, 1 - end of clip).</param>
    /// <param name="targetNormalizedTime">End time within the animation clip (0 - beginning of clip, 1 - end of clip), values greater than 1 can be set to trigger a match after a certain number of loops. Ex: 2.3 means at 30% of 2nd loop.</param>
    public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, [DefaultValue("1")] float targetNormalizedTime)
    {
      Animator.INTERNAL_CALL_MatchTarget(this, ref matchPosition, ref matchRotation, targetBodyPart, ref weightMask, startNormalizedTime, targetNormalizedTime);
    }

    [ExcludeFromDocs]
    public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime)
    {
      float targetNormalizedTime = 1f;
      Animator.INTERNAL_CALL_MatchTarget(this, ref matchPosition, ref matchRotation, targetBodyPart, ref weightMask, startNormalizedTime, targetNormalizedTime);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_MatchTarget(Animator self, ref Vector3 matchPosition, ref Quaternion matchRotation, AvatarTarget targetBodyPart, ref MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime);

    /// <summary>
    ///   <para>Interrupts the automatic target matching.</para>
    /// </summary>
    /// <param name="completeMatch"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void InterruptMatchTarget([DefaultValue("true")] bool completeMatch);

    [ExcludeFromDocs]
    public void InterruptMatchTarget()
    {
      this.InterruptMatchTarget(true);
    }

    /// <summary>
    ///   <para>If automatic matching is active.</para>
    /// </summary>
    public extern bool isMatchingTarget { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The playback speed of the Animator. 1 is normal playback speed.</para>
    /// </summary>
    public extern float speed { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("ForceStateNormalizedTime is deprecated. Please use Play or CrossFade instead.")]
    public void ForceStateNormalizedTime(float normalizedTime)
    {
      this.Play(0, 0, normalizedTime);
    }

    [ExcludeFromDocs]
    public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset)
    {
      float normalizedTransitionTime = 0.0f;
      this.CrossFadeInFixedTime(stateName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
    }

    [ExcludeFromDocs]
    public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer)
    {
      float normalizedTransitionTime = 0.0f;
      float fixedTimeOffset = 0.0f;
      this.CrossFadeInFixedTime(stateName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
    }

    [ExcludeFromDocs]
    public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration)
    {
      float normalizedTransitionTime = 0.0f;
      float fixedTimeOffset = 0.0f;
      int layer = -1;
      this.CrossFadeInFixedTime(stateName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
    }

    /// <summary>
    ///   <para>Creates a crossfade from the current state to any other state using times in seconds.</para>
    /// </summary>
    /// <param name="stateName">The name of the state.</param>
    /// <param name="stateHashName">The hash name of the state.</param>
    /// <param name="fixedTransitionDuration">The duration of the transition (in seconds).</param>
    /// <param name="layer">The layer where the crossfade occurs.</param>
    /// <param name="fixedTimeOffset">The time of the state (in seconds).</param>
    /// <param name="normalizedTransitionTime">The time of the transition (normalized).</param>
    public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, [DefaultValue("-1")] int layer, [DefaultValue("0.0f")] float fixedTimeOffset, [DefaultValue("0.0f")] float normalizedTransitionTime)
    {
      this.CrossFadeInFixedTime(Animator.StringToHash(stateName), fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
    }

    /// <summary>
    ///   <para>Creates a crossfade from the current state to any other state using times in seconds.</para>
    /// </summary>
    /// <param name="stateName">The name of the state.</param>
    /// <param name="stateHashName">The hash name of the state.</param>
    /// <param name="fixedTransitionDuration">The duration of the transition (in seconds).</param>
    /// <param name="layer">The layer where the crossfade occurs.</param>
    /// <param name="fixedTimeOffset">The time of the state (in seconds).</param>
    /// <param name="normalizedTransitionTime">The time of the transition (normalized).</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, [DefaultValue("-1")] int layer, [DefaultValue("0.0f")] float fixedTimeOffset, [DefaultValue("0.0f")] float normalizedTransitionTime);

    [ExcludeFromDocs]
    public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer, float fixedTimeOffset)
    {
      float normalizedTransitionTime = 0.0f;
      this.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
    }

    [ExcludeFromDocs]
    public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer)
    {
      float normalizedTransitionTime = 0.0f;
      float fixedTimeOffset = 0.0f;
      this.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
    }

    [ExcludeFromDocs]
    public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration)
    {
      float normalizedTransitionTime = 0.0f;
      float fixedTimeOffset = 0.0f;
      int layer = -1;
      this.CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
    }

    [ExcludeFromDocs]
    public void CrossFade(string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset)
    {
      float normalizedTransitionTime = 0.0f;
      this.CrossFade(stateName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
    }

    [ExcludeFromDocs]
    public void CrossFade(string stateName, float normalizedTransitionDuration, int layer)
    {
      float normalizedTransitionTime = 0.0f;
      float normalizedTimeOffset = float.NegativeInfinity;
      this.CrossFade(stateName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
    }

    [ExcludeFromDocs]
    public void CrossFade(string stateName, float normalizedTransitionDuration)
    {
      float normalizedTransitionTime = 0.0f;
      float normalizedTimeOffset = float.NegativeInfinity;
      int layer = -1;
      this.CrossFade(stateName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
    }

    /// <summary>
    ///   <para>Creates a crossfade from the current state to any other state using normalized times.</para>
    /// </summary>
    /// <param name="stateName">The name of the state.</param>
    /// <param name="stateHashName">The hash name of the state.</param>
    /// <param name="normalizedTransitionDuration">The duration of the transition (normalized).</param>
    /// <param name="layer">The layer where the crossfade occurs.</param>
    /// <param name="normalizedTimeOffset">The time of the state (normalized).</param>
    /// <param name="normalizedTransitionTime">The time of the transition (normalized).</param>
    public void CrossFade(string stateName, float normalizedTransitionDuration, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float normalizedTimeOffset, [DefaultValue("0.0f")] float normalizedTransitionTime)
    {
      this.CrossFade(Animator.StringToHash(stateName), normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
    }

    /// <summary>
    ///   <para>Creates a crossfade from the current state to any other state using normalized times.</para>
    /// </summary>
    /// <param name="stateName">The name of the state.</param>
    /// <param name="stateHashName">The hash name of the state.</param>
    /// <param name="normalizedTransitionDuration">The duration of the transition (normalized).</param>
    /// <param name="layer">The layer where the crossfade occurs.</param>
    /// <param name="normalizedTimeOffset">The time of the state (normalized).</param>
    /// <param name="normalizedTransitionTime">The time of the transition (normalized).</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void CrossFade(int stateHashName, float normalizedTransitionDuration, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float normalizedTimeOffset, [DefaultValue("0.0f")] float normalizedTransitionTime);

    [ExcludeFromDocs]
    public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset)
    {
      float normalizedTransitionTime = 0.0f;
      this.CrossFade(stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
    }

    [ExcludeFromDocs]
    public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer)
    {
      float normalizedTransitionTime = 0.0f;
      float normalizedTimeOffset = float.NegativeInfinity;
      this.CrossFade(stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
    }

    [ExcludeFromDocs]
    public void CrossFade(int stateHashName, float normalizedTransitionDuration)
    {
      float normalizedTransitionTime = 0.0f;
      float normalizedTimeOffset = float.NegativeInfinity;
      int layer = -1;
      this.CrossFade(stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
    }

    [ExcludeFromDocs]
    public void PlayInFixedTime(string stateName, int layer)
    {
      float fixedTime = float.NegativeInfinity;
      this.PlayInFixedTime(stateName, layer, fixedTime);
    }

    [ExcludeFromDocs]
    public void PlayInFixedTime(string stateName)
    {
      float fixedTime = float.NegativeInfinity;
      int layer = -1;
      this.PlayInFixedTime(stateName, layer, fixedTime);
    }

    /// <summary>
    ///   <para>Plays a state.</para>
    /// </summary>
    /// <param name="stateName">The state name.</param>
    /// <param name="stateNameHash">The state hash name. If statNameHash is 0, it changes the current state time.</param>
    /// <param name="layer">The layer index. If layer is -1, it plays the first state with the given state name or hash.</param>
    /// <param name="fixedTime">The time offset (in seconds).</param>
    public void PlayInFixedTime(string stateName, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float fixedTime)
    {
      this.PlayInFixedTime(Animator.StringToHash(stateName), layer, fixedTime);
    }

    /// <summary>
    ///   <para>Plays a state.</para>
    /// </summary>
    /// <param name="stateName">The state name.</param>
    /// <param name="stateNameHash">The state hash name. If statNameHash is 0, it changes the current state time.</param>
    /// <param name="layer">The layer index. If layer is -1, it plays the first state with the given state name or hash.</param>
    /// <param name="fixedTime">The time offset (in seconds).</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void PlayInFixedTime(int stateNameHash, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float fixedTime);

    [ExcludeFromDocs]
    public void PlayInFixedTime(int stateNameHash, int layer)
    {
      float fixedTime = float.NegativeInfinity;
      this.PlayInFixedTime(stateNameHash, layer, fixedTime);
    }

    [ExcludeFromDocs]
    public void PlayInFixedTime(int stateNameHash)
    {
      float fixedTime = float.NegativeInfinity;
      int layer = -1;
      this.PlayInFixedTime(stateNameHash, layer, fixedTime);
    }

    [ExcludeFromDocs]
    public void Play(string stateName, int layer)
    {
      float normalizedTime = float.NegativeInfinity;
      this.Play(stateName, layer, normalizedTime);
    }

    [ExcludeFromDocs]
    public void Play(string stateName)
    {
      float normalizedTime = float.NegativeInfinity;
      int layer = -1;
      this.Play(stateName, layer, normalizedTime);
    }

    /// <summary>
    ///   <para>Plays a state.</para>
    /// </summary>
    /// <param name="stateName">The state name.</param>
    /// <param name="stateNameHash">The state hash name. If statNameHash is 0, it changes the current state time.</param>
    /// <param name="layer">The layer index. If layer is -1, it plays the first state with the given state name or hash.</param>
    /// <param name="normalizedTime">The time offset (in percentage).</param>
    public void Play(string stateName, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float normalizedTime)
    {
      this.Play(Animator.StringToHash(stateName), layer, normalizedTime);
    }

    /// <summary>
    ///   <para>Plays a state.</para>
    /// </summary>
    /// <param name="stateName">The state name.</param>
    /// <param name="stateNameHash">The state hash name. If statNameHash is 0, it changes the current state time.</param>
    /// <param name="layer">The layer index. If layer is -1, it plays the first state with the given state name or hash.</param>
    /// <param name="normalizedTime">The time offset (in percentage).</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Play(int stateNameHash, [DefaultValue("-1")] int layer, [DefaultValue("float.NegativeInfinity")] float normalizedTime);

    [ExcludeFromDocs]
    public void Play(int stateNameHash, int layer)
    {
      float normalizedTime = float.NegativeInfinity;
      this.Play(stateNameHash, layer, normalizedTime);
    }

    [ExcludeFromDocs]
    public void Play(int stateNameHash)
    {
      float normalizedTime = float.NegativeInfinity;
      int layer = -1;
      this.Play(stateNameHash, layer, normalizedTime);
    }

    /// <summary>
    ///   <para>Sets an AvatarTarget and a targetNormalizedTime for the current state.</para>
    /// </summary>
    /// <param name="targetIndex">The avatar body part that is queried.</param>
    /// <param name="targetNormalizedTime">The current state Time that is queried.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetTarget(AvatarTarget targetIndex, float targetNormalizedTime);

    /// <summary>
    ///   <para>Returns the position of the target specified by SetTarget(AvatarTarget targetIndex, float targetNormalizedTime)).</para>
    /// </summary>
    public Vector3 targetPosition
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_targetPosition(out vector3);
        return vector3;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_targetPosition(out Vector3 value);

    /// <summary>
    ///   <para>Returns the rotation of the target specified by SetTarget(AvatarTarget targetIndex, float targetNormalizedTime)).</para>
    /// </summary>
    public Quaternion targetRotation
    {
      get
      {
        Quaternion quaternion;
        this.INTERNAL_get_targetRotation(out quaternion);
        return quaternion;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_targetRotation(out Quaternion value);

    /// <summary>
    ///   <para>Returns true if the transform is controlled by the Animator\.</para>
    /// </summary>
    /// <param name="transform">The transform that is queried.</param>
    [Obsolete("use mask and layers to control subset of transfroms in a skeleton", true)]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool IsControlled(Transform transform);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern bool IsBoneTransform(Transform transform);

    internal extern Transform avatarRoot { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns transform mapped to this human bone id.</para>
    /// </summary>
    /// <param name="humanBoneId">The human bone that is queried, see enum HumanBodyBones for a list of possible values.</param>
    public Transform GetBoneTransform(HumanBodyBones humanBoneId)
    {
      return this.GetBoneTransformInternal((int) humanBoneId);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern Transform GetBoneTransformInternal(int humanBoneId);

    /// <summary>
    ///   <para>Controls culling of this Animator component.</para>
    /// </summary>
    public extern AnimatorCullingMode cullingMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets the animator in playback mode.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void StartPlayback();

    /// <summary>
    ///   <para>Stops the animator playback mode. When playback stops, the avatar resumes getting control from game logic.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void StopPlayback();

    /// <summary>
    ///   <para>Sets the playback position in the recording buffer.</para>
    /// </summary>
    public extern float playbackTime { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets the animator in recording mode, and allocates a circular buffer of size frameCount.</para>
    /// </summary>
    /// <param name="frameCount">The number of frames (updates) that will be recorded. If frameCount is 0, the recording will continue until the user calls StopRecording. The maximum value for frameCount is 10000.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void StartRecording(int frameCount);

    /// <summary>
    ///   <para>Stops animator record mode.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void StopRecording();

    /// <summary>
    ///   <para>Start time of the first frame of the buffer relative to the frame at which StartRecording was called.</para>
    /// </summary>
    public extern float recorderStartTime { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>End time of the recorded clip relative to when StartRecording was called.</para>
    /// </summary>
    public extern float recorderStopTime { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Gets the mode of the Animator recorder.</para>
    /// </summary>
    public extern AnimatorRecorderMode recorderMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The runtime representation of AnimatorController that controls the Animator.</para>
    /// </summary>
    public extern RuntimeAnimatorController runtimeAnimatorController { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns true if Animator has any playables assigned to it.</para>
    /// </summary>
    public extern bool hasBoundPlayables { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void ClearInternalControllerPlayable();

    /// <summary>
    ///   <para>Returns true if the state exists in this layer, false otherwise.</para>
    /// </summary>
    /// <param name="layerIndex">The layer index.</param>
    /// <param name="stateID">The state ID.</param>
    /// <returns>
    ///   <para>True if the state exists in this layer, false otherwise.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool HasState(int layerIndex, int stateID);

    /// <summary>
    ///   <para>Generates an parameter id from a string.</para>
    /// </summary>
    /// <param name="name">The string to convert to Id.</param>
    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int StringToHash(string name);

    /// <summary>
    ///   <para>Gets/Sets the current Avatar.</para>
    /// </summary>
    public extern Avatar avatar { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern string GetStats();

    /// <summary>
    ///   <para>The PlayableGraph created by the Animator.</para>
    /// </summary>
    public PlayableGraph playableGraph
    {
      get
      {
        PlayableGraph graph = new PlayableGraph();
        this.InternalGetCurrentGraph(ref graph);
        return graph;
      }
    }

    private void InternalGetCurrentGraph(ref PlayableGraph graph)
    {
      Animator.INTERNAL_CALL_InternalGetCurrentGraph(this, ref graph);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_InternalGetCurrentGraph(Animator self, ref PlayableGraph graph);

    private void CheckIfInIKPass()
    {
      if (!this.logWarnings || this.CheckIfInIKPassInternal())
        return;
      Debug.LogWarning((object) "Setting and getting Body Position/Rotation, IK Goals, Lookat and BoneLocalRotation should only be done in OnAnimatorIK or OnStateIK");
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool CheckIfInIKPassInternal();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetFloatString(string name, float value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetFloatID(int id, float value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern float GetFloatString(string name);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern float GetFloatID(int id);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetBoolString(string name, bool value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetBoolID(int id, bool value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool GetBoolString(string name);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool GetBoolID(int id);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetIntegerString(string name, int value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetIntegerID(int id, int value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern int GetIntegerString(string name);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern int GetIntegerID(int id);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetTriggerString(string name);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetTriggerID(int id);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void ResetTriggerString(string name);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void ResetTriggerID(int id);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool IsParameterControlledByCurveString(string name);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool IsParameterControlledByCurveID(int id);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetFloatStringDamp(string name, float value, float dampTime, float deltaTime);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetFloatIDDamp(int id, float value, float dampTime, float deltaTime);

    /// <summary>
    ///   <para>Additional layers affects the center of mass.</para>
    /// </summary>
    public extern bool layersAffectMassCenter { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Get left foot bottom height.</para>
    /// </summary>
    public extern float leftFeetBottomHeight { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Get right foot bottom height.</para>
    /// </summary>
    public extern float rightFeetBottomHeight { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal extern bool supportsOnAnimatorMove { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void OnUpdateModeChanged();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void OnCullingModeChanged();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void WriteDefaultPose();

    /// <summary>
    ///   <para>Evaluates the animator based on deltaTime.</para>
    /// </summary>
    /// <param name="deltaTime">The time delta.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Update(float deltaTime);

    /// <summary>
    ///   <para>Rebind all the animated properties and mesh data with the Animator.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Rebind();

    /// <summary>
    ///   <para>Apply the default Root Motion.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void ApplyBuiltinRootMotion();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void EvaluateController();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern string GetCurrentStateName(int layerIndex);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern string GetNextStateName(int layerIndex);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern string ResolveHash(int hash);

    public extern bool logWarnings { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    public extern bool fireEvents { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Gets the value of a vector parameter.</para>
    /// </summary>
    /// <param name="name">The name of the parameter.</param>
    [Obsolete("GetVector is deprecated.")]
    public Vector3 GetVector(string name)
    {
      return Vector3.zero;
    }

    /// <summary>
    ///   <para>Gets the value of a vector parameter.</para>
    /// </summary>
    /// <param name="id">The id of the parameter. The id is generated using Animator::StringToHash.</param>
    [Obsolete("GetVector is deprecated.")]
    public Vector3 GetVector(int id)
    {
      return Vector3.zero;
    }

    /// <summary>
    ///   <para>Sets the value of a vector parameter.</para>
    /// </summary>
    /// <param name="name">The name of the parameter.</param>
    /// <param name="value">The new value for the parameter.</param>
    [Obsolete("SetVector is deprecated.")]
    public void SetVector(string name, Vector3 value)
    {
    }

    /// <summary>
    ///   <para>Sets the value of a vector parameter.</para>
    /// </summary>
    /// <param name="id">The id of the parameter. The id is generated using Animator::StringToHash.</param>
    /// <param name="value">The new value for the parameter.</param>
    [Obsolete("SetVector is deprecated.")]
    public void SetVector(int id, Vector3 value)
    {
    }

    /// <summary>
    ///   <para>Gets the value of a quaternion parameter.</para>
    /// </summary>
    /// <param name="name">The name of the parameter.</param>
    [Obsolete("GetQuaternion is deprecated.")]
    public Quaternion GetQuaternion(string name)
    {
      return Quaternion.identity;
    }

    /// <summary>
    ///   <para>Gets the value of a quaternion parameter.</para>
    /// </summary>
    /// <param name="id">The id of the parameter. The id is generated using Animator::StringToHash.</param>
    [Obsolete("GetQuaternion is deprecated.")]
    public Quaternion GetQuaternion(int id)
    {
      return Quaternion.identity;
    }

    /// <summary>
    ///   <para>Sets the value of a quaternion parameter.</para>
    /// </summary>
    /// <param name="name">The name of the parameter.</param>
    /// <param name="value">The new value for the parameter.</param>
    [Obsolete("SetQuaternion is deprecated.")]
    public void SetQuaternion(string name, Quaternion value)
    {
    }

    /// <summary>
    ///   <para>Sets the value of a quaternion parameter.</para>
    /// </summary>
    /// <param name="id">Of the parameter. The id is generated using Animator::StringToHash.</param>
    /// <param name="value">The new value for the parameter.</param>
    [Obsolete("SetQuaternion is deprecated.")]
    public void SetQuaternion(int id, Quaternion value)
    {
    }

    /// <summary>
    ///   <para>Gets the list of AnimatorClipInfo currently played by the current state.</para>
    /// </summary>
    /// <param name="layerIndex">The layer's index.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("GetCurrentAnimationClipState is obsolete. Use GetCurrentAnimatorClipInfo instead (UnityUpgradable) -> GetCurrentAnimatorClipInfo(*)", true)]
    public AnimationInfo[] GetCurrentAnimationClipState(int layerIndex)
    {
      return (AnimationInfo[]) null;
    }

    /// <summary>
    ///   <para>Gets the list of AnimatorClipInfo currently played by the next state.</para>
    /// </summary>
    /// <param name="layerIndex">The layer's index.</param>
    [Obsolete("GetNextAnimationClipState is obsolete. Use GetNextAnimatorClipInfo instead (UnityUpgradable) -> GetNextAnimatorClipInfo(*)", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationInfo[] GetNextAnimationClipState(int layerIndex)
    {
      return (AnimationInfo[]) null;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Stop is obsolete. Use Animator.enabled = false instead", true)]
    public void Stop()
    {
    }
  }
}
