using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandDataMgr : MonoBehaviour
{
  public static void resetItems(){
    foreach (string key in ItemModel.all_list){
      DataMgr.SetInt(key, 0);
    }
    foreach (string key in CraftModel.all_list){
      DataMgr.SetBool(key, false);
    }
  }


  // 個数を０にするリスト
  public static List<string> num_reset_list = new List<string>() {
    "wood",
    "kinoko",
    "fish",
    "item_torch",
    "item_fire",
  };
  public static List<string> bool_reset_list = new List<string>() {
    "",
  };

  // TODO HPなど仲間情報も初期化
  public static void initData(){
    DataMgr.SetInt("day", 1);
    DataMgr.SetInt("mp", 100);
    DataMgr.SetInt("max_mp", 100);

    DataMgr.SetStr("time", "morning");
    DataMgr.SetStr("event", "");

    DataMgr.SetBool("is_game", true);

    foreach(string key in num_reset_list) {
      DataMgr.SetInt(key, 0);
    }
    foreach(string key in bool_reset_list) {
      DataMgr.SetBool(key, false);
    }
  }

  public static void timePast(){
    string time = DataMgr.GetStr("time");
    switch(time) {
      case "morning":
        DataMgr.SetStr("time", "evening");
        break;
      case "evening":
        DataMgr.SetStr("time", "sunset");
        break;
      case "sunset":
        DataMgr.SetStr("time", "night");
        break;
      case "night":
        DataMgr.SetStr("time", "morning");
        DataMgr.Increment("day");
        break;
      default:
        Debug.Log($"Error!! time past. unknown time={time}");
        break;
    }
  }

  // TODO mp の場合、最大値を超えない、バーを変更するなどが必要
  public static void changeData(ChangeData[] change_data){
    if(change_data.Length == 0) return;

    foreach(ChangeData data in change_data) {
      if(data.change_key != "") {
        DataMgr.Increment(data.change_key, data.change_val);
      }
      if(data.flag_true != "") {
        DataMgr.SetBool(data.flag_true, true);
      }
      if(data.flag_false != "") {
        DataMgr.SetBool(data.flag_false, true);
      }
    }
  }

  public static string getDisplayNamByKey(string key){
    switch(key) {
      case "hp":
        return "体力";
      case "mp":
        return "正気度";
      case "wood":
        return "木材";
      case "fish":
        return "生魚";
      default:
      break;
    }
    return $"名称未設定 {key}";
  }

}
