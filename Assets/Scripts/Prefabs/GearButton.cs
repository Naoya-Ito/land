using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearButton : MonoBehaviour{

  [SerializeField] Image SettingArea;

  public void pressButton(){
    Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    Image panel = Instantiate(SettingArea, canvas.transform);
    panel.name = "SettingMenu";

  }

}
