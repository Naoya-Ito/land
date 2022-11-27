using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour{
  public CardView view; // カードの見た目の処理
  public CardModel model; // カードのデータを処理

  private void Awake(){
    view = GetComponent<CardView>();
  }

  public void Init(string cardID, string category){
    model = new CardModel(cardID, category);
    view.updateView(this.model);
  }

  public void updateAll(){
    model.updateCard();
    view.updateView(model);
  }
}