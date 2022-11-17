using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour{

  public BloodObject blood;
  private Vector2 MousePos;
  private int pv_hp = 15;
  private int pv_max_hp = 15;
  private int avoid_per = 0;
  private bool is_first_guard = false;
  private bool isPV = false;
  private bool isDebug = false;
  private float muteki_time = 1.0f;

  private void Awake(){
    isPV = CommonUtil.isPV();
  }

  private Vector3 rightTop;
  private Vector3 leftBottom;
  private float world_balance = 40.0f; // 壁に衝突しない猶予
  void Start(){
    rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - world_balance, Screen.height - world_balance, 0f));
    leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(world_balance, world_balance, 0f));
    is_first_guard = SkillModel.isGetSkill("first_guard");

    if(BattleMgr.instance != null) {
      avoid_per = BattleMgr.instance.getPlayerParams("agi")/2;
      if(avoid_per > 50) avoid_per = 50;
    }
    if(SkillModel.isGetSkill("muteki")) muteki_time = 2.0f;

    if(isPV){
      pv_max_hp = 15 + CommonUtil.rnd(30);
      pv_hp = pv_max_hp;
    } else if(BattleMgr.instance == null) {
      isDebug = true;
    }
    updateHP();
  }

  void Update(){  
    moveByMouse();

//    keybordMove();
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if(collision.CompareTag("CircleBullet") || collision.CompareTag("SquareBullet")) {
      hitted(collision);
      Destroy(collision.gameObject);
    }
    if(collision.CompareTag("BlueHeart")) {
//      Debug.Log("hit blue heart");
      hitted(collision);
    }
  }

  private bool is_hit_time = false;
  private void hitted(Collider2D collision){
    if(is_hit_time) return;
    if(BattleMgr.instance != null && BattleMgr.instance.is_battle_end) {
      return;
    }

    if(is_first_guard) {
      showDamageText($"見切り");
      is_first_guard = false;
      return;
    }
    if(CommonUtil.rnd(100) < avoid_per) {
      showDamageText($"回避!");
      return;
    }

    muteki_on();
    Invoke("muteki_off", muteki_time);

    Vector3 hit_pos = collision.gameObject.transform.position;
    Instantiate(blood, hit_pos, Quaternion.identity);

    int damage = calcurateDamage();
    changeHP(damage);
    showDamageText($"{damage}");

    // hit effect
//    ImagesEffect.createEffect(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, "BloodEffect");
    ImagesEffect.createEffect(hit_pos.x, hit_pos.y, "BombEffect");

//      gameController.GameOver();
  
    if(isDead()) deadHeart(hit_pos);
  }

  private void muteki_on(){
    is_hit_time = true;
    Image image = this.gameObject.GetComponent<Image>(); 
  	var color = image.color;
		color.a = 0.7f;
		image.color = color;
  }

  private void muteki_off(){
    if(isDead()) return;

    is_hit_time = false;
    Image image = this.gameObject.GetComponent<Image>(); 
  	var color = image.color;
		color.a = 1.0f;
		image.color = color;
  }

  private void deadHeart(Vector3 pos){
    BattleMgr.instance.lose();
    Instantiate(blood, CommonUtil.getRandomPosBy(pos, 3.0f), Quaternion.identity);
    Instantiate(blood, CommonUtil.getRandomPosBy(pos, 3.0f), Quaternion.identity);
    Instantiate(blood, CommonUtil.getRandomPosBy(pos, 3.0f), Quaternion.identity);
    Invoke("toLoseScene", 1.0f);

    Image image = this.gameObject.GetComponent<Image>(); 
  	var color = image.color;
		color.a = 0.0f;
		image.color = color;
  }
  
  private void showDamageText(string text){
    DamageDisplay damage_display = GameObject.Find("Canvas").GetComponent<DamageDisplay>();
    damage_display.showText(text);
  }

  private int calcurateDamage(){
    if(isPV || isDebug){
      return 1;
    }

    int damage = BattleMgr.instance.enemy.str - BattleMgr.instance.shield - BattleMgr.instance.def;
    if(damage <= 0) damage = 1;
    return damage;
  }

  private void changeHP(int val){
    if(CommonUtil.isPV() || BattleMgr.instance == null){
      pv_hp -= val;
    } else {
      BattleMgr.instance.damaged(val);
    }
    updateHP();
  }

  private void updateHP(){
    if(CommonUtil.isPV() || BattleMgr.instance == null){
      LifeBar.updateLifeBar(pv_hp, pv_max_hp);
    } else {
      LifeBar.updateLifeBar(BattleMgr.instance.player_hp, BattleMgr.instance.player_max_hp);
    }
  }

  private bool isDead(){
    if(isPV || BattleMgr.instance == null){
      return false;
    }

    BattleMgr.instance.phase = "lose";
    return BattleMgr.instance.isDead();
  }

  private void toLoseScene(){
    if(isPV){
      Debug.Log("to lose scene. but now is pv mode.");
      return;
    }
    CommonUtil.changeScene("BattleScene");
  }

  private void moveByMouse(){
    Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//    Vecor3 new_position = new Vector3(mouse.x, mouse.y, 10);
    float position_x = mouse.x;
    float position_y = mouse.y;
    if(position_x > rightTop.x) {
      position_x = rightTop.x;
    }
    if(position_x < leftBottom.x) {
      position_x = leftBottom.x;
    }
    if(position_y > rightTop.y) {
      position_y = rightTop.y;
    }
    if(position_y < leftBottom.y) {
      position_y = leftBottom.y;
    }
    
//    Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));

    // Vector2 target = Camera.main.ScreenToWorldPoint(new Vector3(position_x, position_y));
    Vector2 target = new Vector2(position_x, position_y);

    Rigidbody2D rd = GetComponent<Rigidbody2D>();
    rd.position = target;

    //this.transform.position = target;
  }

  static float HEART_SPEED = 0.03f;
  private void keybordMove(){
    if (Input.GetKey("down")){
      transform.Translate(0, -1*HEART_SPEED, 0);
    }
    if (Input.GetKey("up")){
      transform.Translate(0, HEART_SPEED, 0);
    }
    if (Input.GetKey("right")){
      transform.Translate(HEART_SPEED, 0, 0);
    }
    if (Input.GetKey("left")){
      transform.Translate(-1*HEART_SPEED, 0, 0);
    }
    if (Input.GetKeyDown("space")){
		}
  }
}
