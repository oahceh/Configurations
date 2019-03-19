// Decompiled with JetBrains decompiler
// Type: UnityEngine.Events.UnityEvent`1
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAF87D7C-AD7E-4FF1-9AEC-E2E17FC1223B
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Scripting;
using UnityEngineInternal;

namespace UnityEngine.Events
{
  /// <summary>
  ///   <para>One argument version of UnityEvent.</para>
  /// </summary>
  [Serializable]
  public abstract class UnityEvent<T0> : UnityEventBase
  {
    private object[] m_InvokeArray = (object[]) null;

    [RequiredByNativeCode]
    public UnityEvent()
    {
    }

    public void AddListener(UnityAction<T0> call)
    {
      this.AddCall(UnityEvent<T0>.GetDelegate(call));
    }

    public void RemoveListener(UnityAction<T0> call)
    {
      this.RemoveListener(call.Target, call.GetMethodInfo());
    }

    protected override MethodInfo FindMethod_Impl(string name, object targetObj)
    {
      return UnityEventBase.GetValidMethodInfo(targetObj, name, new System.Type[1]
      {
        typeof (T0)
      });
    }

    internal override BaseInvokableCall GetDelegate(object target, MethodInfo theFunction)
    {
      return (BaseInvokableCall) new InvokableCall<T0>(target, theFunction);
    }

    private static BaseInvokableCall GetDelegate(UnityAction<T0> action)
    {
      return (BaseInvokableCall) new InvokableCall<T0>(action);
    }

    public void Invoke(T0 arg0)
    {
      List<BaseInvokableCall> baseInvokableCallList = this.PrepareInvoke();
      for (int index = 0; index < baseInvokableCallList.Count; ++index)
      {
        InvokableCall<T0> invokableCall1 = baseInvokableCallList[index] as InvokableCall<T0>;
        if (invokableCall1 != null)
        {
          invokableCall1.Invoke(arg0);
        }
        else
        {
          InvokableCall invokableCall2 = baseInvokableCallList[index] as InvokableCall;
          if (invokableCall2 != null)
          {
            invokableCall2.Invoke();
          }
          else
          {
            BaseInvokableCall baseInvokableCall = baseInvokableCallList[index];
            if (this.m_InvokeArray == null)
              this.m_InvokeArray = new object[1];
            this.m_InvokeArray[0] = (object) arg0;
            baseInvokableCall.Invoke(this.m_InvokeArray);
          }
        }
      }
    }

    internal void AddPersistentListener(UnityAction<T0> call)
    {
      this.AddPersistentListener(call, UnityEventCallState.RuntimeOnly);
    }

    internal void AddPersistentListener(UnityAction<T0> call, UnityEventCallState callState)
    {
      int persistentEventCount = this.GetPersistentEventCount();
      this.AddPersistentListener();
      this.RegisterPersistentListener(persistentEventCount, call);
      this.SetPersistentListenerState(persistentEventCount, callState);
    }

    internal void RegisterPersistentListener(int index, UnityAction<T0> call)
    {
      if (call == null)
        Debug.LogWarning((object) "Registering a Listener requires an action");
      else
        this.RegisterPersistentListener(index, (object) (call.Target as UnityEngine.Object), call.Method);
    }
  }
}
