using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeBar : MonoBehaviour{

  public static void updateLifeBar(int val, int max_val){
    double life_per = (double)val/(double)max_val;
    int length = (int)(200*life_per);
    CommonUtil.setRectWidth("enemy_life_bar", length);
    CommonUtil.changeText("enemy_life_text", $"{val}/{max_val}");
  }
}
