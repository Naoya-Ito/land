using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMMgr : MonoBehaviour{

  public AudioClip[] clips;
  AudioSource audios;
  public static BGMMgr instance = null;

  private bool isFadeOut = false;
  private double FadeOutSeconds = 2.0;
  double FadeDeltaTime = 0;

  static int BGM_OP = 0;
  static int BGM_LEGEND = 1;
  static int BGM_GOD = 2;
  static int BGM_AHURERA = 3;
  static int BGM_TITLE = 4;
  static int BGM_OP2 = 5;
  static int BGM_FIELD = 6;
  static int BGM_BATTLE_NORMAL = 7;
  static int BGM_WIN = 8;

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  void Start(){
    DontDestroyOnLoad(this);
    audios = GetComponent<AudioSource>();

    audios.clip = clips[BGM_TITLE];
    audios.Play();

    if(PlayerPrefs.HasKey("bgm_volume")) {
      AudioListener.volume = DataMgr.GetFloat("bgm_volume");
    } else {
      DataMgr.SetFloat("bgm_volume", 1.0f);
    }
  }

  void Update(){
    if (isFadeOut) {
      FadeDeltaTime += Time.deltaTime;
      if (FadeDeltaTime >= FadeOutSeconds) {
        FadeDeltaTime = 0;
        isFadeOut = false;
        audios.Stop();
        audios.volume = 1.0f;
        return;
      }
      audios.volume = (1.0f - (float)(FadeDeltaTime / FadeOutSeconds));
    }
  }

  public void stopMusic(){
//    Debug.Log("stop music");
//    audios.Stop();
//    Debug.Log($"stop music. now day = {DataMgr.GetInt("day")}");
    isFadeOut = true;

    DataMgr.SetStr("now_bgm", "");
  }

  public void changeBGM(string key){
    if(key == "" || key == null) return;

//    Debug.Log($"{DataMgr.GetStr("event_key")}  change bgm. now={DataMgr.GetStr("now_bgm")}, next bgm={key}");

    isFadeOut = false;
    audios.volume = 1.0f;
    DataMgr.SetStr("now_bgm", key);
    int BGM_NO;
    switch(key) {
    case "op":
      BGM_NO = BGM_OP;
      break;
    case "op2":
      BGM_NO = BGM_OP2;
      break;
    case "battle_god":
      BGM_NO = BGM_GOD;
      break;
    case "field":
      BGM_NO = BGM_FIELD;
      break;
    case "normal_battle":
      BGM_NO = BGM_BATTLE_NORMAL;
      break;
    case "win":
      BGM_NO = BGM_WIN;
      break;
    case "ending":
      BGM_NO = BGM_AHURERA;
      break;
    case "title":
      BGM_NO = BGM_TITLE;
      break;
    default:
      BGM_NO = 0;
      Debug.Log($"unknown bgm name. key={key}");
      return;
      break;
    }
    audios.clip = clips[BGM_NO];
    audios.Play();
  }
}