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

    if(SearchModel.all_list.Contains(key)) {
      SearchModel.instance.updateSubMenu(card_model);
    } else if(CraftModel.all_list.Contains(key)) {
      CraftModel.instance.updateCraftMenu(card_model);
    } else if(CookModel.all_list.Contains(key)) {
      CookModel.instance.updateCookMenu(card_model);
    } else if(ItemModel.all_list.Contains(key)) {
      ItemModel.instance.updateItemMenu(card_model);
    }
    SubMenu.instance.show();
  }
}
