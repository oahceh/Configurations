// Decompiled with JetBrains decompiler
// Type: UnityEngine.Coroutine
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
  ///   <para>MonoBehaviour.StartCoroutine returns a Coroutine. Instances of this class are only used to reference these coroutines and do not hold any exposed properties or functions.</para>
  /// </summary>
  [RequiredByNativeCode]
  [StructLayout(LayoutKind.Sequential)]
  public sealed class Coroutine : YieldInstruction
  {
    internal IntPtr m_Ptr;

    private Coroutine()
    {
    }

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void ReleaseCoroutine();

    ~Coroutine()
    {
      this.ReleaseCoroutine();
    }
  }
}
