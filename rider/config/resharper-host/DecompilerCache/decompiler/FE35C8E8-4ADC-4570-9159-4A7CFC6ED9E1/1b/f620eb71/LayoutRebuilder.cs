// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.LayoutRebuilder
// Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE35C8E8-4ADC-4570-9159-4A7CFC6ED9E1
// Assembly location: D:\Unity\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll

using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UnityEngine.UI
{
  /// <summary>
  ///   <para>Wrapper class for managing layout rebuilding of CanvasElement.</para>
  /// </summary>
  public class LayoutRebuilder : ICanvasElement
  {
    private static ObjectPool<LayoutRebuilder> s_Rebuilders = new ObjectPool<LayoutRebuilder>((UnityAction<LayoutRebuilder>) null, (UnityAction<LayoutRebuilder>) (x => x.Clear()));
    private RectTransform m_ToRebuild;
    private int m_CachedHashFromTransform;

    static LayoutRebuilder()
    {
      // ISSUE: reference to a compiler-generated field
      if (LayoutRebuilder.\u003C\u003Ef__mg\u0024cache0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        LayoutRebuilder.\u003C\u003Ef__mg\u0024cache0 = new RectTransform.ReapplyDrivenProperties(LayoutRebuilder.ReapplyDrivenProperties);
      }
      // ISSUE: reference to a compiler-generated field
      RectTransform.reapplyDrivenProperties += LayoutRebuilder.\u003C\u003Ef__mg\u0024cache0;
    }

    private void Initialize(RectTransform controller)
    {
      this.m_ToRebuild = controller;
      this.m_CachedHashFromTransform = controller.GetHashCode();
    }

    private void Clear()
    {
      this.m_ToRebuild = (RectTransform) null;
      this.m_CachedHashFromTransform = 0;
    }

    private static void ReapplyDrivenProperties(RectTransform driven)
    {
      LayoutRebuilder.MarkLayoutForRebuild(driven);
    }

    /// <summary>
    ///   <para>See ICanvasElement.</para>
    /// </summary>
    public Transform transform
    {
      get
      {
        return (Transform) this.m_ToRebuild;
      }
    }

    /// <summary>
    ///   <para>Has the native representation of this LayoutRebuilder been destroyed?</para>
    /// </summary>
    public bool IsDestroyed()
    {
      return (UnityEngine.Object) this.m_ToRebuild == (UnityEngine.Object) null;
    }

    private static void StripDisabledBehavioursFromList(List<Component> components)
    {
      components.RemoveAll((Predicate<Component>) (e => e is Behaviour && !((Behaviour) e).isActiveAndEnabled));
    }

    /// <summary>
    ///   <para>Forces an immediate rebuild of the layout element and child layout elements affected by the calculations.</para>
    /// </summary>
    /// <param name="layoutRoot">The layout element to perform the layout rebuild on.</param>
    public static void ForceRebuildLayoutImmediate(RectTransform layoutRoot)
    {
      LayoutRebuilder element = LayoutRebuilder.s_Rebuilders.Get();
      element.Initialize(layoutRoot);
      element.Rebuild(CanvasUpdate.Layout);
      LayoutRebuilder.s_Rebuilders.Release(element);
    }

    /// <summary>
    ///   <para>See ICanvasElement.Rebuild.</para>
    /// </summary>
    /// <param name="executing"></param>
    public void Rebuild(CanvasUpdate executing)
    {
      if (executing != CanvasUpdate.Layout)
        return;
      this.PerformLayoutCalculation(this.m_ToRebuild, (UnityAction<Component>) (e => (e as ILayoutElement).CalculateLayoutInputHorizontal()));
      this.PerformLayoutControl(this.m_ToRebuild, (UnityAction<Component>) (e => (e as ILayoutController).SetLayoutHorizontal()));
      this.PerformLayoutCalculation(this.m_ToRebuild, (UnityAction<Component>) (e => (e as ILayoutElement).CalculateLayoutInputVertical()));
      this.PerformLayoutControl(this.m_ToRebuild, (UnityAction<Component>) (e => (e as ILayoutController).SetLayoutVertical()));
    }

    private void PerformLayoutControl(RectTransform rect, UnityAction<Component> action)
    {
      if ((UnityEngine.Object) rect == (UnityEngine.Object) null)
        return;
      List<Component> componentList = ListPool<Component>.Get();
      rect.GetComponents(typeof (ILayoutController), componentList);
      LayoutRebuilder.StripDisabledBehavioursFromList(componentList);
      if (componentList.Count > 0)
      {
        for (int index = 0; index < componentList.Count; ++index)
        {
          if (componentList[index] is ILayoutSelfController)
            action(componentList[index]);
        }
        for (int index = 0; index < componentList.Count; ++index)
        {
          if (!(componentList[index] is ILayoutSelfController))
            action(componentList[index]);
        }
        for (int index = 0; index < rect.childCount; ++index)
          this.PerformLayoutControl(rect.GetChild(index) as RectTransform, action);
      }
      ListPool<Component>.Release(componentList);
    }

    private void PerformLayoutCalculation(RectTransform rect, UnityAction<Component> action)
    {
      if ((UnityEngine.Object) rect == (UnityEngine.Object) null)
        return;
      List<Component> componentList = ListPool<Component>.Get();
      rect.GetComponents(typeof (ILayoutElement), componentList);
      LayoutRebuilder.StripDisabledBehavioursFromList(componentList);
      if (componentList.Count > 0 || (bool) ((UnityEngine.Object) rect.GetComponent(typeof (ILayoutGroup))))
      {
        for (int index = 0; index < rect.childCount; ++index)
          this.PerformLayoutCalculation(rect.GetChild(index) as RectTransform, action);
        for (int index = 0; index < componentList.Count; ++index)
          action(componentList[index]);
      }
      ListPool<Component>.Release(componentList);
    }

    /// <summary>
    ///   <para>Mark the given RectTransform as needing it's layout to be recalculated during the next layout pass.</para>
    /// </summary>
    /// <param name="rect">Rect to rebuild.</param>
    public static void MarkLayoutForRebuild(RectTransform rect)
    {
      if ((UnityEngine.Object) rect == (UnityEngine.Object) null || (UnityEngine.Object) rect.gameObject == (UnityEngine.Object) null)
        return;
      List<Component> componentList = ListPool<Component>.Get();
      bool flag = true;
      RectTransform rectTransform = rect;
      for (RectTransform parent = rectTransform.parent as RectTransform; flag && !((UnityEngine.Object) parent == (UnityEngine.Object) null) && !((UnityEngine.Object) parent.gameObject == (UnityEngine.Object) null); parent = parent.parent as RectTransform)
      {
        flag = false;
        parent.GetComponents(typeof (ILayoutGroup), componentList);
        for (int index = 0; index < componentList.Count; ++index)
        {
          Component component = componentList[index];
          if ((UnityEngine.Object) component != (UnityEngine.Object) null && component is Behaviour && ((Behaviour) component).isActiveAndEnabled)
          {
            flag = true;
            rectTransform = parent;
            break;
          }
        }
      }
      if ((UnityEngine.Object) rectTransform == (UnityEngine.Object) rect && !LayoutRebuilder.ValidController(rectTransform, componentList))
      {
        ListPool<Component>.Release(componentList);
      }
      else
      {
        LayoutRebuilder.MarkLayoutRootForRebuild(rectTransform);
        ListPool<Component>.Release(componentList);
      }
    }

    private static bool ValidController(RectTransform layoutRoot, List<Component> comps)
    {
      if ((UnityEngine.Object) layoutRoot == (UnityEngine.Object) null || (UnityEngine.Object) layoutRoot.gameObject == (UnityEngine.Object) null)
        return false;
      layoutRoot.GetComponents(typeof (ILayoutController), comps);
      for (int index = 0; index < comps.Count; ++index)
      {
        Component comp = comps[index];
        if ((UnityEngine.Object) comp != (UnityEngine.Object) null && comp is Behaviour && ((Behaviour) comp).isActiveAndEnabled)
          return true;
      }
      return false;
    }

    private static void MarkLayoutRootForRebuild(RectTransform controller)
    {
      if ((UnityEngine.Object) controller == (UnityEngine.Object) null)
        return;
      LayoutRebuilder element = LayoutRebuilder.s_Rebuilders.Get();
      element.Initialize(controller);
      if (CanvasUpdateRegistry.TryRegisterCanvasElementForLayoutRebuild((ICanvasElement) element))
        return;
      LayoutRebuilder.s_Rebuilders.Release(element);
    }

    /// <summary>
    ///   <para>See ICanvasElement.LayoutComplete.</para>
    /// </summary>
    public void LayoutComplete()
    {
      LayoutRebuilder.s_Rebuilders.Release(this);
    }

    /// <summary>
    ///   <para>See ICanvasElement.GraphicUpdateComplete.</para>
    /// </summary>
    public void GraphicUpdateComplete()
    {
    }

    public override int GetHashCode()
    {
      return this.m_CachedHashFromTransform;
    }

    public override bool Equals(object obj)
    {
      return obj.GetHashCode() == this.GetHashCode();
    }

    public override string ToString()
    {
      return "(Layout Rebuilder for) " + (object) this.m_ToRebuild;
    }
  }
}
