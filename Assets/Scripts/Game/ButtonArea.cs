using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArea : MonoBehaviour {

  public RectTransform buttonArea;
  public Button cookButton;

  public static ButtonArea instance = null;
  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  void Start() {
    
    if(DataMgr.GetBool("fire")) {
      Instantiate(cookButton, buttonArea);
    }
  }

  public void addButton(string key){
    switch(key) {
      case "cook":
        Instantiate(cookButton, buttonArea);
        break;
      default:
        break;
    }
  }
}