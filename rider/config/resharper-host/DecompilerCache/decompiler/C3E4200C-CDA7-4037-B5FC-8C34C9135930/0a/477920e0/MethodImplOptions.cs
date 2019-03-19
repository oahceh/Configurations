// Decompiled with JetBrains decompiler
// Type: System.Runtime.CompilerServices.MethodImplOptions
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: C3E4200C-CDA7-4037-B5FC-8C34C9135930
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
  [Flags]
  [ComVisible(true)]
  [__DynamicallyInvokable]
  [Serializable]
  public enum MethodImplOptions
  {
    Unmanaged = 4,
    ForwardRef = 16, // 0x00000010
    [__DynamicallyInvokable] PreserveSig = 128, // 0x00000080
    InternalCall = 4096, // 0x00001000
    Synchronized = 32, // 0x00000020
    [__DynamicallyInvokable] NoInlining = 8,
    [ComVisible(false), __DynamicallyInvokable] AggressiveInlining = 256, // 0x00000100
    [__DynamicallyInvokable] NoOptimization = 64, // 0x00000040
  }
}
