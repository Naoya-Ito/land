using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStr : MonoBehaviour{

/*
  static public List<string> keys = new List<string>() {
    "dark_sword", "day", "dragon_punch",
    "fire", "kojiki", "mini_sword",  
    "ghost", "goblin", "guilty",
    "enchant",
    "heal",
    "ice_sword",
    "judge",
    "mad",
    "pluck", "punch",
    "revenge",
    "sogeki",
    "thunder"
    };
    */

  static public int getStr(string key){
    switch(key) {
      case "big_sword":
        return getParams("str")*2;
      case "dark_sword":
        return getParams("str")*2;
      case "day":
        int day = DataMgr.GetInt("day");
        return day;
      case "dragon_punch":
        return getParams("str")*25;
      case "drop":
        if(BattleCardMgr.instance == null) {
          return 0;
        } else {
          return BattleCardMgr.instance.drop.Count;
        }
      case "enchant":
        return getParams("mgi");
      case "fire":
        return getParams("mgi");
      case "ghost":
        return 18;
      case "lance":
        return getParams("str")*4;
      case "mad":
        return 27;
      case "mini_sword":
        return getParams("str") + 7;
      case "mountain":
        if(BattleCardMgr.instance == null) {
          return 0;
        } else {
          return BattleCardMgr.instance.pile.Count;
        }
      case "nin":
        return 3;
      case "glass_sword":
        return 19;
      case "goblin":
        return 7;
      case "guilty":
        return getParams("guilty");
      case "heal":
        return getParams("faith");
      case "ice_sword":
      Debug.Log($"{getParams("str")}*{getParams("mgi")}");
        return getParams("str")*getParams("mgi")/2;
      case "judge":
        return getParams("faith")*10;
      case "pluck":
        return getParams("luck")*3;
      case "punch":
        return getParams("str")+1;
      case "revenge":
        return getParams("max_hp")-getParams("hp");
      case "sinobi":
        return getParams("agi")+2;
      case "samurai":
        return getParams("str")+getParams("agi");
      case "sogeki":
        return 41;
      case "sword_white":
        return 44;
      case "thunder":
        return getParams("mgi")*2;
      default:
        return 3;
    }
  }

  static private int getParams(string key){
    if(BattleMgr.instance != null) {
      return BattleMgr.instance.getPlayerParams(key);
    }

    return DataMgr.GetInt(key);
  }

}
