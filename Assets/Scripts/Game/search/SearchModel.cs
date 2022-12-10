using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchModel : MonoBehaviour
{
  [SerializeField] CardController cardPrefab;
  public RectTransform cardArea;

  public static List<string> all_list = new List<string>() {
    "forest",
    "sea",
    "cave"
  };

  public List<string> list = new List<string>() {};

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

  public void setSearcList(){
    foreach(string key in SearchModel.all_list) {
      if(key == "cave" && DataMgr.GetInt("torch") == 0) continue; 

      list.Add(key);
    }
  }

  public void updateSearcList(){
    CardArea.instance.resetAllCard();
    foreach(string key in list) {
      CardController card = Instantiate(cardPrefab, cardArea);
      card.Init(key, "search");
    }
  }

  public void updateSubMenu(CardModel card_model){
    SubMenu.instance.updateInfo(card_model);
  }

  public static void useCard(string key) {
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
        Debug.Log($"unknown search key. key={key}");
        break;
    }
    HeaderBar.updateMPBarCurrent();
    SubMenu.instance.hide();
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
