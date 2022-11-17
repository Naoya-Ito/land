using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// PV修正

// TODO
  // ゾンビだ！イベント
  // 国家は偽りだ
  // 国王との謁見
  // アイスソードを手に入れたぞ

  // 70 エゴダ
  // 80 シヴァ
  // 90 イグニウス
  // 100

  // ダンジョン
    // 
    // 研究所

// ラスボス

// 数が多いほど良い
  // ランダム人イベント
  // 合宿イベント

// フィールドイベント
// TODO 罪の家
  // 最強の武器

// TODO
  // 魔法 ステラリス
  // 魔法 リムワルド
  // 魔法  

// TODO windows でコンパイル通す

// TODO 幸運%で敵撃破児にランダム能力アップ

// TODO 教会イベント　　ツボを買うと信仰+10,  信仰50以上でエクスカリバー

// TODO 酒場の親父の襲撃
// TODO 初心者の館の襲撃

// TODO ボタン連打で動かなくなる？

// TODO 武器屋　カードガチャ

// TODO MP消費演出
// TODO MPが足りない時はコストを赤くする

// TODO スキル　２コストカード使うと魔力+5
// TODO スキル　５コスト以上のカードを使ったら力+10
// TODO スキル　１ターンにカードを4枚使うと素早さ2倍


// TODO day event
  // TODO 70日目　六英雄4人目  　
  // TODO 80日目　５ 勇者シヴァ
  // TODO 90日目　６　失敗すると武器屋が壊される
  // TODO 100日目　世界の終わり(ラストダンジョンにいくべし)


// TODO
// ダンジョン　メメント森　最終ダンジョンの入り口？
// ダンジョン　ガハラ戦場　最強のカードとか？

// TODO カード
  // TODO 信仰心関係のカード
   // TODO 疲労が溜まる大剣カード

// TODO 設定画面 効果音オフ

// TODO スキル残り実装

// TODO 幸運の修行
// TODO カード　ダイスロール 画像

// TODO カード　防御

// TODO 防御ターン時 シールドの判定
// TODO ツールチップを的ステータスやカードにも適用可能に。

// TODO OP キャラ設定 職業選択？　名前設定？

// TODO ストア更新
// TODO 動画画像を作る
// TODO iOS Android対応

// TODO モンスター図鑑
// TODO カード図鑑　　使用回数 1以上を表示
// TODO 実績一覧

// TODO 防御ターン敵の動き　円運動
// TODO 回転剣舞
// TODO ファンネル
// TODO 被弾時の無敵時間

// TODO スキル: 無敵時間を延長

// TODO 護衛兵の襲撃後イベント

// TODO 犯罪者になった時のフラグ

// TODO キーボード操作




public class EventMgr : MonoBehaviour{
  public static EventMgr instance = null;
  public EventModel model;
  public MapModel map;

  [SerializeField] CardController cardPrefab;
  [SerializeField] public Transform rightCardArea;
  [SerializeField] public Transform centerCardArea;
  [SerializeField] public Transform leftCardArea;

  void Start(){
    loadModel();
    if(DataMgr.GetStr("event_key") == "dead/dead_end") {
      CommonUtil.changeScene("GameOverScene");
      return;
    }
    updateScene();
    updateStatus();

    if(CommonUtil.isPV()){
      Invoke("goPVNextScene", 3);
    } else {
      changeBGM();
    }
  }

  private void loadModel(){
    string event_key;
    if(CommonUtil.isPV()) {
      event_key = DataMgr.GetStr("pv_page");
    } else if(DataMgr.GetStr("event_key") == "") {
      Debug.Log("load model. data mgr is null, set debug mode.");
      event_key = "op/op1";
    } else {
      event_key = DataMgr.GetStr("event_key");
      model = new EventModel(event_key);
      if(model.cantRead) {
        event_key = "town/error";
        model = new EventModel(event_key);
      }
      if(model.isHeal) DataMgr.SetInt("hp", DataMgr.GetInt("max_hp"));

      event_key = getInsteadEvent(event_key);
      updateJumpButton(event_key);
    }
    model = new EventModel(event_key);
    map = new MapModel(model.category);
  }

  private string getInsteadEvent(string key){
    if(model.insteadEvent.key == null) {
      return key;
    }
    switch(model.insteadEvent.key){
      case "":
        return key;
      case "flag":
        if(DataMgr.GetBool(model.insteadEvent.value_str)) {
          return model.insteadEvent.event_name;
        }
        return key;
      default:
        if(DataMgr.GetInt(model.insteadEvent.key) >= model.insteadEvent.value_int) {
          return model.insteadEvent.event_name;
        }
        return key;
    }
  }

  private void updateScene(){
    CommonUtil.changeText("event_text", model.event_text);
    CommonUtil.changeText("place_text", getPlace());
    CommonUtil.changeText("chara_text", getCharaText());
    CommonUtil.changeImage("event_image", getImage());

    changeBg("event_bg", model.bg);

    if(model.right_card != null && model.right_card != "") {
      CardController card_r = Instantiate(cardPrefab, rightCardArea);
      card_r.Init(model.right_card);
      card_r.model.setViewMode();
    }
    if(model.center_card != null && model.center_card != "") {
      CardController card_c = Instantiate(cardPrefab, centerCardArea);
      card_c.Init(model.center_card);
      card_c.model.setViewMode();

    }
    if(model.left_card != null && model.left_card != "") {
      CardController card_l = Instantiate(cardPrefab, leftCardArea);
      card_l.Init(model.left_card);
      card_l.model.setViewMode();
    }

    SetButton.initButton(model.choices);
  }

  private void updateJumpButton(string key){
    if(key != "town/start") {
      GameObject button = GameObject.Find("JumpButton");
      button.SetActive(false);
      return;
    }
    SetButton.changeJumpButtonText();
  }

  private void updateStatus(){
    if(CommonUtil.isDebug() || CommonUtil.isPV()) {
      PVModel.setPVStatus();
      return;
    }
    
    LifeBar.updateLifeBar(DataMgr.GetInt("hp"), DataMgr.GetInt("max_hp"));
    RightArea.updateGold(DataMgr.GetInt("gold"));
    LeftArea.updateStatus();
    RightArea.updateStatus();
  }

  public void dayEnd(int day_past = 1){
//    GManager.instance.day += day_past;
//    CommonUtil.instance.changeScene("GameScene");
  }

  private string getImage(){
//    Debug.Log($"get chara. data={model.chara_text}");
    if(model.image == "no") {
//      Debug.Log("so, image is null");
      return ""; 
    }

    if(model.image != ""){
      return model.image;
    }

    return map.image;
  }

  private string getCharaText(){
    if(model.chara_text == "no") {
      return "";
    }
    if(model.chara_text != ""){
      return model.chara_text;
    }
    return map.chara_text;
  }

  private void changeBg(string key, string image_path){
    Image image = GameObject.Find(key).GetComponent<Image>();

    string path = "";
    if(image_path != ""){
      path = image_path;
    } else if(map.bg != ""){
      path = map.bg;
    } else {
      path = "bg_town";
    }
    string last_image_path = $"Textures/bg/{path}";
    Sprite sprite = Resources.Load<Sprite>(last_image_path);
    image.sprite = sprite;
  }

  private void changeBGM(){
//    Debug.Log($"change bgm. now={DataMgr.GetStr("now_bgm")}");
    string now_bgm = DataMgr.GetStr("now_bgm");
    if(model.bgm != "" && model.bgm != null && model.bgm != now_bgm) {
      BGMMgr.instance.changeBGM(model.bgm);
    } else if(now_bgm == "" || now_bgm == null) {
//      Debug.Log($"event mgr. {DataMgr.GetStr("event_key")} change bgm. now=null, do field");
      BGMMgr.instance.changeBGM("field");
    }
  }

  private string getPlace(){
    if(model.place_text == "no") {
      return "";
    }

    if(model.place_text != ""){
      return model.place_text;
    }
    return map.place_text;
  }

  private void goPVNextScene(){
    string next_scene = PVModel.getNextSceneName();
    DataMgr.Increment("pv_level");
    CommonUtil.changeScene(next_scene);
  }
}