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
    if(card_model.viewMode) return;
    if(card_model.cantUse) return;

    if(card_model.getMode) {
      BattleMgr.instance.getCardEnd(card_model.cardID);
      battleWinEnd();
      return;
    }

    if(card_model.cost > BattleCardMgr.instance.mp) {
      BattleCardMgr.instance.cantPlayCard();
      return;
    }

    string key = card_controller.model.cardID;
    BattleCardMgr.instance.playCard(card_controller);
  }

  private void battleWinEnd(){
    CommonUtil.changeScene("GameScene");
    BGMMgr.instance.stopMusic();
  }

  // ドラッグを始めるときに行う処理
  /*
  public void OnBeginDrag(PointerEventData eventData){
    cardParent = transform.parent;
    transform.SetParent(cardParent.parent, false);
    GetComponent<CanvasGroup>().blocksRaycasts = false; // blocksRaycastsをオフにする
  }

  // ドラッグしてる時に起こす処理
  public void OnDrag(PointerEventData eventData){
    Vector3 cardPos = Camera.main.ScreenToWorldPoint(eventData.position);
    cardPos.z = -1 ;
    transform.position = cardPos;
  }

  // カードを離したときに行う処理
  public void OnEndDrag(PointerEventData eventData){
    transform.SetParent(cardParent, false);
    GetComponent<CanvasGroup>().blocksRaycasts = true; // blocksRaycastsをオンにする

    Debug.Log("card end drop");
  }
  */
}
