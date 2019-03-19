// Decompiled with JetBrains decompiler
// Type: N1Editor.Battle.ActAnimationEditor
// Assembly: Assembly-CSharp-Editor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C3FFC96B-C155-4773-8661-97AA6035B736
// Assembly location: E:\N1\client\N1\Library\ScriptAssemblies\Assembly-CSharp-Editor.dll

using N1Editor.Utils;
using System;
using UnityEditor;
using UnityEngine;

namespace N1Editor.Battle
{
  [CustomActEditor(typeof (ActAnimation), "角色动画")]
  public class ActAnimationEditor : ActEditor
  {
    public ActAnimationEditor(ActData actData)
      : base(actData)
    {
      this.CheckProperty("target_actor", string.Empty, "string");
      this.CheckProperty("name", string.Empty, "string");
      this.CheckProperty("is_loop", "false", "bool");
      this.CheckProperty("is_random_start", "false", "bool");
      this.CheckProperty("reset_time_position", "0", "float");
    }

    protected override void DrawProperties()
    {
      ActPropertyData rawProperty1 = this._target.GetRawProperty("target_actor");
      rawProperty1.value = EditorGUILayout.TextField("施放角色", rawProperty1.value, (GUILayoutOption[]) Array.Empty<GUILayoutOption>());
      ActPropertyData rawProperty2 = this._target.GetRawProperty("name");
      int index = EditorGUILayout.Popup("动作名", EditorUtils.IndexOf(BattleConst.ActorAnimations, rawProperty2.value, 0), BattleConst.ActorAnimations, (GUILayoutOption[]) Array.Empty<GUILayoutOption>());
      rawProperty2.value = BattleConst.ActorAnimations[index];
      ActPropertyData rawProperty3 = this._target.GetRawProperty("is_loop");
      rawProperty3.value = EditorGUILayout.Toggle("循环", bool.Parse(rawProperty3.value), (GUILayoutOption[]) Array.Empty<GUILayoutOption>()).ToString();
      ActPropertyData rawProperty4 = this._target.GetRawProperty("is_random_start");
      rawProperty4.value = EditorGUILayout.Toggle("随机开始", bool.Parse(rawProperty4.value), (GUILayoutOption[]) Array.Empty<GUILayoutOption>()).ToString();
      ActPropertyData rawProperty5 = this._target.GetRawProperty("reset_time_position");
      rawProperty5.value = EditorGUILayout.FloatField("同名动作切换时间", float.Parse(rawProperty5.value), (GUILayoutOption[]) Array.Empty<GUILayoutOption>()).ToString();
    }
  }
}
