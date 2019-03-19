// Decompiled with JetBrains decompiler
// Type: UnityEditor.SerializedObject
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CAE0D0B-DF8C-4E5E-A587-2403CEF1446A
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting;

namespace UnityEditor
{
  /// <summary>
  ///   <para>SerializedObject and SerializedProperty are classes for editing properties on objects in a completely generic way that automatically handles undo and styling UI for prefabs.</para>
  /// </summary>
  public sealed class SerializedObject : IDisposable
  {
    private IntPtr m_Property;

    /// <summary>
    ///   <para>Create SerializedObject for inspected object.</para>
    /// </summary>
    /// <param name="obj"></param>
    public SerializedObject(UnityEngine.Object obj)
    {
      this.InternalCreate(new UnityEngine.Object[1]{ obj }, (UnityEngine.Object) null);
    }

    /// <summary>
    ///   <para>Create SerializedObject for inspected object by specifying a context to be used to store and resolve ExposedReference types.</para>
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="context"></param>
    public SerializedObject(UnityEngine.Object obj, UnityEngine.Object context)
    {
      this.InternalCreate(new UnityEngine.Object[1]{ obj }, context);
    }

    /// <summary>
    ///   <para>Create SerializedObject for inspected object.</para>
    /// </summary>
    /// <param name="objs"></param>
    public SerializedObject(UnityEngine.Object[] objs)
    {
      this.InternalCreate(objs, (UnityEngine.Object) null);
    }

    /// <summary>
    ///   <para>Create SerializedObject for inspected object by specifying a context to be used to store and resolve ExposedReference types.</para>
    /// </summary>
    /// <param name="objs"></param>
    /// <param name="context"></param>
    public SerializedObject(UnityEngine.Object[] objs, UnityEngine.Object context)
    {
      this.InternalCreate(objs, context);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void InternalCreate(UnityEngine.Object[] monoObjs, UnityEngine.Object context);

    /// <summary>
    ///   <para>Update serialized object's representation.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Update();

    /// <summary>
    ///   <para>Update hasMultipleDifferentValues cache on the next Update() call.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetIsDifferentCacheDirty();

    /// <summary>
    ///   <para>This has been made obsolete. See SerializedObject.UpdateIfRequiredOrScript instead.</para>
    /// </summary>
    [Obsolete("UpdateIfDirtyOrScript has been deprecated. Use UpdateIfRequiredOrScript instead.", false)]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void UpdateIfDirtyOrScript();

    /// <summary>
    ///   <para>Update serialized object's representation, only if the object has been modified since the last call to Update or if it is a script.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool UpdateIfRequiredOrScript();

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Dispose();

    /// <summary>
    ///   <para>The inspected object (Read Only).</para>
    /// </summary>
    public extern UnityEngine.Object targetObject { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The inspected objects (Read Only).</para>
    /// </summary>
    public extern UnityEngine.Object[] targetObjects { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The context used to store and resolve ExposedReference types. This is set by the SerializedObject constructor.</para>
    /// </summary>
    public extern UnityEngine.Object context { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern SerializedProperty GetIterator_Internal();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void Cache(int instanceID);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern SerializedObject LoadFromCache(int instanceID);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern PropertyModification ExtractPropertyModification(string propertyPath);

    /// <summary>
    ///   <para>Apply property modifications.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool ApplyModifiedProperties();

    /// <summary>
    ///   <para>Applies property modifications without registering an undo operation.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool ApplyModifiedPropertiesWithoutUndo();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void CopyFromSerializedPropertyInternal(SerializedProperty prop);

    /// <summary>
    ///   <para>Copies a value from a SerializedProperty to the same serialized property on this serialized object.</para>
    /// </summary>
    /// <param name="prop"></param>
    public void CopyFromSerializedProperty(SerializedProperty prop)
    {
      if (prop == null)
        throw new ArgumentNullException(nameof (prop));
      this.CopyFromSerializedPropertyInternal(prop);
    }

    internal extern bool hasModifiedProperties { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal extern InspectorMode inspectorMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Does the serialized object represents multiple objects due to multi-object editing? (Read Only)</para>
    /// </summary>
    public extern bool isEditingMultipleObjects { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Defines the maximum size beyond which arrays cannot be edited when multiple objects are selected.</para>
    /// </summary>
    public extern int maxArraySizeForMultiEditing { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    ~SerializedObject()
    {
      this.Dispose();
    }

    /// <summary>
    ///   <para>Get the first serialized property.</para>
    /// </summary>
    public SerializedProperty GetIterator()
    {
      SerializedProperty iteratorInternal = this.GetIterator_Internal();
      iteratorInternal.m_SerializedObject = this;
      return iteratorInternal;
    }

    /// <summary>
    ///   <para>Find serialized property by name.</para>
    /// </summary>
    /// <param name="propertyPath"></param>
    public SerializedProperty FindProperty(string propertyPath)
    {
      SerializedProperty iteratorInternal = this.GetIterator_Internal();
      iteratorInternal.m_SerializedObject = this;
      if (iteratorInternal.FindPropertyInternal(propertyPath))
        return iteratorInternal;
      return (SerializedProperty) null;
    }
  }
}
