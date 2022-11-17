using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillTap : MonoBehaviour, IPointerClickHandler {
  public Transform cardParent;

  public void OnPointerClick(PointerEventData eventData){

    SkillController skill_controller = eventData.pointerClick.GetComponent<SkillController>();
    if (skill_controller == null) return;

    SkillModel skill_model = skill_controller.model;
//    Debug.Log($"skill tapped. model={skill_model.skillID}");
    string skillID = skill_model.skillID;

    if(skill_model.isGet) {
        SkillModel.forgetSkill(skillID, skill_controller.model.cost);
        skill_controller.model.isGet = false;
        skill_controller.view.updateView(skill_controller.model);
    } else {
      if(canGetSkill(skill_model.cost)) {
        SkillModel.getSkill(skillID, skill_model.cost);
        skill_controller.model.isGet = true;
        skill_controller.view.updateView(skill_controller.model);
        RightArea.updateGold(DataMgr.GetInt("gold"));
      }
    }

    // 何かを買ったら全リスト更新が望ましい
    // 買えないスキルは帯を赤にしても良いかも
  }

  private bool canGetSkill(int cost){
    return DataMgr.GetInt("gold") >= cost;
  }
}
