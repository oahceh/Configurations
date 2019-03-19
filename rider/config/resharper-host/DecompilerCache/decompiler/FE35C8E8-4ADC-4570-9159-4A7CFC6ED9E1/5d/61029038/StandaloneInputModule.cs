// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.StandaloneInputModule
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE35C8E8-4ADC-4570-9159-4A7CFC6ED9E1
// Assembly location: D:\Unity\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using UnityEditor;
using UnityEngine.Serialization;

namespace UnityEngine.EventSystems
{
  /// <summary>
  ///   <para>A BaseInputModule designed for mouse  keyboard  controller input.</para>
  /// </summary>
  [AddComponentMenu("Event/Standalone Input Module")]
  public class StandaloneInputModule : PointerInputModule
  {
    private int m_ConsecutiveMoveCount = 0;
    [SerializeField]
    private string m_HorizontalAxis = "Horizontal";
    [SerializeField]
    private string m_VerticalAxis = "Vertical";
    [SerializeField]
    private string m_SubmitButton = "Submit";
    [SerializeField]
    private string m_CancelButton = "Cancel";
    [SerializeField]
    private float m_InputActionsPerSecond = 10f;
    [SerializeField]
    private float m_RepeatDelay = 0.5f;
    private float m_PrevActionTime;
    private Vector2 m_LastMoveVector;
    private Vector2 m_LastMousePosition;
    private Vector2 m_MousePosition;
    private GameObject m_CurrentFocusedGameObject;
    private PointerEventData m_InputPointerEvent;
    [SerializeField]
    [FormerlySerializedAs("m_AllowActivationOnMobileDevice")]
    private bool m_ForceModuleActive;

    protected StandaloneInputModule()
    {
    }

    [Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", false)]
    public StandaloneInputModule.InputMode inputMode
    {
      get
      {
        return StandaloneInputModule.InputMode.Mouse;
      }
    }

    /// <summary>
    ///   <para>Is this module allowed to be activated if you are on mobile.</para>
    /// </summary>
    [Obsolete("allowActivationOnMobileDevice has been deprecated. Use forceModuleActive instead (UnityUpgradable) -> forceModuleActive")]
    public bool allowActivationOnMobileDevice
    {
      get
      {
        return this.m_ForceModuleActive;
      }
      set
      {
        this.m_ForceModuleActive = value;
      }
    }

    /// <summary>
    ///   <para>Force this module to be active.</para>
    /// </summary>
    public bool forceModuleActive
    {
      get
      {
        return this.m_ForceModuleActive;
      }
      set
      {
        this.m_ForceModuleActive = value;
      }
    }

    /// <summary>
    ///   <para>Number of keyboard / controller inputs allowed per second.</para>
    /// </summary>
    public float inputActionsPerSecond
    {
      get
      {
        return this.m_InputActionsPerSecond;
      }
      set
      {
        this.m_InputActionsPerSecond = value;
      }
    }

    /// <summary>
    ///   <para>Delay in seconds before the input actions per second repeat rate takes effect.</para>
    /// </summary>
    public float repeatDelay
    {
      get
      {
        return this.m_RepeatDelay;
      }
      set
      {
        this.m_RepeatDelay = value;
      }
    }

    /// <summary>
    ///   <para>Input manager name for the horizontal axis button.</para>
    /// </summary>
    public string horizontalAxis
    {
      get
      {
        return this.m_HorizontalAxis;
      }
      set
      {
        this.m_HorizontalAxis = value;
      }
    }

    /// <summary>
    ///   <para>Input manager name for the vertical axis.</para>
    /// </summary>
    public string verticalAxis
    {
      get
      {
        return this.m_VerticalAxis;
      }
      set
      {
        this.m_VerticalAxis = value;
      }
    }

    /// <summary>
    ///   <para>Maximum number of input events handled per second.</para>
    /// </summary>
    public string submitButton
    {
      get
      {
        return this.m_SubmitButton;
      }
      set
      {
        this.m_SubmitButton = value;
      }
    }

    /// <summary>
    ///   <para>Input manager name for the 'cancel' button.</para>
    /// </summary>
    public string cancelButton
    {
      get
      {
        return this.m_CancelButton;
      }
      set
      {
        this.m_CancelButton = value;
      }
    }

    private bool ShouldIgnoreEventsOnNoFocus()
    {
      switch (SystemInfo.operatingSystemFamily)
      {
        case OperatingSystemFamily.MacOSX:
        case OperatingSystemFamily.Windows:
        case OperatingSystemFamily.Linux:
          return !EditorApplication.isRemoteConnected;
        default:
          return false;
      }
    }

    /// <summary>
    ///   <para>See BaseInputModule.</para>
    /// </summary>
    public override void UpdateModule()
    {
      if (!this.eventSystem.isFocused && this.ShouldIgnoreEventsOnNoFocus())
      {
        if (this.m_InputPointerEvent != null && (UnityEngine.Object) this.m_InputPointerEvent.pointerDrag != (UnityEngine.Object) null && this.m_InputPointerEvent.dragging)
          ExecuteEvents.Execute<IEndDragHandler>(this.m_InputPointerEvent.pointerDrag, (BaseEventData) this.m_InputPointerEvent, ExecuteEvents.endDragHandler);
        this.m_InputPointerEvent = (PointerEventData) null;
      }
      else
      {
        this.m_LastMousePosition = this.m_MousePosition;
        this.m_MousePosition = this.input.mousePosition;
      }
    }

    /// <summary>
    ///   <para>See BaseInputModule.</para>
    /// </summary>
    /// <returns>
    ///   <para>Supported.</para>
    /// </returns>
    public override bool IsModuleSupported()
    {
      return this.m_ForceModuleActive || this.input.mousePresent || this.input.touchSupported;
    }

    /// <summary>
    ///   <para>See BaseInputModule.</para>
    /// </summary>
    /// <returns>
    ///   <para>Should activate.</para>
    /// </returns>
    public override bool ShouldActivateModule()
    {
      if (!base.ShouldActivateModule())
        return false;
      bool flag = this.m_ForceModuleActive | this.input.GetButtonDown(this.m_SubmitButton) | this.input.GetButtonDown(this.m_CancelButton) | !Mathf.Approximately(this.input.GetAxisRaw(this.m_HorizontalAxis), 0.0f) | !Mathf.Approximately(this.input.GetAxisRaw(this.m_VerticalAxis), 0.0f) | (double) (this.m_MousePosition - this.m_LastMousePosition).sqrMagnitude > 0.0 | this.input.GetMouseButtonDown(0);
      if (this.input.touchCount > 0)
        flag = true;
      return flag;
    }

    /// <summary>
    ///   <para>See BaseInputModule.</para>
    /// </summary>
    public override void ActivateModule()
    {
      if (!this.eventSystem.isFocused && this.ShouldIgnoreEventsOnNoFocus())
        return;
      base.ActivateModule();
      this.m_MousePosition = this.input.mousePosition;
      this.m_LastMousePosition = this.input.mousePosition;
      GameObject selectedGameObject = this.eventSystem.currentSelectedGameObject;
      if ((UnityEngine.Object) selectedGameObject == (UnityEngine.Object) null)
        selectedGameObject = this.eventSystem.firstSelectedGameObject;
      this.eventSystem.SetSelectedGameObject(selectedGameObject, this.GetBaseEventData());
    }

    /// <summary>
    ///   <para>See BaseInputModule.</para>
    /// </summary>
    public override void DeactivateModule()
    {
      base.DeactivateModule();
      this.ClearSelection();
    }

    /// <summary>
    ///   <para>See BaseInputModule.</para>
    /// </summary>
    public override void Process()
    {
      if (!this.eventSystem.isFocused && this.ShouldIgnoreEventsOnNoFocus())
        return;
      bool selectedObject = this.SendUpdateEventToSelectedObject();
      if (this.eventSystem.sendNavigationEvents)
      {
        if (!selectedObject)
          selectedObject |= this.SendMoveEventToSelectedObject();
        if (!selectedObject)
          this.SendSubmitEventToSelectedObject();
      }
      if (this.ProcessTouchEvents() || !this.input.mousePresent)
        return;
      this.ProcessMouseEvent();
    }

    private bool ProcessTouchEvents()
    {
      for (int index = 0; index < this.input.touchCount; ++index)
      {
        Touch touch = this.input.GetTouch(index);
        if (touch.type != TouchType.Indirect)
        {
          bool pressed;
          bool released;
          PointerEventData pointerEventData = this.GetTouchPointerEventData(touch, out pressed, out released);
          this.ProcessTouchPress(pointerEventData, pressed, released);
          if (!released)
          {
            this.ProcessMove(pointerEventData);
            this.ProcessDrag(pointerEventData);
          }
          else
            this.RemovePointerData(pointerEventData);
        }
      }
      return this.input.touchCount > 0;
    }

    /// <summary>
    ///   <para>This method is called by Unity whenever a touch event is processed. Override this method with a custom implementation to process touch events yourself.</para>
    /// </summary>
    /// <param name="pointerEvent">Event data relating to the touch event, such as position and ID to be passed to the touch event destination object.</param>
    /// <param name="pressed">This is true for the first frame of a touch event, and false thereafter. This can therefore be used to determine the instant a touch event occurred.</param>
    /// <param name="released">This is true only for the last frame of a touch event.</param>
    protected void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
    {
      GameObject gameObject1 = pointerEvent.pointerCurrentRaycast.gameObject;
      if (pressed)
      {
        pointerEvent.eligibleForClick = true;
        pointerEvent.delta = Vector2.zero;
        pointerEvent.dragging = false;
        pointerEvent.useDragThreshold = true;
        pointerEvent.pressPosition = pointerEvent.position;
        pointerEvent.pointerPressRaycast = pointerEvent.pointerCurrentRaycast;
        this.DeselectIfSelectionChanged(gameObject1, (BaseEventData) pointerEvent);
        if ((UnityEngine.Object) pointerEvent.pointerEnter != (UnityEngine.Object) gameObject1)
        {
          this.HandlePointerExitAndEnter(pointerEvent, gameObject1);
          pointerEvent.pointerEnter = gameObject1;
        }
        GameObject gameObject2 = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(gameObject1, (BaseEventData) pointerEvent, ExecuteEvents.pointerDownHandler);
        if ((UnityEngine.Object) gameObject2 == (UnityEngine.Object) null)
          gameObject2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject1);
        float unscaledTime = Time.unscaledTime;
        if ((UnityEngine.Object) gameObject2 == (UnityEngine.Object) pointerEvent.lastPress)
        {
          if ((double) (unscaledTime - pointerEvent.clickTime) < 0.300000011920929)
            ++pointerEvent.clickCount;
          else
            pointerEvent.clickCount = 1;
          pointerEvent.clickTime = unscaledTime;
        }
        else
          pointerEvent.clickCount = 1;
        pointerEvent.pointerPress = gameObject2;
        pointerEvent.rawPointerPress = gameObject1;
        pointerEvent.clickTime = unscaledTime;
        pointerEvent.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(gameObject1);
        if ((UnityEngine.Object) pointerEvent.pointerDrag != (UnityEngine.Object) null)
          ExecuteEvents.Execute<IInitializePotentialDragHandler>(pointerEvent.pointerDrag, (BaseEventData) pointerEvent, ExecuteEvents.initializePotentialDrag);
        this.m_InputPointerEvent = pointerEvent;
      }
      if (!released)
        return;
      ExecuteEvents.Execute<IPointerUpHandler>(pointerEvent.pointerPress, (BaseEventData) pointerEvent, ExecuteEvents.pointerUpHandler);
      GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject1);
      if ((UnityEngine.Object) pointerEvent.pointerPress == (UnityEngine.Object) eventHandler && pointerEvent.eligibleForClick)
        ExecuteEvents.Execute<IPointerClickHandler>(pointerEvent.pointerPress, (BaseEventData) pointerEvent, ExecuteEvents.pointerClickHandler);
      else if ((UnityEngine.Object) pointerEvent.pointerDrag != (UnityEngine.Object) null && pointerEvent.dragging)
        ExecuteEvents.ExecuteHierarchy<IDropHandler>(gameObject1, (BaseEventData) pointerEvent, ExecuteEvents.dropHandler);
      pointerEvent.eligibleForClick = false;
      pointerEvent.pointerPress = (GameObject) null;
      pointerEvent.rawPointerPress = (GameObject) null;
      if ((UnityEngine.Object) pointerEvent.pointerDrag != (UnityEngine.Object) null && pointerEvent.dragging)
        ExecuteEvents.Execute<IEndDragHandler>(pointerEvent.pointerDrag, (BaseEventData) pointerEvent, ExecuteEvents.endDragHandler);
      pointerEvent.dragging = false;
      pointerEvent.pointerDrag = (GameObject) null;
      ExecuteEvents.ExecuteHierarchy<IPointerExitHandler>(pointerEvent.pointerEnter, (BaseEventData) pointerEvent, ExecuteEvents.pointerExitHandler);
      pointerEvent.pointerEnter = (GameObject) null;
      this.m_InputPointerEvent = pointerEvent;
    }

    /// <summary>
    ///   <para>Calculate and send a submit event to the current selected object.</para>
    /// </summary>
    /// <returns>
    ///   <para>If the submit event was used by the selected object.</para>
    /// </returns>
    protected bool SendSubmitEventToSelectedObject()
    {
      if ((UnityEngine.Object) this.eventSystem.currentSelectedGameObject == (UnityEngine.Object) null)
        return false;
      BaseEventData baseEventData = this.GetBaseEventData();
      if (this.input.GetButtonDown(this.m_SubmitButton))
        ExecuteEvents.Execute<ISubmitHandler>(this.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.submitHandler);
      if (this.input.GetButtonDown(this.m_CancelButton))
        ExecuteEvents.Execute<ICancelHandler>(this.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.cancelHandler);
      return baseEventData.used;
    }

    private Vector2 GetRawMoveVector()
    {
      Vector2 zero = Vector2.zero;
      zero.x = this.input.GetAxisRaw(this.m_HorizontalAxis);
      zero.y = this.input.GetAxisRaw(this.m_VerticalAxis);
      if (this.input.GetButtonDown(this.m_HorizontalAxis))
      {
        if ((double) zero.x < 0.0)
          zero.x = -1f;
        if ((double) zero.x > 0.0)
          zero.x = 1f;
      }
      if (this.input.GetButtonDown(this.m_VerticalAxis))
      {
        if ((double) zero.y < 0.0)
          zero.y = -1f;
        if ((double) zero.y > 0.0)
          zero.y = 1f;
      }
      return zero;
    }

    /// <summary>
    ///   <para>Calculate and send a move event to the current selected object.</para>
    /// </summary>
    /// <returns>
    ///   <para>If the move event was used by the selected object.</para>
    /// </returns>
    protected bool SendMoveEventToSelectedObject()
    {
      float unscaledTime = Time.unscaledTime;
      Vector2 rawMoveVector = this.GetRawMoveVector();
      if (Mathf.Approximately(rawMoveVector.x, 0.0f) && Mathf.Approximately(rawMoveVector.y, 0.0f))
      {
        this.m_ConsecutiveMoveCount = 0;
        return false;
      }
      bool flag1 = this.input.GetButtonDown(this.m_HorizontalAxis) || this.input.GetButtonDown(this.m_VerticalAxis);
      bool flag2 = (double) Vector2.Dot(rawMoveVector, this.m_LastMoveVector) > 0.0;
      if (!flag1)
        flag1 = !flag2 || this.m_ConsecutiveMoveCount != 1 ? (double) unscaledTime > (double) this.m_PrevActionTime + 1.0 / (double) this.m_InputActionsPerSecond : (double) unscaledTime > (double) this.m_PrevActionTime + (double) this.m_RepeatDelay;
      if (!flag1)
        return false;
      AxisEventData axisEventData = this.GetAxisEventData(rawMoveVector.x, rawMoveVector.y, 0.6f);
      if (axisEventData.moveDir != MoveDirection.None)
      {
        ExecuteEvents.Execute<IMoveHandler>(this.eventSystem.currentSelectedGameObject, (BaseEventData) axisEventData, ExecuteEvents.moveHandler);
        if (!flag2)
          this.m_ConsecutiveMoveCount = 0;
        ++this.m_ConsecutiveMoveCount;
        this.m_PrevActionTime = unscaledTime;
        this.m_LastMoveVector = rawMoveVector;
      }
      else
        this.m_ConsecutiveMoveCount = 0;
      return axisEventData.used;
    }

    /// <summary>
    ///   <para>Iterate through all the different mouse events.</para>
    /// </summary>
    /// <param name="id">The mouse pointer Event data id to get.</param>
    protected void ProcessMouseEvent()
    {
      this.ProcessMouseEvent(0);
    }

    [Obsolete("This method is no longer checked, overriding it with return true does nothing!")]
    protected virtual bool ForceAutoSelect()
    {
      return false;
    }

    /// <summary>
    ///   <para>Iterate through all the different mouse events.</para>
    /// </summary>
    /// <param name="id">The mouse pointer Event data id to get.</param>
    protected void ProcessMouseEvent(int id)
    {
      PointerInputModule.MouseState pointerEventData = this.GetMousePointerEventData(id);
      PointerInputModule.MouseButtonEventData eventData = pointerEventData.GetButtonState(PointerEventData.InputButton.Left).eventData;
      this.m_CurrentFocusedGameObject = eventData.buttonData.pointerCurrentRaycast.gameObject;
      this.ProcessMousePress(eventData);
      this.ProcessMove(eventData.buttonData);
      this.ProcessDrag(eventData.buttonData);
      this.ProcessMousePress(pointerEventData.GetButtonState(PointerEventData.InputButton.Right).eventData);
      this.ProcessDrag(pointerEventData.GetButtonState(PointerEventData.InputButton.Right).eventData.buttonData);
      this.ProcessMousePress(pointerEventData.GetButtonState(PointerEventData.InputButton.Middle).eventData);
      this.ProcessDrag(pointerEventData.GetButtonState(PointerEventData.InputButton.Middle).eventData.buttonData);
      if (Mathf.Approximately(eventData.buttonData.scrollDelta.sqrMagnitude, 0.0f))
        return;
      ExecuteEvents.ExecuteHierarchy<IScrollHandler>(ExecuteEvents.GetEventHandler<IScrollHandler>(eventData.buttonData.pointerCurrentRaycast.gameObject), (BaseEventData) eventData.buttonData, ExecuteEvents.scrollHandler);
    }

    /// <summary>
    ///   <para>Send a update event to the currently selected object.</para>
    /// </summary>
    /// <returns>
    ///   <para>If the update event was used by the selected object.</para>
    /// </returns>
    protected bool SendUpdateEventToSelectedObject()
    {
      if ((UnityEngine.Object) this.eventSystem.currentSelectedGameObject == (UnityEngine.Object) null)
        return false;
      BaseEventData baseEventData = this.GetBaseEventData();
      ExecuteEvents.Execute<IUpdateSelectedHandler>(this.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.updateSelectedHandler);
      return baseEventData.used;
    }

    protected void ProcessMousePress(PointerInputModule.MouseButtonEventData data)
    {
      PointerEventData buttonData = data.buttonData;
      GameObject gameObject1 = buttonData.pointerCurrentRaycast.gameObject;
      if (data.PressedThisFrame())
      {
        buttonData.eligibleForClick = true;
        buttonData.delta = Vector2.zero;
        buttonData.dragging = false;
        buttonData.useDragThreshold = true;
        buttonData.pressPosition = buttonData.position;
        buttonData.pointerPressRaycast = buttonData.pointerCurrentRaycast;
        this.DeselectIfSelectionChanged(gameObject1, (BaseEventData) buttonData);
        GameObject gameObject2 = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(gameObject1, (BaseEventData) buttonData, ExecuteEvents.pointerDownHandler);
        if ((UnityEngine.Object) gameObject2 == (UnityEngine.Object) null)
          gameObject2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject1);
        float unscaledTime = Time.unscaledTime;
        if ((UnityEngine.Object) gameObject2 == (UnityEngine.Object) buttonData.lastPress)
        {
          if ((double) (unscaledTime - buttonData.clickTime) < 0.300000011920929)
            ++buttonData.clickCount;
          else
            buttonData.clickCount = 1;
          buttonData.clickTime = unscaledTime;
        }
        else
          buttonData.clickCount = 1;
        buttonData.pointerPress = gameObject2;
        buttonData.rawPointerPress = gameObject1;
        buttonData.clickTime = unscaledTime;
        buttonData.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(gameObject1);
        if ((UnityEngine.Object) buttonData.pointerDrag != (UnityEngine.Object) null)
          ExecuteEvents.Execute<IInitializePotentialDragHandler>(buttonData.pointerDrag, (BaseEventData) buttonData, ExecuteEvents.initializePotentialDrag);
        this.m_InputPointerEvent = buttonData;
      }
      if (!data.ReleasedThisFrame())
        return;
      ExecuteEvents.Execute<IPointerUpHandler>(buttonData.pointerPress, (BaseEventData) buttonData, ExecuteEvents.pointerUpHandler);
      GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject1);
      if ((UnityEngine.Object) buttonData.pointerPress == (UnityEngine.Object) eventHandler && buttonData.eligibleForClick)
        ExecuteEvents.Execute<IPointerClickHandler>(buttonData.pointerPress, (BaseEventData) buttonData, ExecuteEvents.pointerClickHandler);
      else if ((UnityEngine.Object) buttonData.pointerDrag != (UnityEngine.Object) null && buttonData.dragging)
        ExecuteEvents.ExecuteHierarchy<IDropHandler>(gameObject1, (BaseEventData) buttonData, ExecuteEvents.dropHandler);
      buttonData.eligibleForClick = false;
      buttonData.pointerPress = (GameObject) null;
      buttonData.rawPointerPress = (GameObject) null;
      if ((UnityEngine.Object) buttonData.pointerDrag != (UnityEngine.Object) null && buttonData.dragging)
        ExecuteEvents.Execute<IEndDragHandler>(buttonData.pointerDrag, (BaseEventData) buttonData, ExecuteEvents.endDragHandler);
      buttonData.dragging = false;
      buttonData.pointerDrag = (GameObject) null;
      if ((UnityEngine.Object) gameObject1 != (UnityEngine.Object) buttonData.pointerEnter)
      {
        this.HandlePointerExitAndEnter(buttonData, (GameObject) null);
        this.HandlePointerExitAndEnter(buttonData, gameObject1);
      }
      this.m_InputPointerEvent = buttonData;
    }

    protected GameObject GetCurrentFocusedGameObject()
    {
      return this.m_CurrentFocusedGameObject;
    }

    [Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", false)]
    public enum InputMode
    {
      Mouse,
      Buttons,
    }
  }
}
