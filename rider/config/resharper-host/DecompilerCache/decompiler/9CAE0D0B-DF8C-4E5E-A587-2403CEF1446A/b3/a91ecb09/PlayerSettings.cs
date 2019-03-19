// Decompiled with JetBrains decompiler
// Type: UnityEditor.PlayerSettings
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CAE0D0B-DF8C-4E5E-A587-2403CEF1446A
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEditor.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEditor.Build;
using UnityEditor.Rendering;
using UnityEditor.XR.Daydream;
using UnityEditorInternal;
using UnityEditorInternal.VR;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.iOS;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEditor
{
  /// <summary>
  ///   <para>Player Settings is where you define various parameters for the final game that you will build in Unity. Some of these values are used in the Resolution Dialog that launches when you open a standalone game.</para>
  /// </summary>
  public sealed class PlayerSettings : UnityEngine.Object
  {
    internal static readonly char[] defineSplits = new char[3]
    {
      ';',
      ',',
      ' '
    };
    private static SerializedObject _serializedObject;

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern UnityEngine.Object InternalGetPlayerSettingsObject();

    internal static SerializedObject GetSerializedObject()
    {
      if (PlayerSettings._serializedObject == null)
        PlayerSettings._serializedObject = new SerializedObject(PlayerSettings.InternalGetPlayerSettingsObject());
      return PlayerSettings._serializedObject;
    }

    internal static SerializedProperty FindProperty(string name)
    {
      SerializedProperty property = PlayerSettings.GetSerializedObject().FindProperty(name);
      if (property == null)
        Debug.LogError((object) ("Failed to find:" + name));
      return property;
    }

    /// <summary>
    ///   <para>Sets a PlayerSettings named int property.</para>
    /// </summary>
    /// <param name="name">Name of the property.</param>
    /// <param name="value">Value of the property (int).</param>
    /// <param name="target">BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown to apply to all targets).</param>
    [Obsolete("Use explicit API instead.")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetPropertyInt(string name, int value, [DefaultValue("BuildTargetGroup.Unknown")] BuildTargetGroup target);

    [ExcludeFromDocs]
    [Obsolete("Use explicit API instead.")]
    public static void SetPropertyInt(string name, int value)
    {
      BuildTargetGroup target = BuildTargetGroup.Unknown;
      PlayerSettings.SetPropertyInt(name, value, target);
    }

    [Obsolete("Use explicit API instead.")]
    public static void SetPropertyInt(string name, int value, BuildTarget target)
    {
      PlayerSettings.SetPropertyInt(name, value, BuildPipeline.GetBuildTargetGroup(target));
    }

    /// <summary>
    ///   <para>Returns a PlayerSettings named int property (with an optional build target it should apply to).</para>
    /// </summary>
    /// <param name="name">Name of the property.</param>
    /// <param name="target">BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown to apply to all targets).</param>
    /// <returns>
    ///   <para>The current value of the property.</para>
    /// </returns>
    [Obsolete("Use explicit API instead.")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetPropertyInt(string name, [DefaultValue("BuildTargetGroup.Unknown")] BuildTargetGroup target);

    [ExcludeFromDocs]
    [Obsolete("Use explicit API instead.")]
    public static int GetPropertyInt(string name)
    {
      BuildTargetGroup target = BuildTargetGroup.Unknown;
      return PlayerSettings.GetPropertyInt(name, target);
    }

    [ExcludeFromDocs]
    [Obsolete("Use explicit API instead.")]
    public static bool GetPropertyOptionalInt(string name, ref int value)
    {
      BuildTargetGroup target = BuildTargetGroup.Unknown;
      return PlayerSettings.GetPropertyOptionalInt(name, ref value, target);
    }

    [Obsolete("Use explicit API instead.")]
    public static bool GetPropertyOptionalInt(string name, ref int value, [DefaultValue("BuildTargetGroup.Unknown")] BuildTargetGroup target)
    {
      value = PlayerSettings.GetPropertyInt(name, target);
      return true;
    }

    /// <summary>
    ///   <para>Sets a PlayerSettings named bool property.</para>
    /// </summary>
    /// <param name="name">Name of the property.</param>
    /// <param name="value">Value of the property (bool).</param>
    /// <param name="target">BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown to apply to all targets).</param>
    [Obsolete("Use explicit API instead.")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetPropertyBool(string name, bool value, [DefaultValue("BuildTargetGroup.Unknown")] BuildTargetGroup target);

    [Obsolete("Use explicit API instead.")]
    [ExcludeFromDocs]
    public static void SetPropertyBool(string name, bool value)
    {
      BuildTargetGroup target = BuildTargetGroup.Unknown;
      PlayerSettings.SetPropertyBool(name, value, target);
    }

    [Obsolete("Use explicit API instead.")]
    public static void SetPropertyBool(string name, bool value, BuildTarget target)
    {
      PlayerSettings.SetPropertyBool(name, value, BuildPipeline.GetBuildTargetGroup(target));
    }

    /// <summary>
    ///   <para>Returns a PlayerSettings named bool property (with an optional build target it should apply to).</para>
    /// </summary>
    /// <param name="name">Name of the property.</param>
    /// <param name="target">BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown to apply to all targets).</param>
    /// <returns>
    ///   <para>The current value of the property.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [Obsolete("Use explicit API instead.")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool GetPropertyBool(string name, [DefaultValue("BuildTargetGroup.Unknown")] BuildTargetGroup target);

    [ExcludeFromDocs]
    [Obsolete("Use explicit API instead.")]
    public static bool GetPropertyBool(string name)
    {
      BuildTargetGroup target = BuildTargetGroup.Unknown;
      return PlayerSettings.GetPropertyBool(name, target);
    }

    [Obsolete("Use explicit API instead.")]
    [ExcludeFromDocs]
    public static bool GetPropertyOptionalBool(string name, ref bool value)
    {
      BuildTargetGroup target = BuildTargetGroup.Unknown;
      return PlayerSettings.GetPropertyOptionalBool(name, ref value, target);
    }

    [Obsolete("Use explicit API instead.")]
    public static bool GetPropertyOptionalBool(string name, ref bool value, [DefaultValue("BuildTargetGroup.Unknown")] BuildTargetGroup target)
    {
      value = PlayerSettings.GetPropertyBool(name, target);
      return true;
    }

    /// <summary>
    ///   <para>Sets a PlayerSettings named string property.</para>
    /// </summary>
    /// <param name="name">Name of the property.</param>
    /// <param name="value">Value of the property (string).</param>
    /// <param name="target">BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown to apply to all targets).</param>
    [GeneratedByOldBindingsGenerator]
    [Obsolete("Use explicit API instead.")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetPropertyString(string name, string value, [DefaultValue("BuildTargetGroup.Unknown")] BuildTargetGroup target);

    [ExcludeFromDocs]
    [Obsolete("Use explicit API instead.")]
    public static void SetPropertyString(string name, string value)
    {
      BuildTargetGroup target = BuildTargetGroup.Unknown;
      PlayerSettings.SetPropertyString(name, value, target);
    }

    [Obsolete("Use explicit API instead.")]
    public static void SetPropertyString(string name, string value, BuildTarget target)
    {
      PlayerSettings.SetPropertyString(name, value, BuildPipeline.GetBuildTargetGroup(target));
    }

    /// <summary>
    ///   <para>Returns a PlayerSettings named string property (with an optional build target it should apply to).</para>
    /// </summary>
    /// <param name="name">Name of the property.</param>
    /// <param name="target">BuildTarget for which the property should apply (use default value BuildTargetGroup.Unknown to apply to all targets).</param>
    /// <returns>
    ///   <para>The current value of the property.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [Obsolete("Use explicit API instead.")]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetPropertyString(string name, [DefaultValue("BuildTargetGroup.Unknown")] BuildTargetGroup target);

    [Obsolete("Use explicit API instead.")]
    [ExcludeFromDocs]
    public static string GetPropertyString(string name)
    {
      BuildTargetGroup target = BuildTargetGroup.Unknown;
      return PlayerSettings.GetPropertyString(name, target);
    }

    [ExcludeFromDocs]
    [Obsolete("Use explicit API instead.")]
    public static bool GetPropertyOptionalString(string name, ref string value)
    {
      BuildTargetGroup target = BuildTargetGroup.Unknown;
      return PlayerSettings.GetPropertyOptionalString(name, ref value, target);
    }

    [Obsolete("Use explicit API instead.")]
    public static bool GetPropertyOptionalString(string name, ref string value, [DefaultValue("BuildTargetGroup.Unknown")] BuildTargetGroup target)
    {
      value = PlayerSettings.GetPropertyString(name, target);
      return true;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetDirty();

    /// <summary>
    ///   <para>The name of your company.</para>
    /// </summary>
    public static extern string companyName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The name of your product.</para>
    /// </summary>
    public static extern string productName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Should the builtin Unity splash screen be shown?</para>
    /// </summary>
    [Obsolete("Use PlayerSettings.SplashScreen.show instead")]
    public static extern bool showUnitySplashScreen { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The style to use for the builtin Unity splash screen.</para>
    /// </summary>
    [Obsolete("Use PlayerSettings.SplashScreen.unityLogoStyle instead")]
    public static extern SplashScreenStyle splashScreenStyle { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>A unique cloud project identifier. It is unique for every project (Read Only).</para>
    /// </summary>
    public static string cloudProjectId
    {
      get
      {
        return PlayerSettings.cloudProjectIdRaw;
      }
      internal set
      {
        PlayerSettings.cloudProjectIdRaw = value;
      }
    }

    private static extern string cloudProjectIdRaw { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetCloudServiceEnabled(string serviceKey, bool enabled);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool GetCloudServiceEnabled(string serviceKey);

    public static Guid productGUID
    {
      get
      {
        return new Guid(PlayerSettings.productGUIDRaw);
      }
    }

    private static extern byte[] productGUIDRaw { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Set the rendering color space for the current project.</para>
    /// </summary>
    public static extern ColorSpace colorSpace { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Default horizontal dimension of stand-alone player window.</para>
    /// </summary>
    public static extern int defaultScreenWidth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Default vertical dimension of stand-alone player window.</para>
    /// </summary>
    public static extern int defaultScreenHeight { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Default horizontal dimension of web player window.</para>
    /// </summary>
    public static extern int defaultWebScreenWidth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Default vertical dimension of web player window.</para>
    /// </summary>
    public static extern int defaultWebScreenHeight { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Defines the behaviour of the Resolution Dialog on product launch.</para>
    /// </summary>
    public static extern ResolutionDialogSetting displayResolutionDialog { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns whether or not the specified aspect ratio is enabled.</para>
    /// </summary>
    /// <param name="aspectRatio"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasAspectRatio(AspectRatio aspectRatio);

    /// <summary>
    ///   <para>Enables the specified aspect ratio.</para>
    /// </summary>
    /// <param name="aspectRatio"></param>
    /// <param name="enable"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetAspectRatio(AspectRatio aspectRatio, bool enable);

    /// <summary>
    ///   <para>If enabled, the game will default to fullscreen mode.</para>
    /// </summary>
    public static extern bool defaultIsFullScreen { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    public static extern bool defaultIsNativeResolution { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Enable Retina support for macOS.</para>
    /// </summary>
    public static extern bool macRetinaSupport { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>If enabled, your game will continue to run after lost focus.</para>
    /// </summary>
    public static extern bool runInBackground { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Defines if fullscreen games should darken secondary displays.</para>
    /// </summary>
    public static extern bool captureSingleScreen { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Write a log file with debugging information.</para>
    /// </summary>
    public static extern bool usePlayerLog { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Use resizable window in standalone player builds.</para>
    /// </summary>
    public static extern bool resizableWindow { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Pre bake collision meshes on player build.</para>
    /// </summary>
    public static extern bool bakeCollisionMeshes { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Enable receipt validation for the Mac App Store.</para>
    /// </summary>
    public static extern bool useMacAppStoreValidation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Define how to handle fullscreen mode in macOS standalones.</para>
    /// </summary>
    public static extern MacFullscreenMode macFullscreenMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Define how to handle fullscreen mode in Windows standalones (Direct3D 9 mode).</para>
    /// </summary>
    [Obsolete("D3D9 support has been removed; d3d9FullscreenMode does nothing now")]
    public static extern D3D9FullscreenMode d3d9FullscreenMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Define how to handle fullscreen mode in Windows standalones (Direct3D 11 mode).</para>
    /// </summary>
    public static extern D3D11FullscreenMode d3d11FullscreenMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Enable Virtual Reality support on the current build target.</para>
    /// </summary>
    public static extern bool virtualRealitySupported { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Should Unity support single-pass stereo rendering?</para>
    /// </summary>
    [Obsolete("singlePassStereoRendering will be deprecated. Use stereoRenderingPath instead.")]
    public static extern bool singlePassStereoRendering { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Active stereo rendering path</para>
    /// </summary>
    public static extern StereoRenderingPath stereoRenderingPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Protect graphics memory.</para>
    /// </summary>
    public static extern bool protectGraphicsMemory { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Switch display to HDR mode (if available).</para>
    /// </summary>
    public static extern bool useHDRDisplay { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>On Windows, show the application in the background if Fullscreen Windowed mode is used.</para>
    /// </summary>
    public static extern bool visibleInBackground { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>If enabled, allows the user to switch between full screen and windowed mode using OS specific keyboard short cuts.</para>
    /// </summary>
    public static extern bool allowFullscreenSwitch { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Restrict standalone players to a single concurrent running instance.</para>
    /// </summary>
    public static extern bool forceSingleInstance { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    public static extern bool openGLRequireES31 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    public static extern bool openGLRequireES31AEP { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The image to display in the Resolution Dialog window.</para>
    /// </summary>
    public static extern Texture2D resolutionDialogBanner { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Virtual Reality specific splash screen.</para>
    /// </summary>
    public static extern Texture2D virtualRealitySplashScreen { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The bundle identifier of the iPhone application.</para>
    /// </summary>
    [Obsolete("iPhoneBundleIdentifier is deprecated. Use PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS) instead.")]
    public static string iPhoneBundleIdentifier
    {
      get
      {
        return PlayerSettings.GetApplicationIdentifier(BuildTargetGroup.iPhone);
      }
      set
      {
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iPhone, value);
      }
    }

    /// <summary>
    ///   <para>Returns the list of assigned icons for the specified platform.</para>
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="kind"></param>
    public static Texture2D[] GetIconsForTargetGroup(BuildTargetGroup platform, IconKind kind)
    {
      return PlayerSettings.GetIconsForPlatform(PlayerSettings.GetPlatformName(platform), kind);
    }

    /// <summary>
    ///   <para>Returns the list of assigned icons for the specified platform.</para>
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="kind"></param>
    public static Texture2D[] GetIconsForTargetGroup(BuildTargetGroup platform)
    {
      return PlayerSettings.GetIconsForTargetGroup(platform, IconKind.Any);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern Texture2D[] GetIconsForPlatform(string platform, IconKind kind);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern Texture2D[] GetAllIconsForPlatform(string platform);

    /// <summary>
    ///   <para>Assign a list of icons for the specified platform.</para>
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="icons"></param>
    /// <param name="kind"></param>
    public static void SetIconsForTargetGroup(BuildTargetGroup platform, Texture2D[] icons, IconKind kind)
    {
      PlayerSettings.SetIconsForPlatform(PlayerSettings.GetPlatformName(platform), icons, kind);
    }

    /// <summary>
    ///   <para>Assign a list of icons for the specified platform.</para>
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="icons"></param>
    /// <param name="kind"></param>
    public static void SetIconsForTargetGroup(BuildTargetGroup platform, Texture2D[] icons)
    {
      PlayerSettings.SetIconsForTargetGroup(platform, icons, IconKind.Any);
    }

    internal static void SetIconsForPlatform(string platform, Texture2D[] icons)
    {
      PlayerSettings.SetIconsForPlatform(platform, icons, IconKind.Any);
    }

    internal static void SetIconsForPlatform(string platform, Texture2D[] icons, IconKind[] kinds)
    {
      foreach (IconKind kind in PlayerSettings.GetSupportedIconKindsForPlatform(platform))
      {
        List<Texture2D> texture2DList = new List<Texture2D>();
        for (int index = 0; index < icons.Length; ++index)
        {
          if (kinds[index] == kind)
            texture2DList.Add(icons[index]);
        }
        PlayerSettings.SetIconsForPlatform(platform, texture2DList.ToArray(), kind);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetIconsForPlatform(string platform, Texture2D[] icons, IconKind kind);

    /// <summary>
    ///   <para>Returns a list of icon sizes for the specified platform.</para>
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="kind"></param>
    public static int[] GetIconSizesForTargetGroup(BuildTargetGroup platform, IconKind kind)
    {
      return PlayerSettings.GetIconWidthsForPlatform(PlayerSettings.GetPlatformName(platform), kind);
    }

    /// <summary>
    ///   <para>Returns a list of icon sizes for the specified platform.</para>
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="kind"></param>
    public static int[] GetIconSizesForTargetGroup(BuildTargetGroup platform)
    {
      return PlayerSettings.GetIconSizesForTargetGroup(platform, IconKind.Any);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int[] GetIconWidthsForPlatform(string platform, IconKind kind);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int[] GetIconHeightsForPlatform(string platform, IconKind kind);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int[] GetIconWidthsOfAllKindsForPlatform(string platform);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int[] GetIconHeightsOfAllKindsForPlatform(string platform);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern IconKind[] GetIconKindsForPlatform(string platform);

    internal static IconKind[] GetSupportedIconKindsForPlatform(string platform)
    {
      List<IconKind> iconKindList = new List<IconKind>();
      foreach (IconKind iconKind in PlayerSettings.GetIconKindsForPlatform(platform))
      {
        if (!iconKindList.Contains(iconKind))
          iconKindList.Add(iconKind);
      }
      return iconKindList.ToArray();
    }

    internal static string GetPlatformName(BuildTargetGroup targetGroup)
    {
      BuildPlatform buildPlatform = BuildPlatforms.instance.GetValidPlatforms().Find((Predicate<BuildPlatform>) (p => p.targetGroup == targetGroup));
      return buildPlatform != null ? buildPlatform.name : string.Empty;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern Texture2D GetIconForPlatformAtSize(string platform, int width, int height, IconKind kind);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void GetBatchingForPlatform(BuildTarget platform, out int staticBatching, out int dynamicBatching);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetBatchingForPlatform(BuildTarget platform, int staticBatching, int dynamicBatching);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern LightmapEncodingQuality GetLightmapEncodingQualityForPlatformGroup(BuildTargetGroup platformGroup);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetLightmapEncodingQualityForPlatformGroup(BuildTargetGroup platformGroup, LightmapEncodingQuality encodingQuality);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern GraphicsDeviceType[] GetSupportedGraphicsAPIs(BuildTarget platform);

    /// <summary>
    ///   <para>Get graphics APIs to be used on a build platform.</para>
    /// </summary>
    /// <param name="platform">Platform to get APIs for.</param>
    /// <returns>
    ///   <para>Array of graphics APIs.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern GraphicsDeviceType[] GetGraphicsAPIs(BuildTarget platform);

    /// <summary>
    ///   <para>Sets the graphics APIs used on a build platform.</para>
    /// </summary>
    /// <param name="platform">Platform to set APIs for.</param>
    /// <param name="apis">Array of graphics APIs.</param>
    public static void SetGraphicsAPIs(BuildTarget platform, GraphicsDeviceType[] apis)
    {
      PlayerSettings.SetGraphicsAPIsImpl(platform, apis);
      PlayerSettingsEditor.SyncPlatformAPIsList(platform);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetGraphicsAPIsImpl(BuildTarget platform, GraphicsDeviceType[] apis);

    /// <summary>
    ///   <para>Is a build platform using automatic graphics API choice?</para>
    /// </summary>
    /// <param name="platform">Platform to get the flag for.</param>
    /// <returns>
    ///   <para>Should best available graphics API be used.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool GetUseDefaultGraphicsAPIs(BuildTarget platform);

    /// <summary>
    ///   <para>Should a build platform use automatic graphics API choice.</para>
    /// </summary>
    /// <param name="platform">Platform to set the flag for.</param>
    /// <param name="automatic">Should best available graphics API be used?</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetUseDefaultGraphicsAPIs(BuildTarget platform, bool automatic);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern ColorGamut[] GetColorGamuts();

    internal static void SetColorGamuts(ColorGamut[] colorSpaces)
    {
      PlayerSettings.SetColorGamutsImpl(colorSpaces);
      PlayerSettingsEditor.SyncColorGamuts();
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetColorGamutsImpl(ColorGamut[] colorSpaces);

    internal static extern string[] templateCustomKeys { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetTemplateCustomValue(string key, string value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetTemplateCustomValue(string key);

    internal static extern string spritePackerPolicy { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Get user-specified symbols for script compilation for the given build target group.</para>
    /// </summary>
    /// <param name="targetGroup"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetScriptingDefineSymbolsForGroup(BuildTargetGroup targetGroup);

    /// <summary>
    ///   <para>Set user-specified symbols for script compilation for the given build target group.</para>
    /// </summary>
    /// <param name="targetGroup">The name of the group of devices.</param>
    /// <param name="defines">Symbols for this group separated by semicolons.</param>
    public static void SetScriptingDefineSymbolsForGroup(BuildTargetGroup targetGroup, string defines)
    {
      if (!string.IsNullOrEmpty(defines))
        defines = string.Join(";", defines.Split(PlayerSettings.defineSplits, StringSplitOptions.RemoveEmptyEntries));
      PlayerSettings.SetScriptingDefineSymbolsForGroupInternal(targetGroup, defines);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetScriptingDefineSymbolsForGroupInternal(BuildTargetGroup targetGroup, string defines);

    /// <summary>
    ///   <para>Gets the BuildTargetPlatformGroup architecture.</para>
    /// </summary>
    /// <param name="targetGroup"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetArchitecture(BuildTargetGroup targetGroup);

    /// <summary>
    ///   <para>Sets the BuildTargetPlatformGroup architecture.</para>
    /// </summary>
    /// <param name="targetGroup"></param>
    /// <param name="architecture"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetArchitecture(BuildTargetGroup targetGroup, int architecture);

    /// <summary>
    ///   <para>Gets the scripting framework for a BuildTargetPlatformGroup.</para>
    /// </summary>
    /// <param name="targetGroup"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ScriptingImplementation GetScriptingBackend(BuildTargetGroup targetGroup);

    /// <summary>
    ///   <para>Set the application identifier for the specified platform.</para>
    /// </summary>
    /// <param name="targetGroup"></param>
    /// <param name="identifier"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetApplicationIdentifier(BuildTargetGroup targetGroup, string identifier);

    /// <summary>
    ///   <para>Get the application identifier for the specified platform.</para>
    /// </summary>
    /// <param name="targetGroup"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetApplicationIdentifier(BuildTargetGroup targetGroup);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetBuildNumber(BuildTargetGroup targetGroup, string buildNumber);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetBuildNumber(BuildTargetGroup targetGroup);

    /// <summary>
    ///   <para>Sets the scripting framework for a BuildTargetPlatformGroup.</para>
    /// </summary>
    /// <param name="targetGroup"></param>
    /// <param name="backend"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetScriptingBackend(BuildTargetGroup targetGroup, ScriptingImplementation backend);

    /// <summary>
    ///   <para>Does IL2CPP platform use incremental build?</para>
    /// </summary>
    /// <param name="targetGroup"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool GetIncrementalIl2CppBuild(BuildTargetGroup targetGroup);

    /// <summary>
    ///   <para>Sets incremental build flag.</para>
    /// </summary>
    /// <param name="targetGroup"></param>
    /// <param name="enabled"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetIncrementalIl2CppBuild(BuildTargetGroup targetGroup, bool enabled);

    /// <summary>
    ///   <para>IL2CPP build arguments.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetAdditionalIl2CppArgs();

    /// <summary>
    ///   <para>IL2CPP build arguments.</para>
    /// </summary>
    /// <param name="additionalArgs"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetAdditionalIl2CppArgs(string additionalArgs);

    /// <summary>
    ///   <para>The scripting runtime version setting. Change this to set the version the Editor uses and restart the Editor to apply the change.</para>
    /// </summary>
    public static extern ScriptingRuntimeVersion scriptingRuntimeVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Password used for interacting with the Android Keystore.</para>
    /// </summary>
    public static extern string keystorePass { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Password for the key used for signing an Android application.</para>
    /// </summary>
    public static extern string keyaliasPass { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern string xboxTitleId { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern string xboxImageXexFilePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern string xboxSpaFilePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern bool xboxGenerateSpa { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern bool xboxEnableGuest { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern bool xboxDeployKinectResources { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern bool xboxDeployKinectHeadOrientation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern bool xboxDeployKinectHeadPosition { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern Texture2D xboxSplashScreen { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern int xboxAdditionalTitleMemorySize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern bool xboxEnableKinect { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern bool xboxEnableKinectAutoTracking { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern bool xboxEnableSpeech { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Xbox 360 has been removed in >=5.5")]
    public static extern uint xboxSpeechDB { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Enable GPU skinning on capable platforms.</para>
    /// </summary>
    public static extern bool gpuSkinning { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Enable graphics jobs (multi threaded rendering).</para>
    /// </summary>
    public static extern bool graphicsJobs { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Selects the graphics job mode to use on platforms that support both Native and Legacy graphics jobs.</para>
    /// </summary>
    public static extern GraphicsJobMode graphicsJobMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Gets the current value of the Vuforia AR checkbox in the Player Settings for the specified buildTargetGroup.</para>
    /// </summary>
    /// <param name="targetGroup">The BuildTargetGroup you wish to get the value for.</param>
    /// <returns>
    ///   <para>True if Vuforia AR is enabled, false otherwise.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool GetPlatformVuforiaEnabled(BuildTargetGroup targetGroup);

    /// <summary>
    ///   <para>Sets the value of the Vuforia AR checkbox in the Player Settings for the specified buildTargetGroup.</para>
    /// </summary>
    /// <param name="targetGroup">The BuildTargetGroup you wish to set the value for.</param>
    /// <param name="enabled">True to enable Vuforia AR, false otherwise.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetPlatformVuforiaEnabled(BuildTargetGroup targetGroup, bool enabled);

    public static extern bool xboxPIXTextureCapture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Xbox 360 Avatars.</para>
    /// </summary>
    public static extern bool xboxEnableAvatar { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public static extern int xboxOneResolution { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Enables internal profiler.</para>
    /// </summary>
    public static extern bool enableInternalProfiler { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets the crash behavior on .NET unhandled exception.</para>
    /// </summary>
    public static extern ActionOnDotNetUnhandledException actionOnDotNetUnhandledException { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Are ObjC uncaught exceptions logged?</para>
    /// </summary>
    public static extern bool logObjCUncaughtExceptions { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Enables CrashReport API.</para>
    /// </summary>
    public static extern bool enableCrashReportAPI { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The application identifier for the currently selected build target.</para>
    /// </summary>
    public static string applicationIdentifier
    {
      get
      {
        return PlayerSettings.GetApplicationIdentifier(EditorUserBuildSettings.selectedBuildTargetGroup);
      }
      set
      {
        Debug.LogWarning((object) "PlayerSettings.applicationIdentifier only changes the identifier for the currently active platform. Please use SetApplicationIdentifier to set it for any platform");
        PlayerSettings.SetApplicationIdentifier(EditorUserBuildSettings.selectedBuildTargetGroup, value);
      }
    }

    /// <summary>
    ///   <para>Application bundle version shared between iOS &amp; Android platforms.</para>
    /// </summary>
    public static extern string bundleVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns if status bar should be hidden. Supported on iOS only; on Android, the status bar is always hidden.</para>
    /// </summary>
    public static extern bool statusBarHidden { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Managed code stripping level.</para>
    /// </summary>
    public static extern StrippingLevel strippingLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Remove unused Engine code from your build (IL2CPP-only).</para>
    /// </summary>
    public static extern bool stripEngineCode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Default screen orientation for mobiles.</para>
    /// </summary>
    public static extern UIOrientation defaultInterfaceOrientation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Is auto-rotation to portrait supported?</para>
    /// </summary>
    public static extern bool allowedAutorotateToPortrait { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Is auto-rotation to portrait upside-down supported?</para>
    /// </summary>
    public static extern bool allowedAutorotateToPortraitUpsideDown { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Is auto-rotation to landscape right supported?</para>
    /// </summary>
    public static extern bool allowedAutorotateToLandscapeRight { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Is auto-rotation to landscape left supported?</para>
    /// </summary>
    public static extern bool allowedAutorotateToLandscapeLeft { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Let the OS autorotate the screen as the device orientation changes.</para>
    /// </summary>
    public static extern bool useAnimatedAutorotation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>32-bit Display Buffer is used.</para>
    /// </summary>
    public static extern bool use32BitDisplayBuffer { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>When enabled, preserves the alpha value in the framebuffer to support rendering over native UI on Android.</para>
    /// </summary>
    public static extern bool preserveFramebufferAlpha { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Deprecated. Use PlayerSettings.GetApiCompatibilityLevel and PlayerSettings.SetApiCompatibilityLevel instead.</para>
    /// </summary>
    [Obsolete("apiCompatibilityLevel is deprecated. Use PlayerSettings.GetApiCompatibilityLevel()/PlayerSettings.SetApiCompatibilityLevel() instead.")]
    public static extern ApiCompatibilityLevel apiCompatibilityLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Gets .NET API compatibility level for specified BuildTargetGroup.</para>
    /// </summary>
    /// <param name="buildTargetGroup"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern ApiCompatibilityLevel GetApiCompatibilityLevel(BuildTargetGroup buildTargetGroup);

    /// <summary>
    ///   <para>Sets .NET API compatibility level for specified BuildTargetGroup.</para>
    /// </summary>
    /// <param name="buildTargetGroup"></param>
    /// <param name="value"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetApiCompatibilityLevel(BuildTargetGroup buildTargetGroup, ApiCompatibilityLevel value);

    /// <summary>
    ///   <para>Should unused Mesh components be excluded from game build?</para>
    /// </summary>
    public static extern bool stripUnusedMeshComponents { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Is the advanced version being used?</para>
    /// </summary>
    public static extern bool advancedLicense { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Additional AOT compilation options. Shared by AOT platforms.</para>
    /// </summary>
    public static extern string aotOptions { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The default cursor for your application.</para>
    /// </summary>
    public static extern Texture2D defaultCursor { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Default cursor's click position in pixels from the top left corner of the cursor image.</para>
    /// </summary>
    public static Vector2 cursorHotspot
    {
      get
      {
        Vector2 vector2;
        PlayerSettings.INTERNAL_get_cursorHotspot(out vector2);
        return vector2;
      }
      set
      {
        PlayerSettings.INTERNAL_set_cursorHotspot(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_get_cursorHotspot(out Vector2 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_set_cursorHotspot(ref Vector2 value);

    /// <summary>
    ///   <para>Accelerometer update frequency.</para>
    /// </summary>
    public static extern int accelerometerFrequency { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Is multi-threaded rendering enabled?</para>
    /// </summary>
    public static extern bool MTRendering { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Enable or disable multithreaded rendering option for mobile platform.</para>
    /// </summary>
    /// <param name="targetGroup">Mobile platform (Only iOS, tvOS and Android).</param>
    /// <param name="enable"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetMobileMTRendering(BuildTargetGroup targetGroup, bool enable);

    /// <summary>
    ///   <para>Check if multithreaded rendering option for mobile platform is enabled.</para>
    /// </summary>
    /// <param name="targetGroup">Mobile platform (Only iOS, tvOS and Android).</param>
    /// <returns>
    ///   <para>Return true if multithreaded rendering option for targetGroup platform is enabled.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool GetMobileMTRendering(BuildTargetGroup targetGroup);

    /// <summary>
    ///   <para>Get stack trace logging options.</para>
    /// </summary>
    /// <param name="logType"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern StackTraceLogType GetStackTraceLogType(LogType logType);

    /// <summary>
    ///         <para>Set stack trace logging options.
    /// Note: calling this function will implicitly call Application.SetStackTraceLogType.</para>
    ///       </summary>
    /// <param name="logType"></param>
    /// <param name="stackTraceType"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType);

    /// <summary>
    ///   <para>Should Direct3D 11 be used when available?</para>
    /// </summary>
    [Obsolete("Use UnityEditor.PlayerSettings.SetGraphicsAPIs/GetGraphicsAPIs instead")]
    public static extern bool useDirect3D11 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    internal static extern bool submitAnalytics { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Should player render in stereoscopic 3d on supported hardware?</para>
    /// </summary>
    [Obsolete("Use VREditor.GetStereoDeviceEnabled instead")]
    public static extern bool stereoscopic3D { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Stops or allows audio from other applications to play in the background while your Unity application is running.</para>
    /// </summary>
    public static extern bool muteOtherAudioSources { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    internal static extern bool playModeTestRunnerEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns a list of the available Virtual Reality SDKs that are supported on a given BuildTargetGroup.</para>
    /// </summary>
    /// <param name="targetGroup">The BuildTargetGroup to return the list for.</param>
    /// <returns>
    ///   <para>List of available Virtual Reality SDKs.</para>
    /// </returns>
    public static string[] GetAvailableVirtualRealitySDKs(BuildTargetGroup targetGroup)
    {
      return VREditor.GetAvailableVirtualRealitySDKs(targetGroup);
    }

    /// <summary>
    ///   <para>Returns whether or not Virtual Reality Support is enabled for a given BuildTargetGroup.</para>
    /// </summary>
    /// <param name="targetGroup">The BuildTargetGroup to return the value for.</param>
    /// <returns>
    ///   <para>True if Virtual Reality Support is enabled.</para>
    /// </returns>
    public static bool GetVirtualRealitySupported(BuildTargetGroup targetGroup)
    {
      return VREditor.GetVREnabledOnTargetGroup(targetGroup);
    }

    /// <summary>
    ///   <para>Sets whether or not Virtual Reality Support is enabled for a given BuildTargetGroup.</para>
    /// </summary>
    /// <param name="targetGroup">The BuildTargetGroup to set the value for.</param>
    /// <param name="value">The value to set, true to enable, false to disable.</param>
    public static void SetVirtualRealitySupported(BuildTargetGroup targetGroup, bool value)
    {
      VREditor.SetVREnabledOnTargetGroup(targetGroup, value);
    }

    /// <summary>
    ///   <para>Get the List of Virtual Reality SDKs for a given BuildTargetGroup.</para>
    /// </summary>
    /// <param name="targetGroup">The BuildTargetGroup to return the SDK list for.</param>
    /// <returns>
    ///   <para>Ordered list of Virtual Reality SDKs.</para>
    /// </returns>
    public static string[] GetVirtualRealitySDKs(BuildTargetGroup targetGroup)
    {
      return VREditor.GetVirtualRealitySDKs(targetGroup);
    }

    /// <summary>
    ///   <para>Set the List of Virtual Reality SDKs for a given BuildTargetGroup.</para>
    /// </summary>
    /// <param name="targetGroup">The BuildTargetGroup to set the SDK list for.</param>
    /// <param name="sdks">List of Virtual Reality SDKs.</param>
    public static void SetVirtualRealitySDKs(BuildTargetGroup targetGroup, string[] sdks)
    {
      VREditor.SetVirtualRealitySDKs(targetGroup, sdks);
    }

    [Obsolete("The option alwaysDisplayWatermark is deprecated and is always false", true)]
    public static bool alwaysDisplayWatermark
    {
      get
      {
        return false;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>First level to have access to all Resources.Load assets in Streamed Web Players.</para>
    /// </summary>
    [Obsolete("Use AssetBundles instead for streaming data", true)]
    public static int firstStreamedLevelWithResources
    {
      get
      {
        return 0;
      }
      set
      {
      }
    }

    [Obsolete("targetGlesGraphics is ignored, use SetGraphicsAPIs/GetGraphicsAPIs APIs", false)]
    public static TargetGlesGraphics targetGlesGraphics
    {
      get
      {
        return TargetGlesGraphics.Automatic;
      }
      set
      {
      }
    }

    [Obsolete("targetIOSGraphics is ignored, use SetGraphicsAPIs/GetGraphicsAPIs APIs", false)]
    public static TargetIOSGraphics targetIOSGraphics
    {
      get
      {
        return TargetIOSGraphics.Automatic;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>Describes the reason for access to the user's location data.</para>
    /// </summary>
    [Obsolete("Use PlayerSettings.iOS.locationUsageDescription instead (UnityUpgradable) -> UnityEditor.PlayerSettings/iOS.locationUsageDescription", false)]
    public static string locationUsageDescription
    {
      get
      {
        return PlayerSettings.iOS.locationUsageDescription;
      }
      set
      {
        PlayerSettings.iOS.locationUsageDescription = value;
      }
    }

    /// <summary>
    ///   <para>Which rendering path is enabled?</para>
    /// </summary>
    [Obsolete("renderingPath is ignored, use UnityEditor.Rendering.TierSettings with UnityEditor.Rendering.SetTierSettings/GetTierSettings instead", false)]
    public static RenderingPath renderingPath
    {
      get
      {
        return EditorGraphicsSettings.GetCurrentTierSettings().renderingPath;
      }
      set
      {
      }
    }

    [Obsolete("mobileRenderingPath is ignored, use UnityEditor.Rendering.TierSettings with UnityEditor.Rendering.SetTierSettings/GetTierSettings instead", false)]
    public static RenderingPath mobileRenderingPath
    {
      get
      {
        return EditorGraphicsSettings.GetCurrentTierSettings().renderingPath;
      }
      set
      {
      }
    }

    [Obsolete("Use PlayerSettings.applicationIdentifier instead (UnityUpgradable) -> UnityEditor.PlayerSettings.applicationIdentifier", true)]
    public static string bundleIdentifier
    {
      get
      {
        return PlayerSettings.applicationIdentifier;
      }
      set
      {
        PlayerSettings.applicationIdentifier = value;
      }
    }

    public sealed class PSM
    {
    }

    /// <summary>
    ///   <para>Android specific player settings.</para>
    /// </summary>
    public sealed class Android
    {
      /// <summary>
      ///   <para>Disable Depth and Stencil Buffers.</para>
      /// </summary>
      public static extern bool disableDepthAndStencilBuffers { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>24-bit Depth Buffer is used.</para>
      /// </summary>
      [Obsolete("This has been replaced by disableDepthAndStencilBuffers")]
      public static bool use24BitDepthBuffer
      {
        get
        {
          return !PlayerSettings.Android.disableDepthAndStencilBuffers;
        }
        set
        {
        }
      }

      /// <summary>
      ///   <para>Android bundle version code.</para>
      /// </summary>
      public static extern int bundleVersionCode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The minimum API level required for your application to run.</para>
      /// </summary>
      public static extern AndroidSdkVersions minSdkVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The target API level of your application.</para>
      /// </summary>
      public static extern AndroidSdkVersions targetSdkVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Preferred application install location.</para>
      /// </summary>
      public static extern AndroidPreferredInstallLocation preferredInstallLocation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Force internet permission flag.</para>
      /// </summary>
      public static extern bool forceInternetPermission { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Force SD card permission.</para>
      /// </summary>
      public static extern bool forceSDCardPermission { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Provide a build that is Android TV compatible.</para>
      /// </summary>
      public static extern bool androidTVCompatibility { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Publish the build as a game rather than a regular application. This option affects devices running Android 5.0 Lollipop and later</para>
      /// </summary>
      public static extern bool androidIsGame { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      internal static extern bool androidTangoEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      internal static extern bool androidBannerEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      internal static extern AndroidGamepadSupportLevel androidGamepadSupportLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern AndroidBanner[] GetAndroidBanners();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern Texture2D GetAndroidBannerForHeight(int height);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern void SetAndroidBanners(Texture2D[] banners);

      internal static extern bool createWallpaper { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Android target device.</para>
      /// </summary>
      public static extern AndroidTargetDevice targetDevice { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Android splash screen scale mode.</para>
      /// </summary>
      public static extern AndroidSplashScreenScale splashScreenScale { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Android keystore name.</para>
      /// </summary>
      public static extern string keystoreName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Android keystore password.</para>
      /// </summary>
      public static extern string keystorePass { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Android key alias name.</para>
      /// </summary>
      public static extern string keyaliasName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Android key alias password.</para>
      /// </summary>
      public static extern string keyaliasPass { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>License verification flag.</para>
      /// </summary>
      public static extern bool licenseVerification { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      /// <summary>
      ///   <para>Use APK Expansion Files.</para>
      /// </summary>
      public static extern bool useAPKExpansionFiles { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Application should show ActivityIndicator when loading.</para>
      /// </summary>
      public static extern AndroidShowActivityIndicatorOnLoading showActivityIndicatorOnLoading { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Choose how content is drawn to the screen.</para>
      /// </summary>
      public static extern AndroidBlitType blitType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      internal static extern int supportedAspectRatioMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Maximum aspect ratio which is supported by the application.</para>
      /// </summary>
      public static extern float maxAspectRatio { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      internal static extern bool useLowAccuracyLocation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }
    }

    /// <summary>
    ///   <para>Google Cardboard-specific Player Settings.</para>
    /// </summary>
    public static class VRCardboard
    {
      /// <summary>
      ///   <para>Set the requested depth format for the Depth and Stencil Buffers. Options are 16bit Depth, 24bit Depth and 24bit Depth + 8bit Stencil.</para>
      /// </summary>
      public static extern int depthFormat { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }
    }

    /// <summary>
    ///   <para>Google VR-specific Player Settings.</para>
    /// </summary>
    public static class VRDaydream
    {
      /// <summary>
      ///   <para>Foreground image for the Daydream Launcher Home Screen.</para>
      /// </summary>
      public static extern Texture2D daydreamIcon { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Background image for the Daydream Launcher Home Screen.</para>
      /// </summary>
      public static extern Texture2D daydreamIconBackground { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Set the requested depth format for the Depth and Stencil Buffers. Options are 16bit Depth, 24bit Depth and 24bit Depth + 8bit Stencil.</para>
      /// </summary>
      public static extern int depthFormat { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///         <para>Set the lowest level of head tracking required to run your application.
      /// 
      /// Set this property to limit your application to only run on devices that support this minimum level of head tracking.</para>
      ///       </summary>
      public static extern SupportedHeadTracking minimumSupportedHeadTracking { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///         <para>Set the highest level of head tracking required to run your application.
      /// 
      /// Set this property to limit your application to only run on devices that support this maximum level of head tracking. On devices that support higher levels of head tracking, your application is limited to using the maximum level.</para>
      ///       </summary>
      public static extern SupportedHeadTracking maximumSupportedHeadTracking { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///         <para>Enable Google VR Asynchronous Video Re-Projection when running in Daydream.
      /// 
      /// NOTE: Only takes effect if set before initializing VR.</para>
      ///       </summary>
      public static extern bool enableVideoSurface { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///         <para>Enable Protected Memory support when running with Google VR Asynchronous Video Re-Projection (AVR).
      /// 
      /// Protected memory support is currently an all or nothing feature. When enabled only DRM protected content can be played using AVR. Clear content will fail to play.
      /// 
      /// NOTE: Only takes effect if set before initializing VR.</para>
      ///       </summary>
      public static extern bool enableVideoSurfaceProtectedMemory { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }
    }

    /// <summary>
    ///   <para>Facebook specific Player settings.</para>
    /// </summary>
    public sealed class Facebook
    {
      /// <summary>
      ///   <para>Version of Facebook SDK to use for this project.</para>
      /// </summary>
      public static extern string sdkVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }
    }

    /// <summary>
    ///   <para>iOS specific player settings.</para>
    /// </summary>
    public sealed class iOS
    {
      /// <summary>
      ///   <para>iOS application display name.</para>
      /// </summary>
      public static extern string applicationDisplayName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The build number of the bundle</para>
      /// </summary>
      public static string buildNumber
      {
        get
        {
          return PlayerSettings.GetBuildNumber(BuildTargetGroup.iPhone);
        }
        set
        {
          PlayerSettings.SetBuildNumber(BuildTargetGroup.iPhone, value);
        }
      }

      /// <summary>
      ///   <para>Disable Depth and Stencil Buffers.</para>
      /// </summary>
      public static extern bool disableDepthAndStencilBuffers { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Script calling optimization.</para>
      /// </summary>
      public static extern ScriptCallOptimizationLevel scriptCallOptimization { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Active iOS SDK version used for build.</para>
      /// </summary>
      public static extern iOSSdkVersion sdkVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Deployment minimal version of iOS.</para>
      /// </summary>
      [Obsolete("targetOSVersion is obsolete, use targetOSVersionString")]
      public static extern iOSTargetOSVersion targetOSVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Deployment minimal version of iOS.</para>
      /// </summary>
      public static extern string targetOSVersionString { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Targeted device.</para>
      /// </summary>
      public static extern iOSTargetDevice targetDevice { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Icon is prerendered.</para>
      /// </summary>
      public static extern bool prerenderedIcon { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Application requires persistent WiFi.</para>
      /// </summary>
      public static extern bool requiresPersistentWiFi { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>RequiresFullScreen maps to Apple's plist build setting UIRequiresFullScreen, which is used to opt out of being eligible to participate in Slide Over and Split View for iOS 9.0 multitasking.</para>
      /// </summary>
      public static extern bool requiresFullScreen { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Status bar style.</para>
      /// </summary>
      public static extern iOSStatusBarStyle statusBarStyle { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Defer system gestures until the second swipe on specific edges.</para>
      /// </summary>
      public static extern SystemGestureDeferMode deferSystemGesturesMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specifies whether the home button should be hidden in the iOS build of this application.</para>
      /// </summary>
      public static extern bool hideHomeButton { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Application behavior when entering background.</para>
      /// </summary>
      public static extern iOSAppInBackgroundBehavior appInBackgroundBehavior { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Supported background execution modes (when appInBackgroundBehavior is set to iOSAppInBackgroundBehavior.Custom).</para>
      /// </summary>
      public static extern iOSBackgroundMode backgroundModes { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Should hard shadows be enforced when running on (mobile) Metal.</para>
      /// </summary>
      public static extern bool forceHardShadowsOnMetal { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Should insecure HTTP downloads be allowed?</para>
      /// </summary>
      public static extern bool allowHTTPDownload { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Set this property with your Apple Developer Team ID. You can find this on the Apple Developer website under &lt;a href="https:developer.apple.comaccount#membership"&gt; Account &gt; Membership &lt;/a&gt; . This sets the Team ID for the generated Xcode project, allowing developers to use the Build and Run functionality. An Apple Developer Team ID must be set here for automatic signing of your app.</para>
      /// </summary>
      public static extern string appleDeveloperTeamID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>A provisioning profile Universally Unique Identifier (UUID) that Xcode will use to build your iOS app in Manual Signing mode.</para>
      /// </summary>
      public static extern string iOSManualProvisioningProfileID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>A provisioning profile Universally Unique Identifier (UUID) that Xcode will use to build your tvOS app in Manual Signing mode.</para>
      /// </summary>
      public static extern string tvOSManualProvisioningProfileID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Set this property to true for Xcode to attempt to automatically sign your app based on your appleDeveloperTeamID.</para>
      /// </summary>
      public static extern bool appleEnableAutomaticSigning { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Describes the reason for access to the user's camera.</para>
      /// </summary>
      public static extern string cameraUsageDescription { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Describes the reason for access to the user's location data.</para>
      /// </summary>
      public static extern string locationUsageDescription { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Describes the reason for access to the user's microphone.</para>
      /// </summary>
      public static extern string microphoneUsageDescription { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Application should show ActivityIndicator when loading.</para>
      /// </summary>
      public static extern iOSShowActivityIndicatorOnLoading showActivityIndicatorOnLoading { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Indicates whether application will use On Demand Resources (ODR) API.</para>
      /// </summary>
      public static extern bool useOnDemandResources { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern string[] GetAssetBundleVariantsWithDeviceRequirements();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern bool CheckAssetBundleVariantHasDeviceRequirements(string name);

      /// <summary>
      ///   <para>Sets the image to display on screen when the game launches for the specified iOS device.</para>
      /// </summary>
      /// <param name="image"></param>
      /// <param name="type"></param>
      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void SetLaunchScreenImage(Texture2D image, iOSLaunchScreenImageType type);

      /// <summary>
      ///   <para>Sets the mode which will be used to generate the app's launch screen Interface Builder (.xib) file for iPhone.</para>
      /// </summary>
      /// <param name="type"></param>
      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void SetiPhoneLaunchScreenType(iOSLaunchScreenType type);

      /// <summary>
      ///   <para>Sets the mode which will be used to generate the app's launch screen Interface Builder (.xib) file for iPad.</para>
      /// </summary>
      /// <param name="type"></param>
      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void SetiPadLaunchScreenType(iOSLaunchScreenType type);

      internal static iOSDeviceRequirementGroup GetDeviceRequirementsForAssetBundleVariant(string name)
      {
        if (!PlayerSettings.iOS.CheckAssetBundleVariantHasDeviceRequirements(name))
          return (iOSDeviceRequirementGroup) null;
        return new iOSDeviceRequirementGroup(name);
      }

      internal static void RemoveDeviceRequirementsForAssetBundleVariant(string name)
      {
        iOSDeviceRequirementGroup assetBundleVariant = PlayerSettings.iOS.GetDeviceRequirementsForAssetBundleVariant(name);
        for (int index = 0; index < assetBundleVariant.count; ++index)
          assetBundleVariant.RemoveAt(0);
      }

      internal static iOSDeviceRequirementGroup AddDeviceRequirementsForAssetBundleVariant(string name)
      {
        return new iOSDeviceRequirementGroup(name);
      }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern string[] GetURLSchemes();

      /// <summary>
      ///   <para>Application should exit when suspended to background.</para>
      /// </summary>
      [Obsolete("exitOnSuspend is deprecated, use appInBackgroundBehavior", false)]
      public static bool exitOnSuspend
      {
        get
        {
          return PlayerSettings.iOS.appInBackgroundBehavior == iOSAppInBackgroundBehavior.Exit;
        }
        set
        {
          PlayerSettings.iOS.appInBackgroundBehavior = iOSAppInBackgroundBehavior.Exit;
        }
      }

      [Obsolete("Use Screen.SetResolution at runtime", true)]
      public static iOSTargetResolution targetResolution
      {
        get
        {
          return iOSTargetResolution.Native;
        }
        set
        {
        }
      }

      /// <summary>
      ///   <para>Determines iPod playing behavior.</para>
      /// </summary>
      [Obsolete("Use PlayerSettings.muteOtherAudioSources instead (UnityUpgradable) -> UnityEditor.PlayerSettings.muteOtherAudioSources", false)]
      public static bool overrideIPodMusic
      {
        get
        {
          return PlayerSettings.muteOtherAudioSources;
        }
        set
        {
          PlayerSettings.muteOtherAudioSources = value;
        }
      }
    }

    public sealed class macOS
    {
      public static string buildNumber
      {
        get
        {
          return PlayerSettings.GetBuildNumber(BuildTargetGroup.Standalone);
        }
        set
        {
          PlayerSettings.SetBuildNumber(BuildTargetGroup.Standalone, value);
        }
      }

      internal static extern string applicationCategoryType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }
    }

    /// <summary>
    ///   <para>Nintendo 3DS player settings.</para>
    /// </summary>
    public sealed class N3DS
    {
      /// <summary>
      ///   <para>Disable depth/stencil buffers, to free up memory.</para>
      /// </summary>
      public static extern bool disableDepthAndStencilBuffers { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Disable sterescopic (3D) view on the upper screen.</para>
      /// </summary>
      public static extern bool disableStereoscopicView { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Enable shared L/R command list, for increased performance with stereoscopic rendering.</para>
      /// </summary>
      public static extern bool enableSharedListOpt { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Enable vsync.</para>
      /// </summary>
      public static extern bool enableVSync { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specify true when using expanded save data.</para>
      /// </summary>
      public static extern bool useExtSaveData { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specify true to enable static memory compression or false to disable it.</para>
      /// </summary>
      public static extern bool compressStaticMem { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specify the expanded save data number using 20 bits.</para>
      /// </summary>
      public static extern string extSaveDataNumber { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specify the stack size of the main thread, in bytes.</para>
      /// </summary>
      public static extern int stackSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The 3DS target platform.</para>
      /// </summary>
      public static extern PlayerSettings.N3DS.TargetPlatform targetPlatform { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specifies the title region settings.</para>
      /// </summary>
      public static extern PlayerSettings.N3DS.Region region { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Distribution media size.</para>
      /// </summary>
      public static extern PlayerSettings.N3DS.MediaSize mediaSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Application Logo Style.</para>
      /// </summary>
      public static extern PlayerSettings.N3DS.LogoStyle logoStyle { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The title of the application.</para>
      /// </summary>
      public static extern string title { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specifies the product code, or the add-on content code.</para>
      /// </summary>
      public static extern string productCode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The unique ID of the application, issued by Nintendo.  (0x00300 -&gt; 0xf7fff)</para>
      /// </summary>
      public static extern string applicationId { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Nintendo 3DS target platform.</para>
      /// </summary>
      public enum TargetPlatform
      {
        /// <summary>
        ///   <para>Target the Nintendo 3DS platform.</para>
        /// </summary>
        Nintendo3DS = 1,
        /// <summary>
        ///   <para>Target the New Nintendo 3DS platform.</para>
        /// </summary>
        NewNintendo3DS = 2,
      }

      /// <summary>
      ///   <para>Nintendo 3DS Title region.</para>
      /// </summary>
      public enum Region
      {
        /// <summary>
        ///   <para>For the Japanese region.</para>
        /// </summary>
        Japan = 1,
        /// <summary>
        ///   <para>For the American region.</para>
        /// </summary>
        America = 2,
        /// <summary>
        ///   <para>For the European region.</para>
        /// </summary>
        Europe = 3,
        /// <summary>
        ///   <para>For the Chinese region.</para>
        /// </summary>
        China = 4,
        /// <summary>
        ///   <para>For the Korean region.</para>
        /// </summary>
        Korea = 5,
        /// <summary>
        ///   <para>For the Taiwanese region.</para>
        /// </summary>
        Taiwan = 6,
        /// <summary>
        ///   <para>For all regions.</para>
        /// </summary>
        All = 7,
      }

      /// <summary>
      ///   <para>Nintendo 3DS distribution media size.</para>
      /// </summary>
      public enum MediaSize
      {
        _128MB,
        _256MB,
        _512MB,
        _1GB,
        _2GB,
      }

      /// <summary>
      ///   <para>Nintendo 3DS logo style specification.</para>
      /// </summary>
      public enum LogoStyle
      {
        /// <summary>
        ///   <para>For Nintendo first-party titles.</para>
        /// </summary>
        Nintendo,
        /// <summary>
        ///   <para>For titles for which Nintendo purchased the publishing license from the software manufacturer, etc.</para>
        /// </summary>
        Distributed,
        /// <summary>
        ///   <para>For Chinese region titles.</para>
        /// </summary>
        iQue,
        /// <summary>
        ///   <para>For all other titles.</para>
        /// </summary>
        Licensed,
      }
    }

    /// <summary>
    ///   <para>Player Settings for the PlayStation®4.</para>
    /// </summary>
    public sealed class PS4
    {
      public static extern string npTrophyPackPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int npAgeRating { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string npTitleSecret { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int parentalLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int applicationParameter1 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int applicationParameter2 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int applicationParameter3 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int applicationParameter4 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string passcode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string monoEnv { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool playerPrefsSupport { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool restrictedAudioUsageRights { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool useResolutionFallback { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string contentID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.PS4.PS4AppCategory category { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int appType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string masterVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string appVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.PS4.PS4RemotePlayKeyAssignment remotePlayKeyAssignment { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string remotePlayKeyMappingDir { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int playTogetherPlayerCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.PS4.PS4EnterButtonAssignment enterButtonAssignment { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string paramSfxPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int videoOutPixelFormat { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int videoOutInitialWidth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int videoOutBaseModeInitialWidth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int videoOutReprojectionRate { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("videoOutResolution is deprecated. Use PlayerSettings.PS4.videoOutInitialWidth and PlayerSettings.PS4.videoOutReprojectionRate to control initial display resolution and reprojection rate.")]
      public static extern int videoOutResolution { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string PronunciationXMLPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string PronunciationSIGPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string BackgroundImagePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string StartupImagePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string startupImagesFolder { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string iconImagesFolder { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string SaveDataImagePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string SdkOverride { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string BGMPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string ShareFilePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string ShareOverlayImagePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string PrivacyGuardImagePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool patchDayOne { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string PatchPkgPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string PatchLatestPkgPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string PatchChangeinfoPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string NPtitleDatPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("UnityEditor.PS4.useDebugIl2cppLibs no longer has any affect.")]
      internal static extern bool useDebugIl2cppLibs { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool pnSessions { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool pnPresence { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool pnFriends { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool pnGameCustomData { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int downloadDataSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int garlicHeapSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int proGarlicHeapSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool reprojectionSupport { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool useAudio3dBackend { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int audio3dVirtualSpeakerCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int scriptOptimizationLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int socialScreenEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool attribUserManagement { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool attribMoveSupport { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool attrib3DSupport { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool attribShareSupport { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool attribExclusiveVR { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool disableAutoHideSplash { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int attribCpuUsage { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool videoRecordingFeaturesUsed { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool contentSearchFeaturesUsed { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.PS4.PlayStationVREyeToEyeDistanceSettings attribEyeToEyeDistanceSettingVR { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string[] includedModules { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS4 application category.</para>
      /// </summary>
      public enum PS4AppCategory
      {
        /// <summary>
        ///   <para>Application.</para>
        /// </summary>
        Application,
        Patch,
        Remaster,
      }

      /// <summary>
      ///   <para>Remote Play key assignment.</para>
      /// </summary>
      public enum PS4RemotePlayKeyAssignment
      {
        /// <summary>
        ///   <para>No Remote play key assignment.</para>
        /// </summary>
        None = -1,
        /// <summary>
        ///   <para>Remote Play key layout configuration A.</para>
        /// </summary>
        PatternA = 0,
        /// <summary>
        ///   <para>Remote Play key layout configuration B.</para>
        /// </summary>
        PatternB = 1,
        /// <summary>
        ///   <para>Remote Play key layout configuration C.</para>
        /// </summary>
        PatternC = 2,
        /// <summary>
        ///   <para>Remote Play key layout configuration D.</para>
        /// </summary>
        PatternD = 3,
        /// <summary>
        ///   <para>Remote Play key layout configuration E.</para>
        /// </summary>
        PatternE = 4,
        /// <summary>
        ///   <para>Remote Play key layout configuration F.</para>
        /// </summary>
        PatternF = 5,
        /// <summary>
        ///   <para>Remote Play key layout configuration G.</para>
        /// </summary>
        PatternG = 6,
        /// <summary>
        ///   <para>Remote Play key layout configuration H.</para>
        /// </summary>
        PatternH = 7,
      }

      /// <summary>
      ///   <para>PS4 enter button assignment.</para>
      /// </summary>
      public enum PS4EnterButtonAssignment
      {
        /// <summary>
        ///   <para>Circle button.</para>
        /// </summary>
        CircleButton,
        /// <summary>
        ///   <para>Cross button.</para>
        /// </summary>
        CrossButton,
      }

      public enum PlayStationVREyeToEyeDistanceSettings
      {
        PerUser,
        ForceDefault,
        DynamicModeAtRuntime,
      }
    }

    /// <summary>
    ///   <para>PS Vita specific player settings.</para>
    /// </summary>
    public sealed class PSVita
    {
      /// <summary>
      ///   <para>Path specifying wher to copy a trophy pack from.</para>
      /// </summary>
      public static extern string npTrophyPackPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita power mode.</para>
      /// </summary>
      public static extern PlayerSettings.PSVita.PSVitaPowerMode powerMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Aquire PS Vita background music.</para>
      /// </summary>
      public static extern bool acquireBGM { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Support Game Boot Message or Game Joining Presence.</para>
      /// </summary>
      public static extern bool npSupportGBMorGJP { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita TV boot mode.</para>
      /// </summary>
      public static extern PlayerSettings.PSVita.PSVitaTvBootMode tvBootMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita TV Disable Emu flag.</para>
      /// </summary>
      public static extern bool tvDisableEmu { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Indicates that this is an upgradable (trial) type application which can be converted to a full application by purchasing an upgrade.</para>
      /// </summary>
      public static extern bool upgradable { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specifies whether or not a health warning will be added to the software manual.</para>
      /// </summary>
      public static extern bool healthWarning { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Support for the PS Vita location library was removed by SCE in SDK 3.570.</para>
      /// </summary>
      [Obsolete("useLibLocation has no effect as of SDK 3.570")]
      public static extern bool useLibLocation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specifies whether or not to show the PS Vita information bar when the application starts.</para>
      /// </summary>
      public static extern bool infoBarOnStartup { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specifies the color of the PS Vita information bar, true = white, false = black.</para>
      /// </summary>
      public static extern bool infoBarColor { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("UnityEditor.PSVita.useDebugIl2cppLibs no longer has any affect.")]
      internal static extern bool useDebugIl2cppLibs { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Indicates the IL2CPP scripts' optimization level in a range of 0 to 2. 0 indicates no optimization and 2 indicates maximum optimization.</para>
      /// </summary>
      public static extern int scriptOptimizationLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specifies whether circle or cross will be used as the default enter button.</para>
      /// </summary>
      public static extern PlayerSettings.PSVita.PSVitaEnterButtonAssignment enterButtonAssignment { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Save data quota.</para>
      /// </summary>
      public static extern int saveDataQuota { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita parental level.</para>
      /// </summary>
      public static extern int parentalLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The applications short title.</para>
      /// </summary>
      public static extern string shortTitle { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The applications content ID.</para>
      /// </summary>
      public static extern string contentID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The package build category.</para>
      /// </summary>
      public static extern PlayerSettings.PSVita.PSVitaAppCategory category { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita content master version.</para>
      /// </summary>
      public static extern string masterVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The PS Vita application version.</para>
      /// </summary>
      public static extern string appVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Support for the PS Vita twitter dialog was removed by SCE in SDK 3.570.</para>
      /// </summary>
      [Obsolete("AllowTwitterDialog has no effect as of SDK 3.570")]
      public static extern bool AllowTwitterDialog { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PSN Age rating.</para>
      /// </summary>
      public static extern int npAgeRating { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita NP Title Data File.</para>
      /// </summary>
      public static extern string npTitleDatPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita NP Communications ID.</para>
      /// </summary>
      public static extern string npCommunicationsID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita NP Passphrase.</para>
      /// </summary>
      public static extern string npCommsPassphrase { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita NP Signature.</para>
      /// </summary>
      public static extern string npCommsSig { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Path specifying where to copy the package parameter file (param.sfx) from.</para>
      /// </summary>
      public static extern string paramSfxPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita sofware manual.</para>
      /// </summary>
      public static extern string manualPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita Live area gate image.</para>
      /// </summary>
      public static extern string liveAreaGatePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita Live area background image.</para>
      /// </summary>
      public static extern string liveAreaBackroundPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita Live area path.</para>
      /// </summary>
      public static extern string liveAreaPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita Live area trial path.</para>
      /// </summary>
      public static extern string liveAreaTrialPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>For cumlative patch packages.</para>
      /// </summary>
      public static extern string patchChangeInfoPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>For building cumulative patch packages.</para>
      /// </summary>
      public static extern string patchOriginalPackage { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>32 character password for use if you want to access the contents of a package.</para>
      /// </summary>
      public static extern string packagePassword { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Keystone file.</para>
      /// </summary>
      public static extern string keystoneFile { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita memory expansion mode.</para>
      /// </summary>
      public static extern PlayerSettings.PSVita.PSVitaMemoryExpansionMode memoryExpansionMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita DRM Type.</para>
      /// </summary>
      public static extern PlayerSettings.PSVita.PSVitaDRMType drmType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>PS Vita media type.</para>
      /// </summary>
      public static extern int storageType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Should always = 01.00.</para>
      /// </summary>
      public static extern int mediaCapacity { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Power mode enum.</para>
      /// </summary>
      public enum PSVitaPowerMode
      {
        /// <summary>
        ///   <para>Mode A - default.</para>
        /// </summary>
        ModeA,
        /// <summary>
        ///   <para>Mode B - GPU High - No WLAN or COM.</para>
        /// </summary>
        ModeB,
        /// <summary>
        ///   <para>Mode C - GPU High - No Camera, OLED Low brightness.</para>
        /// </summary>
        ModeC,
      }

      /// <summary>
      ///   <para>PS Vita TV boot mode enum.</para>
      /// </summary>
      public enum PSVitaTvBootMode
      {
        /// <summary>
        ///   <para>Default (Managed by System Software) (SCEE or SCEA).</para>
        /// </summary>
        Default,
        /// <summary>
        ///   <para>PS Vita Bootable, PS Vita TV Bootable (SCEJ or SCE Asia).</para>
        /// </summary>
        PSVitaBootablePSVitaTvBootable,
        /// <summary>
        ///   <para>PS Vita Bootable, PS Vita TV Not Bootable (SCEJ or SCE Asia).</para>
        /// </summary>
        PSVitaBootablePSVitaTvNotBootable,
      }

      /// <summary>
      ///   <para>Enter button assignment enum.</para>
      /// </summary>
      public enum PSVitaEnterButtonAssignment
      {
        /// <summary>
        ///   <para>Default.</para>
        /// </summary>
        Default,
        /// <summary>
        ///   <para>Circle button.</para>
        /// </summary>
        CircleButton,
        /// <summary>
        ///   <para>Cross button.</para>
        /// </summary>
        CrossButton,
      }

      /// <summary>
      ///   <para>Application package category enum.</para>
      /// </summary>
      public enum PSVitaAppCategory
      {
        /// <summary>
        ///   <para>An application package.</para>
        /// </summary>
        Application,
        /// <summary>
        ///   <para>Application patch package.</para>
        /// </summary>
        ApplicationPatch,
      }

      /// <summary>
      ///   <para>Memory expansion mode enum.</para>
      /// </summary>
      public enum PSVitaMemoryExpansionMode
      {
        /// <summary>
        ///   <para>Memory expansion disabled.</para>
        /// </summary>
        None,
        /// <summary>
        ///   <para>Enable 29MB memory expansion mode.</para>
        /// </summary>
        ExpandBy29MB,
        /// <summary>
        ///   <para>Enable 77MB memory expansion mode.</para>
        /// </summary>
        ExpandBy77MB,
        /// <summary>
        ///   <para>Enable 109MB memory expansion mode.</para>
        /// </summary>
        ExpandBy109MB,
      }

      /// <summary>
      ///   <para>DRM type enum.</para>
      /// </summary>
      public enum PSVitaDRMType
      {
        /// <summary>
        ///   <para>Paid for content.</para>
        /// </summary>
        PaidFor,
        /// <summary>
        ///   <para>Free content.</para>
        /// </summary>
        Free,
      }
    }

    /// <summary>
    ///   <para>A single logo that is shown during the Splash Screen. Controls the Sprite that is displayed and its duration.</para>
    /// </summary>
    public struct SplashScreenLogo
    {
      private static Sprite s_UnityLogo = UnityEngine.Resources.GetBuiltinResource<Sprite>("UnitySplash-cube.png");
      private const float k_MinLogoTime = 2f;
      private Sprite m_Logo;
      private float m_Duration;

      [ExcludeFromDocs]
      public static PlayerSettings.SplashScreenLogo Create(float duration)
      {
        Sprite logo = (Sprite) null;
        return PlayerSettings.SplashScreenLogo.Create(duration, logo);
      }

      [ExcludeFromDocs]
      public static PlayerSettings.SplashScreenLogo Create()
      {
        return PlayerSettings.SplashScreenLogo.Create(2f, (Sprite) null);
      }

      /// <summary>
      ///   <para>Creates a new Splash Screen logo with the provided duration and logo Sprite.</para>
      /// </summary>
      /// <param name="duration">The total time in seconds that the logo will be shown. Note minimum time is 2 seconds.</param>
      /// <param name="logo">The logo Sprite to display.</param>
      /// <returns>
      ///   <para>The new logo.</para>
      /// </returns>
      public static PlayerSettings.SplashScreenLogo Create([DefaultValue("k_MinLogoTime")] float duration, [DefaultValue("null")] Sprite logo)
      {
        return new PlayerSettings.SplashScreenLogo()
        {
          m_Duration = duration,
          m_Logo = logo
        };
      }

      [ExcludeFromDocs]
      public static PlayerSettings.SplashScreenLogo CreateWithUnityLogo()
      {
        return PlayerSettings.SplashScreenLogo.CreateWithUnityLogo(2f);
      }

      /// <summary>
      ///   <para>Creates a new Splash Screen logo with the provided duration and the unity logo.</para>
      /// </summary>
      /// <param name="duration">The total time in seconds that the logo will be shown. Note minimum time is 2 seconds.</param>
      /// <returns>
      ///   <para>The new logo.</para>
      /// </returns>
      public static PlayerSettings.SplashScreenLogo CreateWithUnityLogo([DefaultValue("k_MinLogoTime")] float duration)
      {
        return new PlayerSettings.SplashScreenLogo()
        {
          m_Duration = duration,
          m_Logo = PlayerSettings.SplashScreenLogo.s_UnityLogo
        };
      }

      /// <summary>
      ///   <para>The Sprite that is shown during this logo. If this is null, then no logo will be displayed for the duration.</para>
      /// </summary>
      public Sprite logo
      {
        get
        {
          return this.m_Logo;
        }
        set
        {
          this.m_Logo = value;
        }
      }

      /// <summary>
      ///   <para>The Unity logo Sprite.</para>
      /// </summary>
      public static Sprite unityLogo
      {
        get
        {
          return PlayerSettings.SplashScreenLogo.s_UnityLogo;
        }
      }

      /// <summary>
      ///   <para>The total time in seconds for which the logo is shown. The minimum duration is 2 seconds.</para>
      /// </summary>
      public float duration
      {
        get
        {
          return Mathf.Max(this.m_Duration, 2f);
        }
        set
        {
          this.m_Duration = Mathf.Max(value, 2f);
        }
      }
    }

    /// <summary>
    ///   <para>Interface to splash screen player settings.</para>
    /// </summary>
    public sealed class SplashScreen
    {
      /// <summary>
      ///   <para>The type of animation applied during the splash screen.</para>
      /// </summary>
      public static extern PlayerSettings.SplashScreen.AnimationMode animationMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The target zoom (from 0 to 1) for the background when it reaches the end of the SplashScreen animation's total duration. Only used when animationMode is PlayerSettings.SplashScreen.AnimationMode.Custom|AnimationMode.Custom.</para>
      /// </summary>
      public static extern float animationBackgroundZoom { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The target zoom (from 0 to 1) for the logo when it reaches the end of the logo animation's total duration. Only used when animationMode is PlayerSettings.SplashScreen.AnimationMode.Custom|AnimationMode.Custom.</para>
      /// </summary>
      public static extern float animationLogoZoom { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The background Sprite that is shown in landscape mode. Also shown in portrait mode if backgroundPortrait is null.</para>
      /// </summary>
      public static extern Sprite background { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The background Sprite that is shown in portrait mode.</para>
      /// </summary>
      public static extern Sprite backgroundPortrait { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The background color shown if no background Sprite is assigned. Default is a dark blue RGB(34.44,54).</para>
      /// </summary>
      public static Color backgroundColor
      {
        get
        {
          Color color;
          PlayerSettings.SplashScreen.INTERNAL_get_backgroundColor(out color);
          return color;
        }
        set
        {
          PlayerSettings.SplashScreen.INTERNAL_set_backgroundColor(ref value);
        }
      }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void INTERNAL_get_backgroundColor(out Color value);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void INTERNAL_set_backgroundColor(ref Color value);

      /// <summary>
      ///   <para>Determines how the Unity logo should be drawn, if it is enabled. If no Unity logo exists in [logos] then the draw mode defaults to PlayerSettings.SplashScreen.DrawMode.UnityLogoBelow|DrawMode.UnityLogoBelow.</para>
      /// </summary>
      public static extern PlayerSettings.SplashScreen.DrawMode drawMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The collection of logos that is shown during the splash screen. Logos are drawn in ascending order, starting from index 0, followed by 1, etc etc.</para>
      /// </summary>
      public static extern PlayerSettings.SplashScreenLogo[] logos { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>In order to increase contrast between the background and the logos, an overlay color modifier is applied. The overlay opacity is the strength of this effect. Note: Reducing the value below 0.5 requires a Plus/Pro license.</para>
      /// </summary>
      public static extern float overlayOpacity { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Set this to true to display the Splash Screen be shown when the application is launched. Set it to false to disable the Splash Screen. Note: Disabling the Splash Screen requires a Plus/Pro license.</para>
      /// </summary>
      public static extern bool show { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Set this to true to show the Unity logo during the Splash Screen. Set it to false to disable the Unity logo. Note: Disabling the Unity logo requires a Plus/Pro license.</para>
      /// </summary>
      public static extern bool showUnityLogo { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The style to use for the Unity logo during the Splash Screen.</para>
      /// </summary>
      public static extern PlayerSettings.SplashScreen.UnityLogoStyle unityLogoStyle { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The type of animation applied during the Splash Screen.</para>
      /// </summary>
      public enum AnimationMode
      {
        /// <summary>
        ///   <para>No animation is applied to the Splash Screen logo or background.</para>
        /// </summary>
        Static,
        /// <summary>
        ///   <para>Animates the Splash Screen with a simulated dolly effect.</para>
        /// </summary>
        Dolly,
        /// <summary>
        ///   <para>Animates the Splash Screen using custom values from PlayerSettings.SplashScreen.animationBackgroundZoom and PlayerSettings.SplashScreen.animationLogoZoom.</para>
        /// </summary>
        Custom,
      }

      /// <summary>
      ///   <para>Determines how the Unity logo should be drawn, if it is enabled.</para>
      /// </summary>
      public enum DrawMode
      {
        /// <summary>
        ///   <para>The Unity logo is drawn in the lower portion of the screen for the duration of the Splash Screen, while the PlayerSettings.SplashScreen.logos are shown in the centre.</para>
        /// </summary>
        UnityLogoBelow,
        /// <summary>
        ///   <para>The Unity logo is shown sequentially providing it exists in the PlayerSettings.SplashScreen.logos collection.</para>
        /// </summary>
        AllSequential,
      }

      /// <summary>
      ///   <para>The style to use for the Unity logo during the Splash Screen.</para>
      /// </summary>
      public enum UnityLogoStyle
      {
        /// <summary>
        ///   <para>A dark Unity logo with a light background.</para>
        /// </summary>
        DarkOnLight,
        /// <summary>
        ///   <para>A white Unity logo with a dark background.</para>
        /// </summary>
        LightOnDark,
      }
    }

    /// <summary>
    ///   <para>Tizen application capabilities.</para>
    /// </summary>
    public enum TizenCapability
    {
      /// <summary>
      ///   <para></para>
      /// </summary>
      Location,
      /// <summary>
      ///   <para></para>
      /// </summary>
      DataSharing,
      /// <summary>
      ///   <para></para>
      /// </summary>
      NetworkGet,
      /// <summary>
      ///   <para></para>
      /// </summary>
      WifiDirect,
      /// <summary>
      ///   <para></para>
      /// </summary>
      CallHistoryRead,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Power,
      /// <summary>
      ///   <para></para>
      /// </summary>
      ContactWrite,
      /// <summary>
      ///   <para></para>
      /// </summary>
      MessageWrite,
      /// <summary>
      ///   <para></para>
      /// </summary>
      ContentWrite,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Push,
      /// <summary>
      ///   <para></para>
      /// </summary>
      AccountRead,
      /// <summary>
      ///   <para></para>
      /// </summary>
      ExternalStorage,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Recorder,
      /// <summary>
      ///   <para></para>
      /// </summary>
      PackageManagerInfo,
      /// <summary>
      ///   <para></para>
      /// </summary>
      NFCCardEmulation,
      /// <summary>
      ///   <para></para>
      /// </summary>
      CalendarWrite,
      /// <summary>
      ///   <para></para>
      /// </summary>
      WindowPrioritySet,
      /// <summary>
      ///   <para></para>
      /// </summary>
      VolumeSet,
      /// <summary>
      ///   <para></para>
      /// </summary>
      CallHistoryWrite,
      /// <summary>
      ///   <para></para>
      /// </summary>
      AlarmSet,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Call,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Email,
      /// <summary>
      ///   <para></para>
      /// </summary>
      ContactRead,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Shortcut,
      /// <summary>
      ///   <para></para>
      /// </summary>
      KeyManager,
      /// <summary>
      ///   <para></para>
      /// </summary>
      LED,
      /// <summary>
      ///   <para></para>
      /// </summary>
      NetworkProfile,
      /// <summary>
      ///   <para></para>
      /// </summary>
      AlarmGet,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Display,
      /// <summary>
      ///   <para></para>
      /// </summary>
      CalendarRead,
      /// <summary>
      ///   <para></para>
      /// </summary>
      NFC,
      /// <summary>
      ///   <para></para>
      /// </summary>
      AccountWrite,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Bluetooth,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Notification,
      /// <summary>
      ///   <para></para>
      /// </summary>
      NetworkSet,
      /// <summary>
      ///   <para></para>
      /// </summary>
      ExternalStorageAppData,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Download,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Telephony,
      /// <summary>
      ///   <para></para>
      /// </summary>
      MessageRead,
      /// <summary>
      ///   <para></para>
      /// </summary>
      MediaStorage,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Internet,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Camera,
      /// <summary>
      ///   <para></para>
      /// </summary>
      Haptic,
      /// <summary>
      ///   <para></para>
      /// </summary>
      AppManagerLaunch,
      /// <summary>
      ///   <para></para>
      /// </summary>
      SystemSettings,
    }

    /// <summary>
    ///   <para>Tizen specific player settings.</para>
    /// </summary>
    public sealed class Tizen
    {
      /// <summary>
      ///   <para>Description of your project to be displayed in the Tizen Store.</para>
      /// </summary>
      public static extern string productDescription { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>URL of your project to be displayed in the Tizen Store.</para>
      /// </summary>
      public static extern string productURL { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Name of the security profile to code sign Tizen applications with.</para>
      /// </summary>
      public static extern string signingProfileName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Currently chosen Tizen deployment target.</para>
      /// </summary>
      public static extern string deploymentTarget { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Choose a type of Tizen target to deploy to. Options are Device or Emulator.</para>
      /// </summary>
      public static extern int deploymentTargetType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Minimum Tizen OS version that this application is compatible with.
      ///   IMPORTANT: For example: if you choose Tizen 2.4 your application will only run on devices with Tizen 2.4 or later.</para>
      /// </summary>
      public static extern TizenOSVersion minOSVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Set or Get the style of application loading indicator. The available styles are TizenShowActivityIndicatorOnLoading.</para>
      /// </summary>
      public static extern TizenShowActivityIndicatorOnLoading showActivityIndicatorOnLoading { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static void SetCapability(PlayerSettings.TizenCapability capability, bool value)
      {
        PlayerSettings.Tizen.InternalSetCapability(capability.ToString(), value.ToString());
      }

      public static bool GetCapability(PlayerSettings.TizenCapability capability)
      {
        string capability1 = PlayerSettings.Tizen.InternalGetCapability(capability.ToString());
        if (string.IsNullOrEmpty(capability1))
          return false;
        try
        {
          return (bool) TypeDescriptor.GetConverter(typeof (bool)).ConvertFromString(capability1);
        }
        catch
        {
          Debug.LogError((object) ("Failed to parse value  ('" + capability.ToString() + "," + capability1 + "') to bool type."));
          return false;
        }
      }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void InternalSetCapability(string name, string value);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern string InternalGetCapability(string name);
    }

    /// <summary>
    ///   <para>tvOS specific player settings.</para>
    /// </summary>
    public sealed class tvOS
    {
      /// <summary>
      ///   <para>Active tvOS SDK version used for build.</para>
      /// </summary>
      public static extern tvOSSdkVersion sdkVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>The build number of the bundle</para>
      /// </summary>
      public static string buildNumber
      {
        get
        {
          return PlayerSettings.GetBuildNumber(BuildTargetGroup.tvOS);
        }
        set
        {
          PlayerSettings.SetBuildNumber(BuildTargetGroup.tvOS, value);
        }
      }

      /// <summary>
      ///   <para>Deployment minimal version of tvOS.</para>
      /// </summary>
      public static extern tvOSTargetOSVersion targetOSVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Deployment minimal version of tvOS.</para>
      /// </summary>
      public static extern string targetOSVersionString { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern Texture2D[] GetSmallIconLayers();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern Texture2D[] GetSmallIconLayers2x();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern Texture2D[] GetLargeIconLayers();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern Texture2D[] GetTopShelfImageLayers();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern Texture2D[] GetTopShelfImageLayers2x();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern Texture2D[] GetTopShelfImageWideLayers();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern Texture2D[] GetTopShelfImageWideLayers2x();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern void SetSmallIconLayers(Texture2D[] layers);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern void SetSmallIconLayers2x(Texture2D[] layers);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern void SetLargeIconLayers(Texture2D[] layers);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern void SetTopShelfImageLayers(Texture2D[] layers);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern void SetTopShelfImageLayers2x(Texture2D[] layers);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern void SetTopShelfImageWideLayers(Texture2D[] layers);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      internal static extern void SetTopShelfImageWideLayers2x(Texture2D[] layers);

      /// <summary>
      ///   <para>Application requires extended game controller.</para>
      /// </summary>
      public static extern bool requireExtendedGameController { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }
    }

    /// <summary>
    ///   <para>WebGL specific player settings.</para>
    /// </summary>
    public sealed class WebGL
    {
      /// <summary>
      ///   <para>Memory size for WebGL builds in MB.</para>
      /// </summary>
      public static extern int memorySize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Exception support for WebGL builds.</para>
      /// </summary>
      public static extern WebGLExceptionSupport exceptionSupport { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Enables automatic caching of asset data.</para>
      /// </summary>
      public static extern bool dataCaching { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string emscriptenArgs { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string modulesDirectory { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Path to the WebGL template asset.</para>
      /// </summary>
      public static extern string template { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool analyzeBuildSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool useEmbeddedResources { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool useWasm { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>CompressionFormat defines the compression type that the WebGL resources are encoded to.</para>
      /// </summary>
      public static extern WebGLCompressionFormat compressionFormat { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Enables using MD5 hash of the uncompressed file contents as a filename for each file in the build.</para>
      /// </summary>
      public static extern bool nameFilesAsHashes { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Enables generation of debug symbols file in the build output directory.</para>
      /// </summary>
      public static extern bool debugSymbols { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }
    }

    public sealed class WiiU
    {
      public static extern string titleID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string groupID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int commonSaveSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int accountSaveSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string olvAccessKey { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string tinCode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string joinGameId { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string joinGameModeMask { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int commonBossSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int accountBossSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string[] addOnUniqueIDs { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool supportsNunchuk { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool supportsClassicController { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool supportsBalanceBoard { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool supportsMotionPlus { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool supportsProController { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool allowScreenCapture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int controllerCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int mainThreadStackSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int loaderThreadStackSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int systemHeapSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern WiiUTVResolution tvResolution { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern Texture2D tvStartupScreen { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      public static extern Texture2D gamePadStartupScreen { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      public static extern int gamePadMSAA { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string profilerLibraryPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool drcBufferDisabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }
    }

    /// <summary>
    ///   <para>Player Settings for the Nintendo Switch platform.</para>
    /// </summary>
    public sealed class Switch
    {
      public static extern int socketMemoryPoolSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int socketAllocatorPoolSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int socketConcurrencyLimit { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool useSwitchCPUProfiler { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.Switch.ScreenResolutionBehavior screenResolutionBehavior { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string applicationID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string nsoDependencies { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string[] titleNames { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string[] publisherNames { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern Texture2D[] icons { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern Texture2D[] smallIcons { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static string manualHTMLPath
      {
        get
        {
          string manualHtmlPath = PlayerSettings.Switch.GetManualHTMLPath();
          if (string.IsNullOrEmpty(manualHtmlPath))
            return "";
          string path = manualHtmlPath;
          if (!Path.IsPathRooted(path))
            path = Path.GetFullPath(path);
          if (!Directory.Exists(path))
            return "";
          return path;
        }
        set
        {
          PlayerSettings.Switch.SetManualHTMLPath(!string.IsNullOrEmpty(value) ? value : "");
        }
      }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern string GetManualHTMLPath();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void SetManualHTMLPath(string path);

      public static string accessibleURLPath
      {
        get
        {
          string accessibleUrlPath = PlayerSettings.Switch.GetAccessibleURLPath();
          if (string.IsNullOrEmpty(accessibleUrlPath))
            return "";
          string path = accessibleUrlPath;
          if (!Path.IsPathRooted(path))
            path = Path.GetFullPath(path);
          return path;
        }
        set
        {
          PlayerSettings.Switch.SetAccessibleURLPath(!string.IsNullOrEmpty(value) ? value : "");
        }
      }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern string GetAccessibleURLPath();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void SetAccessibleURLPath(string path);

      public static string legalInformationPath
      {
        get
        {
          string path = PlayerSettings.Switch.GetLegalInformationPath();
          if (string.IsNullOrEmpty(path))
            return "";
          if (!Path.IsPathRooted(path))
            path = Path.GetFullPath(path);
          return path;
        }
        set
        {
          PlayerSettings.Switch.SetLegalInformationPath(!string.IsNullOrEmpty(value) ? value : "");
        }
      }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern string GetLegalInformationPath();

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void SetLegalInformationPath(string path);

      public static extern int mainThreadStackSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string presenceGroupId { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.Switch.LogoHandling logoHandling { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string releaseVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string displayVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.Switch.StartupUserAccount startupUserAccount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.Switch.TouchScreenUsage touchScreenUsage { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int supportedLanguages { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.Switch.LogoType logoType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string applicationErrorCodeCategory { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int userAccountSaveDataSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int userAccountSaveDataJournalSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.Switch.ApplicationAttribute applicationAttribute { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int cardSpecSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int cardSpecClock { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int ratingsMask { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      public static extern string[] localCommunicationIds { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool isUnderParentalControl { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      [Obsolete("isAllowsScreenshot has been deprecated. Use isScreenshotEnabled instead (UnityUpgradable) -> isScreenshotEnabled", true)]
      public static extern bool isAllowsScreenshot { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool isScreenshotEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool isVideoCapturingEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool isRuntimeAddOnContentInstallEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("isDataLossConfirmation has been deprecated. Use isDataLossConfirmationEnabled instead (UnityUpgradable) -> isDataLossConfirmationEnabled", true)]
      public static extern bool isDataLossConfirmation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool isDataLossConfirmationEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.Switch.SupportedNpadStyle supportedNpadStyles { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern int GetRatingAge(PlayerSettings.Switch.RatingCategories category);

      public static extern bool socketConfigEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int tcpInitialSendBufferSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int tcpInitialReceiveBufferSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int tcpAutoSendBufferSizeMax { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int tcpAutoReceiveBufferSizeMax { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int udpSendBufferSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int udpReceiveBufferSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int socketBufferEfficiency { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool socketInitializeEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool networkInterfaceManagerInitializeEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool playerConnectionEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public enum ScreenResolutionBehavior
      {
        Manual,
        OperationMode,
        PerformanceMode,
        Both,
      }

      public enum Languages
      {
        AmericanEnglish,
        BritishEnglish,
        Japanese,
        French,
        German,
        LatinAmericanSpanish,
        Spanish,
        Italian,
        Dutch,
        CanadianFrench,
        Portuguese,
        Russian,
        SimplifiedChinese,
        TraditionalChinese,
        Korean,
      }

      public enum StartupUserAccount
      {
        None,
        Required,
        RequiredWithNetworkServiceAccountAvailable,
      }

      public enum TouchScreenUsage
      {
        Supported,
        Required,
        None,
      }

      public enum LogoHandling
      {
        Auto,
        Manual,
      }

      public enum LogoType
      {
        LicensedByNintendo = 0,
        Nintendo = 2,
      }

      public enum ApplicationAttribute
      {
        None,
        Demo,
      }

      public enum RatingCategories
      {
        CERO,
        GRACGCRB,
        GSRMR,
        ESRB,
        ClassInd,
        USK,
        PEGI,
        PEGIPortugal,
        PEGIBBFC,
        Russian,
        ACB,
        OFLC,
      }

      private enum SupportedNpadStyleBits
      {
        FullKey = 1,
        Handheld = 2,
        JoyDual = 4,
        JoyLeft = 8,
        JoyRight = 16, // 0x00000010
      }

      [Flags]
      public enum SupportedNpadStyle
      {
        FullKey = 2,
        Handheld = 4,
        JoyDual = 16, // 0x00000010
        JoyLeft = 256, // 0x00000100
        JoyRight = 65536, // 0x00010000
      }
    }

    public enum WSAApplicationShowName
    {
      NotSet,
      AllLogos,
      NoLogos,
      StandardLogoOnly,
      WideLogoOnly,
    }

    public enum WSADefaultTileSize
    {
      NotSet,
      Medium,
      Wide,
    }

    public enum WSAApplicationForegroundText
    {
      Light = 1,
      Dark = 2,
    }

    /// <summary>
    ///   <para>Compilation overrides for C# files.</para>
    /// </summary>
    public enum WSACompilationOverrides
    {
      /// <summary>
      ///   <para>C# files are compiled using Mono compiler.</para>
      /// </summary>
      None,
      /// <summary>
      ///   <para>C# files are compiled using Microsoft compiler and .NET Core, you can use Windows Runtime API, but classes implemented in C# files aren't accessible from JS or Boo languages.</para>
      /// </summary>
      UseNetCore,
      /// <summary>
      ///   <para>C# files not located in Plugins, Standard Assets, Pro Standard Assets folders are compiled using Microsoft compiler and .NET Core, all other C# files are compiled using Mono compiler. The advantage is that classes implemented in C# are accessible from JS and Boo languages.</para>
      /// </summary>
      UseNetCorePartially,
    }

    public enum WSACapability
    {
      EnterpriseAuthentication,
      InternetClient,
      InternetClientServer,
      MusicLibrary,
      PicturesLibrary,
      PrivateNetworkClientServer,
      RemovableStorage,
      SharedUserCertificates,
      VideosLibrary,
      WebCam,
      Proximity,
      Microphone,
      Location,
      HumanInterfaceDevice,
      AllJoyn,
      BlockedChatMessages,
      Chat,
      CodeGeneration,
      Objects3D,
      PhoneCall,
      UserAccountInformation,
      VoipCall,
      Bluetooth,
      SpatialPerception,
      InputInjectionBrokered,
    }

    /// <summary>
    ///   <para>Various image scales, supported by Windows Store Apps.</para>
    /// </summary>
    public enum WSAImageScale
    {
      Target16 = 16, // 0x00000010
      Target24 = 24, // 0x00000018
      Target32 = 32, // 0x00000020
      Target48 = 48, // 0x00000030
      _80 = 80, // 0x00000050
      _100 = 100, // 0x00000064
      _125 = 125, // 0x0000007D
      _140 = 140, // 0x0000008C
      _150 = 150, // 0x00000096
      _180 = 180, // 0x000000B4
      _200 = 200, // 0x000000C8
      _240 = 240, // 0x000000F0
      Target256 = 256, // 0x00000100
      _400 = 400, // 0x00000190
    }

    /// <summary>
    ///   <para>Image types, supported by Windows Store Apps.</para>
    /// </summary>
    public enum WSAImageType
    {
      PackageLogo = 1,
      SplashScreenImage = 2,
      StoreTileLogo = 11, // 0x0000000B
      StoreTileWideLogo = 12, // 0x0000000C
      StoreTileSmallLogo = 13, // 0x0000000D
      StoreSmallTile = 14, // 0x0000000E
      StoreLargeTile = 15, // 0x0000000F
      PhoneAppIcon = 21, // 0x00000015
      PhoneSmallTile = 22, // 0x00000016
      PhoneMediumTile = 23, // 0x00000017
      PhoneWideTile = 24, // 0x00000018
      PhoneSplashScreen = 25, // 0x00000019
      UWPSquare44x44Logo = 31, // 0x0000001F
      UWPSquare71x71Logo = 32, // 0x00000020
      UWPSquare150x150Logo = 33, // 0x00000021
      UWPSquare310x310Logo = 34, // 0x00000022
      UWPWide310x150Logo = 35, // 0x00000023
    }

    /// <summary>
    ///   <para>Where Unity takes input from (subscripbes to events).</para>
    /// </summary>
    public enum WSAInputSource
    {
      /// <summary>
      ///   <para>Subscribe to CoreWindow events.</para>
      /// </summary>
      CoreWindow,
      /// <summary>
      ///   <para>Create Independent Input Source and receive input from it.</para>
      /// </summary>
      IndependentInputSource,
      /// <summary>
      ///   <para>Subscribe to SwapChainPanel events.</para>
      /// </summary>
      SwapChainPanel,
    }

    /// <summary>
    ///   <para>Describes supported file type for File Type Association declaration.</para>
    /// </summary>
    [RequiredByNativeCode]
    public struct WSASupportedFileType
    {
      /// <summary>
      ///   <para>The 'Content Type' value for the file type's MIME content type. For example: 'image/jpeg'. Can also be left blank.</para>
      /// </summary>
      public string contentType;
      /// <summary>
      ///   <para>File type extension. For ex., .myUnityGame</para>
      /// </summary>
      public string fileType;
    }

    /// <summary>
    ///   <para>Describes File Type Association declaration.</para>
    /// </summary>
    [RequiredByNativeCode]
    public struct WSAFileTypeAssociations
    {
      /// <summary>
      ///   <para>Localizable string that will be displayed to the user as associated file handler.</para>
      /// </summary>
      public string name;
      /// <summary>
      ///   <para>Supported file types for this association.</para>
      /// </summary>
      public PlayerSettings.WSASupportedFileType[] supportedFileTypes;
    }

    /// <summary>
    ///   <para>Windows Store Apps specific player settings.</para>
    /// </summary>
    public sealed class WSA
    {
      /// <summary>
      ///   <para>Sets AlphaMode on the swap chain to DXGI_ALPHA_MODE_PREMULTIPLIED.</para>
      /// </summary>
      public static extern bool transparentSwapchain { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string packageName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string packageLogo { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern string GetWSAImage(PlayerSettings.WSAImageType type, PlayerSettings.WSAImageScale scale);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void SetWSAImage(string image, PlayerSettings.WSAImageType type, PlayerSettings.WSAImageScale scale);

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string packageLogo140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string packageLogo180 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string packageLogo240 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      private static extern string packageVersionRaw { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string commandLineArgsFile { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern bool SetCertificate(string path, string password);

      public static extern string certificatePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      internal static extern string certificatePassword { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      public static extern string certificateSubject { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      public static extern string certificateIssuer { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      private static extern long certificateNotAfterRaw { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      public static extern string applicationDescription { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileLogo80 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileLogo { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileLogo140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileLogo180 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileWideLogo80 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileWideLogo { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileWideLogo140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileWideLogo180 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileSmallLogo80 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileSmallLogo { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileSmallLogo140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeTileSmallLogo180 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeSmallTile80 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeSmallTile { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeSmallTile140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeSmallTile180 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeLargeTile80 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeLargeTile { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeLargeTile140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeLargeTile180 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeSplashScreenImage { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeSplashScreenImageScale140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string storeSplashScreenImageScale180 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneAppIcon { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneAppIcon140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneAppIcon240 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneSmallTile { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneSmallTile140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneSmallTile240 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneMediumTile { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneMediumTile140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneMediumTile240 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneWideTile { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneWideTile140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneWideTile240 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneSplashScreenImage { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneSplashScreenImageScale140 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("Use GetVisualAssetsImage()/SetVisualAssetsImage()")]
      public static extern string phoneSplashScreenImageScale240 { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string tileShortName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.WSAApplicationShowName tileShowName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool mediumTileShowName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool largeTileShowName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool wideTileShowName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.WSADefaultTileSize defaultTileSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Specify how to compile C# files when building to Windows Store Apps.</para>
      /// </summary>
      public static extern PlayerSettings.WSACompilationOverrides compilationOverrides { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern PlayerSettings.WSAApplicationForegroundText tileForegroundText { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static Color tileBackgroundColor
      {
        get
        {
          Color color;
          PlayerSettings.WSA.INTERNAL_get_tileBackgroundColor(out color);
          return color;
        }
        set
        {
          PlayerSettings.WSA.INTERNAL_set_tileBackgroundColor(ref value);
        }
      }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void INTERNAL_get_tileBackgroundColor(out Color value);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void INTERNAL_set_tileBackgroundColor(ref Color value);

      /// <summary>
      ///   <para>Enable/Disable independent input source feature.</para>
      /// </summary>
      [Obsolete("PlayerSettings.WSA.enableIndependentInputSource is deprecated. Use PlayerSettings.WSA.inputSource.", false)]
      public static bool enableIndependentInputSource
      {
        get
        {
          return PlayerSettings.WSA.inputSource == PlayerSettings.WSAInputSource.IndependentInputSource;
        }
        set
        {
          PlayerSettings.WSA.inputSource = !value ? PlayerSettings.WSAInputSource.CoreWindow : PlayerSettings.WSAInputSource.IndependentInputSource;
        }
      }

      /// <summary>
      ///   <para>Where Unity gets input from.</para>
      /// </summary>
      public static extern PlayerSettings.WSAInputSource inputSource { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      /// <summary>
      ///   <para>Enable/Disable low latency presentation API.</para>
      /// </summary>
      [Obsolete("PlayerSettings.enableLowLatencyPresentationAPI is deprecated. It is now always enabled.", false)]
      public static extern bool enableLowLatencyPresentationAPI { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      private static extern bool splashScreenUseBackgroundColor { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      private static Color splashScreenBackgroundColorRaw
      {
        get
        {
          Color color;
          PlayerSettings.WSA.INTERNAL_get_splashScreenBackgroundColorRaw(out color);
          return color;
        }
        set
        {
          PlayerSettings.WSA.INTERNAL_set_splashScreenBackgroundColorRaw(ref value);
        }
      }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void INTERNAL_get_splashScreenBackgroundColorRaw(out Color value);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void INTERNAL_set_splashScreenBackgroundColorRaw(ref Color value);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void InternalSetCapability(string name, string value);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern string InternalGetCapability(string name);

      internal static extern string internalProtocolName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      internal static PlayerSettings.WSAFileTypeAssociations internalFileTypeAssociations
      {
        get
        {
          PlayerSettings.WSAFileTypeAssociations typeAssociations;
          PlayerSettings.WSA.INTERNAL_get_internalFileTypeAssociations(out typeAssociations);
          return typeAssociations;
        }
        set
        {
          PlayerSettings.WSA.INTERNAL_set_internalFileTypeAssociations(ref value);
        }
      }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void INTERNAL_get_internalFileTypeAssociations(out PlayerSettings.WSAFileTypeAssociations value);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      private static extern void INTERNAL_set_internalFileTypeAssociations(ref PlayerSettings.WSAFileTypeAssociations value);

      internal static string ValidatePackageVersion(string value)
      {
        if (new Regex("^(\\d+)\\.(\\d+)\\.(\\d+)\\.(\\d+)$", RegexOptions.Compiled | RegexOptions.CultureInvariant).IsMatch(value))
          return value;
        return "1.0.0.0";
      }

      private static void ValidateWSAImageType(PlayerSettings.WSAImageType type)
      {
        switch (type)
        {
          case PlayerSettings.WSAImageType.StoreTileLogo:
            break;
          case PlayerSettings.WSAImageType.StoreTileWideLogo:
            break;
          case PlayerSettings.WSAImageType.StoreTileSmallLogo:
            break;
          case PlayerSettings.WSAImageType.StoreSmallTile:
            break;
          case PlayerSettings.WSAImageType.StoreLargeTile:
            break;
          case PlayerSettings.WSAImageType.PhoneAppIcon:
            break;
          case PlayerSettings.WSAImageType.PhoneSmallTile:
            break;
          case PlayerSettings.WSAImageType.PhoneMediumTile:
            break;
          case PlayerSettings.WSAImageType.PhoneWideTile:
            break;
          case PlayerSettings.WSAImageType.PhoneSplashScreen:
            break;
          case PlayerSettings.WSAImageType.UWPSquare44x44Logo:
            break;
          case PlayerSettings.WSAImageType.UWPSquare71x71Logo:
            break;
          case PlayerSettings.WSAImageType.UWPSquare150x150Logo:
            break;
          case PlayerSettings.WSAImageType.UWPSquare310x310Logo:
            break;
          case PlayerSettings.WSAImageType.UWPWide310x150Logo:
            break;
          default:
            if (type == PlayerSettings.WSAImageType.PackageLogo || type == PlayerSettings.WSAImageType.SplashScreenImage)
              break;
            throw new Exception("Unknown WSA image type: " + (object) type);
        }
      }

      private static void ValidateWSAImageScale(PlayerSettings.WSAImageScale scale)
      {
        if (scale != PlayerSettings.WSAImageScale.Target16 && scale != PlayerSettings.WSAImageScale.Target24 && (scale != PlayerSettings.WSAImageScale.Target32 && scale != PlayerSettings.WSAImageScale.Target48) && (scale != PlayerSettings.WSAImageScale._80 && scale != PlayerSettings.WSAImageScale._100 && (scale != PlayerSettings.WSAImageScale._125 && scale != PlayerSettings.WSAImageScale._140)) && (scale != PlayerSettings.WSAImageScale._150 && scale != PlayerSettings.WSAImageScale._180 && (scale != PlayerSettings.WSAImageScale._200 && scale != PlayerSettings.WSAImageScale._240) && (scale != PlayerSettings.WSAImageScale.Target256 && scale != PlayerSettings.WSAImageScale._400)))
          throw new Exception("Unknown image scale: " + (object) scale);
      }

      public static string GetVisualAssetsImage(PlayerSettings.WSAImageType type, PlayerSettings.WSAImageScale scale)
      {
        PlayerSettings.WSA.ValidateWSAImageType(type);
        PlayerSettings.WSA.ValidateWSAImageScale(scale);
        return PlayerSettings.WSA.GetWSAImage(type, scale);
      }

      public static void SetVisualAssetsImage(string image, PlayerSettings.WSAImageType type, PlayerSettings.WSAImageScale scale)
      {
        PlayerSettings.WSA.ValidateWSAImageType(type);
        PlayerSettings.WSA.ValidateWSAImageScale(scale);
        PlayerSettings.WSA.SetWSAImage(image, type, scale);
      }

      public static Version packageVersion
      {
        get
        {
          try
          {
            return new Version(PlayerSettings.WSA.ValidatePackageVersion(PlayerSettings.WSA.packageVersionRaw));
          }
          catch (Exception ex)
          {
            throw new Exception(string.Format("{0}, the raw string was {1}", (object) ex.Message, (object) PlayerSettings.WSA.packageVersionRaw));
          }
        }
        set
        {
          PlayerSettings.WSA.packageVersionRaw = value.ToString();
        }
      }

      public static DateTime? certificateNotAfter
      {
        get
        {
          long certificateNotAfterRaw = PlayerSettings.WSA.certificateNotAfterRaw;
          if (certificateNotAfterRaw != 0L)
            return new DateTime?(DateTime.FromFileTime(certificateNotAfterRaw));
          return new DateTime?();
        }
      }

      public static Color? splashScreenBackgroundColor
      {
        get
        {
          if (PlayerSettings.WSA.splashScreenUseBackgroundColor)
            return new Color?(PlayerSettings.WSA.splashScreenBackgroundColorRaw);
          return new Color?();
        }
        set
        {
          PlayerSettings.WSA.splashScreenUseBackgroundColor = value.HasValue;
          if (!value.HasValue)
            return;
          PlayerSettings.WSA.splashScreenBackgroundColorRaw = value.Value;
        }
      }

      public static void SetCapability(PlayerSettings.WSACapability capability, bool value)
      {
        PlayerSettings.WSA.InternalSetCapability(capability.ToString(), value.ToString());
      }

      public static bool GetCapability(PlayerSettings.WSACapability capability)
      {
        string capability1 = PlayerSettings.WSA.InternalGetCapability(capability.ToString());
        if (string.IsNullOrEmpty(capability1))
          return false;
        try
        {
          return (bool) TypeDescriptor.GetConverter(typeof (bool)).ConvertFromString(capability1);
        }
        catch
        {
          Debug.LogError((object) ("Failed to parse value  ('" + capability.ToString() + "," + capability1 + "') to bool type."));
          return false;
        }
      }

      /// <summary>
      ///   <para>Windows Store Apps declarations.</para>
      /// </summary>
      public static class Declarations
      {
        /// <summary>
        ///   <para>
        ///     Registers this application to be a default handler for specified URI scheme name.
        /// 
        ///     For example: if you specify myunitygame, your application can be run from other applications via the URI scheme myunitygame:. You can also test this using the Windows "Run" dialog box (invoked with Windows + R key).
        /// 
        ///     For more information https:msdn.microsoft.comlibrarywindowsappshh779670https:msdn.microsoft.comlibrarywindowsappshh779670.</para>
        /// </summary>
        public static string protocolName
        {
          get
          {
            return PlayerSettings.WSA.internalProtocolName;
          }
          set
          {
            PlayerSettings.WSA.internalProtocolName = value;
          }
        }

        /// <summary>
        ///         <para>Set information for file type associations.
        /// 
        /// For more information - https:msdn.microsoft.comlibrarywindowsappshh779671https:msdn.microsoft.comlibrarywindowsappshh779671.</para>
        ///       </summary>
        public static PlayerSettings.WSAFileTypeAssociations fileTypeAssociations
        {
          get
          {
            return PlayerSettings.WSA.internalFileTypeAssociations;
          }
          set
          {
            PlayerSettings.WSA.internalFileTypeAssociations = value;
          }
        }
      }
    }

    /// <summary>
    ///   <para>Xbox One Specific Player Settings.</para>
    /// </summary>
    public sealed class XboxOne
    {
      public static extern XboxOneLoggingLevel defaultLoggingLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string ProductId { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string UpdateKey { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [Obsolete("SandboxId is obsolete please remove", true)]
      public static extern string SandboxId { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string ContentId { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string TitleId { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string SCID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool EnableVariableGPU { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern uint PresentImmediateThreshold { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool Enable7thCore { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern uint XTitleMemory { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool DisableKinectGpuReservation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool EnablePIXSampling { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string GameOsOverridePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string PackagingOverridePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern XboxOneEncryptionLevel PackagingEncryption { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern XboxOnePackageUpdateGranularity PackageUpdateGranularity { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string AppManifestOverridePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern bool IsContentPackage { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string Version { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern string Description { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void SetCapability(string capability, bool value);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern bool GetCapability(string capability);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void SetSupportedLanguage(string language, bool enabled);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern bool GetSupportedLanguage(string language);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void RemoveSocketDefinition(string name);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void SetSocketDefinition(string name, string port, int protocol, int[] usages, string templateName, int sessionRequirment, int[] deviceUsages);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void GetSocketDefinition(string name, out string port, out int protocol, out int[] usages, out string templateName, out int sessionRequirment, out int[] deviceUsages);

      public static extern string[] SocketNames { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      public static extern string[] AllowedProductIds { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void RemoveAllowedProductId(string id);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern bool AddAllowedProductId(string id);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void UpdateAllowedProductId(int idx, string id);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern void SetGameRating(string name, int value);

      [GeneratedByOldBindingsGenerator]
      [MethodImpl(MethodImplOptions.InternalCall)]
      public static extern int GetGameRating(string name);

      public static extern uint PersistentLocalStorageSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern int monoLoggingLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

      public static extern ScriptCompiler scriptCompiler { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }
    }

    /// <summary>
    ///   <para>Class used to access properties of the Oculus VR device.</para>
    /// </summary>
    public class VROculus
    {
      /// <summary>
      ///   <para>Enable Shared Depth Buffer support with Oculus.</para>
      /// </summary>
      public static bool sharedDepthBuffer
      {
        get
        {
          return PlayerSettingsOculus.sharedDepthBuffer;
        }
        set
        {
          PlayerSettingsOculus.sharedDepthBuffer = value;
        }
      }

      /// <summary>
      ///   <para>Enable Oculus Dash support for the application.</para>
      /// </summary>
      public static bool dashSupport
      {
        get
        {
          return PlayerSettingsOculus.dashSupport;
        }
        set
        {
          PlayerSettingsOculus.dashSupport = value;
        }
      }
    }
  }
}
