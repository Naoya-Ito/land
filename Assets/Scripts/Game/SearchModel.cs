using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchModel : MonoBehaviour
{
  [SerializeField] CardController cardPrefab;
  public RectTransform cardArea;

  public static List<string> all_list = new List<string>() {
    "forest",
    "sea"
  };

  public static SearchModel instance = null;

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void pushedSearchButton(){
    updateSearcList();
  }

  public void updateSearcList(){
    CardArea.instance.resetAllCard();
    foreach(string key in SearchModel.all_list) {
      CardController card = Instantiate(cardPrefab, cardArea);
      card.Init(key, "search");
    }
  }

  public void updateSubMenu(CardModel card_model){
    SubMenu.instance.updateInfo(card_model);
    CommonUtil.changeText("get_item_title", "得られるもの");
  }

  public static void useCard(string key) {
    Debug.Log($"use card. key={key}");
    switch(key) {
      case "forest":
        DataMgr.Increment("wood");
        break;
      case "sea":
        break;
      default:
        break;
    }
    SubMenu.instance.hide();
  }
}
