using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreateMgr : MonoBehaviour{
  void Start(){
    if( CommonUtil.isPV()) {
      Invoke("toPV", 3.0f);
    }
  }

  void Update(){
  }

  private void toPV(){
    string next_scene = PVModel.getNextSceneName();
    DataMgr.Increment("pv_level");
    CommonUtil.changeScene("PVScene");
  }
}
