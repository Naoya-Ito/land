using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBulletModel : MonoBehaviour {
  void OnBecameInvisible(){
    Destroy(gameObject);
  }

  public void changeRandomScale(){
    float new_scale = Random.Range(0.3f, 0.8f);
    gameObject.transform.localScale = new Vector3(new_scale, new_scale, 1);
  }

  public void SetVelocity(float dx, float dy){
    Vector2 v;
    v.x = dx;
    v.y = dy;
    Rigidbody2D rd = GetComponent<Rigidbody2D>();
    rd.velocity = v;
  }

  public void setGravity(float val){
    Rigidbody2D rd = GetComponent<Rigidbody2D>();
    rd.gravityScale = val;
  }

  void Update(){
  }
}