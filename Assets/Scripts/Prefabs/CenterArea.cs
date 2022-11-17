using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CenterArea : MonoBehaviour
{

  static public void hideTextArea(){
    GameObject.Find("TextArea").gameObject.SetActive(false);
  }

  static public void hideImage(){
    GameObject.Find("event_image").gameObject.SetActive(false);
  }

  static public void hidePlace(){
    GameObject.Find("place_text").gameObject.SetActive(false);
  }

  static public void hideChara(){
    GameObject.Find("chara_text").gameObject.SetActive(false);
  }

  static public void fadeOutTextArea(){
    GameObject.Find("TextArea").GetComponent<FadeoutObject>().fadeStart();
    GameObject.Find("event_text").GetComponent<FadeoutTextObject>().fadeStart();
  }

  static public void fadeOutImage(){
    GameObject.Find("event_image").GetComponent<FadeoutImageObject>().fadeStart();
  }

  static public void fadeOutBackgroundImage(){
    GameObject.Find("event_bg").GetComponent<FadeoutImageObject>().fadeStart();
  }

  static public void fadeOutSubText(){
    GameObject.Find("chara_text").GetComponent<FadeoutTextObject>().fadeStart();
    GameObject.Find("place_text").GetComponent<FadeoutTextObject>().fadeStart();
  }

  static public void fadeOutAll(){
    fadeOutTextArea();
    fadeOutImage();
    fadeOutBackgroundImage();
    fadeOutSubText();
  }

  // 一瞬だけ本文を表示
  /*
  static public void flashMessage(string text){
    GameObject center_area = GameObject.Find("center_area").gameObject;
    Transform text_area = center_area.transform.Find("TextArea");
    text_area.SetActive(true);

    TextMeshProUGUI event_text = GameObject.Find("event_text").GetComponent<TextMeshProUGUI>();
    event_text.text = text;
    fadeOutTextArea();
  }
  */
}
