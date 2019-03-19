// Decompiled with JetBrains decompiler
// Type: UnityEngine.MonoBehaviour
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAF87D7C-AD7E-4FF1-9AEC-E2E17FC1223B
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>MonoBehaviour is the base class from which every Unity script derives.</para>
  /// </summary>
  [RequiredByNativeCode]
  public class MonoBehaviour : Behaviour
  {
    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern MonoBehaviour();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void Internal_CancelInvokeAll();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool Internal_IsInvokingAll();

    /// <summary>
    ///   <para>Invokes the method methodName in time seconds.</para>
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="time"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Invoke(string methodName, float time);

    /// <summary>
    ///   <para>Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.</para>
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="time"></param>
    /// <param name="repeatRate"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void InvokeRepeating(string methodName, float time, float repeatRate);

    /// <summary>
    ///   <para>Cancels all Invoke calls on this MonoBehaviour.</para>
    /// </summary>
    public void CancelInvoke()
    {
      this.Internal_CancelInvokeAll();
    }

    /// <summary>
    ///   <para>Cancels all Invoke calls with name methodName on this behaviour.</para>
    /// </summary>
    /// <param name="methodName"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void CancelInvoke(string methodName);

    /// <summary>
    ///   <para>Is any invoke on methodName pending?</para>
    /// </summary>
    /// <param name="methodName"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool IsInvoking(string methodName);

    /// <summary>
    ///   <para>Is any invoke pending on this MonoBehaviour?</para>
    /// </summary>
    public bool IsInvoking()
    {
      return this.Internal_IsInvokingAll();
    }

    /// <summary>
    ///   <para>Starts a coroutine.</para>
    /// </summary>
    /// <param name="routine"></param>
    public Coroutine StartCoroutine(IEnumerator routine)
    {
      return this.StartCoroutine_Auto_Internal(routine);
    }

    [Obsolete("StartCoroutine_Auto has been deprecated. Use StartCoroutine instead (UnityUpgradable) -> StartCoroutine([mscorlib] System.Collections.IEnumerator)", false)]
    public Coroutine StartCoroutine_Auto(IEnumerator routine)
    {
      return this.StartCoroutine(routine);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern Coroutine StartCoroutine_Auto_Internal(IEnumerator routine);

    /// <summary>
    ///   <para>Starts a coroutine named methodName.</para>
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="value"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value);

    /// <summary>
    ///   <para>Starts a coroutine named methodName.</para>
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="value"></param>
    [ExcludeFromDocs]
    public Coroutine StartCoroutine(string methodName)
    {
      object obj = (object) null;
      return this.StartCoroutine(methodName, obj);
    }

    /// <summary>
    ///   <para>Stops the first coroutine named methodName, or the coroutine stored in routine running on this behaviour.</para>
    /// </summary>
    /// <param name="methodName">Name of coroutine.</param>
    /// <param name="routine">Name of the function in code, including coroutines.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void StopCoroutine(string methodName);

    /// <summary>
    ///   <para>Stops the first coroutine named methodName, or the coroutine stored in routine running on this behaviour.</para>
    /// </summary>
    /// <param name="methodName">Name of coroutine.</param>
    /// <param name="routine">Name of the function in code, including coroutines.</param>
    public void StopCoroutine(IEnumerator routine)
    {
      this.StopCoroutineViaEnumerator_Auto(routine);
    }

    /// <summary>
    ///   <para>Stops the first coroutine named methodName, or the coroutine stored in routine running on this behaviour.</para>
    /// </summary>
    /// <param name="methodName">Name of coroutine.</param>
    /// <param name="routine">Name of the function in code, including coroutines.</param>
    public void StopCoroutine(Coroutine routine)
    {
      this.StopCoroutine_Auto(routine);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void StopCoroutineViaEnumerator_Auto(IEnumerator routine);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void StopCoroutine_Auto(Coroutine routine);

    /// <summary>
    ///   <para>Stops all coroutines running on this behaviour.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void StopAllCoroutines();

    /// <summary>
    ///   <para>Logs message to the Unity Console (identical to Debug.Log).</para>
    /// </summary>
    /// <param name="message"></param>
    public static void print(object message)
    {
      Debug.Log(message);
    }

    /// <summary>
    ///   <para>Disabling this lets you skip the GUI layout phase.</para>
    /// </summary>
    public extern bool useGUILayout { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Allow a specific instance of a MonoBehaviour to run in edit mode (only available in the editor).</para>
    /// </summary>
    public extern bool runInEditMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern string GetScriptClassName();
  }
}
