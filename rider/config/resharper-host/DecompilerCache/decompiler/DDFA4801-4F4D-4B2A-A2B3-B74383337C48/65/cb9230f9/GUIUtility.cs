// Decompiled with JetBrains decompiler
// Type: UnityEngine.GUIUtility
// Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDFA4801-4F4D-4B2A-A2B3-B74383337C48
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.IMGUIModule.dll

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Utility class for making new GUI controls.</para>
  /// </summary>
  [NativeHeader("Runtime/Mono/MonoBehaviour.h")]
  [NativeHeader("Runtime/IMGUI/GUIUtility.h")]
  public class GUIUtility
  {
    internal static Vector2 s_EditorScreenPointOffset = Vector2.zero;
    internal static int s_SkinMode;
    internal static int s_OriginalID;
    internal static Action takeCapture;
    internal static Action releaseCapture;
    internal static Func<int, IntPtr, bool> processEvent;
    internal static Action cleanupRoots;
    internal static Func<Exception, bool> endContainerGUIFromException;

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern float Internal_GetPixelsPerPoint();

    /// <summary>
    ///   <para>Get a unique ID for a control, using an integer as a hint to help ensure correct matching of IDs to controls.</para>
    /// </summary>
    /// <param name="hint"></param>
    /// <param name="focus"></param>
    /// <param name="position"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetControlID(int hint, FocusType focus);

    private static int Internal_GetNextControlID2(int hint, FocusType focusType, Rect rect)
    {
      return GUIUtility.INTERNAL_CALL_Internal_GetNextControlID2(hint, focusType, ref rect);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int INTERNAL_CALL_Internal_GetNextControlID2(int hint, FocusType focusType, ref Rect rect);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int GetPermanentControlID();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Internal_GetHotControl();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_SetHotControl(int value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UpdateUndoName();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool GetChanged();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetChanged(bool changed);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Internal_GetKeyboardControl();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_SetKeyboardControl(int value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetDidGUIWindowsEatLastEvent(bool value);

    /// <summary>
    ///   <para>Get access to the system-wide pasteboard.</para>
    /// </summary>
    public static extern string systemCopyBuffer { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern GUISkin Internal_GetDefaultSkin(int skinMode);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Object Internal_GetBuiltinSkin(int skin);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_ExitGUI();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int Internal_GetGUIDepth();

    internal static extern bool mouseUsed { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>A global property, which is true if a ModalWindow is being displayed, false otherwise.</para>
    /// </summary>
    public static extern bool hasModalWindow { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static extern bool textFieldInput { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int CheckForTabEvent(Event evt);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetKeyboardControlToFirstControlId();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetKeyboardControlToLastControlId();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool HasFocusableControls();

    internal static float pixelsPerPoint
    {
      get
      {
        return GUIUtility.Internal_GetPixelsPerPoint();
      }
    }

    /// <summary>
    ///   <para>Get a unique ID for a control.</para>
    /// </summary>
    /// <param name="focus"></param>
    /// <param name="position"></param>
    public static int GetControlID(FocusType focus)
    {
      return GUIUtility.GetControlID(0, focus);
    }

    /// <summary>
    ///   <para>Get a unique ID for a control, using a the label content as a hint to help ensure correct matching of IDs to controls.</para>
    /// </summary>
    /// <param name="contents"></param>
    /// <param name="focus"></param>
    /// <param name="position"></param>
    public static int GetControlID(GUIContent contents, FocusType focus)
    {
      return GUIUtility.GetControlID(contents.hash, focus);
    }

    /// <summary>
    ///   <para>Get a unique ID for a control.</para>
    /// </summary>
    /// <param name="focus"></param>
    /// <param name="position"></param>
    public static int GetControlID(FocusType focus, Rect position)
    {
      return GUIUtility.Internal_GetNextControlID2(0, focus, position);
    }

    /// <summary>
    ///   <para>Get a unique ID for a control, using an integer as a hint to help ensure correct matching of IDs to controls.</para>
    /// </summary>
    /// <param name="hint"></param>
    /// <param name="focus"></param>
    /// <param name="position"></param>
    public static int GetControlID(int hint, FocusType focus, Rect position)
    {
      return GUIUtility.Internal_GetNextControlID2(hint, focus, position);
    }

    /// <summary>
    ///   <para>Get a unique ID for a control, using a the label content as a hint to help ensure correct matching of IDs to controls.</para>
    /// </summary>
    /// <param name="contents"></param>
    /// <param name="focus"></param>
    /// <param name="position"></param>
    public static int GetControlID(GUIContent contents, FocusType focus, Rect position)
    {
      return GUIUtility.Internal_GetNextControlID2(contents.hash, focus, position);
    }

    /// <summary>
    ///   <para>Get a state object from a controlID.</para>
    /// </summary>
    /// <param name="t"></param>
    /// <param name="controlID"></param>
    public static object GetStateObject(System.Type t, int controlID)
    {
      return GUIStateObjects.GetStateObject(t, controlID);
    }

    /// <summary>
    ///   <para>Get an existing state object from a controlID.</para>
    /// </summary>
    /// <param name="t"></param>
    /// <param name="controlID"></param>
    public static object QueryStateObject(System.Type t, int controlID)
    {
      return GUIStateObjects.QueryStateObject(t, controlID);
    }

    internal static bool guiIsExiting { get; set; }

    /// <summary>
    ///   <para>The controlID of the current hot control.</para>
    /// </summary>
    public static int hotControl
    {
      get
      {
        return GUIUtility.Internal_GetHotControl();
      }
      set
      {
        GUIUtility.Internal_SetHotControl(value);
      }
    }

    [RequiredByNativeCode]
    internal static void TakeCapture()
    {
      if (GUIUtility.takeCapture == null)
        return;
      GUIUtility.takeCapture();
    }

    [RequiredByNativeCode]
    internal static void RemoveCapture()
    {
      if (GUIUtility.releaseCapture == null)
        return;
      GUIUtility.releaseCapture();
    }

    /// <summary>
    ///   <para>The controlID of the control that has keyboard focus.</para>
    /// </summary>
    public static int keyboardControl
    {
      get
      {
        return GUIUtility.Internal_GetKeyboardControl();
      }
      set
      {
        GUIUtility.Internal_SetKeyboardControl(value);
      }
    }

    public static void ExitGUI()
    {
      GUIUtility.guiIsExiting = true;
      throw new ExitGUIException();
    }

    internal static GUISkin GetDefaultSkin(int skinMode)
    {
      return GUIUtility.Internal_GetDefaultSkin(skinMode);
    }

    internal static GUISkin GetDefaultSkin()
    {
      return GUIUtility.Internal_GetDefaultSkin(GUIUtility.s_SkinMode);
    }

    internal static GUISkin GetBuiltinSkin(int skin)
    {
      return GUIUtility.Internal_GetBuiltinSkin(skin) as GUISkin;
    }

    [RequiredByNativeCode]
    internal static bool ProcessEvent(int instanceID, IntPtr nativeEventPtr)
    {
      if (GUIUtility.processEvent != null)
        return GUIUtility.processEvent(instanceID, nativeEventPtr);
      return false;
    }

    internal static void EndContainer()
    {
      GUIUtility.Internal_EndContainer();
      GUIUtility.Internal_ExitGUI();
    }

    internal static void CleanupRoots()
    {
      if (GUIUtility.cleanupRoots == null)
        return;
      GUIUtility.cleanupRoots();
    }

    [RequiredByNativeCode]
    internal static void BeginGUI(int skinMode, int instanceID, int useGUILayout)
    {
      GUIUtility.s_SkinMode = skinMode;
      GUIUtility.s_OriginalID = instanceID;
      GUIUtility.ResetGlobalState();
      if (useGUILayout == 0)
        return;
      GUILayoutUtility.Begin(instanceID);
    }

    [RequiredByNativeCode]
    internal static void SetSkin(int skinMode)
    {
      GUIUtility.s_SkinMode = skinMode;
      GUI.DoSetSkin((GUISkin) null);
    }

    [RequiredByNativeCode]
    internal static void EndGUI(int layoutType)
    {
      try
      {
        if (Event.current.type == EventType.Layout && layoutType != 0)
        {
          if (layoutType != 1)
          {
            if (layoutType == 2)
              GUILayoutUtility.LayoutFromEditorWindow();
          }
          else
            GUILayoutUtility.Layout();
        }
        GUILayoutUtility.SelectIDList(GUIUtility.s_OriginalID, false);
        GUIContent.ClearStaticCache();
      }
      finally
      {
        GUIUtility.Internal_ExitGUI();
      }
    }

    [RequiredByNativeCode]
    internal static bool EndGUIFromException(Exception exception)
    {
      GUIUtility.Internal_ExitGUI();
      return GUIUtility.ShouldRethrowException(exception);
    }

    [RequiredByNativeCode]
    internal static bool EndContainerGUIFromException(Exception exception)
    {
      if (GUIUtility.endContainerGUIFromException != null)
        return GUIUtility.endContainerGUIFromException(exception);
      return false;
    }

    internal static void ResetGlobalState()
    {
      GUI.skin = (GUISkin) null;
      GUIUtility.guiIsExiting = false;
      GUI.changed = false;
    }

    internal static bool IsExitGUIException(Exception exception)
    {
      while (exception is TargetInvocationException && exception.InnerException != null)
        exception = exception.InnerException;
      return exception is ExitGUIException;
    }

    internal static bool ShouldRethrowException(Exception exception)
    {
      return GUIUtility.IsExitGUIException(exception);
    }

    internal static void CheckOnGUI()
    {
      if (GUIUtility.Internal_GetGUIDepth() <= 0)
        throw new ArgumentException("You can only call GUI functions from inside OnGUI.");
    }

    /// <summary>
    ///   <para>Convert a point from GUI position to screen space.</para>
    /// </summary>
    /// <param name="guiPoint"></param>
    public static Vector2 GUIToScreenPoint(Vector2 guiPoint)
    {
      return GUIClip.UnclipToWindow(guiPoint) + GUIUtility.s_EditorScreenPointOffset;
    }

    internal static Rect GUIToScreenRect(Rect guiRect)
    {
      Vector2 screenPoint = GUIUtility.GUIToScreenPoint(new Vector2(guiRect.x, guiRect.y));
      guiRect.x = screenPoint.x;
      guiRect.y = screenPoint.y;
      return guiRect;
    }

    /// <summary>
    ///   <para>Convert a point from screen space to GUI position.</para>
    /// </summary>
    /// <param name="screenPoint"></param>
    public static Vector2 ScreenToGUIPoint(Vector2 screenPoint)
    {
      return GUIClip.ClipToWindow(screenPoint) - GUIUtility.s_EditorScreenPointOffset;
    }

    public static Rect ScreenToGUIRect(Rect screenRect)
    {
      Vector2 guiPoint = GUIUtility.ScreenToGUIPoint(new Vector2(screenRect.x, screenRect.y));
      screenRect.x = guiPoint.x;
      screenRect.y = guiPoint.y;
      return screenRect;
    }

    /// <summary>
    ///   <para>Helper function to rotate the GUI around a point.</para>
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="pivotPoint"></param>
    public static void RotateAroundPivot(float angle, Vector2 pivotPoint)
    {
      Matrix4x4 matrix = GUI.matrix;
      GUI.matrix = Matrix4x4.identity;
      Vector2 vector2 = GUIClip.Unclip(pivotPoint);
      GUI.matrix = Matrix4x4.TRS((Vector3) vector2, Quaternion.Euler(0.0f, 0.0f, angle), Vector3.one) * Matrix4x4.TRS((Vector3) (-vector2), Quaternion.identity, Vector3.one) * matrix;
    }

    /// <summary>
    ///   <para>Helper function to scale the GUI around a point.</para>
    /// </summary>
    /// <param name="scale"></param>
    /// <param name="pivotPoint"></param>
    public static void ScaleAroundPivot(Vector2 scale, Vector2 pivotPoint)
    {
      Matrix4x4 matrix = GUI.matrix;
      Vector2 vector2 = GUIClip.Unclip(pivotPoint);
      GUI.matrix = Matrix4x4.TRS((Vector3) vector2, Quaternion.identity, new Vector3(scale.x, scale.y, 1f)) * Matrix4x4.TRS((Vector3) (-vector2), Quaternion.identity, Vector3.one) * matrix;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void BeginContainerFromOwner(ScriptableObject owner);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void BeginContainer(ObjectGUIState objectGUIState);

    [NativeMethod("EndContainer")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Internal_EndContainer();
  }
}
