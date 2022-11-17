using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour{

  public static void updateLifeBar(int val, int max_val){
    double life_per = (double)val/(double)max_val;
    int length = (int)(200*life_per);
    CommonUtil.setRectWidth("life_bar", length);
    CommonUtil.changeText("life_text", $"{val}/{max_val}");
  }

  public static void showDef(int val){
    CommonUtil.showImage("def");
    CommonUtil.changeText("def_text", $"{val}");
  }

  public static void hideDef(){
    CommonUtil.showImage("def");
    CommonUtil.unvisibleImage("def");
  }
}
