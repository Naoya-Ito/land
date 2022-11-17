using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMgr : MonoBehaviour
{
  void Start() {
    updateScene();
    if(CommonUtil.isPV()){
      Invoke("toPV", 3.0f);
    } else {
      DataMgr.SetBool("new_game", true);
      BGMMgr.instance.changeBGM("title");

      if(DataMgr.GetBool("is_ending")) {
        DataMgr.SetBool("is_ending", false);
        CommonUtil.changeText("TitleText", "Game Clear");
      }
    }
  }

  private void updateScene(){
    int day = DataMgr.GetInt("day");
    int war = DataMgr.GetInt("war");
    int choice = DataMgr.GetInt("choice");
    int bonus = DataMgr.GetInt("bonus");
    CommonUtil.changeText("day", $"{day}");
    CommonUtil.changeText("war", $"{war}");
    CommonUtil.changeText("choice", $"{choice}");
    CommonUtil.changeText("status", $"{bonus}");

    int other = DataMgr.GetInt("dead_count") + DataMgr.GetInt("luck")*2 - DataMgr.GetInt("soul_minus");
    CommonUtil.changeText("bonus", $"{other}");

    int soul = day + war + choice + bonus + other;
//    Debug.Log($"status={status}, day={day}, war={war}, choicr={choice}, bonus={bonus}. total soul={soul}");
    CommonUtil.changeText("soul", $"君は{soul}のソウルを手に入れた。");
    DataMgr.Increment("soul", soul);
  }


  private void toPV(){
    string next_scene = PVModel.getNextSceneName();
    DataMgr.Increment("pv_level");
    CommonUtil.changeScene("PVScene");
  }
}
