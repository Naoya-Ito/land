using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour{
  [SerializeField] TextMeshProUGUI nameText;
  [SerializeField] Image image;
  [SerializeField] Image num_image;
  [SerializeField] TextMeshProUGUI num_text;

  public void updateView(CardModel cardModel){
    nameText.text = cardModel.name;
    if(cardModel.name.Length >= 4) {
      nameText.fontSize = 20;
    } else {
      nameText.fontSize = 30;
    }

    changeNumIcon(cardModel);
    changeImage(cardModel.image);
  }

  private void changeNumIcon(CardModel cardModel){
    if(cardModel.card_type != CardEntity.card_type_enum.item) {
      num_image.enabled = false;
      num_text.text = "";
      num_text.fontSize = 30;
    } else {
      int num = DataMgr.GetInt(cardModel.cardID);
      num_text.text = $"{num}";
      if(num > 9) {
        num_text.fontSize = 20;
      } else {
        num_text.fontSize = 30;
      }
    }
  }

  private void changeImage(string image_path){
    Sprite sprite = Resources.Load<Sprite>("Textures/" + image_path);
    if(sprite == null){
      Debug.Log($"sprite not found. image_path={image_path}");
    }
    image.sprite = sprite;
  }

  private void changeMultipleImage(string image_path, string multiple_image_name){
      Sprite sprite = CommonUtil.getSpriteFromMultiple(image_path, multiple_image_name);
    if(sprite == null){
      Debug.Log($"mulriplw sprite not found. image_path={image_path}, multiple={multiple_image_name}");
    }
    image.sprite = sprite;
  }
}