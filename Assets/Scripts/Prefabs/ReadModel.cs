using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadModel : MonoBehaviour
{
  static public void SetRead(string key){
    if(IsRead(key)) {
      return;
    }

    DataMgr.SetBool($"read_{key}", true);

    // 選んだ選択肢の種類
  }

  static public bool IsRead(string key){
    return DataMgr.GetBool($"read_{key}");
  }
}
