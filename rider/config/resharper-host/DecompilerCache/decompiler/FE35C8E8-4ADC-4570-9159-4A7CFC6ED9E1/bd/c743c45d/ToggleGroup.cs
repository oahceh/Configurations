// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.ToggleGroup
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE35C8E8-4ADC-4570-9159-4A7CFC6ED9E1
// Assembly location: D:\Unity\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>A component that represents a group of UI.Toggles.</para>
  /// </summary>
  [AddComponentMenu("UI/Toggle Group", 32)]
  [DisallowMultipleComponent]
  public class ToggleGroup : UIBehaviour
  {
    [SerializeField]
    private bool m_AllowSwitchOff = false;
    private List<Toggle> m_Toggles = new List<Toggle>();

    protected ToggleGroup()
    {
    }

    /// <summary>
    ///   <para>Is it allowed that no toggle is switched on?</para>
    /// </summary>
    public bool allowSwitchOff
    {
      get
      {
        return this.m_AllowSwitchOff;
      }
      set
      {
        this.m_AllowSwitchOff = value;
      }
    }

    private void ValidateToggleIsInGroup(Toggle toggle)
    {
      if ((UnityEngine.Object) toggle == (UnityEngine.Object) null || !this.m_Toggles.Contains(toggle))
        throw new ArgumentException(string.Format("Toggle {0} is not part of ToggleGroup {1}", new object[2]
        {
          (object) toggle,
          (object) this
        }));
    }

    public void NotifyToggleOn(Toggle toggle)
    {
      this.ValidateToggleIsInGroup(toggle);
      for (int index = 0; index < this.m_Toggles.Count; ++index)
      {
        if (!((UnityEngine.Object) this.m_Toggles[index] == (UnityEngine.Object) toggle))
          this.m_Toggles[index].isOn = false;
      }
    }

    public void UnregisterToggle(Toggle toggle)
    {
      if (!this.m_Toggles.Contains(toggle))
        return;
      this.m_Toggles.Remove(toggle);
    }

    public void RegisterToggle(Toggle toggle)
    {
      if (this.m_Toggles.Contains(toggle))
        return;
      this.m_Toggles.Add(toggle);
    }

    /// <summary>
    ///   <para>Are any of the toggles on?</para>
    /// </summary>
    public bool AnyTogglesOn()
    {
      return (UnityEngine.Object) this.m_Toggles.Find((Predicate<Toggle>) (x => x.isOn)) != (UnityEngine.Object) null;
    }

    /// <summary>
    ///   <para>Returns the toggles in this group that are active.</para>
    /// </summary>
    /// <returns>
    ///   <para>The active toggles in the group.</para>
    /// </returns>
    public IEnumerable<Toggle> ActiveToggles()
    {
      return this.m_Toggles.Where<Toggle>((Func<Toggle, bool>) (x => x.isOn));
    }

    /// <summary>
    ///   <para>Switch all toggles off.</para>
    /// </summary>
    public void SetAllTogglesOff()
    {
      bool allowSwitchOff = this.m_AllowSwitchOff;
      this.m_AllowSwitchOff = true;
      for (int index = 0; index < this.m_Toggles.Count; ++index)
        this.m_Toggles[index].isOn = false;
      this.m_AllowSwitchOff = allowSwitchOff;
    }
  }
}
