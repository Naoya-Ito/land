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
    switch(card_model.card_type) {
      case CardEntity.card_type_enum.search:
        SearchModel.instance.updateSubMenu(card_model);
        break;
      case CardEntity.card_type_enum.craft:
        CraftModel.instance.updateCraftMenu(card_model);
        break;
      case CardEntity.card_type_enum.cook:
        CookModel.instance.updateCookMenu(card_model);
        break;
      case CardEntity.card_type_enum.item:
        ItemModel.instance.updateItemMenu(card_model);
        break;
      case CardEntity.card_type_enum.rest:
        RestModel.instance.updateItemMenu(card_model);
        break;
      default:
        Debug.Log($"unknown card type. cardID={card_model.cardID}");
        break;
    }

/*
    if(SearchModel.all_list.Contains(key)) {
      SearchModel.instance.updateSubMenu(card_model);
    } else if(CraftModel.all_list.Contains(key)) {
      CraftModel.instance.updateCraftMenu(card_model);
    } else if(CookModel.all_list.Contains(key)) {
      CookModel.instance.updateCookMenu(card_model);
    } else if(ItemModel.all_list.Contains(key)) {
      ItemModel.instance.updateItemMenu(card_model);
    }
    */
    SubMenu.instance.show();
  }
}
