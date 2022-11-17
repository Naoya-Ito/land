using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{

  private void Start(){
    // 初回時のみ、初期データを作る
    if(!DataMgr.GetBool("is_start")) {
      Destroy(gameObject);
    }
  }

  private bool isButtonPushed = false;
  public void PressStart(){
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

    DataMgr.SetBool("pv_mode", false);

    newGameWithData();
    CommonUtil.changeScene("NewGameScene");
  }

  // 強くてニューゲーム時
  public static void newGameWithData(){
    DataMgr.SetInt("day", 1);
    DataMgr.SetInt("war", 0);
    DataMgr.SetInt("choice", 0);

    if(!SkillModel.isGetSkill("hoken")) DataMgr.SetInt("gold", 0);

    // ステータス初期化
    DataMgr.SetInt("max_hp", 10);
    DataMgr.SetInt("hp", 10);
    DataMgr.SetInt("str", 1);
    DataMgr.SetInt("mgi", 1);
    DataMgr.SetInt("agi", 1);
    DataMgr.SetInt("luck", 1);
    DataMgr.SetInt("faith", 1);
    DataMgr.SetInt("tear", 100);
    DataMgr.SetInt("guilty", 0);
    DataMgr.SetInt("bonus", 0);
    DataMgr.SetInt("soul_minus", 0);

    // ボス戦の結果
    DataMgr.SetBool("dark_knight_win", false);

    // フラグ初期化
    DataMgr.SetBool("is_guilty", false);
    DataMgr.SetBool("arisia_quuest", false);
    DataMgr.SetBool("arisia_quuest_comp", false);
    DataMgr.SetBool("arisia_end", false);
    DataMgr.SetBool("drag", false);
    
    // 死者を復活
    DataMgr.SetBool("father_dead", false);
    DataMgr.SetBool("inn_dead", false);
    DataMgr.SetBool("guard_dead", false);
    DataMgr.SetBool("boy_dead", false);

    // デッキ初期化
    initDeck();

    // 全てのスキルを忘れる
    /*
    foreach(string key in SkillModel.all_list) {
      DataMgr.SetBool($"skill_{key}", false);
    }
    */
  }

  public static void initDeck(){
    List<string> deck = new List<string>() {
      "punch", "punch", "punch", "mini_sword", "mini_sword",
      "fire", "mgi_up", "str_up", "yakusou", "yakusou"
    };
    DataMgr.SetList("deck", deck);

  }
}
