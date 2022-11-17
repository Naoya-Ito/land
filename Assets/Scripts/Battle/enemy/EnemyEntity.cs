using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyEntity", menuName = "Create EnemyEntity")]

public class EnemyEntity : ScriptableObject {
  public string name;
  public int lv;
  public float speed = 3.0f;
  public float speedRepeat = 3.0f;
  public string image;
  [Multiline] public string start_text;
  [Multiline] public string dead_text;
  public bool isTrap;
  public bool isBoss;
  public EnemyAttackModel[] attacks;
  public List<string> drop;
  public bool is_half_hp = false;
}