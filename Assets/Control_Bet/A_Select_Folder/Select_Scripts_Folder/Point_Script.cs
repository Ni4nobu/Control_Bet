using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Point_Script : MonoBehaviour
{

    [SerializeField] private string Clear_Scene;//クリアシーン
    public TMP_Text Point_text;         //テキスト
    public Slider PointSlider;          //スライダー
    public TMP_Text Clear_Point_Text;   //目標ポイント

    public int Point = 0;//現在のポイントの最大
    public int Point_Bet = 0;//使用するポイント

    public int Objective_Point = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期配布ポイント
        Point = 1000;

        PointSlider.maxValue = Point;           //最大値
        PointSlider.minValue = 0;               //最低値
        PointSlider.value = Point / 2;          //初期位置

        Objective_Point = 100000;//目標ポイントを設定
    }

    // Update is called once per frame
    void Update()
    {
        PointSlider.maxValue = Point;           //最大値
        Point_Bet = (int)PointSlider.value;     //UIの値を反映
       
        Point_text.text = Point_Bet + "P";//賭けたポイントをテキストで表示
       
        Clear_Point_Text.text = "必要POINT:" + Objective_Point.ToString("N0") + "P";//目標ポイントを表示


        if (Point >= Objective_Point)//ポイントが目標ポイントを超えるとクリア
        {
            SceneManager.LoadScene(Clear_Scene);//クリアシーンへ移動する
            Cursor.visible = true;//マウスを表示
            Debug.Log("シーン移動");
        }
    }
}
