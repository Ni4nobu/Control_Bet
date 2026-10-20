using UnityEngine;

public class Set_Select_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //カーソル設定
        Cursor.visible = true;//マウスを表示
        //Cursor.visible = false;//マウスを非表示

        //カーソル操作
        //Cursor.lockState = CursorLockMode.None;//好きなように動かせる
        Cursor.lockState = CursorLockMode.Confined;//ウィンドウ内でのみ動かす
        //Cursor.lockState = CursorLockMode.Locked;//カーソルを動かさない状態にする
    }

    // Update is called once per frame
    void Update()
    {
        //ESCを押したとき
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;//好きなように動かせる
            //ゲーム終了
            Application.Quit();
        }
    }
}
