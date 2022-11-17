using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGetButton : MonoBehaviour
{
  [SerializeField] Image SkillArea;

  public void pressButton(){
    Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    Image panel = Instantiate(SkillArea, canvas.transform);
    panel.name = "SkillList";

    SkillList.instance.updateSkillList();
  }
}
