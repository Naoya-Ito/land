using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextEntity", menuName = "Create TextEntity")]

public class TextEntity : ScriptableObject {

  public MultilineText[] texts;
}