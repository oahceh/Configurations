// Decompiled with JetBrains decompiler
// Type: UnityEditor.PropertyHandler
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CAE0D0B-DF8C-4E5E-A587-2403CEF1446A
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace UnityEditor
{
  internal class PropertyHandler
  {
    private PropertyDrawer m_PropertyDrawer = (PropertyDrawer) null;
    private List<DecoratorDrawer> m_DecoratorDrawers = (List<DecoratorDrawer>) null;
    public string tooltip = (string) null;
    public List<ContextMenuItemAttribute> contextMenuItems = (List<ContextMenuItemAttribute>) null;

    public bool hasPropertyDrawer
    {
      get
      {
        return this.propertyDrawer != null;
      }
    }

    private PropertyDrawer propertyDrawer
    {
      get
      {
        return !this.isCurrentlyNested ? this.m_PropertyDrawer : (PropertyDrawer) null;
      }
    }

    private bool isCurrentlyNested
    {
      get
      {
        return this.m_PropertyDrawer != null && ScriptAttributeUtility.s_DrawerStack.Any<PropertyDrawer>() && this.m_PropertyDrawer == ScriptAttributeUtility.s_DrawerStack.Peek();
      }
    }

    public bool empty
    {
      get
      {
        return this.m_DecoratorDrawers == null && this.tooltip == null && this.propertyDrawer == null && this.contextMenuItems == null;
      }
    }

    public void HandleAttribute(PropertyAttribute attribute, System.Reflection.FieldInfo field, System.Type propertyType)
    {
      if (attribute is TooltipAttribute)
        this.tooltip = (attribute as TooltipAttribute).tooltip;
      else if (attribute is ContextMenuItemAttribute)
      {
        if (propertyType.IsArrayOrList())
          return;
        if (this.contextMenuItems == null)
          this.contextMenuItems = new List<ContextMenuItemAttribute>();
        this.contextMenuItems.Add(attribute as ContextMenuItemAttribute);
      }
      else
        this.HandleDrawnType(attribute.GetType(), propertyType, field, attribute);
    }

    public void HandleDrawnType(System.Type drawnType, System.Type propertyType, System.Reflection.FieldInfo field, PropertyAttribute attribute)
    {
      System.Type drawerTypeForType = ScriptAttributeUtility.GetDrawerTypeForType(drawnType);
      if (drawerTypeForType == null)
        return;
      if (typeof (PropertyDrawer).IsAssignableFrom(drawerTypeForType))
      {
        if (propertyType != null && propertyType.IsArrayOrList())
          return;
        this.m_PropertyDrawer = (PropertyDrawer) Activator.CreateInstance(drawerTypeForType);
        this.m_PropertyDrawer.m_FieldInfo = field;
        this.m_PropertyDrawer.m_Attribute = attribute;
      }
      else if (typeof (DecoratorDrawer).IsAssignableFrom(drawerTypeForType) && (field == null || !field.FieldType.IsArrayOrList() || propertyType.IsArrayOrList()))
      {
        DecoratorDrawer instance = (DecoratorDrawer) Activator.CreateInstance(drawerTypeForType);
        instance.m_Attribute = attribute;
        if (this.m_DecoratorDrawers == null)
          this.m_DecoratorDrawers = new List<DecoratorDrawer>();
        this.m_DecoratorDrawers.Add(instance);
      }
    }

    public bool OnGUI(Rect position, SerializedProperty property, GUIContent label, bool includeChildren)
    {
      float height = position.height;
      position.height = 0.0f;
      if (this.m_DecoratorDrawers != null && !this.isCurrentlyNested)
      {
        foreach (DecoratorDrawer decoratorDrawer in this.m_DecoratorDrawers)
        {
          position.height = decoratorDrawer.GetHeight();
          float labelWidth = EditorGUIUtility.labelWidth;
          float fieldWidth = EditorGUIUtility.fieldWidth;
          decoratorDrawer.OnGUI(position);
          EditorGUIUtility.labelWidth = labelWidth;
          EditorGUIUtility.fieldWidth = fieldWidth;
          position.y += position.height;
          height -= position.height;
        }
      }
      position.height = height;
      if (this.propertyDrawer != null)
      {
        float labelWidth = EditorGUIUtility.labelWidth;
        float fieldWidth = EditorGUIUtility.fieldWidth;
        this.propertyDrawer.OnGUISafe(position, property.Copy(), label ?? EditorGUIUtility.TempContent(property.displayName));
        EditorGUIUtility.labelWidth = labelWidth;
        EditorGUIUtility.fieldWidth = fieldWidth;
        return false;
      }
      if (!includeChildren)
        return EditorGUI.DefaultPropertyField(position, property, label);
      Vector2 iconSize = EditorGUIUtility.GetIconSize();
      bool enabled = GUI.enabled;
      int indentLevel = EditorGUI.indentLevel;
      int num = indentLevel - property.depth;
      SerializedProperty serializedProperty = property.Copy();
      SerializedProperty endProperty = serializedProperty.GetEndProperty();
      position.height = EditorGUI.GetSinglePropertyHeight(serializedProperty, label);
      EditorGUI.indentLevel = serializedProperty.depth + num;
      bool enterChildren = EditorGUI.DefaultPropertyField(position, serializedProperty, label) && EditorGUI.HasVisibleChildFields(serializedProperty);
      position.y += position.height + 2f;
      while (serializedProperty.NextVisible(enterChildren) && !SerializedProperty.EqualContents(serializedProperty, endProperty))
      {
        EditorGUI.indentLevel = serializedProperty.depth + num;
        position.height = EditorGUI.GetPropertyHeight(serializedProperty, (GUIContent) null, false);
        EditorGUI.BeginChangeCheck();
        enterChildren = ScriptAttributeUtility.GetHandler(serializedProperty).OnGUI(position, serializedProperty, (GUIContent) null, false) && EditorGUI.HasVisibleChildFields(serializedProperty);
        if (!EditorGUI.EndChangeCheck())
          position.y += position.height + 2f;
        else
          break;
      }
      GUI.enabled = enabled;
      EditorGUIUtility.SetIconSize(iconSize);
      EditorGUI.indentLevel = indentLevel;
      return false;
    }

    public bool OnGUILayout(SerializedProperty property, GUIContent label, bool includeChildren, params GUILayoutOption[] options)
    {
      Rect position = property.propertyType != SerializedPropertyType.Boolean || this.propertyDrawer != null || this.m_DecoratorDrawers != null && this.m_DecoratorDrawers.Count != 0 ? EditorGUILayout.GetControlRect(EditorGUI.LabelHasContent(label), this.GetHeight(property, label, includeChildren), options) : EditorGUILayout.GetToggleRect(true, options);
      EditorGUILayout.s_LastRect = position;
      return this.OnGUI(position, property, label, includeChildren);
    }

    public float GetHeight(SerializedProperty property, GUIContent label, bool includeChildren)
    {
      float num1 = 0.0f;
      if (this.m_DecoratorDrawers != null && !this.isCurrentlyNested)
      {
        foreach (DecoratorDrawer decoratorDrawer in this.m_DecoratorDrawers)
          num1 += decoratorDrawer.GetHeight();
      }
      float num2;
      if (this.propertyDrawer != null)
        num2 = num1 + this.propertyDrawer.GetPropertyHeightSafe(property.Copy(), label ?? EditorGUIUtility.TempContent(property.displayName));
      else if (!includeChildren)
      {
        num2 = num1 + EditorGUI.GetSinglePropertyHeight(property, label);
      }
      else
      {
        property = property.Copy();
        SerializedProperty endProperty = property.GetEndProperty();
        num2 = num1 + EditorGUI.GetSinglePropertyHeight(property, label);
        bool enterChildren = property.isExpanded && EditorGUI.HasVisibleChildFields(property);
        while (property.NextVisible(enterChildren) && !SerializedProperty.EqualContents(property, endProperty))
        {
          float num3 = num2 + ScriptAttributeUtility.GetHandler(property).GetHeight(property, EditorGUIUtility.TempContent(property.displayName), true);
          enterChildren = false;
          num2 = num3 + 2f;
        }
      }
      return num2;
    }

    public bool CanCacheInspectorGUI(SerializedProperty property)
    {
      if (this.m_DecoratorDrawers != null && !this.isCurrentlyNested && this.m_DecoratorDrawers.Any<DecoratorDrawer>((Func<DecoratorDrawer, bool>) (decorator => !decorator.CanCacheInspectorGUI())))
        return false;
      if (this.propertyDrawer != null)
        return this.propertyDrawer.CanCacheInspectorGUISafe(property.Copy());
      property = property.Copy();
      SerializedProperty endProperty = property.GetEndProperty();
      for (bool enterChildren = property.isExpanded && EditorGUI.HasVisibleChildFields(property); property.NextVisible(enterChildren) && !SerializedProperty.EqualContents(property, endProperty); enterChildren = false)
      {
        if (!ScriptAttributeUtility.GetHandler(property).CanCacheInspectorGUI(property))
          return false;
      }
      return true;
    }

    public void AddMenuItems(SerializedProperty property, GenericMenu menu)
    {
      if (this.contextMenuItems == null)
        return;
      System.Type type = property.serializedObject.targetObject.GetType();
      foreach (ContextMenuItemAttribute contextMenuItem in this.contextMenuItems)
      {
        MethodInfo method = type.GetMethod(contextMenuItem.function, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (method != null)
          menu.AddItem(new GUIContent(contextMenuItem.name), false, (GenericMenu.MenuFunction) (() => this.CallMenuCallback((object[]) property.serializedObject.targetObjects, method)));
      }
    }

    public void CallMenuCallback(object[] targets, MethodInfo method)
    {
      foreach (object target in targets)
        method.Invoke(target, new object[0]);
    }
  }
}
