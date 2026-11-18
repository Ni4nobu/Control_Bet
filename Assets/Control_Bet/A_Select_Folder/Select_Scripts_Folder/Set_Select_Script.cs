using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Set_Select_Script : MonoBehaviour
{
    public Player_Script Player_Script;

    public TMP_Text MAP0_text;     //MAPボタン0テキスト
    public TMP_Text MAP1_text;     //MAPボタン1テキスト
    public TMP_Text MAP2_text;     //MAPボタン2テキスト

    public Point_Script Point_Script_obj;

    public float Reword;
    public int money;
    [SerializeField] private string Game_Scene;
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

        money = (int)Random.Range(1000.0f, 1501.0f);
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
        Reword = (float)Point_Script_obj.Point;
        Game_MAP_Custom();
    }
    public void OnClickStartButton_Game()
    {
        
        if (Player_Script.Player_Hp > 0)
        {
            //ゲームシーンへ移動する
            
            SceneManager.LoadScene(Game_Scene);
            Cursor.visible = false;//マウスを非表示
            Debug.Log("シーン移動");
        }
       
    }

    public void Game_MAP_Custom()
    {
        Reword = Reword / 1000.0f;
        money = (int)((float)money * Reword);
        MAP0_text.text = "ステージ：森\r\n目標：生存\r\n報酬：" + money + "P";
    }
}
