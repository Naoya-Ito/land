using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour {
  public GameObject cardArea;
  public GameObject buttonArea;

  public Button button;

  public static NextButton instance = null;
  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void hideCardAndShowButton(){
    cardArea.SetActive(false);
    buttonArea.SetActive(false);
    Vector3 pos = button.transform.position;
    Vector3 new_pos = new Vector3(0, pos.y, pos.z);
    button.transform.position = new_pos;
  }

  private bool isButtonPushed = false;
  public void PressButton(){
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

    LandDataMgr.timePast();
    CommonUtil.changeScene("GameScene");
  }
}
