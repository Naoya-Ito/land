using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodObject : MonoBehaviour {

	public float fadeTime = 2f;
	private float currentRemainTime;
  public SpriteRenderer blood;
  private float now_scale = 1.0f;

  private float START_TIME = 0.8f;
  private bool is_fade = false;

	void Start () {
		currentRemainTime = fadeTime;
		blood = GetComponent<SpriteRenderer>();

    changeRandomScale();

    string now_scene = CommonUtil.getCurrentSceneName();
    if(now_scene == "BattleShootingScene") {
      fadeTime = 1f;
      START_TIME = 0.4f;
    }


    Invoke("fadeStart", START_TIME);

//    blood.size += new Vector2(10.05f, 2.01f);
	}

  // 設定された方向に弾を移動させる
  // 敵の右側が0°
  // 反時計回りに角度は増える
  void OnBecameInvisible(){
//    Destroy(gameObject);
  }

  private void fadeStart(){
    is_fade = true;
  }

  public void changeRandomScale(){
    float new_scale = Random.Range(0.3f, 0.8f);
    now_scale = new_scale;
//    Debug.Log($"change random scale. scale={new_scale}");
    gameObject.transform.localScale = new Vector3(new_scale, new_scale, 1);
  }

  public void toMinimum(){
    now_scale -= 0.00001f;
    if(now_scale < 0.0f) {
      now_scale = 0.0f;
      return;
    }
    gameObject.transform.localScale = new Vector3(now_scale, now_scale, 1);

  }

  void Update(){
    if(!is_fade) {
      return;
    }
//    toMinimum();

    currentRemainTime -= Time.deltaTime;
		if ( currentRemainTime <= 0f ) {
			GameObject.Destroy(gameObject);
//			return;
		}

		float alpha = currentRemainTime / fadeTime;
    if(alpha > 180.0f/255.0f) {
      return;
    }

		var color = blood.color;
		color.a = alpha;
		blood.color = color;
  }

  public void changeWidth(){


  }

}
