using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestModel : MonoBehaviour
{
  [SerializeField] CardController cardPrefab;
  public RectTransform cardArea;
  public static RestModel instance = null;

  public static List<string> all_list = new List<string>() {
    "good_night"
  };

  public List<string> list = new List<string>() {};

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void pushedRestButton(){
    updateRestList();
  }

  public void setRestList(){
    int mp = DataMgr.GetInt("mp");
    if(mp > 80) {
      list.Add("good_night");
    } else {
      list.Add("bad_night");
    }
  }

  public void updateRestList(){
    CardArea.instance.resetAllCard();
    foreach(string key in list) {
//      Debug.Log($"update item_list. key = {key}");
      CardController card = Instantiate(cardPrefab, cardArea);
      card.Init(key, "rest");
    }
  }

  public void updateItemMenu(CardModel card_model){
    card_model.item_cost = getItemCostText(card_model);
    SubMenu.instance.updateInfo(card_model);
  }

  public static void useCard(string key) {
    Debug.Log($"use card. key={key}");
    switch(key) {
      case "wood":
        // 使用不可
        break;
      case "kinoko":
        DataMgr.Increment("kinoko", -1);
        break;
      default:
        break;
    }
  }

  public string getItemCostText(CardModel card_model){
    switch(card_model.cardID) {
      case "wood":
        return $"木材({DataMgr.GetInt("wood")})　　2";
        break;
      default:
        break;
    }
    return "";
  }
}
