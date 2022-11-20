using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour{
  [SerializeField] TextMeshProUGUI nameText;
  [SerializeField] Image image;

  public void updateView(CardModel cardModel){
    nameText.text = cardModel.name;
    if(cardModel.name.Length >= 4) {
      nameText.fontSize = 20;
    } else {
      nameText.fontSize = 30;
    }

    changeImage(cardModel.image);
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