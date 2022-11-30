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
  }

  void Update()
  {
      
  }
}
