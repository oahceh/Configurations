// Decompiled with JetBrains decompiler
// Type: UnityEngine.WWW
// Assembly: UnityEngine.UnityWebRequestWWWModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D1736638-62F5-4517-8E47-5FD1861CE9F3
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.UnityWebRequestWWWModule.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UnityEngine.Networking;

namespace UnityEngine
{
  /// <summary>
  ///   <para>Simple access to web pages.</para>
  /// </summary>
  public class WWW : CustomYieldInstruction, IDisposable
  {
    private UnityWebRequest _uwr;
    private AssetBundle _assetBundle;
    private Dictionary<string, string> _responseHeaders;

    /// <summary>
    ///   <para>Creates a WWW request with the given URL.</para>
    /// </summary>
    /// <param name="url">The url to download. Must be '%' escaped.</param>
    /// <returns>
    ///   <para>A new WWW object. When it has been downloaded, the results can be fetched from the returned object.</para>
    /// </returns>
    public WWW(string url)
    {
      this._uwr = UnityWebRequest.Get(url);
      this._uwr.SendWebRequest();
    }

    /// <summary>
    ///   <para>Creates a WWW request with the given URL.</para>
    /// </summary>
    /// <param name="url">The url to download. Must be '%' escaped.</param>
    /// <param name="form">A WWWForm instance containing the form data to post.</param>
    /// <returns>
    ///   <para>A new WWW object. When it has been downloaded, the results can be fetched from the returned object.</para>
    /// </returns>
    public WWW(string url, WWWForm form)
    {
      this._uwr = UnityWebRequest.Post(url, form);
      this._uwr.chunkedTransfer = false;
      this._uwr.SendWebRequest();
    }

    /// <summary>
    ///   <para>Creates a WWW request with the given URL.</para>
    /// </summary>
    /// <param name="url">The url to download. Must be '%' escaped.</param>
    /// <param name="postData">A byte array of data to be posted to the url.</param>
    /// <returns>
    ///   <para>A new WWW object. When it has been downloaded, the results can be fetched from the returned object.</para>
    /// </returns>
    public WWW(string url, byte[] postData)
    {
      this._uwr = new UnityWebRequest(url, "POST");
      this._uwr.chunkedTransfer = false;
      UploadHandler uploadHandler = (UploadHandler) new UploadHandlerRaw(postData);
      uploadHandler.contentType = "application/x-www-form-urlencoded";
      this._uwr.uploadHandler = uploadHandler;
      this._uwr.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
      this._uwr.SendWebRequest();
    }

    /// <summary>
    ///   <para>Creates a WWW request with the given URL.</para>
    /// </summary>
    /// <param name="url">The url to download. Must be '%' escaped.</param>
    /// <param name="postData">A byte array of data to be posted to the url.</param>
    /// <param name="headers">A hash table of custom headers to send with the request.</param>
    /// <returns>
    ///   <para>A new WWW object. When it has been downloaded, the results can be fetched from the returned object.</para>
    /// </returns>
    [Obsolete("This overload is deprecated. Use UnityEngine.WWW.WWW(string, byte[], System.Collections.Generic.Dictionary<string, string>) instead.")]
    public WWW(string url, byte[] postData, Hashtable headers)
    {
      string method = postData != null ? "POST" : "GET";
      this._uwr = new UnityWebRequest(url, method);
      this._uwr.chunkedTransfer = false;
      UploadHandler uploadHandler = (UploadHandler) new UploadHandlerRaw(postData);
      uploadHandler.contentType = "application/x-www-form-urlencoded";
      this._uwr.uploadHandler = uploadHandler;
      this._uwr.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
      IEnumerator enumerator = headers.Keys.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
        {
          object current = enumerator.Current;
          this._uwr.SetRequestHeader((string) current, (string) headers[current]);
        }
      }
      finally
      {
        IDisposable disposable;
        if ((disposable = enumerator as IDisposable) != null)
          disposable.Dispose();
      }
      this._uwr.SendWebRequest();
    }

    public WWW(string url, byte[] postData, Dictionary<string, string> headers)
    {
      string method = postData != null ? "POST" : "GET";
      this._uwr = new UnityWebRequest(url, method);
      this._uwr.chunkedTransfer = false;
      UploadHandler uploadHandler = (UploadHandler) new UploadHandlerRaw(postData);
      uploadHandler.contentType = "application/x-www-form-urlencoded";
      this._uwr.uploadHandler = uploadHandler;
      this._uwr.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
      foreach (KeyValuePair<string, string> header in headers)
        this._uwr.SetRequestHeader(header.Key, header.Value);
      this._uwr.SendWebRequest();
    }

    internal WWW(string url, string name, Hash128 hash, uint crc)
    {
      this._uwr = UnityWebRequest.GetAssetBundle(url, new CachedAssetBundle(name, hash), crc);
      this._uwr.SendWebRequest();
    }

    /// <summary>
    ///   <para>Escapes characters in a string to ensure they are URL-friendly.</para>
    /// </summary>
    /// <param name="s">A string with characters to be escaped.</param>
    /// <param name="e">The text encoding to use.</param>
    public static string EscapeURL(string s)
    {
      return WWW.EscapeURL(s, Encoding.UTF8);
    }

    /// <summary>
    ///   <para>Escapes characters in a string to ensure they are URL-friendly.</para>
    /// </summary>
    /// <param name="s">A string with characters to be escaped.</param>
    /// <param name="e">The text encoding to use.</param>
    public static string EscapeURL(string s, Encoding e)
    {
      return UnityWebRequest.EscapeURL(s, e);
    }

    /// <summary>
    ///   <para>Converts URL-friendly escape sequences back to normal text.</para>
    /// </summary>
    /// <param name="s">A string containing escaped characters.</param>
    /// <param name="e">The text encoding to use.</param>
    public static string UnEscapeURL(string s)
    {
      return WWW.UnEscapeURL(s, Encoding.UTF8);
    }

    /// <summary>
    ///   <para>Converts URL-friendly escape sequences back to normal text.</para>
    /// </summary>
    /// <param name="s">A string containing escaped characters.</param>
    /// <param name="e">The text encoding to use.</param>
    public static string UnEscapeURL(string s, Encoding e)
    {
      return UnityWebRequest.UnEscapeURL(s, e);
    }

    /// <summary>
    ///   <para>Loads an AssetBundle with the specified version number from the cache. If the AssetBundle is not currently cached, it will automatically be downloaded and stored in the cache for future retrieval from local storage.</para>
    /// </summary>
    /// <param name="url">The URL to download the AssetBundle from, if it is not present in the cache. Must be '%' escaped.</param>
    /// <param name="version">Version of the AssetBundle. The file will only be loaded from the disk cache if it has previously been downloaded with the same version parameter. By incrementing the version number requested by your application, you can force Caching to download a new copy of the AssetBundle from url.</param>
    /// <param name="hash">Hash128 which is used as the version of the AssetBundle.</param>
    /// <param name="cachedBundle">A structure used to download a given version of AssetBundle to a customized cache path.
    /// 
    /// Analogous to the cachedAssetBundle parameter for UnityWebRequest.GetAssetBundle.&lt;/param&gt;</param>
    /// <param name="crc">An optional CRC-32 Checksum of the uncompressed contents. If this is non-zero, then the content will be compared against the checksum before loading it, and give an error if it does not match. You can use this to avoid data corruption from bad downloads or users tampering with the cached files on disk. If the CRC does not match, Unity will try to redownload the data, and if the CRC on the server does not match it will fail with an error. Look at the error string returned to see the correct CRC value to use for an AssetBundle.</param>
    /// <returns>
    ///   <para>A WWW instance, which can be used to access the data once the load/download operation is completed.</para>
    /// </returns>
    public static WWW LoadFromCacheOrDownload(string url, int version)
    {
      return WWW.LoadFromCacheOrDownload(url, version, 0U);
    }

    /// <summary>
    ///   <para>Loads an AssetBundle with the specified version number from the cache. If the AssetBundle is not currently cached, it will automatically be downloaded and stored in the cache for future retrieval from local storage.</para>
    /// </summary>
    /// <param name="url">The URL to download the AssetBundle from, if it is not present in the cache. Must be '%' escaped.</param>
    /// <param name="version">Version of the AssetBundle. The file will only be loaded from the disk cache if it has previously been downloaded with the same version parameter. By incrementing the version number requested by your application, you can force Caching to download a new copy of the AssetBundle from url.</param>
    /// <param name="hash">Hash128 which is used as the version of the AssetBundle.</param>
    /// <param name="cachedBundle">A structure used to download a given version of AssetBundle to a customized cache path.
    /// 
    /// Analogous to the cachedAssetBundle parameter for UnityWebRequest.GetAssetBundle.&lt;/param&gt;</param>
    /// <param name="crc">An optional CRC-32 Checksum of the uncompressed contents. If this is non-zero, then the content will be compared against the checksum before loading it, and give an error if it does not match. You can use this to avoid data corruption from bad downloads or users tampering with the cached files on disk. If the CRC does not match, Unity will try to redownload the data, and if the CRC on the server does not match it will fail with an error. Look at the error string returned to see the correct CRC value to use for an AssetBundle.</param>
    /// <returns>
    ///   <para>A WWW instance, which can be used to access the data once the load/download operation is completed.</para>
    /// </returns>
    public static WWW LoadFromCacheOrDownload(string url, int version, uint crc)
    {
      Hash128 hash = new Hash128(0U, 0U, 0U, (uint) version);
      return WWW.LoadFromCacheOrDownload(url, hash, crc);
    }

    public static WWW LoadFromCacheOrDownload(string url, Hash128 hash)
    {
      return WWW.LoadFromCacheOrDownload(url, hash, 0U);
    }

    /// <summary>
    ///   <para>Loads an AssetBundle with the specified version number from the cache. If the AssetBundle is not currently cached, it will automatically be downloaded and stored in the cache for future retrieval from local storage.</para>
    /// </summary>
    /// <param name="url">The URL to download the AssetBundle from, if it is not present in the cache. Must be '%' escaped.</param>
    /// <param name="version">Version of the AssetBundle. The file will only be loaded from the disk cache if it has previously been downloaded with the same version parameter. By incrementing the version number requested by your application, you can force Caching to download a new copy of the AssetBundle from url.</param>
    /// <param name="hash">Hash128 which is used as the version of the AssetBundle.</param>
    /// <param name="cachedBundle">A structure used to download a given version of AssetBundle to a customized cache path.
    /// 
    /// Analogous to the cachedAssetBundle parameter for UnityWebRequest.GetAssetBundle.&lt;/param&gt;</param>
    /// <param name="crc">An optional CRC-32 Checksum of the uncompressed contents. If this is non-zero, then the content will be compared against the checksum before loading it, and give an error if it does not match. You can use this to avoid data corruption from bad downloads or users tampering with the cached files on disk. If the CRC does not match, Unity will try to redownload the data, and if the CRC on the server does not match it will fail with an error. Look at the error string returned to see the correct CRC value to use for an AssetBundle.</param>
    /// <returns>
    ///   <para>A WWW instance, which can be used to access the data once the load/download operation is completed.</para>
    /// </returns>
    public static WWW LoadFromCacheOrDownload(string url, Hash128 hash, uint crc)
    {
      return new WWW(url, "", hash, crc);
    }

    /// <summary>
    ///   <para>Loads an AssetBundle with the specified version number from the cache. If the AssetBundle is not currently cached, it will automatically be downloaded and stored in the cache for future retrieval from local storage.</para>
    /// </summary>
    /// <param name="url">The URL to download the AssetBundle from, if it is not present in the cache. Must be '%' escaped.</param>
    /// <param name="version">Version of the AssetBundle. The file will only be loaded from the disk cache if it has previously been downloaded with the same version parameter. By incrementing the version number requested by your application, you can force Caching to download a new copy of the AssetBundle from url.</param>
    /// <param name="hash">Hash128 which is used as the version of the AssetBundle.</param>
    /// <param name="cachedBundle">A structure used to download a given version of AssetBundle to a customized cache path.
    /// 
    /// Analogous to the cachedAssetBundle parameter for UnityWebRequest.GetAssetBundle.&lt;/param&gt;</param>
    /// <param name="crc">An optional CRC-32 Checksum of the uncompressed contents. If this is non-zero, then the content will be compared against the checksum before loading it, and give an error if it does not match. You can use this to avoid data corruption from bad downloads or users tampering with the cached files on disk. If the CRC does not match, Unity will try to redownload the data, and if the CRC on the server does not match it will fail with an error. Look at the error string returned to see the correct CRC value to use for an AssetBundle.</param>
    /// <returns>
    ///   <para>A WWW instance, which can be used to access the data once the load/download operation is completed.</para>
    /// </returns>
    public static WWW LoadFromCacheOrDownload(string url, CachedAssetBundle cachedBundle, uint crc = 0)
    {
      return new WWW(url, cachedBundle.name, cachedBundle.hash, crc);
    }

    /// <summary>
    ///   <para>Streams an AssetBundle that can contain any kind of asset from the project folder.</para>
    /// </summary>
    public AssetBundle assetBundle
    {
      get
      {
        if ((Object) this._assetBundle == (Object) null)
        {
          if (!this.WaitUntilDoneIfPossible() || this._uwr.isNetworkError)
            return (AssetBundle) null;
          DownloadHandlerAssetBundle downloadHandler = this._uwr.downloadHandler as DownloadHandlerAssetBundle;
          if (downloadHandler != null)
          {
            this._assetBundle = downloadHandler.assetBundle;
          }
          else
          {
            byte[] bytes = this.bytes;
            if (bytes == null)
              return (AssetBundle) null;
            this._assetBundle = AssetBundle.LoadFromMemory(bytes);
          }
        }
        return this._assetBundle;
      }
    }

    /// <summary>
    ///   <para>Returns a AudioClip generated from the downloaded data (Read Only).</para>
    /// </summary>
    [Obsolete("Obsolete msg (UnityUpgradable) -> * UnityEngine.WWW.GetAudioClip()", true)]
    public Object audioClip
    {
      get
      {
        return (Object) null;
      }
    }

    /// <summary>
    ///   <para>Returns the contents of the fetched web page as a byte array (Read Only).</para>
    /// </summary>
    public byte[] bytes
    {
      get
      {
        if (!this.WaitUntilDoneIfPossible())
          return new byte[0];
        if (this._uwr.isNetworkError)
          return new byte[0];
        DownloadHandler downloadHandler = this._uwr.downloadHandler;
        if (downloadHandler == null)
          return new byte[0];
        return downloadHandler.data;
      }
    }

    /// <summary>
    ///   <para>Returns a MovieTexture generated from the downloaded data (Read Only).</para>
    /// </summary>
    [Obsolete("Obsolete msg (UnityUpgradable) -> * UnityEngine.WWW.GetMovieTexture()", true)]
    public Object movie
    {
      get
      {
        return (Object) null;
      }
    }

    [Obsolete("WWW.size is obsolete. Please use WWW.bytesDownloaded instead")]
    public int size
    {
      get
      {
        return this.bytesDownloaded;
      }
    }

    /// <summary>
    ///   <para>The number of bytes downloaded by this WWW query (read only).</para>
    /// </summary>
    public int bytesDownloaded
    {
      get
      {
        return (int) this._uwr.downloadedBytes;
      }
    }

    /// <summary>
    ///   <para>Returns an error message if there was an error during the download (Read Only).</para>
    /// </summary>
    public string error
    {
      get
      {
        if (!this._uwr.isDone)
          return (string) null;
        if (this._uwr.isNetworkError)
          return this._uwr.error;
        if (this._uwr.responseCode >= 400L)
          return string.Format("{0} {1}", (object) this._uwr.responseCode, (object) this.GetStatusCodeName(this._uwr.responseCode));
        return (string) null;
      }
    }

    /// <summary>
    ///   <para>Is the download already finished? (Read Only)</para>
    /// </summary>
    public bool isDone
    {
      get
      {
        return this._uwr.isDone;
      }
    }

    /// <summary>
    ///   <para>Load an Ogg Vorbis file into the audio clip.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Obsolete msg (UnityUpgradable) -> * UnityEngine.WWW.GetAudioClip()", true)]
    public Object oggVorbis
    {
      get
      {
        return (Object) null;
      }
    }

    /// <summary>
    ///   <para>How far has the download progressed (Read Only).</para>
    /// </summary>
    public float progress
    {
      get
      {
        float num = this._uwr.downloadProgress;
        if ((double) num < 0.0)
          num = 0.0f;
        return num;
      }
    }

    /// <summary>
    ///   <para>Dictionary of headers returned by the request.</para>
    /// </summary>
    public Dictionary<string, string> responseHeaders
    {
      get
      {
        if (!this.isDone)
          return new Dictionary<string, string>();
        if (this._responseHeaders == null)
        {
          this._responseHeaders = this._uwr.GetResponseHeaders();
          if (this._responseHeaders != null)
            this._responseHeaders["STATUS"] = string.Format("HTTP/1.1 {0} {1}", (object) this._uwr.responseCode, (object) this.GetStatusCodeName(this._uwr.responseCode));
          else
            this._responseHeaders = new Dictionary<string, string>();
        }
        return this._responseHeaders;
      }
    }

    [Obsolete("Please use WWW.text instead. (UnityUpgradable) -> text", true)]
    public string data
    {
      get
      {
        return this.text;
      }
    }

    /// <summary>
    ///   <para>Returns the contents of the fetched web page as a string (Read Only).</para>
    /// </summary>
    public string text
    {
      get
      {
        if (!this.WaitUntilDoneIfPossible() || this._uwr.isNetworkError)
          return "";
        DownloadHandler downloadHandler = this._uwr.downloadHandler;
        if (downloadHandler == null)
          return "";
        return downloadHandler.text;
      }
    }

    private Texture2D CreateTextureFromDownloadedData(bool markNonReadable)
    {
      if (!this.WaitUntilDoneIfPossible())
        return new Texture2D(2, 2);
      if (this._uwr.isNetworkError)
        return (Texture2D) null;
      DownloadHandler downloadHandler = this._uwr.downloadHandler;
      if (downloadHandler == null)
        return (Texture2D) null;
      Texture2D tex = new Texture2D(2, 2);
      tex.LoadImage(downloadHandler.data, markNonReadable);
      return tex;
    }

    /// <summary>
    ///   <para>Returns a Texture2D generated from the downloaded data (Read Only).</para>
    /// </summary>
    public Texture2D texture
    {
      get
      {
        return this.CreateTextureFromDownloadedData(false);
      }
    }

    /// <summary>
    ///   <para>Returns a non-readable Texture2D generated from the downloaded data (Read Only).</para>
    /// </summary>
    public Texture2D textureNonReadable
    {
      get
      {
        return this.CreateTextureFromDownloadedData(true);
      }
    }

    /// <summary>
    ///   <para>Replaces the contents of an existing Texture2D with an image from the downloaded data.</para>
    /// </summary>
    /// <param name="tex">An existing texture object to be overwritten with the image data.</param>
    /// <param name="texture"></param>
    public void LoadImageIntoTexture(Texture2D texture)
    {
      if (!this.WaitUntilDoneIfPossible())
        return;
      if (this._uwr.isNetworkError)
      {
        Debug.LogError((object) "Cannot load image: download failed");
      }
      else
      {
        DownloadHandler downloadHandler = this._uwr.downloadHandler;
        if (downloadHandler == null)
          Debug.LogError((object) "Cannot load image: internal error");
        else
          texture.LoadImage(downloadHandler.data, false);
      }
    }

    /// <summary>
    ///   <para>Obsolete, has no effect.</para>
    /// </summary>
    public ThreadPriority threadPriority { get; set; }

    /// <summary>
    ///   <para>How far has the upload progressed (Read Only).</para>
    /// </summary>
    public float uploadProgress
    {
      get
      {
        float num = this._uwr.uploadProgress;
        if ((double) num < 0.0)
          num = 0.0f;
        return num;
      }
    }

    /// <summary>
    ///   <para>The URL of this WWW request (Read Only).</para>
    /// </summary>
    public string url
    {
      get
      {
        return this._uwr.url;
      }
    }

    public override bool keepWaiting
    {
      get
      {
        return !this._uwr.isDone;
      }
    }

    /// <summary>
    ///   <para>Disposes of an existing WWW object.</para>
    /// </summary>
    public void Dispose()
    {
      this._uwr.Dispose();
    }

    internal Object GetAudioClipInternal(bool threeD, bool stream, bool compressed, AudioType audioType)
    {
      return (Object) WebRequestWWW.InternalCreateAudioClipUsingDH(this._uwr.downloadHandler, this._uwr.url, stream, compressed, audioType);
    }

    internal object GetMovieTextureInternal()
    {
      return (object) WebRequestWWW.InternalCreateMovieTextureUsingDH(this._uwr.downloadHandler);
    }

    public AudioClip GetAudioClip()
    {
      return this.GetAudioClip(true, false, AudioType.UNKNOWN);
    }

    /// <summary>
    ///   <para>Returns an AudioClip generated from the downloaded data (Read Only).</para>
    /// </summary>
    /// <param name="threeD">Use this to specify whether the clip should be a 2D or 3D clip
    /// the .audioClip property defaults to 3D.</param>
    /// <param name="stream">Sets whether the clip should be completely downloaded before it's ready to play (false) or the stream can be played even if only part of the clip is downloaded (true).
    /// The latter will disable seeking on the clip (with .time and/or .timeSamples).</param>
    /// <param name="audioType">The AudioType of the content your downloading. If this is not set Unity will try to determine the type from URL.</param>
    /// <returns>
    ///   <para>The returned AudioClip.</para>
    /// </returns>
    public AudioClip GetAudioClip(bool threeD)
    {
      return this.GetAudioClip(threeD, false, AudioType.UNKNOWN);
    }

    /// <summary>
    ///   <para>Returns an AudioClip generated from the downloaded data (Read Only).</para>
    /// </summary>
    /// <param name="threeD">Use this to specify whether the clip should be a 2D or 3D clip
    /// the .audioClip property defaults to 3D.</param>
    /// <param name="stream">Sets whether the clip should be completely downloaded before it's ready to play (false) or the stream can be played even if only part of the clip is downloaded (true).
    /// The latter will disable seeking on the clip (with .time and/or .timeSamples).</param>
    /// <param name="audioType">The AudioType of the content your downloading. If this is not set Unity will try to determine the type from URL.</param>
    /// <returns>
    ///   <para>The returned AudioClip.</para>
    /// </returns>
    public AudioClip GetAudioClip(bool threeD, bool stream)
    {
      return this.GetAudioClip(threeD, stream, AudioType.UNKNOWN);
    }

    /// <summary>
    ///   <para>Returns an AudioClip generated from the downloaded data (Read Only).</para>
    /// </summary>
    /// <param name="threeD">Use this to specify whether the clip should be a 2D or 3D clip
    /// the .audioClip property defaults to 3D.</param>
    /// <param name="stream">Sets whether the clip should be completely downloaded before it's ready to play (false) or the stream can be played even if only part of the clip is downloaded (true).
    /// The latter will disable seeking on the clip (with .time and/or .timeSamples).</param>
    /// <param name="audioType">The AudioType of the content your downloading. If this is not set Unity will try to determine the type from URL.</param>
    /// <returns>
    ///   <para>The returned AudioClip.</para>
    /// </returns>
    public AudioClip GetAudioClip(bool threeD, bool stream, AudioType audioType)
    {
      return (AudioClip) this.GetAudioClipInternal(threeD, stream, false, audioType);
    }

    /// <summary>
    ///   <para>Returns an AudioClip generated from the downloaded data that is compressed in memory (Read Only).</para>
    /// </summary>
    /// <param name="threeD">Use this to specify whether the clip should be a 2D or 3D clip.</param>
    /// <param name="audioType">The AudioType of the content your downloading. If this is not set Unity will try to determine the type from URL.</param>
    /// <returns>
    ///   <para>The returned AudioClip.</para>
    /// </returns>
    public AudioClip GetAudioClipCompressed()
    {
      return this.GetAudioClipCompressed(false, AudioType.UNKNOWN);
    }

    /// <summary>
    ///   <para>Returns an AudioClip generated from the downloaded data that is compressed in memory (Read Only).</para>
    /// </summary>
    /// <param name="threeD">Use this to specify whether the clip should be a 2D or 3D clip.</param>
    /// <param name="audioType">The AudioType of the content your downloading. If this is not set Unity will try to determine the type from URL.</param>
    /// <returns>
    ///   <para>The returned AudioClip.</para>
    /// </returns>
    public AudioClip GetAudioClipCompressed(bool threeD)
    {
      return this.GetAudioClipCompressed(threeD, AudioType.UNKNOWN);
    }

    /// <summary>
    ///   <para>Returns an AudioClip generated from the downloaded data that is compressed in memory (Read Only).</para>
    /// </summary>
    /// <param name="threeD">Use this to specify whether the clip should be a 2D or 3D clip.</param>
    /// <param name="audioType">The AudioType of the content your downloading. If this is not set Unity will try to determine the type from URL.</param>
    /// <returns>
    ///   <para>The returned AudioClip.</para>
    /// </returns>
    public AudioClip GetAudioClipCompressed(bool threeD, AudioType audioType)
    {
      return (AudioClip) this.GetAudioClipInternal(threeD, false, true, audioType);
    }

    /// <summary>
    ///   <para>Returns a MovieTexture generated from the downloaded data (Read Only).</para>
    /// </summary>
    public MovieTexture GetMovieTexture()
    {
      return (MovieTexture) this.GetMovieTextureInternal();
    }

    private bool WaitUntilDoneIfPossible()
    {
      if (this._uwr.isDone)
        return true;
      if (this.url.StartsWith("file://", StringComparison.OrdinalIgnoreCase))
      {
        do
          ;
        while (!this._uwr.isDone);
        return true;
      }
      Debug.LogError((object) "You are trying to load data from a www stream which has not completed the download yet.\nYou need to yield the download or wait until isDone returns true.");
      return false;
    }

    private string GetStatusCodeName(long statusCode)
    {
      if (statusCode >= 400L && statusCode <= 417L)
      {
        switch (statusCode)
        {
          case 400:
            return "Bad Request";
          case 401:
            return "Unauthorized";
          case 402:
            return "Payment Required";
          case 403:
            return "Forbidden";
          case 404:
            return "Not Found";
          case 405:
            return "Method Not Allowed";
          case 406:
            return "Not Acceptable";
          case 407:
            return "Proxy Authentication Required";
          case 408:
            return "Request Timeout";
          case 409:
            return "Conflict";
          case 410:
            return "Gone";
          case 411:
            return "Length Required";
          case 412:
            return "Precondition Failed";
          case 413:
            return "Request Entity Too Large";
          case 414:
            return "Request-URI Too Long";
          case 415:
            return "Unsupported Media Type";
          case 416:
            return "Requested Range Not Satisfiable";
          case 417:
            return "Expectation Failed";
        }
      }
      if (statusCode >= 200L && statusCode <= 206L)
      {
        switch (statusCode)
        {
          case 200:
            return "OK";
          case 201:
            return "Created";
          case 202:
            return "Accepted";
          case 203:
            return "Non-Authoritative Information";
          case 204:
            return "No Content";
          case 205:
            return "Reset Content";
          case 206:
            return "Partial Content";
        }
      }
      if (statusCode >= 300L && statusCode <= 307L)
      {
        switch (statusCode)
        {
          case 300:
            return "Multiple Choices";
          case 301:
            return "Moved Permanently";
          case 302:
            return "Found";
          case 303:
            return "See Other";
          case 304:
            return "Not Modified";
          case 305:
            return "Use Proxy";
          case 307:
            return "Temporary Redirect";
        }
      }
      if (statusCode >= 500L && statusCode <= 505L)
      {
        switch (statusCode)
        {
          case 500:
            return "Internal Server Error";
          case 501:
            return "Not Implemented";
          case 502:
            return "Bad Gateway";
          case 503:
            return "Service Unavailable";
          case 504:
            return "Gateway Timeout";
          case 505:
            return "HTTP Version Not Supported";
        }
      }
      return "";
    }
  }
}
