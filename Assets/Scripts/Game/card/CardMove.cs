using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMove : MonoBehaviour, IPointerClickHandler {
  public Transform cardParent;

  public void OnPointerClick(PointerEventData eventData){
    CardController card_controller = eventData.pointerClick.GetComponent<CardController>();
    if (card_controller == null) return;

    CardModel card_model = card_controller.model;
//    if(card_model.viewMode) return;
//    if(card_model.cantUse) return;

    string key = card_controller.model.cardID;
//    BattleCardMgr.instance.playCard(card_controller);
    Debug.Log($"tapped card_id={key}");
  }
}
