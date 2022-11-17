using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]

public class CardEntity : ScriptableObject {
  public int cost;
  public new string name;
  [Multiline] public string description;
  public bool is_mini_description = false;
  public enum card_type_enum {
    attack,
    skill
  }
  [SerializeField] public card_type_enum card_type = card_type_enum.attack;
  public string icon;
  public string multiple_image_name;
  public string background;
  public bool isDelete;
  public bool cantUse;
}