using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeoutTextObject : MonoBehaviour{
  public bool isFade = false;
	public float fadeTime = 1f;
  private TextMeshProUGUI tmp;
  public bool isDestroy = true;

	private float currentRemainTime;

	void Start () {
    if(!isFade) {
      return;
    }

    tmp = GetComponent<TextMeshProUGUI>();
		currentRemainTime = fadeTime;
	}

  public void fadeStart(){
    isFade = true;
    currentRemainTime = fadeTime;
    tmp = GetComponent<TextMeshProUGUI>();		
  }

	void Update () {
    if(!isFade){
      return;
    }

		currentRemainTime -= Time.deltaTime;
		if ( currentRemainTime <= 0f && isDestroy) {
			GameObject.Destroy(gameObject);
			return;
		}

		float alpha = currentRemainTime / fadeTime;
		var color = tmp.color;
		color.a = alpha;
		tmp.color = color;
	}

  public void show(){
    tmp = GetComponent<TextMeshProUGUI>();
		var color = tmp.color;
		color.a = 1.0f;
		tmp.color = color;
  }
}
