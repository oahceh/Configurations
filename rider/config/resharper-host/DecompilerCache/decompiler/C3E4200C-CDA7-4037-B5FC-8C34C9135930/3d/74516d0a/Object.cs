// Decompiled with JetBrains decompiler
// Type: System.Object
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: C3E4200C-CDA7-4037-B5FC-8C34C9135930
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Versioning;
using System.Security;

namespace System
{
  [ClassInterface(ClassInterfaceType.AutoDual)]
  [ComVisible(true)]
  [__DynamicallyInvokable]
  [Serializable]
  public class Object
  {
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [NonVersionable]
    [__DynamicallyInvokable]
    public Object()
    {
    }

    [__DynamicallyInvokable]
    public virtual string ToString()
    {
      return this.GetType().ToString();
    }

    [__DynamicallyInvokable]
    public virtual bool Equals(object obj)
    {
      return RuntimeHelpers.Equals(this, obj);
    }

    [__DynamicallyInvokable]
    public static bool Equals(object objA, object objB)
    {
      if (objA == objB)
        return true;
      if (objA == null || objB == null)
        return false;
      return objA.Equals(objB);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [NonVersionable]
    [__DynamicallyInvokable]
    public static bool ReferenceEquals(object objA, object objB)
    {
      return objA == objB;
    }

    [__DynamicallyInvokable]
    public virtual int GetHashCode()
    {
      return RuntimeHelpers.GetHashCode(this);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Type GetType();

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [NonVersionable]
    [__DynamicallyInvokable]
    ~Object()
    {
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    protected extern object MemberwiseClone();

    [SecurityCritical]
    private void FieldSetter(string typeName, string fieldName, object val)
    {
      FieldInfo fieldInfo = this.GetFieldInfo(typeName, fieldName);
      if (fieldInfo.IsInitOnly)
        throw new FieldAccessException(Environment.GetResourceString("FieldAccess_InitOnly"));
      Message.CoerceArg(val, fieldInfo.FieldType);
      fieldInfo.SetValue(this, val);
    }

    private void FieldGetter(string typeName, string fieldName, ref object val)
    {
      FieldInfo fieldInfo = this.GetFieldInfo(typeName, fieldName);
      val = fieldInfo.GetValue(this);
    }

    private FieldInfo GetFieldInfo(string typeName, string fieldName)
    {
      Type type = this.GetType();
      while ((Type) null != type && !type.FullName.Equals(typeName))
        type = type.BaseType;
      if ((Type) null == type)
        throw new RemotingException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_BadType"), (object) typeName));
      FieldInfo field = type.GetField(fieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
      if ((FieldInfo) null == field)
        throw new RemotingException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_BadField"), (object) fieldName, (object) typeName));
      return field;
    }
  }
}
