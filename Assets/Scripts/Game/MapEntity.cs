using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaoEntity", menuName = "Create MapEntity")]

public class MapEntity : ScriptableObject {
  public string place_text;
  public string chara_text;
  public string image;
  public string bg;
}