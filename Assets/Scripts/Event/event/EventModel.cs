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

  // TODO mp の場合、最大値を超えない、バーを変更するなどが必要
  public void changeData(){
    foreach(ChangeData data in change_data) {
      if(data.change_key != "") {
        DataMgr.Increment(data.change_key, data.change_val);
      }
      if(data.flag_true != "") {
        DataMgr.SetBool(data.flag_true, true);
      }
      if(data.flag_false != "") {
        DataMgr.SetBool(data.flag_false, true);
      }
    }
  }
}