using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderBar : MonoBehaviour{

  // TODO 減少分の値をバーで表示
  public static void updateMpBar(int val, int max_val){
    double mp_per = (double)val/(double)max_val;
    int length = (int)(200*mp_per);
    CommonUtil.setRectWidth("mp_bar", length);
    CommonUtil.changeText("mp_text", $"{val}/{max_val}");
  }

  public static void updateMPBarCurrent(){
    int now_mp = DataMgr.GetInt("mp");
    int max_mp = DataMgr.GetInt("max_mp");
    updateMpBar(now_mp, max_mp);
  }
}
