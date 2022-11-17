using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleCardMgr : MonoBehaviour{
  [SerializeField] CardController cardPrefab;
  [SerializeField] public Transform playerHand;

  public static BattleCardMgr instance = null;
  public EnemyModel enemy;
  public int mp;
  public List<string> pile;
  public List<string> drop;

  public FadeoutImageObject fadeMessage;
  public FadeoutTextObject fadeMessageText;
  public TextMeshProUGUI flash_text;
  public GameObject fadeArea;

  private int play_count = 0;
  private bool is_mikiri = false;

  // 死亡時にカード引けないバグ

  // 通常時、カード入手
  // 通常時、カード表示

  // デッキのシャッフル
  // 捨て札のターン跨ぎ
  // 自分のデッキ確認
  // ドローのアニメーション
  // 使用後のアニメーション
  // 消滅のアニメーション
  // ゴールドの表示変更

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  void Start(){
    if(BattleMgr.instance != null) {
      BattleMgr.instance.updateBattleDataScene();
      if(BattleMgr.instance.isDead()){
        BattleMgr.instance.lose();
        CommonUtil.changeScene("BattleScene");
        return;
      }
    }

    setDeck();


    if(BattleMgr.instance.enemy.enemyID == "arisis") {
      CreateCard("sword_white", playerHand);
    } else {
      drawCard();
    }
    drawCard();
    drawCard();
    drawCard();
    drawCard();

    loadEnemy();
    updateEnemyLife();

    if(CommonUtil.isPV()) {
      mp = 0;
      PVModel.setPVStatus();
      Invoke("execPV", 3);
    } else if(BattleMgr.instance == null) {
      mp = 0;
      PVModel.setPVStatus();
    } else {
      if(BattleMgr.instance.enemy.enemyID == "majo" && !BattleMgr.instance.is_jagan) {
        flashMessage("邪眼が君を見つめている！");
        if(!SkillModel.isGetSkill("jagan")) BattleMgr.instance.jagan();

        BattleMgr.instance.is_jagan = true;
        updateAllCard();
      }

      mp = BattleMgr.instance.mp;
      execTurnStartSkill();
      LeftArea.updateBattleStatus();
      RightArea.updateBattleStatus();
      BattleMgr.instance.lifeBarUpdate();

    }
    mp += 3;
    if(SkillModel.isGetSkill("mp_boost")) mp += 1;

    updateScene();
  }

  private void execTurnStartSkill(){
    if(SkillModel.isGetSkill("def")) BattleMgr.instance.changePlayerParams("def", 1);

    if(SkillModel.isGetSkill("ikari")) BattleMgr.instance.changePlayerParams("str", 1);
    
    if(SkillModel.isGetSkill("teate")) BattleMgr.instance.heal(1);

    if(SkillModel.isGetSkill("first_attack")){
      int agi = BattleMgr.instance.agi;
      dealDamage(agi);
      ImagesEffect.createEffect(0, 1.4f, "SwordEffect");
    }
  }

  private void setDeck(){
    if(CommonUtil.isPV() || BattleMgr.instance == null){
      pile = PVModel.getPVHand();
    } else {
      pile = BattleMgr.instance.pile;
      drop = BattleMgr.instance.drop;
    }
  }

  public void drawCard(){
    // FIXME shuffle animation
    if(pile.Count <= 0) {
      shufflleCard();
      if(pile.Count == 0) {
        return;
      }
    }

    CreateCard(pile[0], playerHand);

    pile.RemoveAt(0);
    updatePileDrop();
    updateAllCard();
  }

  public void getCard(string key){
    CreateCard(key, playerHand);
    updatePileDrop();
    updateAllCard();

    if(key == "curse" && SkillModel.isGetSkill("dark")) {
      BattleMgr.instance.str += 6;
    }
  }

  private void shufflleCard(){
    pile = drop;
    CommonUtil.shuffleList(pile);
    drop = new List<string>() {}; 
  }

  public void playCard(CardController card_controller){
    CardModel card_model = card_controller.model;
    mp -= card_model.cost;
    CommonUtil.changeText("mp", $"MP{mp}");
    if(BattleMgr.instance.enemy.enemyID == "brave" && !is_mikiri) {
    } else {
      NormalCardUse.useCard(card_model.cardID);
    }

    // TODO 消滅アニメーション
    if(card_model.isDelete) {
      Destroy(card_controller.gameObject);
      if(SkillModel.isGetSkill("renkin")) {
        BattleMgr.instance.gold += 10;
        RightArea.updateBattleStatus();
      }
    } else {
      if(card_model.cardID != "sword_white") dropCard(card_model.cardID);
    }
    BattleCardMgr.instance.DropCardView(card_controller);
    if(BattleMgr.instance.enemy.enemyID == "brave" && !is_mikiri) {
      flashMessage("「見切った！」");
      is_mikiri = true;
      updateAllCard();
      return;
    }
    useCardSkill();

    updateAllCard();
    if(BattleCardMgr.instance.isWin()){
      Invoke("win", 0.3f);
      LeftArea.updateBattleStatus();
      return;
    }

    if(BattleMgr.instance.enemy.enemyID == "egoda") {
      BattleMgr.instance.enemy.str *= 2;
      flashMessage("「この恨み、忘れねぇ」");
    }
    play_count += 1;
    if(play_count == 4 && SkillModel.isGetSkill("thief")) {
      BattleMgr.instance.agi *= 2;
    }
    if(card_model.cost == 2 && SkillModel.isGetSkill("wizard")) {
      BattleMgr.instance.mgi += 7;
    }
    LeftArea.updateBattleStatus();
  }

  private void win(){
    dropAllCard();
    var str = string.Join(",", drop);
    var str_pile = string.Join(",", pile);
    BattleMgr.instance.pile = pile;
    BattleMgr.instance.drop = drop;

    BattleMgr.instance.win();
    CommonUtil.changeScene("BattleScene");
  }

  public void cantPlayCard(){
    flashMessage("くっ、MPが足りぬ");
  }

  private void flashMessage(string text){
    Vector3 now_pos = fadeArea.transform.position;
    fadeArea.transform.position = new Vector3(0, now_pos.y, now_pos.z);
    Invoke("hideFlashMessage", 4.0f);

    flash_text.text = text;
    fadeMessage.show();
    fadeMessage.fadeStart();
    fadeMessageText.show();
    fadeMessageText.fadeStart();
  }

  private void hideFlashMessage(){
    Vector3 now_pos = fadeArea.transform.position;
    fadeArea.transform.position = new Vector3(2000, now_pos.y, now_pos.z);
  }

  private void useCardSkill(){
    if(SkillModel.isGetSkill("knife")){
      dealDamage(1);
    }
  }

  public void updateAllCard(){
    CardController[] hands = playerHand.GetComponentsInChildren<CardController>();
    foreach (CardController card in hands){
      card.updateAll();
    }
  }

  public void updatePileDrop(){
    CommonUtil.changeText("pile_text", $"{pile.Count}");
    CommonUtil.changeText("drop_text", $"{drop.Count}");
  }


  public void dropCard(string cardID){
    if(cardID == "sword_white") return;

    drop.Add(cardID);
    updatePileDrop();
    // FIXME drop animation
  }

  public void dropAllCard(){
    CardController[] hands = playerHand.GetComponentsInChildren<CardController>();
    foreach (CardController card in hands){
      dropCard(card.model.cardID);
    }
  }

  private void loadEnemy(){
    if(CommonUtil.isPV()) {
      enemy = new EnemyModel("shield_knight");
    } else if(BattleMgr.instance == null)  {
      enemy = new EnemyModel("shield_knight");
    } else {
      enemy = BattleMgr.instance.enemy;
    }
  }

  private void updateScene(){
    CenterArea.hideTextArea();
    CommonUtil.changeImage("event_image", enemy.image);
    CommonUtil.changeText("chara_text", enemy.name);
    CommonUtil.changeText("place_text", "");
    CommonUtil.changeText("mp", $"MP{mp}");
  }

  public void updateEnemyLife(){
    EnemyLifeBar.updateLifeBar(enemy.hp, enemy.max_hp);
  }

  public void CreateCard(string cardID, Transform place){
    CardController card = Instantiate(cardPrefab, place);
    card.Init(cardID);
  }

  public void DropCardView(CardController card){
    Destroy(card.gameObject);
  }

  private void execPV(){
    string next_scene = PVModel.getNextSceneName();
    DataMgr.Increment("pv_level");
    CommonUtil.changeScene(next_scene);
  }

  public void dealDamage(int val){
    enemy.hp -= val;
    if(enemy.hp < 0) enemy.hp = 0;
    updateEnemyLife();

    DamageDisplay damage_display = GameObject.Find("event_image").GetComponent<DamageDisplay>();
    damage_display.showText($"{val}");
  }

  public bool isWin(){
    return enemy.hp <= 0;
  }
}
