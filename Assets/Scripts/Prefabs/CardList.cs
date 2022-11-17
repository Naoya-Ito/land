using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour{
  [SerializeField] CardController cardPrefab;
  public RectTransform contentRectTransform;

  public static CardList instance = null;

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

/*
  void Start(){
    List<string> deck = new List<string>() {
       "punch", "mountain", "drop", "curse", 
       "mgi_up", "fire", "mini_sword",
       "ice_sword"
    };    
    updateCardList(deck);
  }
*/
  public void updateCardList(List<string> list){
    foreach(string key in list) {
      CardController card = Instantiate(cardPrefab, contentRectTransform);
      card.Init(key);
      card.model.setViewMode();
    }
  }

  public void updateTitle(string val){
    CommonUtil.changeText("cardListTitle", val);
  }

  public void cancel(){
    GameObject panel = GameObject.Find("CardList");
    if(panel != null) {
      Destroy(panel);
    } else {
      Debug.Log("SettingMenu is not found.");
    }
  }
}
