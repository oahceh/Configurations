// Decompiled with JetBrains decompiler
// Type: UnityEngine.Networking.UnityWebRequestAsyncOperation
// Assembly: UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 288406E7-240C-49F3-859B-DBA713BA828A
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.UnityWebRequestModule.dll

using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Networking
{
  /// <summary>
  ///         <para>Asynchronous operation object returned from UnityWebRequest.SendWebRequest().
  /// 
  /// You can yield until it continues, register an event handler with AsyncOperation.completed, or manually check whether it's done (AsyncOperation.isDone) or progress (AsyncOperation.progress).</para>
  ///       </summary>
  [UsedByNativeCode]
  [NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequestAsyncOperation.h")]
  [NativeHeader("UnityWebRequestScriptingClasses.h")]
  [StructLayout(LayoutKind.Sequential)]
  public class UnityWebRequestAsyncOperation : AsyncOperation
  {
    /// <summary>
    ///   <para>Returns the associated UnityWebRequest that created the operation.</para>
    /// </summary>
    public UnityWebRequest webRequest { get; internal set; }
  }
}
