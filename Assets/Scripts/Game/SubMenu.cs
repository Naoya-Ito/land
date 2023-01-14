using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubMenu : MonoBehaviour {
  public RectTransform sub_menu;
  public TextMeshProUGUI name;
  public TextMeshProUGUI description;
  public Button nextButton;

  private float scene_transition_delay = 3.0f;

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


  // TODO 画面遷移のディレイや暗転を入れる
  private bool isButtonPushed = false;
  public void okButtonDidPushed(){
    if(isButtonPushed) {
      return;
    }
    isButtonPushed = true;

    changeData();

    Invoke("goEventScene", scene_transition_delay);

    // TODO カードなどは全て非表示(一才の操作不可)
    hide();
    hideCardAndShowButton();
  }

  private void changeData(){
    LandDataMgr.changeData(card_model.change_data);

    showFooterMessage(card_model.change_data);

    // TODO ライフや正気度などを表示変更
  }

  // TODO footer message 3 も作る
  // TODO 共通化する
  // TODO 画像も設定できるようにする
  private void showFooterMessage(ChangeData[] change_data){
    if(change_data.Length == 0) return;

    int i = 1;
    foreach(ChangeData data in change_data) {
      Image footer_msg = GameObject.Find($"footer_message{i}").GetComponent<Image>();
      Vector3 pos = footer_msg.transform.localPosition;
      footer_msg.transform.localPosition = new Vector3(300, pos.y, pos.z);

      string title = LandDataMgr.getDisplayNamByKey(data.change_key);
      int body = data.change_val;

      if(data.change_key != "") {
        CommonUtil.changeText($"footer_text{i}", $"{title}\n{body}");
      }
      /*
      if(data.flag_true != "") {
        DataMgr.SetBool(data.flag_true, true);
      }
      if(data.flag_false != "") {
        DataMgr.SetBool(data.flag_false, true);
      }
      */
      i++;
    }
  }

  private void goEventScene(){
    DataMgr.SetStr("event", card_model.event_key);
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
