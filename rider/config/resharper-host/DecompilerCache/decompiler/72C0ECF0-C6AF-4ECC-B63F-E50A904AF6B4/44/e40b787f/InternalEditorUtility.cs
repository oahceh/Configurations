// Decompiled with JetBrains decompiler
// Type: UnityEditorInternal.InternalEditorUtility
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 72C0ECF0-C6AF-4ECC-B63F-E50A904AF6B4
// Assembly location: C:\Program Files\Unity2018.3.6f1\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Audio;
using UnityEditor.PackageManager;
using UnityEditor.Scripting;
using UnityEditor.Scripting.ScriptCompilation;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.U2D;
using UnityEngine.Experimental.UIElements;
using UnityEngine.StyleSheets;
using UnityEngine.Tilemaps;
using UnityEngine.Video;

namespace UnityEditorInternal
{
  [NativeHeader("Runtime/Camera/RenderManager.h")]
  [NativeHeader("Editor/Src/BuildPipeline/BuildTargetPlatformSpecific.h")]
  [NativeHeader("Runtime/Utilities/Argv.h")]
  [NativeHeader("Runtime/Utilities/FileUtilities.h")]
  [NativeHeader("Runtime/Utilities/LaunchUtilities.h")]
  [NativeHeader("Runtime/Utilities/UnityRevision.h")]
  [NativeHeader("Runtime/Interfaces/ILicensing.h")]
  [NativeHeader("Editor/Platform/Interface/ColorPicker.h")]
  [NativeHeader("Editor/Platform/Interface/EditorUtility.h")]
  [NativeHeader("Editor/Platform/Interface/EditorWindows.h")]
  [NativeHeader("Editor/Src/Application/Application.h")]
  [NativeHeader("Modules/AssetDatabase/Editor/Public/AssetDatabase.h")]
  [NativeHeader("Modules/AssetDatabase/Editor/Public/AssetDatabaseDeprecated.h")]
  [NativeHeader("Editor/Src/AssetPipeline/TextureImporting/BumpMapSettings.h")]
  [NativeHeader("Editor/Src/AssetPipeline/MdFourGenerator.h")]
  [NativeHeader("Editor/Src/ScriptCompilation/PrecompiledAssemblies.h")]
  [NativeHeader("Editor/Src/AssetPipeline/ObjectHashGenerator.h")]
  [NativeHeader("Editor/Src/AssetPipeline/UnityExtensions.h")]
  [NativeHeader("Editor/Src/InspectorExpandedState.h")]
  [NativeHeader("Editor/Src/HierarchyState.h")]
  [NativeHeader("Editor/Src/Gizmos/GizmoUtil.h")]
  [NativeHeader("Editor/Src/EditorModules.h")]
  [NativeHeader("Editor/Src/EditorWindowController.h")]
  [NativeHeader("Editor/Src/EditorUserBuildSettings.h")]
  [NativeHeader("Editor/Src/EditorHelper.h")]
  [NativeHeader("Editor/Src/DragAndDropForwarding.h")]
  [NativeHeader("Editor/Src/DisplayDialog.h")]
  [NativeHeader("Editor/Src/BuildPipeline/BuildPlayer.h")]
  [NativeHeader("Runtime/Utilities/Word.h")]
  [NativeHeader("Editor/Src/AuxWindowManager.h")]
  [NativeHeader("Editor/Src/ShaderMenu.h")]
  [NativeHeader("Runtime/Shaders/ShaderImpl/FastPropertyName.h")]
  [NativeHeader("Runtime/Serialize/PersistentManager.h")]
  [NativeHeader("Runtime/Misc/PlayerSettings.h")]
  [NativeHeader("Runtime/Misc/Player.h")]
  [NativeHeader("Runtime/Misc/GameObjectUtility.h")]
  [NativeHeader("Runtime/Input/Cursor.h")]
  [NativeHeader("Runtime/Graphics/GpuDeviceManager.h")]
  [NativeHeader("Runtime/BaseClasses/TagManager.h")]
  [NativeHeader("Runtime/Serialize/PersistentManager.h")]
  [NativeHeader("Runtime/Graphics/GraphicsHelper.h")]
  [NativeHeader("Editor/Src/InternalEditorUtility.bindings.h")]
  [NativeHeader("Runtime/Camera/RenderSettings.h")]
  [NativeHeader("Runtime/Graphics/SpriteFrame.h")]
  [NativeHeader("Runtime/Graphics/ScreenManager.h")]
  [NativeHeader("Runtime/Graphics/Renderer.h")]
  [NativeHeader("Runtime/Transform/RectTransform.h")]
  [NativeHeader("Runtime/Camera/Camera.h")]
  [NativeHeader("Runtime/Camera/Skybox.h")]
  [NativeHeader("Runtime/2D/Common/SpriteTypes.h")]
  [NativeHeader("Editor/Src/RemoteInput/RemoteInput.h")]
  [NativeHeader("Editor/Src/Utility/GameObjectHierarchyProperty.h")]
  [NativeHeader("Runtime/Threads/ThreadChecks.h")]
  [NativeHeader("Editor/Src/Undo/ObjectUndo.h")]
  [NativeHeader("Editor/Mono/MonoEditorUtility.h")]
  [NativeHeader("Modules/AssetDatabase/Editor/Public/AssetDatabaseProperty.h")]
  [NativeHeader("Editor/Src/Utility/CustomLighting.h")]
  [NativeHeader("Editor/Src/Utility/DiffTool.h")]
  public class InternalEditorUtility
  {
    public static extern bool isHumanControllingUs { [FreeFunction("IsHumanControllingUs"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    public static extern bool isApplicationActive { [FreeFunction("IsApplicationActive"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    public static extern bool inBatchMode { [FreeFunction("IsBatchmode"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    [NativeMethod("PerformUnmarkedBumpMapTexturesFixingAfterDialog")]
    [StaticAccessor("BumpMapSettings::Get()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BumpMapSettingsFixingWindowReportResult(int result);

    [FreeFunction("InternalEditorUtilityBindings::BumpMapTextureNeedsFixingInternal")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool BumpMapTextureNeedsFixingInternal(
      Material material,
      string propName,
      bool flaggedAsNormal);

    internal static bool BumpMapTextureNeedsFixing(MaterialProperty prop)
    {
      if (prop.type != MaterialProperty.PropType.Texture)
        return false;
      bool flaggedAsNormal = (prop.flags & MaterialProperty.PropFlags.Normal) != MaterialProperty.PropFlags.None;
      foreach (Material target in prop.targets)
      {
        if (InternalEditorUtility.BumpMapTextureNeedsFixingInternal(target, prop.name, flaggedAsNormal))
          return true;
      }
      return false;
    }

    [FreeFunction("InternalEditorUtilityBindings::FixNormalmapTextureInternal")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void FixNormalmapTextureInternal([NotNull] Material material, string propName);

    internal static void FixNormalmapTexture(MaterialProperty prop)
    {
      foreach (Material target in prop.targets)
        InternalEditorUtility.FixNormalmapTextureInternal(target, prop.name);
    }

    [FreeFunction("InternalEditorUtilityBindings::GetEditorAssemblyPath")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetEditorAssemblyPath();

    [FreeFunction("InternalEditorUtilityBindings::GetEngineAssemblyPath")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetEngineAssemblyPath();

    [FreeFunction("InternalEditorUtilityBindings::GetEngineCoreModuleAssemblyPath")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetEngineCoreModuleAssemblyPath();

    [FreeFunction("InternalEditorUtilityBindings::CalculateHashForObjectsAndDependencies")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string CalculateHashForObjectsAndDependencies(UnityEngine.Object[] objects);

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ExecuteCommandOnKeyWindow(string commandName);

    [FreeFunction("InternalEditorUtilityBindings::InstantiateMaterialsInEditMode")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern Material[] InstantiateMaterialsInEditMode([NotNull] Renderer renderer);

    [FreeFunction("InternalEditorUtilityBindings::BuildCanBeAppended")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern CanAppendBuild BuildCanBeAppended(
      BuildTarget target,
      string location);

    [FreeFunction("InternalEditorUtilityBindings::RegisterExtensionDll")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void RegisterExtensionDll(string dllLocation, string guid);

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void RegisterPrecompiledAssembly(string dllName, string dllLocation);

    [FreeFunction("InternalEditorUtilityBindings::SetPlatformPath")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetPlatformPath(string path);

    [FreeFunction("InternalEditorUtilityBindings::AddScriptComponentUncheckedUndoable")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int AddScriptComponentUncheckedUndoable(
      [NotNull] GameObject gameObject,
      [NotNull] MonoScript script);

    [FreeFunction("InternalEditorUtilityBindings::CreateScriptableObjectUnchecked")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int CreateScriptableObjectUnchecked(MonoScript script);

    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void RequestScriptReload();

    [NativeMethod("SwitchSkinAndRepaintAllViews")]
    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SwitchSkinAndRepaintAllViews();

    [StaticAccessor("GetApplication()", StaticAccessorType.Dot)]
    [NativeMethod("RequestRepaintAllViews")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void RepaintAllViews();

    [NativeMethod("IsInspectorExpanded")]
    [StaticAccessor("GetInspectorExpandedState()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool GetIsInspectorExpanded(UnityEngine.Object obj);

    [NativeMethod("SetInspectorExpanded")]
    [StaticAccessor("GetInspectorExpandedState()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetIsInspectorExpanded(UnityEngine.Object obj, bool isExpanded);

    public static extern int[] expandedProjectWindowItems { [StaticAccessor("AssetDatabase::GetProjectWindowHierarchyState()", StaticAccessorType.Dot), NativeMethod("GetExpandedArray"), MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction("InternalEditorUtilityBindings::SetExpandedProjectWindowItems"), MethodImpl(MethodImplOptions.InternalCall)] set; }

    public static Assembly LoadAssemblyWrapper(string dllName, string dllLocation)
    {
      return (Assembly) InternalEditorUtility.LoadAssemblyWrapperInternal(dllName, dllLocation);
    }

    [StaticAccessor("GetMonoManager()", StaticAccessorType.Dot)]
    [NativeMethod("LoadAssembly")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern object LoadAssemblyWrapperInternal(string dllName, string dllLocation);

    public static void SaveToSerializedFileAndForget(
      UnityEngine.Object[] obj,
      string path,
      bool allowTextSerialization)
    {
      InternalEditorUtility.SaveToSerializedFileAndForgetInternal(path, obj, allowTextSerialization);
    }

    [FreeFunction("SaveToSerializedFileAndForget")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SaveToSerializedFileAndForgetInternal(
      string path,
      UnityEngine.Object[] obj,
      bool allowTextSerialization);

    [FreeFunction("InternalEditorUtilityBindings::LoadSerializedFileAndForget")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object[] LoadSerializedFileAndForget(string path);

    [FreeFunction("InternalEditorUtilityBindings::ProjectWindowDrag")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern DragAndDropVisualMode ProjectWindowDrag(
      HierarchyProperty property,
      bool perform);

    [FreeFunction("InternalEditorUtilityBindings::HierarchyWindowDrag")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern DragAndDropVisualMode HierarchyWindowDrag(
      HierarchyProperty property,
      InternalEditorUtility.HierarchyDropMode dropMode,
      Transform parentForDraggedObjects,
      bool perform);

    [FreeFunction("InternalEditorUtilityBindings::InspectorWindowDrag")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern DragAndDropVisualMode InspectorWindowDrag(
      UnityEngine.Object[] targets,
      bool perform);

    [FreeFunction("InternalEditorUtilityBindings::SceneViewDrag")]
    public static DragAndDropVisualMode SceneViewDrag(
      UnityEngine.Object dropUpon,
      Vector3 worldPosition,
      Vector2 viewportPosition,
      Transform parentForDraggedObjects,
      bool perform)
    {
      return InternalEditorUtility.SceneViewDrag_Injected(dropUpon, ref worldPosition, ref viewportPosition, parentForDraggedObjects, perform);
    }

    [FreeFunction("InternalEditorUtilityBindings::SetRectTransformTemporaryRect")]
    public static void SetRectTransformTemporaryRect([NotNull] RectTransform rectTransform, Rect rect)
    {
      InternalEditorUtility.SetRectTransformTemporaryRect_Injected(rectTransform, ref rect);
    }

    [FreeFunction("InternalEditorUtilityBindings::HasTeamLicense", IsThreadSafe = true)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasTeamLicense();

    [FreeFunction("InternalEditorUtilityBindings::HasPro", IsThreadSafe = true)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasPro();

    [FreeFunction("InternalEditorUtilityBindings::HasFreeLicense", IsThreadSafe = true)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasFreeLicense();

    [FreeFunction("InternalEditorUtilityBindings::HasEduLicense", IsThreadSafe = true)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasEduLicense();

    [FreeFunction("InternalEditorUtilityBindings::HasUFSTLicense", IsThreadSafe = true)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool HasUFSTLicense();

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasAdvancedLicenseOnBuildTarget(BuildTarget target);

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool IsMobilePlatform(BuildTarget target);

    [NativeThrows]
    [FreeFunction("InternalEditorUtilityBindings::GetBoundsOfDesktopAtPoint")]
    public static Rect GetBoundsOfDesktopAtPoint(Vector2 pos)
    {
      Rect ret;
      InternalEditorUtility.GetBoundsOfDesktopAtPoint_Injected(ref pos, out ret);
      return ret;
    }

    [NativeMethod("RemoveTag")]
    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void RemoveTag(string tag);

    [FreeFunction("InternalEditorUtilityBindings::AddTag")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void AddTag(string tag);

    public static extern string[] tags { [FreeFunction("InternalEditorUtilityBindings::GetTags"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    public static extern string[] layers { [FreeFunction("InternalEditorUtilityBindings::GetLayers"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    [FreeFunction("InternalEditorUtilityBindings::GetLayersWithId")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string[] GetLayersWithId();

    [FreeFunction("InternalEditorUtilityBindings::CanRenameAssetInternal")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool CanRenameAsset(int instanceID);

    public static LayerMask ConcatenatedLayersMaskToLayerMask(int concatenatedLayersMask)
    {
      return (LayerMask) InternalEditorUtility.ConcatenatedLayersMaskToLayerMaskInternal(concatenatedLayersMask);
    }

    [FreeFunction("InternalEditorUtilityBindings::ConcatenatedLayersMaskToLayerMaskInternal")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int ConcatenatedLayersMaskToLayerMaskInternal(int concatenatedLayersMask);

    public static int LayerMaskToConcatenatedLayersMask(LayerMask mask)
    {
      return InternalEditorUtility.LayerMaskToConcatenatedLayersMaskInternal((int) mask);
    }

    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetSortingLayerName(int index);

    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int GetSortingLayerUniqueID(int index);

    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetSortingLayerNameFromUniqueID(int id);

    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int GetSortingLayerCount();

    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetSortingLayerName(int index, string name);

    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetSortingLayerLocked(int index, bool locked);

    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool GetSortingLayerLocked(int index);

    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsSortingLayerDefault(int index);

    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void AddSortingLayer();

    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void UpdateSortingLayersOrder();

    internal static extern string[] sortingLayerNames { [FreeFunction("InternalEditorUtilityBindings::GetSortingLayerNames"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static extern int[] sortingLayerUniqueIDs { [FreeFunction("InternalEditorUtilityBindings::GetSortingLayerUniqueIDs"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    [FreeFunction("InternalEditorUtilityBindings::GetSpriteOuterUV")]
    public static Vector4 GetSpriteOuterUV([NotNull] Sprite sprite, bool getAtlasData)
    {
      Vector4 ret;
      InternalEditorUtility.GetSpriteOuterUV_Injected(sprite, getAtlasData, out ret);
      return ret;
    }

    [FreeFunction("PPtr<Object>")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object GetObjectFromInstanceID(int instanceID);

    [FreeFunction("GetTypeWithoutLoadingObject")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern System.Type GetTypeWithoutLoadingObject(int instanceID);

    [FreeFunction("Object::IDToPointer")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern UnityEngine.Object GetLoadedObjectFromInstanceID(int instanceID);

    [NativeMethod("LayerToString")]
    [StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetLayerName(int layer);

    public static extern string unityPreferencesFolder { [FreeFunction, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetAssetsFolder();

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetEditorFolder();

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool IsInEditorFolder(string path);

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ReloadWindowLayoutMenu();

    [FreeFunction("RevertFactorySettings")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void RevertFactoryLayoutSettings(bool quitOnCancel);

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void LoadDefaultLayout();

    [StaticAccessor("GetRenderSettings()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void CalculateAmbientProbeFromSkybox();

    [FreeFunction("SetupShaderPopupMenu")]
    [Obsolete("SetupShaderMenu is obsolete. You can get list of available shaders with ShaderUtil.GetAllShaderInfos", false)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetupShaderMenu([NotNull] Material material);

    [FreeFunction("GetUnityBuildFullVersion")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetFullUnityVersion();

    public static Version GetUnityVersion()
    {
      Version version = new Version(InternalEditorUtility.GetUnityVersionDigits());
      return new Version(version.Major, version.Minor, version.Build, InternalEditorUtility.GetUnityRevision());
    }

    [FreeFunction("InternalEditorUtilityBindings::GetUnityVersionDigits")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetUnityVersionDigits();

    [FreeFunction("GetUnityBuildBranchName")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetUnityBuildBranch();

    [FreeFunction("GetUnityBuildTimeSinceEpoch")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetUnityVersionDate();

    [FreeFunction("GetUnityBuildNumericRevision")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetUnityRevision();

    [FreeFunction("InternalEditorUtilityBindings::IsUnityBeta")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool IsUnityBeta();

    [FreeFunction("InternalEditorUtilityBindings::GetUnityCopyright")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetUnityCopyright();

    [FreeFunction("InternalEditorUtilityBindings::GetLicenseInfoText")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetLicenseInfo();

    [FreeFunction("InternalEditorUtilityBindings::GetLicenseFlags")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int[] GetLicenseFlags();

    [FreeFunction("InternalEditorUtilityBindings::GetAuthToken")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetAuthToken();

    [FreeFunction("InternalEditorUtilityBindings::OpenEditorConsole")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void OpenEditorConsole();

    [FreeFunction("InternalEditorUtilityBindings::GetGameObjectInstanceIDFromComponent")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetGameObjectInstanceIDFromComponent(int instanceID);

    [FreeFunction("InternalEditorUtilityBindings::ReadScreenPixel")]
    public static Color[] ReadScreenPixel(Vector2 pixelPos, int sizex, int sizey)
    {
      return InternalEditorUtility.ReadScreenPixel_Injected(ref pixelPos, sizex, sizey);
    }

    [FreeFunction("InternalEditorUtilityBindings::ReadScreenPixelUnderCursor")]
    public static Color[] ReadScreenPixelUnderCursor(
      Vector2 cursorPosHint,
      int sizex,
      int sizey)
    {
      return InternalEditorUtility.ReadScreenPixelUnderCursor_Injected(ref cursorPosHint, sizex, sizey);
    }

    [StaticAccessor("GetGpuDeviceManager()", StaticAccessorType.Dot)]
    [NativeMethod("SetDevice")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetGpuDeviceAndRecreateGraphics(int index, string name);

    [NativeMethod("IsSupported")]
    [StaticAccessor("GetGpuDeviceManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool IsGpuDeviceSelectionSupported();

    [FreeFunction("InternalEditorUtilityBindings::GetGpuDevices")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string[] GetGpuDevices();

    [FreeFunction("InternalEditorUtilityBindings::OpenPlayerConsole")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void OpenPlayerConsole();

    public static string TextifyEvent(Event evt)
    {
      if (evt == null)
        return "none";
      KeyCode keyCode = evt.keyCode;
      string str;
      switch (keyCode)
      {
        case KeyCode.Keypad0:
          str = "[0]";
          break;
        case KeyCode.Keypad1:
          str = "[1]";
          break;
        case KeyCode.Keypad2:
          str = "[2]";
          break;
        case KeyCode.Keypad3:
          str = "[3]";
          break;
        case KeyCode.Keypad4:
          str = "[4]";
          break;
        case KeyCode.Keypad5:
          str = "[5]";
          break;
        case KeyCode.Keypad6:
          str = "[6]";
          break;
        case KeyCode.Keypad7:
          str = "[7]";
          break;
        case KeyCode.Keypad8:
          str = "[8]";
          break;
        case KeyCode.Keypad9:
          str = "[9]";
          break;
        case KeyCode.KeypadPeriod:
          str = "[.]";
          break;
        case KeyCode.KeypadDivide:
          str = "[/]";
          break;
        case KeyCode.KeypadMinus:
          str = "[-]";
          break;
        case KeyCode.KeypadPlus:
          str = "[+]";
          break;
        case KeyCode.KeypadEnter:
          str = "enter";
          break;
        case KeyCode.KeypadEquals:
          str = "[=]";
          break;
        case KeyCode.UpArrow:
          str = "up";
          break;
        case KeyCode.DownArrow:
          str = "down";
          break;
        case KeyCode.RightArrow:
          str = "right";
          break;
        case KeyCode.LeftArrow:
          str = "left";
          break;
        case KeyCode.Insert:
          str = "insert";
          break;
        case KeyCode.Home:
          str = "home";
          break;
        case KeyCode.End:
          str = "end";
          break;
        case KeyCode.PageUp:
          str = "page up";
          break;
        case KeyCode.PageDown:
          str = "page down";
          break;
        case KeyCode.F1:
          str = "F1";
          break;
        case KeyCode.F2:
          str = "F2";
          break;
        case KeyCode.F3:
          str = "F3";
          break;
        case KeyCode.F4:
          str = "F4";
          break;
        case KeyCode.F5:
          str = "F5";
          break;
        case KeyCode.F6:
          str = "F6";
          break;
        case KeyCode.F7:
          str = "F7";
          break;
        case KeyCode.F8:
          str = "F8";
          break;
        case KeyCode.F9:
          str = "F9";
          break;
        case KeyCode.F10:
          str = "F10";
          break;
        case KeyCode.F11:
          str = "F11";
          break;
        case KeyCode.F12:
          str = "F12";
          break;
        case KeyCode.F13:
          str = "F13";
          break;
        case KeyCode.F14:
          str = "F14";
          break;
        case KeyCode.F15:
          str = "F15";
          break;
        default:
          str = keyCode == KeyCode.Backspace ? "backspace" : (keyCode == KeyCode.Return ? "return" : (keyCode == KeyCode.Escape ? "[esc]" : (keyCode == KeyCode.Delete ? "delete" : "" + (object) evt.keyCode)));
          break;
      }
      string empty = string.Empty;
      if (evt.alt)
        empty += "Alt+";
      if (evt.command)
        empty += Application.platform != RuntimePlatform.OSXEditor ? "Ctrl+" : "Cmd+";
      if (evt.control)
        empty += "Ctrl+";
      if (evt.shift)
        empty += "Shift+";
      return empty + str;
    }

    [StaticAccessor("GetPlayerSettings()", StaticAccessorType.Dot)]
    [NativeProperty("defaultScreenWidth", TargetType.Field)]
    public static extern float defaultScreenWidth { [MethodImpl(MethodImplOptions.InternalCall)] get; }

    [NativeProperty("defaultScreenHeight", TargetType.Field)]
    [StaticAccessor("GetPlayerSettings()", StaticAccessorType.Dot)]
    public static extern float defaultScreenHeight { [MethodImpl(MethodImplOptions.InternalCall)] get; }

    [StaticAccessor("GetPlayerSettings()", StaticAccessorType.Dot)]
    [NativeProperty("defaultWebScreenWidth", TargetType.Field)]
    public static extern float defaultWebScreenWidth { [MethodImpl(MethodImplOptions.InternalCall)] get; }

    [StaticAccessor("GetPlayerSettings()", StaticAccessorType.Dot)]
    [NativeProperty("defaultWebScreenHeight", TargetType.Field)]
    public static extern float defaultWebScreenHeight { [MethodImpl(MethodImplOptions.InternalCall)] get; }

    public static extern float remoteScreenWidth { [FreeFunction("RemoteScreenWidth"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    public static extern float remoteScreenHeight { [FreeFunction("RemoteScreenHeight"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string[] GetAvailableDiffTools();

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetNoDiffToolsDetectedMessage();

    [FreeFunction("InternalEditorUtilityBindings::TransformBounds")]
    public static Bounds TransformBounds(Bounds b, Transform t)
    {
      Bounds ret;
      InternalEditorUtility.TransformBounds_Injected(ref b, t, out ret);
      return ret;
    }

    [NativeMethod("SetCustomLighting")]
    [StaticAccessor("CustomLighting::Get()", StaticAccessorType.Dot)]
    public static void SetCustomLightingInternal(Light[] lights, Color ambient)
    {
      InternalEditorUtility.SetCustomLightingInternal_Injected(lights, ref ambient);
    }

    public static void SetCustomLighting(Light[] lights, Color ambient)
    {
      if (lights == null)
        throw new ArgumentNullException(nameof (lights));
      InternalEditorUtility.SetCustomLightingInternal(lights, ambient);
    }

    [StaticAccessor("CustomLighting::Get()", StaticAccessorType.Dot)]
    [NativeMethod("RestoreSceneLighting")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void RemoveCustomLighting();

    [StaticAccessor("GetRenderManager()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasFullscreenCamera();

    [FreeFunction]
    public static Bounds CalculateSelectionBounds(
      bool usePivotOnlyForParticles,
      bool onlyUseActiveSelection)
    {
      Bounds ret;
      InternalEditorUtility.CalculateSelectionBounds_Injected(usePivotOnlyForParticles, onlyUseActiveSelection, out ret);
      return ret;
    }

    internal static Bounds CalculateSelectionBoundsInSpace(
      Vector3 position,
      Quaternion rotation,
      bool rectBlueprintMode)
    {
      Quaternion quaternion = Quaternion.Inverse(rotation);
      Vector3 vector3_1 = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
      Vector3 vector3_2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
      Vector3[] vector3Array = new Vector3[2];
      foreach (GameObject gameObject in Selection.gameObjects)
      {
        Bounds localBounds = InternalEditorUtility.GetLocalBounds(gameObject);
        vector3Array[0] = localBounds.min;
        vector3Array[1] = localBounds.max;
        for (int index1 = 0; index1 < 2; ++index1)
        {
          for (int index2 = 0; index2 < 2; ++index2)
          {
            for (int index3 = 0; index3 < 2; ++index3)
            {
              Vector3 position1 = new Vector3(vector3Array[index1].x, vector3Array[index2].y, vector3Array[index3].z);
              if (rectBlueprintMode && InternalEditorUtility.SupportsRectLayout(gameObject.transform))
              {
                Vector3 localPosition = gameObject.transform.localPosition;
                localPosition.z = 0.0f;
                position1 = gameObject.transform.parent.TransformPoint(position1 + localPosition);
              }
              else
                position1 = gameObject.transform.TransformPoint(position1);
              position1 = quaternion * (position1 - position);
              for (int index4 = 0; index4 < 3; ++index4)
              {
                vector3_1[index4] = Mathf.Min(vector3_1[index4], position1[index4]);
                vector3_2[index4] = Mathf.Max(vector3_2[index4], position1[index4]);
              }
            }
          }
        }
      }
      return new Bounds((vector3_1 + vector3_2) * 0.5f, vector3_2 - vector3_1);
    }

    internal static bool SupportsRectLayout(Transform tr)
    {
      return !((UnityEngine.Object) tr == (UnityEngine.Object) null) && !((UnityEngine.Object) tr.parent == (UnityEngine.Object) null) && (!((UnityEngine.Object) tr.GetComponent<RectTransform>() == (UnityEngine.Object) null) && !((UnityEngine.Object) tr.parent.GetComponent<RectTransform>() == (UnityEngine.Object) null));
    }

    private static Bounds GetLocalBounds(GameObject gameObject)
    {
      RectTransform component1 = gameObject.GetComponent<RectTransform>();
      if ((bool) ((UnityEngine.Object) component1))
        return new Bounds((Vector3) component1.rect.center, (Vector3) component1.rect.size);
      Renderer component2 = gameObject.GetComponent<Renderer>();
      if (component2 is MeshRenderer)
      {
        MeshFilter component3 = component2.GetComponent<MeshFilter>();
        if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && (UnityEngine.Object) component3.sharedMesh != (UnityEngine.Object) null)
          return component3.sharedMesh.bounds;
      }
      if (component2 is SpriteRenderer)
        return ((SpriteRenderer) component2).GetSpriteBounds();
      if (component2 is SpriteMask)
        return ((SpriteMask) component2).GetSpriteBounds();
      if (component2 is SpriteShapeRenderer)
        return ((SpriteShapeRenderer) component2).GetLocalAABB();
      if (component2 is TilemapRenderer)
      {
        Tilemap component3 = component2.GetComponent<Tilemap>();
        if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
          return component3.localBounds;
      }
      return new Bounds(Vector3.zero, Vector3.zero);
    }

    [FreeFunction("SetPlayerFocus")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void OnGameViewFocus(bool focus);

    [FreeFunction("OpenScriptFile")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool OpenFileAtLineExternal(string filename, int line);

    [FreeFunction("AssetDatabaseDeprecated::CanConnectToCacheServer")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool CanConnectToCacheServer();

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern DllType DetectDotNetDll(string path);

    public static bool IsDotNet4Dll(string path)
    {
      DllType dllType = InternalEditorUtility.DetectDotNetDll(path);
      switch (dllType)
      {
        case DllType.Unknown:
        case DllType.Native:
        case DllType.UnknownManaged:
        case DllType.ManagedNET35:
          return false;
        case DllType.ManagedNET40:
        case DllType.WinMDNative:
        case DllType.WinMDNET40:
          return true;
        default:
          throw new Exception(string.Format("Unknown dll type: {0}", (object) dllType));
      }
    }

    internal static bool RunningUnderWindows8(bool orHigher = true)
    {
      if (Application.platform != RuntimePlatform.WindowsEditor)
        return false;
      OperatingSystem osVersion = Environment.OSVersion;
      int major = osVersion.Version.Major;
      int minor = osVersion.Version.Minor;
      if (orHigher)
        return major > 6 || major == 6 && minor >= 2;
      return major == 6 && minor == 2;
    }

    [FreeFunction("ScriptingManager::GetClasslibsProfile")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetEditorProfile();

    [StaticAccessor("UnityExtensions::Get()", StaticAccessorType.Dot)]
    [NativeMethod("IsInitialized")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsUnityExtensionsInitialized();

    [FreeFunction("UnityExtensions::IsValidExtensionPath")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsValidUnityExtensionPath(string path);

    [StaticAccessor("UnityExtensions::Get()", StaticAccessorType.Dot)]
    [NativeMethod("IsRegistered")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsUnityExtensionRegistered(string filename);

    [NativeMethod("IsCompatibleWithEditor")]
    [StaticAccessor("UnityExtensions::Get()", StaticAccessorType.Dot)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsUnityExtensionCompatibleWithEditor(
      BuildTargetGroup targetGroup,
      BuildTarget target,
      string path);

    [FreeFunction("GetAllEditorModuleNames")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string[] GetEditorModuleDllNames();

    [FreeFunction(IsThreadSafe = true)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool CurrentThreadIsMainThread();

    internal static extern bool canRenameSelectedAssets { [FreeFunction("CanRenameSelectedAssets"), MethodImpl(MethodImplOptions.InternalCall)] get; }

    [FreeFunction("InternalEditorUtilityBindings::GetCrashReportFolder")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetCrashReportFolder();

    [FreeFunction("InternalEditorUtilityBindings::DrawSkyboxMaterial")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void DrawSkyboxMaterial([NotNull] Material mat, [NotNull] Camera cam);

    [FreeFunction("InternalEditorUtilityBindings::ResetCursor")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ResetCursor();

    [FreeFunction("InternalEditorUtilityBindings::VerifyCacheServerIntegrity")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong VerifyCacheServerIntegrity();

    [FreeFunction("InternalEditorUtilityBindings::FixCacheServerIntegrityErrors")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ulong FixCacheServerIntegrityErrors();

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int DetermineDepthOrder(Transform lhs, Transform rhs);

    internal static PrecompiledAssembly[] GetUnityAssemblies(
      bool buildingForEditor,
      BuildTargetGroup buildTargetGroup,
      BuildTarget target)
    {
      return InternalEditorUtility.GetUnityAssembliesInternal(buildingForEditor, target);
    }

    [FreeFunction("GetUnityAssembliesManaged")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern PrecompiledAssembly[] GetUnityAssembliesInternal(
      bool buildingForEditor,
      BuildTarget target);

    [FreeFunction("GetPrecompiledAssembliesManaged")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern PrecompiledAssembly[] GetPrecompiledAssemblies(
      bool buildingForEditor,
      BuildTargetGroup buildTargetGroup,
      BuildTarget target);

    [FreeFunction]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ShowPackageManagerWindow();

    [FreeFunction("InternalEditorUtilityBindings::PassAndReturnVector2")]
    public static Vector2 PassAndReturnVector2(Vector2 v)
    {
      Vector2 ret;
      InternalEditorUtility.PassAndReturnVector2_Injected(ref v, out ret);
      return ret;
    }

    [FreeFunction("InternalEditorUtilityBindings::PassAndReturnColor32")]
    public static Color32 PassAndReturnColor32(Color32 c)
    {
      Color32 ret;
      InternalEditorUtility.PassAndReturnColor32_Injected(ref c, out ret);
      return ret;
    }

    [FreeFunction("InternalEditorUtilityBindings::SaveCursorToFile")]
    public static bool SaveCursorToFile(string path, Texture2D image, Vector2 hotSpot)
    {
      return InternalEditorUtility.SaveCursorToFile_Injected(path, image, ref hotSpot);
    }

    [FreeFunction("GetScriptCompilationDefines")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string[] GetCompilationDefines(
      EditorScriptCompilationOptions options,
      BuildTargetGroup targetGroup,
      BuildTarget target,
      ApiCompatibilityLevel apiCompatibilityLevel);

    [FreeFunction("LaunchApplication")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool LaunchApplication(string path, string[] arguments);

    public static string CountToString(ulong count)
    {
      string[] strArray = new string[4]{ "G", "M", "k", "" };
      float[] numArray = new float[4]
      {
        1E+09f,
        1000000f,
        1000f,
        1f
      };
      int index = 0;
      while (index < 3 && (double) count < (double) numArray[index] / 2.0)
        ++index;
      return ((float) count / numArray[index]).ToString("0.0") + strArray[index];
    }

    [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)]
    [Obsolete("use EditorSceneManager.EnsureUntitledSceneHasBeenSaved")]
    [NativeMethod("EnsureUntitledSceneHasBeenSaved")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool EnsureSceneHasBeenSaved(string operation);

    internal static void PrepareDragAndDropTesting(EditorWindow editorWindow)
    {
      if (!((UnityEngine.Object) editorWindow.m_Parent != (UnityEngine.Object) null))
        return;
      InternalEditorUtility.PrepareDragAndDropTestingInternal((GUIView) editorWindow.m_Parent);
    }

    [FreeFunction("InternalEditorUtilityBindings::PrepareDragAndDropTestingInternal")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void PrepareDragAndDropTestingInternal(GUIView guiView);

    [FreeFunction("InternalEditorUtilityBindings::LayerMaskToConcatenatedLayersMaskInternal")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int LayerMaskToConcatenatedLayersMaskInternal(int mask);

    public static Texture2D FindIconForFile(string fileName)
    {
      int num1 = fileName.LastIndexOf('.');
      string key = num1 != -1 ? fileName.Substring(num1 + 1).ToLower() : "";
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (InternalEditorUtility.\u003C\u003Ef__switch\u0024map2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          InternalEditorUtility.\u003C\u003Ef__switch\u0024map2 = new Dictionary<string, int>(135)
          {
            {
              "asset",
              0
            },
            {
              "cginc",
              1
            },
            {
              "cs",
              2
            },
            {
              "guiskin",
              3
            },
            {
              "dll",
              4
            },
            {
              "asmdef",
              5
            },
            {
              "mat",
              6
            },
            {
              "physicmaterial",
              7
            },
            {
              "prefab",
              8
            },
            {
              "shader",
              9
            },
            {
              "txt",
              10
            },
            {
              "unity",
              11
            },
            {
              "prefs",
              12
            },
            {
              "anim",
              13
            },
            {
              "meta",
              14
            },
            {
              "mixer",
              15
            },
            {
              "uxml",
              16
            },
            {
              "uss",
              17
            },
            {
              "ttf",
              18
            },
            {
              "otf",
              18
            },
            {
              "fon",
              18
            },
            {
              "fnt",
              18
            },
            {
              "aac",
              19
            },
            {
              "aif",
              19
            },
            {
              "aiff",
              19
            },
            {
              "au",
              19
            },
            {
              "mid",
              19
            },
            {
              "midi",
              19
            },
            {
              "mp3",
              19
            },
            {
              "mpa",
              19
            },
            {
              "ra",
              19
            },
            {
              "ram",
              19
            },
            {
              "wma",
              19
            },
            {
              "wav",
              19
            },
            {
              "wave",
              19
            },
            {
              "ogg",
              19
            },
            {
              "ai",
              20
            },
            {
              "apng",
              20
            },
            {
              "png",
              20
            },
            {
              "bmp",
              20
            },
            {
              "cdr",
              20
            },
            {
              "dib",
              20
            },
            {
              "eps",
              20
            },
            {
              "exif",
              20
            },
            {
              "gif",
              20
            },
            {
              "ico",
              20
            },
            {
              "icon",
              20
            },
            {
              "j",
              20
            },
            {
              "j2c",
              20
            },
            {
              "j2k",
              20
            },
            {
              "jas",
              20
            },
            {
              "jiff",
              20
            },
            {
              "jng",
              20
            },
            {
              "jp2",
              20
            },
            {
              "jpc",
              20
            },
            {
              "jpe",
              20
            },
            {
              "jpeg",
              20
            },
            {
              "jpf",
              20
            },
            {
              "jpg",
              20
            },
            {
              "jpw",
              20
            },
            {
              "jpx",
              20
            },
            {
              "jtf",
              20
            },
            {
              "mac",
              20
            },
            {
              "omf",
              20
            },
            {
              "qif",
              20
            },
            {
              "qti",
              20
            },
            {
              "qtif",
              20
            },
            {
              "tex",
              20
            },
            {
              "tfw",
              20
            },
            {
              "tga",
              20
            },
            {
              "tif",
              20
            },
            {
              "tiff",
              20
            },
            {
              "wmf",
              20
            },
            {
              "psd",
              20
            },
            {
              "exr",
              20
            },
            {
              "hdr",
              20
            },
            {
              "3df",
              21
            },
            {
              "3dm",
              21
            },
            {
              "3dmf",
              21
            },
            {
              "3ds",
              21
            },
            {
              "3dv",
              21
            },
            {
              "3dx",
              21
            },
            {
              "blend",
              21
            },
            {
              "c4d",
              21
            },
            {
              "lwo",
              21
            },
            {
              "lws",
              21
            },
            {
              "ma",
              21
            },
            {
              "max",
              21
            },
            {
              "mb",
              21
            },
            {
              "mesh",
              21
            },
            {
              "obj",
              21
            },
            {
              "vrl",
              21
            },
            {
              "wrl",
              21
            },
            {
              "wrz",
              21
            },
            {
              "fbx",
              21
            },
            {
              "dv",
              22
            },
            {
              "mp4",
              22
            },
            {
              "mpg",
              22
            },
            {
              "mpeg",
              22
            },
            {
              "m4v",
              22
            },
            {
              "ogv",
              22
            },
            {
              "vp8",
              22
            },
            {
              "webm",
              22
            },
            {
              "asf",
              22
            },
            {
              "asx",
              22
            },
            {
              "avi",
              22
            },
            {
              "dat",
              22
            },
            {
              "divx",
              22
            },
            {
              "dvx",
              22
            },
            {
              "mlv",
              22
            },
            {
              "m2l",
              22
            },
            {
              "m2t",
              22
            },
            {
              "m2ts",
              22
            },
            {
              "m2v",
              22
            },
            {
              "m4e",
              22
            },
            {
              "mjp",
              22
            },
            {
              "mov",
              22
            },
            {
              "movie",
              22
            },
            {
              "mp21",
              22
            },
            {
              "mpe",
              22
            },
            {
              "mpv2",
              22
            },
            {
              "ogm",
              22
            },
            {
              "qt",
              22
            },
            {
              "rm",
              22
            },
            {
              "rmvb",
              22
            },
            {
              "wmw",
              22
            },
            {
              "xvid",
              22
            },
            {
              "colors",
              23
            },
            {
              "gradients",
              23
            },
            {
              "curves",
              23
            },
            {
              "curvesnormalized",
              23
            },
            {
              "particlecurves",
              23
            },
            {
              "particlecurvessigned",
              23
            },
            {
              "particledoublecurves",
              23
            },
            {
              "particledoublecurvessigned",
              23
            }
          };
        }
        int num2;
        // ISSUE: reference to a compiler-generated field
        if (InternalEditorUtility.\u003C\u003Ef__switch\u0024map2.TryGetValue(key, out num2))
        {
          switch (num2)
          {
            case 0:
              return AssetDatabase.GetCachedIcon(fileName) as Texture2D ?? EditorGUIUtility.FindTexture("GameManager Icon");
            case 1:
              return EditorGUIUtility.FindTexture("CGProgram Icon");
            case 2:
              return EditorGUIUtility.FindTexture("cs Script Icon");
            case 3:
              return EditorGUIUtility.FindTexture(typeof (GUISkin));
            case 4:
              return EditorGUIUtility.FindTexture("Assembly Icon");
            case 5:
              return EditorGUIUtility.FindTexture(typeof (AssemblyDefinitionAsset));
            case 6:
              return EditorGUIUtility.FindTexture(typeof (Material));
            case 7:
              return EditorGUIUtility.FindTexture(typeof (PhysicMaterial));
            case 8:
              return EditorGUIUtility.FindTexture("Prefab Icon");
            case 9:
              return EditorGUIUtility.FindTexture(typeof (Shader));
            case 10:
              return EditorGUIUtility.FindTexture(typeof (TextAsset));
            case 11:
              return EditorGUIUtility.FindTexture(typeof (SceneAsset));
            case 12:
              return EditorGUIUtility.FindTexture(typeof (EditorSettings));
            case 13:
              return EditorGUIUtility.FindTexture(typeof (Animation));
            case 14:
              return EditorGUIUtility.FindTexture("MetaFile Icon");
            case 15:
              return EditorGUIUtility.FindTexture(typeof (AudioMixerController));
            case 16:
              return EditorGUIUtility.FindTexture(typeof (VisualTreeAsset));
            case 17:
              return EditorGUIUtility.FindTexture(typeof (StyleSheet));
            case 18:
              return EditorGUIUtility.FindTexture(typeof (Font));
            case 19:
              return EditorGUIUtility.FindTexture(typeof (AudioClip));
            case 20:
              return EditorGUIUtility.FindTexture(typeof (Texture));
            case 21:
              return EditorGUIUtility.FindTexture(typeof (Mesh));
            case 22:
              return AssetDatabase.GetCachedIcon(fileName) as Texture2D ?? EditorGUIUtility.FindTexture(typeof (VideoClip));
            case 23:
              return EditorGUIUtility.FindTexture(typeof (ScriptableObject));
          }
        }
      }
      return (Texture2D) null;
    }

    public static Texture2D GetIconForFile(string fileName)
    {
      return InternalEditorUtility.FindIconForFile(fileName) ?? EditorGUIUtility.FindTexture(typeof (DefaultAsset));
    }

    public static string[] GetEditorSettingsList(string prefix, int count)
    {
      ArrayList arrayList = new ArrayList();
      for (int index = 1; index <= count; ++index)
      {
        string str = EditorPrefs.GetString(prefix + (object) index, "defaultValue");
        if (!(str == "defaultValue"))
          arrayList.Add((object) str);
        else
          break;
      }
      return arrayList.ToArray(typeof (string)) as string[];
    }

    public static void SaveEditorSettingsList(string prefix, string[] aList, int count)
    {
      for (int index = 0; index < aList.Length; ++index)
        EditorPrefs.SetString(prefix + (object) (index + 1), aList[index]);
      for (int index = aList.Length + 1; index <= count; ++index)
        EditorPrefs.DeleteKey(prefix + (object) index);
    }

    public static string TextAreaForDocBrowser(Rect position, string text, GUIStyle style)
    {
      int controlId = GUIUtility.GetControlID("TextAreaWithTabHandling".GetHashCode(), FocusType.Keyboard, position);
      EditorGUI.RecycledTextEditor recycledEditor = EditorGUI.s_RecycledEditor;
      Event current = Event.current;
      if (recycledEditor.IsEditingControl(controlId) && current.type == EventType.KeyDown)
      {
        if (current.character == '\t')
        {
          recycledEditor.Insert('\t');
          current.Use();
          GUI.changed = true;
          text = recycledEditor.text;
        }
        if (current.character == '\n')
        {
          recycledEditor.Insert('\n');
          current.Use();
          GUI.changed = true;
          text = recycledEditor.text;
        }
      }
      bool changed;
      text = EditorGUI.DoTextField(recycledEditor, controlId, EditorGUI.IndentedRect(position), text, style, (string) null, out changed, false, true, false);
      return text;
    }

    public static Camera[] GetSceneViewCameras()
    {
      return SceneView.GetAllSceneCameras();
    }

    public static void ShowGameView()
    {
      WindowLayout.ShowAppropriateViewOnEnterExitPlaymode(true);
    }

    public static List<int> GetNewSelection(
      int clickedInstanceID,
      List<int> allInstanceIDs,
      List<int> selectedInstanceIDs,
      int lastClickedInstanceID,
      bool keepMultiSelection,
      bool useShiftAsActionKey,
      bool allowMultiSelection)
    {
      List<int> intList = new List<int>();
      bool flag1 = Event.current.shift || EditorGUI.actionKey && useShiftAsActionKey;
      bool flag2 = EditorGUI.actionKey && !useShiftAsActionKey;
      if (!allowMultiSelection)
        flag1 = flag2 = false;
      if (flag2)
      {
        intList.AddRange((IEnumerable<int>) selectedInstanceIDs);
        if (intList.Contains(clickedInstanceID))
          intList.Remove(clickedInstanceID);
        else
          intList.Add(clickedInstanceID);
      }
      else if (flag1)
      {
        if (clickedInstanceID == lastClickedInstanceID)
        {
          intList.AddRange((IEnumerable<int>) selectedInstanceIDs);
          return intList;
        }
        int firstIndex;
        int lastIndex;
        if (!InternalEditorUtility.GetFirstAndLastSelected(allInstanceIDs, selectedInstanceIDs, out firstIndex, out lastIndex))
        {
          intList.Add(clickedInstanceID);
          return intList;
        }
        int num1 = -1;
        int num2 = -1;
        for (int index = 0; index < allInstanceIDs.Count; ++index)
        {
          if (allInstanceIDs[index] == clickedInstanceID)
            num1 = index;
          if (lastClickedInstanceID != 0 && allInstanceIDs[index] == lastClickedInstanceID)
            num2 = index;
        }
        int num3 = 0;
        if (num2 != -1)
          num3 = num1 <= num2 ? -1 : 1;
        int num4;
        int num5;
        if (num1 > lastIndex)
        {
          num4 = firstIndex;
          num5 = num1;
        }
        else if (num1 >= firstIndex && num1 < lastIndex)
        {
          if (num3 > 0)
          {
            num4 = num1;
            num5 = lastIndex;
          }
          else
          {
            num4 = firstIndex;
            num5 = num1;
          }
        }
        else
        {
          num4 = num1;
          num5 = lastIndex;
        }
        for (int index = num4; index <= num5; ++index)
          intList.Add(allInstanceIDs[index]);
      }
      else
      {
        if (keepMultiSelection && selectedInstanceIDs.Contains(clickedInstanceID))
        {
          intList.AddRange((IEnumerable<int>) selectedInstanceIDs);
          return intList;
        }
        intList.Add(clickedInstanceID);
      }
      return intList;
    }

    private static bool GetFirstAndLastSelected(
      List<int> allInstanceIDs,
      List<int> selectedInstanceIDs,
      out int firstIndex,
      out int lastIndex)
    {
      firstIndex = -1;
      lastIndex = -1;
      for (int index = 0; index < allInstanceIDs.Count; ++index)
      {
        if (selectedInstanceIDs.Contains(allInstanceIDs[index]))
        {
          if (firstIndex == -1)
            firstIndex = index;
          lastIndex = index;
        }
      }
      return firstIndex != -1 && lastIndex != -1;
    }

    internal static string GetApplicationExtensionForRuntimePlatform(RuntimePlatform platform)
    {
      if (platform == RuntimePlatform.OSXEditor)
        return "app";
      if (platform == RuntimePlatform.WindowsEditor)
        return "exe";
      return string.Empty;
    }

    public static bool IsValidFileName(string filename)
    {
      string str = InternalEditorUtility.RemoveInvalidCharsFromFileName(filename, false);
      return !(str != filename) && !string.IsNullOrEmpty(str);
    }

    public static string RemoveInvalidCharsFromFileName(string filename, bool logIfInvalidChars)
    {
      if (string.IsNullOrEmpty(filename))
        return filename;
      filename = filename.Trim();
      if (string.IsNullOrEmpty(filename))
        return filename;
      string str1 = new string(Path.GetInvalidFileNameChars());
      string str2 = "";
      bool flag = false;
      foreach (char ch in filename)
      {
        if (str1.IndexOf(ch) == -1)
          str2 += (string) (object) ch;
        else
          flag = true;
      }
      if (flag && logIfInvalidChars)
      {
        string invalidCharsOfFileName = InternalEditorUtility.GetDisplayStringOfInvalidCharsOfFileName(filename);
        if (invalidCharsOfFileName.Length > 0)
          Debug.LogWarningFormat("A filename cannot contain the following character{0}:  {1}", invalidCharsOfFileName.Length <= 1 ? (object) "" : (object) "s", (object) invalidCharsOfFileName);
      }
      return str2;
    }

    public static string GetDisplayStringOfInvalidCharsOfFileName(string filename)
    {
      if (string.IsNullOrEmpty(filename))
        return "";
      string str1 = new string(Path.GetInvalidFileNameChars());
      string str2 = "";
      foreach (char ch in filename)
      {
        if (str1.IndexOf(ch) >= 0 && str2.IndexOf(ch) == -1)
        {
          if (str2.Length > 0)
            str2 += " ";
          str2 += (string) (object) ch;
        }
      }
      return str2;
    }

    internal static bool IsScriptOrAssembly(string filename)
    {
      if (string.IsNullOrEmpty(filename))
        return false;
      switch (Path.GetExtension(filename).ToLower())
      {
        case ".cs":
        case ".js":
        case ".boo":
          return true;
        case ".dll":
        case ".exe":
          return AssemblyHelper.IsManagedAssembly(filename);
        default:
          return false;
      }
    }

    internal static T ParentHasComponent<T>(Transform trans) where T : Component
    {
      if (!((UnityEngine.Object) trans != (UnityEngine.Object) null))
        return (T) null;
      T component = trans.GetComponent<T>();
      if ((bool) ((UnityEngine.Object) component))
        return component;
      return InternalEditorUtility.ParentHasComponent<T>(trans.parent);
    }

    internal static IEnumerable<string> GetAllScriptGUIDs()
    {
      return ((IEnumerable<string>) AssetDatabase.GetAllAssetPaths()).Where<string>((Func<string, bool>) (asset => InternalEditorUtility.IsScriptOrAssembly(asset) && !Folders.IsPackagedAssetPath(asset))).Select<string, string>((Func<string, string>) (asset => AssetDatabase.AssetPathToGUID(asset)));
    }

    internal static MonoIsland[] GetMonoIslandsForPlayer()
    {
      BuildTargetGroup buildTargetGroup = EditorUserBuildSettings.activeBuildTargetGroup;
      BuildTarget activeBuildTarget = EditorUserBuildSettings.activeBuildTarget;
      return EditorCompilationInterface.Instance.GetAllMonoIslands(InternalEditorUtility.GetUnityAssemblies(false, buildTargetGroup, activeBuildTarget), InternalEditorUtility.GetPrecompiledAssemblies(false, buildTargetGroup, activeBuildTarget), EditorScriptCompilationOptions.BuildingIncludingTestAssemblies);
    }

    internal static MonoIsland[] GetMonoIslands()
    {
      return EditorCompilationInterface.GetAllMonoIslands();
    }

    internal static string[] GetCompilationDefinesForPlayer()
    {
      return InternalEditorUtility.GetCompilationDefines(EditorScriptCompilationOptions.BuildingEmpty, EditorUserBuildSettings.activeBuildTargetGroup, EditorUserBuildSettings.activeBuildTarget);
    }

    internal static string GetMonolithicEngineAssemblyPath()
    {
      return Path.Combine(Path.GetDirectoryName(InternalEditorUtility.GetEditorAssemblyPath()), "UnityEngine.dll");
    }

    internal static string[] GetCompilationDefines(
      EditorScriptCompilationOptions options,
      BuildTargetGroup targetGroup,
      BuildTarget target)
    {
      return InternalEditorUtility.GetCompilationDefines(options, targetGroup, target, PlayerSettings.GetApiCompatibilityLevel(targetGroup));
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern DragAndDropVisualMode SceneViewDrag_Injected(
      UnityEngine.Object dropUpon,
      ref Vector3 worldPosition,
      ref Vector2 viewportPosition,
      Transform parentForDraggedObjects,
      bool perform);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetRectTransformTemporaryRect_Injected(
      RectTransform rectTransform,
      ref Rect rect);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void GetBoundsOfDesktopAtPoint_Injected(ref Vector2 pos, out Rect ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void GetSpriteOuterUV_Injected(
      Sprite sprite,
      bool getAtlasData,
      out Vector4 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Color[] ReadScreenPixel_Injected(
      ref Vector2 pixelPos,
      int sizex,
      int sizey);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Color[] ReadScreenPixelUnderCursor_Injected(
      ref Vector2 cursorPosHint,
      int sizex,
      int sizey);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void TransformBounds_Injected(ref Bounds b, Transform t, out Bounds ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetCustomLightingInternal_Injected(Light[] lights, ref Color ambient);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void CalculateSelectionBounds_Injected(
      bool usePivotOnlyForParticles,
      bool onlyUseActiveSelection,
      out Bounds ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void PassAndReturnVector2_Injected(ref Vector2 v, out Vector2 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void PassAndReturnColor32_Injected(ref Color32 c, out Color32 ret);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool SaveCursorToFile_Injected(
      string path,
      Texture2D image,
      ref Vector2 hotSpot);

    public enum HierarchyDropMode
    {
      kHierarchyDragNormal = 0,
      kHierarchyDropUpon = 1,
      kHierarchyDropBetween = 2,
      kHierarchyDropAfterParent = 4,
      kHierarchySearchActive = 8,
    }
  }
}
