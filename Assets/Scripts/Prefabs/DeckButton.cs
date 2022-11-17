using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckButton : MonoBehaviour
{
  [SerializeField] Image CardArea;

  public void pressButton(){
    Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    Image panel = Instantiate(CardArea, canvas.transform);
    panel.name = "CardList";

    List<string> deck = DataMgr.GetList("deck");
    CardList.instance.updateCardList(deck);
    CardList.instance.updateTitle("デッキ");
  }
}
