// Decompiled with JetBrains decompiler
// Type: UnityEditor.EditorWindow
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CAE0D0B-DF8C-4E5E-A587-2403CEF1446A
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.UIElements;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor
{
  /// <summary>
  ///   <para>Derive from this class to create an editor window.</para>
  /// </summary>
  [UsedByNativeCode]
  public class EditorWindow : ScriptableObject
  {
    [SerializeField]
    [HideInInspector]
    private Vector2 m_MinSize = new Vector2(100f, 100f);
    [HideInInspector]
    [SerializeField]
    private Vector2 m_MaxSize = new Vector2(4000f, 4000f);
    [SerializeField]
    [HideInInspector]
    private int m_DepthBufferBits = 0;
    [SerializeField]
    [HideInInspector]
    internal Rect m_Pos = new Rect(0.0f, 0.0f, 320f, 240f);
    internal GUIContent m_Notification = (GUIContent) null;
    internal float m_FadeoutTime = 0.0f;
    [HideInInspector]
    [SerializeField]
    private bool m_AutoRepaintOnSceneChange;
    [SerializeField]
    [HideInInspector]
    internal GUIContent m_TitleContent;
    private VisualElement m_RootVisualContainer;
    [SerializeField]
    private SerializableJsonDictionary m_PersistentViewDataDictionary;
    private bool m_EnableViewDataPersistence;
    private Rect m_GameViewRect;
    private Rect m_GameViewClippedRect;
    private Vector2 m_GameViewTargetSize;
    private bool m_DontClearBackground;
    private EventInterests m_EventInterests;
    private bool m_DisableInputEvents;
    [NonSerialized]
    internal HostView m_Parent;
    private const double kWarningFadeoutWait = 4.0;
    private const double kWarningFadeoutTime = 1.0;
    private Vector2 m_NotificationSize;

    public EditorWindow()
    {
      this.m_EnableViewDataPersistence = true;
      this.titleContent.text = this.GetType().ToString();
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void MakeModal(ContainerWindow win);

    /// <summary>
    ///   <para>Returns the first EditorWindow of type t which is currently on the screen.</para>
    /// </summary>
    /// <param name="t">The type of the window. Must derive from EditorWindow.</param>
    /// <param name="utility">Set this to true, to create a floating utility window, false to create a normal window.</param>
    /// <param name="title">If GetWindow creates a new window, it will get this title. If this value is null, use the class name as title.</param>
    /// <param name="focus">Whether to give the window focus, if it already exists. (If GetWindow creates a new window, it will always get focus).</param>
    [ExcludeFromDocs]
    public static EditorWindow GetWindow(System.Type t, bool utility, string title)
    {
      bool focus = true;
      return EditorWindow.GetWindow(t, utility, title, focus);
    }

    /// <summary>
    ///   <para>Returns the first EditorWindow of type t which is currently on the screen.</para>
    /// </summary>
    /// <param name="t">The type of the window. Must derive from EditorWindow.</param>
    /// <param name="utility">Set this to true, to create a floating utility window, false to create a normal window.</param>
    /// <param name="title">If GetWindow creates a new window, it will get this title. If this value is null, use the class name as title.</param>
    /// <param name="focus">Whether to give the window focus, if it already exists. (If GetWindow creates a new window, it will always get focus).</param>
    [ExcludeFromDocs]
    public static EditorWindow GetWindow(System.Type t, bool utility)
    {
      bool focus = true;
      string title = (string) null;
      return EditorWindow.GetWindow(t, utility, title, focus);
    }

    /// <summary>
    ///   <para>Returns the first EditorWindow of type t which is currently on the screen.</para>
    /// </summary>
    /// <param name="t">The type of the window. Must derive from EditorWindow.</param>
    /// <param name="utility">Set this to true, to create a floating utility window, false to create a normal window.</param>
    /// <param name="title">If GetWindow creates a new window, it will get this title. If this value is null, use the class name as title.</param>
    /// <param name="focus">Whether to give the window focus, if it already exists. (If GetWindow creates a new window, it will always get focus).</param>
    [ExcludeFromDocs]
    public static EditorWindow GetWindow(System.Type t)
    {
      bool focus = true;
      string title = (string) null;
      bool utility = false;
      return EditorWindow.GetWindow(t, utility, title, focus);
    }

    /// <summary>
    ///   <para>Returns the first EditorWindow of type t which is currently on the screen.</para>
    /// </summary>
    /// <param name="t">The type of the window. Must derive from EditorWindow.</param>
    /// <param name="utility">Set this to true, to create a floating utility window, false to create a normal window.</param>
    /// <param name="title">If GetWindow creates a new window, it will get this title. If this value is null, use the class name as title.</param>
    /// <param name="focus">Whether to give the window focus, if it already exists. (If GetWindow creates a new window, it will always get focus).</param>
    public static EditorWindow GetWindow(System.Type t, [DefaultValue("false")] bool utility, [DefaultValue("null")] string title, [DefaultValue("true")] bool focus)
    {
      return EditorWindow.GetWindowPrivate(t, utility, title, focus);
    }

    /// <summary>
    ///   <para>Returns the first EditorWindow of type t which is currently on the screen.</para>
    /// </summary>
    /// <param name="t">The type of the window. Must derive from EditorWindow.</param>
    /// <param name="rect">The position on the screen where a newly created window will show.</param>
    /// <param name="utility">Set this to true, to create a floating utility window, false to create a normal window.</param>
    /// <param name="title">If GetWindow creates a new window, it will get this title. If this value is null, use the class name as title.</param>
    [ExcludeFromDocs]
    public static EditorWindow GetWindowWithRect(System.Type t, Rect rect, bool utility)
    {
      string title = (string) null;
      return EditorWindow.GetWindowWithRect(t, rect, utility, title);
    }

    /// <summary>
    ///   <para>Returns the first EditorWindow of type t which is currently on the screen.</para>
    /// </summary>
    /// <param name="t">The type of the window. Must derive from EditorWindow.</param>
    /// <param name="rect">The position on the screen where a newly created window will show.</param>
    /// <param name="utility">Set this to true, to create a floating utility window, false to create a normal window.</param>
    /// <param name="title">If GetWindow creates a new window, it will get this title. If this value is null, use the class name as title.</param>
    [ExcludeFromDocs]
    public static EditorWindow GetWindowWithRect(System.Type t, Rect rect)
    {
      string title = (string) null;
      bool utility = false;
      return EditorWindow.GetWindowWithRect(t, rect, utility, title);
    }

    /// <summary>
    ///   <para>Returns the first EditorWindow of type t which is currently on the screen.</para>
    /// </summary>
    /// <param name="t">The type of the window. Must derive from EditorWindow.</param>
    /// <param name="rect">The position on the screen where a newly created window will show.</param>
    /// <param name="utility">Set this to true, to create a floating utility window, false to create a normal window.</param>
    /// <param name="title">If GetWindow creates a new window, it will get this title. If this value is null, use the class name as title.</param>
    public static EditorWindow GetWindowWithRect(System.Type t, Rect rect, [DefaultValue("false")] bool utility, [DefaultValue("null")] string title)
    {
      return EditorWindow.GetWindowWithRectPrivate(t, rect, utility, title);
    }

    internal VisualElement rootVisualContainer
    {
      get
      {
        if (this.m_RootVisualContainer == null)
          this.m_RootVisualContainer = new VisualElement()
          {
            name = VisualElementUtils.GetUniqueName(nameof (rootVisualContainer)),
            pickingMode = PickingMode.Ignore,
            persistenceKey = nameof (rootVisualContainer)
          };
        return this.m_RootVisualContainer;
      }
    }

    internal SerializableJsonDictionary viewDataDictionary
    {
      get
      {
        if (this.m_EnableViewDataPersistence && (UnityEngine.Object) this.m_PersistentViewDataDictionary == (UnityEngine.Object) null)
          this.m_PersistentViewDataDictionary = ScriptableSingletonDictionary<EditorWindowPersistentViewData, SerializableJsonDictionary>.instance[this.GetType().ToString()];
        return this.m_PersistentViewDataDictionary;
      }
    }

    internal void SavePersistentViewData()
    {
      if (!this.m_EnableViewDataPersistence || !((UnityEngine.Object) this.m_PersistentViewDataDictionary != (UnityEngine.Object) null))
        return;
      ScriptableSingletonDictionary<EditorWindowPersistentViewData, SerializableJsonDictionary>.instance.Save(this.GetType().ToString(), this.m_PersistentViewDataDictionary);
    }

    internal ISerializableJsonDictionary GetViewDataDictionary()
    {
      return (ISerializableJsonDictionary) this.viewDataDictionary;
    }

    internal void DisableViewDataPersistence()
    {
      this.m_EnableViewDataPersistence = false;
    }

    internal void ClearPersistentViewData()
    {
      ScriptableSingletonDictionary<EditorWindowPersistentViewData, SerializableJsonDictionary>.instance.Clear(this.GetType().ToString());
      UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.m_PersistentViewDataDictionary);
      this.m_PersistentViewDataDictionary = (SerializableJsonDictionary) null;
    }

    /// <summary>
    ///   <para>Mark the beginning area of all popup windows.</para>
    /// </summary>
    public void BeginWindows()
    {
      EditorGUIInternal.BeginWindowsForward(1, this.GetInstanceID());
    }

    /// <summary>
    ///   <para>Close a window group started with EditorWindow.BeginWindows.</para>
    /// </summary>
    public void EndWindows()
    {
      GUI.EndWindows();
    }

    internal virtual void OnResized()
    {
    }

    /// <summary>
    ///   <para>Checks whether MouseMove events are received in the GUI in this Editor window.</para>
    /// </summary>
    public bool wantsMouseMove
    {
      get
      {
        return this.m_EventInterests.wantsMouseMove;
      }
      set
      {
        this.m_EventInterests.wantsMouseMove = value;
        this.MakeParentsSettingsMatchMe();
      }
    }

    /// <summary>
    ///   <para>Checks whether MouseEnterWindow and MouseLeaveWindow events are received in the GUI in this Editor window.</para>
    /// </summary>
    public bool wantsMouseEnterLeaveWindow
    {
      get
      {
        return this.m_EventInterests.wantsMouseEnterLeaveWindow;
      }
      set
      {
        this.m_EventInterests.wantsMouseEnterLeaveWindow = value;
        this.MakeParentsSettingsMatchMe();
      }
    }

    internal void CheckForWindowRepaint()
    {
      double timeSinceStartup = EditorApplication.timeSinceStartup;
      if (timeSinceStartup < (double) this.m_FadeoutTime)
        return;
      if (timeSinceStartup > (double) this.m_FadeoutTime + 1.0)
        this.RemoveNotification();
      else
        this.Repaint();
    }

    internal GUIContent GetLocalizedTitleContent()
    {
      return EditorWindow.GetLocalizedTitleContentFromType(this.GetType());
    }

    internal static GUIContent GetLocalizedTitleContentFromType(System.Type t)
    {
      EditorWindowTitleAttribute windowTitleAttribute = EditorWindow.GetEditorWindowTitleAttribute(t);
      if (windowTitleAttribute == null)
        return new GUIContent(t.ToString());
      string iconName = "";
      if (!string.IsNullOrEmpty(windowTitleAttribute.icon))
        iconName = windowTitleAttribute.icon;
      else if (windowTitleAttribute.useTypeNameAsIconName)
        iconName = t.ToString();
      if (!string.IsNullOrEmpty(iconName))
        return EditorGUIUtility.TrTextContentWithIcon(windowTitleAttribute.title, iconName);
      return EditorGUIUtility.TrTextContent(windowTitleAttribute.title);
    }

    private static EditorWindowTitleAttribute GetEditorWindowTitleAttribute(System.Type t)
    {
      foreach (object customAttribute in t.GetCustomAttributes(true))
      {
        if (((Attribute) customAttribute).TypeId == typeof (EditorWindowTitleAttribute))
          return (EditorWindowTitleAttribute) customAttribute;
      }
      return (EditorWindowTitleAttribute) null;
    }

    /// <summary>
    ///   <para>Show a notification message.</para>
    /// </summary>
    /// <param name="notification"></param>
    public void ShowNotification(GUIContent notification)
    {
      this.m_Notification = new GUIContent(notification);
      if ((double) this.m_FadeoutTime == 0.0)
        EditorApplication.update += new EditorApplication.CallbackFunction(this.CheckForWindowRepaint);
      this.m_FadeoutTime = (float) (EditorApplication.timeSinceStartup + 4.0);
    }

    /// <summary>
    ///   <para>Stop showing notification message.</para>
    /// </summary>
    public void RemoveNotification()
    {
      if ((double) this.m_FadeoutTime == 0.0)
        return;
      EditorApplication.update -= new EditorApplication.CallbackFunction(this.CheckForWindowRepaint);
      this.m_Notification = (GUIContent) null;
      this.m_FadeoutTime = 0.0f;
    }

    internal void DrawNotification()
    {
      EditorStyles.notificationText.CalcMinMaxWidth(this.m_Notification, out this.m_NotificationSize.y, out this.m_NotificationSize.x);
      this.m_NotificationSize.y = EditorStyles.notificationText.CalcHeight(this.m_Notification, this.m_NotificationSize.x);
      Vector2 notificationSize = this.m_NotificationSize;
      float num1 = this.position.width - (float) EditorStyles.notificationText.margin.horizontal;
      float num2 = (float) ((double) this.position.height - (double) EditorStyles.notificationText.margin.vertical - 20.0);
      if ((double) num1 < (double) this.m_NotificationSize.x)
      {
        float num3 = num1 / this.m_NotificationSize.x;
        notificationSize.x *= num3;
        notificationSize.y = EditorStyles.notificationText.CalcHeight(this.m_Notification, notificationSize.x);
      }
      if ((double) notificationSize.y > (double) num2)
        notificationSize.y = num2;
      Rect position = new Rect((float) (((double) this.position.width - (double) notificationSize.x) * 0.5), (float) (20.0 + ((double) this.position.height - 20.0 - (double) notificationSize.y) * 0.699999988079071), notificationSize.x, notificationSize.y);
      double timeSinceStartup = EditorApplication.timeSinceStartup;
      if (timeSinceStartup > (double) this.m_FadeoutTime)
        GUI.color = new Color(1f, 1f, 1f, 1f - (float) ((timeSinceStartup - (double) this.m_FadeoutTime) / 1.0));
      GUI.Label(position, GUIContent.none, EditorStyles.notificationBackground);
      EditorGUI.DoDropShadowLabel(position, this.m_Notification, EditorStyles.notificationText, 0.3f);
    }

    internal bool dontClearBackground
    {
      get
      {
        return this.m_DontClearBackground;
      }
      set
      {
        this.m_DontClearBackground = value;
        if (!(bool) ((UnityEngine.Object) this.m_Parent) || !((UnityEngine.Object) this.m_Parent.actualView == (UnityEngine.Object) this))
          return;
        this.m_Parent.backgroundValid = false;
      }
    }

    /// <summary>
    ///   <para>Does the window automatically repaint whenever the scene has changed?</para>
    /// </summary>
    public bool autoRepaintOnSceneChange
    {
      get
      {
        return this.m_AutoRepaintOnSceneChange;
      }
      set
      {
        this.m_AutoRepaintOnSceneChange = value;
        this.MakeParentsSettingsMatchMe();
      }
    }

    /// <summary>
    ///   <para>Is this window maximized?</para>
    /// </summary>
    public bool maximized
    {
      get
      {
        return WindowLayout.IsMaximized(this);
      }
      set
      {
        bool flag = WindowLayout.IsMaximized(this);
        if (value == flag)
          return;
        if (value)
          WindowLayout.Maximize(this);
        else
          WindowLayout.Unmaximize(this);
      }
    }

    internal bool hasFocus
    {
      get
      {
        return (bool) ((UnityEngine.Object) this.m_Parent) && (UnityEngine.Object) this.m_Parent.actualView == (UnityEngine.Object) this;
      }
    }

    internal bool docked
    {
      get
      {
        return (UnityEngine.Object) this.m_Parent != (UnityEngine.Object) null && (UnityEngine.Object) this.m_Parent.window != (UnityEngine.Object) null && !this.m_Parent.window.IsNotDocked();
      }
    }

    internal bool disableInputEvents
    {
      get
      {
        return this.m_DisableInputEvents;
      }
      set
      {
        if (this.m_DisableInputEvents == value)
          return;
        this.m_DisableInputEvents = value;
        this.MakeParentsSettingsMatchMe();
      }
    }

    /// <summary>
    ///   <para>The EditorWindow which currently has keyboard focus. (Read Only)</para>
    /// </summary>
    public static EditorWindow focusedWindow
    {
      get
      {
        HostView focusedView = GUIView.focusedView as HostView;
        if ((UnityEngine.Object) focusedView != (UnityEngine.Object) null)
          return focusedView.actualView;
        return (EditorWindow) null;
      }
    }

    /// <summary>
    ///   <para>The EditorWindow currently under the mouse cursor. (Read Only)</para>
    /// </summary>
    public static EditorWindow mouseOverWindow
    {
      get
      {
        HostView mouseOverView = GUIView.mouseOverView as HostView;
        if ((UnityEngine.Object) mouseOverView != (UnityEngine.Object) null)
          return mouseOverView.actualView;
        return (EditorWindow) null;
      }
    }

    internal int GetNumTabs()
    {
      DockArea parent = this.m_Parent as DockArea;
      if ((bool) ((UnityEngine.Object) parent))
        return parent.m_Panes.Count;
      return 0;
    }

    internal bool ShowNextTabIfPossible()
    {
      DockArea parent = this.m_Parent as DockArea;
      if ((bool) ((UnityEngine.Object) parent))
      {
        int num = (parent.m_Panes.IndexOf(this) + 1) % parent.m_Panes.Count;
        if (parent.selected != num)
        {
          parent.selected = num;
          parent.Repaint();
          return true;
        }
      }
      return false;
    }

    public void ShowTab()
    {
      DockArea parent = this.m_Parent as DockArea;
      if ((bool) ((UnityEngine.Object) parent))
      {
        int num = parent.m_Panes.IndexOf(this);
        if (parent.selected != num)
          parent.selected = num;
      }
      this.Repaint();
    }

    /// <summary>
    ///   <para>Moves keyboard focus to another EditorWindow.</para>
    /// </summary>
    public void Focus()
    {
      if (!(bool) ((UnityEngine.Object) this.m_Parent))
        return;
      this.ShowTab();
      this.m_Parent.Focus();
    }

    internal void MakeParentsSettingsMatchMe()
    {
      if (!(bool) ((UnityEngine.Object) this.m_Parent) || (UnityEngine.Object) this.m_Parent.actualView != (UnityEngine.Object) this)
        return;
      this.m_Parent.SetTitle(this.GetType().FullName);
      this.m_Parent.autoRepaintOnSceneChange = this.m_AutoRepaintOnSceneChange;
      bool flag = this.m_Parent.depthBufferBits != this.m_DepthBufferBits;
      this.m_Parent.depthBufferBits = this.m_DepthBufferBits;
      this.m_Parent.SetInternalGameViewDimensions(this.m_GameViewRect, this.m_GameViewClippedRect, this.m_GameViewTargetSize);
      this.m_Parent.eventInterests = this.m_EventInterests;
      this.m_Parent.disableInputEvents = this.m_DisableInputEvents;
      Vector2 vector2 = new Vector2((float) (this.m_Parent.borderSize.left + this.m_Parent.borderSize.right), (float) (this.m_Parent.borderSize.top + this.m_Parent.borderSize.bottom));
      this.m_Parent.SetMinMaxSizes(this.minSize + vector2, this.maxSize + vector2);
      if (!flag)
        return;
      this.m_Parent.RecreateContext();
    }

    /// <summary>
    ///   <para>Show the EditorWindow as a floating utility window.</para>
    /// </summary>
    public void ShowUtility()
    {
      this.ShowWithMode(ShowMode.Utility);
    }

    /// <summary>
    ///   <para>Shows an Editor window using popup-style framing.</para>
    /// </summary>
    public void ShowPopup()
    {
      if (!((UnityEngine.Object) this.m_Parent == (UnityEngine.Object) null))
        return;
      ContainerWindow instance1 = ScriptableObject.CreateInstance<ContainerWindow>();
      instance1.title = this.titleContent.text;
      HostView instance2 = ScriptableObject.CreateInstance<HostView>();
      instance2.actualView = this;
      Rect rect = this.m_Parent.borderSize.Add(new Rect(this.position.x, this.position.y, this.position.width, this.position.height));
      instance1.position = rect;
      instance1.rootView = (View) instance2;
      this.MakeParentsSettingsMatchMe();
      instance1.ShowPopup();
    }

    internal void ShowWithMode(ShowMode mode)
    {
      if (!((UnityEngine.Object) this.m_Parent == (UnityEngine.Object) null))
        return;
      SavedGUIState savedGuiState = SavedGUIState.Create();
      ContainerWindow instance1 = ScriptableObject.CreateInstance<ContainerWindow>();
      instance1.title = this.titleContent.text;
      HostView instance2 = ScriptableObject.CreateInstance<HostView>();
      instance2.actualView = this;
      Rect rect = this.m_Parent.borderSize.Add(new Rect(this.position.x, this.position.y, this.position.width, this.position.height));
      instance1.position = rect;
      instance1.rootView = (View) instance2;
      this.MakeParentsSettingsMatchMe();
      instance1.Show(mode, true, false);
      savedGuiState.ApplyAndForget();
    }

    /// <summary>
    ///   <para>Shows a window with dropdown behaviour and styling.</para>
    /// </summary>
    /// <param name="buttonRect">The button from which the position of the window will be determined (see description).</param>
    /// <param name="windowSize">The initial size of the window.</param>
    public void ShowAsDropDown(Rect buttonRect, Vector2 windowSize)
    {
      this.ShowAsDropDown(buttonRect, windowSize, (PopupLocationHelper.PopupLocation[]) null);
    }

    internal void ShowAsDropDown(Rect buttonRect, Vector2 windowSize, PopupLocationHelper.PopupLocation[] locationPriorityOrder)
    {
      this.ShowAsDropDown(buttonRect, windowSize, locationPriorityOrder, ShowMode.PopupMenu);
    }

    internal void ShowAsDropDown(Rect buttonRect, Vector2 windowSize, PopupLocationHelper.PopupLocation[] locationPriorityOrder, ShowMode mode)
    {
      this.position = this.ShowAsDropDownFitToScreen(buttonRect, windowSize, locationPriorityOrder);
      this.ShowWithMode(mode);
      this.position = this.ShowAsDropDownFitToScreen(buttonRect, windowSize, locationPriorityOrder);
      this.minSize = new Vector2(this.position.width, this.position.height);
      this.maxSize = new Vector2(this.position.width, this.position.height);
      if ((UnityEngine.Object) EditorWindow.focusedWindow != (UnityEngine.Object) this)
        this.Focus();
      this.m_Parent.AddToAuxWindowList();
      this.m_Parent.window.m_DontSaveToLayout = true;
    }

    internal Rect ShowAsDropDownFitToScreen(Rect buttonRect, Vector2 windowSize, PopupLocationHelper.PopupLocation[] locationPriorityOrder)
    {
      if ((UnityEngine.Object) this.m_Parent == (UnityEngine.Object) null)
        return new Rect(buttonRect.x, buttonRect.yMax, windowSize.x, windowSize.y);
      return this.m_Parent.window.GetDropDownRect(buttonRect, windowSize, windowSize, locationPriorityOrder);
    }

    /// <summary>
    ///   <para>Show the EditorWindow window.</para>
    /// </summary>
    /// <param name="immediateDisplay">Immediately display Show.</param>
    public void Show()
    {
      this.Show(false);
    }

    /// <summary>
    ///   <para>Show the EditorWindow window.</para>
    /// </summary>
    /// <param name="immediateDisplay">Immediately display Show.</param>
    public void Show(bool immediateDisplay)
    {
      if (!((UnityEngine.Object) this.m_Parent == (UnityEngine.Object) null))
        return;
      EditorWindow.CreateNewWindowForEditorWindow(this, true, immediateDisplay);
    }

    /// <summary>
    ///   <para>Show the editor window in the auxiliary window.</para>
    /// </summary>
    public void ShowAuxWindow()
    {
      this.ShowWithMode(ShowMode.AuxWindow);
      this.Focus();
      this.m_Parent.AddToAuxWindowList();
    }

    internal void ShowModal()
    {
      this.ShowWithMode(ShowMode.AuxWindow);
      SavedGUIState savedGuiState = SavedGUIState.Create();
      this.MakeModal(this.m_Parent.window);
      savedGuiState.ApplyAndForget();
    }

    private static EditorWindow GetWindowPrivate(System.Type t, bool utility, string title, bool focus)
    {
      UnityEngine.Object[] objectsOfTypeAll = UnityEngine.Resources.FindObjectsOfTypeAll(t);
      EditorWindow editorWindow = objectsOfTypeAll.Length <= 0 ? (EditorWindow) null : (EditorWindow) objectsOfTypeAll[0];
      if (!(bool) ((UnityEngine.Object) editorWindow))
      {
        editorWindow = ScriptableObject.CreateInstance(t) as EditorWindow;
        if (title != null)
          editorWindow.titleContent = new GUIContent(title);
        if (utility)
          editorWindow.ShowUtility();
        else
          editorWindow.Show();
      }
      else if (focus)
      {
        editorWindow.Show();
        editorWindow.Focus();
      }
      return editorWindow;
    }

    public static T GetWindow<T>() where T : EditorWindow
    {
      return EditorWindow.GetWindow<T>(false, (string) null, true);
    }

    public static T GetWindow<T>(bool utility) where T : EditorWindow
    {
      return EditorWindow.GetWindow<T>(utility, (string) null, true);
    }

    public static T GetWindow<T>(bool utility, string title) where T : EditorWindow
    {
      return EditorWindow.GetWindow<T>(utility, title, true);
    }

    public static T GetWindow<T>(string title) where T : EditorWindow
    {
      return EditorWindow.GetWindow<T>(title, true);
    }

    public static T GetWindow<T>(string title, bool focus) where T : EditorWindow
    {
      return EditorWindow.GetWindow<T>(false, title, focus);
    }

    public static T GetWindow<T>(bool utility, string title, bool focus) where T : EditorWindow
    {
      return EditorWindow.GetWindow(typeof (T), utility, title, focus) as T;
    }

    public static T GetWindow<T>(params System.Type[] desiredDockNextTo) where T : EditorWindow
    {
      return EditorWindow.GetWindow<T>((string) null, true, desiredDockNextTo);
    }

    public static T GetWindow<T>(string title, params System.Type[] desiredDockNextTo) where T : EditorWindow
    {
      return EditorWindow.GetWindow<T>(title, true, desiredDockNextTo);
    }

    public static T GetWindow<T>(string title, bool focus, params System.Type[] desiredDockNextTo) where T : EditorWindow
    {
      T[] objectsOfTypeAll = UnityEngine.Resources.FindObjectsOfTypeAll(typeof (T)) as T[];
      T obj = objectsOfTypeAll.Length <= 0 ? (T) null : objectsOfTypeAll[0];
      if ((UnityEngine.Object) obj != (UnityEngine.Object) null)
      {
        if (focus)
          obj.Focus();
        return obj;
      }
      T instance = ScriptableObject.CreateInstance<T>();
      if (title != null)
        instance.titleContent = new GUIContent(title);
      foreach (System.Type type in desiredDockNextTo)
      {
        System.Type desired = type;
        foreach (ContainerWindow window in ContainerWindow.windows)
        {
          foreach (View allChild in window.rootView.allChildren)
          {
            DockArea dockArea = allChild as DockArea;
            if (!((UnityEngine.Object) dockArea == (UnityEngine.Object) null) && dockArea.m_Panes.Any<EditorWindow>((Func<EditorWindow, bool>) (pane => pane.GetType() == desired)))
            {
              dockArea.AddTab((EditorWindow) instance);
              return instance;
            }
          }
        }
      }
      instance.Show();
      return instance;
    }

    /// <summary>
    ///   <para>Focuses the first found EditorWindow of specified type if it is open.</para>
    /// </summary>
    /// <param name="t">The type of the window. Must derive from EditorWindow.</param>
    public static void FocusWindowIfItsOpen(System.Type t)
    {
      UnityEngine.Object[] objectsOfTypeAll = UnityEngine.Resources.FindObjectsOfTypeAll(t);
      EditorWindow editorWindow = objectsOfTypeAll.Length <= 0 ? (EditorWindow) null : objectsOfTypeAll[0] as EditorWindow;
      if (!(bool) ((UnityEngine.Object) editorWindow))
        return;
      editorWindow.Focus();
    }

    public static void FocusWindowIfItsOpen<T>() where T : EditorWindow
    {
      EditorWindow.FocusWindowIfItsOpen(typeof (T));
    }

    internal void RemoveFromDockArea()
    {
      DockArea parent = this.m_Parent as DockArea;
      if (!(bool) ((UnityEngine.Object) parent))
        return;
      parent.RemoveTab(this, true);
    }

    private static EditorWindow GetWindowWithRectPrivate(System.Type t, Rect rect, bool utility, string title)
    {
      UnityEngine.Object[] objectsOfTypeAll = UnityEngine.Resources.FindObjectsOfTypeAll(t);
      EditorWindow editorWindow = objectsOfTypeAll.Length <= 0 ? (EditorWindow) null : (EditorWindow) objectsOfTypeAll[0];
      if (!(bool) ((UnityEngine.Object) editorWindow))
      {
        editorWindow = ScriptableObject.CreateInstance(t) as EditorWindow;
        editorWindow.minSize = new Vector2(rect.width, rect.height);
        editorWindow.maxSize = new Vector2(rect.width, rect.height);
        editorWindow.position = rect;
        if (title != null)
          editorWindow.titleContent = new GUIContent(title);
        if (utility)
          editorWindow.ShowUtility();
        else
          editorWindow.Show();
      }
      else
        editorWindow.Focus();
      return editorWindow;
    }

    public static T GetWindowWithRect<T>(Rect rect) where T : EditorWindow
    {
      return EditorWindow.GetWindowWithRect<T>(rect, false, (string) null, true);
    }

    public static T GetWindowWithRect<T>(Rect rect, bool utility) where T : EditorWindow
    {
      return EditorWindow.GetWindowWithRect<T>(rect, utility, (string) null, true);
    }

    public static T GetWindowWithRect<T>(Rect rect, bool utility, string title) where T : EditorWindow
    {
      return EditorWindow.GetWindowWithRect<T>(rect, utility, title, true);
    }

    public static T GetWindowWithRect<T>(Rect rect, bool utility, string title, bool focus) where T : EditorWindow
    {
      UnityEngine.Object[] objectsOfTypeAll = UnityEngine.Resources.FindObjectsOfTypeAll(typeof (T));
      T instance;
      if (objectsOfTypeAll.Length > 0)
      {
        instance = (T) objectsOfTypeAll[0];
        if (focus)
          instance.Focus();
      }
      else
      {
        instance = ScriptableObject.CreateInstance<T>();
        instance.minSize = new Vector2(rect.width, rect.height);
        instance.maxSize = new Vector2(rect.width, rect.height);
        instance.position = rect;
        if (title != null)
          instance.titleContent = new GUIContent(title);
        if (utility)
          instance.ShowUtility();
        else
          instance.Show();
      }
      return instance;
    }

    internal static T GetWindowDontShow<T>() where T : EditorWindow
    {
      UnityEngine.Object[] objectsOfTypeAll = UnityEngine.Resources.FindObjectsOfTypeAll(typeof (T));
      return objectsOfTypeAll.Length <= 0 ? ScriptableObject.CreateInstance<T>() : (T) objectsOfTypeAll[0];
    }

    /// <summary>
    ///   <para>Close the editor window.</para>
    /// </summary>
    public void Close()
    {
      if (WindowLayout.IsMaximized(this))
        WindowLayout.Unmaximize(this);
      DockArea parent = this.m_Parent as DockArea;
      if ((bool) ((UnityEngine.Object) parent))
        parent.RemoveTab(this, true);
      else
        this.m_Parent.window.Close();
      UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this, true);
    }

    /// <summary>
    ///   <para>Make the window repaint.</para>
    /// </summary>
    public void Repaint()
    {
      if (!(bool) ((UnityEngine.Object) this.m_Parent) || !((UnityEngine.Object) this.m_Parent.actualView == (UnityEngine.Object) this))
        return;
      this.m_Parent.Repaint();
    }

    internal void RepaintImmediately()
    {
      if (!(bool) ((UnityEngine.Object) this.m_Parent) || !((UnityEngine.Object) this.m_Parent.actualView == (UnityEngine.Object) this))
        return;
      this.m_Parent.RepaintImmediately();
    }

    /// <summary>
    ///   <para>The minimum size of this window.</para>
    /// </summary>
    public Vector2 minSize
    {
      get
      {
        return this.m_MinSize;
      }
      set
      {
        this.m_MinSize = value;
        this.MakeParentsSettingsMatchMe();
      }
    }

    /// <summary>
    ///   <para>The maximum size of this window.</para>
    /// </summary>
    public Vector2 maxSize
    {
      get
      {
        return this.m_MaxSize;
      }
      set
      {
        this.m_MaxSize = value;
        this.MakeParentsSettingsMatchMe();
      }
    }

    /// <summary>
    ///   <para>The title of this window.</para>
    /// </summary>
    [Obsolete("Use titleContent instead (it supports setting a title icon as well).")]
    public string title
    {
      get
      {
        return this.titleContent.text;
      }
      set
      {
        this.titleContent = EditorGUIUtility.TextContent(value);
      }
    }

    /// <summary>
    ///   <para>The GUIContent used for drawing the title of EditorWindows.</para>
    /// </summary>
    public GUIContent titleContent
    {
      get
      {
        return this.m_TitleContent ?? (this.m_TitleContent = new GUIContent());
      }
      set
      {
        this.m_TitleContent = value;
        if (this.m_TitleContent == null || !(bool) ((UnityEngine.Object) this.m_Parent) || (!(bool) ((UnityEngine.Object) this.m_Parent.window) || !((UnityEngine.Object) this.m_Parent.window.rootView == (UnityEngine.Object) this.m_Parent)))
          return;
        this.m_Parent.window.title = this.m_TitleContent.text;
      }
    }

    public int depthBufferBits
    {
      get
      {
        return this.m_DepthBufferBits;
      }
      set
      {
        this.m_DepthBufferBits = value;
      }
    }

    internal void SetParentGameViewDimensions(Rect rect, Rect clippedRect, Vector2 targetSize)
    {
      this.m_GameViewRect = rect;
      this.m_GameViewClippedRect = clippedRect;
      this.m_GameViewTargetSize = targetSize;
      this.m_Parent.SetInternalGameViewDimensions(this.m_GameViewRect, this.m_GameViewClippedRect, this.m_GameViewTargetSize);
    }

    [Obsolete("AA is not supported on EditorWindows", false)]
    public int antiAlias
    {
      get
      {
        return 1;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>The desired position of the window in screen space.</para>
    /// </summary>
    public Rect position
    {
      get
      {
        return this.m_Pos;
      }
      set
      {
        this.m_Pos = value;
        if (!(bool) ((UnityEngine.Object) this.m_Parent))
          return;
        DockArea parent = this.m_Parent as DockArea;
        if (!(bool) ((UnityEngine.Object) parent))
          this.m_Parent.window.position = value;
        else if ((bool) ((UnityEngine.Object) parent.parent) && parent.m_Panes.Count == 1 && !(bool) ((UnityEngine.Object) parent.parent.parent))
        {
          Rect rect = parent.borderSize.Add(value);
          if (parent.background != null)
            rect.y -= (float) parent.background.margin.top;
          parent.window.position = rect;
        }
        else
        {
          parent.RemoveTab(this);
          EditorWindow.CreateNewWindowForEditorWindow(this, true, true);
        }
      }
    }

    /// <summary>
    ///   <para>Sends an Event to a window.</para>
    /// </summary>
    /// <param name="e"></param>
    public bool SendEvent(Event e)
    {
      return this.m_Parent.SendEvent(e);
    }

    private void __internalAwake()
    {
      this.hideFlags = HideFlags.DontSave;
    }

    internal static void CreateNewWindowForEditorWindow(EditorWindow window, bool loadPosition, bool showImmediately)
    {
      EditorWindow.CreateNewWindowForEditorWindow(window, new Vector2(window.position.x, window.position.y), loadPosition, showImmediately);
    }

    internal static void CreateNewWindowForEditorWindow(EditorWindow window, Vector2 screenPosition, bool loadPosition, bool showImmediately)
    {
      ContainerWindow instance1 = ScriptableObject.CreateInstance<ContainerWindow>();
      SplitView instance2 = ScriptableObject.CreateInstance<SplitView>();
      instance1.rootView = (View) instance2;
      DockArea instance3 = ScriptableObject.CreateInstance<DockArea>();
      instance2.AddChild((View) instance3);
      instance3.AddTab(window);
      Rect rect = window.m_Parent.borderSize.Add(new Rect(screenPosition.x, screenPosition.y, window.position.width, window.position.height));
      instance1.position = rect;
      instance2.position = new Rect(0.0f, 0.0f, rect.width, rect.height);
      window.MakeParentsSettingsMatchMe();
      instance1.Show(ShowMode.NormalWindow, loadPosition, showImmediately);
      instance1.OnResize();
    }

    [ContextMenu("Add Scene")]
    internal void AddSceneTab()
    {
    }

    [ContextMenu("Add Game")]
    internal void AddGameTab()
    {
    }
  }
}
