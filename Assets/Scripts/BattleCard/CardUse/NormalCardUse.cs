using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCardUse : MonoBehaviour{

//  private List<string> keys = new List<string>() { "bomb", "donut", "gold", "mushiba", "punch", "quest", "ramen", "run", "sushi", "wairo", "yakusou", "yamikin" };

  // TODO 消しても良いかも
  static public List<string> keys = new List<string>() {
    "agi_up", "arisia",
    "dark_sword", "day", "dragon_punch",
    "enchant",
    "fire", "gacha",
    "kojiki", 
    "heal",
    "guilty",
    "ice_sword", "jab",
    "judge",
    "mgi_up", "mini_sword", "mountain", "megami",
    "pluck", "punch",
    "revenge",
    "sacrifice",
    "sinobi",
    "str_up",
    "ring",
    "tmp_str_up", 
    "thunder",
    "yakusou"
  };

  // TODO †ダガー†

  // FIXME animation
  static public void useCard(string key){ 
//    Debug.Log($"play card. key={key}");
    int damage = 1;
    switch(key) {
      case "agi_up":
        BattleMgr.instance.changePlayerParams("agi", 10);
        break;
      case "arisia":
        BattleMgr.instance.str = 1;
        BattleMgr.instance.heal(20); 
        break;
      case "big_sword":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");
        BattleCardMgr.instance.getCard("hirou");
        break;
      case "dark_sword":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");
        BattleCardMgr.instance.getCard("curse");
        break;
      case "day":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "BombEffect");
        break;
      case "dragon_punch":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "BombEffect");
        break;
      case "drop":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "BombEffect");
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");        
        break;
      case "enchant":
        damage = CardStr.getStr(key);
        BattleMgr.instance.changePlayerParams("str", damage);
        break;
      case "fire":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "FireEffect");
        break;
      case "gacha":
        damage = 1 + CommonUtil.rnd(99);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");        
        break;
      case "glass_shield":
        BattleMgr.instance.changePlayerParams("def", 17);
        BattleMgr.instance.updateShield();
        break;
      case "glass_sword":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");
        break;
      case "ghost":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "BombEffect");
        break;
      case "guilty":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");        
        break;
      case "guard":
        BattleMgr.instance.changePlayerParams("def", 4);
        BattleMgr.instance.updateShield();
        break;
      case "heal":
        damage = CardStr.getStr(key);
        BattleMgr.instance.heal(damage);
        break;
      case "ice_sword":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");
        break;
      case "jab":
        BattleCardMgr.instance.getCard("punch");
        BattleCardMgr.instance.getCard("punch");
        BattleCardMgr.instance.getCard("punch");
        break;
      case "judge":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "FireEffect");
        break;
      case "kioku":
        BattleCardMgr.instance.pile = new List<string>() {};
        BattleCardMgr.instance.updatePileDrop();
        break;
      case "kojiki":
        BattleMgr.instance.changePlayerParams("gold", 2);
        break;
      case "lance":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "BombEffect");
        break;
      case "magic_shield":
        BattleMgr.instance.changePlayerParams("def", BattleMgr.instance.getPlayerParams("mgi"));
        BattleMgr.instance.updateShield();
        break;
      case "mad":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "BombEffect");
        break; 
      case "megami":
        BattleMgr.instance.heal(9999);
        break;
      case "mgi_up":
        BattleMgr.instance.changePlayerParams("mgi", 4);
        break;
      case "mini_sword":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");
        break;
      case "mountain":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "FireEffect");
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");        
        break;
      case "nin":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "BombEffect");
        break;
      case "pari":
        BattleMgr.instance.changePlayerParams("def", 11);
        BattleMgr.instance.updateShield();
        break;
      case "pluck":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");
        break;
      case "punch":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "BombEffect");
        break;
      case "revenge":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "BombEffect");
        break;
      case "ring":
        BattleCardMgr.instance.mp += 1;
        CommonUtil.changeText("mp", $"MP{BattleCardMgr.instance.mp}");
        break;
      case "samurai":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");
        break;
      case "shield":
        BattleMgr.instance.changePlayerParams("def", BattleMgr.instance.getPlayerParams("faith"));
        BattleMgr.instance.updateShield();
        break;
      case "sinobi":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");
        break;
      case "sister":
        BattleCardMgr.instance.drawCard();
        BattleCardMgr.instance.drawCard();
        break;
      case "sogeki":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "BombEffect");
        break;
      case "str_up":
        BattleMgr.instance.changePlayerParams("str", 2);
        break;
      case "sword_white":
          if(BattleMgr.instance.enemy.enemyID != "arisis") return;

          DataMgr.SetStr("event_key", "igni/kill");
          DataMgr.SetStr("pv_text", "「なくした小指が痛む」");
          DataMgr.SetBool("is_white", true);
          CommonUtil.changeScene("PVScene");
          BGMMgr.instance.stopMusic();
      /*
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);
        ImagesEffect.createEffect(0, 1.4f, "SwordEffect");
        */
        break;
      case "tmp_str_up":
        BattleMgr.instance.changePlayerParams("str", 7);
        break;
      case "thunder":
        damage = CardStr.getStr(key);
        BattleCardMgr.instance.dealDamage(damage);

        // TODO 雷エフェクト
        ImagesEffect.createEffect(0, 1.4f, "FireEffect");
        break;
      case "yakusou":
        BattleMgr.instance.heal(5);
        break;
      default:
        Debug.Log($"normal card use error. {key} is not exist");
        break;
    }
  }

  static public bool isCard(string key){
    return keys.Contains(key);
  }
}
