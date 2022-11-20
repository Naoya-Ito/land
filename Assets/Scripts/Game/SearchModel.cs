using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchModel : MonoBehaviour
{
  [SerializeField] CardController cardPrefab;
  public RectTransform cardArea;

  public static List<string> all_list = new List<string>() {
    "forest",
    "sea"
  };

  public static SearchModel instance = null;

  private void Awake(){
    if(instance == null) {
      instance = this;
    } else {
      Destroy(this.gameObject);
    }
  }

  void Start() {
      
  }

  void Update() {
      
  }

  
  public void pushedSearchButton(){
    updateSearcList();
  }

  public void updateSearcList(){
    Debug.Log("update search list");
    foreach(string key in SearchModel.all_list) {
      CardController card = Instantiate(cardPrefab, cardArea);
      card.Init(key);
      Debug.Log($"update search list key={key}");
    }
  }
}
