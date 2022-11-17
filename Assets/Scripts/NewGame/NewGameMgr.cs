using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameMgr : MonoBehaviour
{
  public GameObject str_button;
  public GameObject mgi_button;
  public GameObject agi_button;
  public GameObject luck_button;
  public GameObject hp_button;
  public GameObject gold_button;

  void Start() {
    updateScene();
  }

  private void updateScene(){
    int str_up = DataMgr.GetInt("str_up");
    int mgi_up = DataMgr.GetInt("mgi_up");
    int agi_up = DataMgr.GetInt("agi_up");
    int luck_up = DataMgr.GetInt("luck_up");
    int hp_up = DataMgr.GetInt("hp_up");
    int gold_up = DataMgr.GetInt("gold_up");
    CommonUtil.changeText("str", $"ゲーム開始時の<sprite name=\"str\"> +1 (現在: {1+str_up})");
    CommonUtil.changeText("mgi", $"ゲーム開始時の<sprite name=\"mgi\"> +1 (現在: {1+mgi_up})");
    CommonUtil.changeText("agi", $"ゲーム開始時の<sprite name=\"agi\"> +1 (現在: {1+agi_up})");
    CommonUtil.changeText("luck", $"ゲーム開始時の<sprite name=\"luck\"> +1 (現在: {1+luck_up})");
    CommonUtil.changeText("hp", $"ゲーム開始時の<sprite name=\"heart\"> +1 (現在: {10+hp_up})");
    CommonUtil.changeText("gold", $"1日ごとの収入 <sprite name=\"gold\"> +1 (現在:{gold_up})");

    int str_cost = 10 + str_up*10;
    int mgi_cost = 10 + mgi_up*10;
    int agi_cost = 10 + agi_up*10;
    int luck_cost = 10 + luck_up*10;
    int hp_cost = 5 + hp_up*5;
    int gold_cost = 10 + gold_up*15;

    CommonUtil.changeText("str_cost", $"{str_cost}");
    CommonUtil.changeText("mgi_cost", $"{mgi_cost}");
    CommonUtil.changeText("agi_cost", $"{agi_cost}");
    CommonUtil.changeText("luck_cost", $"{luck_cost}");
    CommonUtil.changeText("hp_cost", $"{hp_cost}");
    CommonUtil.changeText("gold_cost", $"{gold_cost}");

    int soul = DataMgr.GetInt("soul");
    CommonUtil.changeText("soul", $"所持ソウル {soul}");
//    Debug.Log($"soul={soul}. agi_cost={agi_cost}");
    if(soul < str_cost)  str_button.SetActive(false);
    if(soul < mgi_cost)  mgi_button.SetActive(false);
    if(soul < agi_cost)  agi_button.SetActive(false);
    if(soul < luck_cost) luck_button.SetActive(false);
    if(soul < hp_cost)   hp_button.SetActive(false);
    if(soul < gold_cost) gold_button.SetActive(false);
  }

  public void goGame(){
    DataMgr.Increment("str", DataMgr.GetInt("str_up"));
    DataMgr.Increment("mgi", DataMgr.GetInt("mgi_up"));
    DataMgr.Increment("agi", DataMgr.GetInt("agi_up"));
    DataMgr.Increment("luck", DataMgr.GetInt("luck_up"));
    DataMgr.Increment("hp", DataMgr.GetInt("hp_up"));
    DataMgr.Increment("max_hp", DataMgr.GetInt("hp_up"));
    DataMgr.SetInt("income", DataMgr.GetInt("gold_up"));

    DataMgr.SetBool("new_game", false);
    DataMgr.SetStr("pv_text", $"1日目");
    CommonUtil.changeScene("PVScene");
  }

  public void pushedUp(string key) {
    int str_up = DataMgr.GetInt("str_up");
    int mgi_up = DataMgr.GetInt("mgi_up");
    int agi_up = DataMgr.GetInt("agi_up");
    int luck_up = DataMgr.GetInt("luck_up");
    int hp_up = DataMgr.GetInt("hp_up");
    int gold_up = DataMgr.GetInt("gold_up");

    int str_cost = 10 + str_up*10;
    int mgi_cost = 10 + mgi_up*10;
    int agi_cost = 10 + agi_up*10;
    int luck_cost = 10 + luck_up*10;
    int hp_cost = 10 + hp_up*10;
    int gold_cost = 10 + gold_up*10;

    DataMgr.Increment($"{key}_up", 1);
    int soul = DataMgr.GetInt("soul");
    switch(key) {
    case "str":
      if(soul >= str_cost) DataMgr.Increment("soul", -str_cost);
      break;
    case "mgi":
      if(soul >= mgi_cost) DataMgr.Increment("soul", -mgi_cost);
      break;
    case "agi":
      if(soul >= agi_cost) DataMgr.Increment("soul", -agi_cost);
      break;
    case "luck":
      if(soul >= luck_cost) DataMgr.Increment("soul", -luck_cost);
      break;
    case "hp":
      if(soul >= hp_cost) DataMgr.Increment("soul", -hp_cost);
      break;
    case "gold":
      if(soul >= gold_cost) DataMgr.Increment("soul", -gold_cost);
      break;
    default:
      break;
    }
    updateScene();
  }
}
