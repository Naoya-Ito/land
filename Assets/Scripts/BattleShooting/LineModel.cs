using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineModel : MonoBehaviour {

  public void setLine(Vector3 from, Vector3 to) {
    LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
    lineRenderer.SetPosition(0, from);
    float radian = Mathf.Atan2(to.y - from.y, to.x - from.x);

    // 遠すぎると破線になる
//    Vector3 endPos = new Vector3(1000*Mathf.Cos(radian), 1000*Mathf.Sin(radian), 0);
//    Vector3 endPos = new Vector3(1000*Mathf.Cos(radian), 1000*Mathf.Sin(radian), 0);
    Vector3 endPos = new Vector3(1000*Mathf.Cos(radian), 1000*Mathf.Sin(radian), 0);
    lineRenderer.SetPosition(1, endPos);

    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
//    lineRenderer.startColor = Color.black;
//    lineRenderer.endColor = Color.black;
    lineRenderer.startColor = Color.white;
    lineRenderer.endColor = Color.white;


  }

	public float fadeTime = 6f;
	private float currentRemainTime = 6f;

	void Start () {
		currentRemainTime = fadeTime;
	}

	void Update () {
		currentRemainTime -= Time.deltaTime;

    LineRenderer renderer = gameObject.GetComponent<LineRenderer>();
		float alpha = currentRemainTime / fadeTime;
		var color = renderer.startColor;
		color.a = alpha;

//    renderer.material.SetColor("_Color", new Color(0.5f,0.5f,0.5f ,alpha));
 //   renderer.materials[0].SetColor("_TintColor", new Color(1f,1f,1f ,alpha));
  
    renderer.material.SetColor("_Color", new Color(255.0f,255.0f,255.0f ,alpha));
    renderer.materials[0].SetColor("_TintColor", new Color(255f,255f,255f ,alpha));


    renderer.startColor = color;
    renderer.endColor = color;

    if ( alpha <= 0f ) {
//			GameObject.Destroy(gameObject);
			return;
		}
	}

  
}