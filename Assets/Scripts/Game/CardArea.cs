using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardArea : MonoBehaviour
{
  public RectTransform cardArea;
  public static CardArea instance = null;

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }
/*
    foreach(string key in SearchModel.all_list) {
      CardController card = Instantiate(cardPrefab, cardArea);
      card.Init(key, "search");
    }
*/
  public void resetAllCard(){
    CardController[] hands = cardArea.GetComponentsInChildren<CardController>();
    foreach (CardController card in hands){
      Destroy(card.gameObject);
    }
  }
}
