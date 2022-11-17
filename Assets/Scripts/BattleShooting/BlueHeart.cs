using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHeart : MonoBehaviour{
  public Heart heart;
  public CircleBulletModel circleBulletPrefab;
  public SquareBulletModel squareBulletPrefab;
  public LineModel linePrefab;

  private float START_TIME = 4.0f;
  private EnemyAttackModel attackModel;
  private bool isDebug = false;

  private float world_balance = 40.0f;
  private Vector3 rightTop;
  private Vector3 leftBottom;
  void Start(){
    if(CommonUtil.isPV()) {
      setPVData();
    } else if(BattleMgr.instance != null){
      setEnemyData();
      attackModel = BattleMgr.instance.getAttackModel();
    } else {
      isDebug = true;
      setPVData();
    }
    Invoke("startExec", START_TIME);

    rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - world_balance, Screen.height - world_balance, 0f));
    leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(world_balance, world_balance, 0f));
  }

  private bool isStart = false;
  private void startExec(){
    foreach(EnemyAttackDetailModel attack in attackModel.attacks) {
      InvokeRepeating(attack.attack_name.ToString(), attack.start_time, attack.repeat_time);
    }
    isStart = true;

    enemyMove();
  }

  private float speedRepeat = 2.0f;
  private float enemySpeed = 2.0f;
  private void setEnemyData(){
    speedRepeat = BattleMgr.instance.enemy.speedRepeat;
    enemySpeed = BattleMgr.instance.enemy.speed;
  }

  private void setPVData(){
    EnemyModel enemy = PVModel.getEnemyModel();
    attackModel = enemy.attacks[0];
    speedRepeat = 2.0f;
    enemySpeed = 2.0f;
  }

  void Update(){
    if(!isStart) {
      return;
    }

    float position_x = transform.position.x;
    float position_y = transform.position.y;
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
    
    Vector2 pos = new Vector2(position_x, position_y);
    transform.position = pos;
  }

  private void enemyMove(){
    switch(attackModel.move.move_name.ToString()) {
      case "randomMove":
        InvokeRepeating("randomMove", 0f, speedRepeat);
        break;
      case "stop":
        break;
      case "targetMove":
        InvokeRepeating("targetMove", 0f, speedRepeat);
        break;
      case "ziguzagu":
        Vector2 v = new Vector2(enemySpeed, 0);
        Rigidbody2D rd = GetComponent<Rigidbody2D>();
        rd.velocity = v;
        InvokeRepeating("ziguzagu", speedRepeat, speedRepeat);
        break;
      default:
        Debug.Log($"enemy move is not found. move={attackModel.move.move_name.ToString()}");
        break;
    }
  }

  public void angleMove(float angle, float speed){
    Vector2 v;
    v.x = Mathf.Cos(angle) * speed;
    v.y = Mathf.Sin(angle) * speed;
    Rigidbody2D rd = GetComponent<Rigidbody2D>();
    rd.velocity = v;
  }

  private void moveToPos(Vector3 targetPos, float speed){
    float radian = Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x);

    angleMove(radian, speed);
  }

  private void targetMove(){
    moveToPos(heart.transform.position, enemySpeed);
    //createLine(transform.position, heart.transform.position);
  }

  private void randomMove(){
    moveToPos(getRandomPos(), 5.0f);

    // createLine(transform.position, heart.transform.position);
  }

  // ここから移動
  private void ziguzagu(){
    Rigidbody2D rd = GetComponent<Rigidbody2D>();
    Vector2 v = new Vector2(-1*rd.velocity.x, 0);      
    rd.velocity = v;
  }

  private void createLine(Vector3 from, Vector3 to) {
    LineModel line = Instantiate(linePrefab, from, Quaternion.identity);
    line.setLine(from, to);
  }

  // ここから技
  private int rotate_i = 0;
  private void execRotateNShot(){
    rotateNShot(8 + rotate_i*2);
    rotate_i = rotate_i + 1;
    if(rotate_i == 12) {
      rotate_i = 13;
    } else if (rotate_i >= 13) {
     rotate_i = 12;
    }
  }

  private int gravity_rotate_i = 0;
  private void execRotateGravityNShot(){
    rotateNShot(8 + rotate_i*2, 1.0f);
    gravity_rotate_i = gravity_rotate_i + 1;
  }

  private void targetHeartFromWorld(){
    float delay = 0.5f;
    FromToShot(getRandomPosWorldUp(), heart.transform.position, delay);
    FromToShot(getRandomPosWorldRight(), heart.transform.position, delay);
    FromToShot(getRandomPosWorldLeft(), heart.transform.position, delay);
    FromToShot(getRandomPosWorldDown(), heart.transform.position, delay);
  }

  private void targetHeartFromUnderWorld(){
    float delay = 0.5f;
    FromToShot(getRandomPosWorldDown(), heart.transform.position, delay);
    FromToShot(getRandomPosWorldDown(), heart.transform.position, delay);
    FromToShot(getRandomPosWorldDown(), heart.transform.position, delay);
    FromToShot(getRandomPosWorldDown(), heart.transform.position, delay);
  }

  private void targetFromUpWorld(){
    FromToShot(getRandomPosWorldUp(), heart.transform.position);
  }

  private void randomFromUpWorld(){
    FromToShot(getRandomPosWorldUp(), getRandomPosWorldDown());
    FromToShot(getRandomPosWorldUp(), getRandomPosWorldDown());
    FromToShot(getRandomPosWorldUp(), getRandomPosWorldDown());
    FromToShot(getRandomPosWorldUp(), getRandomPosWorldDown());
  }

  private void targetHeartShot(){
    FromToShot(transform.position, heart.transform.position, 0f);
  }

  private CircleBulletModel createBullet(Vector2 pos){
    CircleBulletModel bullet = Instantiate(circleBulletPrefab, pos, Quaternion.identity);
    if(attackModel.is_change_size) {
      bullet.changeRandomScale();
    }
    return bullet;
  }

  private SquareBulletModel createSquareBullet(Vector2 pos){
    SquareBulletModel bullet = Instantiate(squareBulletPrefab, pos, Quaternion.identity);
    if(attackModel.is_change_size) {
      bullet.changeRandomScale();
    }
    return bullet;
  }

  private void meteoRain(){
    Vector3 from = getRandomPosWorldUp();
    SquareBulletModel bullet = createSquareBullet(from);
//    StartCoroutine(DelayCoroutine(0.5f, () => {
      bullet.setGravity(0.5f);
//    }));  

    Vector3 to = new Vector3(from.x, 0, from.z);
    createLine(from, to);
  }

  private void commetFromRight(){
    Vector3 from = getRandomPosWorldRight();
    SquareBulletModel bullet = createSquareBullet(from);
    bullet.SetVelocity(-1.0f*attackModel.circle_speed, 0.0f);
    Vector3 to = new Vector3(0.0f, from.y, from.z);
    createLine(from, to);
  }

  private void commetFromLeft(){
    Vector3 from = getRandomPosWorldLeft();
    SquareBulletModel bullet = createSquareBullet(from);
    bullet.SetVelocity(attackModel.circle_speed, 0.0f);
    Vector3 to = new Vector3(rightTop.x, from.y, from.z);
    createLine(from, to);
  }

  private void randomShot(){
    FromToShot(transform.position, getRandomPos(), 0f);
  }
  // ここまで技

  void rotateNShot(int count, float gravity = 0.0f){
    int bulletCount = count;      
    for (int i = 0; i < bulletCount; i++){
      float angle = i * (2 * Mathf.PI / bulletCount); // 2PI：360
//      CircleBulletModel bullet = Instantiate(circleBulletPrefab, transform.position, transform.rotation);
      CircleBulletModel bullet = createBullet(transform.position);
      bullet.angleShot(angle, attackModel.circle_speed);
      if(gravity != 0.0f) {
        bullet.setGravity(gravity);
      }
    }
  }

  private void FromToShot(Vector3 from, Vector3 to, float delay = 0.0f){
    CircleBulletModel bullet = createBullet(from);
    StartCoroutine(DelayCoroutine(delay, () => {
      if(bullet != null) {
        bullet.targetShot(from, to, attackModel.circle_speed);
      }
    }));  

    createLine(from, to);
  }

  // 一定時間後に処理を呼び出すコルーチン
  private IEnumerator DelayCoroutine(float seconds, Action action) {
    yield return new WaitForSeconds(seconds);
    action?.Invoke();
  }

  private Vector3 getRandomPosWorldUp(){
    float pos_x = UnityEngine.Random.Range(0, Screen.width);
    Vector3 world_pos = Camera.main.ScreenToWorldPoint(new Vector3(pos_x, Screen.height, 0.0f));
    return new Vector3(world_pos.x, world_pos.y, transform.position.z);
  }

  private Vector3 getRandomPosWorldRight(){
    float pos_y = UnityEngine.Random.Range(0, Screen.height);
    Vector3 world_pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, pos_y, 0.0f));
    return new Vector3(world_pos.x, world_pos.y, transform.position.z);
  }

  private Vector3 getRandomPosWorldLeft(){
    float pos_y = UnityEngine.Random.Range(0, Screen.height);
    Vector3 world_pos = Camera.main.ScreenToWorldPoint(new Vector3(0, pos_y, 0.0f));
    return new Vector3(world_pos.x, world_pos.y, transform.position.z);
  }

  private Vector3 getRandomPosWorldDown(){
    float pos_x = UnityEngine.Random.Range(0, Screen.width);
    Vector3 world_pos = Camera.main.ScreenToWorldPoint(new Vector3(pos_x, 0, 0.0f));
    return new Vector3(world_pos.x, world_pos.y, transform.position.z);
  }

  private Vector3 getRandomPos(){
    float pos_x = UnityEngine.Random.Range(0, Screen.width);
    float pos_y = UnityEngine.Random.Range(0, Screen.height);

    Vector3 world_pos = Camera.main.ScreenToWorldPoint(new Vector3(pos_x, pos_y, 0.0f));
    return new Vector3(world_pos.x, world_pos.y, transform.position.z);
  }
}
