using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : MonoBehaviour
{
  [SerializeField] CardController cardPrefab;
  public RectTransform cardArea;
  public static ItemModel instance = null;

  public static List<string> all_list = new List<string>() {
    "wood",
    "kinoko",
    "fish",
    "item_torch",

    // 制作物
    "item_fire",
  };

  public List<string> list = new List<string>() {};

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void pushedItemButton(){
    updateItemList();
  }

  public static List<string> num_item_list = new List<string>() {
    "wood",
    "kinoko",
    "fish",
    "item_torch",
  }


  public void setItemList(){
    foreach(string key in ItemModel.all_list) {
      foreach(string num_key in num_item_list) {
        if(key == num_key && DataMgr.GetInt(key) == 0) continue;
      }

      if(key == "item_fire" && !DataMgr.GetBool("fire")) continue;

      list.Add(key);
    }
  }

  public void updateItemList(){
    CardArea.instance.resetAllCard();
    foreach(string key in list) {
      CardController card = Instantiate(cardPrefab, cardArea);
      card.Init(key, "item");
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
    SubMenu.instance.hide();
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

  // TODO OKボタン押せるかどうかの判定


}
