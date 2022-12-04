using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchMenu : MonoBehaviour {
  public RectTransform search_menu;
  public TextMeshProUGUI name;
  public TextMeshProUGUI description;

  public static SearchMenu instance = null;

  private string selected_card = "";
  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  public void show(){
    Vector3 pos = search_menu.position;
    Vector3 new_pos = new Vector3(0, 0, 0);
    search_menu.position = new_pos;
  }

  public void hide(){
    Vector3 pos = search_menu.position;
    Vector3 new_pos = new Vector3(2000, 0, 0);
    search_menu.position = new_pos;
  }

  public void updateInfo(CardModel model){
    name.text = model.name;
    description.text = model.description;
    selected_card = model.cardID;
  }

  public void okButtonDidPushed(){
    SearchModel.useCard(selected_card);
  }
}
