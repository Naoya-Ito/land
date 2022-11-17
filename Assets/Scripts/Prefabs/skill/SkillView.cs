using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillView : MonoBehaviour{
  [SerializeField] TextMeshProUGUI title, body, cost;
  [SerializeField] Image background;

  public void updateView(SkillModel skillModel){
    title.text = skillModel.title;
    body.text = skillModel.description;

    if(!skillModel.isGet){
      cost.text = $"{skillModel.cost.ToString()} <sprite name=\"gold\">";
    } else {
      cost.text = "習得済み";
    }

    // お金が足りない場合は枠の色を変える
  }
}