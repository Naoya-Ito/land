using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMgr : MonoBehaviour
{
  // 初期状態（探索）の一覧を出す
  void Start() {
    SearchModel.instance.updateSearcList();
  }

  void Update()
  {
      
  }
}
