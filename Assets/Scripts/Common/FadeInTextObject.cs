using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeInTextObject : MonoBehaviour{
	public float fadeTime = 1f;
  public TextMeshProUGUI tmp;

	private float currentRemainTime;

	void Start () {
		currentRemainTime = fadeTime;

//    tmp.CrossFadeAlpha(0.0f, fadeTime, false);
	}

	void Update () {
		currentRemainTime -= Time.deltaTime;
		if ( currentRemainTime <= 0f ) {
			return;
		}

		float alpha = 1.0f - currentRemainTime / fadeTime;
		var color = tmp.color;
		color.a = alpha;
    tmp.color = color;
	}

  public void show(){
		var color = tmp.color;
		color.a = 1.0f;
		tmp.color = color;
  }
}
