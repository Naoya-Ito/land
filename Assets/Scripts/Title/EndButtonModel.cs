using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonModel : MonoBehaviour{
  private bool isButtonPushed = false;
  public void pushedButton(){
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
  }
}
