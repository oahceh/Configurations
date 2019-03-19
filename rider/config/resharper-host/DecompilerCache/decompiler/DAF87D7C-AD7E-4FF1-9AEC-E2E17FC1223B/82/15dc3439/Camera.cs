// Decompiled with JetBrains decompiler
// Type: UnityEngine.Camera
// Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAF87D7C-AD7E-4FF1-9AEC-E2E17FC1223B
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>A Camera is a device through which the player views the world.</para>
  /// </summary>
  [UsedByNativeCode]
  [RequireComponent(typeof (Transform))]
  [NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
  [NativeHeader("Runtime/Camera/Camera.h")]
  public sealed class Camera : Behaviour
  {
    /// <summary>
    ///   <para>Event that is fired before any camera starts culling.</para>
    /// </summary>
    public static Camera.CameraCallback onPreCull;
    /// <summary>
    ///   <para>Event that is fired before any camera starts rendering.</para>
    /// </summary>
    public static Camera.CameraCallback onPreRender;
    /// <summary>
    ///   <para>Event that is fired after any camera finishes rendering.</para>
    /// </summary>
    public static Camera.CameraCallback onPostRender;

    [Obsolete("use Camera.fieldOfView instead.")]
    public float fov
    {
      get
      {
        return this.fieldOfView;
      }
      set
      {
        this.fieldOfView = value;
      }
    }

    [Obsolete("use Camera.nearClipPlane instead.")]
    public float near
    {
      get
      {
        return this.nearClipPlane;
      }
      set
      {
        this.nearClipPlane = value;
      }
    }

    [Obsolete("use Camera.farClipPlane instead.")]
    public float far
    {
      get
      {
        return this.farClipPlane;
      }
      set
      {
        this.farClipPlane = value;
      }
    }

    /// <summary>
    ///   <para>The field of view of the camera in degrees.</para>
    /// </summary>
    public extern float fieldOfView { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The near clipping plane distance.</para>
    /// </summary>
    public extern float nearClipPlane { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The far clipping plane distance.</para>
    /// </summary>
    public extern float farClipPlane { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The rendering path that should be used, if possible.</para>
    /// </summary>
    public extern RenderingPath renderingPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The rendering path that is currently being used (Read Only).</para>
    /// </summary>
    public extern RenderingPath actualRenderingPath { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>High dynamic range rendering.</para>
    /// </summary>
    public extern bool allowHDR { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>High dynamic range rendering.</para>
    /// </summary>
    [Obsolete("use Camera.allowHDR instead.")]
    public extern bool hdr { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Should camera rendering be forced into a RenderTexture.</para>
    /// </summary>
    public extern bool forceIntoRenderTexture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>MSAA rendering.</para>
    /// </summary>
    public extern bool allowMSAA { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Dynamic Resolution Scaling.</para>
    /// </summary>
    public extern bool allowDynamicResolution { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern string[] GetCameraBufferWarnings();

    /// <summary>
    ///   <para>Camera's half-size when in orthographic mode.</para>
    /// </summary>
    public extern float orthographicSize { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Is the camera orthographic (true) or perspective (false)?</para>
    /// </summary>
    public extern bool orthographic { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Opaque object sorting mode.</para>
    /// </summary>
    public extern OpaqueSortMode opaqueSortMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Transparent object sorting mode.</para>
    /// </summary>
    public extern TransparencySortMode transparencySortMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>An axis that describes the direction along which the distances of objects are measured for the purpose of sorting.</para>
    /// </summary>
    public Vector3 transparencySortAxis
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_transparencySortAxis(out vector3);
        return vector3;
      }
      set
      {
        this.INTERNAL_set_transparencySortAxis(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_transparencySortAxis(out Vector3 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_transparencySortAxis(ref Vector3 value);

    /// <summary>
    ///   <para>Camera's depth in the camera rendering order.</para>
    /// </summary>
    public extern float depth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The aspect ratio (width divided by height).</para>
    /// </summary>
    public extern float aspect { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>This is used to render parts of the scene selectively.</para>
    /// </summary>
    public extern int cullingMask { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    internal static extern int PreviewCullingLayer { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>If not null, the camera will only render the contents of the specified scene.</para>
    /// </summary>
    public Scene scene
    {
      get
      {
        Scene scene;
        this.INTERNAL_get_scene(out scene);
        return scene;
      }
      set
      {
        this.INTERNAL_set_scene(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_scene(out Scene value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_scene(ref Scene value);

    /// <summary>
    ///   <para>Mask to select which layers can trigger events on the camera.</para>
    /// </summary>
    public extern int eventMask { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The color with which the screen will be cleared.</para>
    /// </summary>
    public Color backgroundColor
    {
      get
      {
        Color color;
        this.INTERNAL_get_backgroundColor(out color);
        return color;
      }
      set
      {
        this.INTERNAL_set_backgroundColor(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_backgroundColor(out Color value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_backgroundColor(ref Color value);

    /// <summary>
    ///   <para>Where on the screen is the camera rendered in normalized coordinates.</para>
    /// </summary>
    public Rect rect
    {
      get
      {
        Rect rect;
        this.INTERNAL_get_rect(out rect);
        return rect;
      }
      set
      {
        this.INTERNAL_set_rect(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_rect(out Rect value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_rect(ref Rect value);

    /// <summary>
    ///   <para>Where on the screen is the camera rendered in pixel coordinates.</para>
    /// </summary>
    public Rect pixelRect
    {
      get
      {
        Rect rect;
        this.INTERNAL_get_pixelRect(out rect);
        return rect;
      }
      set
      {
        this.INTERNAL_set_pixelRect(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_pixelRect(out Rect value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_pixelRect(ref Rect value);

    /// <summary>
    ///   <para>Destination render texture.</para>
    /// </summary>
    public extern RenderTexture targetTexture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Gets the temporary RenderTexture target for this Camera.</para>
    /// </summary>
    public extern RenderTexture activeTexture { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetTargetBuffersImpl(out RenderBuffer color, out RenderBuffer depth);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void SetTargetBuffersMRTImpl(RenderBuffer[] color, out RenderBuffer depth);

    /// <summary>
    ///   <para>Sets the Camera to render to the chosen buffers of one or more RenderTextures.</para>
    /// </summary>
    /// <param name="colorBuffer">The RenderBuffer(s) to which color information will be rendered.</param>
    /// <param name="depthBuffer">The RenderBuffer to which depth information will be rendered.</param>
    public void SetTargetBuffers(RenderBuffer colorBuffer, RenderBuffer depthBuffer)
    {
      this.SetTargetBuffersImpl(out colorBuffer, out depthBuffer);
    }

    /// <summary>
    ///   <para>Sets the Camera to render to the chosen buffers of one or more RenderTextures.</para>
    /// </summary>
    /// <param name="colorBuffer">The RenderBuffer(s) to which color information will be rendered.</param>
    /// <param name="depthBuffer">The RenderBuffer to which depth information will be rendered.</param>
    public void SetTargetBuffers(RenderBuffer[] colorBuffer, RenderBuffer depthBuffer)
    {
      this.SetTargetBuffersMRTImpl(colorBuffer, out depthBuffer);
    }

    /// <summary>
    ///   <para>How wide is the camera in pixels (not accounting for dynamic resolution scaling) (Read Only).</para>
    /// </summary>
    public extern int pixelWidth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>How tall is the camera in pixels (not accounting for dynamic resolution scaling) (Read Only).</para>
    /// </summary>
    public extern int pixelHeight { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>How wide is the camera in pixels (accounting for dynamic resolution scaling) (Read Only).</para>
    /// </summary>
    public extern int scaledPixelWidth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>How tall is the camera in pixels (accounting for dynamic resolution scaling) (Read Only).</para>
    /// </summary>
    public extern int scaledPixelHeight { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Matrix that transforms from camera space to world space (Read Only).</para>
    /// </summary>
    public Matrix4x4 cameraToWorldMatrix
    {
      get
      {
        Matrix4x4 matrix4x4;
        this.INTERNAL_get_cameraToWorldMatrix(out matrix4x4);
        return matrix4x4;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_cameraToWorldMatrix(out Matrix4x4 value);

    /// <summary>
    ///   <para>Matrix that transforms from world to camera space.</para>
    /// </summary>
    public Matrix4x4 worldToCameraMatrix
    {
      get
      {
        Matrix4x4 matrix4x4;
        this.INTERNAL_get_worldToCameraMatrix(out matrix4x4);
        return matrix4x4;
      }
      set
      {
        this.INTERNAL_set_worldToCameraMatrix(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_worldToCameraMatrix(out Matrix4x4 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_worldToCameraMatrix(ref Matrix4x4 value);

    /// <summary>
    ///   <para>Make the rendering position reflect the camera's position in the scene.</para>
    /// </summary>
    public void ResetWorldToCameraMatrix()
    {
      Camera.INTERNAL_CALL_ResetWorldToCameraMatrix(this);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ResetWorldToCameraMatrix(Camera self);

    /// <summary>
    ///   <para>Set a custom projection matrix.</para>
    /// </summary>
    public Matrix4x4 projectionMatrix
    {
      get
      {
        Matrix4x4 matrix4x4;
        this.INTERNAL_get_projectionMatrix(out matrix4x4);
        return matrix4x4;
      }
      set
      {
        this.INTERNAL_set_projectionMatrix(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_projectionMatrix(out Matrix4x4 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_projectionMatrix(ref Matrix4x4 value);

    /// <summary>
    ///   <para>Get or set the raw projection matrix with no camera offset (no jittering).</para>
    /// </summary>
    public Matrix4x4 nonJitteredProjectionMatrix
    {
      get
      {
        Matrix4x4 matrix4x4;
        this.INTERNAL_get_nonJitteredProjectionMatrix(out matrix4x4);
        return matrix4x4;
      }
      set
      {
        this.INTERNAL_set_nonJitteredProjectionMatrix(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_nonJitteredProjectionMatrix(out Matrix4x4 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_nonJitteredProjectionMatrix(ref Matrix4x4 value);

    /// <summary>
    ///   <para>Should the jittered matrix be used for transparency rendering?</para>
    /// </summary>
    public extern bool useJitteredProjectionMatrixForTransparentRendering { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Get the view projection matrix used on the last frame.</para>
    /// </summary>
    public Matrix4x4 previousViewProjectionMatrix
    {
      get
      {
        Matrix4x4 matrix4x4;
        this.INTERNAL_get_previousViewProjectionMatrix(out matrix4x4);
        return matrix4x4;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_previousViewProjectionMatrix(out Matrix4x4 value);

    /// <summary>
    ///   <para>Make the projection reflect normal camera's parameters.</para>
    /// </summary>
    public void ResetProjectionMatrix()
    {
      Camera.INTERNAL_CALL_ResetProjectionMatrix(this);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ResetProjectionMatrix(Camera self);

    /// <summary>
    ///   <para>Revert the aspect ratio to the screen's aspect ratio.</para>
    /// </summary>
    public void ResetAspect()
    {
      Camera.INTERNAL_CALL_ResetAspect(this);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ResetAspect(Camera self);

    /// <summary>
    ///   <para>Reset to the default field of view.</para>
    /// </summary>
    [Obsolete("Camera.ResetFieldOfView has been deprecated in Unity 5.6 and will be removed in the future. Please replace it by explicitly setting the camera's FOV to 60 degrees.")]
    public void ResetFieldOfView()
    {
      Camera.INTERNAL_CALL_ResetFieldOfView(this);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ResetFieldOfView(Camera self);

    /// <summary>
    ///   <para>Get the world-space speed of the camera (Read Only).</para>
    /// </summary>
    public Vector3 velocity
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_velocity(out vector3);
        return vector3;
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_velocity(out Vector3 value);

    /// <summary>
    ///   <para>How the camera clears the background.</para>
    /// </summary>
    public extern CameraClearFlags clearFlags { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Stereoscopic rendering.</para>
    /// </summary>
    public extern bool stereoEnabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The distance between the virtual eyes. Use this to query or set the current eye separation. Note that most VR devices provide this value, in which case setting the value will have no effect.</para>
    /// </summary>
    public extern float stereoSeparation { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Distance to a point where virtual eyes converge.</para>
    /// </summary>
    public extern float stereoConvergence { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Identifies what kind of camera this is.</para>
    /// </summary>
    public extern CameraType cameraType { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Render only once and use resulting image for both eyes.</para>
    /// </summary>
    [Obsolete("This property is no longer supported. Please use single pass stereo rendering instead.", true)]
    public extern bool stereoMirrorMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("GetStereoViewMatrices is deprecated. Use GetStereoViewMatrix(StereoscopicEye eye) instead.")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Matrix4x4[] GetStereoViewMatrices();

    public Matrix4x4 GetStereoViewMatrix(Camera.StereoscopicEye eye)
    {
      Matrix4x4 matrix4x4;
      Camera.INTERNAL_CALL_GetStereoViewMatrix(this, eye, out matrix4x4);
      return matrix4x4;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_GetStereoViewMatrix(Camera self, Camera.StereoscopicEye eye, out Matrix4x4 value);

    /// <summary>
    ///   <para>Defines which eye of a VR display the Camera renders into.</para>
    /// </summary>
    public extern StereoTargetEyeMask stereoTargetEye { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Determines whether the stereo view matrices are suitable to allow for a single pass cull.</para>
    /// </summary>
    public extern bool areVRStereoViewMatricesWithinSingleCullTolerance { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Set custom view matrices for both eyes.</para>
    /// </summary>
    /// <param name="leftMatrix">View matrix for the stereo left eye.</param>
    /// <param name="rightMatrix">View matrix for the stereo right eye.</param>
    [Obsolete("SetStereoViewMatrices is deprecated. Use SetStereoViewMatrix(StereoscopicEye eye) instead.")]
    public void SetStereoViewMatrices(Matrix4x4 leftMatrix, Matrix4x4 rightMatrix)
    {
      Camera.INTERNAL_CALL_SetStereoViewMatrices(this, ref leftMatrix, ref rightMatrix);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetStereoViewMatrices(Camera self, ref Matrix4x4 leftMatrix, ref Matrix4x4 rightMatrix);

    public void SetStereoViewMatrix(Camera.StereoscopicEye eye, Matrix4x4 matrix)
    {
      Camera.INTERNAL_CALL_SetStereoViewMatrix(this, eye, ref matrix);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetStereoViewMatrix(Camera self, Camera.StereoscopicEye eye, ref Matrix4x4 matrix);

    /// <summary>
    ///   <para>Reset the camera to using the Unity computed view matrices for all stereoscopic eyes.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void ResetStereoViewMatrices();

    [Obsolete("GetStereoProjectionMatrices is deprecated. Use GetStereoProjectionMatrix(StereoscopicEye eye) instead.")]
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern Matrix4x4[] GetStereoProjectionMatrices();

    public Matrix4x4 GetStereoProjectionMatrix(Camera.StereoscopicEye eye)
    {
      Matrix4x4 matrix4x4;
      Camera.INTERNAL_CALL_GetStereoProjectionMatrix(this, eye, out matrix4x4);
      return matrix4x4;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_GetStereoProjectionMatrix(Camera self, Camera.StereoscopicEye eye, out Matrix4x4 value);

    public void SetStereoProjectionMatrix(Camera.StereoscopicEye eye, Matrix4x4 matrix)
    {
      Camera.INTERNAL_CALL_SetStereoProjectionMatrix(this, eye, ref matrix);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetStereoProjectionMatrix(Camera self, Camera.StereoscopicEye eye, ref Matrix4x4 matrix);

    /// <summary>
    ///   <para>Sets custom projection matrices for both the left and right stereoscopic eyes.</para>
    /// </summary>
    /// <param name="leftMatrix">Projection matrix for the stereoscopic left eye.</param>
    /// <param name="rightMatrix">Projection matrix for the stereoscopic right eye.</param>
    [Obsolete("SetStereoProjectionMatrices is deprecated. Use SetStereoProjectionMatrix(StereoscopicEye eye) instead.")]
    public void SetStereoProjectionMatrices(Matrix4x4 leftMatrix, Matrix4x4 rightMatrix)
    {
      Camera.INTERNAL_CALL_SetStereoProjectionMatrices(this, ref leftMatrix, ref rightMatrix);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_SetStereoProjectionMatrices(Camera self, ref Matrix4x4 leftMatrix, ref Matrix4x4 rightMatrix);

    /// <summary>
    ///         <para>Returns the eye that is currently rendering.
    /// If called when stereo is not enabled it will return Camera.MonoOrStereoscopicEye.Mono.
    /// 
    /// If called during a camera rendering callback such as OnRenderImage it will return the currently rendering eye.
    /// 
    /// If called outside of a rendering callback and stereo is enabled, it will return the default eye which is Camera.MonoOrStereoscopicEye.Left.</para>
    ///       </summary>
    public extern Camera.MonoOrStereoscopicEye stereoActiveEye { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public void CalculateFrustumCorners(Rect viewport, float z, Camera.MonoOrStereoscopicEye eye, Vector3[] outCorners)
    {
      if (outCorners == null)
        throw new ArgumentNullException(nameof (outCorners));
      if (outCorners.Length < 4)
        throw new ArgumentException("outCorners minimum size is 4", nameof (outCorners));
      this.CalculateFrustumCornersInternal(viewport, z, eye, outCorners);
    }

    private void CalculateFrustumCornersInternal(Rect viewport, float z, Camera.MonoOrStereoscopicEye eye, Vector3[] outCorners)
    {
      Camera.INTERNAL_CALL_CalculateFrustumCornersInternal(this, ref viewport, z, eye, outCorners);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_CalculateFrustumCornersInternal(Camera self, ref Rect viewport, float z, Camera.MonoOrStereoscopicEye eye, Vector3[] outCorners);

    /// <summary>
    ///   <para>Reset the camera to using the Unity computed projection matrices for all stereoscopic eyes.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void ResetStereoProjectionMatrices();

    /// <summary>
    ///   <para>Resets this Camera's transparency sort settings to the default. Default transparency settings are taken from GraphicsSettings instead of directly from this Camera.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void ResetTransparencySortSettings();

    /// <summary>
    ///   <para>Set the target display for this Camera.</para>
    /// </summary>
    public extern int targetDisplay { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Transforms position from world space into screen space.</para>
    /// </summary>
    /// <param name="position"></param>
    public Vector3 WorldToScreenPoint(Vector3 position)
    {
      Vector3 vector3;
      Camera.INTERNAL_CALL_WorldToScreenPoint(this, ref position, out vector3);
      return vector3;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_WorldToScreenPoint(Camera self, ref Vector3 position, out Vector3 value);

    /// <summary>
    ///   <para>Transforms position from world space into viewport space.</para>
    /// </summary>
    /// <param name="position"></param>
    public Vector3 WorldToViewportPoint(Vector3 position)
    {
      Vector3 vector3;
      Camera.INTERNAL_CALL_WorldToViewportPoint(this, ref position, out vector3);
      return vector3;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_WorldToViewportPoint(Camera self, ref Vector3 position, out Vector3 value);

    /// <summary>
    ///   <para>Transforms position from viewport space into world space.</para>
    /// </summary>
    /// <param name="position">The 3d vector in Viewport space.</param>
    /// <returns>
    ///   <para>The 3d vector in World space.</para>
    /// </returns>
    public Vector3 ViewportToWorldPoint(Vector3 position)
    {
      Vector3 vector3;
      Camera.INTERNAL_CALL_ViewportToWorldPoint(this, ref position, out vector3);
      return vector3;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ViewportToWorldPoint(Camera self, ref Vector3 position, out Vector3 value);

    /// <summary>
    ///   <para>Transforms position from screen space into world space.</para>
    /// </summary>
    /// <param name="position"></param>
    public Vector3 ScreenToWorldPoint(Vector3 position)
    {
      Vector3 vector3;
      Camera.INTERNAL_CALL_ScreenToWorldPoint(this, ref position, out vector3);
      return vector3;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ScreenToWorldPoint(Camera self, ref Vector3 position, out Vector3 value);

    /// <summary>
    ///   <para>Transforms position from screen space into viewport space.</para>
    /// </summary>
    /// <param name="position"></param>
    public Vector3 ScreenToViewportPoint(Vector3 position)
    {
      Vector3 vector3;
      Camera.INTERNAL_CALL_ScreenToViewportPoint(this, ref position, out vector3);
      return vector3;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ScreenToViewportPoint(Camera self, ref Vector3 position, out Vector3 value);

    /// <summary>
    ///   <para>Transforms position from viewport space into screen space.</para>
    /// </summary>
    /// <param name="position"></param>
    public Vector3 ViewportToScreenPoint(Vector3 position)
    {
      Vector3 vector3;
      Camera.INTERNAL_CALL_ViewportToScreenPoint(this, ref position, out vector3);
      return vector3;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ViewportToScreenPoint(Camera self, ref Vector3 position, out Vector3 value);

    /// <summary>
    ///   <para>Returns a ray going from camera through a viewport point.</para>
    /// </summary>
    /// <param name="position"></param>
    public Ray ViewportPointToRay(Vector3 position)
    {
      Ray ray;
      Camera.INTERNAL_CALL_ViewportPointToRay(this, ref position, out ray);
      return ray;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ViewportPointToRay(Camera self, ref Vector3 position, out Ray value);

    /// <summary>
    ///   <para>Returns a ray going from camera through a screen point.</para>
    /// </summary>
    /// <param name="position"></param>
    public Ray ScreenPointToRay(Vector3 position)
    {
      Ray ray;
      Camera.INTERNAL_CALL_ScreenPointToRay(this, ref position, out ray);
      return ray;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ScreenPointToRay(Camera self, ref Vector3 position, out Ray value);

    /// <summary>
    ///   <para>The first enabled camera tagged "MainCamera" (Read Only).</para>
    /// </summary>
    public static extern Camera main { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The camera we are currently rendering with, for low-level render control only (Read Only).</para>
    /// </summary>
    public static extern Camera current { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Returns all enabled cameras in the scene.</para>
    /// </summary>
    public static extern Camera[] allCameras { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>The number of cameras in the current scene.</para>
    /// </summary>
    public static extern int allCamerasCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Fills an array of Camera with the current cameras in the scene, without allocating a new array.</para>
    /// </summary>
    /// <param name="cameras">An array to be filled up with cameras currently in the scene.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int GetAllCameras(Camera[] cameras);

    [RequiredByNativeCode]
    private static void FireOnPreCull(Camera cam)
    {
      if (Camera.onPreCull == null)
        return;
      Camera.onPreCull(cam);
    }

    [RequiredByNativeCode]
    private static void FireOnPreRender(Camera cam)
    {
      if (Camera.onPreRender == null)
        return;
      Camera.onPreRender(cam);
    }

    [RequiredByNativeCode]
    private static void FireOnPostRender(Camera cam)
    {
      if (Camera.onPostRender == null)
        return;
      Camera.onPostRender(cam);
    }

    /// <summary>
    ///   <para>Render the camera manually.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Render();

    /// <summary>
    ///   <para>Render the camera with shader replacement.</para>
    /// </summary>
    /// <param name="shader"></param>
    /// <param name="replacementTag"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void RenderWithShader(Shader shader, string replacementTag);

    /// <summary>
    ///   <para>Make the camera render with shader replacement.</para>
    /// </summary>
    /// <param name="shader"></param>
    /// <param name="replacementTag"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetReplacementShader(Shader shader, string replacementTag);

    /// <summary>
    ///   <para>Remove shader replacement from camera.</para>
    /// </summary>
    public void ResetReplacementShader()
    {
      Camera.INTERNAL_CALL_ResetReplacementShader(this);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ResetReplacementShader(Camera self);

    /// <summary>
    ///   <para>Whether or not the Camera will use occlusion culling during rendering.</para>
    /// </summary>
    public extern bool useOcclusionCulling { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets a custom matrix for the camera to use for all culling queries.</para>
    /// </summary>
    public Matrix4x4 cullingMatrix
    {
      get
      {
        Matrix4x4 matrix4x4;
        this.INTERNAL_get_cullingMatrix(out matrix4x4);
        return matrix4x4;
      }
      set
      {
        this.INTERNAL_set_cullingMatrix(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_get_cullingMatrix(out Matrix4x4 value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void INTERNAL_set_cullingMatrix(ref Matrix4x4 value);

    /// <summary>
    ///   <para>Make culling queries reflect the camera's built in parameters.</para>
    /// </summary>
    public void ResetCullingMatrix()
    {
      Camera.INTERNAL_CALL_ResetCullingMatrix(this);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ResetCullingMatrix(Camera self);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void RenderDontRestore();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetupCurrent(Camera cur);

    [ExcludeFromDocs]
    public bool RenderToCubemap(Cubemap cubemap)
    {
      int faceMask = 63;
      return this.RenderToCubemap(cubemap, faceMask);
    }

    /// <summary>
    ///   <para>Render into a static cubemap from this camera.</para>
    /// </summary>
    /// <param name="cubemap">The cube map to render to.</param>
    /// <param name="faceMask">A bitmask which determines which of the six faces are rendered to.</param>
    /// <returns>
    ///   <para>False if rendering fails, else true.</para>
    /// </returns>
    public bool RenderToCubemap(Cubemap cubemap, [DefaultValue("63")] int faceMask)
    {
      return this.Internal_RenderToCubemapTexture(cubemap, faceMask);
    }

    [ExcludeFromDocs]
    public bool RenderToCubemap(RenderTexture cubemap)
    {
      int faceMask = 63;
      return this.RenderToCubemap(cubemap, faceMask);
    }

    /// <summary>
    ///   <para>Render into a cubemap from this camera.</para>
    /// </summary>
    /// <param name="faceMask">A bitfield indicating which cubemap faces should be rendered into.</param>
    /// <param name="cubemap">The texture to render to.</param>
    /// <returns>
    ///   <para>False if rendering fails, else true.</para>
    /// </returns>
    public bool RenderToCubemap(RenderTexture cubemap, [DefaultValue("63")] int faceMask)
    {
      return this.Internal_RenderToCubemapRT(cubemap, faceMask);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool Internal_RenderToCubemapRT(RenderTexture cubemap, int faceMask);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern bool Internal_RenderToCubemapTexture(Cubemap cubemap, int faceMask);

    /// <summary>
    ///   <para>Per-layer culling distances.</para>
    /// </summary>
    public extern float[] layerCullDistances { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>How to perform per-layer culling for a Camera.</para>
    /// </summary>
    public extern bool layerCullSpherical { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Makes this camera's settings match other camera.</para>
    /// </summary>
    /// <param name="other">Copy camera settings to the other camera.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void CopyFrom(Camera other);

    /// <summary>
    ///   <para>How and if camera generates a depth texture.</para>
    /// </summary>
    public extern DepthTextureMode depthTextureMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Should the camera clear the stencil buffer after the deferred light pass?</para>
    /// </summary>
    public extern bool clearStencilAfterLightingPass { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern bool IsFiltered(GameObject go);

    /// <summary>
    ///   <para>Add a command buffer to be executed at a specified place.</para>
    /// </summary>
    /// <param name="evt">When to execute the command buffer during rendering.</param>
    /// <param name="buffer">The buffer to execute.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void AddCommandBuffer(CameraEvent evt, CommandBuffer buffer);

    /// <summary>
    ///   <para>Remove command buffer from execution at a specified place.</para>
    /// </summary>
    /// <param name="evt">When to execute the command buffer during rendering.</param>
    /// <param name="buffer">The buffer to execute.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void RemoveCommandBuffer(CameraEvent evt, CommandBuffer buffer);

    /// <summary>
    ///   <para>Remove command buffers from execution at a specified place.</para>
    /// </summary>
    /// <param name="evt">When to execute the command buffer during rendering.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void RemoveCommandBuffers(CameraEvent evt);

    /// <summary>
    ///   <para>Remove all command buffers set on this camera.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void RemoveAllCommandBuffers();

    /// <summary>
    ///   <para>Get command buffers to be executed at a specified place.</para>
    /// </summary>
    /// <param name="evt">When to execute the command buffer during rendering.</param>
    /// <returns>
    ///   <para>Array of command buffers.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern CommandBuffer[] GetCommandBuffers(CameraEvent evt);

    /// <summary>
    ///   <para>Number of command buffers set up on this camera (Read Only).</para>
    /// </summary>
    public extern int commandBufferCount { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal GameObject RaycastTry(Ray ray, float distance, int layerMask)
    {
      return Camera.INTERNAL_CALL_RaycastTry(this, ref ray, distance, layerMask);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern GameObject INTERNAL_CALL_RaycastTry(Camera self, ref Ray ray, float distance, int layerMask);

    internal GameObject RaycastTry2D(Ray ray, float distance, int layerMask)
    {
      return Camera.INTERNAL_CALL_RaycastTry2D(this, ref ray, distance, layerMask);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern GameObject INTERNAL_CALL_RaycastTry2D(Camera self, ref Ray ray, float distance, int layerMask);

    /// <summary>
    ///   <para>Calculates and returns oblique near-plane projection matrix.</para>
    /// </summary>
    /// <param name="clipPlane">Vector4 that describes a clip plane.</param>
    /// <returns>
    ///   <para>Oblique near-plane projection matrix.</para>
    /// </returns>
    public Matrix4x4 CalculateObliqueMatrix(Vector4 clipPlane)
    {
      Matrix4x4 matrix4x4;
      Camera.INTERNAL_CALL_CalculateObliqueMatrix(this, ref clipPlane, out matrix4x4);
      return matrix4x4;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_CalculateObliqueMatrix(Camera self, ref Vector4 clipPlane, out Matrix4x4 value);

    internal void OnlyUsedForTesting1()
    {
    }

    internal void OnlyUsedForTesting2()
    {
    }

    public Matrix4x4 GetStereoNonJitteredProjectionMatrix(Camera.StereoscopicEye eye)
    {
      Matrix4x4 ret;
      this.GetStereoNonJitteredProjectionMatrix_Injected(eye, out ret);
      return ret;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void CopyStereoDeviceProjectionMatrixToNonJittered(Camera.StereoscopicEye eye);

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Property isOrthoGraphic has been deprecated. Use orthographic (UnityUpgradable) -> orthographic", true)]
    public bool isOrthoGraphic
    {
      get
      {
        return false;
      }
      set
      {
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Property GetScreenWidth() has been deprecated. Use Screen.width instead (UnityUpgradable) -> Screen.width", true)]
    public float GetScreenWidth()
    {
      return 0.0f;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Property GetScreenHeight() has been deprecated. Use Screen.height instead (UnityUpgradable) -> Screen.height", true)]
    public float GetScreenHeight()
    {
      return 0.0f;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Property mainCamera has been deprecated. Use Camera.main instead (UnityUpgradable) -> main", true)]
    public static Camera mainCamera
    {
      get
      {
        return (Camera) null;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Camera.DoClear has been deprecated (UnityUpgradable).", true)]
    public void DoClear()
    {
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetStereoNonJitteredProjectionMatrix_Injected(Camera.StereoscopicEye eye, out Matrix4x4 ret);

    /// <summary>
    ///   <para>Enum used to specify either the left or the right eye of a stereoscopic camera.</para>
    /// </summary>
    public enum StereoscopicEye
    {
      /// <summary>
      ///   <para>Specifies the target to be the left eye.</para>
      /// </summary>
      Left,
      /// <summary>
      ///   <para>Specifies the target to be the right eye.</para>
      /// </summary>
      Right,
    }

    /// <summary>
    ///         <para>A Camera eye corresponding to the left or right human eye for stereoscopic rendering, or neither for non-stereoscopic rendering.
    /// 
    /// A single Camera can render both left and right views in a single frame. Therefore, this enum describes which eye the Camera is currently rendering when returned by Camera.stereoActiveEye during a rendering callback (such as Camera.OnRenderImage), or which eye to act on when passed into a function.
    /// 
    /// The default value is Camera.MonoOrStereoscopicEye.Left, so Camera.MonoOrStereoscopicEye.Left may be returned by some methods or properties when called outside of rendering if stereoscopic rendering is enabled.</para>
    ///       </summary>
    public enum MonoOrStereoscopicEye
    {
      /// <summary>
      ///   <para>Camera eye corresponding to stereoscopic rendering of the left eye.</para>
      /// </summary>
      Left,
      /// <summary>
      ///   <para>Camera eye corresponding to stereoscopic rendering of the right eye.</para>
      /// </summary>
      Right,
      /// <summary>
      ///   <para>Camera eye corresponding to non-stereoscopic rendering.</para>
      /// </summary>
      Mono,
    }

    /// <summary>
    ///   <para>Delegate type for camera callbacks.</para>
    /// </summary>
    /// <param name="cam"></param>
    public delegate void CameraCallback(Camera cam);
  }
}
