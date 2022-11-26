using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubMenu : MonoBehaviour {
  public RectTransform sub_menu;
  public TextMeshProUGUI name;
  public TextMeshProUGUI time_cost;
  public TextMeshProUGUI item_cost;
  public TextMeshProUGUI get_item;
  public TextMeshProUGUI description;

  public static SubMenu instance = null;

  private string selected_card = "";
  private CardEntity.card_type_enum selected_type;
  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  void Start() {
  }

  void Update() {
  }

  public void show(){
    Vector3 pos = sub_menu.position;
    Vector3 new_pos = new Vector3(0, pos.y, 0);
    sub_menu.position = new_pos;
  }

  public void hide(){
    Vector3 pos = sub_menu.position;
    Vector3 new_pos = new Vector3(2000, pos.y, 0);
    sub_menu.position = new_pos;
  }

  public void updateInfo(CardModel model){
    name.text = model.name;
    time_cost.text = model.time_cost;
    item_cost.text = model.item_cost;
    get_item.text = model.get_item;
    description.text = model.description;

    selected_card = model.cardID;
    selected_type = model.card_type;
  }

  public void okButtonDidPushed(){
    switch(selected_type) {
    case CardEntity.card_type_enum.search:
      SearchModel.useCard(selected_card);
      break;
    default:
      break;
    }
  }
}
