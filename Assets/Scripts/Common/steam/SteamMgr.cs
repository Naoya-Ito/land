using UnityEngine;
using System.Collections;
using Steamworks;
using System;

public class SteamMgr : MonoBehaviour {

// appID の取得 SteamUtils.GetAppID()
// player name の取得 SteamFriends.GetPersonaName()

// データのセット
// SteamUserStats.SetStat(api, value)
// データの取得(apiがAPI名でstring、valueが取得するデータでintかfloat)
// SteamUserStats.GetStat(api, out value);
// StoreStats() で store にデータ送信

// 実績を直接解除したい時はSteamUserStats.SetAchievementを使います。
// 実績の解除(apiがAPI名でstring)
// SteamUserStats.SetAchievement(api);

  void Start() {
    /*
    if(SteamManager.Initialized) {
      Debug.Log("steam api initialize");
//      string name = SteamFriends.GetPersonaName();
//      Debug.Log(name);
    }
    */
    if (!SteamManager.Initialized) {
      Debug.LogWarning("SteamManagerの初期化に失敗しました");
      return;
    }
  }

  public static void setAchievement(string api){
    try{
      SteamUserStats.SetAchievement(api);
    } catch (Exception e){
      Debug.Log(e);
      Debug.Log("setAchievementでエラー発生");
    }
  }
  
  public static void increment(string key) {
    try{
      SteamUserStats.GetStat(key, out int now_val);
      SteamUserStats.SetStat(key, now_val+1);
      SteamUserStats.StoreStats();
    } catch (Exception e){
      Debug.Log(e);
      Debug.Log("setAchievementでエラー発生");
    }
  }
}