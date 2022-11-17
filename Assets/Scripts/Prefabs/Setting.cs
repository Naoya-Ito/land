using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour {

  [SerializeField] Slider bgmSlider;
  public Toggle changeSceneTimeToggle;
  public Toggle changeDayToggle;
 
	
  void Start() {
    if(PlayerPrefs.HasKey("bgm_volume")) {
      float bgm_volume = DataMgr.GetFloat("bgm_volume");
      bgmSlider.value = bgm_volume;
    } else {
      bgmSlider.value = 1.0f;
      DataMgr.SetFloat("bgm_volume", 1.0f);
    }

    changeSceneTimeToggle.isOn = DataMgr.GetBool("change_scene_time_speed_up");
    changeDayToggle.isOn = DataMgr.GetBool("change_day_speed_up");

    DataMgr.SetBool("is_setting", true);
  }

  private bool isEndButtonPushed = false;
  public void pushedEndButton(){
    if(isEndButtonPushed) {
      return;
    }
    isEndButtonPushed = true;

    DataMgr.SetBool("is_setting", false);
    finishGame();
  }

  public void cancel(){
    DataMgr.SetBool("is_setting", false);
    GameObject panel = GameObject.Find("SettingMenu");
    if(panel != null) {
      Destroy(panel);
    } else {
      Debug.Log("SettingMenu is not found.");
    }
  }

  private void finishGame(){
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
  }

  public void retireGame(){
    CommonUtil.changeScene("GameOverScene");
  }

  public int pushed = 0;
  public void resetAllData(){
    // TODO 確認ダイアログ出す
    if(pushed == 0) {
      CommonUtil.changeText("resetText", "本当に全データ削除する");
      pushed += 1;
    } else {
      PlayerPrefs.DeleteAll();
      CommonUtil.changeScene("TitleScene");
    }
  }

  public void changeBGMSlider(){
    DataMgr.SetFloat("bgm_volume", bgmSlider.value);

    AudioListener.volume = bgmSlider.value;
//    BGMMgr.instance.changeVolume();
  }

  public void goTitle(){
    CommonUtil.changeScene("TitleScene");
  }

  public void OnChangeSceneTimeToggleChanged(){
    DataMgr.SetBool("change_scene_time_speed_up", changeSceneTimeToggle.isOn);
  }

  public void OnChangeDayToggleChanged(){
    DataMgr.SetBool("change_day_speed_up", changeDayToggle.isOn);
  }
}
