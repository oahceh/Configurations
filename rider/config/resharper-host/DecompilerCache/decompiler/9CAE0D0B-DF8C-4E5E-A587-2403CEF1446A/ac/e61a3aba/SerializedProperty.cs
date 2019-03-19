// Decompiled with JetBrains decompiler
// Type: UnityEditor.SerializedProperty
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CAE0D0B-DF8C-4E5E-A587-2403CEF1446A
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor
{
  /// <summary>
  ///   <para>SerializedProperty and SerializedObject are classes for editing properties on objects in a completely generic way that automatically handles undo and styling UI for prefabs.</para>
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public sealed class SerializedProperty : IDisposable
  {
    private IntPtr m_Property;
    internal SerializedObject m_SerializedObject;

    internal SerializedProperty()
    {
    }

    [GeneratedByOldBindingsGenerator]
    [ThreadAndSerializationSafe]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Dispose();

    /// <summary>
    ///   <para>See if contained serialized properties are equal.</para>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool EqualContents(SerializedProperty x, SerializedProperty y);

    /// <summary>
    ///   <para>Does this property represent multiple different values due to multi-object editing? (Read Only)</para>
    /// </summary>
    public extern bool hasMultipleDifferentValues { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal extern int hasMultipleDifferentValuesBitwise { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void SetBitAtIndexForAllTargetsImmediate(int index, bool value);

    /// <summary>
    ///   <para>Nice display name of the property. (Read Only)</para>
    /// </summary>
    public extern string displayName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Name of the property. (Read Only)</para>
    /// </summary>
    public extern string name { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Type name of the property. (Read Only)</para>
    /// </summary>
    public extern string type { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Type name of the element in an array property. (Read Only)</para>
    /// </summary>
    public extern string arrayElementType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Tooltip of the property. (Read Only)</para>
    /// </summary>
    public extern string tooltip { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Nesting depth of the property. (Read Only)</para>
    /// </summary>
    public extern int depth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Full path of the property. (Read Only)</para>
    /// </summary>
    public extern string propertyPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal extern int hashCodeForPropertyPathWithoutArrayIndex { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Is this property editable? (Read Only)</para>
    /// </summary>
    public extern bool editable { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public extern bool isAnimated { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal extern bool isCandidate { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal extern bool isKey { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Is this property expanded in the inspector?</para>
    /// </summary>
    public extern bool isExpanded { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Does it have child properties? (Read Only)</para>
    /// </summary>
    public extern bool hasChildren { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Does it have visible child properties? (Read Only)</para>
    /// </summary>
    public extern bool hasVisibleChildren { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Is property part of a prefab instance? (Read Only)</para>
    /// </summary>
    public extern bool isInstantiatedPrefab { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Is property's value different from the prefab it belongs to?</para>
    /// </summary>
    public extern bool prefabOverride { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Type of this property (Read Only).</para>
    /// </summary>
    public extern SerializedPropertyType propertyType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Value of an integer property.</para>
    /// </summary>
    public extern int intValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Value of a integer property as a long.</para>
    /// </summary>
    public extern long longValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Value of a boolean property.</para>
    /// </summary>
    public extern bool boolValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Value of a float property.</para>
    /// </summary>
    public extern float floatValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Value of a float property as a double.</para>
    /// </summary>
    public extern double doubleValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Value of a string property.</para>
    /// </summary>
    public extern string stringValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Value of a color property.</para>
    /// </summary>
    public Color colorValue
    {
      get
      {
        Color color;
        this.INTERNAL_get_colorValue(out color);
        return color;
      }
      set
      {
        this.INTERNAL_set_colorValue(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_colorValue(out Color value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_colorValue(ref Color value);

    /// <summary>
    ///   <para>Value of a animation curve property.</para>
    /// </summary>
    public extern AnimationCurve animationCurveValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    internal extern Gradient gradientValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Value of an object reference property.</para>
    /// </summary>
    public extern UnityEngine.Object objectReferenceValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    public extern int objectReferenceInstanceIDValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    internal extern string objectReferenceStringValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern bool ValidateObjectReferenceValue(UnityEngine.Object obj);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern bool ValidateObjectReferenceValueExact(UnityEngine.Object obj);

    internal extern string objectReferenceTypeString { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void AppendFoldoutPPtrValue(UnityEngine.Object obj);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetLayerMaskStringValue(uint layers);

    internal extern uint layerMaskBits { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Enum index of an enum property.</para>
    /// </summary>
    public extern int enumValueIndex { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Names of enumeration of an enum property.</para>
    /// </summary>
    public extern string[] enumNames { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Display-friendly names of enumeration of an enum property.</para>
    /// </summary>
    public extern string[] enumDisplayNames { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Value of a 2D vector property.</para>
    /// </summary>
    public Vector2 vector2Value
    {
      get
      {
        Vector2 vector2;
        this.INTERNAL_get_vector2Value(out vector2);
        return vector2;
      }
      set
      {
        this.INTERNAL_set_vector2Value(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_vector2Value(out Vector2 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_vector2Value(ref Vector2 value);

    /// <summary>
    ///   <para>Value of a 3D vector property.</para>
    /// </summary>
    public Vector3 vector3Value
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_vector3Value(out vector3);
        return vector3;
      }
      set
      {
        this.INTERNAL_set_vector3Value(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_vector3Value(out Vector3 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_vector3Value(ref Vector3 value);

    /// <summary>
    ///   <para>Value of a 4D vector property.</para>
    /// </summary>
    public Vector4 vector4Value
    {
      get
      {
        Vector4 vector4;
        this.INTERNAL_get_vector4Value(out vector4);
        return vector4;
      }
      set
      {
        this.INTERNAL_set_vector4Value(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_vector4Value(out Vector4 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_vector4Value(ref Vector4 value);

    /// <summary>
    ///   <para>Value of a 2D integer vector property.</para>
    /// </summary>
    public Vector2Int vector2IntValue
    {
      get
      {
        Vector2Int vector2Int;
        this.INTERNAL_get_vector2IntValue(out vector2Int);
        return vector2Int;
      }
      set
      {
        this.INTERNAL_set_vector2IntValue(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_vector2IntValue(out Vector2Int value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_vector2IntValue(ref Vector2Int value);

    /// <summary>
    ///   <para>Value of a 3D integer vector property.</para>
    /// </summary>
    public Vector3Int vector3IntValue
    {
      get
      {
        Vector3Int vector3Int;
        this.INTERNAL_get_vector3IntValue(out vector3Int);
        return vector3Int;
      }
      set
      {
        this.INTERNAL_set_vector3IntValue(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_vector3IntValue(out Vector3Int value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_vector3IntValue(ref Vector3Int value);

    /// <summary>
    ///   <para>Value of a quaternion property.</para>
    /// </summary>
    public Quaternion quaternionValue
    {
      get
      {
        Quaternion quaternion;
        this.INTERNAL_get_quaternionValue(out quaternion);
        return quaternion;
      }
      set
      {
        this.INTERNAL_set_quaternionValue(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_quaternionValue(out Quaternion value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_quaternionValue(ref Quaternion value);

    /// <summary>
    ///   <para>Value of a rectangle property.</para>
    /// </summary>
    public Rect rectValue
    {
      get
      {
        Rect rect;
        this.INTERNAL_get_rectValue(out rect);
        return rect;
      }
      set
      {
        this.INTERNAL_set_rectValue(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_rectValue(out Rect value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_rectValue(ref Rect value);

    /// <summary>
    ///   <para>Value of a rectangle with integer values property.</para>
    /// </summary>
    public RectInt rectIntValue
    {
      get
      {
        RectInt rectInt;
        this.INTERNAL_get_rectIntValue(out rectInt);
        return rectInt;
      }
      set
      {
        this.INTERNAL_set_rectIntValue(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_rectIntValue(out RectInt value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_rectIntValue(ref RectInt value);

    /// <summary>
    ///   <para>Value of bounds property.</para>
    /// </summary>
    public Bounds boundsValue
    {
      get
      {
        Bounds bounds;
        this.INTERNAL_get_boundsValue(out bounds);
        return bounds;
      }
      set
      {
        this.INTERNAL_set_boundsValue(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_boundsValue(out Bounds value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_boundsValue(ref Bounds value);

    /// <summary>
    ///   <para>Value of bounds with integer values property.</para>
    /// </summary>
    public BoundsInt boundsIntValue
    {
      get
      {
        BoundsInt boundsInt;
        this.INTERNAL_get_boundsIntValue(out boundsInt);
        return boundsInt;
      }
      set
      {
        this.INTERNAL_set_boundsIntValue(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_boundsIntValue(out BoundsInt value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_boundsIntValue(ref BoundsInt value);

    /// <summary>
    ///   <para>Move to next property.</para>
    /// </summary>
    /// <param name="enterChildren"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool Next(bool enterChildren);

    /// <summary>
    ///   <para>Move to next visible property.</para>
    /// </summary>
    /// <param name="enterChildren"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool NextVisible(bool enterChildren);

    /// <summary>
    ///   <para>Move to first property of the object.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Reset();

    /// <summary>
    ///   <para>Count remaining visible properties.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int CountRemaining();

    /// <summary>
    ///   <para>Count visible children of this property, including this property itself.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int CountInProperty();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern SerializedProperty CopyInternal();

    /// <summary>
    ///   <para>Duplicates the serialized property.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool DuplicateCommand();

    /// <summary>
    ///   <para>Deletes the serialized property.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool DeleteCommand();

    [ExcludeFromDocs]
    public SerializedProperty GetEndProperty()
    {
      return this.GetEndProperty(false);
    }

    /// <summary>
    ///   <para>Retrieves the SerializedProperty that defines the end range of this property.</para>
    /// </summary>
    /// <param name="includeInvisible"></param>
    public SerializedProperty GetEndProperty([DefaultValue("false")] bool includeInvisible)
    {
      SerializedProperty serializedProperty = this.Copy();
      if (includeInvisible)
        serializedProperty.Next(false);
      else
        serializedProperty.NextVisible(false);
      return serializedProperty;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern bool FindPropertyInternal(string propertyPath);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern bool FindPropertyRelativeInternal(string propertyPath);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int[] GetLayerMaskSelectedIndex(uint layers);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string[] GetLayerMaskNames(uint layers);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern uint ToggleLayerMask(uint layers, int index);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void ToggleLayerMaskAtIndex(int index);

    /// <summary>
    ///   <para>Is this property an array? (Read Only)</para>
    /// </summary>
    public extern bool isArray { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The number of elements in the array. If the SerializedObject contains multiple objects it will return the smallest number of elements. So it is always possible to iterate through the SerializedObject and only get properties found in all objects.</para>
    /// </summary>
    public extern int arraySize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool GetArrayElementAtIndexInternal(int index);

    /// <summary>
    ///   <para>Insert an empty element at the specified index in the array.</para>
    /// </summary>
    /// <param name="index"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void InsertArrayElementAtIndex(int index);

    /// <summary>
    ///   <para>Delete the element at the specified index in the array.</para>
    /// </summary>
    /// <param name="index"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void DeleteArrayElementAtIndex(int index);

    /// <summary>
    ///   <para>Remove all elements from the array.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void ClearArray();

    /// <summary>
    ///   <para>Move an array element from srcIndex to dstIndex.</para>
    /// </summary>
    /// <param name="srcIndex"></param>
    /// <param name="dstIndex"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool MoveArrayElement(int srcIndex, int dstIndex);

    /// <summary>
    ///   <para>Is this property a fixed buffer? (Read Only)</para>
    /// </summary>
    public extern bool isFixedBuffer { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The number of elements in the fixed buffer. (Read Only)</para>
    /// </summary>
    public extern int fixedBufferSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns the element at the specified index in the fixed buffer.</para>
    /// </summary>
    /// <param name="index"></param>
    public SerializedProperty GetFixedBufferElementAtIndex(int index)
    {
      SerializedProperty serializedProperty = this.Copy();
      if (serializedProperty.GetFixedBufferAtIndexInternal(index))
        return serializedProperty;
      return (SerializedProperty) null;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool GetFixedBufferAtIndexInternal(int index);

    ~SerializedProperty()
    {
      this.Dispose();
    }

    /// <summary>
    ///   <para>SerializedObject this property belongs to (Read Only).</para>
    /// </summary>
    public SerializedObject serializedObject
    {
      get
      {
        return this.m_SerializedObject;
      }
    }

    /// <summary>
    ///   <para>A reference to another Object in the Scene. This reference is resolved in the context of the SerializedObject containing the SerializedProperty.</para>
    /// </summary>
    public UnityEngine.Object exposedReferenceValue
    {
      get
      {
        if (this.propertyType != SerializedPropertyType.ExposedReference)
          return (UnityEngine.Object) null;
        SerializedProperty propertyRelative = this.FindPropertyRelative("defaultValue");
        if (propertyRelative == null)
          return (UnityEngine.Object) null;
        UnityEngine.Object @object = propertyRelative.objectReferenceValue;
        IExposedPropertyTable context = this.serializedObject.context as IExposedPropertyTable;
        if (context != null)
        {
          PropertyName id = new PropertyName(this.FindPropertyRelative("exposedName").stringValue);
          bool idValid = false;
          UnityEngine.Object referenceValue = context.GetReferenceValue(id, out idValid);
          if (idValid)
            @object = referenceValue;
        }
        return @object;
      }
      set
      {
        if (this.propertyType != SerializedPropertyType.ExposedReference)
          throw new InvalidOperationException("Attempting to set the reference value on a SerializedProperty that is not an ExposedReference");
        SerializedProperty propertyRelative1 = this.FindPropertyRelative("defaultValue");
        IExposedPropertyTable context = this.serializedObject.context as IExposedPropertyTable;
        if (context == null)
        {
          propertyRelative1.objectReferenceValue = value;
          propertyRelative1.serializedObject.ApplyModifiedProperties();
        }
        else
        {
          SerializedProperty propertyRelative2 = this.FindPropertyRelative("exposedName");
          string stringValue = propertyRelative2.stringValue;
          if (string.IsNullOrEmpty(stringValue))
          {
            stringValue = GUID.Generate().ToString();
            propertyRelative2.stringValue = stringValue;
          }
          PropertyName id = new PropertyName(stringValue);
          context.SetReferenceValue(id, value);
        }
      }
    }

    internal bool isScript
    {
      get
      {
        return this.type == "PPtr<MonoScript>";
      }
    }

    /// <summary>
    ///   <para>Returns a copy of the SerializedProperty iterator in its current state. This is useful if you want to keep a reference to the current property but continue with the iteration.</para>
    /// </summary>
    public SerializedProperty Copy()
    {
      SerializedProperty serializedProperty = this.CopyInternal();
      serializedProperty.m_SerializedObject = this.m_SerializedObject;
      return serializedProperty;
    }

    /// <summary>
    ///   <para>Retrieves the SerializedProperty at a relative path to the current property.</para>
    /// </summary>
    /// <param name="relativePropertyPath"></param>
    public SerializedProperty FindPropertyRelative(string relativePropertyPath)
    {
      SerializedProperty serializedProperty = this.Copy();
      if (serializedProperty.FindPropertyRelativeInternal(relativePropertyPath))
        return serializedProperty;
      return (SerializedProperty) null;
    }

    /// <summary>
    ///   <para>Retrieves an iterator that allows you to iterator over the current nexting of a serialized property.</para>
    /// </summary>
    [DebuggerHidden]
    public IEnumerator GetEnumerator()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new SerializedProperty.\u003CGetEnumerator\u003Ec__Iterator0()
      {
        \u0024this = this
      };
    }

    /// <summary>
    ///   <para>Returns the element at the specified index in the array.</para>
    /// </summary>
    /// <param name="index"></param>
    public SerializedProperty GetArrayElementAtIndex(int index)
    {
      SerializedProperty serializedProperty = this.Copy();
      if (serializedProperty.GetArrayElementAtIndexInternal(index))
        return serializedProperty;
      return (SerializedProperty) null;
    }

    internal void SetToValueOfTarget(UnityEngine.Object target)
    {
      SerializedProperty property = new SerializedObject(target).FindProperty(this.propertyPath);
      if (property == null)
      {
        UnityEngine.Debug.LogError((object) (target.name + " does not have the property " + this.propertyPath));
      }
      else
      {
        switch (this.propertyType)
        {
          case SerializedPropertyType.Integer:
            this.intValue = property.intValue;
            break;
          case SerializedPropertyType.Boolean:
            this.boolValue = property.boolValue;
            break;
          case SerializedPropertyType.Float:
            this.floatValue = property.floatValue;
            break;
          case SerializedPropertyType.String:
            this.stringValue = property.stringValue;
            break;
          case SerializedPropertyType.Color:
            this.colorValue = property.colorValue;
            break;
          case SerializedPropertyType.ObjectReference:
            this.objectReferenceValue = property.objectReferenceValue;
            break;
          case SerializedPropertyType.LayerMask:
            this.intValue = property.intValue;
            break;
          case SerializedPropertyType.Enum:
            this.enumValueIndex = property.enumValueIndex;
            break;
          case SerializedPropertyType.Vector2:
            this.vector2Value = property.vector2Value;
            break;
          case SerializedPropertyType.Vector3:
            this.vector3Value = property.vector3Value;
            break;
          case SerializedPropertyType.Vector4:
            this.vector4Value = property.vector4Value;
            break;
          case SerializedPropertyType.Rect:
            this.rectValue = property.rectValue;
            break;
          case SerializedPropertyType.ArraySize:
            this.intValue = property.intValue;
            break;
          case SerializedPropertyType.Character:
            this.intValue = property.intValue;
            break;
          case SerializedPropertyType.AnimationCurve:
            this.animationCurveValue = property.animationCurveValue;
            break;
          case SerializedPropertyType.Bounds:
            this.boundsValue = property.boundsValue;
            break;
          case SerializedPropertyType.Gradient:
            this.gradientValue = property.gradientValue;
            break;
          case SerializedPropertyType.ExposedReference:
            this.exposedReferenceValue = property.exposedReferenceValue;
            break;
          case SerializedPropertyType.Vector2Int:
            this.vector2IntValue = property.vector2IntValue;
            break;
          case SerializedPropertyType.Vector3Int:
            this.vector3IntValue = property.vector3IntValue;
            break;
          case SerializedPropertyType.RectInt:
            this.rectIntValue = property.rectIntValue;
            break;
          case SerializedPropertyType.BoundsInt:
            this.boundsIntValue = property.boundsIntValue;
            break;
        }
      }
    }
  }
}
