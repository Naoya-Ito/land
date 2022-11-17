using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyMoveDetailModel{
  public enum move_type {
    stop,
    ziguzagu,
    targetMove,
    randomMove
  }

  [SerializeField] public move_type move_name = move_type.stop;
}
