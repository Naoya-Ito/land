using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyAttackModel{
  [Multiline] public string attack_text;
  public float circle_speed;
  public bool is_change_size;
  public EnemyAttackDetailModel[] attacks;
  public EnemyMoveDetailModel move;
}
