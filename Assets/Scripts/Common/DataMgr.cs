using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataMgr : MonoBehaviour{
  public static DataMgr instance = null;

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  void Start(){
    DontDestroyOnLoad(this);
  }

  public static bool GetBool(string key) {
    return PlayerPrefs.GetInt(key) == 1;
  }

  public static void SetBool(string key, bool val){
    if(val) {
      PlayerPrefs.SetInt(key, 1);
    } else {
      PlayerPrefs.SetInt(key, 0);
    }
  }

  public static int GetInt(string key){
    return PlayerPrefs.GetInt(key);
  }

  public static void SetInt(string key, int val){
    PlayerPrefs.SetInt(key, val);
  }

  public static float GetFloat(string key){
    return PlayerPrefs.GetFloat(key);
  }

  public static void SetFloat(string key, float val) {
    PlayerPrefs.SetFloat(key, val);    
  }

  public static void Increment(string key, int up=1) {
    int val = GetInt(key);
    SetInt(key, val+up);

    //if(key=="day" && DataMgr.GetBool("is_debug")){
    if(key=="day"){
      SteamMgr.increment("day");
    }
  }

  public static string GetStr(string key){
    return PlayerPrefs.GetString(key);
  }

  public static void SetStr(string key, string val){
    PlayerPrefs.SetString(key, val);
  }

  public static void SetList(string key, List<string> list) {
    int i = 0;
    foreach (string val in list){
      SetStr($"{key}{i}", val);
      i++;
    }
    SetInt($"{key}_length", i);
  }

  public static List<string> GetList(string key){
    int length = GetInt($"{key}_length");
    List<string> list =  new List<string>() {};
    for(int i=0; i<length; i++) {
      string val = GetStr($"{key}{i}"); 
      list.Add(val);
    }
    return list;
  }

  public static void addList(string key, string val) {
    List<string> list = GetList(key);
    list.Add(val);
    SetList(key, list);
  }

  public static string[] GetArray(string key){
    int length = GetInt($"{key}_length");
    string[] array = new string[length];
    for(int i=0; i<length; i++) {
      string val = GetStr($"{key}{i}"); 
      array[i] = val;
    }
    return array;
  }

  public static void SetArray(string key, string[] array){
    int i = 0;
    foreach (string val in array){
      SetStr($"{key}{i}", val);
      i++;
    }
    SetInt($"{key}_length", i);
  }

  public static void ChangeHP(int val) {
    int hp = GetInt("hp");
    int max_hp = GetInt("max_hp");

    hp += val;
    if(hp >= max_hp) {
      hp = max_hp;
    }
    if(hp < 0) {
      hp = 0;
    }
    DataMgr.SetInt("hp", hp);
  }

  public static void maxHeadl(){
    int max_hp = GetInt("max_hp");
    SetInt("hp", max_hp);
  }
  
  public static bool isDead(){
    int hp = GetInt("hp");
    return hp <= 0;
  }

  public static void countUpDeath(){
    Increment("dead_count");
  }

  static public void dayPast(){
    Increment("day");
  }
}