using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class StartButtonModel : MonoBehaviour
{

  private void  Start(){
    if(DataMgr.GetBool("new_game")) {
      Destroy(gameObject);
      return;
    }
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
      CommonUtil.changeScene("PVScene");
    } else {
      if(DataMgr.GetBool("new_game")) {
        NewGameButton.newGameWithData();
        CommonUtil.changeScene("NewGameScene");
      } else {
        CommonUtil.changeScene("GameScene");
      }
    }
  }

  private void createInitData(){
    DataMgr.SetBool("is_start", true);
    PlayerPrefs.SetInt("is_start", 1);

    //PlayerPrefs.SetString("event_key", "town/start");

    PlayerPrefs.SetInt("dead_count", 0);
    PlayerPrefs.SetInt("day", 1);
    PlayerPrefs.SetInt("war", 0);
    PlayerPrefs.SetInt("choice", 0);
    DataMgr.SetStr("pv_text", $"1日目");

    // 周回要素
    PlayerPrefs.SetInt("soul", 0);
    DataMgr.SetInt("str_up", 0);
    DataMgr.SetInt("mgi_up", 0);
    DataMgr.SetInt("agi_up", 0);
    DataMgr.SetInt("luck_up", 0);
    DataMgr.SetInt("gold_up", 0);
    DataMgr.SetInt("income", 0);

    NewGameButton.initDeck();

    DataMgr.SetStr("party", "");

    DataMgr.SetInt("max_hp", 10);
    DataMgr.SetInt("hp", 10);
    DataMgr.SetInt("day", 1);
    DataMgr.SetInt("str", 1);
    DataMgr.SetInt("mgi", 1);
    DataMgr.SetInt("agi", 1);
    DataMgr.SetInt("luck", 1);
    DataMgr.SetInt("faith", 1);
    DataMgr.SetInt("tear", 100);
    DataMgr.SetInt("bonus", 0);
  }
}
