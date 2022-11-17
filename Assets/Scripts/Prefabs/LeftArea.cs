using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArea : MonoBehaviour
{
  void Start(){
        
  }

  void Update(){      
  }

  static public void updateStatus(){
    CommonUtil.changeText("str_text", $"<sprite name=\"str\"> {DataMgr.GetInt("str")}");    
    CommonUtil.changeText("mgi_text", $"<sprite name=\"mgi\"> {DataMgr.GetInt("mgi")}");    
    CommonUtil.changeText("agi_text", $"<sprite name=\"agi\"> {DataMgr.GetInt("agi")}");    
    CommonUtil.changeText("luck_text", $"<sprite name=\"luck\"> {DataMgr.GetInt("luck")}");    
    CommonUtil.changeText("faith_text", $"<sprite name=\"faith\"> {DataMgr.GetInt("faith")}");    
    CommonUtil.changeText("tear_text", $"<sprite name=\"tear\"> {DataMgr.GetInt("tear")}");    
    CommonUtil.changeText("guilty_text", $"{DataMgr.GetInt("guilty")}");    
  }

  static public void updateBattleStatus(){
    CommonUtil.changeText("str_text", $"<sprite name=\"str\"> {BattleMgr.instance.getPlayerParams("str")}");    
    CommonUtil.changeText("mgi_text", $"<sprite name=\"mgi\"> {BattleMgr.instance.getPlayerParams("mgi")}");    
    CommonUtil.changeText("agi_text", $"<sprite name=\"agi\"> {BattleMgr.instance.getPlayerParams("agi")}");    
    CommonUtil.changeText("luck_text", $"<sprite name=\"luck\"> {BattleMgr.instance.getPlayerParams("luck")}");    
    CommonUtil.changeText("faith_text", $"<sprite name=\"faith\"> {BattleMgr.instance.getPlayerParams("faith")}");    
    CommonUtil.changeText("tear_text", $"<sprite name=\"tear\"> {BattleMgr.instance.getPlayerParams("tear")}");    
  }

  static public void fadeOut(){
    GameObject area = GameObject.Find("status_area");
    GameObject str_text = GameObject.Find("str_text");
    GameObject mgi_text = GameObject.Find("mgi_text");
    GameObject agi_text = GameObject.Find("agi_text");
    GameObject luck_text = GameObject.Find("luck_text");
    GameObject faith_text = GameObject.Find("faith_text");
    GameObject tear_text = GameObject.Find("tear_text");
    GameObject guilty_img = GameObject.Find("hakari");
    GameObject guilty_text = GameObject.Find("guilty_text");

    FadeoutObject area_fade = area.GetComponent<FadeoutObject>();
    FadeoutTextObject str_fade = str_text.GetComponent<FadeoutTextObject>();
    FadeoutTextObject mgi_fade = mgi_text.GetComponent<FadeoutTextObject>();
    FadeoutTextObject agi_fade = agi_text.GetComponent<FadeoutTextObject>();
    FadeoutTextObject luck_fade = luck_text.GetComponent<FadeoutTextObject>();
    FadeoutTextObject faith_fade = faith_text.GetComponent<FadeoutTextObject>();
    FadeoutTextObject tear_fade = tear_text.GetComponent<FadeoutTextObject>();
    FadeoutImageObject hakari_fade = guilty_img.GetComponent<FadeoutImageObject>();
    FadeoutTextObject guilty_fade = guilty_text.GetComponent<FadeoutTextObject>();

    area_fade.fadeStart();
    str_fade.fadeStart();
    mgi_fade.fadeStart();
    agi_fade.fadeStart();
    luck_fade.fadeStart();
    faith_fade.fadeStart();
    tear_fade.fadeStart();
    hakari_fade.fadeStart();
    guilty_fade.fadeStart();
  }
}
