// Decompiled with JetBrains decompiler
// Type: UnityEngine.AnimationCurve
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAF87D7C-AD7E-4FF1-9AEC-E2E17FC1223B
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Store a collection of Keyframes that can be evaluated over time.</para>
  /// </summary>
  [RequiredByNativeCode]
  [StructLayout(LayoutKind.Sequential)]
  public sealed class AnimationCurve
  {
    internal IntPtr m_Ptr;

    /// <summary>
    ///   <para>Creates an animation curve from an arbitrary number of keyframes.</para>
    /// </summary>
    /// <param name="keys">An array of Keyframes used to define the curve.</param>
    public AnimationCurve(params Keyframe[] keys)
    {
      this.Init(keys);
    }

    /// <summary>
    ///   <para>Creates an empty animation curve.</para>
    /// </summary>
    [RequiredByNativeCode]
    public AnimationCurve()
    {
      this.Init((Keyframe[]) null);
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void Cleanup();

    ~AnimationCurve()
    {
      this.Cleanup();
    }

    /// <summary>
    ///   <para>Evaluate the curve at time.</para>
    /// </summary>
    /// <param name="time">The time within the curve you want to evaluate (the horizontal axis in the curve graph).</param>
    /// <returns>
    ///   <para>The value of the curve, at the point in time specified.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern float Evaluate(float time);

    /// <summary>
    ///   <para>All keys defined in the animation curve.</para>
    /// </summary>
    public Keyframe[] keys
    {
      get
      {
        return this.GetKeys();
      }
      set
      {
        this.SetKeys(value);
      }
    }

    /// <summary>
    ///   <para>Add a new key to the curve.</para>
    /// </summary>
    /// <param name="time">The time at which to add the key (horizontal axis in the curve graph).</param>
    /// <param name="value">The value for the key (vertical axis in the curve graph).</param>
    /// <returns>
    ///   <para>The index of the added key, or -1 if the key could not be added.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int AddKey(float time, float value);

    /// <summary>
    ///   <para>Add a new key to the curve.</para>
    /// </summary>
    /// <param name="key">The key to add to the curve.</param>
    /// <returns>
    ///   <para>The index of the added key, or -1 if the key could not be added.</para>
    /// </returns>
    public int AddKey(Keyframe key)
    {
      return this.AddKey_Internal(key);
    }

    private int AddKey_Internal(Keyframe key)
    {
      return AnimationCurve.INTERNAL_CALL_AddKey_Internal(this, ref key);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int INTERNAL_CALL_AddKey_Internal(AnimationCurve self, ref Keyframe key);

    /// <summary>
    ///   <para>Removes the keyframe at index and inserts key.</para>
    /// </summary>
    /// <param name="index">The index of the key to move.</param>
    /// <param name="key">The key (with its new time) to insert.</param>
    /// <returns>
    ///   <para>The index of the keyframe after moving it.</para>
    /// </returns>
    public int MoveKey(int index, Keyframe key)
    {
      return AnimationCurve.INTERNAL_CALL_MoveKey(this, index, ref key);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int INTERNAL_CALL_MoveKey(AnimationCurve self, int index, ref Keyframe key);

    /// <summary>
    ///   <para>Removes a key.</para>
    /// </summary>
    /// <param name="index">The index of the key to remove.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void RemoveKey(int index);

    public Keyframe this[int index]
    {
      get
      {
        return this.GetKey_Internal(index);
      }
    }

    /// <summary>
    ///   <para>The number of keys in the curve. (Read Only)</para>
    /// </summary>
    public extern int length { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetKeys(Keyframe[] keys);

    private Keyframe GetKey_Internal(int index)
    {
      Keyframe keyframe;
      AnimationCurve.INTERNAL_CALL_GetKey_Internal(this, index, out keyframe);
      return keyframe;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_GetKey_Internal(AnimationCurve self, int index, out Keyframe value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern Keyframe[] GetKeys();

    /// <summary>
    ///   <para>Smooth the in and out tangents of the keyframe at index.</para>
    /// </summary>
    /// <param name="index">The index of the keyframe to be smoothed.</param>
    /// <param name="weight">The smoothing weight to apply to the keyframe's tangents.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SmoothTangents(int index, float weight);

    /// <summary>
    ///   <para>Creates a constant "curve" starting at timeStart, ending at timeEnd and with the value value.</para>
    /// </summary>
    /// <param name="timeStart">The start time for the constant curve.</param>
    /// <param name="timeEnd">The start time for the constant curve.</param>
    /// <param name="value">The value for the constant curve.</param>
    /// <returns>
    ///   <para>The constant curve created from the specified values.</para>
    /// </returns>
    public static AnimationCurve Constant(float timeStart, float timeEnd, float value)
    {
      return AnimationCurve.Linear(timeStart, value, timeEnd, value);
    }

    /// <summary>
    ///   <para>A straight Line starting at timeStart, valueStart and ending at timeEnd, valueEnd.</para>
    /// </summary>
    /// <param name="timeStart">The start time for the linear curve.</param>
    /// <param name="valueStart">The start value for the linear curve.</param>
    /// <param name="timeEnd">The end time for the linear curve.</param>
    /// <param name="valueEnd">The end value for the linear curve.</param>
    /// <returns>
    ///   <para>The linear curve created from the specified values.</para>
    /// </returns>
    public static AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd)
    {
      float num = (float) (((double) valueEnd - (double) valueStart) / ((double) timeEnd - (double) timeStart));
      return new AnimationCurve(new Keyframe[2]
      {
        new Keyframe(timeStart, valueStart, 0.0f, num),
        new Keyframe(timeEnd, valueEnd, num, 0.0f)
      });
    }

    /// <summary>
    ///   <para>Creates an ease-in and out curve starting at timeStart, valueStart and ending at timeEnd, valueEnd.</para>
    /// </summary>
    /// <param name="timeStart">The start time for the ease curve.</param>
    /// <param name="valueStart">The start value for the ease curve.</param>
    /// <param name="timeEnd">The end time for the ease curve.</param>
    /// <param name="valueEnd">The end value for the ease curve.</param>
    /// <returns>
    ///   <para>The ease-in and out curve generated from the specified values.</para>
    /// </returns>
    public static AnimationCurve EaseInOut(float timeStart, float valueStart, float timeEnd, float valueEnd)
    {
      return new AnimationCurve(new Keyframe[2]
      {
        new Keyframe(timeStart, valueStart, 0.0f, 0.0f),
        new Keyframe(timeEnd, valueEnd, 0.0f, 0.0f)
      });
    }

    /// <summary>
    ///   <para>The behaviour of the animation before the first keyframe.</para>
    /// </summary>
    public extern WrapMode preWrapMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The behaviour of the animation after the last keyframe.</para>
    /// </summary>
    public extern WrapMode postWrapMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void Init(Keyframe[] keys);
  }
}
