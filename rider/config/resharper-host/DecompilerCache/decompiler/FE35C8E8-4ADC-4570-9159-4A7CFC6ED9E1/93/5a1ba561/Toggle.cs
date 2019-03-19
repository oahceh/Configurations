// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.Toggle
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE35C8E8-4ADC-4570-9159-4A7CFC6ED9E1
// Assembly location: D:\Unity\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>A standard toggle that has an on / off state.</para>
  /// </summary>
  [AddComponentMenu("UI/Toggle", 31)]
  [RequireComponent(typeof (RectTransform))]
  public class Toggle : Selectable, IPointerClickHandler, ISubmitHandler, ICanvasElement, IEventSystemHandler
  {
    /// <summary>
    ///   <para>Transition mode for the toggle.</para>
    /// </summary>
    public Toggle.ToggleTransition toggleTransition = Toggle.ToggleTransition.Fade;
    /// <summary>
    ///   <para>Callback executed when the value of the toggle is changed.</para>
    /// </summary>
    public Toggle.ToggleEvent onValueChanged = new Toggle.ToggleEvent();
    /// <summary>
    ///   <para>Graphic affected by the toggle.</para>
    /// </summary>
    public Graphic graphic;
    [SerializeField]
    private ToggleGroup m_Group;
    [FormerlySerializedAs("m_IsActive")]
    [Tooltip("Is the toggle currently on or off?")]
    [SerializeField]
    private bool m_IsOn;

    protected Toggle()
    {
    }

    /// <summary>
    ///   <para>Group the toggle belongs to.</para>
    /// </summary>
    public ToggleGroup group
    {
      get
      {
        return this.m_Group;
      }
      set
      {
        this.m_Group = value;
        if (!Application.isPlaying)
          return;
        this.SetToggleGroup(this.m_Group, true);
        this.PlayEffect(true);
      }
    }

    protected override void OnValidate()
    {
      base.OnValidate();
      if (PrefabUtility.GetPrefabType((UnityEngine.Object) this) == PrefabType.Prefab || Application.isPlaying)
        return;
      CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild((ICanvasElement) this);
    }

    /// <summary>
    ///   <para>Handling for when the canvas is rebuilt.</para>
    /// </summary>
    /// <param name="executing"></param>
    public virtual void Rebuild(CanvasUpdate executing)
    {
      if (executing != CanvasUpdate.Prelayout)
        return;
      this.onValueChanged.Invoke(this.m_IsOn);
    }

    /// <summary>
    ///   <para>See ICanvasElement.LayoutComplete.</para>
    /// </summary>
    public virtual void LayoutComplete()
    {
    }

    /// <summary>
    ///   <para>See ICanvasElement.GraphicUpdateComplete.</para>
    /// </summary>
    public virtual void GraphicUpdateComplete()
    {
    }

    protected override void OnEnable()
    {
      base.OnEnable();
      this.SetToggleGroup(this.m_Group, false);
      this.PlayEffect(true);
    }

    /// <summary>
    ///   <para>See MonoBehaviour.OnDisable.</para>
    /// </summary>
    protected override void OnDisable()
    {
      this.SetToggleGroup((ToggleGroup) null, false);
      base.OnDisable();
    }

    protected override void OnDidApplyAnimationProperties()
    {
      if ((UnityEngine.Object) this.graphic != (UnityEngine.Object) null)
      {
        bool flag = !Mathf.Approximately(this.graphic.canvasRenderer.GetColor().a, 0.0f);
        if (this.m_IsOn != flag)
        {
          this.m_IsOn = flag;
          this.Set(!flag);
        }
      }
      base.OnDidApplyAnimationProperties();
    }

    private void SetToggleGroup(ToggleGroup newGroup, bool setMemberValue)
    {
      ToggleGroup group = this.m_Group;
      if ((UnityEngine.Object) this.m_Group != (UnityEngine.Object) null)
        this.m_Group.UnregisterToggle(this);
      if (setMemberValue)
        this.m_Group = newGroup;
      if ((UnityEngine.Object) newGroup != (UnityEngine.Object) null && this.IsActive())
        newGroup.RegisterToggle(this);
      if (!((UnityEngine.Object) newGroup != (UnityEngine.Object) null) || !((UnityEngine.Object) newGroup != (UnityEngine.Object) group) || (!this.isOn || !this.IsActive()))
        return;
      newGroup.NotifyToggleOn(this);
    }

    /// <summary>
    ///   <para>Return or set whether the Toggle is on or not.</para>
    /// </summary>
    public bool isOn
    {
      get
      {
        return this.m_IsOn;
      }
      set
      {
        this.Set(value);
      }
    }

    private void Set(bool value)
    {
      this.Set(value, true);
    }

    private void Set(bool value, bool sendCallback)
    {
      if (this.m_IsOn == value)
        return;
      this.m_IsOn = value;
      if ((UnityEngine.Object) this.m_Group != (UnityEngine.Object) null && this.IsActive() && (this.m_IsOn || !this.m_Group.AnyTogglesOn() && !this.m_Group.allowSwitchOff))
      {
        this.m_IsOn = true;
        this.m_Group.NotifyToggleOn(this);
      }
      this.PlayEffect(this.toggleTransition == Toggle.ToggleTransition.None);
      if (!sendCallback)
        return;
      UISystemProfilerApi.AddMarker("Toggle.value", (UnityEngine.Object) this);
      this.onValueChanged.Invoke(this.m_IsOn);
    }

    private void PlayEffect(bool instant)
    {
      if ((UnityEngine.Object) this.graphic == (UnityEngine.Object) null)
        return;
      if (!Application.isPlaying)
        this.graphic.canvasRenderer.SetAlpha(!this.m_IsOn ? 0.0f : 1f);
      else
        this.graphic.CrossFadeAlpha(!this.m_IsOn ? 0.0f : 1f, !instant ? 0.1f : 0.0f, true);
    }

    protected override void Start()
    {
      this.PlayEffect(true);
    }

    private void InternalToggle()
    {
      if (!this.IsActive() || !this.IsInteractable())
        return;
      this.isOn = !this.isOn;
    }

    /// <summary>
    ///   <para>Handling for when the toggle is 'clicked'.</para>
    /// </summary>
    /// <param name="eventData">Current event.</param>
    public virtual void OnPointerClick(PointerEventData eventData)
    {
      if (eventData.button != PointerEventData.InputButton.Left)
        return;
      this.InternalToggle();
    }

    /// <summary>
    ///   <para>Handling for when the submit key is pressed.</para>
    /// </summary>
    /// <param name="eventData">Current event.</param>
    public virtual void OnSubmit(BaseEventData eventData)
    {
      this.InternalToggle();
    }

    Transform ICanvasElement.get_transform()
    {
      return this.transform;
    }

    /// <summary>
    ///   <para>Display settings for when a toggle is activated or deactivated.</para>
    /// </summary>
    public enum ToggleTransition
    {
      /// <summary>
      ///   <para>Show / hide the toggle instantly.</para>
      /// </summary>
      None,
      /// <summary>
      ///   <para>Fade the toggle in / out.</para>
      /// </summary>
      Fade,
    }

    /// <summary>
    ///   <para>UnityEvent callback for when a toggle is toggled.</para>
    /// </summary>
    [Serializable]
    public class ToggleEvent : UnityEvent<bool>
    {
    }
  }
}
