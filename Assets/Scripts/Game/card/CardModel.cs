using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardModel : MonoBehaviour{
  public string cardID;
  public string name;
  public string image;
  [SerializeField] public CardEntity.card_type_enum card_type;
  public string time;
  public string use_resource;
  public string get_resource;
  public string description;

  public CardModel(string cardID){
    CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/" + cardID);
    if(cardEntity == null) {
      Debug.Log($"card not exist. id={cardID}");
      return;
    }

    this.cardID = cardID;
    this.name = cardEntity.name;
    this.image = cardEntity.image;
    this.card_type = cardEntity.card_type;
    this.time = cardEntity.time;
    this.use_resource = cardEntity.use_resource;
    this.get_resource = cardEntity.get_resource;
    this.description = cardEntity.description;
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