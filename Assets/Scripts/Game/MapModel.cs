using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel {
  public string place_text;
  public string chara_text;
  public string image;
  public string bg;

  public MapModel(string mapID){
    if(mapID == "pv") {
      setEmpty();
      return;
    }

    MapEntity mapEntity = Resources.Load<MapEntity>("MapEntityList/" + mapID);
    if(mapEntity == null) {
      Debug.Log($"Error!! MapModel. load key={mapID} is not exist.");
      setEmpty();
      return;
    }

    this.place_text = mapEntity.place_text;
    this.chara_text = mapEntity.chara_text;
    this.image = mapEntity.image;
    this.bg = mapEntity.bg;
  }

  private void setEmpty(){
    this.place_text = "";
    this.chara_text = "";
    this.image = "";
    this.bg = "";
  }
}