// Decompiled with JetBrains decompiler
// Type: UnityEditor.EditorUtility
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 72C0ECF0-C6AF-4ECC-B63F-E50A904AF6B4
// Assembly location: C:\Program Files\Unity2018.3.6f1\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.Scripting.Compilers;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEditor
{
  /// <summary>
  ///   <para>Editor utility functions.</para>
  /// </summary>
  [NativeHeader("Editor/Mono/MonoEditorUtility.h")]
  [NativeHeader("Runtime/Shaders/ShaderImpl/ShaderUtilities.h")]
  [NativeHeader("Editor/Mono/EditorUtility.bindings.h")]
  public class EditorUtility
  {
    /// <summary>
    ///   <para>Displays the "open file" dialog and returns the selected path name.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="directory"></param>
    /// <param name="extension"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string OpenFilePanel(string title, string directory, string extension);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_OpenFilePanelWithFilters(
      string title,
      string directory,
      string[] filters);

    /// <summary>
    ///   <para>Displays the "open file" dialog and returns the selected path name.</para>
    /// </summary>
    /// <param name="title">Title for dialog.</param>
    /// <param name="directory">Default directory.</param>
    /// <param name="filters">File extensions in form { "Image files", "png,jpg,jpeg", "All files", "*" }.</param>
    public static string OpenFilePanelWithFilters(string title, string directory, string[] filters)
    {
      if (filters.Length % 2 != 0)
        throw new Exception("Filters must be declared in pairs { \"FileType\", \"FileExtension\" }; for instance { \"CSharp\", \"cs\" }. ");
      return EditorUtility.Internal_OpenFilePanelWithFilters(title, directory, filters);
    }

    [FreeFunction("RevealInFinder")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void RevealInFinder(string path);

    /// <summary>
    ///   <para>Displays a modal dialog.</para>
    /// </summary>
    /// <param name="title">The title of the message box.</param>
    /// <param name="message">The text of the message.</param>
    /// <param name="ok">Label displayed on the OK dialog button.</param>
    /// <param name="cancel">Label displayed on the Cancel dialog button.</param>
    [FreeFunction("DisplayDialog")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool DisplayDialog(
      string title,
      string message,
      string ok,
      [DefaultValue("\"\"")] string cancel);

    /// <summary>
    ///   <para>Displays a modal dialog.</para>
    /// </summary>
    /// <param name="title">The title of the message box.</param>
    /// <param name="message">The text of the message.</param>
    /// <param name="ok">Label displayed on the OK dialog button.</param>
    /// <param name="cancel">Label displayed on the Cancel dialog button.</param>
    [ExcludeFromDocs]
    public static bool DisplayDialog(string title, string message, string ok)
    {
      return EditorUtility.DisplayDialog(title, message, ok, string.Empty);
    }

    /// <summary>
    ///   <para>Displays a modal dialog with three buttons.</para>
    /// </summary>
    /// <param name="title">Title for dialog.</param>
    /// <param name="message">Purpose for the dialog.</param>
    /// <param name="ok">Dialog function chosen.</param>
    /// <param name="cancel">Close dialog with no operation.</param>
    /// <param name="alt">Choose alternative dialog purpose.</param>
    /// <returns>
    ///   <para>The id of the chosen button.</para>
    /// </returns>
    [FreeFunction("DisplayDialogComplex")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int DisplayDialogComplex(
      string title,
      string message,
      string ok,
      string cancel,
      string alt);

    /// <summary>
    ///   <para>Displays the "open folder" dialog and returns the selected path name.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="folder"></param>
    /// <param name="defaultName"></param>
    [FreeFunction("RunOpenFolderPanel")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string OpenFolderPanel(string title, string folder, string defaultName);

    /// <summary>
    ///   <para>Displays the "save folder" dialog and returns the selected path name.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="folder"></param>
    /// <param name="defaultName"></param>
    [FreeFunction("RunSaveFolderPanel")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string SaveFolderPanel(string title, string folder, string defaultName);

    [FreeFunction("WarnPrefab")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool WarnPrefab(
      UnityEngine.Object target,
      string title,
      string warning,
      string okButton);

    /// <summary>
    ///   <para>Determines if an object is stored on disk.</para>
    /// </summary>
    /// <param name="target"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool IsPersistent(UnityEngine.Object target);

    /// <summary>
    ///   <para>Displays the "save file" dialog and returns the selected path name.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="directory"></param>
    /// <param name="defaultName"></param>
    /// <param name="extension"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string SaveFilePanel(
      string title,
      string directory,
      string defaultName,
      string extension);

    /// <summary>
    ///   <para>Human-like sorting.</para>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int NaturalCompare(string a, string b);

    /// <summary>
    ///   <para>Marks target object as dirty. (Only suitable for non-scene objects).</para>
    /// </summary>
    /// <param name="target">The object to mark as dirty.</param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetDirty([NotNull] UnityEngine.Object target);

    /// <summary>
    ///   <para>Translates an instance ID to a reference to an object.</para>
    /// </summary>
    /// <param name="instanceID"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object InstanceIDToObject(int instanceID);

    /// <summary>
    ///   <para>Compress a texture.</para>
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="format"></param>
    /// <param name="quality"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CompressTexture([NotNull] Texture2D texture, TextureFormat format, int quality);

    /// <summary>
    ///   <para>Compress a cubemap texture.</para>
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="format"></param>
    /// <param name="quality"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CompressCubemapTexture(
      [NotNull] Cubemap texture,
      TextureFormat format,
      int quality);

    [FreeFunction("InvokeDiffTool")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string InvokeDiffTool(
      string leftTitle,
      string leftFile,
      string rightTitle,
      string rightFile,
      string ancestorTitle,
      string ancestorFile);

    /// <summary>
    ///   <para>Copy all settings of a Unity Object.</para>
    /// </summary>
    /// <param name="source"></param>
    /// <param name="dest"></param>
    [FreeFunction("CopySerialized")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CopySerialized(UnityEngine.Object source, UnityEngine.Object dest);

    /// <summary>
    ///   <para>Copies the serializable fields from one managed object to another.</para>
    /// </summary>
    /// <param name="source">The object to copy data from.</param>
    /// <param name="dest">The object to copy data to.</param>
    [FreeFunction("CopyScriptSerialized")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CopySerializedManagedFieldsOnly([NotNull] object source, [NotNull] object dest);

    [FreeFunction("CopySerializedIfDifferent")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void InternalCopySerializedIfDifferent(UnityEngine.Object source, UnityEngine.Object dest);

    /// <summary>
    ///   <para>Calculates and returns a list of all assets the assets listed in roots depend on.</para>
    /// </summary>
    /// <param name="roots"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object[] CollectDependencies(UnityEngine.Object[] roots);

    /// <summary>
    ///   <para>Collect all objects in the hierarchy rooted at each of the given objects.</para>
    /// </summary>
    /// <param name="roots">Array of objects where the search will start.</param>
    /// <returns>
    ///   <para>Array of objects heirarchically attached to the search array.</para>
    /// </returns>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object[] CollectDeepHierarchy(UnityEngine.Object[] roots);

    [FreeFunction("InstantiateObjectRemoveAllNonAnimationComponents")]
    private static UnityEngine.Object Internal_InstantiateRemoveAllNonAnimationComponentsSingle(
      UnityEngine.Object data,
      Vector3 pos,
      Quaternion rot)
    {
      return EditorUtility.Internal_InstantiateRemoveAllNonAnimationComponentsSingle_Injected(data, ref pos, ref rot);
    }

    [FreeFunction("UnloadUnusedAssetsImmediate")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void UnloadUnusedAssets(bool managedObjects);

    [Obsolete("Use EditorUtility.UnloadUnusedAssetsImmediate instead", false)]
    public static void UnloadUnusedAssets()
    {
      EditorUtility.UnloadUnusedAssets(true);
    }

    [Obsolete("Use EditorUtility.UnloadUnusedAssetsImmediate instead", false)]
    public static void UnloadUnusedAssetsIgnoreManagedReferences()
    {
      EditorUtility.UnloadUnusedAssets(false);
    }

    [FreeFunction("MenuController::DisplayPopupMenu")]
    private static void Private_DisplayPopupMenu(
      Rect position,
      string menuItemPath,
      UnityEngine.Object context,
      int contextUserData)
    {
      EditorUtility.Private_DisplayPopupMenu_Injected(ref position, menuItemPath, context, contextUserData);
    }

    [FreeFunction("UpdateMenuTitleForLanguage")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Internal_UpdateMenuTitleForLanguage(SystemLanguage newloc);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Internal_UpdateAllMenus();

    [FreeFunction("DisplayObjectContextPopupMenu")]
    internal static void DisplayObjectContextPopupMenu(
      Rect position,
      UnityEngine.Object[] context,
      int contextUserData)
    {
      EditorUtility.DisplayObjectContextPopupMenu_Injected(ref position, context, contextUserData);
    }

    [FreeFunction("DisplayCustomContextPopupMenu")]
    private static void DisplayCustomContextPopupMenu(
      Rect screenPosition,
      string[] options,
      bool[] enabled,
      bool[] separator,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey,
      bool allowDisplayNames)
    {
      EditorUtility.DisplayCustomContextPopupMenu_Injected(ref screenPosition, options, enabled, separator, selected, callback, userData, showHotkey, allowDisplayNames);
    }

    [FreeFunction("DisplayObjectContextPopupMenuWithExtraItems")]
    internal static void DisplayObjectContextPopupMenuWithExtraItems(
      Rect position,
      UnityEngine.Object[] context,
      int contextUserData,
      string[] options,
      bool[] enabled,
      bool[] separator,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey)
    {
      EditorUtility.DisplayObjectContextPopupMenuWithExtraItems_Injected(ref position, context, contextUserData, options, enabled, separator, selected, callback, userData, showHotkey);
    }

    [FreeFunction("FormatBytes")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string FormatBytes(long bytes);

    /// <summary>
    ///   <para>Displays or updates a progress bar.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="info"></param>
    /// <param name="progress"></param>
    [FreeFunction("DisplayProgressbar")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DisplayProgressBar(string title, string info, float progress);

    /// <summary>
    ///   <para>Displays or updates a progress bar that has a cancel button.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="info"></param>
    /// <param name="progress"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool DisplayCancelableProgressBar(
      string title,
      string info,
      float progress);

    /// <summary>
    ///   <para>Removes progress bar.</para>
    /// </summary>
    [FreeFunction("ClearProgressbar")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ClearProgressBar();

    /// <summary>
    ///   <para>Is the object enabled (0 disabled, 1 enabled, -1 has no enabled button).</para>
    /// </summary>
    /// <param name="target"></param>
    [FreeFunction("GetObjectEnabled")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetObjectEnabled(UnityEngine.Object target);

    /// <summary>
    ///   <para>Set the enabled state of the object.</para>
    /// </summary>
    /// <param name="target"></param>
    /// <param name="enabled"></param>
    [FreeFunction("SetObjectEnabled")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetObjectEnabled(UnityEngine.Object target, bool enabled);

    /// <summary>
    ///   <para>Set the Scene View selected display mode for this Renderer.</para>
    /// </summary>
    /// <param name="renderer"></param>
    /// <param name="renderState"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetSelectedRenderState(
      Renderer renderer,
      EditorSelectedRenderState renderState);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ForceReloadInspectors();

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void ForceRebuildInspectors();

    /// <summary>
    ///   <para>Saves an AudioClip or MovieTexture to a file.</para>
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="path"></param>
    [FreeFunction("ExtractOggFile")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool ExtractOggFile(UnityEngine.Object obj, string path);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern GameObject Internal_CreateGameObjectWithHideFlags(
      string name,
      HideFlags flags);

    [FreeFunction("OpenWithDefaultApp")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void OpenWithDefaultApp(string fileName);

    [NativeThrows]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool WSACreateTestCertificate(
      string path,
      string publisher,
      string password,
      bool overwrite);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsWindows10OrGreater();

    /// <summary>
    ///   <para>Sets this camera to allow animation of materials in the Editor.</para>
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="animate"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetCameraAnimateMaterials([NotNull] Camera camera, bool animate);

    /// <summary>
    ///   <para>Sets the global time for this camera to use when rendering.</para>
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="time"></param>
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetCameraAnimateMaterialsTime([NotNull] Camera camera, float time);

    /// <summary>
    ///   <para>Updates the global shader properties to use when rendering.</para>
    /// </summary>
    /// <param name="time">Time to use. -1 to disable.</param>
    [FreeFunction("ShaderLab::UpdateGlobalShaderProperties")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void UpdateGlobalShaderProperties(float time);

    [FreeFunction("GetInvalidFilenameChars")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetInvalidFilenameChars();

    [FreeFunction("GetApplication().IsAutoRefreshEnabled")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsAutoRefreshEnabled();

    [FreeFunction("GetApplication().GetActiveNativePlatformSupportModuleName")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetActiveNativePlatformSupportModuleName();

    public static extern bool audioMasterMute { [FreeFunction("GetAudioManager().GetMasterGroupMute"), MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction("GetAudioManager().SetMasterGroupMute"), MethodImpl(MethodImplOptions.InternalCall)] set; }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void LaunchBugReporter();

    internal static extern bool audioProfilingEnabled { [FreeFunction("GetAudioManager().GetProfilingEnabled"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>True if there are any compilation error messages in the log.</para>
    /// </summary>
    public static extern bool scriptCompilationFailed { [FreeFunction("HaveEditorCompileErrors"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool EventHasDragCopyModifierPressed(Event evt);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool EventHasDragMoveModifierPressed(Event evt);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SaveProjectAsTemplate(
      string targetPath,
      string name,
      string displayName,
      string description,
      string defaultScene,
      string version);

    [FreeFunction("FindAssetWithKlass")]
    [Obsolete("Use AssetDatabase.LoadAssetAtPath", false)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object FindAsset(string path, System.Type type);

    [FreeFunction("LoadPlatformSupportModuleNativeDll")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void LoadPlatformSupportModuleNativeDllInternal(string target);

    [FreeFunction("LoadPlatformSupportNativeLibrary")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void LoadPlatformSupportNativeLibrary(string nativeLibrary);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int GetDirtyIndex(int instanceID);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsDirty(int instanceID);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string SaveBuildPanel(
      BuildTarget target,
      string title,
      string directory,
      string defaultName,
      string extension,
      out bool updateExistingBuild);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int NaturalCompareObjectNames(UnityEngine.Object a, UnityEngine.Object b);

    [FreeFunction("RunSavePanelInProject")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_SaveFilePanelInProject(
      string title,
      string defaultName,
      string extension,
      string message,
      string path);

    /// <summary>
    ///   <para>Brings the project window to the front and focuses it.</para>
    /// </summary>
    [RequiredByNativeCode]
    public static void FocusProjectWindow()
    {
      ProjectBrowser projectBrowser = (ProjectBrowser) null;
      HostView focusedView = GUIView.focusedView as HostView;
      if ((UnityEngine.Object) focusedView != (UnityEngine.Object) null && focusedView.actualView is ProjectBrowser)
        projectBrowser = (ProjectBrowser) focusedView.actualView;
      if ((UnityEngine.Object) projectBrowser == (UnityEngine.Object) null)
      {
        UnityEngine.Object[] objectsOfTypeAll = Resources.FindObjectsOfTypeAll(typeof (ProjectBrowser));
        if (objectsOfTypeAll.Length > 0)
          projectBrowser = objectsOfTypeAll[0] as ProjectBrowser;
      }
      if (!((UnityEngine.Object) projectBrowser != (UnityEngine.Object) null))
        return;
      projectBrowser.Focus();
      Event e = EditorGUIUtility.CommandEvent(nameof (FocusProjectWindow));
      projectBrowser.SendEvent(e);
    }

    public static bool LoadWindowLayout(string path)
    {
      return WindowLayout.LoadWindowLayout(path, false);
    }

    /// <summary>
    ///   <para>Compress a texture.</para>
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="format"></param>
    /// <param name="quality"></param>
    public static void CompressTexture(
      Texture2D texture,
      TextureFormat format,
      TextureCompressionQuality quality)
    {
      EditorUtility.CompressTexture(texture, format, (int) quality);
    }

    private static void CompressTexture(Texture2D texture, TextureFormat format)
    {
      EditorUtility.CompressTexture(texture, format, TextureCompressionQuality.Normal);
    }

    /// <summary>
    ///   <para>Compress a cubemap texture.</para>
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="format"></param>
    /// <param name="quality"></param>
    public static void CompressCubemapTexture(
      Cubemap texture,
      TextureFormat format,
      TextureCompressionQuality quality)
    {
      EditorUtility.CompressCubemapTexture(texture, format, (int) quality);
    }

    private static void CompressCubemapTexture(Cubemap texture, TextureFormat format)
    {
      EditorUtility.CompressCubemapTexture(texture, format, TextureCompressionQuality.Normal);
    }

    /// <summary>
    ///   <para>Displays the "save file" dialog in the Assets folder of the project and returns the selected path name.</para>
    /// </summary>
    /// <param name="title"></param>
    /// <param name="defaultName"></param>
    /// <param name="extension"></param>
    /// <param name="message"></param>
    public static string SaveFilePanelInProject(
      string title,
      string defaultName,
      string extension,
      string message)
    {
      return EditorUtility.Internal_SaveFilePanelInProject(title, defaultName, extension, message, "Assets");
    }

    public static string SaveFilePanelInProject(
      string title,
      string defaultName,
      string extension,
      string message,
      string path)
    {
      return EditorUtility.Internal_SaveFilePanelInProject(title, defaultName, extension, message, path);
    }

    /// <summary>
    ///   <para>Copy all settings of a Unity Object to a second Object if they differ.</para>
    /// </summary>
    /// <param name="source"></param>
    /// <param name="dest"></param>
    public static void CopySerializedIfDifferent(UnityEngine.Object source, UnityEngine.Object dest)
    {
      if (source == (UnityEngine.Object) null)
        throw new ArgumentNullException(nameof (source));
      if (dest == (UnityEngine.Object) null)
        throw new ArgumentNullException(nameof (dest));
      EditorUtility.InternalCopySerializedIfDifferent(source, dest);
    }

    [Obsolete("Use AssetDatabase.GetAssetPath", false)]
    public static string GetAssetPath(UnityEngine.Object asset)
    {
      return AssetDatabase.GetAssetPath(asset);
    }

    /// <summary>
    ///   <para>Unloads assets that are not used.</para>
    /// </summary>
    /// <param name="ignoreReferencesFromScript">When true delete assets even if linked in scripts.</param>
    public static void UnloadUnusedAssetsImmediate()
    {
      EditorUtility.UnloadUnusedAssets(true);
    }

    public static void UnloadUnusedAssetsImmediate(bool includeMonoReferencesAsRoots)
    {
      EditorUtility.UnloadUnusedAssets(includeMonoReferencesAsRoots);
    }

    [Obsolete("Use BuildPipeline.BuildAssetBundle instead")]
    public static bool BuildResourceFile(UnityEngine.Object[] selection, string pathName)
    {
      return false;
    }

    /// <summary>
    ///   <para>Displays a popup menu.</para>
    /// </summary>
    /// <param name="position"></param>
    /// <param name="menuItemPath"></param>
    /// <param name="command"></param>
    public static void DisplayPopupMenu(Rect position, string menuItemPath, MenuCommand command)
    {
      if ((menuItemPath == "CONTEXT" || menuItemPath == "CONTEXT/" || menuItemPath == "CONTEXT\\") && (command == null || command.context == (UnityEngine.Object) null))
      {
        Debug.LogError((object) "DisplayPopupMenu: invalid arguments: using CONTEXT requires a valid MenuCommand object. If you want a custom context menu then try using the GenericMenu.");
      }
      else
      {
        Vector2 screenPoint = GUIUtility.GUIToScreenPoint(new Vector2(position.x, position.y));
        position.x = screenPoint.x;
        position.y = screenPoint.y;
        Rect position1 = position;
        string menuItemPath1 = menuItemPath;
        UnityEngine.Object context = command?.context;
        int? userData = command?.userData;
        int contextUserData = !userData.HasValue ? 0 : userData.Value;
        EditorUtility.Internal_DisplayPopupMenu(position1, menuItemPath1, context, contextUserData);
        EditorUtility.ResetMouseDown();
      }
    }

    public static void DisplayCustomMenu(
      Rect position,
      GUIContent[] options,
      int selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData)
    {
      EditorUtility.DisplayCustomMenu(position, options, (Func<int, bool>) null, selected, callback, userData, false);
    }

    public static void DisplayCustomMenu(
      Rect position,
      GUIContent[] options,
      int selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey)
    {
      EditorUtility.DisplayCustomMenu(position, options, (Func<int, bool>) null, selected, callback, userData, showHotkey);
    }

    public static void DisplayCustomMenu(
      Rect position,
      GUIContent[] options,
      Func<int, bool> checkEnabled,
      int selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey = false)
    {
      int[] selected1 = new int[1]{ selected };
      string[] options1 = new string[options.Length];
      for (int index = 0; index < options.Length; ++index)
        options1[index] = options[index].text;
      bool[] enabled;
      if (checkEnabled != null)
      {
        enabled = new bool[options1.Length];
        for (int index = 0; index < options1.Length; ++index)
          enabled[index] = checkEnabled(index);
      }
      else
        enabled = Enumerable.Repeat<bool>(true, options.Length).ToArray<bool>();
      EditorUtility.DisplayCustomMenu(position, options1, enabled, selected1, callback, userData, showHotkey);
    }

    /// <summary>
    ///   <para>Returns a text for a number of bytes.</para>
    /// </summary>
    /// <param name="bytes"></param>
    public static string FormatBytes(int bytes)
    {
      return EditorUtility.FormatBytes((long) bytes);
    }

    /// <summary>
    ///   <para>Sets whether the selected Renderer's wireframe will be hidden when the GameObject it is attached to is selected.</para>
    /// </summary>
    /// <param name="renderer"></param>
    /// <param name="enabled"></param>
    [Obsolete("Use EditorUtility.SetSelectedRenderState", false)]
    public static void SetSelectedWireframeHidden(Renderer renderer, bool enabled)
    {
      EditorUtility.SetSelectedRenderState(renderer, !enabled ? EditorSelectedRenderState.Wireframe | EditorSelectedRenderState.Highlight : EditorSelectedRenderState.Hidden);
    }

    /// <summary>
    ///   <para>Creates a game object with HideFlags and specified components.</para>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="flags"></param>
    /// <param name="components"></param>
    public static GameObject CreateGameObjectWithHideFlags(
      string name,
      HideFlags flags,
      params System.Type[] components)
    {
      GameObject objectWithHideFlags = EditorUtility.Internal_CreateGameObjectWithHideFlags(name, flags);
      objectWithHideFlags.AddComponent(typeof (Transform));
      foreach (System.Type component in components)
        objectWithHideFlags.AddComponent(component);
      return objectWithHideFlags;
    }

    public static string[] CompileCSharp(
      string[] sources,
      string[] references,
      string[] defines,
      string outputFile)
    {
      return MonoCSharpCompiler.Compile(sources, references, defines, outputFile, PlayerSettings.allowUnsafeCode);
    }

    [Obsolete("Use PrefabUtility.InstantiatePrefab", false)]
    public static UnityEngine.Object InstantiatePrefab(UnityEngine.Object target)
    {
      return PrefabUtility.InstantiatePrefab(target);
    }

    [Obsolete("Use PrefabUtility.SaveAsPrefabAsset with a path instead.", false)]
    public static GameObject ReplacePrefab(
      GameObject go,
      UnityEngine.Object targetPrefab,
      ReplacePrefabOptions options)
    {
      return PrefabUtility.ReplacePrefab(go, targetPrefab, options);
    }

    [Obsolete("Use PrefabUtility.SaveAsPrefabAsset or PrefabUtility.SaveAsPrefabAssetAndConnect with a path instead.", false)]
    public static GameObject ReplacePrefab(GameObject go, UnityEngine.Object targetPrefab)
    {
      return PrefabUtility.ReplacePrefab(go, targetPrefab, ReplacePrefabOptions.Default);
    }

    [Obsolete("The concept of creating a completely empty Prefab has been discontinued. You can however use PrefabUtility.SaveAsPrefabAsset with an empty GameObject.", false)]
    public static UnityEngine.Object CreateEmptyPrefab(string path)
    {
      return PrefabUtility.CreateEmptyPrefab(path);
    }

    [Obsolete("Use PrefabUtility.RevertPrefabInstance.", false)]
    public static bool ReconnectToLastPrefab(GameObject go)
    {
      return PrefabUtility.ReconnectToLastPrefab(go);
    }

    [Obsolete("Use PrefabUtility.GetPrefabAssetType and PrefabUtility.GetPrefabInstanceStatus to get the full picture about Prefab types.", false)]
    public static PrefabType GetPrefabType(UnityEngine.Object target)
    {
      return PrefabUtility.GetPrefabType(target);
    }

    [Obsolete("Use PrefabUtility.GetCorrespondingObjectFromSource.", false)]
    public static UnityEngine.Object GetPrefabParent(UnityEngine.Object source)
    {
      return PrefabUtility.GetCorrespondingObjectFromSource<UnityEngine.Object>(source);
    }

    [Obsolete("Use PrefabUtility.GetOutermostPrefabInstanceRoot if source is a Prefab instance or source.transform.root.gameObject if source is a Prefab Asset object.", false)]
    public static GameObject FindPrefabRoot(GameObject source)
    {
      return PrefabUtility.FindPrefabRoot(source);
    }

    [Obsolete("Use PrefabUtility.RevertObjectOverride.", false)]
    public static bool ResetToPrefabState(UnityEngine.Object source)
    {
      return PrefabUtility.ResetToPrefabState(source);
    }

    internal static void ResetMouseDown()
    {
      Tools.s_ButtonDown = -1;
      GUIUtility.hotControl = 0;
    }

    internal static void DisplayCustomMenu(
      Rect position,
      string[] options,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData)
    {
      EditorUtility.DisplayCustomMenu(position, options, selected, callback, userData, false);
    }

    internal static void DisplayCustomMenu(
      Rect position,
      string[] options,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey)
    {
      bool[] separator = new bool[options.Length];
      EditorUtility.DisplayCustomMenuWithSeparators(position, options, separator, selected, callback, userData, showHotkey);
    }

    internal static void DisplayCustomMenuWithSeparators(
      Rect position,
      string[] options,
      bool[] separator,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData)
    {
      EditorUtility.DisplayCustomMenuWithSeparators(position, options, separator, selected, callback, userData, false);
    }

    internal static void DisplayCustomMenuWithSeparators(
      Rect position,
      string[] options,
      bool[] separator,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey)
    {
      Vector2 screenPoint = GUIUtility.GUIToScreenPoint(new Vector2(position.x, position.y));
      position.x = screenPoint.x;
      position.y = screenPoint.y;
      bool[] array = Enumerable.Repeat<bool>(true, options.Length).ToArray<bool>();
      EditorUtility.Internal_DisplayCustomMenu(position, options, array, separator, selected, callback, userData, showHotkey, false);
      EditorUtility.ResetMouseDown();
    }

    internal static void DisplayCustomMenu(
      Rect position,
      string[] options,
      bool[] enabled,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData)
    {
      EditorUtility.DisplayCustomMenu(position, options, enabled, selected, callback, userData, false);
    }

    internal static void DisplayCustomMenu(
      Rect position,
      string[] options,
      bool[] enabled,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey)
    {
      bool[] separator = new bool[options.Length];
      EditorUtility.DisplayCustomMenuWithSeparators(position, options, enabled, separator, selected, callback, userData, showHotkey);
    }

    internal static void DisplayCustomMenuWithSeparators(
      Rect position,
      string[] options,
      bool[] enabled,
      bool[] separator,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData)
    {
      EditorUtility.DisplayCustomMenuWithSeparators(position, options, enabled, separator, selected, callback, userData, false);
    }

    internal static void DisplayCustomMenuWithSeparators(
      Rect position,
      string[] options,
      bool[] enabled,
      bool[] separator,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey)
    {
      EditorUtility.DisplayCustomMenuWithSeparators(position, options, enabled, separator, selected, callback, userData, showHotkey, false);
    }

    internal static void DisplayCustomMenuWithSeparators(
      Rect position,
      string[] options,
      bool[] enabled,
      bool[] separator,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey,
      bool allowDisplayNames)
    {
      Vector2 screenPoint = GUIUtility.GUIToScreenPoint(new Vector2(position.x, position.y));
      position.x = screenPoint.x;
      position.y = screenPoint.y;
      EditorUtility.Internal_DisplayCustomMenu(position, options, enabled, separator, selected, callback, userData, showHotkey, allowDisplayNames);
      EditorUtility.ResetMouseDown();
    }

    internal static void DisplayObjectContextMenu(
      Rect position,
      UnityEngine.Object context,
      int contextUserData)
    {
      EditorUtility.DisplayObjectContextMenu(position, new UnityEngine.Object[1]
      {
        context
      }, contextUserData);
    }

    internal static void DisplayObjectContextMenu(
      Rect position,
      UnityEngine.Object[] context,
      int contextUserData)
    {
      if (EditorGUIUtility.comparisonViewMode != EditorGUIUtility.ComparisonViewMode.None)
        return;
      Vector2 screenPoint = GUIUtility.GUIToScreenPoint(new Vector2(position.x, position.y));
      position.x = screenPoint.x;
      position.y = screenPoint.y;
      GenericMenu pm = new GenericMenu();
      if (context != null && context.Length == 1 && context[0] is Component)
      {
        UnityEngine.Object targetObject = context[0];
        Component targetComponent = (Component) targetObject;
        if (!((UnityEngine.Object) PrefabUtility.GetCorrespondingObjectFromSource<GameObject>(targetComponent.gameObject) == (UnityEngine.Object) null))
        {
          if (PrefabUtility.GetCorrespondingObjectFromSource<UnityEngine.Object>(targetObject) == (UnityEngine.Object) null && (UnityEngine.Object) targetComponent != (UnityEngine.Object) null)
          {
            PrefabUtility.HandleApplyRevertMenuItems("Added Component", (UnityEngine.Object) targetComponent.gameObject, (Action<GUIContent, UnityEngine.Object>) ((menuItemContent, sourceGo) =>
            {
              TargetChoiceHandler.ObjectInstanceAndSourcePathInfo andSourcePathInfo = new TargetChoiceHandler.ObjectInstanceAndSourcePathInfo();
              andSourcePathInfo.instanceObject = (UnityEngine.Object) targetComponent;
              andSourcePathInfo.assetPath = AssetDatabase.GetAssetPath(sourceGo);
              if (!PrefabUtility.IsPartOfPrefabThatCanBeAppliedTo((UnityEngine.Object) PrefabUtility.GetRootGameObject(sourceGo)))
              {
                pm.AddDisabledItem(menuItemContent);
              }
              else
              {
                GenericMenu genericMenu = pm;
                GUIContent content = menuItemContent;
                // ISSUE: reference to a compiler-generated field
                if (EditorUtility.\u003C\u003Ef__mg\u0024cache0 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  EditorUtility.\u003C\u003Ef__mg\u0024cache0 = new GenericMenu.MenuFunction2(TargetChoiceHandler.ApplyPrefabAddedComponent);
                }
                // ISSUE: reference to a compiler-generated field
                GenericMenu.MenuFunction2 fMgCache0 = EditorUtility.\u003C\u003Ef__mg\u0024cache0;
                // ISSUE: variable of a boxed type
                __Boxed<TargetChoiceHandler.ObjectInstanceAndSourcePathInfo> local = (ValueType) andSourcePathInfo;
                genericMenu.AddItem(content, false, fMgCache0, (object) local);
              }
            }), (Action<GUIContent>) (menuItemContent =>
            {
              GenericMenu genericMenu = pm;
              GUIContent content = menuItemContent;
              // ISSUE: reference to a compiler-generated field
              if (EditorUtility.\u003C\u003Ef__mg\u0024cache1 == null)
              {
                // ISSUE: reference to a compiler-generated field
                EditorUtility.\u003C\u003Ef__mg\u0024cache1 = new GenericMenu.MenuFunction2(TargetChoiceHandler.RevertPrefabAddedComponent);
              }
              // ISSUE: reference to a compiler-generated field
              GenericMenu.MenuFunction2 fMgCache1 = EditorUtility.\u003C\u003Ef__mg\u0024cache1;
              Component component = targetComponent;
              genericMenu.AddItem(content, false, fMgCache1, (object) component);
            }), false);
          }
          else
          {
            SerializedProperty iterator = new SerializedObject(targetObject).GetIterator();
            bool flag = false;
            while (iterator.Next(iterator.hasChildren))
            {
              if (iterator.isInstantiatedPrefab && iterator.prefabOverride && !iterator.isDefaultOverride)
              {
                flag = true;
                break;
              }
            }
            if (flag)
            {
              bool anySource = PrefabUtility.IsObjectOverrideAllDefaultOverridesComparedToAnySource(targetObject);
              PrefabUtility.HandleApplyRevertMenuItems("Modified Component", targetObject, (Action<GUIContent, UnityEngine.Object>) ((menuItemContent, sourceObject) =>
              {
                TargetChoiceHandler.ObjectInstanceAndSourcePathInfo andSourcePathInfo = new TargetChoiceHandler.ObjectInstanceAndSourcePathInfo();
                andSourcePathInfo.instanceObject = targetObject;
                andSourcePathInfo.assetPath = AssetDatabase.GetAssetPath(sourceObject);
                if (!PrefabUtility.IsPartOfPrefabThatCanBeAppliedTo((UnityEngine.Object) PrefabUtility.GetRootGameObject(sourceObject)))
                {
                  pm.AddDisabledItem(menuItemContent);
                }
                else
                {
                  GenericMenu genericMenu = pm;
                  GUIContent content = menuItemContent;
                  // ISSUE: reference to a compiler-generated field
                  if (EditorUtility.\u003C\u003Ef__mg\u0024cache2 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    EditorUtility.\u003C\u003Ef__mg\u0024cache2 = new GenericMenu.MenuFunction2(TargetChoiceHandler.ApplyPrefabObjectOverride);
                  }
                  // ISSUE: reference to a compiler-generated field
                  GenericMenu.MenuFunction2 fMgCache2 = EditorUtility.\u003C\u003Ef__mg\u0024cache2;
                  // ISSUE: variable of a boxed type
                  __Boxed<TargetChoiceHandler.ObjectInstanceAndSourcePathInfo> local = (ValueType) andSourcePathInfo;
                  genericMenu.AddItem(content, false, fMgCache2, (object) local);
                }
              }), (Action<GUIContent>) (menuItemContent =>
              {
                GenericMenu genericMenu = pm;
                GUIContent content = menuItemContent;
                // ISSUE: reference to a compiler-generated field
                if (EditorUtility.\u003C\u003Ef__mg\u0024cache3 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  EditorUtility.\u003C\u003Ef__mg\u0024cache3 = new GenericMenu.MenuFunction2(TargetChoiceHandler.RevertPrefabObjectOverride);
                }
                // ISSUE: reference to a compiler-generated field
                GenericMenu.MenuFunction2 fMgCache3 = EditorUtility.\u003C\u003Ef__mg\u0024cache3;
                UnityEngine.Object @object = targetObject;
                genericMenu.AddItem(content, false, fMgCache3, (object) @object);
              }), anySource);
            }
          }
        }
      }
      pm.ObjectContextDropDown(position, context, contextUserData);
      EditorUtility.ResetMouseDown();
    }

    internal static void Internal_DisplayPopupMenu(
      Rect position,
      string menuItemPath,
      UnityEngine.Object context,
      int contextUserData)
    {
      EditorUtility.Private_DisplayPopupMenu(position, menuItemPath, context, contextUserData);
    }

    internal static void InitInstantiatedPreviewRecursive(GameObject go)
    {
      go.hideFlags = HideFlags.HideAndDontSave;
      go.layer = Camera.PreviewCullingLayer;
      IEnumerator enumerator = go.transform.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
          EditorUtility.InitInstantiatedPreviewRecursive(((Component) enumerator.Current).gameObject);
      }
      finally
      {
        if (enumerator is IDisposable disposable)
          disposable.Dispose();
      }
    }

    internal static GameObject InstantiateForAnimatorPreview(UnityEngine.Object original)
    {
      if (original == (UnityEngine.Object) null)
        throw new ArgumentException("The Prefab you want to instantiate is null.");
      GameObject go = EditorUtility.InstantiateRemoveAllNonAnimationComponents(original, Vector3.zero, Quaternion.identity) as GameObject;
      go.name += "AnimatorPreview";
      go.tag = "Untagged";
      EditorUtility.InitInstantiatedPreviewRecursive(go);
      Animator[] componentsInChildren = go.GetComponentsInChildren<Animator>();
      for (int index = 0; index < componentsInChildren.Length; ++index)
      {
        Animator animator = componentsInChildren[index];
        animator.enabled = false;
        animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        animator.logWarnings = false;
        animator.fireEvents = false;
      }
      if (componentsInChildren.Length == 0)
      {
        Animator animator = go.AddComponent<Animator>();
        animator.enabled = false;
        animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        animator.logWarnings = false;
        animator.fireEvents = false;
      }
      return go;
    }

    internal static UnityEngine.Object InstantiateRemoveAllNonAnimationComponents(
      UnityEngine.Object original,
      Vector3 position,
      Quaternion rotation)
    {
      if (original == (UnityEngine.Object) null)
        throw new ArgumentException("The Prefab you want to instantiate is null.");
      return EditorUtility.Internal_InstantiateRemoveAllNonAnimationComponentsSingle(original, position, rotation);
    }

    internal static bool IsUnityAssembly(UnityEngine.Object target)
    {
      if (target == (UnityEngine.Object) null)
        return false;
      return EditorUtility.IsUnityAssembly(target.GetType());
    }

    internal static bool IsUnityAssembly(System.Type type)
    {
      if (type == null)
        return false;
      string name = type.Assembly.GetName().Name;
      return name.StartsWith("UnityEditor") || name.StartsWith("UnityEngine");
    }

    private static void Internal_DisplayCustomMenu(
      Rect screenPosition,
      string[] options,
      bool[] enabled,
      bool[] separator,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey,
      bool allowDisplayNames = false)
    {
      EditorUtility.DisplayCustomContextPopupMenu(screenPosition, options, enabled, separator, selected, callback, userData, showHotkey, allowDisplayNames);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern UnityEngine.Object Internal_InstantiateRemoveAllNonAnimationComponentsSingle_Injected(
      UnityEngine.Object data,
      ref Vector3 pos,
      ref Quaternion rot);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Private_DisplayPopupMenu_Injected(
      ref Rect position,
      string menuItemPath,
      UnityEngine.Object context,
      int contextUserData);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void DisplayObjectContextPopupMenu_Injected(
      ref Rect position,
      UnityEngine.Object[] context,
      int contextUserData);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void DisplayCustomContextPopupMenu_Injected(
      ref Rect screenPosition,
      string[] options,
      bool[] enabled,
      bool[] separator,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey,
      bool allowDisplayNames);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void DisplayObjectContextPopupMenuWithExtraItems_Injected(
      ref Rect position,
      UnityEngine.Object[] context,
      int contextUserData,
      string[] options,
      bool[] enabled,
      bool[] separator,
      int[] selected,
      EditorUtility.SelectMenuItemFunction callback,
      object userData,
      bool showHotkey);

    public delegate void SelectMenuItemFunction(object userData, string[] options, int selected);
  }
}
