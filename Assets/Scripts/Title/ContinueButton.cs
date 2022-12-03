using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
  private void Start(){
    if(!DataMgr.GetBool("is_game")) {
      Destroy(gameObject);
    }
  }

  private bool isButtonPushed = false;
  public void PressStart(){
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

    BGMMgr.instance.changeBGM("field");
    CommonUtil.changeScene("GameScene");
  }
}
