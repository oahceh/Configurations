// Decompiled with JetBrains decompiler
// Type: UnityEngine.GUI
// Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDFA4801-4F4D-4B2A-A2B3-B74383337C48
// Assembly location: D:\Unity\Editor\Data\Managed\UnityEngine\UnityEngine.IMGUIModule.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;
using UnityEngineInternal;

namespace UnityEngine
{
  /// <summary>
  ///   <para>The GUI class is the interface for Unity's GUI with manual positioning.</para>
  /// </summary>
  public class GUI
  {
    private static float s_ScrollStepSize = 10f;
    private static int s_HotTextField = -1;
    private static readonly int s_BoxHash = "Box".GetHashCode();
    private static readonly int s_RepeatButtonHash = "repeatButton".GetHashCode();
    private static readonly int s_ToggleHash = "Toggle".GetHashCode();
    private static readonly int s_SliderHash = "Slider".GetHashCode();
    private static readonly int s_BeginGroupHash = "BeginGroup".GetHashCode();
    private static readonly int s_ScrollviewHash = "scrollView".GetHashCode();
    private static GenericStack s_ScrollViewStates = new GenericStack();
    private static int s_ScrollControlId;
    private static GUISkin s_Skin;
    internal static Rect s_ToolTipRect;

    static GUI()
    {
      GUI.nextScrollStepTime = DateTime.Now;
    }

    /// <summary>
    ///   <para>Global tinting color for the GUI.</para>
    /// </summary>
    public static Color color
    {
      get
      {
        Color color;
        GUI.INTERNAL_get_color(out color);
        return color;
      }
      set
      {
        GUI.INTERNAL_set_color(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_get_color(out Color value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_set_color(ref Color value);

    /// <summary>
    ///   <para>Global tinting color for all background elements rendered by the GUI.</para>
    /// </summary>
    public static Color backgroundColor
    {
      get
      {
        Color color;
        GUI.INTERNAL_get_backgroundColor(out color);
        return color;
      }
      set
      {
        GUI.INTERNAL_set_backgroundColor(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_get_backgroundColor(out Color value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_set_backgroundColor(ref Color value);

    /// <summary>
    ///   <para>Tinting color for all text rendered by the GUI.</para>
    /// </summary>
    public static Color contentColor
    {
      get
      {
        Color color;
        GUI.INTERNAL_get_contentColor(out color);
        return color;
      }
      set
      {
        GUI.INTERNAL_set_contentColor(ref value);
      }
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_get_contentColor(out Color value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_set_contentColor(ref Color value);

    /// <summary>
    ///   <para>Returns true if any controls changed the value of the input data.</para>
    /// </summary>
    public static extern bool changed { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Is the GUI enabled?</para>
    /// </summary>
    public static extern bool enabled { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_GetTooltip();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_SetTooltip(string value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern string Internal_GetMouseTooltip();

    /// <summary>
    ///   <para>The sorting depth of the currently executing GUI behaviour.</para>
    /// </summary>
    public static extern int depth { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    private static void DoLabel(Rect position, GUIContent content, IntPtr style)
    {
      GUI.INTERNAL_CALL_DoLabel(ref position, content, style);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_DoLabel(ref Rect position, GUIContent content, IntPtr style);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void InitializeGUIClipTexture();

    internal static extern Material blendMaterial { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static extern Material blitMaterial { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    internal static extern Material roundedRectMaterial { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    private static bool DoButton(Rect position, GUIContent content, IntPtr style)
    {
      return GUI.INTERNAL_CALL_DoButton(ref position, content, style);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool INTERNAL_CALL_DoButton(ref Rect position, GUIContent content, IntPtr style);

    /// <summary>
    ///   <para>Set the name of the next control.</para>
    /// </summary>
    /// <param name="name"></param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void SetNextControlName(string name);

    /// <summary>
    ///   <para>Get the name of named control that has focus.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string GetNameOfFocusedControl();

    /// <summary>
    ///   <para>Move keyboard focus to a named control.</para>
    /// </summary>
    /// <param name="name">Name set using SetNextControlName.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void FocusControl(string name);

    internal static bool DoToggle(Rect position, int id, bool value, GUIContent content, IntPtr style)
    {
      return GUI.INTERNAL_CALL_DoToggle(ref position, id, value, content, style);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool INTERNAL_CALL_DoToggle(ref Rect position, int id, bool value, GUIContent content, IntPtr style);

    internal static extern bool usePageScrollbars { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void InternalRepaintEditorWindow();

    private static Rect Internal_DoModalWindow(int id, int instanceID, Rect clientRect, GUI.WindowFunction func, GUIContent content, GUIStyle style, GUISkin skin)
    {
      Rect rect;
      GUI.INTERNAL_CALL_Internal_DoModalWindow(id, instanceID, ref clientRect, func, content, style, skin, out rect);
      return rect;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Internal_DoModalWindow(int id, int instanceID, ref Rect clientRect, GUI.WindowFunction func, GUIContent content, GUIStyle style, GUISkin skin, out Rect value);

    private static Rect Internal_DoWindow(int id, int instanceID, Rect clientRect, GUI.WindowFunction func, GUIContent title, GUIStyle style, GUISkin skin, bool forceRectOnLayout)
    {
      Rect rect;
      GUI.INTERNAL_CALL_Internal_DoWindow(id, instanceID, ref clientRect, func, title, style, skin, forceRectOnLayout, out rect);
      return rect;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Internal_DoWindow(int id, int instanceID, ref Rect clientRect, GUI.WindowFunction func, GUIContent title, GUIStyle style, GUISkin skin, bool forceRectOnLayout, out Rect value);

    /// <summary>
    ///   <para>Make a window draggable.</para>
    /// </summary>
    /// <param name="position">The part of the window that can be dragged. This is clipped to the actual window.</param>
    public static void DragWindow(Rect position)
    {
      GUI.INTERNAL_CALL_DragWindow(ref position);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_DragWindow(ref Rect position);

    /// <summary>
    ///   <para>Bring a specific window to front of the floating windows.</para>
    /// </summary>
    /// <param name="windowID">The identifier used when you created the window in the Window call.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BringWindowToFront(int windowID);

    /// <summary>
    ///   <para>Bring a specific window to back of the floating windows.</para>
    /// </summary>
    /// <param name="windowID">The identifier used when you created the window in the Window call.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void BringWindowToBack(int windowID);

    /// <summary>
    ///   <para>Make a window become the active window.</para>
    /// </summary>
    /// <param name="windowID">The identifier used when you created the window in the Window call.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void FocusWindow(int windowID);

    /// <summary>
    ///   <para>Remove focus from all windows.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void UnfocusWindow();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_BeginWindows();

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Internal_EndWindows();

    internal static int scrollTroughSide { get; set; }

    internal static DateTime nextScrollStepTime { get; set; }

    /// <summary>
    ///   <para>The global skin to use.</para>
    /// </summary>
    public static GUISkin skin
    {
      set
      {
        GUIUtility.CheckOnGUI();
        GUI.DoSetSkin(value);
      }
      get
      {
        GUIUtility.CheckOnGUI();
        return GUI.s_Skin;
      }
    }

    internal static void DoSetSkin(GUISkin newSkin)
    {
      if (!(bool) ((Object) newSkin))
        newSkin = GUIUtility.GetDefaultSkin();
      GUI.s_Skin = newSkin;
      newSkin.MakeCurrent();
    }

    internal static void CleanupRoots()
    {
      GUI.s_Skin = (GUISkin) null;
      GUIUtility.CleanupRoots();
      GUILayoutUtility.CleanupRoots();
      GUISkin.CleanupRoots();
      GUIStyle.CleanupRoots();
    }

    /// <summary>
    ///   <para>The GUI transform matrix.</para>
    /// </summary>
    public static Matrix4x4 matrix
    {
      get
      {
        return GUIClip.GetMatrix();
      }
      set
      {
        GUIClip.SetMatrix(value);
      }
    }

    /// <summary>
    ///   <para>The tooltip of the control the mouse is currently over, or which has keyboard focus. (Read Only).</para>
    /// </summary>
    public static string tooltip
    {
      get
      {
        return GUI.Internal_GetTooltip() ?? "";
      }
      set
      {
        GUI.Internal_SetTooltip(value);
      }
    }

    protected static string mouseTooltip
    {
      get
      {
        return GUI.Internal_GetMouseTooltip();
      }
    }

    protected static Rect tooltipRect
    {
      get
      {
        return GUI.s_ToolTipRect;
      }
      set
      {
        GUI.s_ToolTipRect = value;
      }
    }

    /// <summary>
    ///   <para>Make a text or texture label on screen.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the label.</param>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    public static void Label(Rect position, string text)
    {
      GUI.Label(position, GUIContent.Temp(text), GUI.s_Skin.label);
    }

    /// <summary>
    ///   <para>Make a text or texture label on screen.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the label.</param>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    public static void Label(Rect position, Texture image)
    {
      GUI.Label(position, GUIContent.Temp(image), GUI.s_Skin.label);
    }

    /// <summary>
    ///   <para>Make a text or texture label on screen.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the label.</param>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    public static void Label(Rect position, GUIContent content)
    {
      GUI.Label(position, content, GUI.s_Skin.label);
    }

    /// <summary>
    ///   <para>Make a text or texture label on screen.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the label.</param>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    public static void Label(Rect position, string text, GUIStyle style)
    {
      GUI.Label(position, GUIContent.Temp(text), style);
    }

    /// <summary>
    ///   <para>Make a text or texture label on screen.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the label.</param>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    public static void Label(Rect position, Texture image, GUIStyle style)
    {
      GUI.Label(position, GUIContent.Temp(image), style);
    }

    /// <summary>
    ///   <para>Make a text or texture label on screen.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the label.</param>
    /// <param name="text">Text to display on the label.</param>
    /// <param name="image">Texture to display on the label.</param>
    /// <param name="content">Text, image and tooltip for this label.</param>
    /// <param name="style">The style to use. If left out, the label style from the current GUISkin is used.</param>
    public static void Label(Rect position, GUIContent content, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      GUI.DoLabel(position, content, style.m_Ptr);
    }

    /// <summary>
    ///   <para>Draw a texture within a rectangle.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to draw the texture within.</param>
    /// <param name="image">Texture to display.</param>
    /// <param name="scaleMode">How to scale the image when the aspect ratio of it doesn't fit the aspect ratio to be drawn within.</param>
    /// <param name="alphaBlend">Whether to apply alpha blending when drawing the image (enabled by default).</param>
    /// <param name="imageAspect">Aspect ratio to use for the source image. If 0 (the default), the aspect ratio from the image is used.  Pass in w/h for the desired aspect ratio.  This allows the aspect ratio of the source image to be adjusted without changing the pixel width and height.</param>
    public static void DrawTexture(Rect position, Texture image)
    {
      GUI.DrawTexture(position, image, ScaleMode.StretchToFill);
    }

    /// <summary>
    ///   <para>Draw a texture within a rectangle.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to draw the texture within.</param>
    /// <param name="image">Texture to display.</param>
    /// <param name="scaleMode">How to scale the image when the aspect ratio of it doesn't fit the aspect ratio to be drawn within.</param>
    /// <param name="alphaBlend">Whether to apply alpha blending when drawing the image (enabled by default).</param>
    /// <param name="imageAspect">Aspect ratio to use for the source image. If 0 (the default), the aspect ratio from the image is used.  Pass in w/h for the desired aspect ratio.  This allows the aspect ratio of the source image to be adjusted without changing the pixel width and height.</param>
    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode)
    {
      GUI.DrawTexture(position, image, scaleMode, true);
    }

    /// <summary>
    ///   <para>Draw a texture within a rectangle.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to draw the texture within.</param>
    /// <param name="image">Texture to display.</param>
    /// <param name="scaleMode">How to scale the image when the aspect ratio of it doesn't fit the aspect ratio to be drawn within.</param>
    /// <param name="alphaBlend">Whether to apply alpha blending when drawing the image (enabled by default).</param>
    /// <param name="imageAspect">Aspect ratio to use for the source image. If 0 (the default), the aspect ratio from the image is used.  Pass in w/h for the desired aspect ratio.  This allows the aspect ratio of the source image to be adjusted without changing the pixel width and height.</param>
    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend)
    {
      GUI.DrawTexture(position, image, scaleMode, alphaBlend, 0.0f);
    }

    /// <summary>
    ///   <para>Draw a texture within a rectangle.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to draw the texture within.</param>
    /// <param name="image">Texture to display.</param>
    /// <param name="scaleMode">How to scale the image when the aspect ratio of it doesn't fit the aspect ratio to be drawn within.</param>
    /// <param name="alphaBlend">Whether to apply alpha blending when drawing the image (enabled by default).</param>
    /// <param name="imageAspect">Aspect ratio to use for the source image. If 0 (the default), the aspect ratio from the image is used.  Pass in w/h for the desired aspect ratio.  This allows the aspect ratio of the source image to be adjusted without changing the pixel width and height.</param>
    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect)
    {
      GUI.DrawTexture(position, image, scaleMode, alphaBlend, imageAspect, GUI.color, 0.0f, 0.0f);
    }

    /// <summary>
    ///   <para>Draws a border with rounded corners within a rectangle. The texture is used to pattern the border.  Note that this method only works on shader model 2.5 and above.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to draw the texture within.</param>
    /// <param name="image">Texture to display.</param>
    /// <param name="scaleMode">How to scale the image when the aspect ratio of it doesn't fit the aspect ratio to be drawn within.</param>
    /// <param name="alphaBlend">Whether to apply alpha blending when drawing the image (enabled by default).</param>
    /// <param name="imageAspect">Aspect ratio to use for the source image. If 0 (the default), the aspect ratio from the image is used.  Pass in w/h for the desired aspect ratio.  This allows the aspect ratio of the source image to be adjusted without changing the pixel width and height.</param>
    /// <param name="color">A tint color to apply on the texture.</param>
    /// <param name="borderWidth">The width of the border. If 0, the full texture is drawn.</param>
    /// <param name="borderWidths">The width of the borders (left, top, right and bottom). If Vector4.zero, the full texture is drawn.</param>
    /// <param name="borderRadius">The radius for rounded corners. If 0, corners will not be rounded.</param>
    /// <param name="borderRadiuses">The radiuses for rounded corners (top-left, top-right, bottom-right and bottom-left). If Vector4.zero, corners will not be rounded.</param>
    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, float borderWidth, float borderRadius)
    {
      Vector4 borderWidths = Vector4.one * borderWidth;
      GUI.DrawTexture(position, image, scaleMode, alphaBlend, imageAspect, color, borderWidths, borderRadius);
    }

    /// <summary>
    ///   <para>Draws a border with rounded corners within a rectangle. The texture is used to pattern the border.  Note that this method only works on shader model 2.5 and above.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to draw the texture within.</param>
    /// <param name="image">Texture to display.</param>
    /// <param name="scaleMode">How to scale the image when the aspect ratio of it doesn't fit the aspect ratio to be drawn within.</param>
    /// <param name="alphaBlend">Whether to apply alpha blending when drawing the image (enabled by default).</param>
    /// <param name="imageAspect">Aspect ratio to use for the source image. If 0 (the default), the aspect ratio from the image is used.  Pass in w/h for the desired aspect ratio.  This allows the aspect ratio of the source image to be adjusted without changing the pixel width and height.</param>
    /// <param name="color">A tint color to apply on the texture.</param>
    /// <param name="borderWidth">The width of the border. If 0, the full texture is drawn.</param>
    /// <param name="borderWidths">The width of the borders (left, top, right and bottom). If Vector4.zero, the full texture is drawn.</param>
    /// <param name="borderRadius">The radius for rounded corners. If 0, corners will not be rounded.</param>
    /// <param name="borderRadiuses">The radiuses for rounded corners (top-left, top-right, bottom-right and bottom-left). If Vector4.zero, corners will not be rounded.</param>
    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, Vector4 borderWidths, float borderRadius)
    {
      Vector4 borderRadiuses = Vector4.one * borderRadius;
      GUI.DrawTexture(position, image, scaleMode, alphaBlend, imageAspect, color, borderWidths, borderRadiuses);
    }

    public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, Vector4 borderWidths, Vector4 borderRadiuses)
    {
      GUIUtility.CheckOnGUI();
      if (Event.current.type != EventType.Repaint)
        return;
      if ((Object) image == (Object) null)
      {
        Debug.LogWarning((object) "null texture passed to GUI.DrawTexture");
      }
      else
      {
        if ((double) imageAspect == 0.0)
          imageAspect = (float) image.width / (float) image.height;
        Material material = borderWidths != Vector4.zero || borderRadiuses != Vector4.zero ? GUI.roundedRectMaterial : (!alphaBlend ? GUI.blitMaterial : GUI.blendMaterial);
        Internal_DrawTextureArguments args = new Internal_DrawTextureArguments();
        args.leftBorder = 0;
        args.rightBorder = 0;
        args.topBorder = 0;
        args.bottomBorder = 0;
        args.color = (Color32) color;
        args.borderWidths = borderWidths;
        args.cornerRadiuses = borderRadiuses;
        args.texture = image;
        args.mat = material;
        GUI.CalculateScaledTextureRects(position, scaleMode, imageAspect, ref args.screenRect, ref args.sourceRect);
        Graphics.Internal_DrawTexture(ref args);
      }
    }

    internal static bool CalculateScaledTextureRects(Rect position, ScaleMode scaleMode, float imageAspect, ref Rect outScreenRect, ref Rect outSourceRect)
    {
      float num1 = position.width / position.height;
      bool flag = false;
      switch (scaleMode)
      {
        case ScaleMode.StretchToFill:
          outScreenRect = position;
          outSourceRect = new Rect(0.0f, 0.0f, 1f, 1f);
          flag = true;
          break;
        case ScaleMode.ScaleAndCrop:
          if ((double) num1 > (double) imageAspect)
          {
            float height = imageAspect / num1;
            outScreenRect = position;
            outSourceRect = new Rect(0.0f, (float) ((1.0 - (double) height) * 0.5), 1f, height);
            flag = true;
            break;
          }
          float width = num1 / imageAspect;
          outScreenRect = position;
          outSourceRect = new Rect((float) (0.5 - (double) width * 0.5), 0.0f, width, 1f);
          flag = true;
          break;
        case ScaleMode.ScaleToFit:
          if ((double) num1 > (double) imageAspect)
          {
            float num2 = imageAspect / num1;
            outScreenRect = new Rect(position.xMin + (float) ((double) position.width * (1.0 - (double) num2) * 0.5), position.yMin, num2 * position.width, position.height);
            outSourceRect = new Rect(0.0f, 0.0f, 1f, 1f);
            flag = true;
            break;
          }
          float num3 = num1 / imageAspect;
          outScreenRect = new Rect(position.xMin, position.yMin + (float) ((double) position.height * (1.0 - (double) num3) * 0.5), position.width, num3 * position.height);
          outSourceRect = new Rect(0.0f, 0.0f, 1f, 1f);
          flag = true;
          break;
      }
      return flag;
    }

    /// <summary>
    ///   <para>Draw a texture within a rectangle with the given texture coordinates.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to draw the texture within.</param>
    /// <param name="image">Texture to display.</param>
    /// <param name="texCoords">How to scale the image when the aspect ratio of it doesn't fit the aspect ratio to be drawn within.</param>
    /// <param name="alphaBlend">Whether to alpha blend the image on to the display (the default). If false, the picture is drawn on to the display.</param>
    public static void DrawTextureWithTexCoords(Rect position, Texture image, Rect texCoords)
    {
      GUI.DrawTextureWithTexCoords(position, image, texCoords, true);
    }

    /// <summary>
    ///   <para>Draw a texture within a rectangle with the given texture coordinates.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to draw the texture within.</param>
    /// <param name="image">Texture to display.</param>
    /// <param name="texCoords">How to scale the image when the aspect ratio of it doesn't fit the aspect ratio to be drawn within.</param>
    /// <param name="alphaBlend">Whether to alpha blend the image on to the display (the default). If false, the picture is drawn on to the display.</param>
    public static void DrawTextureWithTexCoords(Rect position, Texture image, Rect texCoords, bool alphaBlend)
    {
      GUIUtility.CheckOnGUI();
      if (Event.current.type != EventType.Repaint)
        return;
      Material material = !alphaBlend ? GUI.blitMaterial : GUI.blendMaterial;
      Graphics.Internal_DrawTexture(ref new Internal_DrawTextureArguments()
      {
        texture = image,
        mat = material,
        leftBorder = 0,
        rightBorder = 0,
        topBorder = 0,
        bottomBorder = 0,
        color = (Color32) GUI.color,
        screenRect = position,
        sourceRect = texCoords
      });
    }

    /// <summary>
    ///   <para>Create a Box on the GUI Layer.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the box.</param>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    public static void Box(Rect position, string text)
    {
      GUI.Box(position, GUIContent.Temp(text), GUI.s_Skin.box);
    }

    /// <summary>
    ///   <para>Create a Box on the GUI Layer.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the box.</param>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    public static void Box(Rect position, Texture image)
    {
      GUI.Box(position, GUIContent.Temp(image), GUI.s_Skin.box);
    }

    /// <summary>
    ///   <para>Create a Box on the GUI Layer.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the box.</param>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    public static void Box(Rect position, GUIContent content)
    {
      GUI.Box(position, content, GUI.s_Skin.box);
    }

    /// <summary>
    ///   <para>Create a Box on the GUI Layer.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the box.</param>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    public static void Box(Rect position, string text, GUIStyle style)
    {
      GUI.Box(position, GUIContent.Temp(text), style);
    }

    /// <summary>
    ///   <para>Create a Box on the GUI Layer.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the box.</param>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    public static void Box(Rect position, Texture image, GUIStyle style)
    {
      GUI.Box(position, GUIContent.Temp(image), style);
    }

    /// <summary>
    ///   <para>Create a Box on the GUI Layer.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the box.</param>
    /// <param name="text">Text to display on the box.</param>
    /// <param name="image">Texture to display on the box.</param>
    /// <param name="content">Text, image and tooltip for this box.</param>
    /// <param name="style">The style to use. If left out, the box style from the current GUISkin is used.</param>
    public static void Box(Rect position, GUIContent content, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      int controlId = GUIUtility.GetControlID(GUI.s_BoxHash, FocusType.Passive);
      if (Event.current.type != EventType.Repaint)
        return;
      style.Draw(position, content, controlId);
    }

    /// <summary>
    ///   <para>Make a single press button. The user clicks them and something happens immediately.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(Rect position, string text)
    {
      return GUI.Button(position, GUIContent.Temp(text), GUI.s_Skin.button);
    }

    /// <summary>
    ///   <para>Make a single press button. The user clicks them and something happens immediately.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(Rect position, Texture image)
    {
      return GUI.Button(position, GUIContent.Temp(image), GUI.s_Skin.button);
    }

    /// <summary>
    ///   <para>Make a single press button. The user clicks them and something happens immediately.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(Rect position, GUIContent content)
    {
      return GUI.Button(position, content, GUI.s_Skin.button);
    }

    /// <summary>
    ///   <para>Make a single press button. The user clicks them and something happens immediately.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(Rect position, string text, GUIStyle style)
    {
      return GUI.Button(position, GUIContent.Temp(text), style);
    }

    /// <summary>
    ///   <para>Make a single press button. The user clicks them and something happens immediately.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(Rect position, Texture image, GUIStyle style)
    {
      return GUI.Button(position, GUIContent.Temp(image), style);
    }

    /// <summary>
    ///   <para>Make a single press button. The user clicks them and something happens immediately.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>true when the users clicks the button.</para>
    /// </returns>
    public static bool Button(Rect position, GUIContent content, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoButton(position, content, style.m_Ptr);
    }

    /// <summary>
    ///   <para>Make a button that is active as long as the user holds it down.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>True when the users clicks the button.</para>
    /// </returns>
    public static bool RepeatButton(Rect position, string text)
    {
      return GUI.DoRepeatButton(position, GUIContent.Temp(text), GUI.s_Skin.button, FocusType.Passive);
    }

    /// <summary>
    ///   <para>Make a button that is active as long as the user holds it down.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>True when the users clicks the button.</para>
    /// </returns>
    public static bool RepeatButton(Rect position, Texture image)
    {
      return GUI.DoRepeatButton(position, GUIContent.Temp(image), GUI.s_Skin.button, FocusType.Passive);
    }

    /// <summary>
    ///   <para>Make a button that is active as long as the user holds it down.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>True when the users clicks the button.</para>
    /// </returns>
    public static bool RepeatButton(Rect position, GUIContent content)
    {
      return GUI.DoRepeatButton(position, content, GUI.s_Skin.button, FocusType.Passive);
    }

    /// <summary>
    ///   <para>Make a button that is active as long as the user holds it down.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>True when the users clicks the button.</para>
    /// </returns>
    public static bool RepeatButton(Rect position, string text, GUIStyle style)
    {
      return GUI.DoRepeatButton(position, GUIContent.Temp(text), style, FocusType.Passive);
    }

    /// <summary>
    ///   <para>Make a button that is active as long as the user holds it down.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>True when the users clicks the button.</para>
    /// </returns>
    public static bool RepeatButton(Rect position, Texture image, GUIStyle style)
    {
      return GUI.DoRepeatButton(position, GUIContent.Temp(image), style, FocusType.Passive);
    }

    /// <summary>
    ///   <para>Make a button that is active as long as the user holds it down.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>True when the users clicks the button.</para>
    /// </returns>
    public static bool RepeatButton(Rect position, GUIContent content, GUIStyle style)
    {
      return GUI.DoRepeatButton(position, content, style, FocusType.Passive);
    }

    private static bool DoRepeatButton(Rect position, GUIContent content, GUIStyle style, FocusType focusType)
    {
      GUIUtility.CheckOnGUI();
      int controlId = GUIUtility.GetControlID(GUI.s_RepeatButtonHash, focusType, position);
      switch (Event.current.GetTypeForControl(controlId))
      {
        case EventType.MouseDown:
          if (position.Contains(Event.current.mousePosition))
          {
            GUIUtility.hotControl = controlId;
            Event.current.Use();
          }
          return false;
        case EventType.MouseUp:
          if (GUIUtility.hotControl != controlId)
            return false;
          GUIUtility.hotControl = 0;
          Event.current.Use();
          return position.Contains(Event.current.mousePosition);
        case EventType.Repaint:
          style.Draw(position, content, controlId);
          return controlId == GUIUtility.hotControl && position.Contains(Event.current.mousePosition);
        default:
          return false;
      }
    }

    /// <summary>
    ///   <para>Make a single-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextField(Rect position, string text)
    {
      GUIContent content = GUIContent.Temp(text);
      GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), content, false, -1, GUI.skin.textField);
      return content.text;
    }

    /// <summary>
    ///   <para>Make a single-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextField(Rect position, string text, int maxLength)
    {
      GUIContent content = GUIContent.Temp(text);
      GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), content, false, maxLength, GUI.skin.textField);
      return content.text;
    }

    /// <summary>
    ///   <para>Make a single-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextField(Rect position, string text, GUIStyle style)
    {
      GUIContent content = GUIContent.Temp(text);
      GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), content, false, -1, style);
      return content.text;
    }

    /// <summary>
    ///   <para>Make a single-line text field where the user can edit a string.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextField(Rect position, string text, int maxLength, GUIStyle style)
    {
      GUIContent content = GUIContent.Temp(text);
      GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), content, false, maxLength, style);
      return content.text;
    }

    /// <summary>
    ///   <para>Make a text field where the user can enter a password.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="password">Password to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maskChar">Character to mask the password with.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited password.</para>
    /// </returns>
    public static string PasswordField(Rect position, string password, char maskChar)
    {
      return GUI.PasswordField(position, password, maskChar, -1, GUI.skin.textField);
    }

    /// <summary>
    ///   <para>Make a text field where the user can enter a password.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="password">Password to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maskChar">Character to mask the password with.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited password.</para>
    /// </returns>
    public static string PasswordField(Rect position, string password, char maskChar, int maxLength)
    {
      return GUI.PasswordField(position, password, maskChar, maxLength, GUI.skin.textField);
    }

    /// <summary>
    ///   <para>Make a text field where the user can enter a password.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="password">Password to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maskChar">Character to mask the password with.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited password.</para>
    /// </returns>
    public static string PasswordField(Rect position, string password, char maskChar, GUIStyle style)
    {
      return GUI.PasswordField(position, password, maskChar, -1, style);
    }

    /// <summary>
    ///   <para>Make a text field where the user can enter a password.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="password">Password to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maskChar">Character to mask the password with.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textField style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited password.</para>
    /// </returns>
    public static string PasswordField(Rect position, string password, char maskChar, int maxLength, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      GUIContent content = GUIContent.Temp(GUI.PasswordFieldGetStrToShow(password, maskChar));
      bool changed = GUI.changed;
      GUI.changed = false;
      if (TouchScreenKeyboard.isSupported)
        GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard), content, false, maxLength, style, password, maskChar);
      else
        GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), content, false, maxLength, style);
      string str = !GUI.changed ? password : content.text;
      GUI.changed |= changed;
      return str;
    }

    internal static string PasswordFieldGetStrToShow(string password, char maskChar)
    {
      return Event.current.type == EventType.Repaint || Event.current.type == EventType.MouseDown ? "".PadRight(password.Length, maskChar) : password;
    }

    /// <summary>
    ///   <para>Make a Multi-line text area where the user can edit a string.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textArea style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextArea(Rect position, string text)
    {
      GUIContent content = GUIContent.Temp(text);
      GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), content, true, -1, GUI.skin.textArea);
      return content.text;
    }

    /// <summary>
    ///   <para>Make a Multi-line text area where the user can edit a string.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textArea style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextArea(Rect position, string text, int maxLength)
    {
      GUIContent content = GUIContent.Temp(text);
      GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), content, true, maxLength, GUI.skin.textArea);
      return content.text;
    }

    /// <summary>
    ///   <para>Make a Multi-line text area where the user can edit a string.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textArea style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextArea(Rect position, string text, GUIStyle style)
    {
      GUIContent content = GUIContent.Temp(text);
      GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), content, true, -1, style);
      return content.text;
    }

    /// <summary>
    ///   <para>Make a Multi-line text area where the user can edit a string.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the text field.</param>
    /// <param name="text">Text to edit. The return value of this function should be assigned back to the string as shown in the example.</param>
    /// <param name="maxLength">The maximum length of the string. If left out, the user can type for ever and ever.</param>
    /// <param name="style">The style to use. If left out, the textArea style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The edited string.</para>
    /// </returns>
    public static string TextArea(Rect position, string text, int maxLength, GUIStyle style)
    {
      GUIContent content = GUIContent.Temp(text);
      GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), content, false, maxLength, style);
      return content.text;
    }

    private static string TextArea(Rect position, GUIContent content, int maxLength, GUIStyle style)
    {
      GUIContent content1 = GUIContent.Temp(content.text, content.image);
      GUI.DoTextField(position, GUIUtility.GetControlID(FocusType.Keyboard, position), content1, false, maxLength, style);
      return content1.text;
    }

    internal static void DoTextField(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style)
    {
      GUI.DoTextField(position, id, content, multiline, maxLength, style, (string) null);
    }

    internal static void DoTextField(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, string secureText)
    {
      GUI.DoTextField(position, id, content, multiline, maxLength, style, secureText, char.MinValue);
    }

    internal static void DoTextField(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, string secureText, char maskChar)
    {
      GUIUtility.CheckOnGUI();
      if (maxLength >= 0 && content.text.Length > maxLength)
        content.text = content.text.Substring(0, maxLength);
      TextEditor stateObject = (TextEditor) GUIUtility.GetStateObject(typeof (TextEditor), id);
      stateObject.text = content.text;
      stateObject.SaveBackup();
      stateObject.position = position;
      stateObject.style = style;
      stateObject.multiline = multiline;
      stateObject.controlID = id;
      stateObject.DetectFocusChange();
      if (TouchScreenKeyboard.isSupported)
        GUI.HandleTextFieldEventForTouchscreen(position, id, content, multiline, maxLength, style, secureText, maskChar, stateObject);
      else
        GUI.HandleTextFieldEventForDesktop(position, id, content, multiline, maxLength, style, stateObject);
      stateObject.UpdateScrollOffsetIfNeeded(Event.current);
    }

    private static void HandleTextFieldEventForTouchscreen(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, string secureText, char maskChar, TextEditor editor)
    {
      Event current = Event.current;
      switch (current.type)
      {
        case EventType.MouseDown:
          if (!position.Contains(current.mousePosition))
            break;
          GUIUtility.hotControl = id;
          if (GUI.s_HotTextField != -1 && GUI.s_HotTextField != id)
            ((TextEditor) GUIUtility.GetStateObject(typeof (TextEditor), GUI.s_HotTextField)).keyboardOnScreen = (TouchScreenKeyboard) null;
          GUI.s_HotTextField = id;
          if (GUIUtility.keyboardControl != id)
            GUIUtility.keyboardControl = id;
          editor.keyboardOnScreen = TouchScreenKeyboard.Open(secureText == null ? content.text : secureText, TouchScreenKeyboardType.Default, true, multiline, secureText != null);
          current.Use();
          break;
        case EventType.Repaint:
          if (editor.keyboardOnScreen != null)
          {
            content.text = editor.keyboardOnScreen.text;
            if (maxLength >= 0 && content.text.Length > maxLength)
              content.text = content.text.Substring(0, maxLength);
            if (editor.keyboardOnScreen.done)
            {
              editor.keyboardOnScreen = (TouchScreenKeyboard) null;
              GUI.changed = true;
            }
          }
          string text = content.text;
          if (secureText != null)
            content.text = GUI.PasswordFieldGetStrToShow(text, maskChar);
          style.Draw(position, content, id, false);
          content.text = text;
          break;
      }
    }

    private static void HandleTextFieldEventForDesktop(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, TextEditor editor)
    {
      Event current = Event.current;
      bool flag = false;
      switch (current.type)
      {
        case EventType.MouseDown:
          if (position.Contains(current.mousePosition))
          {
            GUIUtility.hotControl = id;
            GUIUtility.keyboardControl = id;
            editor.m_HasFocus = true;
            editor.MoveCursorToPosition(Event.current.mousePosition);
            if (Event.current.clickCount == 2 && GUI.skin.settings.doubleClickSelectsWord)
            {
              editor.SelectCurrentWord();
              editor.DblClickSnap(TextEditor.DblClickSnapping.WORDS);
              editor.MouseDragSelectsWholeWords(true);
            }
            if (Event.current.clickCount == 3 && GUI.skin.settings.tripleClickSelectsLine)
            {
              editor.SelectCurrentParagraph();
              editor.MouseDragSelectsWholeWords(true);
              editor.DblClickSnap(TextEditor.DblClickSnapping.PARAGRAPHS);
            }
            current.Use();
            break;
          }
          break;
        case EventType.MouseUp:
          if (GUIUtility.hotControl == id)
          {
            editor.MouseDragSelectsWholeWords(false);
            GUIUtility.hotControl = 0;
            current.Use();
            break;
          }
          break;
        case EventType.MouseDrag:
          if (GUIUtility.hotControl == id)
          {
            if (current.shift)
              editor.MoveCursorToPosition(Event.current.mousePosition);
            else
              editor.SelectToPosition(Event.current.mousePosition);
            current.Use();
            break;
          }
          break;
        case EventType.KeyDown:
          if (GUIUtility.keyboardControl != id)
            return;
          if (editor.HandleKeyEvent(current))
          {
            current.Use();
            flag = true;
            content.text = editor.text;
            break;
          }
          if (current.keyCode == KeyCode.Tab || current.character == '\t')
            return;
          char character = current.character;
          if (character == '\n' && !multiline && !current.alt)
            return;
          Font font = style.font;
          if (!(bool) ((Object) font))
            font = GUI.skin.font;
          if (!font.HasCharacter(character))
          {
            switch (character)
            {
              case char.MinValue:
                if (Input.compositionString.Length > 0)
                {
                  editor.ReplaceSelection("");
                  flag = true;
                }
                current.Use();
                goto label_34;
              case '\n':
                break;
              default:
                goto label_34;
            }
          }
          editor.Insert(character);
          flag = true;
          break;
        case EventType.Repaint:
          if (GUIUtility.keyboardControl != id)
          {
            style.Draw(position, content, id, false);
            break;
          }
          editor.DrawCursor(content.text);
          break;
      }
label_34:
      if (GUIUtility.keyboardControl == id)
        GUIUtility.textFieldInput = true;
      if (!flag)
        return;
      GUI.changed = true;
      content.text = editor.text;
      if (maxLength >= 0 && content.text.Length > maxLength)
        content.text = content.text.Substring(0, maxLength);
      current.Use();
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="value">Is this button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the toggle style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(Rect position, bool value, string text)
    {
      return GUI.Toggle(position, value, GUIContent.Temp(text), GUI.s_Skin.toggle);
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="value">Is this button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the toggle style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(Rect position, bool value, Texture image)
    {
      return GUI.Toggle(position, value, GUIContent.Temp(image), GUI.s_Skin.toggle);
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="value">Is this button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the toggle style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(Rect position, bool value, GUIContent content)
    {
      return GUI.Toggle(position, value, content, GUI.s_Skin.toggle);
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="value">Is this button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the toggle style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(Rect position, bool value, string text, GUIStyle style)
    {
      return GUI.Toggle(position, value, GUIContent.Temp(text), style);
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="value">Is this button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the toggle style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(Rect position, bool value, Texture image, GUIStyle style)
    {
      return GUI.Toggle(position, value, GUIContent.Temp(image), style);
    }

    /// <summary>
    ///   <para>Make an on/off toggle button.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the button.</param>
    /// <param name="value">Is this button on or off?</param>
    /// <param name="text">Text to display on the button.</param>
    /// <param name="image">Texture to display on the button.</param>
    /// <param name="content">Text, image and tooltip for this button.</param>
    /// <param name="style">The style to use. If left out, the toggle style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The new value of the button.</para>
    /// </returns>
    public static bool Toggle(Rect position, bool value, GUIContent content, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoToggle(position, GUIUtility.GetControlID(GUI.s_ToggleHash, FocusType.Passive, position), value, content, style.m_Ptr);
    }

    public static bool Toggle(Rect position, int id, bool value, GUIContent content, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoToggle(position, id, value, content, style.m_Ptr);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the toolbar.</param>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the toolbar buttons.</param>
    /// <param name="images">An array of textures on the toolbar buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the toolbar buttons.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(Rect position, int selected, string[] texts)
    {
      return GUI.Toolbar(position, selected, GUIContent.Temp(texts), GUI.s_Skin.button);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the toolbar.</param>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the toolbar buttons.</param>
    /// <param name="images">An array of textures on the toolbar buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the toolbar buttons.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(Rect position, int selected, Texture[] images)
    {
      return GUI.Toolbar(position, selected, GUIContent.Temp(images), GUI.s_Skin.button);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the toolbar.</param>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the toolbar buttons.</param>
    /// <param name="images">An array of textures on the toolbar buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the toolbar buttons.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(Rect position, int selected, GUIContent[] contents)
    {
      return GUI.Toolbar(position, selected, contents, GUI.s_Skin.button);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the toolbar.</param>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the toolbar buttons.</param>
    /// <param name="images">An array of textures on the toolbar buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the toolbar buttons.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(Rect position, int selected, string[] texts, GUIStyle style)
    {
      return GUI.Toolbar(position, selected, GUIContent.Temp(texts), style);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the toolbar.</param>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the toolbar buttons.</param>
    /// <param name="images">An array of textures on the toolbar buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the toolbar buttons.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(Rect position, int selected, Texture[] images, GUIStyle style)
    {
      return GUI.Toolbar(position, selected, GUIContent.Temp(images), style);
    }

    /// <summary>
    ///   <para>Make a toolbar.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the toolbar.</param>
    /// <param name="selected">The index of the selected button.</param>
    /// <param name="texts">An array of strings to show on the toolbar buttons.</param>
    /// <param name="images">An array of textures on the toolbar buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the toolbar buttons.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="buttonSize">Determines how toolbar button size is calculated.</param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int Toolbar(Rect position, int selected, GUIContent[] contents, GUIStyle style)
    {
      return GUI.Toolbar(position, selected, contents, (string[]) null, style, GUI.ToolbarButtonSize.Fixed);
    }

    public static int Toolbar(Rect position, int selected, GUIContent[] contents, GUIStyle style, GUI.ToolbarButtonSize buttonSize)
    {
      return GUI.Toolbar(position, selected, contents, (string[]) null, style, buttonSize);
    }

    internal static int Toolbar(Rect position, int selected, GUIContent[] contents, string[] controlNames, GUIStyle style, GUI.ToolbarButtonSize buttonSize)
    {
      GUIUtility.CheckOnGUI();
      GUIStyle firstStyle;
      GUIStyle midStyle;
      GUIStyle lastStyle;
      GUI.FindStyles(ref style, out firstStyle, out midStyle, out lastStyle, "left", "mid", "right");
      return GUI.DoButtonGrid(position, selected, contents, controlNames, contents.Length, style, firstStyle, midStyle, lastStyle, buttonSize);
    }

    /// <summary>
    ///   <para>Make a grid of buttons.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the grid.</param>
    /// <param name="selected">The index of the selected grid button.</param>
    /// <param name="texts">An array of strings to show on the grid buttons.</param>
    /// <param name="images">An array of textures on the grid buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the grid button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The controls will be scaled to fit unless the style defines a fixedWidth to use.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(Rect position, int selected, string[] texts, int xCount)
    {
      return GUI.SelectionGrid(position, selected, GUIContent.Temp(texts), xCount, (GUIStyle) null);
    }

    /// <summary>
    ///   <para>Make a grid of buttons.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the grid.</param>
    /// <param name="selected">The index of the selected grid button.</param>
    /// <param name="texts">An array of strings to show on the grid buttons.</param>
    /// <param name="images">An array of textures on the grid buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the grid button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The controls will be scaled to fit unless the style defines a fixedWidth to use.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(Rect position, int selected, Texture[] images, int xCount)
    {
      return GUI.SelectionGrid(position, selected, GUIContent.Temp(images), xCount, (GUIStyle) null);
    }

    /// <summary>
    ///   <para>Make a grid of buttons.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the grid.</param>
    /// <param name="selected">The index of the selected grid button.</param>
    /// <param name="texts">An array of strings to show on the grid buttons.</param>
    /// <param name="images">An array of textures on the grid buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the grid button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The controls will be scaled to fit unless the style defines a fixedWidth to use.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(Rect position, int selected, GUIContent[] content, int xCount)
    {
      return GUI.SelectionGrid(position, selected, content, xCount, (GUIStyle) null);
    }

    /// <summary>
    ///   <para>Make a grid of buttons.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the grid.</param>
    /// <param name="selected">The index of the selected grid button.</param>
    /// <param name="texts">An array of strings to show on the grid buttons.</param>
    /// <param name="images">An array of textures on the grid buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the grid button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The controls will be scaled to fit unless the style defines a fixedWidth to use.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(Rect position, int selected, string[] texts, int xCount, GUIStyle style)
    {
      return GUI.SelectionGrid(position, selected, GUIContent.Temp(texts), xCount, style);
    }

    /// <summary>
    ///   <para>Make a grid of buttons.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the grid.</param>
    /// <param name="selected">The index of the selected grid button.</param>
    /// <param name="texts">An array of strings to show on the grid buttons.</param>
    /// <param name="images">An array of textures on the grid buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the grid button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The controls will be scaled to fit unless the style defines a fixedWidth to use.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(Rect position, int selected, Texture[] images, int xCount, GUIStyle style)
    {
      return GUI.SelectionGrid(position, selected, GUIContent.Temp(images), xCount, style);
    }

    /// <summary>
    ///   <para>Make a grid of buttons.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the grid.</param>
    /// <param name="selected">The index of the selected grid button.</param>
    /// <param name="texts">An array of strings to show on the grid buttons.</param>
    /// <param name="images">An array of textures on the grid buttons.</param>
    /// <param name="contents">An array of text, image and tooltips for the grid button.</param>
    /// <param name="xCount">How many elements to fit in the horizontal direction. The controls will be scaled to fit unless the style defines a fixedWidth to use.</param>
    /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
    /// <param name="content"></param>
    /// <returns>
    ///   <para>The index of the selected button.</para>
    /// </returns>
    public static int SelectionGrid(Rect position, int selected, GUIContent[] contents, int xCount, GUIStyle style)
    {
      if (style == null)
        style = GUI.s_Skin.button;
      return GUI.DoButtonGrid(position, selected, contents, (string[]) null, xCount, style, style, style, style, GUI.ToolbarButtonSize.Fixed);
    }

    internal static void FindStyles(ref GUIStyle style, out GUIStyle firstStyle, out GUIStyle midStyle, out GUIStyle lastStyle, string first, string mid, string last)
    {
      if (style == null)
        style = GUI.skin.button;
      string name = style.name;
      midStyle = GUI.skin.FindStyle(name + mid);
      if (midStyle == null)
        midStyle = style;
      firstStyle = GUI.skin.FindStyle(name + first);
      if (firstStyle == null)
        firstStyle = midStyle;
      lastStyle = GUI.skin.FindStyle(name + last);
      if (lastStyle != null)
        return;
      lastStyle = midStyle;
    }

    internal static int CalcTotalHorizSpacing(int xCount, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle)
    {
      if (xCount < 2)
        return 0;
      if (xCount == 2)
        return Mathf.Max(firstStyle.margin.right, lastStyle.margin.left);
      int num = Mathf.Max(midStyle.margin.left, midStyle.margin.right);
      return Mathf.Max(firstStyle.margin.right, midStyle.margin.left) + Mathf.Max(midStyle.margin.right, lastStyle.margin.left) + num * (xCount - 3);
    }

    private static int DoButtonGrid(Rect position, int selected, GUIContent[] contents, string[] controlNames, int xCount, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle, GUI.ToolbarButtonSize buttonSize)
    {
      GUIUtility.CheckOnGUI();
      int length = contents.Length;
      if (length == 0)
        return selected;
      if (xCount <= 0)
      {
        Debug.LogWarning((object) "You are trying to create a SelectionGrid with zero or less elements to be displayed in the horizontal direction. Set xCount to a positive value.");
        return selected;
      }
      int num1 = length / xCount;
      if (length % xCount != 0)
        ++num1;
      float num2 = (float) GUI.CalcTotalHorizSpacing(xCount, style, firstStyle, midStyle, lastStyle);
      float num3 = (float) (Mathf.Max(style.margin.top, style.margin.bottom) * (num1 - 1));
      float elemWidth = (position.width - num2) / (float) xCount;
      float elemHeight = (position.height - num3) / (float) num1;
      if ((double) style.fixedWidth != 0.0)
        elemWidth = style.fixedWidth;
      if ((double) style.fixedHeight != 0.0)
        elemHeight = style.fixedHeight;
      Rect[] rectArray = GUI.CalcMouseRects(position, contents, xCount, elemWidth, elemHeight, style, firstStyle, midStyle, lastStyle, false, buttonSize);
      GUIStyle guiStyle1 = (GUIStyle) null;
      int num4 = 0;
      for (int index = 0; index < length; ++index)
      {
        Rect rect = rectArray[index];
        GUIContent content = contents[index];
        if (controlNames != null)
          GUI.SetNextControlName(controlNames[index]);
        int controlId = GUIUtility.GetControlID(content, FocusType.Passive, rect);
        if (index == selected)
          num4 = controlId;
        switch (Event.current.GetTypeForControl(controlId))
        {
          case EventType.MouseDown:
            if (rect.Contains(Event.current.mousePosition))
            {
              GUIUtility.hotControl = controlId;
              Event.current.Use();
              break;
            }
            break;
          case EventType.MouseUp:
            if (GUIUtility.hotControl == controlId)
            {
              GUIUtility.hotControl = 0;
              Event.current.Use();
              GUI.changed = true;
              return index;
            }
            break;
          case EventType.MouseDrag:
            if (GUIUtility.hotControl == controlId)
            {
              Event.current.Use();
              break;
            }
            break;
          case EventType.Repaint:
            GUIStyle guiStyle2 = length != 1 ? (index != 0 ? (index != length - 1 ? midStyle : lastStyle) : firstStyle) : style;
            bool flag1 = rect.Contains(Event.current.mousePosition);
            bool flag2 = GUIUtility.hotControl == controlId;
            if (selected != index)
              guiStyle2.Draw(rect, content, flag1 && (GUI.enabled || flag2) && (flag2 || GUIUtility.hotControl == 0), GUI.enabled && flag2, false, false);
            else
              guiStyle1 = guiStyle2;
            if (flag1)
            {
              GUIUtility.mouseUsed = true;
              if (!string.IsNullOrEmpty(content.tooltip))
                GUIStyle.SetMouseTooltip(content.tooltip, rect);
              break;
            }
            break;
        }
      }
      if (guiStyle1 != null)
      {
        Rect position1 = rectArray[selected];
        GUIContent content = contents[selected];
        bool flag1 = position1.Contains(Event.current.mousePosition);
        bool flag2 = GUIUtility.hotControl == num4;
        guiStyle1.Draw(position1, content, flag1 && (GUI.enabled || flag2) && (flag2 || GUIUtility.hotControl == 0), GUI.enabled && flag2, true, false);
      }
      return selected;
    }

    private static Rect[] CalcMouseRects(Rect position, GUIContent[] contents, int xCount, float elemWidth, float elemHeight, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle, bool addBorders, GUI.ToolbarButtonSize buttonSize)
    {
      int length = contents.Length;
      int num1 = 0;
      int num2 = 0;
      float xMin = position.xMin;
      float yMin = position.yMin;
      GUIStyle guiStyle1 = style;
      Rect[] rectArray = new Rect[length];
      if (length > 1)
        guiStyle1 = firstStyle;
      for (int index = 0; index < length; ++index)
      {
        float width = 0.0f;
        switch (buttonSize)
        {
          case GUI.ToolbarButtonSize.Fixed:
            width = elemWidth;
            break;
          case GUI.ToolbarButtonSize.FitToContents:
            width = guiStyle1.CalcSize(contents[index]).x;
            break;
        }
        rectArray[index] = addBorders ? guiStyle1.margin.Add(new Rect(xMin, yMin, width, elemHeight)) : new Rect(xMin, yMin, width, elemHeight);
        rectArray[index].width = Mathf.Round(rectArray[index].xMax) - Mathf.Round(rectArray[index].x);
        rectArray[index].x = Mathf.Round(rectArray[index].x);
        GUIStyle guiStyle2 = midStyle;
        if (index == length - 2 || index == xCount - 2)
          guiStyle2 = lastStyle;
        xMin += width + (float) Mathf.Max(guiStyle1.margin.right, guiStyle2.margin.left);
        ++num2;
        if (num2 >= xCount)
        {
          ++num1;
          num2 = 0;
          yMin += elemHeight + (float) Mathf.Max(style.margin.top, style.margin.bottom);
          xMin = position.xMin;
          guiStyle2 = firstStyle;
        }
        guiStyle1 = guiStyle2;
      }
      return rectArray;
    }

    /// <summary>
    ///   <para>A horizontal slider the user can drag to change a value between a min and a max.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the slider.</param>
    /// <param name="value">The value the slider shows. This determines the position of the draggable thumb.</param>
    /// <param name="leftValue">The value at the left end of the slider.</param>
    /// <param name="rightValue">The value at the right end of the slider.</param>
    /// <param name="slider">The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider style from the current GUISkin is used.</param>
    /// <param name="thumb">The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The value that has been set by the user.</para>
    /// </returns>
    public static float HorizontalSlider(Rect position, float value, float leftValue, float rightValue)
    {
      return GUI.Slider(position, value, 0.0f, leftValue, rightValue, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb, true, 0);
    }

    /// <summary>
    ///   <para>A horizontal slider the user can drag to change a value between a min and a max.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the slider.</param>
    /// <param name="value">The value the slider shows. This determines the position of the draggable thumb.</param>
    /// <param name="leftValue">The value at the left end of the slider.</param>
    /// <param name="rightValue">The value at the right end of the slider.</param>
    /// <param name="slider">The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider style from the current GUISkin is used.</param>
    /// <param name="thumb">The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The value that has been set by the user.</para>
    /// </returns>
    public static float HorizontalSlider(Rect position, float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb)
    {
      return GUI.Slider(position, value, 0.0f, leftValue, rightValue, slider, thumb, true, 0);
    }

    /// <summary>
    ///   <para>A vertical slider the user can drag to change a value between a min and a max.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the slider.</param>
    /// <param name="value">The value the slider shows. This determines the position of the draggable thumb.</param>
    /// <param name="topValue">The value at the top end of the slider.</param>
    /// <param name="bottomValue">The value at the bottom end of the slider.</param>
    /// <param name="slider">The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider style from the current GUISkin is used.</param>
    /// <param name="thumb">The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The value that has been set by the user.</para>
    /// </returns>
    public static float VerticalSlider(Rect position, float value, float topValue, float bottomValue)
    {
      return GUI.Slider(position, value, 0.0f, topValue, bottomValue, GUI.skin.verticalSlider, GUI.skin.verticalSliderThumb, false, 0);
    }

    /// <summary>
    ///   <para>A vertical slider the user can drag to change a value between a min and a max.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the slider.</param>
    /// <param name="value">The value the slider shows. This determines the position of the draggable thumb.</param>
    /// <param name="topValue">The value at the top end of the slider.</param>
    /// <param name="bottomValue">The value at the bottom end of the slider.</param>
    /// <param name="slider">The GUIStyle to use for displaying the dragging area. If left out, the horizontalSlider style from the current GUISkin is used.</param>
    /// <param name="thumb">The GUIStyle to use for displaying draggable thumb. If left out, the horizontalSliderThumb style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The value that has been set by the user.</para>
    /// </returns>
    public static float VerticalSlider(Rect position, float value, float topValue, float bottomValue, GUIStyle slider, GUIStyle thumb)
    {
      return GUI.Slider(position, value, 0.0f, topValue, bottomValue, slider, thumb, false, 0);
    }

    public static float Slider(Rect position, float value, float size, float start, float end, GUIStyle slider, GUIStyle thumb, bool horiz, int id)
    {
      GUIUtility.CheckOnGUI();
      if (id == 0)
        id = GUIUtility.GetControlID(GUI.s_SliderHash, FocusType.Passive, position);
      return new SliderHandler(position, value, size, start, end, slider, thumb, horiz, id).Handle();
    }

    /// <summary>
    ///   <para>Make a horizontal scrollbar. Scrollbars are what you use to scroll through a document. Most likely, you want to use scrollViews instead.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the scrollbar.</param>
    /// <param name="value">The position between min and max.</param>
    /// <param name="size">How much can we see?</param>
    /// <param name="leftValue">The value at the left end of the scrollbar.</param>
    /// <param name="rightValue">The value at the right end of the scrollbar.</param>
    /// <param name="style">The style to use for the scrollbar background. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The modified value. This can be changed by the user by dragging the scrollbar, or clicking the arrows at the end.</para>
    /// </returns>
    public static float HorizontalScrollbar(Rect position, float value, float size, float leftValue, float rightValue)
    {
      return GUI.Scroller(position, value, size, leftValue, rightValue, GUI.skin.horizontalScrollbar, GUI.skin.horizontalScrollbarThumb, GUI.skin.horizontalScrollbarLeftButton, GUI.skin.horizontalScrollbarRightButton, true);
    }

    /// <summary>
    ///   <para>Make a horizontal scrollbar. Scrollbars are what you use to scroll through a document. Most likely, you want to use scrollViews instead.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the scrollbar.</param>
    /// <param name="value">The position between min and max.</param>
    /// <param name="size">How much can we see?</param>
    /// <param name="leftValue">The value at the left end of the scrollbar.</param>
    /// <param name="rightValue">The value at the right end of the scrollbar.</param>
    /// <param name="style">The style to use for the scrollbar background. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The modified value. This can be changed by the user by dragging the scrollbar, or clicking the arrows at the end.</para>
    /// </returns>
    public static float HorizontalScrollbar(Rect position, float value, float size, float leftValue, float rightValue, GUIStyle style)
    {
      return GUI.Scroller(position, value, size, leftValue, rightValue, style, GUI.skin.GetStyle(style.name + "thumb"), GUI.skin.GetStyle(style.name + "leftbutton"), GUI.skin.GetStyle(style.name + "rightbutton"), true);
    }

    internal static bool ScrollerRepeatButton(int scrollerID, Rect rect, GUIStyle style)
    {
      bool flag1 = false;
      if (GUI.DoRepeatButton(rect, GUIContent.none, style, FocusType.Passive))
      {
        bool flag2 = GUI.s_ScrollControlId != scrollerID;
        GUI.s_ScrollControlId = scrollerID;
        if (flag2)
        {
          flag1 = true;
          GUI.nextScrollStepTime = DateTime.Now.AddMilliseconds(250.0);
        }
        else if (DateTime.Now >= GUI.nextScrollStepTime)
        {
          flag1 = true;
          GUI.nextScrollStepTime = DateTime.Now.AddMilliseconds(30.0);
        }
        if (Event.current.type == EventType.Repaint)
          GUI.InternalRepaintEditorWindow();
      }
      return flag1;
    }

    /// <summary>
    ///   <para>Make a vertical scrollbar. Scrollbars are what you use to scroll through a document. Most likely, you want to use scrollViews instead.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the scrollbar.</param>
    /// <param name="value">The position between min and max.</param>
    /// <param name="size">How much can we see?</param>
    /// <param name="topValue">The value at the top of the scrollbar.</param>
    /// <param name="bottomValue">The value at the bottom of the scrollbar.</param>
    /// <param name="style">The style to use for the scrollbar background. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The modified value. This can be changed by the user by dragging the scrollbar, or clicking the arrows at the end.</para>
    /// </returns>
    public static float VerticalScrollbar(Rect position, float value, float size, float topValue, float bottomValue)
    {
      return GUI.Scroller(position, value, size, topValue, bottomValue, GUI.skin.verticalScrollbar, GUI.skin.verticalScrollbarThumb, GUI.skin.verticalScrollbarUpButton, GUI.skin.verticalScrollbarDownButton, false);
    }

    /// <summary>
    ///   <para>Make a vertical scrollbar. Scrollbars are what you use to scroll through a document. Most likely, you want to use scrollViews instead.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the scrollbar.</param>
    /// <param name="value">The position between min and max.</param>
    /// <param name="size">How much can we see?</param>
    /// <param name="topValue">The value at the top of the scrollbar.</param>
    /// <param name="bottomValue">The value at the bottom of the scrollbar.</param>
    /// <param name="style">The style to use for the scrollbar background. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <returns>
    ///   <para>The modified value. This can be changed by the user by dragging the scrollbar, or clicking the arrows at the end.</para>
    /// </returns>
    public static float VerticalScrollbar(Rect position, float value, float size, float topValue, float bottomValue, GUIStyle style)
    {
      return GUI.Scroller(position, value, size, topValue, bottomValue, style, GUI.skin.GetStyle(style.name + "thumb"), GUI.skin.GetStyle(style.name + "upbutton"), GUI.skin.GetStyle(style.name + "downbutton"), false);
    }

    internal static float Scroller(Rect position, float value, float size, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUIStyle leftButton, GUIStyle rightButton, bool horiz)
    {
      GUIUtility.CheckOnGUI();
      int controlId = GUIUtility.GetControlID(GUI.s_SliderHash, FocusType.Passive, position);
      Rect position1;
      Rect rect1;
      Rect rect2;
      if (horiz)
      {
        position1 = new Rect(position.x + leftButton.fixedWidth, position.y, position.width - leftButton.fixedWidth - rightButton.fixedWidth, position.height);
        rect1 = new Rect(position.x, position.y, leftButton.fixedWidth, position.height);
        rect2 = new Rect(position.xMax - rightButton.fixedWidth, position.y, rightButton.fixedWidth, position.height);
      }
      else
      {
        position1 = new Rect(position.x, position.y + leftButton.fixedHeight, position.width, position.height - leftButton.fixedHeight - rightButton.fixedHeight);
        rect1 = new Rect(position.x, position.y, position.width, leftButton.fixedHeight);
        rect2 = new Rect(position.x, position.yMax - rightButton.fixedHeight, position.width, rightButton.fixedHeight);
      }
      value = GUI.Slider(position1, value, size, leftValue, rightValue, slider, thumb, horiz, controlId);
      bool flag = false;
      if (Event.current.type == EventType.MouseUp)
        flag = true;
      if (GUI.ScrollerRepeatButton(controlId, rect1, leftButton))
        value -= GUI.s_ScrollStepSize * ((double) leftValue >= (double) rightValue ? -1f : 1f);
      if (GUI.ScrollerRepeatButton(controlId, rect2, rightButton))
        value += GUI.s_ScrollStepSize * ((double) leftValue >= (double) rightValue ? -1f : 1f);
      if (flag && Event.current.type == EventType.Used)
        GUI.s_ScrollControlId = 0;
      value = (double) leftValue >= (double) rightValue ? Mathf.Clamp(value, rightValue, leftValue - size) : Mathf.Clamp(value, leftValue, rightValue - size);
      return value;
    }

    public static void BeginClip(Rect position, Vector2 scrollOffset, Vector2 renderOffset, bool resetOffset)
    {
      GUIUtility.CheckOnGUI();
      GUIClip.Push(position, scrollOffset, renderOffset, resetOffset);
    }

    /// <summary>
    ///   <para>Begin a group. Must be matched with a call to EndGroup.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the group.</param>
    /// <param name="text">Text to display on the group.</param>
    /// <param name="image">Texture to display on the group.</param>
    /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
    /// <param name="style">The style to use for the background.</param>
    public static void BeginGroup(Rect position)
    {
      GUI.BeginGroup(position, GUIContent.none, GUIStyle.none);
    }

    /// <summary>
    ///   <para>Begin a group. Must be matched with a call to EndGroup.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the group.</param>
    /// <param name="text">Text to display on the group.</param>
    /// <param name="image">Texture to display on the group.</param>
    /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
    /// <param name="style">The style to use for the background.</param>
    public static void BeginGroup(Rect position, string text)
    {
      GUI.BeginGroup(position, GUIContent.Temp(text), GUIStyle.none);
    }

    /// <summary>
    ///   <para>Begin a group. Must be matched with a call to EndGroup.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the group.</param>
    /// <param name="text">Text to display on the group.</param>
    /// <param name="image">Texture to display on the group.</param>
    /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
    /// <param name="style">The style to use for the background.</param>
    public static void BeginGroup(Rect position, Texture image)
    {
      GUI.BeginGroup(position, GUIContent.Temp(image), GUIStyle.none);
    }

    /// <summary>
    ///   <para>Begin a group. Must be matched with a call to EndGroup.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the group.</param>
    /// <param name="text">Text to display on the group.</param>
    /// <param name="image">Texture to display on the group.</param>
    /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
    /// <param name="style">The style to use for the background.</param>
    public static void BeginGroup(Rect position, GUIContent content)
    {
      GUI.BeginGroup(position, content, GUIStyle.none);
    }

    /// <summary>
    ///   <para>Begin a group. Must be matched with a call to EndGroup.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the group.</param>
    /// <param name="text">Text to display on the group.</param>
    /// <param name="image">Texture to display on the group.</param>
    /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
    /// <param name="style">The style to use for the background.</param>
    public static void BeginGroup(Rect position, GUIStyle style)
    {
      GUI.BeginGroup(position, GUIContent.none, style);
    }

    /// <summary>
    ///   <para>Begin a group. Must be matched with a call to EndGroup.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the group.</param>
    /// <param name="text">Text to display on the group.</param>
    /// <param name="image">Texture to display on the group.</param>
    /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
    /// <param name="style">The style to use for the background.</param>
    public static void BeginGroup(Rect position, string text, GUIStyle style)
    {
      GUI.BeginGroup(position, GUIContent.Temp(text), style);
    }

    /// <summary>
    ///   <para>Begin a group. Must be matched with a call to EndGroup.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the group.</param>
    /// <param name="text">Text to display on the group.</param>
    /// <param name="image">Texture to display on the group.</param>
    /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
    /// <param name="style">The style to use for the background.</param>
    public static void BeginGroup(Rect position, Texture image, GUIStyle style)
    {
      GUI.BeginGroup(position, GUIContent.Temp(image), style);
    }

    /// <summary>
    ///   <para>Begin a group. Must be matched with a call to EndGroup.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the group.</param>
    /// <param name="text">Text to display on the group.</param>
    /// <param name="image">Texture to display on the group.</param>
    /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
    /// <param name="style">The style to use for the background.</param>
    public static void BeginGroup(Rect position, GUIContent content, GUIStyle style)
    {
      GUI.BeginGroup(position, content, style, Vector2.zero);
    }

    internal static void BeginGroup(Rect position, GUIContent content, GUIStyle style, Vector2 scrollOffset)
    {
      GUIUtility.CheckOnGUI();
      int controlId = GUIUtility.GetControlID(GUI.s_BeginGroupHash, FocusType.Passive);
      if (content != GUIContent.none || style != GUIStyle.none)
      {
        if (Event.current.type == EventType.Repaint)
          style.Draw(position, content, controlId);
        else if (position.Contains(Event.current.mousePosition))
          GUIUtility.mouseUsed = true;
      }
      GUIClip.Push(position, scrollOffset, Vector2.zero, false);
    }

    /// <summary>
    ///   <para>End a group.</para>
    /// </summary>
    public static void EndGroup()
    {
      GUIUtility.CheckOnGUI();
      GUIClip.Internal_Pop();
    }

    public static void BeginClip(Rect position)
    {
      GUIUtility.CheckOnGUI();
      GUIClip.Push(position, Vector2.zero, Vector2.zero, false);
    }

    public static void EndClip()
    {
      GUIUtility.CheckOnGUI();
      GUIClip.Pop();
    }

    /// <summary>
    ///   <para>Begin a scrolling view inside your GUI.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the ScrollView.</param>
    /// <param name="scrollPosition">The pixel distance that the view is scrolled in the X and Y directions.</param>
    /// <param name="viewRect">The rectangle used inside the scrollview.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when viewRect is wider than position.</param>
    /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when viewRect is taller than position.</param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect)
    {
      return GUI.BeginScrollView(position, scrollPosition, viewRect, false, false, GUI.skin.horizontalScrollbar, GUI.skin.verticalScrollbar, GUI.skin.scrollView);
    }

    /// <summary>
    ///   <para>Begin a scrolling view inside your GUI.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the ScrollView.</param>
    /// <param name="scrollPosition">The pixel distance that the view is scrolled in the X and Y directions.</param>
    /// <param name="viewRect">The rectangle used inside the scrollview.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when viewRect is wider than position.</param>
    /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when viewRect is taller than position.</param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical)
    {
      return GUI.BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical, GUI.skin.horizontalScrollbar, GUI.skin.verticalScrollbar, GUI.skin.scrollView);
    }

    /// <summary>
    ///   <para>Begin a scrolling view inside your GUI.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the ScrollView.</param>
    /// <param name="scrollPosition">The pixel distance that the view is scrolled in the X and Y directions.</param>
    /// <param name="viewRect">The rectangle used inside the scrollview.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when viewRect is wider than position.</param>
    /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when viewRect is taller than position.</param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar)
    {
      return GUI.BeginScrollView(position, scrollPosition, viewRect, false, false, horizontalScrollbar, verticalScrollbar, GUI.skin.scrollView);
    }

    /// <summary>
    ///   <para>Begin a scrolling view inside your GUI.</para>
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the ScrollView.</param>
    /// <param name="scrollPosition">The pixel distance that the view is scrolled in the X and Y directions.</param>
    /// <param name="viewRect">The rectangle used inside the scrollview.</param>
    /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
    /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
    /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when viewRect is wider than position.</param>
    /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when viewRect is taller than position.</param>
    /// <returns>
    ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
    /// </returns>
    public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar)
    {
      return GUI.BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, GUI.skin.scrollView);
    }

    protected static Vector2 DoBeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background)
    {
      return GUI.BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, background);
    }

    internal static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background)
    {
      GUIUtility.CheckOnGUI();
      if (Event.current.type == EventType.DragUpdated && position.Contains(Event.current.mousePosition))
      {
        if ((double) Mathf.Abs(Event.current.mousePosition.y - position.y) < 8.0)
        {
          scrollPosition.y -= 16f;
          GUI.InternalRepaintEditorWindow();
        }
        else if ((double) Mathf.Abs(Event.current.mousePosition.y - position.yMax) < 8.0)
        {
          scrollPosition.y += 16f;
          GUI.InternalRepaintEditorWindow();
        }
      }
      ScrollViewState stateObject = (ScrollViewState) GUIUtility.GetStateObject(typeof (ScrollViewState), GUIUtility.GetControlID(GUI.s_ScrollviewHash, FocusType.Passive));
      if (stateObject.apply)
      {
        scrollPosition = stateObject.scrollPosition;
        stateObject.apply = false;
      }
      stateObject.position = position;
      stateObject.scrollPosition = scrollPosition;
      stateObject.visibleRect = stateObject.viewRect = viewRect;
      stateObject.visibleRect.width = position.width;
      stateObject.visibleRect.height = position.height;
      GUI.s_ScrollViewStates.Push((object) stateObject);
      Rect screenRect = new Rect(position);
      switch (Event.current.type)
      {
        case EventType.Layout:
          GUIUtility.GetControlID(GUI.s_SliderHash, FocusType.Passive);
          GUIUtility.GetControlID(GUI.s_RepeatButtonHash, FocusType.Passive);
          GUIUtility.GetControlID(GUI.s_RepeatButtonHash, FocusType.Passive);
          GUIUtility.GetControlID(GUI.s_SliderHash, FocusType.Passive);
          GUIUtility.GetControlID(GUI.s_RepeatButtonHash, FocusType.Passive);
          GUIUtility.GetControlID(GUI.s_RepeatButtonHash, FocusType.Passive);
          goto case EventType.Used;
        case EventType.Used:
          GUIClip.Push(screenRect, new Vector2(Mathf.Round(-scrollPosition.x - viewRect.x), Mathf.Round(-scrollPosition.y - viewRect.y)), Vector2.zero, false);
          return scrollPosition;
        default:
          bool flag1 = alwaysShowVertical;
          bool flag2 = alwaysShowHorizontal;
          if (flag2 || (double) viewRect.width > (double) screenRect.width)
          {
            stateObject.visibleRect.height = position.height - horizontalScrollbar.fixedHeight + (float) horizontalScrollbar.margin.top;
            screenRect.height -= horizontalScrollbar.fixedHeight + (float) horizontalScrollbar.margin.top;
            flag2 = true;
          }
          if (flag1 || (double) viewRect.height > (double) screenRect.height)
          {
            stateObject.visibleRect.width = position.width - verticalScrollbar.fixedWidth + (float) verticalScrollbar.margin.left;
            screenRect.width -= verticalScrollbar.fixedWidth + (float) verticalScrollbar.margin.left;
            flag1 = true;
            if (!flag2 && (double) viewRect.width > (double) screenRect.width)
            {
              stateObject.visibleRect.height = position.height - horizontalScrollbar.fixedHeight + (float) horizontalScrollbar.margin.top;
              screenRect.height -= horizontalScrollbar.fixedHeight + (float) horizontalScrollbar.margin.top;
              flag2 = true;
            }
          }
          if (Event.current.type == EventType.Repaint && background != GUIStyle.none)
            background.Draw(position, position.Contains(Event.current.mousePosition), false, flag2 && flag1, false);
          if (flag2 && horizontalScrollbar != GUIStyle.none)
          {
            scrollPosition.x = GUI.HorizontalScrollbar(new Rect(position.x, position.yMax - horizontalScrollbar.fixedHeight, screenRect.width, horizontalScrollbar.fixedHeight), scrollPosition.x, Mathf.Min(screenRect.width, viewRect.width), 0.0f, viewRect.width, horizontalScrollbar);
          }
          else
          {
            GUIUtility.GetControlID(GUI.s_SliderHash, FocusType.Passive);
            GUIUtility.GetControlID(GUI.s_RepeatButtonHash, FocusType.Passive);
            GUIUtility.GetControlID(GUI.s_RepeatButtonHash, FocusType.Passive);
            scrollPosition.x = horizontalScrollbar == GUIStyle.none ? Mathf.Clamp(scrollPosition.x, 0.0f, Mathf.Max(viewRect.width - position.width, 0.0f)) : 0.0f;
          }
          if (flag1 && verticalScrollbar != GUIStyle.none)
          {
            scrollPosition.y = GUI.VerticalScrollbar(new Rect(screenRect.xMax + (float) verticalScrollbar.margin.left, screenRect.y, verticalScrollbar.fixedWidth, screenRect.height), scrollPosition.y, Mathf.Min(screenRect.height, viewRect.height), 0.0f, viewRect.height, verticalScrollbar);
            goto case EventType.Used;
          }
          else
          {
            GUIUtility.GetControlID(GUI.s_SliderHash, FocusType.Passive);
            GUIUtility.GetControlID(GUI.s_RepeatButtonHash, FocusType.Passive);
            GUIUtility.GetControlID(GUI.s_RepeatButtonHash, FocusType.Passive);
            scrollPosition.y = verticalScrollbar == GUIStyle.none ? Mathf.Clamp(scrollPosition.y, 0.0f, Mathf.Max(viewRect.height - position.height, 0.0f)) : 0.0f;
            goto case EventType.Used;
          }
      }
    }

    /// <summary>
    ///   <para>Ends a scrollview started with a call to BeginScrollView.</para>
    /// </summary>
    /// <param name="handleScrollWheel"></param>
    public static void EndScrollView()
    {
      GUI.EndScrollView(true);
    }

    /// <summary>
    ///   <para>Ends a scrollview started with a call to BeginScrollView.</para>
    /// </summary>
    /// <param name="handleScrollWheel"></param>
    public static void EndScrollView(bool handleScrollWheel)
    {
      GUIUtility.CheckOnGUI();
      ScrollViewState scrollViewState = (ScrollViewState) GUI.s_ScrollViewStates.Peek();
      GUIClip.Pop();
      GUI.s_ScrollViewStates.Pop();
      if (!handleScrollWheel || Event.current.type != EventType.ScrollWheel || !scrollViewState.position.Contains(Event.current.mousePosition))
        return;
      scrollViewState.scrollPosition.x = Mathf.Clamp(scrollViewState.scrollPosition.x + Event.current.delta.x * 20f, 0.0f, scrollViewState.viewRect.width - scrollViewState.visibleRect.width);
      scrollViewState.scrollPosition.y = Mathf.Clamp(scrollViewState.scrollPosition.y + Event.current.delta.y * 20f, 0.0f, scrollViewState.viewRect.height - scrollViewState.visibleRect.height);
      if ((double) scrollViewState.scrollPosition.x < 0.0)
        scrollViewState.scrollPosition.x = 0.0f;
      if ((double) scrollViewState.scrollPosition.y < 0.0)
        scrollViewState.scrollPosition.y = 0.0f;
      scrollViewState.apply = true;
      Event.current.Use();
    }

    internal static ScrollViewState GetTopScrollView()
    {
      if (GUI.s_ScrollViewStates.Count != 0)
        return (ScrollViewState) GUI.s_ScrollViewStates.Peek();
      return (ScrollViewState) null;
    }

    /// <summary>
    ///   <para>Scrolls all enclosing scrollviews so they try to make position visible.</para>
    /// </summary>
    /// <param name="position"></param>
    public static void ScrollTo(Rect position)
    {
      GUI.GetTopScrollView()?.ScrollTo(position);
    }

    public static bool ScrollTowards(Rect position, float maxDelta)
    {
      ScrollViewState topScrollView = GUI.GetTopScrollView();
      if (topScrollView == null)
        return false;
      return topScrollView.ScrollTowards(position, maxDelta);
    }

    public static Rect Window(int id, Rect clientRect, GUI.WindowFunction func, string text)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoWindow(id, clientRect, func, GUIContent.Temp(text), GUI.skin.window, GUI.skin, true);
    }

    public static Rect Window(int id, Rect clientRect, GUI.WindowFunction func, Texture image)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoWindow(id, clientRect, func, GUIContent.Temp(image), GUI.skin.window, GUI.skin, true);
    }

    public static Rect Window(int id, Rect clientRect, GUI.WindowFunction func, GUIContent content)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoWindow(id, clientRect, func, content, GUI.skin.window, GUI.skin, true);
    }

    public static Rect Window(int id, Rect clientRect, GUI.WindowFunction func, string text, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoWindow(id, clientRect, func, GUIContent.Temp(text), style, GUI.skin, true);
    }

    public static Rect Window(int id, Rect clientRect, GUI.WindowFunction func, Texture image, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoWindow(id, clientRect, func, GUIContent.Temp(image), style, GUI.skin, true);
    }

    public static Rect Window(int id, Rect clientRect, GUI.WindowFunction func, GUIContent title, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoWindow(id, clientRect, func, title, style, GUI.skin, true);
    }

    public static Rect ModalWindow(int id, Rect clientRect, GUI.WindowFunction func, string text)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoModalWindow(id, clientRect, func, GUIContent.Temp(text), GUI.skin.window, GUI.skin);
    }

    public static Rect ModalWindow(int id, Rect clientRect, GUI.WindowFunction func, Texture image)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoModalWindow(id, clientRect, func, GUIContent.Temp(image), GUI.skin.window, GUI.skin);
    }

    public static Rect ModalWindow(int id, Rect clientRect, GUI.WindowFunction func, GUIContent content)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoModalWindow(id, clientRect, func, content, GUI.skin.window, GUI.skin);
    }

    public static Rect ModalWindow(int id, Rect clientRect, GUI.WindowFunction func, string text, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoModalWindow(id, clientRect, func, GUIContent.Temp(text), style, GUI.skin);
    }

    public static Rect ModalWindow(int id, Rect clientRect, GUI.WindowFunction func, Texture image, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoModalWindow(id, clientRect, func, GUIContent.Temp(image), style, GUI.skin);
    }

    public static Rect ModalWindow(int id, Rect clientRect, GUI.WindowFunction func, GUIContent content, GUIStyle style)
    {
      GUIUtility.CheckOnGUI();
      return GUI.DoModalWindow(id, clientRect, func, content, style, GUI.skin);
    }

    private static Rect DoWindow(int id, Rect clientRect, GUI.WindowFunction func, GUIContent title, GUIStyle style, GUISkin skin, bool forceRectOnLayout)
    {
      return GUI.Internal_DoWindow(id, GUIUtility.s_OriginalID, clientRect, func, title, style, skin, forceRectOnLayout);
    }

    private static Rect DoModalWindow(int id, Rect clientRect, GUI.WindowFunction func, GUIContent content, GUIStyle style, GUISkin skin)
    {
      return GUI.Internal_DoModalWindow(id, GUIUtility.s_OriginalID, clientRect, func, content, style, skin);
    }

    [RequiredByNativeCode]
    internal static void CallWindowDelegate(GUI.WindowFunction func, int id, int instanceID, GUISkin _skin, int forceRect, float width, float height, GUIStyle style)
    {
      GUILayoutUtility.SelectIDList(id, true);
      GUISkin skin = GUI.skin;
      if (Event.current.type == EventType.Layout)
      {
        if (forceRect != 0)
        {
          GUILayoutOption[] options = new GUILayoutOption[2]
          {
            GUILayout.Width(width),
            GUILayout.Height(height)
          };
          GUILayoutUtility.BeginWindow(id, style, options);
        }
        else
          GUILayoutUtility.BeginWindow(id, style, (GUILayoutOption[]) null);
      }
      else
        GUILayoutUtility.BeginWindow(id, GUIStyle.none, (GUILayoutOption[]) null);
      GUI.skin = _skin;
      func(id);
      if (Event.current.type == EventType.Layout)
        GUILayoutUtility.Layout();
      GUI.skin = skin;
    }

    /// <summary>
    ///   <para>If you want to have the entire window background to act as a drag area, use the version of DragWindow that takes no parameters and put it at the end of the window function.</para>
    /// </summary>
    public static void DragWindow()
    {
      GUI.DragWindow(new Rect(0.0f, 0.0f, 10000f, 10000f));
    }

    internal static void BeginWindows(int skinMode, int editorWindowInstanceID)
    {
      GUILayoutGroup topLevel = GUILayoutUtility.current.topLevel;
      GenericStack layoutGroups = GUILayoutUtility.current.layoutGroups;
      GUILayoutGroup windows = GUILayoutUtility.current.windows;
      Matrix4x4 matrix = GUI.matrix;
      GUI.Internal_BeginWindows();
      GUI.matrix = matrix;
      GUILayoutUtility.current.topLevel = topLevel;
      GUILayoutUtility.current.layoutGroups = layoutGroups;
      GUILayoutUtility.current.windows = windows;
    }

    internal static void EndWindows()
    {
      GUILayoutGroup topLevel = GUILayoutUtility.current.topLevel;
      GenericStack layoutGroups = GUILayoutUtility.current.layoutGroups;
      GUILayoutGroup windows = GUILayoutUtility.current.windows;
      GUI.Internal_EndWindows();
      GUILayoutUtility.current.topLevel = topLevel;
      GUILayoutUtility.current.layoutGroups = layoutGroups;
      GUILayoutUtility.current.windows = windows;
    }

    /// <summary>
    ///   <para>Determines how toolbar button size is calculated.</para>
    /// </summary>
    public enum ToolbarButtonSize
    {
      /// <summary>
      ///   <para>Calculates the button size by dividing the available width by the number of buttons. The minimum size is the maximum content width.</para>
      /// </summary>
      Fixed,
      /// <summary>
      ///   <para>The width of each toolbar button is calculated based on the width of its content.</para>
      /// </summary>
      FitToContents,
    }

    /// <summary>
    ///   <para>Callback to draw GUI within a window (used with GUI.Window).</para>
    /// </summary>
    /// <param name="id"></param>
    public delegate void WindowFunction(int id);

    public abstract class Scope : IDisposable
    {
      private bool m_Disposed;

      protected abstract void CloseScope();

      ~Scope()
      {
        if (this.m_Disposed)
          return;
        Debug.LogError((object) "Scope was not disposed! You should use the 'using' keyword or manually call Dispose.");
      }

      public void Dispose()
      {
        if (this.m_Disposed)
          return;
        this.m_Disposed = true;
        if (GUIUtility.guiIsExiting)
          return;
        this.CloseScope();
      }
    }

    /// <summary>
    ///   <para>Disposable helper class for managing BeginGroup / EndGroup.</para>
    /// </summary>
    public class GroupScope : GUI.Scope
    {
      /// <summary>
      ///   <para>Create a new GroupScope and begin the corresponding group.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the group.</param>
      /// <param name="text">Text to display on the group.</param>
      /// <param name="image">Texture to display on the group.</param>
      /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
      /// <param name="style">The style to use for the background.</param>
      public GroupScope(Rect position)
      {
        GUI.BeginGroup(position);
      }

      /// <summary>
      ///   <para>Create a new GroupScope and begin the corresponding group.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the group.</param>
      /// <param name="text">Text to display on the group.</param>
      /// <param name="image">Texture to display on the group.</param>
      /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
      /// <param name="style">The style to use for the background.</param>
      public GroupScope(Rect position, string text)
      {
        GUI.BeginGroup(position, text);
      }

      /// <summary>
      ///   <para>Create a new GroupScope and begin the corresponding group.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the group.</param>
      /// <param name="text">Text to display on the group.</param>
      /// <param name="image">Texture to display on the group.</param>
      /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
      /// <param name="style">The style to use for the background.</param>
      public GroupScope(Rect position, Texture image)
      {
        GUI.BeginGroup(position, image);
      }

      /// <summary>
      ///   <para>Create a new GroupScope and begin the corresponding group.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the group.</param>
      /// <param name="text">Text to display on the group.</param>
      /// <param name="image">Texture to display on the group.</param>
      /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
      /// <param name="style">The style to use for the background.</param>
      public GroupScope(Rect position, GUIContent content)
      {
        GUI.BeginGroup(position, content);
      }

      /// <summary>
      ///   <para>Create a new GroupScope and begin the corresponding group.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the group.</param>
      /// <param name="text">Text to display on the group.</param>
      /// <param name="image">Texture to display on the group.</param>
      /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
      /// <param name="style">The style to use for the background.</param>
      public GroupScope(Rect position, GUIStyle style)
      {
        GUI.BeginGroup(position, style);
      }

      /// <summary>
      ///   <para>Create a new GroupScope and begin the corresponding group.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the group.</param>
      /// <param name="text">Text to display on the group.</param>
      /// <param name="image">Texture to display on the group.</param>
      /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
      /// <param name="style">The style to use for the background.</param>
      public GroupScope(Rect position, string text, GUIStyle style)
      {
        GUI.BeginGroup(position, text, style);
      }

      /// <summary>
      ///   <para>Create a new GroupScope and begin the corresponding group.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the group.</param>
      /// <param name="text">Text to display on the group.</param>
      /// <param name="image">Texture to display on the group.</param>
      /// <param name="content">Text, image and tooltip for this group. If supplied, any mouse clicks are "captured" by the group and not If left out, no background is rendered, and mouse clicks are passed.</param>
      /// <param name="style">The style to use for the background.</param>
      public GroupScope(Rect position, Texture image, GUIStyle style)
      {
        GUI.BeginGroup(position, image, style);
      }

      protected override void CloseScope()
      {
        GUI.EndGroup();
      }
    }

    /// <summary>
    ///   <para>Disposable helper class for managing BeginScrollView / EndScrollView.</para>
    /// </summary>
    public class ScrollViewScope : GUI.Scope
    {
      /// <summary>
      ///   <para>Create a new ScrollViewScope and begin the corresponding ScrollView.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the ScrollView.</param>
      /// <param name="scrollPosition">The pixel distance that the view is scrolled in the X and Y directions.</param>
      /// <param name="viewRect">The rectangle used inside the scrollview.</param>
      /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when clientRect is wider than position.</param>
      /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when clientRect is taller than position.</param>
      /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
      /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
      public ScrollViewScope(Rect position, Vector2 scrollPosition, Rect viewRect)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUI.BeginScrollView(position, scrollPosition, viewRect);
      }

      /// <summary>
      ///   <para>Create a new ScrollViewScope and begin the corresponding ScrollView.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the ScrollView.</param>
      /// <param name="scrollPosition">The pixel distance that the view is scrolled in the X and Y directions.</param>
      /// <param name="viewRect">The rectangle used inside the scrollview.</param>
      /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when clientRect is wider than position.</param>
      /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when clientRect is taller than position.</param>
      /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
      /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
      public ScrollViewScope(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUI.BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical);
      }

      /// <summary>
      ///   <para>Create a new ScrollViewScope and begin the corresponding ScrollView.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the ScrollView.</param>
      /// <param name="scrollPosition">The pixel distance that the view is scrolled in the X and Y directions.</param>
      /// <param name="viewRect">The rectangle used inside the scrollview.</param>
      /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when clientRect is wider than position.</param>
      /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when clientRect is taller than position.</param>
      /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
      /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
      public ScrollViewScope(Rect position, Vector2 scrollPosition, Rect viewRect, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUI.BeginScrollView(position, scrollPosition, viewRect, horizontalScrollbar, verticalScrollbar);
      }

      /// <summary>
      ///   <para>Create a new ScrollViewScope and begin the corresponding ScrollView.</para>
      /// </summary>
      /// <param name="position">Rectangle on the screen to use for the ScrollView.</param>
      /// <param name="scrollPosition">The pixel distance that the view is scrolled in the X and Y directions.</param>
      /// <param name="viewRect">The rectangle used inside the scrollview.</param>
      /// <param name="alwaysShowHorizontal">Optional parameter to always show the horizontal scrollbar. If false or left out, it is only shown when clientRect is wider than position.</param>
      /// <param name="alwaysShowVertical">Optional parameter to always show the vertical scrollbar. If false or left out, it is only shown when clientRect is taller than position.</param>
      /// <param name="horizontalScrollbar">Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar style from the current GUISkin is used.</param>
      /// <param name="verticalScrollbar">Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar style from the current GUISkin is used.</param>
      public ScrollViewScope(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUI.BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar);
      }

      internal ScrollViewScope(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background)
      {
        this.handleScrollWheel = true;
        this.scrollPosition = GUI.BeginScrollView(position, scrollPosition, viewRect, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, background);
      }

      /// <summary>
      ///   <para>The modified scrollPosition. Feed this back into the variable you pass in, as shown in the example.</para>
      /// </summary>
      public Vector2 scrollPosition { get; private set; }

      /// <summary>
      ///   <para>Whether this ScrollView should handle scroll wheel events. (default: true).</para>
      /// </summary>
      public bool handleScrollWheel { get; set; }

      protected override void CloseScope()
      {
        GUI.EndScrollView(this.handleScrollWheel);
      }
    }

    public class ClipScope : GUI.Scope
    {
      public ClipScope(Rect position)
      {
        GUI.BeginClip(position);
      }

      protected override void CloseScope()
      {
        GUI.EndClip();
      }
    }
  }
}
