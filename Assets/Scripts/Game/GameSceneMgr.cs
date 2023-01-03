using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMgr : MonoBehaviour
{
  // sub_menu: 
    // TODO カードごとにOKボタンの文言(空なら非表示)

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
    updateDayText();
    // TODO イベントがなければ
    updateText();
  }

  private void updateHeader(){
    HeaderBar.updateMPBarCurrent();
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

  private void updateText(){
    string time = DataMgr.GetStr("time");
    string text;
    switch(time) {
      case "morning":
        text = getMorningText();
        break;
      case "evening":
        text = "昼";
        break;
      case "sunset":
        text = "夕";
        break;
      case "knight":
        text = "夜";
        break;
      default:
        text = "その他";
        break;
    }

    CommonUtil.changeText("main_text", text);
  }

  private string getMorningText(){
    return "朝日が眩しい。今日も大冒険が始まる。";
  }
}
