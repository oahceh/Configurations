// Decompiled with JetBrains decompiler
// Type: UnityEngine.CustomYieldInstruction
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAF87D7C-AD7E-4FF1-9AEC-E2E17FC1223B
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System.Collections;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Base class for custom yield instructions to suspend coroutines.</para>
  /// </summary>
  public abstract class CustomYieldInstruction : IEnumerator
  {
    /// <summary>
    ///   <para>Indicates if coroutine should be kept suspended.</para>
    /// </summary>
    public abstract bool keepWaiting { get; }

    public object Current
    {
      get
      {
        return (object) null;
      }
    }

    public bool MoveNext()
    {
      return this.keepWaiting;
    }

    public void Reset()
    {
    }
  }
}
