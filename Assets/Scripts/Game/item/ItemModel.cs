using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : MonoBehaviour
{
  [SerializeField] CardController cardPrefab;
  public RectTransform cardArea;

  public static List<string> all_list = new List<string>() {
    "wood",
    "kinoko",
  };

  public static ItemModel instance = null;
  public int card_num = 0;

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void pushedCraftButton(){
    updateItemList();
  }

  public void updateItemList(){
    CardArea.instance.resetAllCard();
    card_num = 0;
    foreach(string key in ItemModel.all_list) {
      if(DataMgr.GetBool(key)) continue;

      CardController card = Instantiate(cardPrefab, cardArea);
      card.Init(key, "item");
      card_num += 1;
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
        DataMgr.Increment("wood", -2);
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
