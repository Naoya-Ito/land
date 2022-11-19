using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class StartButtonModel : MonoBehaviour
{

  private void  Start(){
    if(DataMgr.GetBool("is_start")) {
      CommonUtil.changeText("start_text", "冒険を再開する");
    }
  }

  private bool isButtonPushed = false;
  public void PressStart(){
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

    DataMgr.SetBool("pv_mode", false);
//    BGMMgr.instance.changeBGM("field");
    BGMMgr.instance.stopMusic();

    // 初回時のみ、初期データを作る
    if(!DataMgr.GetBool("is_start")) {
      createInitData();

      // TODO opストーリーシーンに行く
      CommonUtil.changeScene("GameScene");
    } else {
      CommonUtil.changeScene("GameScene");
    }
  }

  private void createInitData(){
    DataMgr.SetBool("is_start", true);
    DataMgr.SetInt("day", 1);

    DataMgr.SetStr("party", "");
    DataMgr.SetInt("max_hp", 10);
    DataMgr.SetInt("hp", 10);
    DataMgr.SetInt("day", 1);
    DataMgr.SetInt("str", 1);
    DataMgr.SetInt("agi", 1);
    DataMgr.SetInt("luck", 1);
  }
}
