using UnityEngine;
//カメラがプレイヤーを追いかけるプログラム

public class Camera_Move_Script : MonoBehaviour
{
    //プレイヤーのオブジェクトを獲得
    public GameObject Player_Obj;
    //プレイヤーの位置を獲得
    Vector3 Player_Pos;

    //カメラの位置を取得
    Vector3 Camera_Pos;

    //プレイヤーを動かすスクリプトを取得
    Player_Script Player_Controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //プレイヤーのスクリプトからコンポーネントを取得
        Player_Controller = GetComponent<Player_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの位置を取得
        if(Player_Obj.transform.position != Player_Pos)
        {
            //カメラの位置を取得
            Camera_Pos = transform.position;

            //カメラの位置を調整
            transform.position = new Vector3(
                Player_Obj.transform.position.x+14,
                transform.position.y,
                transform.position.z);
            //カメラの位置を設定
            Player_Pos = transform.position;
        }
    }
}
