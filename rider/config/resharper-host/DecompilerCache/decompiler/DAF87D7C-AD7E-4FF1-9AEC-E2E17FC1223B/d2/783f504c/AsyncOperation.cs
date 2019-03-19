// Decompiled with JetBrains decompiler
// Type: UnityEngine.AsyncOperation
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
  ///   <para>Asynchronous operation coroutine.</para>
  /// </summary>
  [RequiredByNativeCode]
  [StructLayout(LayoutKind.Sequential)]
  public class AsyncOperation : YieldInstruction
  {
    internal IntPtr m_Ptr;
    private Action<AsyncOperation> m_completeCallback;

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void InternalDestroy();

    ~AsyncOperation()
    {
      this.InternalDestroy();
    }

    /// <summary>
    ///   <para>Has the operation finished? (Read Only)</para>
    /// </summary>
    public extern bool isDone { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>What's the operation's progress. (Read Only)</para>
    /// </summary>
    public extern float progress { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Priority lets you tweak in which order async operation calls will be performed.</para>
    /// </summary>
    public extern int priority { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Allow scenes to be activated as soon as it is ready.</para>
    /// </summary>
    public extern bool allowSceneActivation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [RequiredByNativeCode]
    internal void InvokeCompletionEvent()
    {
      if (this.m_completeCallback == null)
        return;
      this.m_completeCallback(this);
      this.m_completeCallback = (Action<AsyncOperation>) null;
    }

    public event Action<AsyncOperation> completed
    {
      add
      {
        if (this.isDone)
          value(this);
        else
          this.m_completeCallback += value;
      }
      remove
      {
        this.m_completeCallback -= value;
      }
    }
  }
}
