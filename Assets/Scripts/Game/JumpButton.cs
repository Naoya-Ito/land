using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour{
  private bool isButtonPushed = false;
  public void PushButton() {
    if(isButtonPushed) return;
    isButtonPushed = true;
    
    hideButton();

    updateDate();
    CommonUtil.changeScene("PVScene");
  }

  private void updateDate(){
    int day = DataMgr.GetInt("day");
    int next_day = day/10*10 + 10;
    DataMgr.SetInt("day", next_day);
    DataMgr.SetStr("pv_text", $"{next_day}日目");
    BGMMgr.instance.stopMusic();
  }

  private void hideButton(){
    for (int i = 0; i < 6; i++) {
      GameObject button = GameObject.Find($"ChoiceButton{i+1}");
      if(button != null) {
        button.SetActive(false);
      }
    }
  }
}