using Unity.VisualScripting;
using UnityEngine;

//敵オブジェクト　鳥
public class Enemy_Bard_Script : MonoBehaviour
{
    //プレイヤー
   　public Transform Player;


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
    }

    // Update is called once per frame
    void Update()
    {
        //動く
        if (eMove == true)
        {
            
        }
    }
    void OnBecameInvisible()
    {
        // enabled = false;
        if (eMove == true)
        {
            //このオブジェクトを削除
            Debug.Log("敵:鳥を削除");
            Destroy(gameObject);
        }
    }

    void OnBecameVisible()
    {
        //ゲーム画面に映れば移動開始
        eMove = true;
    }
}
