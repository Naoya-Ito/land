using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSceneMgr : MonoBehaviour
{
  EventModel model;


  void Start() {
    updateHeader();
    updateDayText();

    setEventModel();

    updateText();
  }

  private void updateHeader(){
    HeaderBar.updateMPBarCurrent();
  }

  private void updateDayText(){
    int day = DataMgr.GetInt("day");
    string time = DataMgr.GetStr("time");
    string time_text;
    switch(time) {
      case "morning":
        time_text = "朝";
        break;
      case "evening":
        time_text = "昼";
        break;
      case "sunset":
        time_text = "夕";
        break;
      case "knight":
        time_text = "夜";
        break;
      default:
        time_text = "その他";
        break;
    }

    string day_text = $"{day}日目({time_text})";
    CommonUtil.changeText("day_text", day_text);
  }

  private void setEventModel(){
    string key = DataMgr.GetStr("event");
    model = new EventModel(key);
  }

  private void updateText(){
    string text = model.text;
    CommonUtil.changeText("main_text", text);

    int i = 0;
    foreach(ChoiceModel choice in model.choices) {
      CommonUtil.changeText($"choice_text{i+1}", choice.choice_text);
      i++;
    }
    if(i == 1) {
      CommonUtil.hideButton($"ChoiceButton2");
      CommonUtil.hideButton($"ChoiceButton3");
    } else if (i == 2) {
      CommonUtil.hideButton("ChoiceButton3");
    }
  }

  private bool is_pushed = false;
  public void pushedChoiceButton(int i) {
//    Debug.Log($"pushed {i}");
    if(is_pushed) {
      return;
    }
    is_pushed = true;

    string next_key = model.choices[i-1].key_name;
    CommonUtil.changeScene("GameScene");
    if(next_key == "end") {
      DataMgr.SetStr("event", "");
      LandDataMgr.timePast();
      CommonUtil.changeScene("GameScene");
    } else {
      DataMgr.SetStr("event", next_key);

      // データ変動あれば行う
      CommonUtil.changeScene("EventScene");
    }
  }
}
