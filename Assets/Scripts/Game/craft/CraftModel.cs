using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftModel : MonoBehaviour
{
  [SerializeField] CardController cardPrefab;
  public RectTransform cardArea;

  public static List<string> all_list = new List<string>() {
    "fire",
    "torch"
  };
  public List<string> list = new List<string>() {};

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

  public void setCraftList(){
    foreach(string key in CraftModel.all_list) {
      if(key == "fire") {
        if(DataMgr.GetBool("fire")) continue;
        if(DataMgr.GetInt("wood") < 2) continue;
      }
      if(key == "torch") {
        if(!DataMgr.GetBool("fire")) continue;
        if(DataMgr.GetInt("wood") < 1) continue;
      }

      list.Add(key);
    }
  }

  public void updateCraftList(){
    CardArea.instance.resetAllCard();
    foreach(string key in list) {
      CardController card = Instantiate(cardPrefab, cardArea);
      card.Init(key, "craft");
    }
  }

  public void updateCraftMenu(CardModel card_model){
    card_model.item_cost = getItemCostText(card_model);
    SubMenu.instance.updateInfo(card_model);
  }

  public static void useCard(string key) {
    switch(key) {
      case "fire":
        DataMgr.Increment("wood", -2);
        DataMgr.Increment("item_fire", 1);
        CommonUtil.changeText("main_text", "焚き火を作る事に成功した！\n火……それは文明の証だ！");
        break;
      case "torch":
        DataMgr.Increment("wood", -1);
        DataMgr.Increment("item_torch", 1);
        CommonUtil.changeText("main_text", "焚き火を作る事に成功した！\n火……それは文明の証だ！");
        break;
      default:
        Debug.Log($"unknown craft key. key={key}");
        break;
    }
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



}
