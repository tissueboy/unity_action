using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using TouchScript.Gestures.TransformGestures;

public class touch : MonoBehaviour {

  private GameObject player; 
  public Vector2 temp;

  Rigidbody2D rb;
  //Player script;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        rb = player.GetComponent<Rigidbody2D>();
        temp = player.transform.localScale;
        //script = Player.GetComponent<jump>();
	}
  void OnEnable()
  {
    GetComponent<TapGesture>().Tapped += HandleTapped; 

    GetComponent<FlickGesture>().Flicked += HandleFlick;
    GetComponent<FlickGesture>().MinDistance = 1f;
    GetComponent<FlickGesture>().FlickTime = 0.3f;

    
    // Transform Gestureのdelegateに登録
    GetComponent<TransformGesture>().TransformStarted += TransformStartedHandle; // 変形開始
    GetComponent<TransformGesture>().StateChanged += StateChangedHandle; //状態変化
    GetComponent<TransformGesture>().TransformCompleted += TransformCompletedHandle; // 変形終了
    GetComponent<TransformGesture>().Cancelled += CancelledHandle; // キャンセル
    
  }	
  void OnDisable()
  {
      UnsubscribeEvent();
  }

  void OnDestroy()
  {
      UnsubscribeEvent();
  }

  void UnsubscribeEvent()
  {
      // 登録を解除
      GetComponent<TransformGesture>().TransformStarted -= TransformStartedHandle;
      GetComponent<TransformGesture>().StateChanged -= StateChangedHandle;
      GetComponent<TransformGesture>().TransformCompleted -= TransformCompletedHandle;
      GetComponent<TransformGesture>().Cancelled -= CancelledHandle;
  }

  void TransformStartedHandle(object sender, System.EventArgs e)
  {
  // 変形開始のタッチ時の処理
    Debug.Log("TransformStartedHandle");
  }

  void StateChangedHandle(object sender, System.EventArgs e)
  {
  // 変形中のタッチ時の処理
    Debug.Log("StateChangedHandle");
    rb.velocity = Vector2.right * 5.0f;
  }

  void TransformCompletedHandle(object sender, System.EventArgs e)
  {
  // 変形終了のタッチ時の処理
    Debug.Log("TransformCompletedHandle");
  }
  void CancelledHandle(object sender, System.EventArgs e)
  {
  // 変形終了のタッチ時の処理
    Debug.Log("CancelledHandle");
  }
  void HandleTapped (object sender, System.EventArgs e)  {  
    Debug.Log ("HandleTapped");
    rb.velocity = Vector2.up * 10.0f;
  }
  void HandleFlick(object sender, System.EventArgs e)
  {
      var gesture = sender as FlickGesture;

      if (gesture.State != FlickGesture.GestureState.Recognized)
          return;

     if(gesture.ScreenFlickVector.x < 0){
        if(temp.x > 0){//キャラクターが右向き
          temp.x *= -1;
          player.transform.localScale = temp;
        }
      }else if(gesture.ScreenFlickVector.x > 0)
      {
        if(temp.x < 0 || temp.x == 0){//キャラクターが左向き
          temp.x *= -1;
          player.transform.localScale = temp;
        }
      }
  }
}  
