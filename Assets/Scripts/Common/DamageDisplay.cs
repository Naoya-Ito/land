using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageDisplay : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI damageText; //ダーメージテキストを格納
  [SerializeField] private GameObject obj; // 表示先オブジェクト

  private Vector3 pos;//表示座標を格納
  private GameObject canvas;//親にするキャンバスを格納

  void Start(){
/*
    Vector3 obj_pos = obj.GetComponent<Transform>().position;
    pos = Camera.main.ScreenToWorldPoint(obj_pos);
    */
    pos = obj.GetComponent<Transform>().position;
    canvas = GameObject.Find("Canvas");
  }

  void Update(){
  }

  public void showText(string damage_text){
    TextMeshProUGUI text;
    text = Instantiate(damageText, new Vector3(0,0,0), Quaternion.identity);
    text.transform.SetParent(obj.transform, false);
//    text.transform.position = pos;
    text.text = damage_text; 
  }
}
