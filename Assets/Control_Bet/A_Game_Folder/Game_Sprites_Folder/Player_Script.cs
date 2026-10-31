using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
//プレイヤーを操作するプログラム
public class Player_Script : MonoBehaviour
{

    private CharacterController controller;

    //速度
    private Vector3 velocity;
    public Vector3 Inital_Pos;

    //------移動-------
    public bool pMove = false;//移動可能状態

    public float Move_Speed = 10.0f;//速度
    public float Max_Speed = 100.0f;//速度制限

    public float Y_Limitto = 5.0f;//ｙ軸制限
    //----------------


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期化
        pMove = true;

        controller = GetComponent<CharacterController>();
        //現在の位置
        Vector3 Inital_Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        Vector3 move = Vector3.zero;
        Inital_Pos.y = Mathf.Clamp(Inital_Pos.y, -Y_Limitto, Y_Limitto);
        transform.position = Inital_Pos;

        if (pMove == true)
        {
            if(Move_Speed < Max_Speed)
            {
                //常にプレイヤーを右方向へ力を加える
                move = transform.right * Move_Speed ;
            }

            // プレイヤーに上方向へ力を加える
            if (Input.GetKey(KeyCode.Mouse0))
            {
                 //上昇させる
                velocity.y = 5.0f;
            }
            else
            {
                //重力
                velocity.y = -5.0f;  // 地面に押し付ける
            }
            
        }

        //if (Input.GetKey(KeyCode.Mouse1))
        //{

        //}

        //-----------移動実行-------------
        //上下
        move.y = velocity.y;
        
        controller.Move(move * Time.deltaTime);
        
        //-----------移動実行-------------
    }
}
