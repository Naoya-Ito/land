using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubMenu : MonoBehaviour {
  public RectTransform sub_menu;
  public TextMeshProUGUI name;
  public TextMeshProUGUI description;
  public Image okButton;
  public Button nextButton;

  public static SubMenu instance = null;
  private CardModel card_model;
  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void show(){
    Vector3 new_pos = new Vector3(0, 0, 0);
    sub_menu.position = new_pos;
  }

  public void hide(){
    Vector3 new_pos = new Vector3(2000, 0, 0);
    sub_menu.position = new_pos;
  }

  public void updateInfo(CardModel model){
    card_model = model;
    name.text = model.name;
    description.text = model.description;
    if(model.button_text == "" || model.button_text == null) {
      CommonUtil.hideButton("SubMenuOKButton");
//      CommonUtil.hideButton("CancelButton");
    } else {
      CommonUtil.changeText("sub_menu_button_text", model.button_text);
      //CommonUtil.showImage("SubMenuOKButton");
      CommonUtil.showButton("SubMenuOKButton", 220.0f);
    }
  }

  private bool isButtonPushed = false;
  public void okButtonDidPushed(){
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

    DataMgr.SetStr("event", card_model.event_key);
    EventModel event_model = new EventModel(card_model.event_key);
    event_model.changeData();
    CommonUtil.changeScene("EventScene");
  }

  public void hideCardAndShowButton(){
    CardArea.instance.hideArea();
    ButtonArea.instance.hideArea();

    Vector3 pos = nextButton.transform.position;
    Vector3 new_pos = new Vector3(0, pos.y, pos.z);
    nextButton.transform.position = new_pos;
  }
}
