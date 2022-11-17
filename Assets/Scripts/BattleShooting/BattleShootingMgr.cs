using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShootingMgr : MonoBehaviour{

  public bool isTurnEnd = false;
  private EnemyModel enemy;
  private EnemyAttackModel attackModel;
  private bool isDebug = false;
  private float startTime = 3.5f;
  private float battleTime = 6.0f;

  void Start(){
    if(CommonUtil.isPV()) {
      PVModel.setPVStatus();
      battleTime = 15.0f;
      RightArea.hideSkillButton();
      updatePVScene();
      Invoke("execPV", startTime + battleTime);
    } else if(BattleMgr.instance != null) {
      BattleMgr.instance.updateBattleDataScene();
      attackModel = BattleMgr.instance.getAttackModel();
      updateScene();
      Invoke("turnEnd", startTime + battleTime);
    } else {
      isDebug = true;
      updateDebugScene();
      Invoke("turnEnd", startTime + battleTime);
    }
    LeftArea.fadeOut();
    RightArea.fadeOut();
    CenterArea.fadeOutAll();
  }

  private void updateScene(){
    enemy = BattleMgr.instance.enemy;
//    Debug.Log($"enemy_image={enemy.image}");

    CommonUtil.changeText("chara_text", enemy.name);
    CommonUtil.changeText("place_text", "");
    CommonUtil.changeText("event_text", attackModel.attack_text);
    CommonUtil.changeImage("event_image", enemy.image);
//    LifeBar.updateLifeBar(BattleMgr.instance.player_hp, BattleMgr.instance.player_max_hp);
  }

  private void updatePVScene(){
    enemy = PVModel.getEnemyModel();
    attackModel = enemy.attacks[0];
    CommonUtil.changeImage("event_image", enemy.image);
    CommonUtil.changeText("event_text", attackModel.attack_text);
    PVModel.setPVStatus();
  }

  private void updateDebugScene(){
    enemy = PVModel.getEnemyModel();
    attackModel = enemy.attacks[0];
    CommonUtil.changeImage("event_image", enemy.image);
    CommonUtil.changeText("event_text", attackModel.attack_text);
  }

  void turnEnd(){
    if(isDebug || isTurnEnd) {
      return;
    }

    BattleMgr.instance.def = 0;

//    if(isTurnEnd || BattleMgr.instance.isDead()) {
    if(BattleMgr.instance.player_hp <= 0) return;

    if(BattleMgr.instance.enemy.isTrap) {
      trapEnd();
      return;
    }

    isTurnEnd = true;

    BattleMgr.instance.phase = "player_attack";
    BattleMgr.instance.turn += 1;

    // isDead
    // CommonUtil.changeScene("BattleCardScene");
    CommonUtil.changeScene("BattleCardScene");
  }

  private void trapEnd(){
    BattleMgr.instance.saveWinData();
    BGMMgr.instance.stopMusic();

    CommonUtil.changeScene("GameScene");
  }

  private void execPV(){
    int pv_level = DataMgr.GetInt("pv_level");
    string next_scene = PVModel.getNextSceneName();
    DataMgr.Increment("pv_level");
    CommonUtil.changeScene(next_scene);
  }
}
