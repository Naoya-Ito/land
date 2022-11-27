using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryModel : MonoBehaviour{
  public string storyID;
  public string next_scene;
  public string[] images;

  public StoryModel(string storyID){
    StoryEntity storyEntity = Resources.Load<StoryEntity>("StoryEntityList/" + storyID);
    if(storyEntity == null) {
      Debug.Log($"story not exist. id={storyID}");
      return;
    }

    this.storyID = storyID;
    this.next_scene = storyEntity.next_scene;
    this.images = storyEntity.images;
  }
}