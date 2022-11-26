using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]

public class CardEntity : ScriptableObject {
  public new string name;
  public string image;
  public enum card_type_enum {
    search,
    create
  }
  [SerializeField] public card_type_enum card_type = card_type_enum.search;
  public float time_cost;
  [Multiline] public string item_cost;
  [Multiline] public string get_item;
  [Multiline] public string description;
}