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
  public string time;
  public string use_resource;
  public string get_resource;
  public string description;
}