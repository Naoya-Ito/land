using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour{
  
  public static BattleMgr instance = null;
  public EnemyModel enemy;

  public string phase = "op"; // op, death, enemy_attack, player_attack, win

  public int player_hp = 1;
  public int player_max_hp = 1;
  public int mp = 0;
  public int str = 1;
  public int mgi = 1;
  public int agi = 1;
  public int def = 0;
  public int luck = 1;
  public int gold = 1;
  public int shield = 0;
  public int tear = 1;
  public int faith = 1;
  public int turn = 1;
  public bool is_battle_end = false;
  public List<string> pile;
  public List<string> drop;

  public bool is_jagan = false;

  // 戦闘終了後、セーブを行う
  // 勝利処理
  // 敗北処理

  // 処理時、場所や人名、キャラ画像は非表示にする

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  void Start(){
    DontDestroyOnLoad(this);
    initBattleData();
  }

  void Update(){      
  }

  public void battleEnd(){
    Destroy(this.gameObject);
  }

  public int getPlayerParams(string key){
    switch(key){
      case "str":
        return str;
      case "mgi":
        return mgi;
      case "agi":
        return agi;
      case "luck":
        return luck;
      case "gold":
        return gold;
      case "tear":
        return tear;
      case "faith":
        return faith;
      case "def":
        return def;
      default:
        return 99;
    }
  }

  public void changePlayerParams(string key, int val) {
    switch(key){
      case "str":
        str = str + val;
        break;
      case "mgi":
        mgi = mgi + val;
        break;
      case "agi":
        agi = agi + val; 
        break;
      case "luck":
        luck = luck + val;
        break;
      case "gold":
        gold = gold + val;
        break;
      case "tear":
        tear = tear + val;
        break;
      case "faith":
        faith = faith + val;
        break;
      case "def":
        def = def + val;
        break;
      default:
        break;
    }
    LeftArea.updateBattleStatus();
  }

  private bool isInit = false;
  private void initBattleData(){
    if(isInit) {
      return;
    }

    isInit = true;

    pile = DataMgr.GetList("deck");
    CommonUtil.shuffleList(pile);

    enemy = new EnemyModel(DataMgr.instance.battle_info.enemy_name);
    if(CommonUtil.isPV()){
      setPVData();
    } else {
      setPlayerData();
    }
  }

  private void setPlayerData(){
    player_hp = DataMgr.GetInt("hp");
    player_max_hp = DataMgr.GetInt("max_hp");
    gold = DataMgr.GetInt("gold");
    str = DataMgr.GetInt("str");
    mgi = DataMgr.GetInt("mgi");        
    agi = DataMgr.GetInt("agi");        
    luck = DataMgr.GetInt("luck");        
    tear = DataMgr.GetInt("tear");        
    faith = DataMgr.GetInt("faith");        
  }

  private void setPVData(){
    player_hp = 33;
    player_max_hp = 33;
    gold = 215;
  }

  public void updateBattleDataScene(){
    LeftArea.updateBattleStatus();
    RightArea.updateBattleStatus();
    RightArea.hideSkillButton();

    if(BattleMgr.instance != null) {
      updateShield();
    }
    CommonUtil.changeText("place_text", "");
    CommonUtil.changeImage("event_bg", "no");
  }

  public void updateShield(){
    CommonUtil.changeText("chara_text", BattleMgr.instance.enemy.name);
    if(BattleMgr.instance.def > 0) {
      LifeBar.showDef(BattleMgr.instance.def);
    } else {
      LifeBar.hideDef();
    }
  }

  public EnemyAttackModel getAttackModel(){
    return enemy.attacks[(turn-1)%enemy.attacks.Length];
  }

  public void damaged(int val){
    if(val <= 0 ) {
      player_hp -= 1;      
    } else {
      player_hp -= val;
    }

    if(player_hp < 0) player_hp = 0;
  }

  public void heal(int val) {
    player_hp += val;
    if(player_hp > player_max_hp) player_hp = player_max_hp;
    lifeBarUpdate();
  }

  public bool isFirst(){
    if(BattleMgr.instance.enemy.isTrap) return false;
    return DataMgr.GetInt("agi") > BattleMgr.instance.enemy.lv;    
  }

  public bool isWin(){
    return enemy.hp <= 0;
  }

  public bool isDead(){
    return player_hp <= 0;
  }

  public void win(){
    is_battle_end = true;
    phase = "win";
  }

  public void lose(){
    is_battle_end = true;
    phase = "lose";
  }

  public void saveData(){
    DataMgr.instance.battle_info = null;
  }

  private void saveCommonData(){
    DataMgr.SetInt("gold", gold);
    DataMgr.SetInt("hp", player_hp);

    foreach (string card_name in drop){
      pile.Add(card_name);
    }
/*
    var str = string.Join(",", pile);
    Debug.Log($"pile={str}");
    */

    DataMgr.SetList("deck", pile);
  }

  public void saveWinData(){
    if(DataMgr.instance.battle_info != null) {
      DataMgr.SetStr("event_key", DataMgr.instance.battle_info.win_page);
    }
    saveCommonData();
    saveData();
  }

  public void saveLoseData(){
    if(DataMgr.instance.battle_info != null && DataMgr.instance.battle_info.lose_page != "") {
      DataMgr.SetStr("event_key", DataMgr.instance.battle_info.lose_page);
    } else {
      DataMgr.SetStr("event_key", "dead/lose");
    }
    saveCommonData();
    saveData();
    battleEnd();
  }

  public void getCardEnd(string key){
    pile.Add(key);
    BattleMgr.instance.saveWinData();
    BattleMgr.instance.battleEnd();
    CommonUtil.changeScene("GameScene");
  }

  public void lifeBarUpdate(){
    LifeBar.updateLifeBar(BattleMgr.instance.player_hp, BattleMgr.instance.player_max_hp);
  }

  public void jagan(){
    str = 1;
    mgi = 1;
    agi = 1;
    luck = 1;
  }
}
