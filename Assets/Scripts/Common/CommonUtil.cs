using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CommonUtil : MonoBehaviour{

  public static int rnd(int max_num){
    return Random.Range(0, max_num);
  }

  public static void changeScene(string scene_name, float delay = 0.4f){
    if(FadeManager.instance) {
      if(DataMgr.GetBool("change_scene_time_speed_up")) {
        FadeManager.Instance.LoadScene(scene_name, 0.1f);
      } else {
        FadeManager.Instance.LoadScene(scene_name, delay);  
      }
    } else {
      SceneManager.LoadScene(scene_name);
    }
  }

  public static string getCurrentSceneName(){
    return SceneManager.GetActiveScene().name;
  }

  public static string getRndStrByArray(string[] rows){
    int array_num = rows.Length;
    int rand_key = Random.Range(0, array_num);
    return rows[rand_key];
  }

  public static void changeText(string key, string text) {
    if(GameObject.Find(key) == null) {
      Debug.Log("error!!  " + key + "is not exist.");
      return;
    }

    TextMeshProUGUI target_text = GameObject.Find(key).GetComponent<TextMeshProUGUI>();
    if(target_text != null) {
      target_text.text = text;
    } else {
      Debug.Log($"Warning!!! {key} is text. not tmp");
      Text target_text2 = GameObject.Find(key).GetComponent<Text>();
      target_text2.text = text;

    }
  }

  public static Vector3 getRandomPosBy(Vector3 pos, float rand_size){
    float new_x = pos.x + rand_size*Random.Range(-1.0f, 1.0f);
    float new_y = pos.y + rand_size*Random.Range(-1.0f, 1.0f);
    Vector3 new_pos = new Vector3(new_x, new_y, 1);
    return new_pos;
  }

  public static void changeImage(string key, string image_path){
//    Debug.Log($"change image. key={key}. image_path={image_path}");
    SpriteRenderer sr = GameObject.Find(key).GetComponent<SpriteRenderer>();
    if(image_path == ""){
      hideImage(key);
      return;
    }
    Sprite sprite = Resources.Load<Sprite>("Textures/" + image_path);
    if(sprite == null){
      Debug.Log($"sprite not found. image_path={image_path}");
    }
    if(sr == null) {
      Image image = GameObject.Find(key).GetComponent<Image>();
      image.sprite = sprite;
      return;
    } else {
      sr.sprite = null;
      sr.sprite = sprite;
    }
  }

  public static void showImage(string key){
    Debug.Log($"show image. key={key}");
    Image image = GameObject.Find(key).GetComponent<Image>();
		var color = image.color;
		color.a = 1.0f;
		image.color = color;
  }

  public static void unvisibleImage(string key){
    Image image = GameObject.Find(key).GetComponent<Image>();
		var color = image.color;
		color.a = 0.0f;
		image.color = color;
  }

  public static void hideImage(string key) {
    SpriteRenderer sr = GameObject.Find(key).GetComponent<SpriteRenderer>();
    if(sr != null) {
      sr.gameObject.SetActive(false);
      return;
    }

    Image image = GameObject.Find(key).GetComponent<Image>();
    image.enabled = false;
  }

  public static void setRectWidth(string key, int width){
    RectTransform rct = GameObject.Find(key).GetComponent<RectTransform>();
    rct.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
  }

  public static bool isPV(){
    return DataMgr.GetBool("pv_mode");
  }

  public static bool isDebug(){
    return DataMgr.instance == null;
  }

  public static Sprite getSpriteFromMultiple(string fileName, string spriteName){
    Sprite[] sprites = Resources.LoadAll<Sprite>($"Textures/{fileName}");
    return System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(spriteName));
  }

  public static void shuffleList(List<string> list){
    for (int i = list.Count - 1; i > 0; i--){
      var j = Random.Range(0, i+1);
      var temp = list[i];
      list[i] = list[j];
      list[j] = temp;
    }
  }
}
