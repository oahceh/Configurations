// Decompiled with JetBrains decompiler
// Type: UnityEngine.Behaviour
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAF87D7C-AD7E-4FF1-9AEC-E2E17FC1223B
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Behaviours are Components that can be enabled or disabled.</para>
  /// </summary>
  [UsedByNativeCode]
  public class Behaviour : Component
  {
    /// <summary>
    ///   <para>Enabled Behaviours are Updated, disabled Behaviours are not.</para>
    /// </summary>
    public extern bool enabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Has the Behaviour had enabled called.</para>
    /// </summary>
    public extern bool isActiveAndEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }
  }
}
