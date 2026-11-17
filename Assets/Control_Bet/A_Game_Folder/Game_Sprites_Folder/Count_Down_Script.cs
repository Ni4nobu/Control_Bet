using UnityEngine;
using TMPro;
//ゲーム開始時に時間を止めてカウントダウンするプログラム

public class Count_Down_Script : MonoBehaviour
{
    //オブジェクト
    [SerializeField, Header("オブジェクト")]
    public GameObject Count_Panel;
    public TMP_Text Count3_text;
    public TMP_Text Count2_text;
    public TMP_Text Count1_text;
    public TMP_Text Count0_text;

    //ゲームの時間を進める用
    public bool Game_Start_on = false;

    //タイマー
    [SerializeField, Header("タイマー")]
    public float Timer_Count = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //時間停止
        Time.timeScale = 0;

        //初期化
        Game_Start_on = false;

        //確認パネルを表示
        Count_Panel.SetActive(true);
        Debug.Log("カウントパネルon");

        //オブジェクトをアクティブ
        Count3_text.gameObject.SetActive(true);

        //オブジェクトを非アクティブ
        Count2_text.gameObject.SetActive(false);
        Count1_text.gameObject.SetActive(false);
        Count0_text.gameObject.SetActive(false);

        //タイマー初期化
        Timer_Count = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //停止中
        if ((Game_Start_on == false))
        {
            Timer_Count += Time.unscaledDeltaTime;

            //2
            if (Timer_Count > 1.0f)
            {
                Count3_text.gameObject.SetActive(false);
                Count2_text.gameObject.SetActive(true);
            }
            //1
            if (Timer_Count > 2.0f)
            {
                Count2_text.gameObject.SetActive(false);
                Count1_text.gameObject.SetActive(true);
            }
            //Go
            if (Timer_Count > 3.0f)
            {
                Count1_text.gameObject.SetActive(false);
                Count0_text.gameObject.SetActive(true);
            }
            //ゲームスタート
            if (Timer_Count > 4.0f)
            {
                
                Count0_text.gameObject.SetActive(false);
                Game_Start_on = true;
            }
        }
        
        //ゲームを動かす
        if (Game_Start_on == true)
        {
            //確認パネルを非表示
            Count_Panel.SetActive(false);
            Debug.Log("カウントパネルoff");
            //ゲーム時間を正常に
            Time.timeScale = 1;

        }
        
    }
}
