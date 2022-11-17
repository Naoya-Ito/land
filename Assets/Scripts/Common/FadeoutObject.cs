using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeoutObject : MonoBehaviour{
  public bool isFade = false;
	public float fadeTime = 1f;
  public TextMeshProUGUI  text;

	private float currentRemainTime;
	private SpriteRenderer spRenderer;

	void Start () {
    if(!isFade){
      return;
    } 
		currentRemainTime = fadeTime;
		spRenderer = GetComponent<SpriteRenderer>();

    if(text != null) {
      text.CrossFadeAlpha(0.0f, fadeTime, false);
    }
	}

  public void fadeStart(){
    isFade = true;
    currentRemainTime = fadeTime;
		spRenderer = GetComponent<SpriteRenderer>();
    if(text != null) {
      text.CrossFadeAlpha(0.0f, fadeTime, false);
    }
  }

	void Update () {
    if(!isFade){
      return;
    }

		currentRemainTime -= Time.deltaTime;
		if ( currentRemainTime <= 0f ) {
			GameObject.Destroy(gameObject);
			return;
		}

		float alpha = currentRemainTime / fadeTime;
		var color = spRenderer.color;
		color.a = alpha;
		spRenderer.color = color;
	}
}
