using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInObject : MonoBehaviour{
	public float fadeTime = 1f;
  public Text text;

	private float currentRemainTime;
	private SpriteRenderer spRenderer;

	void Start () {
		currentRemainTime = fadeTime;
		spRenderer = GetComponent<SpriteRenderer>();

    if(text != null) {
      text.CrossFadeAlpha(0.0f, fadeTime, false);
    }
	}

	void Update () {
		currentRemainTime -= Time.deltaTime;
		if ( currentRemainTime <= 0f ) {
			return;
		}

		float alpha = 1.0f - currentRemainTime / fadeTime;
		var color = spRenderer.color;
		color.a = alpha;
		spRenderer.color = color;
	}
}
