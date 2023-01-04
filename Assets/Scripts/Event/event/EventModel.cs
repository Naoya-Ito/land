using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventModel : MonoBehaviour{
  public string eventID;
  public string text;
  public string bg;
  public ChangeData[] change_data;
  public ChoiceModel[] choices;

  public EventModel(string eventID){
    EventEntity eventEntity = Resources.Load<EventEntity>($"EventEntityList/{eventID}");
    if(eventEntity == null) {
      Debug.Log($"card not exist. id={eventID}");
      return;
    }

    this.eventID = eventID;
    this.text = eventEntity.getText();
    this.bg = eventEntity.bg;
    this.change_data = eventEntity.change_data;
    this.choices = eventEntity.choices;
    updateEvent();
  }

  public void updateEvent(){
    switch(eventID){
      case "mini_sword":
        break;
      case "punch":
        break;
      default:
        break;
    }     
  }
}