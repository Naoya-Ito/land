using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVModel : MonoBehaviour{

  public const int STEP_PV_FIRST = 1;
  public const int STEP_GAME_WHERE = 2;
  public const int STEP_PV_SOKO = 3;
  public const int STEP_GAME_ZOMBI = 4;
  public const int STEP_GAME_IGNI = 5;
  public const int STEP_GAME_KING = 6;
  public const int STEP_PV_HERO = 7;
  public const int STEP_GAME_HIGAI = 8;
  public const int STEP_PV_EVIL = 9;
  public const int STEP_GAME_THIEF = 10;
  public const int STEP_PV_DEAD = 11;
  public const int STEP_GAME_JUDGE = 12;
  public const int STEP_PV_DEATH = 13;
  public const int STEP_GAME_ANGEL = 14;
  public const int STEP_CHOICE_HWART = 15;
  public const int STEP_PV_GOD = 16;
  public const int STEP_GAME_GOD = 17;
  public const int STEP_PV_VS_GOD = 18;
  public const int STEP_BATTLE_ANGEL = 19;
  public const int STEP_BATTLE_CARD = 20;
  public const int STEP_PV_VS_GUARD = 21;
  public const int STEP_BATTLE_GUARD = 22;
  public const int STEP_PV_VS_BRAVE = 23;
  public const int STEP_BATTLE_BRAVE = 24;
  public const int STEP_PV_VS_EGODA = 25;
  public const int STEP_BATTLE_EGODA = 26;
  public const int STEP_PV_YOUR_SAGA = 27;
  public const int STEP_BATTLE_IGNI = 28;
  public const int STEP_PV_YOUR_END = 29;
  public const int STEP_PV_TITLE = 30;

  static public EnemyModel getEnemyModel(){
    int pv_level = DataMgr.GetInt("pv_level");;
    string enemy_name;
    switch(pv_level){
      case STEP_BATTLE_ANGEL:
        BGMMgr.instance.changeBGM("battle_god");
        enemy_name = "angel";
        break;
      case STEP_BATTLE_GUARD:
        enemy_name = "guard";
        break;
      case STEP_BATTLE_BRAVE:
        enemy_name = "brave";
        break;
      case STEP_BATTLE_EGODA:
        enemy_name = "egoda";
        break;
      case STEP_BATTLE_IGNI:
        enemy_name = "igunius";
        break;
      default:
        enemy_name = "brave";
        Debug.Log($"unknown pv level. pv_level={pv_level}");
      break;
    }
    return new EnemyModel(enemy_name);
  }

  static public void setPVSetting(){
    int pv_level = DataMgr.GetInt("pv_level");;
    string scene_name;
    switch(pv_level){
      case STEP_PV_FIRST:
        DataMgr.SetStr("pv_text", "大いなる災厄まで100日");
        break;
      case STEP_PV_SOKO:
        DataMgr.SetStr("pv_text", "そこは不死者が徘徊する王国。\n安全な場所はどこにもない。");
        break;
      case STEP_PV_HERO:
        DataMgr.SetStr("pv_text", "君は王国を救う勇者となっても良いし");
        break;
      case STEP_PV_EVIL:
        DataMgr.SetStr("pv_text", "君は国を脅かす大罪人になっても良い。");
        break;
      case STEP_PV_DEAD:
        DataMgr.SetStr("pv_text", "選択を誤れば君は死ぬ。");
        break;
      case STEP_PV_DEATH:
        DataMgr.SetStr("pv_text", "黒き天使は君に契約を望む。");
        break;
      case STEP_PV_GOD:
        DataMgr.SetStr("pv_text", "君は強大な力を神のために使っても良いし……");
        break;
      case STEP_PV_VS_GOD:
        BGMMgr.instance.stopMusic();
        DataMgr.SetStr("pv_text", "神に叛逆しても良い。");
        break;
      case STEP_PV_VS_GUARD:
        DataMgr.SetStr("pv_text", "雪のように白く");
        break;
      case STEP_PV_VS_BRAVE:
        DataMgr.SetStr("pv_text", "血のように緋く");
        break;
      case STEP_PV_VS_EGODA:
        DataMgr.SetStr("pv_text", "闇のように黒く");
        break;
      case STEP_PV_YOUR_SAGA:
        DataMgr.SetStr("pv_text", "不死者との物語の結末は");
        break;
      case STEP_PV_YOUR_END:
        DataMgr.SetStr("pv_text", "君が決める。");
        break;
      default:
        Debug.Log($"unknown pv level. pv_level={pv_level}");
        break;
    }
  }

  static public string getNextSceneName(){
    int pv_level = DataMgr.GetInt("pv_level");;
    string scene_name;
    switch(pv_level){
      case STEP_PV_FIRST:
        BGMMgr.instance.changeBGM("op2");
        //DataMgr.SetStr("pv_page", "op/op2");
        DataMgr.SetStr("pv_page", "yogen/start");
        scene_name = "GameScene";
        break;
      case STEP_GAME_WHERE:
        scene_name = "PVScene";
        break;
      case STEP_PV_SOKO:
        DataMgr.SetStr("pv_page", "op/zombi_first");
        scene_name = "GameScene";
        break;
      case STEP_GAME_ZOMBI:
        DataMgr.SetStr("pv_page", "igni/about_kingdom");
        scene_name = "GameScene";
        break;
      case STEP_GAME_IGNI:
        scene_name = "GameScene";
        DataMgr.SetStr("pv_page", "castle_king/order");
        break;
      case STEP_GAME_KING:
        scene_name = "PVScene";
        break;
      case STEP_PV_HERO:
        DataMgr.SetStr("pv_page", "arisia/talk");
        scene_name = "GameScene";
        break;
      case STEP_GAME_HIGAI:
        scene_name = "PVScene";
        break;
      case STEP_PV_EVIL:
        DataMgr.SetStr("pv_page", "ura/thief_party");
        scene_name = "GameScene";
        break;
      case STEP_GAME_THIEF:
        scene_name = "PVScene";
        break;
      case STEP_PV_DEAD:
        DataMgr.SetStr("pv_page", "judge/to_death2");
        scene_name = "GameScene";
        break;
      case STEP_GAME_JUDGE:
        scene_name = "PVScene";
        break;
      case STEP_PV_DEATH:
        DataMgr.SetStr("pv_page", "angel/contract");
        scene_name = "GameScene";
        break;
      case STEP_GAME_ANGEL:
        //scene_name = "CharacterCreateScene";
        scene_name = "GameOverScene";
        break;
      case STEP_CHOICE_HWART:
        scene_name = "PVScene";
        break;
      case STEP_PV_GOD:
        DataMgr.SetStr("pv_page", "church/sister");
        scene_name = "GameScene";
        break;
      case STEP_GAME_GOD:
        scene_name = "PVScene";
        break;
      case STEP_PV_VS_GOD:
        scene_name = "BattleShootingScene";
        break;
      case STEP_BATTLE_ANGEL:
        scene_name = "BattleCardScene";
        break;
      case STEP_BATTLE_CARD:
        scene_name = "PVScene";
        break;
      case STEP_PV_VS_GUARD:
        scene_name = "BattleShootingScene";
        break;
      case STEP_BATTLE_GUARD:
        scene_name = "PVScene";
        break;
      case STEP_PV_VS_BRAVE:
        scene_name = "BattleShootingScene";
        break;
      case STEP_BATTLE_BRAVE:
        scene_name = "PVScene";
        break;
      case STEP_PV_VS_EGODA:
        scene_name = "BattleShootingScene";
        break;
      case STEP_BATTLE_EGODA:
        scene_name = "PVScene";
        break;
      case 100:
        scene_name = "BattleShootingScene";
        break;
      case STEP_PV_YOUR_SAGA:
        scene_name = "BattleShootingScene";
        break;
      case STEP_BATTLE_IGNI:
        scene_name = "PVScene";
        break;
      case STEP_PV_YOUR_END:
        scene_name = "TitleScene";
        break;
      default:
        scene_name = "PVScene";
        Debug.Log($"unknown pv level. pv_level={pv_level}");
        break;
    }
    return scene_name;
  }

  static public float getPVWaitTime(){
    float wait_time = 2.0f;
    if(DataMgr.GetInt("pv_level") >= STEP_PV_VS_GUARD) {
      wait_time = 1.3f;
    }
    return wait_time;
  }

  static public void setPVStatus(){
    LifeBar.updateLifeBar(CommonUtil.rnd(32), CommonUtil.rnd(32)+32);
    RightArea.updateGold(CommonUtil.rnd(100));

    CommonUtil.changeText("str_text", $"<sprite name=\"str\"> {CommonUtil.rnd(12)}");
    CommonUtil.changeText("mgi_text", $"<sprite name=\"mgi\"> {CommonUtil.rnd(12)}");
    CommonUtil.changeText("agi_text", $"<sprite name=\"agi\"> {CommonUtil.rnd(12)}");
    CommonUtil.changeText("faith_text", $"<sprite name=\"faith\"> {CommonUtil.rnd(12)}");
    CommonUtil.changeText("luck_text", $"<sprite name=\"luck\"> {CommonUtil.rnd(12)}");
    CommonUtil.changeText("tear_text", $"<sprite name=\"tear\"> {CommonUtil.rnd(100)}");
    CommonUtil.changeText("gold_text", $"<sprite name=\"gold\"> {CommonUtil.rnd(1001)}G");
  }

  static public List<string> getPVHand(){
    List<string> pile = new List<string>() { "punch", "mini_sword", "ice_sword", "guard", "fire" };
    return pile;
  }


}
