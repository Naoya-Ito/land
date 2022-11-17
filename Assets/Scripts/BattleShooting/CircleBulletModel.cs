using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBulletModel : MonoBehaviour {
  // 設定された方向に弾を移動させる
  // 敵の右側が0°
  // 反時計回りに角度は増える
  void OnBecameInvisible(){
    Destroy(gameObject);
  }

  public void changeRandomScale(){
    float new_scale = Random.Range(0.3f, 0.8f);
    gameObject.transform.localScale = new Vector3(new_scale, new_scale, 1);
  }

  // 2PI 360
  // PI 180
  // PI/2 90
  public void angleShot(float angle, float speed){
    Vector2 v;
    v.x = Mathf.Cos(angle) * speed;
    v.y = Mathf.Sin(angle) * speed;
    Rigidbody2D rd = GetComponent<Rigidbody2D>();
    rd.velocity = v;
  }

  public void setGravity(float val){
    Rigidbody2D rd = GetComponent<Rigidbody2D>();
    rd.gravityScale = val;
  }

  void Update(){
//    transform.position += new Vector2(dx, dy, 0) * Time.deltaTime;
  }

  // rotate N angle shot
  public void rotateNShot(int count, float speed){
    int bulletCount = count;
    for (int i = 0; i < bulletCount; i++){
      float angle = i * (2 * Mathf.PI / bulletCount); // 2PI：360
      angleShot(angle, speed);
    }
  }

  public void targetShot(Vector3 fromPos, Vector3 targetPos, float speed){
    float radian = Mathf.Atan2(targetPos.y - fromPos.y, targetPos.x - fromPos.x);

    angleShot(radian, speed);
  }
}