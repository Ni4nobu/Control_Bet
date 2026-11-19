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

    public float Betting_Point;//賭けているポイント
    public int Reword_Random_0;//報酬ポイントをランダムに決めたポイントMAP0用
    public int Reword_Random_1;//報酬ポイントをランダムに決めたポイントMAP1用
    public int Reword_Random_2;//報酬ポイントをランダムに決めたポイントMAP2用

    //倍率を保存
    public float num0;
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


        //ここで報酬をランダムに決める
        Reword_Random_0 = (int)Random.Range(500.0f, 1501.0f);
        Reword_Random_1 = (int)Random.Range(500.0f, 1501.0f);
        Reword_Random_2 = (int)Random.Range(500.0f, 1501.0f);
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

        Betting_Point = (float)Point_Script_obj.Point_Bet;

        Game_Map_Point();
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
    public void Game_Map_Point()
    {
        Betting_Point = Betting_Point / 1000.0f;//ここで賭けたポイントを小数点にする

        //報酬倍率
        num0 = Reword_Random_0 * Betting_Point;
    }
    public void Game_MAP_Custom()
    {
        //報酬ポイントを計算して出す
        int Reword_Point_Display0 = Reword_Random_0 + (int)num0;
        int Reword_Point_Display1 = Reword_Random_1 + (int)num0;
        int Reword_Point_Display2 = Reword_Random_2 + (int)num0;
        MAP0_text.text = "ステージ：森\r\n目標：生存\r\n報酬：" + Reword_Point_Display0 + "P";
        MAP1_text.text = "ステージ：森\r\n目標：生存\r\n報酬：" + Reword_Point_Display1 + "P";
        MAP2_text.text = "ステージ：森\r\n目標：生存\r\n報酬：" + Reword_Point_Display2 + "P";
    }
    
}
