using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]

// TODO 正気度100なら怠けるカッパ画像

public class CardEntity : ScriptableObject {
  public new string name;
  public string image;
  public enum card_type_enum {
    search,
    craft,
    cook,
    move,
    item,
    party,
    rest
  }
  [SerializeField] public card_type_enum card_type = card_type_enum.search;
  [Multiline] public string item_cost;
  [Multiline] public string description;
  public string button_text;
  public ChangeData[] change_data;
  public string[] events;
}