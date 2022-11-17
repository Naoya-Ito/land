using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel {
  public string enemyID;
  public string name;
  public string image;
  public string start_text;
  public string dead_text;
  public int lv;
  public float speed;
  public float speedRepeat;
  public int max_hp;
  public int hp;
  public int str;
  public bool isTrap;
  public bool isBoss;
  public EnemyAttackModel[] attacks;
  public List<string> drop;
  public bool is_half_hp;

  public EnemyModel(string enemyID){
    EnemyEntity enemyEntity = Resources.Load<EnemyEntity>("EnemyEntityList/" + enemyID);
    if(enemyEntity == null) {
      Debug.Log($"Error!! EnemyModel. load key={enemyID} is not exist.");

      enemyEntity = Resources.Load<EnemyEntity>("EnemyEntityList/zombi");
    }

    this.enemyID = enemyID;
    name = enemyEntity.name;
    image = enemyEntity.image;
    start_text = enemyEntity.start_text;
    dead_text = enemyEntity.dead_text;
    speed = enemyEntity.speed;
    speedRepeat = enemyEntity.speedRepeat;
    attacks = enemyEntity.attacks;
    drop = enemyEntity.drop;
    is_half_hp = enemyEntity.is_half_hp;
    isTrap = enemyEntity.isTrap;
    isBoss = enemyEntity.isBoss;

    lv = enemyEntity.lv;
    setStatus();
  }

  private void setStatus(){
    if(lv <= 10) {
      max_hp = 5 + lv*lv;
    } else {
      max_hp = 110 + (lv-10)*(lv-10);

    }
    hp = max_hp;

    if(is_half_hp) {
      max_hp = max_hp/2;
      hp = hp/2;
    }
    if(SkillModel.isGetSkill("iatu")) hp = hp*9/10;
    str = lv;

    if(enemyID == "egoda") {
      str = 20;
      max_hp *= 2;
      hp *= 2;
    }
  }
}