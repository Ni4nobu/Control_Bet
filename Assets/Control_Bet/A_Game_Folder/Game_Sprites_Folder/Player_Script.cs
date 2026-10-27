using UnityEngine;
//プレイヤーを操作するプログラム
public class Player_Script : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool pMove = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期化
        rb = GetComponent<Rigidbody2D>();

        pMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        if (pMove == true)
        {
            //常にプレイヤーを右方向へ力を加える
            rb.AddForce(transform.right * 1.0f);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // プレイヤーに上方向へ力を加える
            rb.AddForce(transform.up * 2.0f);
        }
    }
}
