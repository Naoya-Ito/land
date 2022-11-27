using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMgr : MonoBehaviour
{

  // 画像
  // TODO タイトル画面の画像
  // TODO 浜辺探索
  // TODO 焚き火

  // TODO ステージ選択画面


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
