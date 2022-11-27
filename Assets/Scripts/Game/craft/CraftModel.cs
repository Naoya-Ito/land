using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftModel : MonoBehaviour
{
  [SerializeField] CardController cardPrefab;
  public RectTransform cardArea;

  public static List<string> all_list = new List<string>() {
    "fire",
  };

  public static CraftModel instance = null;

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void pushedCraftButton(){
    updateCraftList();
  }

  public void updateCraftList(){
    CardArea.instance.resetAllCard();
    foreach(string key in CraftModel.all_list) {
      CardController card = Instantiate(cardPrefab, cardArea);
      card.Init(key, "craft");
    }
  }

  public void updateCraftMenu(CardModel card_model){
    card_model.item_cost = getItemCostText(card_model);
    CraftMenu.instance.updateInfo(card_model);
    CommonUtil.changeText("get_item_title", "");
  }

  public static void useCard(string key) {
    Debug.Log($"use card. key={key}");
    switch(key) {
      case "fire":
        DataMgr.Increment("wood");
        break;
      default:
        break;
    }
    CraftMenu.instance.hide();
  }

  public string getItemCostText(CardModel card_model){
    switch(card_model.cardID) {
      case "fire":
        return $"木材({DataMgr.GetInt("wood")})　　2";
        break;
      default:
        break;
    }
    return "";
  }

  // TODO OKボタン押せるかどうかの判定


}
