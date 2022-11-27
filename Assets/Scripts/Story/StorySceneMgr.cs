using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySceneMgr : MonoBehaviour {
  private StoryModel story;
  private int page = 0;

  void Start() {
    string key = "op";
    story = new StoryModel(key);

    updateImage();
  }

  private void updateImage(){
    CommonUtil.changeImage("image", story.images[page]);
  }

  public void clickedPage(){
    page += 1;
    if(page >= story.images.Length) {
      goNextScene(story.next_scene);
    } else {
      updateImage();
    }
  }

  private void goNextScene(string key) {
    switch(key) {
    case "game":
      CommonUtil.changeScene("Gamescene");
      break;
    default:
      Debug.Log($"unknown next scene. key={key}");
      break;
    }
  }
}
