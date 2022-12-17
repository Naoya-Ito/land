using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardModel : MonoBehaviour{
  public string cardID;
  public string name;
  public string image;
  [SerializeField] public CardEntity.card_type_enum card_type;
  public string item_cost;
  public string get_item;
  public string description;
  public string button_text;
  public string event_key;

  public CardModel(string cardID, string category){
    CardEntity cardEntity = Resources.Load<CardEntity>($"CardEntityList/{category}/{cardID}");
    if(cardEntity == null) {
      Debug.Log($"card not exist. id={cardID}");
      return;
    }

    this.cardID = cardID;
    this.name = cardEntity.name;
    this.image = cardEntity.image;
    this.card_type = cardEntity.card_type;
    this.item_cost = cardEntity.item_cost;
    this.description = cardEntity.description;
    this.button_text = cardEntity.button_text;
    if(cardEntity.events == null || cardEntity.events.Length == 0) {
      this.event_key = "";
    } else {
      this.event_key = CommonUtil.getRndStrByArray(cardEntity.events);
    }
    updateCard();
  }

  public void updateCard(){
    switch(cardID){
      case "mini_sword":
        break;
      case "punch":
        break;
      default:
        break;
    }     
  }
}