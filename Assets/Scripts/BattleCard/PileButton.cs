using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PileButton : MonoBehaviour
{
  [SerializeField] Image CardArea;

  public void PushButton(){

    Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    Image panel = Instantiate(CardArea, canvas.transform);
    panel.name = "CardList";

    List<string> pile = BattleCardMgr.instance.pile;
    CardList.instance.updateCardList(pile);
    CardList.instance.updateTitle("山札");
  }
}
