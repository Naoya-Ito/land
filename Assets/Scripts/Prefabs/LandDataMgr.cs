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

  public static initData(){
    DataMgr.SetInt("day", 1);
    GameData.SetBool("is_game", true);
  }
}
