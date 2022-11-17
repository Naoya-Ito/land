using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour
{
  [SerializeField] SkillController skillPrefab;
  public RectTransform contentRectTransform;

  public static SkillList instance = null;

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }

    updateCostWithData();
  }

  public void updateSkillList(){
    foreach(string key in SkillModel.all_list) {
      SkillController skill = Instantiate(skillPrefab, contentRectTransform);
      skill.Init(key);
    }
  }

  public void updateTitle(string val){
    CommonUtil.changeText("SkillListTitle", val);
  }

  public static void updateCostWithData(){
    int gold = DataMgr.GetInt("gold");
    CommonUtil.changeText("SkillCost", $"所持金 {gold}<sprite name=\"gold\">");
  }

  public void cancel(){
    GameObject panel = GameObject.Find("SkillList");
    if(panel != null) {
      Destroy(panel);
    } else {
      Debug.Log("SkillList is not found.");
    }
  }
}
