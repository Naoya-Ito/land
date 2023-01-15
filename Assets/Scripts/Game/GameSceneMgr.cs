using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMgr : MonoBehaviour
{
  // sub_menu: 
    // TODO カードごとにOKボタンの文言(空なら非表示)

  // 持ち物が多いと混乱する


  // HPが減っていると低い可能性で傷が化膿するイベント発生

  // 寝るとHPが僅かに自然回復する

  // 家なしで寝ると病期になるかも
    // bad event 5種類



  // メインクエスト、サブクエストを画面右上に表示？

  // TODO イベント結果の文章を表示するモデル

  // TODO ゴールドの表示

  // TODO HPの減少

  // 1面クリアに必要なもの
    // TODO イカダのクラフト
    // TODO イカダ→使う  

  // TODO アイテムボタンに(3)など数を表示
  // TODO 各アイテムに所持数を追加

  // TODO アイテムを使えるかどうかのフラグ
    // 木は使えない

  // TODO ゲームオーバー画面を作る

  // 画像
  // TODO 羊皮紙のメッセージエリア

  // TODO ステージ選択画面

  // TODO イベント
    // 孤独
    // 夜空

  // ステージ情報

  // TODO ゲーム画面
     // TODO HP、正気度の表示
     // メイン文章の表示

  // TODO 探索で n, r, sr, ssr の判定

  // TODO カッパの探索アニメーション


  // TODO 画像
  //  探索
    // 洞窟
  //  料理
      // 焼き魚、焼きキノコ
  // アイテム
    // 生魚


  // TODO 仲間
    // TODO 遊ぶ。　童心に帰って遊ぶ。体力と正気度の２コイチ


  // 初期状態（探索）の一覧を出す
  void Start() {
    updateHeader();
    updateLifeBar(); 
    updateDayText();
    // TODO イベントがなければ
    updateText();

    // TODO 状態によってカッパアイコンを変更
  }

  private void updateHeader(){
    HeaderBar.updateMPBarCurrent();
  }

  // TODO 人数分のHPを更新
  private void updateLifeBar(){
    updateHpBarCurrent(1);
  }

  // TODO なんらかの形で汎用化。４人分のライフを管理できるようにする
  public void updateHpBarCurrent(int i){
    int now_hp = DataMgr.GetInt($"hp{i}");
    int max_hp = DataMgr.GetInt($"max_hp{i}");
    updateHpBar(now_hp, max_hp, i);
  }

    // TODO 減少分の値をバーで表示
  public static void updateHpBar(int val, int max_val, int i){
    double per = (double)val/(double)max_val;
    int length = (int)(100*per);
    CommonUtil.setRectWidth($"life_bar{i}", length);
    //CommonUtil.changeText("mp_text", $"{val}/{max_val}");
    CommonUtil.changeText($"life_text{i}", $"{val}");
  }

  private void updateDayText(){
    int day = DataMgr.GetInt("day");
    string time = DataMgr.GetStr("time");
    string time_text;
    switch(time) {
      case "morning":
        time_text = "朝";
        break;
      case "evening":
        time_text = "昼";
        break;
      case "sunset":
        time_text = "夕";
        break;
      case "night":
        time_text = "夜";
        break;
      default:
        time_text = "その他";
        break;
    }

    string day_text = $"{day}日目({time_text})";
    CommonUtil.changeText("day_text", day_text);
  }

  // TODO 正気度や条件によって呼ぶモデルを変える`
  private void updateText(){
    string time = DataMgr.GetStr("time");
    string key = $"{time}/good";
    TextModel text_model = new TextModel(key);
    CommonUtil.changeText("main_text", text_model.text);
  }
}
