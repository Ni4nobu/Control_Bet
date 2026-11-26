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

    //--------------------目標-----------------------------
    //目的をランダムにする
    public int Random_Objective0 = 0;
    public int Random_Objective1 = 0;
    public int Random_Objective2 = 0;

    //表示用
    public string Objective_View0;
    public string Objective_View1;
    public string Objective_View2;

    //------------------------------------------------------

    //-------------------マップ-----------------------------

    //マップの抽選用
    public int Random_Map_0 = 0;
    public int Random_Map_1 = 0;
    public int Random_Map_2 = 0;

    //表示用
    public string Map_View0;
    public string Map_View1;
    public string Map_View2;

    //-------------------------------------------------------

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

        //目標をランダムに決める
        Random_Objective0 = (int)Random.Range(1.0f, 5.0f);
        Random_Objective1 = (int)Random.Range(1.0f, 5.0f);
        Random_Objective2 = (int)Random.Range(1.0f, 5.0f);

        //マップをランダムに抽選する
        Random_Map_0 = (int)Random.Range(1.0f, 5.0f);
        Random_Map_1 = (int)Random.Range(1.0f, 5.0f);
        Random_Map_2 = (int)Random.Range(1.0f, 5.0f);
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

        Game_Map_Coose();
        Game_Objective();
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

    //ステージのマップを選択
    public void Game_Map_Coose()
    {
        //一枚目
        switch (Random_Map_0)
        {
            case 1:
                Map_View0 = "森";
                break;
            case 2:
                Map_View0 = "森(夜)";
                break;
            case 3:
                Map_View0 = "村";
                break;
            case 4:
                Map_View0 = "山";
                break;
        default:
                Map_View0 = "エラー";
                break;
        }
        //二枚目
        switch (Random_Map_1)
        {
            case 1:
                Map_View1 = "森";
                break;
            case 2:
                Map_View1 = "森(夜)";
                break;
            case 3:
                Map_View1 = "村";
                break;
            case 4:
                Map_View1 = "山";
                break;
            default:
                Map_View1 = "エラー";
                break;
        }
        //三枚目
        switch (Random_Map_2)
        {
            case 1:
                Map_View2 = "森";
                break;
            case 2:
                Map_View2 = "森(夜)";
                break;
            case 3:
                Map_View2 = "村";
                break;
            case 4:
                Map_View2 = "山";
                break;
            default:
                Map_View2 = "エラー";
                break;
        }
    }

    //ステージの目標
    public void Game_Objective()
    {
        //1枚目
        if(Random_Objective0 == 1)
        {
            Objective_View0 = "生存";
        }
        else if (Random_Objective0 == 2)
        {
            Objective_View0 = "脱出";
        }
        else if (Random_Objective0 == 3)
        {
            Objective_View0 = "移動";
        }
        else if (Random_Objective0 == 4)
        {
            Objective_View0 = "コイン";
        }
        else
        {
            Objective_View0 = "エラー";
        }

        //2枚目
        if (Random_Objective1 == 1)
        {
            Objective_View1 = "生存";
        }
        else if (Random_Objective1 == 2)
        {
            Objective_View1 = "脱出";
        }
        else if (Random_Objective1 == 3)
        {
            Objective_View1 = "移動";
        }
        else if (Random_Objective1 == 4)
        {
            Objective_View1 = "コイン";
        }
        else
        {
            Objective_View1 = "エラー";
        }

        //三枚目
        if (Random_Objective2 == 1)
        {
            Objective_View2 = "生存";
        }
        else if (Random_Objective2 == 2)
        {
            Objective_View2 = "脱出";
        }
        else if (Random_Objective2 == 3)
        {
            Objective_View2 = "移動";
        }
        else if (Random_Objective2 == 4)
        {
            Objective_View2 = "コイン";
        }
        else
        {
            Objective_View2 = "エラー";
        }
    }

    //ステージの報酬を決める
    public void Game_Map_Point()
    {
        Betting_Point = Betting_Point / 1000.0f;//ここで賭けたポイントを小数点にする

        //報酬倍率
        num0 = Reword_Random_0 * Betting_Point;
    }

    //ステージの内容を表示する
    public void Game_MAP_Custom()
    {
        //報酬ポイントを計算して出す
        int Reword_Point_Display0 = Reword_Random_0 + (int)num0;
        int Reword_Point_Display1 = Reword_Random_1 + (int)num0;
        int Reword_Point_Display2 = Reword_Random_2 + (int)num0;
        MAP0_text.text = "ステージ："+ Map_View0 + "\r\n目標：" + Objective_View0 + "\r\n報酬：" + Reword_Point_Display0 + "P";
        MAP1_text.text = "ステージ："+ Map_View1 + "\r\n目標：" + Objective_View1 + "\r\n報酬：" + Reword_Point_Display1 + "P";
        MAP2_text.text = "ステージ："+ Map_View2 + "\r\n目標：" + Objective_View2 + "\r\n報酬：" + Reword_Point_Display2 + "P";
    }
    
}
