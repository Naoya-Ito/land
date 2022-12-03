using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMgr : MonoBehaviour
{

  // 画像
  // TODO 羊皮紙のメッセージエリア

  // TODO ステージ選択画面


  // TODO ゲーム画面
     // TODO HP、正気度の表示
     // メイン文章の表示

  // TODO 探索で n, r, sr, ssr の判定

  // TODO カッパの探索アニメーション

  // 初期状態（探索）の一覧を出す
  void Start() {
    SearchModel.instance.updateSearcList();
    updateDayText();

    // TODO イベントがなければ
    updateText();
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
      case "knight":
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
