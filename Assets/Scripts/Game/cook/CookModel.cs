using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookModel : MonoBehaviour
{
  [SerializeField] CardController cardPrefab;
  public RectTransform cardArea;

  public static List<string> all_list = new List<string>() {
    "",
  };

  public static CookModel instance = null;

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void pushedCraftButton(){
    updateCookList();
  }

  public void updateCookList(){
    CardArea.instance.resetAllCard();
    foreach(string key in CookModel.all_list) {
//      CardController card = Instantiate(cardPrefab, cardArea);
//      card.Init(key, "cook");
    }
  }

  public void updateCookMenu(CardModel card_model){
    card_model.item_cost = getItemCostText(card_model);
    CookMenu.instance.updateInfo(card_model);
  }

  public static void useCard(string key) {
    switch(key) {
      case "":
        break;
      default:
        break;
    }
    CraftMenu.instance.hide();
  }

  public string getItemCostText(CardModel card_model){
    switch(card_model.cardID) {
      case "":
        return $"木材({DataMgr.GetInt("wood")})　　2";
        break;
      default:
        break;
    }
    return "";
  }

  // TODO OKボタン押せるかどうかの判定


}
