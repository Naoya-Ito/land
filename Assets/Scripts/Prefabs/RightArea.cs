using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArea : MonoBehaviour {

  static public void updateStatus(){
    CommonUtil.changeText("day", $"<sprite name=\"day\">{DataMgr.GetInt("day")}");
    updateGold(DataMgr.GetInt("gold"));
//    CommonUtil.changeImage("party", DataMgr.GetStr("party"));
  }
  
  static public void updateBattleStatus(){
    if(CommonUtil.isPV()) return;

    CommonUtil.changeText("day", $"<sprite name=\"day\">{DataMgr.GetInt("day")}");
    updateGold(BattleMgr.instance.gold);
//    CommonUtil.changeImage("party", DataMgr.GetStr("party"));
  }

  public static void updateGold(int val){
    CommonUtil.changeText("gold_text", $"<sprite name=\"gold\"> {val}");
  }

  public static void updateGoldWithData(){
    int gold = DataMgr.GetInt("gold");
    CommonUtil.changeText("gold_text", $"<sprite name=\"gold\"> {gold}");
  }

  public static void hideSkillButton(){
    GameObject skill_button = GameObject.Find("skill_button");
    skill_button.SetActive(false);
  }


  static public void fadeOut(){
    GameObject area = GameObject.Find("right_area");
    GameObject day_text = GameObject.Find("day");
    GameObject gold_text = GameObject.Find("gold_text");
//    GameObject skill_button = GameObject.Find("skill_button");
//    GameObject armor = GameObject.Find("armor_area");
//    GameObject ring = GameObject.Find("ring_area");
    GameObject party = GameObject.Find("party_area");

    FadeoutObject area_fade = area.GetComponent<FadeoutObject>();
    FadeoutTextObject day_fade = day_text.GetComponent<FadeoutTextObject>();
    FadeoutTextObject gold_fade = gold_text.GetComponent<FadeoutTextObject>();
//    FadeoutObject skill_fade = skill_button.GetComponent<FadeoutObject>();
    FadeoutImageObject party_fade = party.GetComponent<FadeoutImageObject>();

    area_fade.fadeStart();
    day_fade.fadeStart();
    gold_fade.fadeStart();
//    skill_fade.fadeStart();

//    armor_fade.fadeStart();
//    ring_fade.fadeStart();
    party_fade.fadeStart();
  }
}
