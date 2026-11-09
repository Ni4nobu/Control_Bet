using UnityEngine;

public class Enemy_Script : MonoBehaviour
{

    //プレイヤー
   　public Transform Player;


    //------------移動--------------
    public bool eMove = false;//移動可能状態

    public float Move_Speed = 10.0f;//速度
    public float Max_Speed = 100.0f;//速度制限

    public float Time_Move =10.0f;

    public int Dead_Namber = 0;


    //------------------------------

    //------------時間--------------

    //制限時間
    public float Time_Out = 1.0f;

    //突進時間
    public float Rush = 5.0f;

    //タイマー
    private float Time_Elapsed = 0.0f;

    //------------------------------

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期化
        eMove = false;

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー取得
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //エネミーの移動
        Vector3 Distance = Player.position - transform.position;

        //10秒に一回プレイヤー方向に突進する
        if (eMove == true)
        {
            Distance.Normalize();
            Time_Elapsed += Time.deltaTime;

            if (Time_Elapsed >= Time_Out)
            {
                Time_Move = 30.0f; 
                Time_Elapsed = 0.0f;
            }
            if(Time_Elapsed >= Rush)
            {
                Time_Move = 5.0f;
            }
            //プレイヤーから遠ければ
            if (Vector3.Distance(Player.position,transform.position) >50.0f)
            {
                //このオブジェクトを削除
                Debug.Log("敵を削除");
                Destroy(gameObject);
            }
            transform.position += (Distance * Time_Move * Time.deltaTime);
        }
        

    }
    void OnBecameInvisible()
    {
        // enabled = false;
        if (eMove == true)
        {
            //このオブジェクトを削除
            Debug.Log("敵を削除");
            Destroy(gameObject);
        }
    }

    void OnBecameVisible()
    {
        eMove = true;
        //enabled = true; 
    }
}
