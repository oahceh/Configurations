// Decompiled with JetBrains decompiler
// Type: UnityEngine.Object
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAF87D7C-AD7E-4FF1-9AEC-E2E17FC1223B
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using UnityEngineInternal;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Base class for all objects Unity can reference.</para>
  /// </summary>
  [RequiredByNativeCode]
  [StructLayout(LayoutKind.Sequential)]
  public class Object
  {
    internal static int OffsetOfInstanceIDInCPlusPlusObject = -1;
    private IntPtr m_CachedPtr;
    private int m_InstanceID;
    private string m_UnityRuntimeErrorString;

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Object Internal_CloneSingle(Object data);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Object Internal_CloneSingleWithParent(Object data, Transform parent, bool worldPositionStays);

    private static Object Internal_InstantiateSingle(Object data, Vector3 pos, Quaternion rot)
    {
      return Object.INTERNAL_CALL_Internal_InstantiateSingle(data, ref pos, ref rot);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Object INTERNAL_CALL_Internal_InstantiateSingle(Object data, ref Vector3 pos, ref Quaternion rot);

    private static Object Internal_InstantiateSingleWithParent(Object data, Transform parent, Vector3 pos, Quaternion rot)
    {
      return Object.INTERNAL_CALL_Internal_InstantiateSingleWithParent(data, parent, ref pos, ref rot);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Object INTERNAL_CALL_Internal_InstantiateSingleWithParent(Object data, Transform parent, ref Vector3 pos, ref Quaternion rot);

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int GetOffsetOfInstanceIDInCPlusPlusObject();

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void EnsureRunningOnMainThread();

    /// <summary>
    ///   <para>Removes a gameobject, component or asset.</para>
    /// </summary>
    /// <param name="obj">The object to destroy.</param>
    /// <param name="t">The optional amount of time to delay before destroying the object.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Destroy(Object obj, [DefaultValue("0.0F")] float t);

    /// <summary>
    ///   <para>Removes a gameobject, component or asset.</para>
    /// </summary>
    /// <param name="obj">The object to destroy.</param>
    /// <param name="t">The optional amount of time to delay before destroying the object.</param>
    [ExcludeFromDocs]
    public static void Destroy(Object obj)
    {
      float t = 0.0f;
      Object.Destroy(obj, t);
    }

    /// <summary>
    ///   <para>Destroys the object obj immediately. You are strongly recommended to use Destroy instead.</para>
    /// </summary>
    /// <param name="obj">Object to be destroyed.</param>
    /// <param name="allowDestroyingAssets">Set to true to allow assets to be destroyed.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DestroyImmediate(Object obj, [DefaultValue("false")] bool allowDestroyingAssets);

    /// <summary>
    ///   <para>Destroys the object obj immediately. You are strongly recommended to use Destroy instead.</para>
    /// </summary>
    /// <param name="obj">Object to be destroyed.</param>
    /// <param name="allowDestroyingAssets">Set to true to allow assets to be destroyed.</param>
    [ExcludeFromDocs]
    public static void DestroyImmediate(Object obj)
    {
      bool allowDestroyingAssets = false;
      Object.DestroyImmediate(obj, allowDestroyingAssets);
    }

    /// <summary>
    ///   <para>Returns a list of all active loaded objects of Type type.</para>
    /// </summary>
    /// <param name="type">The type of object to find.</param>
    /// <returns>
    ///   <para>The array of objects found matching the type specified.</para>
    /// </returns>
    [TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Object[] FindObjectsOfType(System.Type type);

    /// <summary>
    ///   <para>The name of the object.</para>
    /// </summary>
    public extern string name { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Makes the object target not be destroyed automatically when loading a new scene.</para>
    /// </summary>
    /// <param name="target">The object which is not destroyed on scene change.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DontDestroyOnLoad(Object target);

    /// <summary>
    ///   <para>Should the object be hidden, saved with the scene or modifiable by the user?</para>
    /// </summary>
    public extern HideFlags hideFlags { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DestroyObject(Object obj, [DefaultValue("0.0F")] float t);

    [ExcludeFromDocs]
    public static void DestroyObject(Object obj)
    {
      float t = 0.0f;
      Object.DestroyObject(obj, t);
    }

    [Obsolete("use Object.FindObjectsOfType instead.")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Object[] FindSceneObjectsOfType(System.Type type);

    /// <summary>
    ///   <para>Returns a list of all active and inactive loaded objects of Type type, including assets.</para>
    /// </summary>
    /// <param name="type">The type of object or asset to find.</param>
    /// <returns>
    ///   <para>The array of objects and assets found matching the type specified.</para>
    /// </returns>
    [Obsolete("use Resources.FindObjectsOfTypeAll instead.")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Object[] FindObjectsOfTypeIncludingAssets(System.Type type);

    /// <summary>
    ///   <para>Returns a list of all active and inactive loaded objects of Type type.</para>
    /// </summary>
    /// <param name="type">The type of object to find.</param>
    /// <returns>
    ///   <para>The array of objects found matching the type specified.</para>
    /// </returns>
    [Obsolete("Please use Resources.FindObjectsOfTypeAll instead")]
    public static Object[] FindObjectsOfTypeAll(System.Type type)
    {
      return Resources.FindObjectsOfTypeAll(type);
    }

    /// <summary>
    ///   <para>Returns the name of the GameObject.</para>
    /// </summary>
    /// <returns>
    ///   <para>The name returned by ToString.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public override extern string ToString();

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool DoesObjectWithInstanceIDExist(int instanceID);

    /// <summary>
    ///   <para>Returns the instance id of the object.</para>
    /// </summary>
    [SecuritySafeCritical]
    public int GetInstanceID()
    {
      this.EnsureRunningOnMainThread();
      return this.m_InstanceID;
    }

    public override int GetHashCode()
    {
      return this.m_InstanceID;
    }

    public override bool Equals(object other)
    {
      Object rhs = other as Object;
      if (rhs == (Object) null && other != null && (object) (other as Object) == null)
        return false;
      return Object.CompareBaseObjects(this, rhs);
    }

    public static implicit operator bool(Object exists)
    {
      return !Object.CompareBaseObjects(exists, (Object) null);
    }

    private static bool CompareBaseObjects(Object lhs, Object rhs)
    {
      bool flag1 = (object) lhs == null;
      bool flag2 = (object) rhs == null;
      if (flag2 && flag1)
        return true;
      if (flag2)
        return !Object.IsNativeObjectAlive(lhs);
      if (flag1)
        return !Object.IsNativeObjectAlive(rhs);
      return lhs.m_InstanceID == rhs.m_InstanceID;
    }

    private static bool IsNativeObjectAlive(Object o)
    {
      if (o.GetCachedPtr() != IntPtr.Zero)
        return true;
      if (o is MonoBehaviour || o is ScriptableObject)
        return false;
      return Object.DoesObjectWithInstanceIDExist(o.GetInstanceID());
    }

    private IntPtr GetCachedPtr()
    {
      return this.m_CachedPtr;
    }

    /// <summary>
    ///   <para>Clones the object original and returns the clone.</para>
    /// </summary>
    /// <param name="original">An existing object that you want to make a copy of.</param>
    /// <param name="position">Position for the new object.</param>
    /// <param name="rotation">Orientation of the new object.</param>
    /// <param name="parent">Parent that will be assigned to the new object.</param>
    /// <param name="instantiateInWorldSpace">Pass true when assigning a parent Object to maintain the world position of the Object, instead of setting its position relative to the new parent. Pass false to set the Object's position relative to its new parent.</param>
    /// <returns>
    ///   <para>The instantiated clone.</para>
    /// </returns>
    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public static Object Instantiate(Object original, Vector3 position, Quaternion rotation)
    {
      Object.CheckNullArgument((object) original, "The Object you want to instantiate is null.");
      if (original is ScriptableObject)
        throw new ArgumentException("Cannot instantiate a ScriptableObject with a position and rotation");
      return Object.Internal_InstantiateSingle(original, position, rotation);
    }

    /// <summary>
    ///   <para>Clones the object original and returns the clone.</para>
    /// </summary>
    /// <param name="original">An existing object that you want to make a copy of.</param>
    /// <param name="position">Position for the new object.</param>
    /// <param name="rotation">Orientation of the new object.</param>
    /// <param name="parent">Parent that will be assigned to the new object.</param>
    /// <param name="instantiateInWorldSpace">Pass true when assigning a parent Object to maintain the world position of the Object, instead of setting its position relative to the new parent. Pass false to set the Object's position relative to its new parent.</param>
    /// <returns>
    ///   <para>The instantiated clone.</para>
    /// </returns>
    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent)
    {
      if ((Object) parent == (Object) null)
        return Object.Internal_InstantiateSingle(original, position, rotation);
      Object.CheckNullArgument((object) original, "The Object you want to instantiate is null.");
      return Object.Internal_InstantiateSingleWithParent(original, parent, position, rotation);
    }

    /// <summary>
    ///   <para>Clones the object original and returns the clone.</para>
    /// </summary>
    /// <param name="original">An existing object that you want to make a copy of.</param>
    /// <param name="position">Position for the new object.</param>
    /// <param name="rotation">Orientation of the new object.</param>
    /// <param name="parent">Parent that will be assigned to the new object.</param>
    /// <param name="instantiateInWorldSpace">Pass true when assigning a parent Object to maintain the world position of the Object, instead of setting its position relative to the new parent. Pass false to set the Object's position relative to its new parent.</param>
    /// <returns>
    ///   <para>The instantiated clone.</para>
    /// </returns>
    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public static Object Instantiate(Object original)
    {
      Object.CheckNullArgument((object) original, "The Object you want to instantiate is null.");
      return Object.Internal_CloneSingle(original);
    }

    /// <summary>
    ///   <para>Clones the object original and returns the clone.</para>
    /// </summary>
    /// <param name="original">An existing object that you want to make a copy of.</param>
    /// <param name="position">Position for the new object.</param>
    /// <param name="rotation">Orientation of the new object.</param>
    /// <param name="parent">Parent that will be assigned to the new object.</param>
    /// <param name="instantiateInWorldSpace">Pass true when assigning a parent Object to maintain the world position of the Object, instead of setting its position relative to the new parent. Pass false to set the Object's position relative to its new parent.</param>
    /// <returns>
    ///   <para>The instantiated clone.</para>
    /// </returns>
    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public static Object Instantiate(Object original, Transform parent)
    {
      return Object.Instantiate(original, parent, false);
    }

    /// <summary>
    ///   <para>Clones the object original and returns the clone.</para>
    /// </summary>
    /// <param name="original">An existing object that you want to make a copy of.</param>
    /// <param name="position">Position for the new object.</param>
    /// <param name="rotation">Orientation of the new object.</param>
    /// <param name="parent">Parent that will be assigned to the new object.</param>
    /// <param name="instantiateInWorldSpace">Pass true when assigning a parent Object to maintain the world position of the Object, instead of setting its position relative to the new parent. Pass false to set the Object's position relative to its new parent.</param>
    /// <returns>
    ///   <para>The instantiated clone.</para>
    /// </returns>
    [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
    public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
    {
      if ((Object) parent == (Object) null)
        return Object.Internal_CloneSingle(original);
      Object.CheckNullArgument((object) original, "The Object you want to instantiate is null.");
      return Object.Internal_CloneSingleWithParent(original, parent, instantiateInWorldSpace);
    }

    public static T Instantiate<T>(T original) where T : Object
    {
      Object.CheckNullArgument((object) original, "The Object you want to instantiate is null.");
      return (T) Object.Internal_CloneSingle((Object) original);
    }

    public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : Object
    {
      return (T) Object.Instantiate((Object) original, position, rotation);
    }

    public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : Object
    {
      return (T) Object.Instantiate((Object) original, position, rotation, parent);
    }

    public static T Instantiate<T>(T original, Transform parent) where T : Object
    {
      return Object.Instantiate<T>(original, parent, false);
    }

    public static T Instantiate<T>(T original, Transform parent, bool worldPositionStays) where T : Object
    {
      return (T) Object.Instantiate((Object) original, parent, worldPositionStays);
    }

    public static T[] FindObjectsOfType<T>() where T : Object
    {
      return Resources.ConvertObjects<T>(Object.FindObjectsOfType(typeof (T)));
    }

    public static T FindObjectOfType<T>() where T : Object
    {
      return (T) Object.FindObjectOfType(typeof (T));
    }

    private static void CheckNullArgument(object arg, string message)
    {
      if (arg == null)
        throw new ArgumentException(message);
    }

    /// <summary>
    ///   <para>Returns the first active loaded object of Type type.</para>
    /// </summary>
    /// <param name="type">The type of object to find.</param>
    /// <returns>
    ///   <para>This returns the  Object that matches the specified type. It returns null if no Object matches the type.</para>
    /// </returns>
    [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
    public static Object FindObjectOfType(System.Type type)
    {
      Object[] objectsOfType = Object.FindObjectsOfType(type);
      if (objectsOfType.Length > 0)
        return objectsOfType[0];
      return (Object) null;
    }

    public static bool operator ==(Object x, Object y)
    {
      return Object.CompareBaseObjects(x, y);
    }

    public static bool operator !=(Object x, Object y)
    {
      return !Object.CompareBaseObjects(x, y);
    }
  }
}
