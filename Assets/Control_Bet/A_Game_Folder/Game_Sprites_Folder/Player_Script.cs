using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
//プレイヤーを操作するプログラム
public class Player_Script : MonoBehaviour
{
    //キャラクターコントローラー
    private CharacterController controller;

    //カメラ
    Camera Camera_Player_Limmit;

    [SerializeField] private string Select_Scene;
    //速度
    private Vector3 velocity;

    //プレイヤーの位置
    private Vector3 Player_Pos;

    //プレイヤーの体力
    public int Player_Hp = 0;

    //プレイヤーの大きさ
    public float Player_Height = 0.0f;

    //------移動-------
    public bool pMove = false;//移動可能状態

    public float Move_Speed = 10.0f;//速度
    public float Max_Speed = 100.0f;//速度制限

    public float Y_Limitto = 5.0f;//ｙ軸制限

    //----------------

    //------無敵時間------

    public float Unrivaled_Timer = 0.0f;//無敵時間

    public bool Unrivaled_State = false;


    //--------------------

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //カメラの情報を取得
        Camera_Player_Limmit = Camera.main;


        //初期化
        pMove = true;

        //キャラクターコントローラーの情報を取得
        controller = GetComponent<CharacterController>();

        //現在の位置
        Vector3 Player_Pos = transform.position;

        //プレイヤーのサイズを取得
        Player_Height = controller.bounds.extents.y;

        Player_Hp = 5;

        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動を0
        Vector3 move = Vector3.zero;

        //カメラの描画の上情報

        Vector3 Screen_Up_Limmit = 
            Camera_Player_Limmit.ViewportToWorldPoint(new Vector3(0.5f, 1, 
            Camera_Player_Limmit.WorldToScreenPoint(transform.position).z));

        //カメラの描画の下情報
        Vector3 Screen_Down_Limmit =
            Camera_Player_Limmit.ViewportToWorldPoint(new Vector3(0.5f, 0,
            Camera_Player_Limmit.WorldToScreenPoint(transform.position).z));

        //移動処理
        if (pMove == true)
        {
           // Debug.Log("プレイヤー移動可能");

            //前進する速度の上限を超えないようにする
            if (Move_Speed < Max_Speed)
            {
                //常にプレイヤーを右方向へ力を加える
                move = transform.right * Move_Speed ;
            }

            // プレイヤーに上方向へ力を加える
            if (Input.GetKey(KeyCode.Mouse0))
            {
                 //上昇させる
                velocity.y = 5.0f;
                //Debug.Log("プレイヤー上昇 : " + velocity.y);
            }
            else
            {
                //重力
                velocity.y = -5.0f;  // 地面に押し付ける

            }
            
        }

        //実行
        //if (Input.GetKey(KeyCode.Mouse1))
        //{

        //}

        //-----------移動実行-------------

        //上下に動かす
        move.y = velocity.y;
        
        controller.Move(move * Time.deltaTime);

        //-----------移動実行-------------

        //-----------移動制限-------------
        Player_Pos = transform.position;

        //上方向の画面外にプレイヤーを出さないようにする
        if (Player_Pos.y + Player_Height > Screen_Up_Limmit.y)
        {
            //留める
            Player_Pos.y = Screen_Up_Limmit.y - Player_Height;
        }
        //下方向の画面外にプレイヤーを出さないようにする
        if (Player_Pos.y - Player_Height < Screen_Down_Limmit.y)
        {
            //留める
            Player_Pos.y = Screen_Down_Limmit.y + Player_Height;
        }

        transform.position = Player_Pos;

        //--------------------------------

        //無敵
        if (Unrivaled_State == true)
        {
            Unrivaled_Timer += Time.deltaTime;
            Debug.Log("無敵状態");
            //無敵時間用タイマー


            if (Unrivaled_Timer >= 3f)
            {
                Unrivaled_Timer = 0.0f;
                Unrivaled_State = false;//通常状態
                Debug.Log("無敵状態終わり");
            }
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy_tag"))
        {
            Debug.Log("プレイヤー：敵と接触");
            if(Player_Hp <= 0)
            {
                //体力がなければ死亡
                Player_Hp = 0;
                Destroy(gameObject);
                //ゲームオーバーシーンへ移動する
                SceneManager.LoadScene(Select_Scene);
                Debug.Log("シーン移動");
            }
            //体力があれば
            if (Player_Hp > 0 && Unrivaled_State == false)
            {
                //HPを減らす
                Player_Hp--;
                Unrivaled_State = true;//無敵状態
               
            }


        }
    }

   
}
