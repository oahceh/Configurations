// Decompiled with JetBrains decompiler
// Type: UnityEditor.BuildPipeline
// Assembly: UnityEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CAE0D0B-DF8C-4E5E-A587-2403CEF1446A
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEditor.dll

using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor.BuildReporting;
using UnityEngine;
using UnityEngine.Scripting;

namespace UnityEditor
{
  /// <summary>
  ///   <para>Lets you programmatically build players or AssetBundles which can be loaded from the web.</para>
  /// </summary>
  public sealed class BuildPipeline
  {
    [GeneratedByOldBindingsGenerator]
    [ThreadAndSerializationSafe]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern BuildTargetGroup GetBuildTargetGroup(BuildTarget platform);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern BuildTargetGroup GetBuildTargetGroupByName(string platform);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern BuildTarget GetBuildTargetByName(string platform);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetBuildTargetGroupDisplayName(BuildTargetGroup targetPlatformGroup);

    [GeneratedByOldBindingsGenerator]
    [ThreadAndSerializationSafe]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetBuildTargetName(BuildTarget targetPlatform);

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetEditorTargetName();

    /// <summary>
    ///   <para>Lets you manage cross-references and dependencies between different asset bundles and player builds.</para>
    /// </summary>
    [Obsolete("PushAssetDependencies has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void PushAssetDependencies();

    /// <summary>
    ///   <para>Lets you manage cross-references and dependencies between different asset bundles and player builds.</para>
    /// </summary>
    [Obsolete("PopAssetDependencies has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void PopAssetDependencies();

    private static string[] InvokeCalculateBuildTags(BuildTarget target, BuildTargetGroup group)
    {
      return new string[0];
    }

    private static void LogBuildExceptionAndExit(string buildFunctionName, Exception exception)
    {
      Debug.LogErrorFormat("Internal Error in {0}:", (object) buildFunctionName);
      Debug.LogException(exception);
      EditorApplication.Exit(1);
    }

    /// <summary>
    ///   <para>Builds a player. These overloads are still supported, but will be replaced. Please use BuildPlayer (BuildPlayerOptions buildPlayerOptions)  instead.</para>
    /// </summary>
    /// <param name="levels">The scenes to be included in the build. If empty, the currently open scene will be built. Paths are relative to the project folder (AssetsMyLevelsMyScene.unity).</param>
    /// <param name="locationPathName">The path where the application will be built.</param>
    /// <param name="target">The BuildTarget to build.</param>
    /// <param name="options">Additional BuildOptions, like whether to run the built player.</param>
    /// <returns>
    ///   <para>An error message if an error occurred.</para>
    /// </returns>
    public static string BuildPlayer(EditorBuildSettingsScene[] levels, string locationPathName, BuildTarget target, BuildOptions options)
    {
      return BuildPipeline.BuildPlayer(new BuildPlayerOptions()
      {
        scenes = EditorBuildSettingsScene.GetActiveSceneList(levels),
        locationPathName = locationPathName,
        target = target,
        options = options
      });
    }

    /// <summary>
    ///   <para>Builds a player. These overloads are still supported, but will be replaced. Please use BuildPlayer (BuildPlayerOptions buildPlayerOptions)  instead.</para>
    /// </summary>
    /// <param name="levels">The scenes to be included in the build. If empty, the currently open scene will be built. Paths are relative to the project folder (AssetsMyLevelsMyScene.unity).</param>
    /// <param name="locationPathName">The path where the application will be built.</param>
    /// <param name="target">The BuildTarget to build.</param>
    /// <param name="options">Additional BuildOptions, like whether to run the built player.</param>
    /// <returns>
    ///   <para>An error message if an error occurred.</para>
    /// </returns>
    public static string BuildPlayer(string[] levels, string locationPathName, BuildTarget target, BuildOptions options)
    {
      BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(target);
      return BuildPipeline.BuildPlayer(new BuildPlayerOptions()
      {
        scenes = levels,
        locationPathName = locationPathName,
        targetGroup = buildTargetGroup,
        target = target,
        options = options
      });
    }

    /// <summary>
    ///   <para>Builds a player.</para>
    /// </summary>
    /// <param name="buildPlayerOptions">Provide various options to control the behavior of BuildPipeline.BuildPlayer.</param>
    /// <returns>
    ///   <para>An error message if an error occurred.</para>
    /// </returns>
    public static string BuildPlayer(BuildPlayerOptions buildPlayerOptions)
    {
      return BuildPipeline.BuildPlayer(buildPlayerOptions.scenes, buildPlayerOptions.locationPathName, buildPlayerOptions.assetBundleManifestPath, buildPlayerOptions.targetGroup, buildPlayerOptions.target, buildPlayerOptions.options);
    }

    private static string BuildPlayer(string[] scenes, string locationPathName, string assetBundleManifestPath, BuildTargetGroup buildTargetGroup, BuildTarget target, BuildOptions options)
    {
      if (BuildPipeline.isBuildingPlayer)
        return "Cannot start a new build because there is already a build in progress.";
      if (buildTargetGroup == BuildTargetGroup.Unknown)
        buildTargetGroup = BuildPipeline.GetBuildTargetGroup(target);
      string errorMessage;
      if (!BuildPipeline.ValidateLocationPathNameForBuildTargetGroup(locationPathName, buildTargetGroup, target, options, out errorMessage))
        return errorMessage;
      try
      {
        return BuildPipeline.BuildPlayerInternal(scenes, locationPathName, assetBundleManifestPath, buildTargetGroup, target, options).SummarizeErrors();
      }
      catch (Exception ex)
      {
        BuildPipeline.LogBuildExceptionAndExit("BuildPipeline.BuildPlayer", ex);
        return "";
      }
    }

    internal static bool ValidateLocationPathNameForBuildTargetGroup(string locationPathName, BuildTargetGroup buildTargetGroup, BuildTarget target, BuildOptions options, out string errorMessage)
    {
      if (string.IsNullOrEmpty(locationPathName))
      {
        if ((options & BuildOptions.InstallInBuildFolder) == BuildOptions.None || !PostprocessBuildPlayer.SupportsInstallInBuildFolder(buildTargetGroup, target))
        {
          errorMessage = "The 'locationPathName' parameter for BuildPipeline.BuildPlayer should not be null or empty.";
          return false;
        }
      }
      else if (string.IsNullOrEmpty(Path.GetFileName(locationPathName)))
      {
        string extensionForBuildTarget = PostprocessBuildPlayer.GetExtensionForBuildTarget(buildTargetGroup, target, options);
        if (!string.IsNullOrEmpty(extensionForBuildTarget))
        {
          errorMessage = string.Format("For the '{0}' target the 'locationPathName' parameter for BuildPipeline.BuildPlayer should not end with a directory separator.\nProvided path: '{1}', expected a path with the extension '.{2}'.", (object) target, (object) locationPathName, (object) extensionForBuildTarget);
          return false;
        }
      }
      errorMessage = "";
      return true;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsFeatureSupported(string define, BuildTarget platform);

    /// <summary>
    ///   <para>Builds one or more scenes and all their dependencies into a compressed asset bundle.</para>
    /// </summary>
    /// <param name="levels">Pathnames of levels to include in the asset bundle.</param>
    /// <param name="locationPath">Pathname for the output asset bundle.</param>
    /// <param name="target">Runtime platform on which the asset bundle will be used.</param>
    /// <param name="crc">Output parameter to receive CRC checksum of generated assetbundle.</param>
    /// <param name="options">Build options. See BuildOptions for possible values.</param>
    /// <returns>
    ///   <para>String with an error message, empty on success.</para>
    /// </returns>
    [Obsolete("BuildStreamedSceneAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    public static string BuildStreamedSceneAssetBundle(string[] levels, string locationPath, BuildTarget target, BuildOptions options)
    {
      return BuildPipeline.BuildPlayer(levels, locationPath, target, options | BuildOptions.BuildAdditionalStreamedScenes);
    }

    /// <summary>
    ///   <para>Builds one or more scenes and all their dependencies into a compressed asset bundle.</para>
    /// </summary>
    /// <param name="levels">Pathnames of levels to include in the asset bundle.</param>
    /// <param name="locationPath">Pathname for the output asset bundle.</param>
    /// <param name="target">Runtime platform on which the asset bundle will be used.</param>
    /// <param name="crc">Output parameter to receive CRC checksum of generated assetbundle.</param>
    /// <param name="options">Build options. See BuildOptions for possible values.</param>
    /// <returns>
    ///   <para>String with an error message, empty on success.</para>
    /// </returns>
    [Obsolete("BuildStreamedSceneAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    public static string BuildStreamedSceneAssetBundle(string[] levels, string locationPath, BuildTarget target)
    {
      return BuildPipeline.BuildPlayer(levels, locationPath, target, BuildOptions.BuildAdditionalStreamedScenes);
    }

    [Obsolete("BuildStreamedSceneAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    public static string BuildStreamedSceneAssetBundle(string[] levels, string locationPath, BuildTarget target, out uint crc, BuildOptions options)
    {
      BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(target);
      return BuildPipeline.BuildStreamedSceneAssetBundle(levels, locationPath, buildTargetGroup, target, out crc, options);
    }

    [Obsolete("BuildStreamedSceneAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    internal static string BuildStreamedSceneAssetBundle(string[] levels, string locationPath, BuildTargetGroup buildTargetGroup, BuildTarget target, out uint crc, BuildOptions options)
    {
      crc = 0U;
      try
      {
        BuildReport buildReport = BuildPipeline.BuildPlayerInternal(levels, locationPath, (string) null, buildTargetGroup, target, options | BuildOptions.BuildAdditionalStreamedScenes | BuildOptions.ComputeCRC);
        crc = buildReport.crc;
        string str = buildReport.SummarizeErrors();
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) buildReport, true);
        return str;
      }
      catch (Exception ex)
      {
        BuildPipeline.LogBuildExceptionAndExit("BuildPipeline.BuildStreamedSceneAssetBundle", ex);
        return "";
      }
    }

    [Obsolete("BuildStreamedSceneAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    public static string BuildStreamedSceneAssetBundle(string[] levels, string locationPath, BuildTarget target, out uint crc)
    {
      return BuildPipeline.BuildStreamedSceneAssetBundle(levels, locationPath, target, out crc, BuildOptions.None);
    }

    private static BuildReport BuildPlayerInternal(string[] levels, string locationPathName, string assetBundleManifestPath, BuildTargetGroup buildTargetGroup, BuildTarget target, BuildOptions options)
    {
      if ((BuildOptions.EnableHeadlessMode & options) != BuildOptions.None && (BuildOptions.Development & options) != BuildOptions.None)
        throw new Exception("Unsupported build setting: cannot build headless development player");
      return BuildPipeline.BuildPlayerInternalNoCheck(levels, locationPathName, assetBundleManifestPath, buildTargetGroup, target, options, false);
    }

    /// <summary>
    ///   <para>Is a player currently being built?</para>
    /// </summary>
    public static extern bool isBuildingPlayer { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern BuildReport BuildPlayerInternalNoCheck(string[] levels, string locationPathName, string assetBundleManifestPath, BuildTargetGroup buildTargetGroup, BuildTarget target, BuildOptions options, bool delayToAfterScriptReload);

    /// <summary>
    ///   <para>Builds an asset bundle.</para>
    /// </summary>
    /// <param name="mainAsset">Lets you specify a specific object that can be conveniently retrieved using AssetBundle.mainAsset.</param>
    /// <param name="assets">An array of assets to write into the bundle.</param>
    /// <param name="pathName">The filename where to write the compressed asset bundle.</param>
    /// <param name="assetBundleOptions">Automatically include dependencies or always include complete assets instead of just the exact referenced objects.</param>
    /// <param name="targetPlatform">The platform to build the bundle for.</param>
    /// <param name="crc">The optional crc output parameter can be used to get a CRC checksum for the generated AssetBundle, which can be used to verify content when downloading AssetBundles using UnityWebRequest.GetAssetBundle.</param>
    [Obsolete("BuildAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    public static bool BuildAssetBundle(UnityEngine.Object mainAsset, UnityEngine.Object[] assets, string pathName, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform)
    {
      uint crc;
      return BuildPipeline.BuildAssetBundle(mainAsset, assets, pathName, out crc, assetBundleOptions, targetPlatform);
    }

    [Obsolete("BuildAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    public static bool BuildAssetBundle(UnityEngine.Object mainAsset, UnityEngine.Object[] assets, string pathName, out uint crc, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform)
    {
      BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(targetPlatform);
      return BuildPipeline.BuildAssetBundle(mainAsset, assets, pathName, out crc, assetBundleOptions, buildTargetGroup, targetPlatform);
    }

    internal static bool BuildAssetBundle(UnityEngine.Object mainAsset, UnityEngine.Object[] assets, string pathName, out uint crc, BuildAssetBundleOptions assetBundleOptions, BuildTargetGroup targetPlatformGroup, BuildTarget targetPlatform)
    {
      crc = 0U;
      try
      {
        return BuildPipeline.BuildAssetBundleInternal(mainAsset, assets, (string[]) null, pathName, assetBundleOptions, targetPlatformGroup, targetPlatform, out crc);
      }
      catch (Exception ex)
      {
        BuildPipeline.LogBuildExceptionAndExit("BuildPipeline.BuildAssetBundle", ex);
        return false;
      }
    }

    /// <summary>
    ///   <para>Builds an asset bundle, with custom names for the assets.</para>
    /// </summary>
    /// <param name="assets">A collection of assets to be built into the asset bundle. Asset bundles can contain any asset found in the project folder.</param>
    /// <param name="assetNames">An array of strings of the same size as the number of assets.
    /// These will be used as asset names, which you can then pass to AssetBundle.Load to load a specific asset. Use BuildAssetBundle to just use the asset's path names instead.</param>
    /// <param name="pathName">The location where the compressed asset bundle will be written to.</param>
    /// <param name="assetBundleOptions">Automatically include dependencies or always include complete assets instead of just the exact referenced objects.</param>
    /// <param name="targetPlatform">The platform where the asset bundle will be used.</param>
    /// <param name="crc">An optional output parameter used to get a CRC checksum for the generated AssetBundle. (Used to verify content when downloading AssetBundles using UnityWebRequest.GetAssetBundle().)</param>
    [Obsolete("BuildAssetBundleExplicitAssetNames has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    public static bool BuildAssetBundleExplicitAssetNames(UnityEngine.Object[] assets, string[] assetNames, string pathName, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform)
    {
      uint crc;
      return BuildPipeline.BuildAssetBundleExplicitAssetNames(assets, assetNames, pathName, out crc, assetBundleOptions, targetPlatform);
    }

    [Obsolete("BuildAssetBundleExplicitAssetNames has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
    public static bool BuildAssetBundleExplicitAssetNames(UnityEngine.Object[] assets, string[] assetNames, string pathName, out uint crc, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform)
    {
      BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(targetPlatform);
      return BuildPipeline.BuildAssetBundleExplicitAssetNames(assets, assetNames, pathName, out crc, assetBundleOptions, buildTargetGroup, targetPlatform);
    }

    internal static bool BuildAssetBundleExplicitAssetNames(UnityEngine.Object[] assets, string[] assetNames, string pathName, out uint crc, BuildAssetBundleOptions assetBundleOptions, BuildTargetGroup targetPlatformGroup, BuildTarget targetPlatform)
    {
      crc = 0U;
      try
      {
        return BuildPipeline.BuildAssetBundleInternal((UnityEngine.Object) null, assets, assetNames, pathName, assetBundleOptions, targetPlatformGroup, targetPlatform, out crc);
      }
      catch (Exception ex)
      {
        BuildPipeline.LogBuildExceptionAndExit("BuildPipeline.BuildAssetBundleExplicitAssetNames", ex);
        return false;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool BuildAssetBundleInternal(UnityEngine.Object mainAsset, UnityEngine.Object[] assets, string[] assetNames, string pathName, BuildAssetBundleOptions assetBundleOptions, BuildTargetGroup targetPlatformGroup, BuildTarget targetPlatform, out uint crc);

    /// <summary>
    ///   <para>Build all AssetBundles specified in the editor.</para>
    /// </summary>
    /// <param name="outputPath">Output path for the AssetBundles.</param>
    /// <param name="assetBundleOptions">AssetBundle building options.</param>
    /// <param name="targetPlatform">Chosen target build platform.</param>
    /// <returns>
    ///   <para>The manifest listing all AssetBundles included in this build.</para>
    /// </returns>
    public static AssetBundleManifest BuildAssetBundles(string outputPath, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform)
    {
      BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(targetPlatform);
      return BuildPipeline.BuildAssetBundles(outputPath, assetBundleOptions, buildTargetGroup, targetPlatform);
    }

    internal static AssetBundleManifest BuildAssetBundles(string outputPath, BuildAssetBundleOptions assetBundleOptions, BuildTargetGroup targetPlatformGroup, BuildTarget targetPlatform)
    {
      if (!Directory.Exists(outputPath))
        throw new ArgumentException("The output path \"" + outputPath + "\" doesn't exist");
      return BuildPipeline.BuildAssetBundlesInternal(outputPath, assetBundleOptions, targetPlatformGroup, targetPlatform);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern AssetBundleManifest BuildAssetBundlesInternal(string outputPath, BuildAssetBundleOptions assetBundleOptions, BuildTargetGroup targetPlatformGroup, BuildTarget targetPlatform);

    /// <summary>
    ///   <para>Build AssetBundles from a building map.</para>
    /// </summary>
    /// <param name="outputPath">Output path for the AssetBundles.</param>
    /// <param name="builds">AssetBundle building map.</param>
    /// <param name="assetBundleOptions">AssetBundle building options.</param>
    /// <param name="targetPlatform">Target build platform.</param>
    /// <returns>
    ///   <para>The manifest listing all AssetBundles included in this build.</para>
    /// </returns>
    public static AssetBundleManifest BuildAssetBundles(string outputPath, AssetBundleBuild[] builds, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform)
    {
      BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(targetPlatform);
      return BuildPipeline.BuildAssetBundles(outputPath, builds, assetBundleOptions, buildTargetGroup, targetPlatform);
    }

    internal static AssetBundleManifest BuildAssetBundles(string outputPath, AssetBundleBuild[] builds, BuildAssetBundleOptions assetBundleOptions, BuildTargetGroup targetPlatformGroup, BuildTarget targetPlatform)
    {
      if (!Directory.Exists(outputPath))
        throw new ArgumentException("The output path \"" + outputPath + "\" doesn't exist");
      if (builds == null)
        throw new ArgumentException("AssetBundleBuild cannot be null.");
      return BuildPipeline.BuildAssetBundlesWithInfoInternal(outputPath, builds, assetBundleOptions, targetPlatformGroup, targetPlatform);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern AssetBundleManifest BuildAssetBundlesWithInfoInternal(string outputPath, AssetBundleBuild[] builds, BuildAssetBundleOptions assetBundleOptions, BuildTargetGroup targetPlatformGroup, BuildTarget targetPlatform);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool GetCRCForAssetBundle(string targetPath, out uint crc);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool GetHashForAssetBundle(string targetPath, out Hash128 hash);

    [ThreadAndSerializationSafe]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool LicenseCheck(BuildTarget target);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsBuildTargetSupported(BuildTargetGroup buildTargetGroup, BuildTarget target);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsBuildTargetCompatibleWithOS(BuildTarget target);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetBuildTargetAdvancedLicenseName(BuildTarget target);

    internal static string GetPlaybackEngineDirectory(BuildTarget target, BuildOptions options)
    {
      return BuildPipeline.GetPlaybackEngineDirectory(BuildPipeline.GetBuildTargetGroup(target), target, options);
    }

    [GeneratedByOldBindingsGenerator]
    [ThreadAndSerializationSafe]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetPlaybackEngineDirectory(BuildTargetGroup buildTargetGroup, BuildTarget target, BuildOptions options);

    [GeneratedByOldBindingsGenerator]
    [ThreadAndSerializationSafe]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetPlaybackEngineExtensionDirectory(BuildTargetGroup buildTargetGroup, BuildTarget target, BuildOptions options);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void SetPlaybackEngineDirectory(BuildTargetGroup buildTargetGroup, BuildTarget target, BuildOptions options, string playbackEngineDirectory);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetBuildToolsDirectory(BuildTarget target);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetMonoBinDirectory(BuildTarget target);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetMonoLibDirectory(BuildTarget target);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string CompatibilityProfileToClassLibFolder(ApiCompatibilityLevel compatibilityLevel);

    internal static string GetBuildTargetGroupName(BuildTarget target)
    {
      return BuildPipeline.GetBuildTargetGroupName(BuildPipeline.GetBuildTargetGroup(target));
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetBuildTargetGroupName(BuildTargetGroup buildTargetGroup);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsUnityScriptEvalSupported(BuildTarget target);

    internal static string[] GetReferencingPlayerAssembliesForDLL(string dllPath)
    {
      DefaultAssemblyResolver assemblyResolver1 = new DefaultAssemblyResolver();
      assemblyResolver1.AddSearchDirectory(Path.GetDirectoryName(dllPath));
      AssemblyDefinition assemblyDefinition = AssemblyDefinition.ReadAssembly(dllPath, new ReaderParameters()
      {
        AssemblyResolver = (IAssemblyResolver) assemblyResolver1
      });
      string[] managedPlayerDllPaths = BuildPipeline.GetManagedPlayerDllPaths();
      List<string> stringList = new List<string>();
      foreach (string path in managedPlayerDllPaths)
      {
        DefaultAssemblyResolver assemblyResolver2 = new DefaultAssemblyResolver();
        assemblyResolver2.AddSearchDirectory(Path.GetDirectoryName(path));
        string fileName = path;
        ReaderParameters parameters = new ReaderParameters()
        {
          AssemblyResolver = (IAssemblyResolver) assemblyResolver2
        };
        foreach (AssemblyNameReference assemblyReference in AssemblyDefinition.ReadAssembly(fileName, parameters).MainModule.AssemblyReferences)
        {
          if (assemblyReference.FullName == assemblyDefinition.Name.FullName)
            stringList.Add(path);
        }
      }
      return stringList.ToArray();
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string[] GetManagedPlayerDllPaths();
  }
}
