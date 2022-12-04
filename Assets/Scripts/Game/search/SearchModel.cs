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
    SearchMenu.instance.updateInfo(card_model);
  }

  public static void useCard(string key) {
    Debug.Log($"use card. key={key}");
    switch(key) {
      case "forest":
        DataMgr.Increment("mp", -2);
        // TODO HPを5減らす
        searchForest();
        NextButton.instance.hideCardAndShowButton();
        break;
      case "sea":
        DataMgr.Increment("mp", -3);
        // TODO HPを3減らす
        DataMgr.Increment("fish");
        CommonUtil.changeText("main_text", "生魚を一つ見つけたぞ！");
        NextButton.instance.hideCardAndShowButton();
        break;
      default:
        break;
    }
    HeaderBar.updateMPBarCurrent();
    SearchMenu.instance.hide();
  }

  private static void searchForest(){
    int rnd = CommonUtil.rnd(3);
    switch(rnd) {
      case 0:
      case 1:
        DataMgr.Increment("wood");
        CommonUtil.changeText("main_text", "木材を一つ見つけたぞ！");
        break;
      case 2:
        DataMgr.Increment("kinoko");
        CommonUtil.changeText("main_text", "謎のキノコを見つけた。\n食べられるのだろうか？");
        break;
      default:
        break;
    }


  }
}
