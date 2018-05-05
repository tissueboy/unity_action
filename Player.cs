using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class Player : MonoBehaviour {
  private CharacterController controller;

  public float jumpPower;
  //Rigidbody2D rigidbody2D;
/*
  private Vector3 touchStartPos;
  private Vector3 touchEndPos;
  public float directionX;
  public float directionY;
*/
  Rigidbody2D rb;

  private bool isJump = false;

  // JumpParams
  private float jumpPowor = 2.0f;
  public float jumpPoworConst = 0.8f;
  public float jumpGrvity = 0.05f;
  public float test;
/*
  float wid,hei;
  float tx,ty;
  Touch sPos;
*/
  // Use this for initialization
  void Start () {
    rb = GetComponent<Rigidbody2D>();
/*
    wid = Screen.width;
    hei = Screen.height;    
*/
  }
  
  // Update is called once per frame
  void Update () {
/*
    int stPos;
    int edPos;
*/
    Vector2 temp = gameObject.transform.localScale;

/*
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {

          Debug.Log("touch.deltaTime="+touch.deltaTime);
            // タッチ開始
          sPos = touch;
          //transform.Translate(Vector3.up * jumpPowor); 
          //rb.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
          
        }
        else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary){

          Debug.Log("sPos.deltaTime="+sPos.deltaTime);

          tx = (touch.position.x - sPos.position.x)/wid; //横移動量(-1<tx<1)

          if(-0.3 < tx && tx < 0.3){
            rb.velocity = Vector2.up * 10.0f;
          }

          // タッチ移動
          Debug.Log("tx="+tx);

          if( tx <= -0.3 ){//スワイプ右
            if(temp.x < 0 || temp.x == 0){//キャラクターが左向き
              //処理なし
            }else{
              temp.x *= -1;
              //結果を戻す
              gameObject.transform.localScale = temp;
            }
          }else if( 0.3 <= tx ){//スワイプ左
            if(temp.x < 0 || temp.x == 0){//キャラクターが左向き
              temp.x *= -1;
              //結果を戻す
              gameObject.transform.localScale = temp;
            }else{
              //処理なし
            }              
          }
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            // タッチ終了
        }
    }
*/
  }
  void HandleTapped (object sender, System.EventArgs e)  
  {  
    // 色をランダム指定  
    Debug.Log ("HelloWorld3");
  }  
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private CharacterController controller;

  public float jumpPower;
  //Rigidbody2D rigidbody2D;

  private Vector3 touchStartPos;
  private Vector3 touchEndPos;
  public float directionX;
  public float directionY;
  Rigidbody2D rb;

  private bool isJump = false;

  // JumpParams
  private float jumpPowor = 2.0f;
  public float jumpPoworConst = 0.8f;
  public float jumpGrvity = 0.05f;

  // Use this for initialization
  void Start () {
    rb = GetComponent<Rigidbody2D>();
    
  }
  
  // Update is called once per frame
  void Update () {

    //タッチ
    if (Input.GetKeyDown(KeyCode.Mouse0)){
        touchStartPos = new Vector3(Input.mousePosition.x,
                                    Input.mousePosition.y,
                                    Input.mousePosition.z);
    }

    //離した
    if (Input.GetKeyUp(KeyCode.Mouse0)){
       touchEndPos = new Vector3(Input.mousePosition.x,
                                 Input.mousePosition.y,
                                 Input.mousePosition.z);
    
      directionX = touchEndPos.x - touchStartPos.x;
      directionY = touchEndPos.y - touchStartPos.y;

      if(Mathf.Abs(directionX) ==0 || Mathf.Abs(directionX) < 30){
        if(Mathf.Abs(directionY) ==0 || Mathf.Abs(directionY) < 30){
          actJump();
        }else{
            GetDirection();            
        }
      }else{
        GetDirection();
      }

    }
  }
  void actJump(){
    Debug.Log("actJump");
          //jumpPowor = jumpPowor - jumpGrvity;
          transform.Translate(Vector3.up * jumpPowor);  
  }

  void GetDirection(){
    Debug.Log("okok");
    string Direction = "";

    if (Mathf.Abs(directionY) < Mathf.Abs(directionX)){
      if (30 < directionX){
        //右向きにフリック
        Direction = "right";
      }else{
        if (-30 > directionX){
          //左向きにフリック
          Direction = "left";
        }
      }
    }else{
      if (Mathf.Abs(directionX) < Mathf.Abs(directionY)){
        if (30 < directionY){
          //上向きにフリック
          Direction = "up";
        }else{
          if (-30 > directionY){
            //下向きのフリック
            Direction = "down";
          }
        }
      }else{
        //タッチを検出
        Direction = "touch";
      }
    }

    Vector2 temp = gameObject.transform.localScale;

    switch (Direction){
      case "up":
      //上フリックされた時の処理
      break;

      case "down":
        //下フリックされた時の処理
        break;

      case "right":
        //右フリックされた時の処理
        if(temp.x < 0 || temp.x == 0){
          temp.x *= -1;
          //結果を戻す
          gameObject.transform.localScale = temp;
        }
        break;

      case "left":
        //localScale.xに-1をかける
        if(temp.x > 0){
          temp.x *= -1;
          //結果を戻す
          gameObject.transform.localScale = temp;
        }
        //左フリックされた時の処理
        break;
      case "touch":
        //タッチされた時の処理
        Debug.Log("OK touch");
        rb.AddForce(Vector2.up * jumpPower);
        break;
    }
  }
}

*/