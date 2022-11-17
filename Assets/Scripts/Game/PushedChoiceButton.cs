using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PushedChoiceButton : MonoBehaviour{
  static int CHOICE_NUM = 6;

  private bool isButtonPushed = false;
  public void PushButton(int number) {
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;
    
    hideButton(number);
    changeButtonColor(number);

    if(CommonUtil.isPV()){
      return;
    }

    EventMgr event_mgr = GameObject.Find("EventMgrObject").GetComponent<EventMgr>();
    ChoiceModel choice = event_mgr.model.choices[number-1];
    string read_key = $"{DataMgr.GetStr("event_key")}_{choice.key_category}/{choice.key_name}";
    if(!ReadModel.IsRead(read_key)) {
      ReadModel.SetRead(read_key);
      DataMgr.Increment("choice", 1);
    }

    // 下記の場合は一切の後処理をせず画面遷移
    if(choice.battle_info.enemy_name != "") {
      DataMgr.instance.battle_info = choice.battle_info;
      if(choice.battle_info.bgm == "") {
        BGMMgr.instance.changeBGM("normal_battle");
      } else {
        BGMMgr.instance.changeBGM(choice.battle_info.bgm);
      }
      CommonUtil.changeScene("BattleScene");
      return;
    }

    string category = choice.key_category != "" ? choice.key_category : event_mgr.model.category;  
    string event_key = choice.key_name;
    string new_key = category + "/" + event_key;

    // 下記のキーの場合は一切の処理をせずに終了
    switch(category) {
    case "judge":
      if(event_key == "to_live") DataMgr.SetBool("is_guilty", false);
      break;
    case "ending":
      if(event_key == "game_end") {
        DataMgr.Increment("bonus", 100);
        DataMgr.SetBool("is_ending", true);
        CommonUtil.changeScene("GameOverScene");
        return;
      }
      if(event_key == "kill_king3") {
        SteamMgr.setAchievement("ENDING_C");
      }
      break;
    case "angel":
      if(event_key == "choice_done2") {
        DataMgr.SetBool("is_guilty", false);
        if(DataMgr.GetInt("tear") <= 0) {
          DataMgr.SetStr("event_key", "angel/tear");
          CommonUtil.changeScene("GameScene");
          return;
        }
      }
      if(event_key == "choice_end") {
        int birth_day = DataMgr.GetInt("day");
        if(birth_day%10 == 0) {
          DataMgr.SetInt("day", birth_day - 3);
          DataMgr.SetStr("pv_text", $"{birth_day}日目");
          DataMgr.SetStr("event_key", "angel/time");
          CommonUtil.changeScene("GameScene");
          return;
        }
      }
      break;
    case "day":
      switch(event_key) {
        case "time_11_to":
          DataMgr.SetInt("day", 11);
          DataMgr.SetStr("pv_text", "11日目");
          DataMgr.SetStr("event_key", "town/start");
          BGMMgr.instance.stopMusic();
          CommonUtil.changeScene("PVScene");
          return;
        case "time_21_to":
          DataMgr.SetInt("day", 21);
          DataMgr.SetStr("pv_text", "21日目");
          DataMgr.SetStr("event_key", "town/start");
          BGMMgr.instance.stopMusic();
          CommonUtil.changeScene("PVScene");
          return;
        case "time_31_to":
          DataMgr.SetInt("day", 31);
          DataMgr.SetStr("pv_text", "31日目");
          DataMgr.SetStr("event_key", "town/start");
          BGMMgr.instance.stopMusic();
          CommonUtil.changeScene("PVScene");
          return;
        case "time_41_to":
          DataMgr.SetInt("day", 41);
          DataMgr.SetStr("pv_text", "41日目");
          DataMgr.SetStr("event_key", "town/start");
          BGMMgr.instance.stopMusic();
          CommonUtil.changeScene("PVScene");
          return;
        case "time_51_to":
          DataMgr.SetInt("day", 51);
          DataMgr.SetStr("pv_text", "51日目");
          DataMgr.SetStr("event_key", "town/start");
          BGMMgr.instance.stopMusic();
          CommonUtil.changeScene("PVScene");
          return;
        case "time_61_to":
          DataMgr.SetInt("day", 61);
          DataMgr.SetStr("pv_text", "61日目");
          DataMgr.SetStr("event_key", "town/start");
          BGMMgr.instance.stopMusic();
          CommonUtil.changeScene("PVScene");
          return;
        case "time_71_to":
          DataMgr.SetInt("day", 71);
          DataMgr.SetStr("pv_text", "71日目");
          DataMgr.SetStr("event_key", "town/start");
          BGMMgr.instance.stopMusic();
          CommonUtil.changeScene("PVScene");
          return;
        case "time_81_to":
          DataMgr.SetInt("day", 81);
          DataMgr.SetStr("pv_text", "81日目");
          DataMgr.SetStr("event_key", "town/start");
          BGMMgr.instance.stopMusic();
          CommonUtil.changeScene("PVScene");
          return;
        case "time_91_to":
          DataMgr.SetInt("day", 91);
          DataMgr.SetStr("pv_text", "91日目");
          DataMgr.SetStr("event_key", "town/start");
          BGMMgr.instance.stopMusic();
          CommonUtil.changeScene("PVScene");
          return;
        default:
          break;
      }
      break;
    case "dead":
      if(event_key == "dead_end") {
        FadeManager.Instance.LoadScene("GameOverScene", 0.4f);
        return;
      }
      break;
    case "town":
      if(event_key == "face2") DataMgr.SetBool("is_guilty", false);
      break;
    case "yogen":
      if(event_key == "100_warp") {
        DataMgr.SetInt("day", 100);
        DataMgr.SetStr("pv_text", "100日目");
        DataMgr.SetStr("event_key", "town/start");
        BGMMgr.instance.stopMusic();
        CommonUtil.changeScene("PVScene");
        return;
      }
      break;
    case "random_people":
      if(event_key == "ghost2") {
        DataMgr.Increment("max_hp", 3);
        DataMgr.Increment("str", 3);
        DataMgr.Increment("mgi", 3);
        DataMgr.Increment("agi", 3);
        DataMgr.Increment("luck", 3);
      }
      if(event_key == "ghost_life") {
        DataMgr.SetInt("max_hp", 1);
        DataMgr.SetInt("hp", 1);
      }
      if(event_key == "ghost_curse") {
        DataMgr.addList("deck", "curse");
        DataMgr.addList("deck", "curse");
        DataMgr.addList("deck", "curse");
        DataMgr.addList("deck", "curse");
        DataMgr.addList("deck", "curse");
      }
      break;  
    case "work":
      if(event_key == "zouki_done") {
        DataMgr.SetInt("max_hp", 1);
        DataMgr.SetInt("hp", 1);
      }
      break;  
    default:
//      GManager.instance.event_key = new_key;
//      CommonUtil.instance.changeScene("EventScene");
      break;
    }

    if(choice.change_key != "") {
      DataMgr.Increment(choice.change_key, choice.change_val);
    }

    if(choice.get_card != ""){
      DataMgr.addList("deck", choice.get_card);
    }

    if(choice.set_flag != "") {
      DataMgr.SetBool(choice.set_flag, true);
    }

    if(choice.change_hp != 0) {
      DataMgr.ChangeHP(choice.change_hp);
      if(DataMgr.isDead()){
        Debug.Log($"player is dead. next_page={choice.dead_page}");
        new_key = choice.dead_page;
      }
    }

    EventModel next_event = new EventModel(new_key);
    if(next_event.clicked_change_key == "hp") {
      DataMgr.ChangeHP(next_event.clicked_change_val);
    } else if(next_event.clicked_change_key != "") {
      DataMgr.Increment(next_event.clicked_change_key, next_event.clicked_change_val);
    }

    if(DataMgr.GetInt("hp") > DataMgr.GetInt("max_hp")) {
      DataMgr.SetInt("hp", DataMgr.GetInt("max_hp"));
    }

    if(choice.isDayPast) {
      DataMgr.dayPast();
      int day = DataMgr.GetInt("day");
      DataMgr.SetStr("pv_text", $"{day}日目");
      DataMgr.SetStr("event_key", "town/start");
      BGMMgr.instance.stopMusic();
      CommonUtil.changeScene("PVScene");
      return;
    }

    DataMgr.SetStr("event_key", new_key);
    CommonUtil.changeScene("GameScene");
  }

  private void hideButton(int number){
    for (int i = 0; i < CHOICE_NUM; i++) {
      if(i + 1 == number) {
        continue;
      }
      GameObject button = GameObject.Find($"ChoiceButton{i+1}");
      if(button != null) {
        button.SetActive(false);
      }
    }
  }

  private void changeButtonColor(int number) {
    Image button = GameObject.Find($"ChoiceButton{number}").GetComponent<Image>();
    button.color = Color.white;
    TextMeshProUGUI text = GameObject.Find($"choiceText{number}").GetComponent<TextMeshProUGUI>();
    text.color = Color.black;
  }
}