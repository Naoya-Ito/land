using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ChoiceModel
{
  public string choice_text;
  public string key_name = "";
  public string lock_text;
  public string lock_text_sub;
  public string lock_key = "";
  public int lock_val;
  public string lock_flag_name;
  public string[] random_keys;
  public string get_card;
  public string change_key = "";
  public int change_val;
  public string set_flag = "";

  public bool isChoiceLock(){
    if(lock_key == "") return false;

    if(lock_key == "flag") {
      return !DataMgr.GetBool(lock_flag_name);
    } else{
      return DataMgr.GetInt(lock_key) < lock_val;
    }
  }
}
