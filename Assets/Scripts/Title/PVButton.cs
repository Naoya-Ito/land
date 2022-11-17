using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class PVButton : MonoBehaviour
{
  private bool isButtonPushed = false;
  public void PressStart(){
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

    DataMgr.SetBool("pv_mode", true);
    DataMgr.SetInt("pv_level", 1);

    BGMMgr.instance.stopMusic();
    CommonUtil.changeScene("PVScene");
  }

}
