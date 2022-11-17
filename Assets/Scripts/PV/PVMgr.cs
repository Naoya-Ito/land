using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 文字だけが表示される暗転シーン
// 普段はPV pv_mode=true で使用するが、日数変化時も使う
public class PVMgr : MonoBehaviour{
  void Start(){
    if(CommonUtil.isPV()){
      PVModel.setPVSetting();
      float wait_time = PVModel.getPVWaitTime();
      Invoke("goNextScene", wait_time);
      CommonUtil.changeText("skill_text", "");
    } else {
      if(DataMgr.GetBool("is_white")){
        DataMgr.SetBool("is_white", false);
        Invoke("goGameScene", 3.0f);
        CommonUtil.changeText("skill_text", "");
        updateScene();
        return;
      }
        
      execSkill();
      setDayEvent();

      if(DataMgr.GetBool("change_day_speed_up")) {
        Invoke("goGameScene", 0.5f);
      } else {
        Invoke("goGameScene", 3.0f);
      }
    }
    updateScene();
  }

  private void updateScene(){
    string pv_text = DataMgr.GetStr("pv_text");
    CommonUtil.changeText("text", pv_text);
  }

  private void execSkill(){
    string text = "";
    if(SkillModel.isGetSkill("day_heal") && DataMgr.GetInt("hp") != DataMgr.GetInt("max_hp")) {
      DataMgr.ChangeHP(1);
      text += "[自然回復] <sprite name=\"heart\">1回復\n";
    }

    if(SkillModel.isGetSkill("yakusou")){
      DataMgr.addList("deck", "yakusou");
      text += "[薬草栽培] 薬草を獲得。\n";
    }
    if(SkillModel.isGetSkill("day_str") || SkillModel.isGetSkill("day_mgi") || SkillModel.isGetSkill("day_agi") || SkillModel.isGetSkill("day_luck")){
      text += "[能力成長]";
      if(SkillModel.isGetSkill("day_str") && CommonUtil.rnd(10) < 3) {
        DataMgr.Increment("str");
        text += "<sprite name=\"str\">";
      }
      if(SkillModel.isGetSkill("day_mgi") && CommonUtil.rnd(10) < 3) {
        DataMgr.Increment("mgi");
        text += "<sprite name=\"mgi\">";
      }
      if(SkillModel.isGetSkill("day_agi") && CommonUtil.rnd(10) < 3) {
        DataMgr.Increment("agi");
        text += "<sprite name=\"agi\">";
      }
      if(SkillModel.isGetSkill("day_luck") && CommonUtil.rnd(10) < 3) {
        DataMgr.Increment("luck");
        text += "<sprite name=\"luck\">";
      }
      text += "\n";
    }
    int income = DataMgr.GetInt("income");
    if(income > 0) {
      text += $"日々の収入 +{income}<sprite name=\"gold\">\n";
      DataMgr.Increment("gold", income);
    }

    CommonUtil.changeText("skill_text", text);
  }

  private void goNextScene(){
    string next_scene = PVModel.getNextSceneName();
    DataMgr.Increment("pv_level");
    CommonUtil.changeScene(next_scene);
  }

  private void goGameScene(){
    BGMMgr.instance.changeBGM("field");
    CommonUtil.changeScene("GameScene");
  }


  // 3日目　ランダム人
  // 4~7日目  ３日間の合宿
  // 9日目　安息日　今日は寝よう
  private void setDayEvent(){
    int day = DataMgr.GetInt("day");

    if(day%10 == 3) {
      if(!DataMgr.GetBool("3_igni")) {
        DataMgr.SetStr("event_key", "day/3_igni");
      } else {
        DataMgr.SetStr("event_key", "random_people/start");
      }
      return;
    }
    if(day%10 == 9) {
      DataMgr.SetStr("event_key", "day/rest");
      return;
    }

    if(day%10 == 4) {
      DataMgr.SetStr("event_key", "day_event/start");
      return;
    }

    switch(day) {
    case 1:
      if(!DataMgr.GetBool("fist_day1")) {
        DataMgr.SetStr("event_key", "day/1_start");
      } else {
        DataMgr.SetStr("event_key", "day/1_time");
      }
      break;
      /*
    case 2:
      if(!DataMgr.GetBool("day2_zombi")) {
        DataMgr.SetStr("event_key", "day/1_start");
      }
      break;
      */
    case 10:
      DataMgr.SetStr("event_key", "day10/start");
      break;
    case 20:
      DataMgr.SetStr("event_key", "day20/start");
      break;
    case 21:
      if(DataMgr.GetBool("day21_end")) return;
      DataMgr.SetStr("event_key", "day21/start");
      break;
    case 30:
      DataMgr.SetStr("event_key", "day30/start");
      break;
    case 40:
      DataMgr.SetStr("event_key", "day40/start");
      break;
    case 41:
      if(DataMgr.GetBool("day41_end")) return;
      DataMgr.SetStr("event_key", "day41/start");
      break;
    case 50:
      DataMgr.SetStr("event_key", "day50/start");
      break;
    case 60:
      DataMgr.SetStr("event_key", "day60/start");
      break;
    case 61:
      if(DataMgr.GetBool("day61_end")) return;
      DataMgr.SetStr("event_key", "day61/start");
      break;
    case 70:
      DataMgr.SetStr("event_key", "day70/start");
      break;
    case 80:
      DataMgr.SetStr("event_key", "day80/start");
      break;
    case 81:
      if(DataMgr.GetBool("day81_end")) return;
      DataMgr.SetStr("event_key", "day81/start");
      break;
    case 90:
      DataMgr.SetStr("event_key", "day90/start");
      break;
    case 100:
      DataMgr.SetStr("event_key", "day100/start");
      break;
    default:
      break;
    }
  }
}
