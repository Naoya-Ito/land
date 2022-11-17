using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndPushed : MonoBehaviour{
  private bool isButtonPushed = false;
  public void PushButton() {
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

    execTurnEndSkill();

    BattleCardMgr.instance.dropAllCard();

    BattleMgr.instance.enemy = BattleCardMgr.instance.enemy;
    BattleMgr.instance.pile = BattleCardMgr.instance.pile;
    BattleMgr.instance.drop = BattleCardMgr.instance.drop;
    BattleMgr.instance.mp = BattleCardMgr.instance.mp;

    if(BattleMgr.instance.isDead() ) {
      BattleMgr.instance.lose();
      CommonUtil.changeScene("BattleScene");
    } else if (BattleMgr.instance.isWin()){
      BattleMgr.instance.win();
      CommonUtil.changeScene("BattleScene");
    } else {
      BattleMgr.instance.phase = "attacked";    
      CommonUtil.changeScene("BattleShootingScene");
    }
  }

  private void execTurnEndSkill(){
    if(SkillModel.isGetSkill("keikai")) {
      BattleMgr.instance.def += BattleCardMgr.instance.mp;
    }
    if(SkillModel.isGetSkill("meisou")) {
      BattleMgr.instance.changePlayerParams("mgi", 2);
    }
    if(SkillModel.isGetSkill("power")) {
      BattleMgr.instance.changePlayerParams("str", BattleMgr.instance.def);
    }
  }

}
