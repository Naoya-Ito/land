using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour {

  void Start(){
    BattleMgr.instance.updateBattleDataScene();
    switch(BattleMgr.instance.phase){
      case "op":
        DataMgr.Increment("war", BattleMgr.instance.enemy.lv);
        if(BattleMgr.instance.enemy.enemyID == "ozumi") BattleMgr.instance.player_hp = 1;
        updateScene();
        break;
      case "win":
        SetAchievement();
        updateScene();
        fadeScene();
        hideButton();
        Invoke("toWinPage", 3.0f);
        break;
      case "win_reward":
        BGMMgr.instance.changeBGM("win");
        updateScene();
        break;
      case "lose":
        updateScene();
        hideButton();
        fadeScene();
        Invoke("toLosePage", 5.0f);
        break;
      default:
        break;
    }
  }


  private void fadeScene(){
    CenterArea.fadeOutImage();
    CenterArea.fadeOutTextArea();
  }

  public void updateScene(){
    switch(BattleMgr.instance.phase) {
      case "op":
        CommonUtil.changeImage("event_image", BattleMgr.instance.enemy.image);
        if(BattleMgr.instance.enemy.start_text != "") {
          CommonUtil.changeText("event_text", BattleMgr.instance.enemy.start_text);
        } else {
          CommonUtil.changeText("event_text", $"{BattleMgr.instance.enemy.name}が現れた。");
        }
        if(BattleMgr.instance.isFirst()) {
          CommonUtil.changeText("choiceText1", "攻撃をしかける");
        } else {
          CommonUtil.changeText("choiceText1", "攻撃が……来る！");
        }
        break;
      case "win":
        CommonUtil.changeImage("event_image", BattleMgr.instance.enemy.image);
        CommonUtil.changeText("event_text", BattleMgr.instance.enemy.dead_text);
        break;
      case "win_reward":
        CenterArea.hidePlace();
        CenterArea.hideChara();
        int get_gold = BattleMgr.instance.enemy.lv;
        CommonUtil.changeText("event_text", $"君は{get_gold}の<sprite name=\"gold\">を得た。");
        CommonUtil.changeText("choiceText1", "次へ");
        CommonUtil.changeImage("event_image", "treasure");
        BattleMgr.instance.changePlayerParams("gold", get_gold);
        break;
      case "lose":
        CommonUtil.changeImage("event_image", BattleMgr.instance.enemy.image);
        CommonUtil.changeText("event_text", "目の前が暗くなる……。\n君はもう立ち上がれない。");
        BattleMgr.instance.saveLoseData();
        break;
      default:
        break;
    }

    LifeBar.updateLifeBar(BattleMgr.instance.player_hp, BattleMgr.instance.player_max_hp);
    RightArea.updateGold(BattleMgr.instance.gold);

//    changeImage("event_image", getImage());
//    changeBg("event_bg", model.bg);

//    SetButton.initButton(model.choices);
  }

  private void toWinPage(){
    BattleMgr.instance.phase = "win_reward";
    CommonUtil.changeScene("BattleScene");
  }

  private void toLosePage(){
    BGMMgr.instance.stopMusic();
    CommonUtil.changeScene("GameScene");
  }

  private void hideButton(){
    GameObject button = GameObject.Find("ChoiceButton1");
    button.SetActive(false);
  }

  private void SetAchievement(){
    if(!BattleMgr.instance.enemy.isBoss) return;

    string enemyID = BattleMgr.instance.enemy.enemyID;
    switch(enemyID) {
      case "dark_knight":
        DataMgr.SetBool("first_dark_knight_win", true);
        DataMgr.SetBool("dark_knight_win", true);
        SteamMgr.setAchievement("BEAT_BOSS_DAY5");
        break;
      case "skelton_king":
        DataMgr.SetBool("first_skelton_king_win", true);
        SteamMgr.setAchievement("BEAT_BOSS_GAMOS");
        break;
      case "majo":
        DataMgr.SetBool("first_majo_win", true);
        SteamMgr.setAchievement("BEAT_BOSS_MAJO");
        break;
      case "ozumi":
        DataMgr.SetBool("first_ozumi_win", true);
        SteamMgr.setAchievement("BEAT_BOSS_OZUMI");
        break;
      case "yogi":
        DataMgr.SetBool("first_yogi_win", true);
        SteamMgr.setAchievement("BEAT_BOSS_YOGI");
        break;
      case "egoda":
        DataMgr.SetBool("first_egoda_win", true);
        SteamMgr.setAchievement("BEAT_BOSS_EGODA");
        break;
      case "brave":
        DataMgr.SetBool("first_brave_win", true);
        SteamMgr.setAchievement("BEAT_BOSS_80");
        break;
      case "igunius":
        DataMgr.SetBool("first_igni_win", true);
        SteamMgr.setAchievement("BEAT_BOSS_90");
        break;
      case "angel":
        DataMgr.SetBool("first_angel_win", true);
        SteamMgr.setAchievement("ENDING_B");
        break;
      case "necro":
        DataMgr.SetBool("first_necro_win", true);
        SteamMgr.setAchievement("BEAT_BOSS_100");
        break;
      default:
        break;
    }
  }
}
