using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour{
  public SkillView view; // カードの見た目の処理
  public SkillModel model; // カードのデータを処理

  private void Awake(){
    view = GetComponent<SkillView>();
  }

  public void Init(string skillID){
    model = new SkillModel(skillID);
    view.updateView(model);
  }
}