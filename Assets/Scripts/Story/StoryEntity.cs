using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryEntity", menuName = "Create StoryEntity")]

public class StoryEntity : ScriptableObject {
  public new string next_scene;
  public string[] images;
}