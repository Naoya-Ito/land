using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubMenu : MonoBehaviour {
  public RectTransform sub_menu;
  public TextMeshProUGUI name;
  public TextMeshProUGUI description;

  public static SubMenu instance = null;

  private CardEntity.card_type_enum card_type;
  private string selected_card = "";
  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void show(){
    Vector3 pos = sub_menu.position;
    Vector3 new_pos = new Vector3(0, 0, 0);
    sub_menu.position = new_pos;
  }

  public void hide(){
    Vector3 pos = sub_menu.position;
    Vector3 new_pos = new Vector3(2000, 0, 0);
    sub_menu.position = new_pos;
  }

  public void updateInfo(CardModel model){
    name.text = model.name;
    description.text = model.description;
    selected_card = model.cardID;
    card_type = model.card_type;
  }

  public void okButtonDidPushed(){
    switch(card_type) {
      case CardEntity.card_type_enum.search:
        SearchModel.useCard(selected_card);
        break;
      case CardEntity.card_type_enum.craft:
        CraftModel.useCard(selected_card);
        break;
      default:
        Debug.Log($"Error! card_type={card_type}");
        break;
    }
  }
}
