using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropButton : MonoBehaviour
{
  [SerializeField] Image CardArea;

  public void PushButton(){
    Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    Image panel = Instantiate(CardArea, canvas.transform);
    panel.name = "CardList";

    List<string> drop = BattleCardMgr.instance.drop;
    CardList.instance.updateCardList(drop);
    CardList.instance.updateTitle("捨て札");
  }
}
