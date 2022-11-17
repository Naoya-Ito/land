using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeinImageObject : MonoBehaviour
{
  Image image;
	public float fadeTime = 1f;
	private float currentRemainTime;

	[SerializeField] public bool isFadeIn = false;

  // Start is called before the first frame update
  void Start(){
    image = this.gameObject.GetComponent<Image>();
  }

    // Update is called once per frame
  void Update(){
    if(!isFadeIn) {
      return;
    }

		currentRemainTime -= Time.deltaTime;
		if ( currentRemainTime <= 0f ) {
			GameObject.Destroy(gameObject);
			return;
		}

		float alpha = currentRemainTime / fadeTime;
		var color = image.color;
		color.a = 1.0f - alpha;
		image.color = color;
  }

  public void fadeStart(){
    currentRemainTime = fadeTime;
    isFadeIn = true;
  }
}
