using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventModel {
  public string event_text;
  public string place_text;
  public string chara_text;
  public string image;
  public string bg;
  public string bgm;
  public string right_card;
  public string center_card;
  public string left_card;
  public string category;
  public InsteadEventModel insteadEvent;
  public string clicked_change_key = "";
  public int clicked_change_val;

  public ChoiceModel[] choices;
  public bool isHeal = false;
  public bool cantRead = false;



  public EventModel(string eventID){
    EventEntity eventEntity = Resources.Load<EventEntity>("EventEntityList/" + eventID);
    if(eventEntity == null) {
      Debug.Log($"Error!! EventModel. load key={eventID} is not exist.");
      this.cantRead = true;
      return;
    }

    this.category = eventID.Split('/')[0];

    this.place_text = eventEntity.place_text;
    this.chara_text = eventEntity.chara_text;
    this.event_text = eventEntity.event_text;
    this.image = eventEntity.image;
    this.bg = eventEntity.bg;
    this.bgm = eventEntity.bgm;
    this.right_card = eventEntity.right_card;
    this.center_card = eventEntity.center_card;
    this.left_card = eventEntity.left_card;
    this.insteadEvent = eventEntity.insteadEvent;
    this.clicked_change_key = eventEntity.clicked_change_key;
    this.clicked_change_val = eventEntity.clicked_change_val;
    this.choices = eventEntity.choices;
    this.isHeal = eventEntity.isHeal;
  }
}