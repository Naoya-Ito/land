using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeoutImageObject : MonoBehaviour
{
  Image image;
	public float fadeTime = 1f;
	private float currentRemainTime;
  public bool isDestroy = true;

	[SerializeField] public bool isFadeOut = false;

  // Start is called before the first frame update
  void Start(){
    image = this.gameObject.GetComponent<Image>();
  }

    // Update is called once per frame
  void Update(){
    if(!isFadeOut) {
      return;
    }

		currentRemainTime -= Time.deltaTime;
		if ( currentRemainTime <= 0f && isDestroy ) {
			GameObject.Destroy(gameObject);
			return;
		}

		float alpha = currentRemainTime / fadeTime;
		var color = image.color;
		color.a = alpha;
		image.color = color;
  }

  public void fadeStart(){
    currentRemainTime = fadeTime;
    isFadeOut = true;
  }

  public void show(){
		var color = image.color;
		color.a = 1.0f;
		image.color = color;
  }
}
