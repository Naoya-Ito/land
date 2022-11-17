using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyAttackDetailModel{
  public float start_time;
  public float repeat_time;
  public enum attack_type {
    targetHeartShot,
    targetHeartFromWorld,
    targetHeartFromUnderWorld,
    randomFromUpWorld,
    randomShot,
    execRotateNShot,
    execRotateGravityNShot,
    meteoRain,
    commetFromLeft,
    commetFromRight,
  }

  [SerializeField] public attack_type attack_name = attack_type.execRotateNShot;
}
