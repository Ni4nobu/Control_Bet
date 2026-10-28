using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
//プレイヤーを操作するプログラム
public class Player_Script : MonoBehaviour
{

    private CharacterController controller;

    private Vector3 velocity;


    //------移動-------
    public bool pMove = false;//移動可能状態

    public float Move_Speed = 10.0f;//速度
    public float Max_Speed = 100.0f;//速度制限

    public float Y_Limitto = 0;//ｙ軸制限
    //----------------

    public Vector3 RotationSpeed;
    public Vector3 Rotation_NO_Speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期化
        pMove = true;

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        Vector3 move = Vector3.zero;

        Vector3 RotationSpeed = new Vector3(0, 0, 30); // 1秒間の回転角度
        

        if (pMove == true)
        {
            if(Move_Speed<Max_Speed)
            {
                //常にプレイヤーを右方向へ力を加える
                move = transform.right * Move_Speed ;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                // プレイヤーに上方向へ力を加える
                //if (Move_Speed < Max_Speed)
                {

                    velocity.y = 5.0f;
                    transform.Rotate(RotationSpeed * Time.deltaTime);
                }
            }
            else
            {
                velocity.y = -5.5f;  // 地面に押し付ける
               
            }
        }
        
        //if (Input.GetKey(KeyCode.Mouse1))
        //{

        //}

        //移動実行
        move.y = velocity.y;
        controller.Move(move * Time.deltaTime);
    }
}
