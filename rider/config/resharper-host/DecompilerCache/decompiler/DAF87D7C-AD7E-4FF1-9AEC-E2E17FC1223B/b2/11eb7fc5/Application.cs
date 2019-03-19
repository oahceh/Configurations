// Decompiled with JetBrains decompiler
// Type: UnityEngine.Application
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAF87D7C-AD7E-4FF1-9AEC-E2E17FC1223B
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Access to application run-time data.</para>
  /// </summary>
  public sealed class Application
  {
    internal static Application.AdvertisingIdentifierCallback OnAdvertisingIdentifierCallback;
    private static Application.LogCallback s_LogCallbackHandler;
    private static Application.LogCallback s_LogCallbackHandlerThreaded;
    private static volatile Application.LogCallback s_RegisterLogCallbackDeprecated;

    public static event Application.LowMemoryCallback lowMemory;

    [RequiredByNativeCode]
    private static void CallLowMemory()
    {
      // ISSUE: reference to a compiler-generated field
      Application.LowMemoryCallback lowMemory = Application.lowMemory;
      if (lowMemory == null)
        return;
      lowMemory();
    }

    /// <summary>
    ///   <para>Quits the player application.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Quit();

    /// <summary>
    ///   <para>Cancels quitting the application. This is useful for showing a splash screen at the end of a game.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void CancelQuit();

    /// <summary>
    ///   <para>Unloads the Unity runtime.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Unload();

    /// <summary>
    ///   <para>Is some level being loaded? (Read Only) (Obsolete).</para>
    /// </summary>
    [Obsolete("This property is deprecated, please use LoadLevelAsync to detect if a specific scene is currently loading.")]
    public static extern bool isLoadingLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern float GetStreamProgressForLevelByName(string levelName);

    /// <summary>
    ///   <para>How far has the download progressed? [0...1].</para>
    /// </summary>
    /// <param name="levelIndex"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float GetStreamProgressForLevel(int levelIndex);

    /// <summary>
    ///   <para>How far has the download progressed? [0...1].</para>
    /// </summary>
    /// <param name="levelName"></param>
    public static float GetStreamProgressForLevel(string levelName)
    {
      return Application.GetStreamProgressForLevelByName(levelName);
    }

    /// <summary>
    ///   <para>How many bytes have we downloaded from the main unity web stream (Read Only).</para>
    /// </summary>
    public static extern int streamedBytes { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool CanStreamedLevelBeLoadedByName(string levelName);

    /// <summary>
    ///   <para>Can the streamed level be loaded?</para>
    /// </summary>
    /// <param name="levelIndex"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool CanStreamedLevelBeLoaded(int levelIndex);

    /// <summary>
    ///   <para>Can the streamed level be loaded?</para>
    /// </summary>
    /// <param name="levelName"></param>
    public static bool CanStreamedLevelBeLoaded(string levelName)
    {
      return Application.CanStreamedLevelBeLoadedByName(levelName);
    }

    /// <summary>
    ///   <para>Returns true when in any kind of player is active.(Read Only).</para>
    /// </summary>
    public static extern bool isPlaying { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Whether the player currently has focus. Read-only.</para>
    /// </summary>
    public static extern bool isFocused { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Are we running inside the Unity editor? (Read Only)</para>
    /// </summary>
    public static extern bool isEditor { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Are we running inside a web player? (Read Only)</para>
    /// </summary>
    [Obsolete("This property is deprecated and will be removed in a future version of Unity, Webplayer support has been removed since Unity 5.4", true)]
    public static extern bool isWebPlayer { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns the platform the game is running on (Read Only).</para>
    /// </summary>
    [ThreadAndSerializationSafe]
    public static extern RuntimePlatform platform { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns an array of feature tags in use for this build.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string[] GetBuildTags();

    /// <summary>
    ///   <para>Set an array of feature tags for this build.</para>
    /// </summary>
    /// <param name="buildTags"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetBuildTags(string[] buildTags);

    /// <summary>
    ///   <para>Returns a GUID for this build (Read Only).</para>
    /// </summary>
    public static extern string buildGUID { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Is the current Runtime platform a known mobile platform.</para>
    /// </summary>
    public static bool isMobilePlatform
    {
      get
      {
        RuntimePlatform platform = Application.platform;
        switch (platform)
        {
          case RuntimePlatform.MetroPlayerX86:
          case RuntimePlatform.MetroPlayerX64:
          case RuntimePlatform.MetroPlayerARM:
            return SystemInfo.deviceType == DeviceType.Handheld;
          case RuntimePlatform.TizenPlayer:
label_2:
            return true;
          default:
            switch (platform - 8)
            {
              case RuntimePlatform.OSXEditor:
              case RuntimePlatform.OSXWebPlayer:
                goto label_2;
              default:
                return false;
            }
        }
      }
    }

    /// <summary>
    ///   <para>Is the current Runtime platform a known console platform.</para>
    /// </summary>
    public static bool isConsolePlatform
    {
      get
      {
        RuntimePlatform platform = Application.platform;
        return platform == RuntimePlatform.PS4 || platform == RuntimePlatform.XboxOne;
      }
    }

    /// <summary>
    ///   <para>Captures a screenshot at path filename as a PNG file.</para>
    /// </summary>
    /// <param name="filename">Pathname to save the screenshot file to.</param>
    /// <param name="superSize">Factor by which to increase resolution.</param>
    [Obsolete("Application.CaptureScreenshot is obsolete. Use ScreenCapture.CaptureScreenshot instead (UnityUpgradable) -> [UnityEngine] UnityEngine.ScreenCapture.CaptureScreenshot(*)", true)]
    public static void CaptureScreenshot(string filename, int superSize)
    {
      throw new NotSupportedException("Application.CaptureScreenshot is obsolete. Use ScreenCapture.CaptureScreenshot instead.");
    }

    /// <summary>
    ///   <para>Captures a screenshot at path filename as a PNG file.</para>
    /// </summary>
    /// <param name="filename">Pathname to save the screenshot file to.</param>
    /// <param name="superSize">Factor by which to increase resolution.</param>
    [Obsolete("Application.CaptureScreenshot is obsolete. Use ScreenCapture.CaptureScreenshot instead (UnityUpgradable) -> [UnityEngine] UnityEngine.ScreenCapture.CaptureScreenshot(*)", true)]
    public static void CaptureScreenshot(string filename)
    {
      throw new NotSupportedException("Application.CaptureScreenshot is obsolete. Use ScreenCapture.CaptureScreenshot instead.");
    }

    /// <summary>
    ///   <para>Should the player be running when the application is in the background?</para>
    /// </summary>
    public static extern bool runInBackground { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("use Application.isEditor instead")]
    public static bool isPlayer
    {
      get
      {
        return !Application.isEditor;
      }
    }

    /// <summary>
    ///   <para>Is Unity activated with the Pro license?</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasProLicense();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool HasAdvancedLicense();

    internal static extern bool isBatchmode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static extern bool isTestRun { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static extern bool isHumanControllingUs { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool HasARGV(string name);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string GetValueForARGV(string name);

    [Obsolete("Use Object.DontDestroyOnLoad instead")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void DontDestroyOnLoad(Object mono);

    /// <summary>
    ///   <para>Contains the path to the game data folder (Read Only).</para>
    /// </summary>
    public static extern string dataPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Contains the path to the StreamingAssets folder (Read Only).</para>
    /// </summary>
    public static extern string streamingAssetsPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Contains the path to a persistent data directory (Read Only).</para>
    /// </summary>
    [SecurityCritical]
    public static extern string persistentDataPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Contains the path to a temporary data / cache directory (Read Only).</para>
    /// </summary>
    public static extern string temporaryCachePath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The path to the web player data file relative to the html file (Read Only).</para>
    /// </summary>
    [Obsolete("Application.srcValue is obsolete and has no effect. It will be removed in a subsequent Unity release.", true)]
    public static extern string srcValue { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The URL of the document (what is shown in a browser's address bar) for WebGL (Read Only).</para>
    /// </summary>
    public static extern string absoluteURL { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    private static string ObjectToJSString(object o)
    {
      if (o == null)
        return "null";
      if (o is string)
        return 34.ToString() + o.ToString().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r").Replace("\0", "").Replace("\x2028", "").Replace("\x2029", "") + (object) '"';
      if (o is int || o is short || (o is uint || o is ushort) || o is byte)
        return o.ToString();
      if (o is float)
      {
        NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
        return ((float) o).ToString((IFormatProvider) numberFormat);
      }
      if (o is double)
      {
        NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
        return ((double) o).ToString((IFormatProvider) numberFormat);
      }
      if (o is char)
      {
        if ((char) o == '"')
          return "\"\\\"\"";
        return 34.ToString() + o.ToString() + (object) '"';
      }
      if (!(o is IList))
        return Application.ObjectToJSString((object) o.ToString());
      IList list = (IList) o;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("new Array(");
      int count = list.Count;
      for (int index = 0; index < count; ++index)
      {
        if (index != 0)
          stringBuilder.Append(", ");
        stringBuilder.Append(Application.ObjectToJSString(list[index]));
      }
      stringBuilder.Append(")");
      return stringBuilder.ToString();
    }

    /// <summary>
    ///   <para>Calls a function in the web page that contains the WebGL Player.</para>
    /// </summary>
    /// <param name="functionName">Name of the function to call.</param>
    /// <param name="args">Array of arguments passed in the call.</param>
    [Obsolete("Application.ExternalCall is deprecated. See https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html for alternatives.")]
    public static void ExternalCall(string functionName, params object[] args)
    {
      Application.Internal_ExternalCall(Application.BuildInvocationForArguments(functionName, args));
    }

    private static string BuildInvocationForArguments(string functionName, params object[] args)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(functionName);
      stringBuilder.Append('(');
      int length = args.Length;
      for (int index = 0; index < length; ++index)
      {
        if (index != 0)
          stringBuilder.Append(", ");
        stringBuilder.Append(Application.ObjectToJSString(args[index]));
      }
      stringBuilder.Append(')');
      stringBuilder.Append(';');
      return stringBuilder.ToString();
    }

    /// <summary>
    ///   <para>Execution of a script function in the contained web page.</para>
    /// </summary>
    /// <param name="script">The Javascript function to call.</param>
    [Obsolete("Application.ExternalEval is deprecated. See https://docs.unity3d.com/Manual/webgl-interactingwithbrowserscripting.html for alternatives.")]
    public static void ExternalEval(string script)
    {
      if (script.Length > 0 && script[script.Length - 1] != ';')
        script += (string) (object) ';';
      Application.Internal_ExternalCall(script);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_ExternalCall(string script);

    /// <summary>
    ///   <para>The version of the Unity runtime used to play the content.</para>
    /// </summary>
    public static extern string unityVersion { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns application version number  (Read Only).</para>
    /// </summary>
    public static extern string version { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns the name of the store or package that installed the application (Read Only).</para>
    /// </summary>
    public static extern string installerName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns application identifier at runtime. On Apple platforms this is the 'bundleIdentifier' saved in the info.plist file, on Android it's the 'package' from the AndroidManifest.xml. </para>
    /// </summary>
    public static extern string identifier { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns application install mode (Read Only).</para>
    /// </summary>
    public static extern ApplicationInstallMode installMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns application running in sandbox (Read Only).</para>
    /// </summary>
    public static extern ApplicationSandboxType sandboxType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns application product name (Read Only).</para>
    /// </summary>
    public static extern string productName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Return application company name (Read Only).</para>
    /// </summary>
    public static extern string companyName { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>A unique cloud project identifier. It is unique for every project (Read Only).</para>
    /// </summary>
    public static extern string cloudProjectId { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static void InvokeOnAdvertisingIdentifierCallback(string advertisingId, bool trackingEnabled)
    {
      if (Application.OnAdvertisingIdentifierCallback == null)
        return;
      Application.OnAdvertisingIdentifierCallback(advertisingId, trackingEnabled, string.Empty);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool RequestAdvertisingIdentifierAsync(Application.AdvertisingIdentifierCallback delegateMethod);

    /// <summary>
    ///   <para>Indicates whether Unity's webplayer security model is enabled.</para>
    /// </summary>
    [Obsolete("Application.webSecurityEnabled is no longer supported, since the Unity Web Player is no longer supported by Unity.", true)]
    [ThreadAndSerializationSafe]
    public static extern bool webSecurityEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [Obsolete("Application.webSecurityHostUrl is no longer supported, since the Unity Web Player is no longer supported by Unity.", true)]
    [ThreadAndSerializationSafe]
    public static extern string webSecurityHostUrl { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Opens the url in a browser.</para>
    /// </summary>
    /// <param name="url"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void OpenURL(string url);

    [Obsolete("For internal use only")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void ForceCrash(int mode);

    /// <summary>
    ///   <para>Instructs game to try to render at a specified frame rate.</para>
    /// </summary>
    public static extern int targetFrameRate { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The language the user's operating system is running in.</para>
    /// </summary>
    public static extern SystemLanguage systemLanguage { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public static event Application.LogCallback logMessageReceived
    {
      add
      {
        Application.s_LogCallbackHandler += value;
        Application.SetLogCallbackDefined(true);
      }
      remove
      {
        Application.s_LogCallbackHandler -= value;
      }
    }

    public static event Application.LogCallback logMessageReceivedThreaded
    {
      add
      {
        Application.s_LogCallbackHandlerThreaded += value;
        Application.SetLogCallbackDefined(true);
      }
      remove
      {
        Application.s_LogCallbackHandlerThreaded -= value;
      }
    }

    [RequiredByNativeCode]
    private static void CallLogCallback(string logString, string stackTrace, LogType type, bool invokedOnMainThread)
    {
      if (invokedOnMainThread)
      {
        Application.LogCallback logCallbackHandler = Application.s_LogCallbackHandler;
        if (logCallbackHandler != null)
          logCallbackHandler(logString, stackTrace, type);
      }
      Application.LogCallback callbackHandlerThreaded = Application.s_LogCallbackHandlerThreaded;
      if (callbackHandlerThreaded == null)
        return;
      callbackHandlerThreaded(logString, stackTrace, type);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetLogCallbackDefined(bool defined);

    /// <summary>
    ///   <para>Stack trace logging options. The default value is StackTraceLogType.ScriptOnly.</para>
    /// </summary>
    [Obsolete("Use SetStackTraceLogType/GetStackTraceLogType instead")]
    public static extern StackTraceLogType stackTraceLogType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Get stack trace logging options. The default value is StackTraceLogType.ScriptOnly.</para>
    /// </summary>
    /// <param name="logType"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern StackTraceLogType GetStackTraceLogType(LogType logType);

    /// <summary>
    ///   <para>Set stack trace logging options. The default value is StackTraceLogType.ScriptOnly.</para>
    /// </summary>
    /// <param name="logType"></param>
    /// <param name="stackTraceType"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType);

    /// <summary>
    ///   <para>Priority of background loading thread.</para>
    /// </summary>
    public static extern ThreadPriority backgroundLoadingPriority { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Returns the type of Internet reachability currently possible on the device.</para>
    /// </summary>
    public static extern NetworkReachability internetReachability { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns false if application is altered in any way after it was built.</para>
    /// </summary>
    public static extern bool genuine { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns true if application integrity can be confirmed.</para>
    /// </summary>
    public static extern bool genuineCheckAvailable { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Request authorization to use the webcam or microphone in the Web Player.</para>
    /// </summary>
    /// <param name="mode"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern AsyncOperation RequestUserAuthorization(UserAuthorization mode);

    /// <summary>
    ///   <para>Check if the user has authorized use of the webcam or microphone in the Web Player.</para>
    /// </summary>
    /// <param name="mode"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern bool HasUserAuthorization(UserAuthorization mode);

    internal static extern bool submitAnalytics { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Checks whether splash screen is being shown.</para>
    /// </summary>
    [Obsolete("This property is deprecated, please use SplashScreen.isFinished instead")]
    public static bool isShowingSplashScreen
    {
      get
      {
        return !SplashScreen.isFinished;
      }
    }

    public static event UnityAction onBeforeRender
    {
      add
      {
        BeforeRenderHelper.RegisterCallback(value);
      }
      remove
      {
        BeforeRenderHelper.UnregisterCallback(value);
      }
    }

    [RequiredByNativeCode]
    internal static void InvokeOnBeforeRender()
    {
      BeforeRenderHelper.Invoke();
    }

    [Obsolete("Application.RegisterLogCallback is deprecated. Use Application.logMessageReceived instead.")]
    public static void RegisterLogCallback(Application.LogCallback handler)
    {
      Application.RegisterLogCallback(handler, false);
    }

    [Obsolete("Application.RegisterLogCallbackThreaded is deprecated. Use Application.logMessageReceivedThreaded instead.")]
    public static void RegisterLogCallbackThreaded(Application.LogCallback handler)
    {
      Application.RegisterLogCallback(handler, true);
    }

    private static void RegisterLogCallback(Application.LogCallback handler, bool threaded)
    {
      if (Application.s_RegisterLogCallbackDeprecated != null)
      {
        Application.logMessageReceived -= Application.s_RegisterLogCallbackDeprecated;
        Application.logMessageReceivedThreaded -= Application.s_RegisterLogCallbackDeprecated;
      }
      Application.s_RegisterLogCallbackDeprecated = handler;
      if (handler == null)
        return;
      if (threaded)
        Application.logMessageReceivedThreaded += handler;
      else
        Application.logMessageReceived += handler;
    }

    /// <summary>
    ///   <para>The total number of levels available (Read Only).</para>
    /// </summary>
    [Obsolete("Use SceneManager.sceneCountInBuildSettings")]
    public static int levelCount
    {
      get
      {
        return SceneManager.sceneCountInBuildSettings;
      }
    }

    /// <summary>
    ///   <para>The level index that was last loaded (Read Only).</para>
    /// </summary>
    [Obsolete("Use SceneManager to determine what scenes have been loaded")]
    public static int loadedLevel
    {
      get
      {
        return SceneManager.GetActiveScene().buildIndex;
      }
    }

    /// <summary>
    ///   <para>The name of the level that was last loaded (Read Only).</para>
    /// </summary>
    [Obsolete("Use SceneManager to determine what scenes have been loaded")]
    public static string loadedLevelName
    {
      get
      {
        return SceneManager.GetActiveScene().name;
      }
    }

    /// <summary>
    ///   <para>Note: This is now obsolete. Use SceneManager.LoadScene instead.</para>
    /// </summary>
    /// <param name="index">The level to load.</param>
    /// <param name="name">The name of the level to load.</param>
    [Obsolete("Use SceneManager.LoadScene")]
    public static void LoadLevel(int index)
    {
      SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    /// <summary>
    ///   <para>Note: This is now obsolete. Use SceneManager.LoadScene instead.</para>
    /// </summary>
    /// <param name="index">The level to load.</param>
    /// <param name="name">The name of the level to load.</param>
    [Obsolete("Use SceneManager.LoadScene")]
    public static void LoadLevel(string name)
    {
      SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    /// <summary>
    ///   <para>Loads a level additively.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="name"></param>
    [Obsolete("Use SceneManager.LoadScene")]
    public static void LoadLevelAdditive(int index)
    {
      SceneManager.LoadScene(index, LoadSceneMode.Additive);
    }

    /// <summary>
    ///   <para>Loads a level additively.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="name"></param>
    [Obsolete("Use SceneManager.LoadScene")]
    public static void LoadLevelAdditive(string name)
    {
      SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    /// <summary>
    ///   <para>Loads the level asynchronously in the background.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="levelName"></param>
    [Obsolete("Use SceneManager.LoadSceneAsync")]
    public static AsyncOperation LoadLevelAsync(int index)
    {
      return SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
    }

    /// <summary>
    ///   <para>Loads the level asynchronously in the background.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="levelName"></param>
    [Obsolete("Use SceneManager.LoadSceneAsync")]
    public static AsyncOperation LoadLevelAsync(string levelName)
    {
      return SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
    }

    /// <summary>
    ///   <para>Loads the level additively and asynchronously in the background.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="levelName"></param>
    [Obsolete("Use SceneManager.LoadSceneAsync")]
    public static AsyncOperation LoadLevelAdditiveAsync(int index)
    {
      return SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    }

    /// <summary>
    ///   <para>Loads the level additively and asynchronously in the background.</para>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="levelName"></param>
    [Obsolete("Use SceneManager.LoadSceneAsync")]
    public static AsyncOperation LoadLevelAdditiveAsync(string levelName)
    {
      return SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
    }

    /// <summary>
    ///   <para>Unloads all GameObject associated with the given scene. Note that assets are currently not unloaded, in order to free up asset memory call Resources.UnloadAllUnusedAssets.</para>
    /// </summary>
    /// <param name="index">Index of the scene in the PlayerSettings to unload.</param>
    /// <param name="scenePath">Name of the scene to Unload.</param>
    /// <returns>
    ///   <para>Return true if the scene is unloaded.</para>
    /// </returns>
    [Obsolete("Use SceneManager.UnloadScene")]
    public static bool UnloadLevel(int index)
    {
      return SceneManager.UnloadScene(index);
    }

    /// <summary>
    ///   <para>Unloads all GameObject associated with the given scene. Note that assets are currently not unloaded, in order to free up asset memory call Resources.UnloadAllUnusedAssets.</para>
    /// </summary>
    /// <param name="index">Index of the scene in the PlayerSettings to unload.</param>
    /// <param name="scenePath">Name of the scene to Unload.</param>
    /// <returns>
    ///   <para>Return true if the scene is unloaded.</para>
    /// </returns>
    [Obsolete("Use SceneManager.UnloadScene")]
    public static bool UnloadLevel(string scenePath)
    {
      return SceneManager.UnloadScene(scenePath);
    }

    /// <summary>
    ///   <para>Delegate method for fetching advertising ID.</para>
    /// </summary>
    /// <param name="advertisingId">Advertising ID.</param>
    /// <param name="trackingEnabled">Indicates whether user has chosen to limit ad tracking.</param>
    /// <param name="errorMsg">Error message.</param>
    public delegate void AdvertisingIdentifierCallback(string advertisingId, bool trackingEnabled, string errorMsg);

    /// <summary>
    ///   <para>This is the delegate function when a mobile device notifies of low memory.</para>
    /// </summary>
    public delegate void LowMemoryCallback();

    /// <summary>
    ///   <para>Use this delegate type with Application.logMessageReceived or Application.logMessageReceivedThreaded to monitor what gets logged.</para>
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="stackTrace"></param>
    /// <param name="type"></param>
    public delegate void LogCallback(string condition, string stackTrace, LogType type);
  }
}
