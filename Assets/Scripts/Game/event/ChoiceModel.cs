using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ChoiceModel {
  public string choice_text;
  public string key_name = "";
  public string key_category;
  public string lock_text;
  public string lock_text_sub;
  public string lock_key = "";
  public int lock_val;
  public string lock_flag_name;
  public string[] random_keys;
  public string get_card;
  public string change_key = "";
  public int change_val;
  public int change_hp = 0;
  public string dead_page = "";
  public string set_flag = "";
  public BattleInfoModel battle_info;
  public bool isDayPast;

  public string getEventKey(int i){
    if(isDayPast) return "";

    if(random_keys == null || random_keys.Length == 0) {
      if(key_name == "") {
        key_name = $"{i}";
      }
      return key_name;
    }

    return CommonUtil.getRndStrByArray(random_keys);
  }

  public bool isChoiceLock(){
    if(lock_key == "") return false;

    if(lock_key == "flag") {
      return !DataMgr.GetBool(lock_flag_name);
    } else{
      return DataMgr.GetInt(lock_key) < lock_val;
    }
  }
}