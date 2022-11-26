using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandDataMgr : MonoBehaviour
{
  public static void resetItems(){
    foreach (string key in ItemModel.all_list){
      DataMgr.SetInt(key, 0);
    }
  }
}
