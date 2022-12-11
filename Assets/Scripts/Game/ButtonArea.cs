using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArea : MonoBehaviour {

  public RectTransform buttonArea;
  public Button craftButton;
  public Button cookButton;
  public Button itemButton;

  public static ButtonArea instance = null;
  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  void Start() {
    SearchModel.instance.setSearcList();
    int search_num = SearchModel.instance.list.Count;
    CommonUtil.changeText("search_button_text", $"探索({search_num})");
    SearchModel.instance.updateSearcList();

    CraftModel.instance.setCraftList();
    int craft_num = CraftModel.instance.list.Count;
    if(craft_num > 0) {
      CommonUtil.changeText("craft_button_text", $"クラフト({craft_num})");
      Instantiate(craftButton, buttonArea);
    }

    CookModel.instance.setCookList();
    int cook_num = CookModel.instance.list.Count;
    if(cook_num > 0) {
      CommonUtil.changeText("cook_button_text", $"料理({cook_num})");
      Instantiate(cookButton, buttonArea);
    }

    ItemModel.instance.setItemList();
    int item_num = ItemModel.instance.list.Count;
    if(item_num > 0) {
      CommonUtil.changeText("item_button_text", $"アイテム({item_num})");
      Instantiate(itemButton, buttonArea);
    }
  }

  public void addButton(string key){
    switch(key) {
      case "cook":
        Instantiate(cookButton, buttonArea);
        break;
      default:
        break;
    }
  }
}