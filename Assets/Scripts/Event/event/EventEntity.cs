using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventEntity", menuName = "Create EventEntity")]

public class EventEntity : ScriptableObject {

  // TODO イベント文章は配列にして、多様性を持たせたい
  [Multiline] public string text;
  public string bg;
  public ChangeData[] change_data;
  public ChoiceModel[] choices;
}