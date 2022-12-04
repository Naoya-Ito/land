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
      if(key == "fire" && DataMgr.GetBool("fire")) continue;

      CardController card = Instantiate(cardPrefab, cardArea);
      card.Init(key, "craft");
    }
  }

  public void updateCraftMenu(CardModel card_model){
    card_model.item_cost = getItemCostText(card_model);
    CraftMenu.instance.updateInfo(card_model);
  }

  public static void useCard(string key) {
    Debug.Log($"use card. key={key}");
    switch(key) {
      case "fire":
        DataMgr.Increment("wood", -2);
        DataMgr.SetBool("fire", true);
        ButtonArea.instance.addButton("cook");
        CommonUtil.changeText("main_text", "焚き火を作る事に成功した！\n火……それは文明の証だ！");
        CraftModel.instance.updateCraftList();
        NextButton.instance.hideCardAndShowButton();
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
