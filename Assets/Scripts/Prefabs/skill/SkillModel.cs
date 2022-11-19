using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillModel : MonoBehaviour{
  public string skillID;
  public string title;
  public string description;
  public int cost;
  public bool isGet = false;

  public static List<string> all_list = new List<string>() {   
    // 10
    "day_heal",  // ok
    "ikari",   // ok
    "keikai",  // ok
    "yakusou",  // ok

    // 20
    "meisou", // ok

    // 30
    "knife",  // ok
    "teate",

    // 50
    "dark",
    "power",
    "thief",
    "wizard",
    "renkin",

    // 70
    "first_attack",  // ok
//    "end_attack",

    // 100
    "iatu",

//    "income",
    // 150
    "mp_boost",

    // 170
    "def",

    // 200
    "first_guard",
//    "super",

    // 210
    "day_str", "day_mgi", "day_agi", "day_luck",

    // 250
    "muteki",
    "jagan",

    // 500
    "hoken",
  };

  public SkillModel(string skillID){
    SkillEntity skillEntity = Resources.Load<SkillEntity>("SkillEntityList/" + skillID);
    if(skillEntity == null) {
      Debug.Log($"skill not exist. id={skillID}");
      return;
    }

    this.skillID = skillID;
    title = skillEntity.title;
    description = skillEntity.text;
    cost = skillEntity.cost;
    isGet = isGetSkill(skillID);
  }

  public static void getSkill(string key, int cost){
    if(!isGetSkill(key)){
      DataMgr.SetBool($"skill_{key}", true);
      DataMgr.Increment("gold", -1*cost);
      SkillList.updateCostWithData();
    }
  }

  public static void forgetSkill(string key, int cost){
    if(isGetSkill(key)){
      DataMgr.SetBool($"skill_{key}", false);
      DataMgr.Increment("gold", cost);

      SkillList.updateCostWithData();
    }
  }

  public static bool isGetSkill(string key){
    return DataMgr.GetBool($"skill_{key}");
  }
}