using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Point_Script : MonoBehaviour
{
    public TMP_Text Point_text;     //テキスト
    public Slider PointSlider;      //スライダー


    public int Point = 0;//現在のポイントの最大
    public int Point_Bet = 0;//使用するポイント


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期配布ポイント
        Point = 1000;

        PointSlider.maxValue = Point;           //最大値
        PointSlider.minValue = 0;               //最低値
        PointSlider.value = Point / 2;
    }

    // Update is called once per frame
    void Update()
    {
        PointSlider.maxValue = Point;           //最大値
        Point_Bet = (int)PointSlider.value;     //UIの値を反映
       
        Point_text.text = Point_Bet + "P";//賭けたポイントをテキストで表示
    }
}
