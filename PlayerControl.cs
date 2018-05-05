using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour {

	public float speed;
	public Vector2 pos;
	public Vector2 pos2;
	public Vector2 pos3;/**/
	public bool isDown = false;
	public bool isAttack = false;
	

	private Animator anim;

	Rigidbody2D m_rigidbody;
	public GameObject yajirushi;

	Vector2 m_lookTarget;

	public LayerMask groundLayer;
	public bool isGrounded; //着地判定

	void Awake () {
		Application.targetFrameRate = 30;
	}

	void Start () {
		m_rigidbody = GetComponent<Rigidbody2D> ();
		
		yajirushi = transform.Find("yajirushi").gameObject;
		yajirushi.SetActive(false);
		//obj = GetComponent<Rigidbody2D> ();
		
		isGrounded = false;

		anim = GetComponent<Animator>();
	}

	void Update () {

		Transform groundCheck = transform.Find("GroundCheck");

		isGrounded = (Physics2D.OverlapPoint(groundCheck.position) != null ) ? true : false;

		// 動く入力
		Vector2 moveInput = new Vector2 (
			CrossPlatformInputManager.GetAxis ("Horizontal"),
			CrossPlatformInputManager.GetAxis ("Vertical")
		);

		// 動く方向をみる
		m_lookTarget = moveInput;


		// 動く方向があるとき
		if (m_lookTarget != Vector2.zero) {
			// 向きを更新
		}

	}

	void FixedUpdate () {
		// 動く方向があるときだけ進む
		Vector2 movement = new Vector2 (m_lookTarget.x, m_lookTarget.y);
		if (m_lookTarget != Vector2.zero) {	
			if (m_lookTarget.y < -0.3) {
				pos = new Vector2 (m_lookTarget.x, m_lookTarget.y);//離した場合のベクトルを保存
				pos3 = new Vector2 (
					Mathf.Abs(pos2.x - m_lookTarget.x),
					Mathf.Abs(pos2.y - m_lookTarget.y)
				);
				isDown = true;//下に入力をしていることを保存
				yajirushi.SetActive (true);//下に入力していることを視覚化
				yajirushi.transform.localScale = new Vector2(0.1f,-1-(pos3.magnitude));
		    Vector2 p1 = pos2;
		    Vector2 p2 = new Vector2 (m_lookTarget.x, m_lookTarget.y);
		    float dx = p2.x - p1.x;
		    float dy = p2.y - p1.y;
		    float rad = Mathf.Atan2(-dx, dy);
		    float degree = rad * Mathf.Rad2Deg;
		    yajirushi.transform.rotation = Quaternion.Euler(0, 0, degree);
		    anim.SetBool("down", true);
		    anim.SetBool("run", false);
			} else {
				anim.SetBool("down", false);
				anim.SetBool("run", true);
				//anim.SetTrigger("Jump");
				//ジャンプ中
				if (isGrounded == false) {
					Debug.Log(isGrounded);
					m_rigidbody.velocity = new Vector2 (0, 0);
					//右
					if(m_lookTarget.x > 0){
						transform.localScale = new Vector3(3, 3, 1);						
					}
					//右
					if(m_lookTarget.x < 0){
						transform.localScale = new Vector3(-3, 3, 1);						
					}
				}
				//右移動中
				if(m_lookTarget.x > 0.1){
					transform.localScale = new Vector3(3, 3, 1);
				}
				//左移動中
				if(m_lookTarget.x < 0.1){
					transform.localScale = new Vector3(-3, 3, 1);
				}

				if (isDown == false && isGrounded == true) {
					pos2 = new Vector2 (m_lookTarget.x, m_lookTarget.y);//下に入力する前の値
					m_rigidbody.velocity = new Vector2 (movement.x * speed, 0);//下以外は移動
					isDown = false;//下に入力をしていることを解除
					yajirushi.SetActive (false);//下に入力していることを非表示				
				}
				//攻撃
				if (m_lookTarget.x != 0 && isAttack == true) {
					anim.SetBool("run", false);
					anim.SetBool("attack", true);
				}else{
					anim.SetBool("attack", false);
				}
			}
		} else {
			//離した時
			anim.SetBool("attack", false);
			anim.SetBool("down", false);
			anim.SetBool("run", false);
			if (isDown == true) {
				//下に入力していた時は逆のベクトルを渡す。
				m_rigidbody.velocity = new Vector2(pos.x * -6, pos.y * -6);
				isDown = false;//下に入力をしていることを解除
				yajirushi.SetActive (false);//下に入力していることを非表示
			}else{
				if (isGrounded) {
					//地面に着地している時は動かさない
					//anim.SetBool("jump",false);
					m_rigidbody.velocity = new Vector2 (0, 0);
				}else{
					anim.SetBool("jump",true);
				}
			}
		}
	}
	void OnCollisionStay2D (Collision2D col){
		if (col.gameObject.tag == "Enemy") {
			isAttack = true;
		}
	}
	void OnCollisionExit2D (Collision2D col){
		if (col.gameObject.tag == "Enemy") {
			isAttack = false;
		}
	}
}

