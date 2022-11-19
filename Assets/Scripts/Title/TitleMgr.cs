using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMgr : MonoBehaviour{

  public GameObject pv_bg;
  public GameObject pv_text;

  void Start(){
  }

  private int ura = 0;
  void Update(){
    if(Input.GetKeyUp(KeyCode.K)) ura = 1;
    if(Input.GetKeyUp(KeyCode.A)) {
      Debug.Log("ura");
      if(ura == 1) ura += 1;
      if(ura == 4) urawaza();
    }
    if(Input.GetKeyUp(KeyCode.P)){
      if(ura == 2 || ura == 3) {
        ura += 1;
      } else {
        ura = 0;
      }
    }
  }

  private void urawaza(){
    DataMgr.SetInt("max_hp", 999);
    DataMgr.SetInt("hp", 909);
    DataMgr.SetInt("str", 999);
    DataMgr.SetInt("mgi", 999);
    DataMgr.SetInt("agi", 999);
    DataMgr.SetInt("luck", 999);
    DataMgr.SetInt("gold", 90099);


    DataMgr.SetBool("is_debug", true);
  }

  private void updatePVScene(){
    pv_bg.SetActive(true);
    pv_text.SetActive(true);

    List<string> list = new List<string> {"StartButton", "SettingButton", "PVButton", "EndButton"};
    foreach(string key in list) {
      GameObject button = GameObject.Find(key);
      button.SetActive(false);
    }

    DataMgr.SetBool("pv_mode", false);

    Invoke("pvEnd", 20);
  }

  private void pvEnd(){
    CommonUtil.changeScene("TitleScene");
  }
}
