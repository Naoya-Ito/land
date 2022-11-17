using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWinMgr : MonoBehaviour {

  [SerializeField] CardController cardPrefab;
  [SerializeField] public Transform rightCardArea;
  [SerializeField] public Transform centerCardArea;
  [SerializeField] public Transform leftCardArea;


  void Start(){
    updateScene();
    showDropCard();

    var str = string.Join(",", BattleMgr.instance.pile);
    Debug.Log($"win.pile={str}");
  }

  public void updateScene(){
    CommonUtil.changeText("event_text","入手するカードを選べ");

    CenterArea.hideImage();
    CenterArea.hidePlace();
    CenterArea.hideChara();

    LeftArea.updateStatus();
    RightArea.updateStatus();
  }

  private void showDropCard(){
    List<string> drop;
    if(BattleMgr.instance == null) {
      drop = CardDrop.lv1_drop;
    } else {
      drop = BattleMgr.instance.enemy.drop;

      int enemy_lv = BattleMgr.instance.enemy.lv;
      List<string> item_list = CardDrop.lv1_drop;
      if(enemy_lv < 5) {
      } else {
        foreach(string key in CardDrop.lv2_drop) {
          item_list.Add(key);
        }
      }

      switch(drop.Count) {
      case 0:
        drop.Add(item_list[Random.Range(0, item_list.Count)]);
        drop.Add(item_list[Random.Range(0, item_list.Count)]);
        drop.Add(item_list[Random.Range(0, item_list.Count)]);
        break;
      case 1:
        drop.Add(item_list[Random.Range(0, item_list.Count)]);
        drop.Add(item_list[Random.Range(0, item_list.Count)]);
        break;
      case 2:
        drop.Add(item_list[Random.Range(0, item_list.Count)]);
        break;
      default:
        break;
      }
    }
    // CommonUtil.shuffleList(drop);

    Transform left_area = GameObject.Find("left_card").GetComponent<Transform>();
    CardController card_l = Instantiate(cardPrefab, left_area);
    card_l.Init(drop[0]);
    card_l.model.setGetMode();

    Transform center_area = GameObject.Find("center_card").GetComponent<Transform>();
    CardController card_c = Instantiate(cardPrefab, center_area);
    card_c.Init(drop[1]);
    card_c.model.setGetMode();

    Transform right_area = GameObject.Find("right_card").GetComponent<Transform>();
    CardController card_r = Instantiate(cardPrefab, right_area);
    card_r.Init(drop[2]);
    card_r.model.setGetMode();
  }

}
