using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextModel : MonoBehaviour
{
  public string text;

  public TextModel(string key){
    TextEntity entity = Resources.Load<TextEntity>($"TextEntityList/{key}");
    if(entity == null) {
      Debug.Log($"text entity not exist. key={key}");
      return;
    }
    
    int i = CommonUtil.rnd(entity.texts.Length);
    this.text = entity.texts[i].text;
  }
}
