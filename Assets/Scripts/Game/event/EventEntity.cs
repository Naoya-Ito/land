using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventEntity", menuName = "Create EventEntity")]

public class EventEntity : ScriptableObject {
  [Multiline] public string event_text;
  public string place_text;
  public string chara_text;
  public string image;
  public string bg;
  public string bgm;
  public string right_card;
  public string center_card;
  public string left_card;
  public string clicked_change_key = "";
  public int clicked_change_val;
  [SerializeField] public InsteadEventModel insteadEvent;
  public ChoiceModel[] choices;
  public bool isHeal;
}