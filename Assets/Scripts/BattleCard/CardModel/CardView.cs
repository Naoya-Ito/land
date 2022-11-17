using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour{
  [SerializeField] TextMeshProUGUI nameText, descriptionText, cost, damage;
  [SerializeField] Image iconImage;
  [SerializeField] Image background;
  [SerializeField] Image damage_image;
  [SerializeField] Image cost_image;
  [SerializeField] GameObject cardPanel;
  private GameObject panel;

  public void updateView(CardModel cardModel){
    nameText.text = cardModel.name;
    if(cardModel.name.Length >= 4) {
      nameText.fontSize = 20;
    } else {
      nameText.fontSize = 30;
    }

    descriptionText.text = cardModel.description.ToString();
    if(cardModel.is_mini_description) {
      descriptionText.fontSize = 20;      
    }

    cost.text = cardModel.cost.ToString();
    if(cardModel.multiple_image_name != "" && cardModel.multiple_image_name != null) {
      changeMultipleImage(cardModel.icon, cardModel.multiple_image_name);
    } else {
      changeImage(cardModel.icon);
    }
    changeBackground(cardModel.background);

    if(cardModel.cantUse) {
      cardPanel.GetComponent<Image>().color = Color.red;
      cost_image.gameObject.SetActive(false);
    }

    if(cardModel.card_type != CardEntity.card_type_enum.attack) {
      damage_image.gameObject.SetActive(false);
    } else {
      if(cardModel.cardID == "gacha") {
        damage.text = "?";
      } else {
        damage.text = cardModel.damage.ToString();
        if(cardModel.damage >= 100) {
          damage.fontSize = 20;
        }
      }
    }
  }


  private void changeImage(string image_path){
    Sprite sprite = Resources.Load<Sprite>("Textures/" + image_path);
    if(sprite == null){
      Debug.Log($"sprite not found. image_path={image_path}");
    }
    iconImage.sprite = sprite;
  }

    private void changeMultipleImage(string image_path, string multiple_image_name){
      Sprite sprite = CommonUtil.getSpriteFromMultiple(image_path, multiple_image_name);
    if(sprite == null){
      Debug.Log($"mulriplw sprite not found. image_path={image_path}, multiple={multiple_image_name}");
    }
    iconImage.sprite = sprite;
  }


  private void changeBackground(string key){
    switch (key) {
    case "black":
      background.color = Color.black;
      break;
    case "white":
      background.color = Color.white;
      break;
    default:
      break;
    }
  }

 /*
  void Start(){
    updateCard("ramen");
  }
  */
}