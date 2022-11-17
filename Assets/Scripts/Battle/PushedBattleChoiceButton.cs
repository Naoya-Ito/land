using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushedBattleChoiceButton : MonoBehaviour{

  private bool isButtonPushed = false;
  public void PushButton(int number) {
    if(isButtonPushed || CommonUtil.isPV()) {
      return;
    }
    isButtonPushed = true;

    switch(BattleMgr.instance.phase) {
      case "win_reward":
        BattleMgr.instance.phase = "win_card";
        CommonUtil.changeScene("BattleWinScene", 0.0f);
        break;
      case "op":
        if(BattleMgr.instance.isFirst()){
          CommonUtil.changeScene("BattleCardScene", 0.0f);    
        } else {
          CommonUtil.changeScene("BattleShootingScene", 0.0f);    
        }
        break;
      default:
        CommonUtil.changeScene("BattleShootingScene", 0.0f);    
        break;
    }
  }
}