using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetButton : MonoBehaviour{

  static int CHOICE_NUM = 6;
  static int LONG_BUTTON_LENGtH = 700;

  public static void initButton(ChoiceModel[] choices){
    float[] pos_y = new float[3];
    pos_y[0] = GameObject.Find("ChoiceButton2").transform.position.y;
    pos_y[1] = GameObject.Find("ChoiceButton4").transform.position.y;
    pos_y[2] = GameObject.Find("ChoiceButton6").transform.position.y;

    // ボタンの長さを変える
    // is_choice_three_rows は不要。消す
    if(choices.Length <= 3) {
      setButtonLengthLong();      
    }

    // ボタンを非表示or文言変更
    for (int i = 0; i < CHOICE_NUM; i++) {
      if(choices.Length <= i || choices[i].choice_text == "") {
        string key = "ChoiceButton" + (i +1);
        hideButton(key);
      } else {
        ChoiceModel choice = choices[i];
        choice.key_name = choice.getEventKey(i);

        string text_key = "choiceText" + (i +1);
        if(choice.isChoiceLock()) {
          string lock_text = $"[<sprite name=\"lock\">{choice.lock_text}]{choice.lock_text_sub}";
          CommonUtil.changeText(text_key, lock_text);
          changeButtonDisable(i+1);
        } else {
          string text = choice.choice_text;
          string is_read_key = $"{DataMgr.GetStr("event_key")}_{choice.key_category}/{choice.key_name}";
          if(ReadModel.IsRead(is_read_key)) showReadLabel(i+1);
          CommonUtil.changeText(text_key, text);
        }
      }
    }
  }

  private static void showReadLabel(int i){
    TextMeshProUGUI read_text = GameObject.Find($"ChoiceButton{i}/read").GetComponent<TextMeshProUGUI>();
    var color = read_text.color;
    color.a = 1.0f;
    read_text.color = color;
  }

  private static void changeButtonDisable(int number) {
    Image buttonImage = GameObject.Find($"ChoiceButton{number}").GetComponent<Image>();
    buttonImage.color = Color.gray;

    Button button = GameObject.Find($"ChoiceButton{number}").GetComponent<Button>();
    button.interactable = false;
  }

  private static void setButtonLengthLong(){
    float[] pos_y = new float[3];
    pos_y[0] = GameObject.Find("ChoiceButton2").transform.position.y;
    pos_y[1] = GameObject.Find("ChoiceButton4").transform.position.y;
    pos_y[2] = GameObject.Find("ChoiceButton6").transform.position.y;

    for (int i = 0; i < 3; i++) {
      string key = "ChoiceButton" + (i +1);
      GameObject button = GameObject.Find(key);
      CommonUtil.setRectWidth(key, LONG_BUTTON_LENGtH);
      Vector3 pos = button.transform.position;
      pos.x = 0;
      pos.y = pos_y[i];
      button.transform.position = pos;

      string key2 = "choiceText" + (i +1);
      CommonUtil.setRectWidth(key2, LONG_BUTTON_LENGtH);

      TextMeshProUGUI read_text = GameObject.Find($"ChoiceButton{i+1}/read").GetComponent<TextMeshProUGUI>();
      Vector3 read_pos = new Vector3(-220, read_text.transform.position.y, 1);
      read_text.transform.localPosition = read_pos;
    } 
  }

  private static void showTextAreaMini(){
    Transform text_area = GameObject.Find("TextArea").GetComponent<Transform>();
    Vector3 text_area_pos = new Vector3(900, 0, 0);
    text_area.transform.position = text_area_pos;
  }

  private static void hideTextAreaMini(){
    Transform text_area = GameObject.Find("TextAreaMini").GetComponent<Transform>();
    Vector3 text_area_pos = new Vector3(900, 0, 0);
    text_area.transform.position = text_area_pos;
  }

   private static void hideButton(string key) {
//    Debug.Log("hide button. key=" + key);
    GameObject button = GameObject.Find(key);
//    Transform button = transform.Find(key);

    if(button == null) {
      Debug.Log(key + ": button is not exist.(hide)");
    } else {
      button.GetComponent<Button>().gameObject.SetActive(false);
    }
  }

  public static void changeJumpButtonText(){
    TextMeshProUGUI text = GameObject.Find("jump_text").GetComponent<TextMeshProUGUI>();
    int day = DataMgr.GetInt("day");
    if(day < 10) {
      text.text = "19日まで寝る";
    } else if (day < 20) {
      text.text = "20日まで寝る";
    } else if (day < 30) {
      text.text = "30日まで寝る";
    } else if (day < 40) {
      text.text = "40日まで寝る";
    } else if (day < 50) {
      text.text = "50日まで寝る";
    } else if (day < 60) {
      text.text = "60日まで寝る";
    } else if (day < 70) {
      text.text = "70日まで寝る";
    } else if (day < 80) {
      text.text = "80日まで寝る";
    } else if (day < 90) {
      text.text = "90日まで寝る";
    } else if (day < 100) {
      text.text = "100日まで寝る";
    }
  }
}
