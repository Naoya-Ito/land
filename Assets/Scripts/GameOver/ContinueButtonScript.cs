using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 死亡時の処理
public class ContinueButtonScript : MonoBehaviour{
  private bool isButtonPushed = false;
  public void PressStart(){
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

    //regeneratePlayer();

    CommonUtil.changeScene("TitleScene");
//    BGMMgr.instance.changeBGM("title");
  }

  private void regeneratePlayer(){
    DataMgr.countUpDeath();
    DataMgr.maxHeadl();
    switch(DataMgr.GetInt("dead_count")){
    case 1:
      DataMgr.SetStr("event_key", "church/first_dead");
      break;
    default:
      DataMgr.SetStr("event_key", "church/reborn");
      break;
    }
  }
}
