using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookMenu : MonoBehaviour {
  public RectTransform cook_menu;
  public TextMeshProUGUI name;
  public TextMeshProUGUI time_cost;
  public TextMeshProUGUI item_cost;
  public TextMeshProUGUI description;

  public static CookMenu instance = null;

  private string selected_card = "";
  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void show(){
    Vector3 pos = cook_menu.position;
    Vector3 new_pos = new Vector3(0, pos.y, 0);
    cook_menu.position = new_pos;
  }

  public void hide(){
    Vector3 pos = cook_menu.position;
    Vector3 new_pos = new Vector3(2000, pos.y, 0);
    cook_menu.position = new_pos;
  }

  public void updateInfo(CardModel model){
    name.text = model.name;
    time_cost.text = model.time_cost;
    item_cost.text = model.item_cost;
    description.text = model.description;

    selected_card = model.cardID;
  }

  public void okButtonDidPushed(){
    CookModel.useCard(selected_card);
  }
}
