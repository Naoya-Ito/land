using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardModel : MonoBehaviour{
  public string cardID;
  public string name;
  public string description;
  public bool is_mini_description;
  public string icon;
  public string multiple_image_name;
  public string background;
  public int cost;
  public int damage;
  public bool viewMode = false;
  public bool getMode = false;
  [SerializeField] public CardEntity.card_type_enum card_type;
  public bool isDelete;
  public bool cantUse;

  public CardModel(string cardID){
    CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/" + cardID);
    if(cardEntity == null) {
      Debug.Log($"card not exist. id={cardID}");
      return;
    }

    this.cardID = cardID;
    this.name = cardEntity.name;
    this.description = cardEntity.description;
    this.is_mini_description = cardEntity.is_mini_description;
    this.icon = cardEntity.icon;
    this.multiple_image_name = cardEntity.multiple_image_name;
    this.background = cardEntity.background;
    this.isDelete = cardEntity.isDelete;
    this.cantUse = cardEntity.cantUse;
    this.cost = cardEntity.cost;
    this.card_type = cardEntity.card_type;
    this.damage = 0;
    updateCard();
  }

  public void updateCard(){
    if(card_type == CardEntity.card_type_enum.attack) {
      damage = CardStr.getStr(cardID);
    }

    switch(cardID){
      case "mini_sword":
        break;
      case "punch":
        break;
      default:
        break;
    }     
  }

  public void setViewMode(){
    viewMode = true;
  }

  public void setGetMode(){
    getMode = true;
  }
}