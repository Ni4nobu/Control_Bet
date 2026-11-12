using UnityEngine;
using TMPro;
public class View_FPS_Script : MonoBehaviour
{
    //FPSを表示するスクリプト
    //ネットにあるものをTMPで使えるように変更した
    [SerializeField]
    private float Interval = 0.1f;

    TextMeshProUGUI sampleText;
    

    private float _time_cnt;
    private int _frames;
    private float _time_mn;
    private float _fps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // FPSの値を別の場所で指定しているなら以下の設定は消す
        // Application.targetFrameRate = 30;

        // テキストコンポーネントの取得
        sampleText = GetComponent<TextMeshProUGUI>();
    }

    // FPSの表示と計算
    // Update is called once per frame
    void Update()
    {
        _time_mn -= Time.deltaTime;
        _time_cnt += Time.timeScale / Time.deltaTime;
        _frames++;

        if (0 < _time_mn) return;

        _fps = _time_cnt / _frames;
        _time_mn = Interval;
        _time_cnt = 0;
        _frames = 0;

        sampleText.text = "FPS: " + _fps.ToString("f2");
    }
}
