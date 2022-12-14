using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class StartButtonModel : MonoBehaviour
{
  private void  Start(){
  }

  private bool isButtonPushed = false;
  public void PressStart(){
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

    LandDataMgr.initData();

    DataMgr.SetBool("pv_mode", false);

    BGMMgr.instance.changeBGM("field");
    CommonUtil.changeScene("GameScene");
  }

}
