using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Escape_Script : MonoBehaviour
{
    //プレイヤー
   　public Transform Player;
    public Rigidbody rb;


    //------------移動--------------
    public bool eMove = false;//移動可能状態

    //------------------------------
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期化
        eMove = false;

        //プレイヤー取得
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Move_Left = Vector3.left;
        //動く
        if (eMove == true)
        {
            rb.MovePosition(rb.position + Move_Left * 10.0f * Time.fixedDeltaTime);
        }
    }
    void OnBecameInvisible()
    {
        // enabled = false;
        if (eMove == true)
        {
            //このオブジェクトを削除
            Debug.Log("敵:逃亡を削除");
            Destroy(gameObject);
        }
    }

    void OnBecameVisible()
    {
        //ゲーム画面に映れば移動開始
        eMove = true;
    }
}
