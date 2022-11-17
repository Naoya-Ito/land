using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillEntity", menuName = "Create SkillEntity")]

public class SkillEntity : ScriptableObject {
  public string title;
  [Multiline] public string text;
  public int cost;
}