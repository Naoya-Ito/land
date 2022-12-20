using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventEntity", menuName = "Create EventEntity")]

public class EventEntity : ScriptableObject {

  // TODO イベント文章は配列にして、多様性を持たせたい
  public MultilineText[] texts;
  public string bg;
  public ChangeData[] change_data;
  public ChoiceModel[] choices;

  public string getText(){
    int i = CommonUtil.rnd(texts.Length);
    MultilineText multi_text = texts[i];
    return multi_text.text;
  }
}