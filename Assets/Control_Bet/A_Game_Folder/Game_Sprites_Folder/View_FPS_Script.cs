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

    public bool Key_F2_One_Push = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // FPSの値を別の場所で指定しているなら以下の設定は消す
        // Application.targetFrameRate = 30;

        // テキストコンポーネントの取得
        sampleText = GetComponent<TextMeshProUGUI>();

        //表示を初期化
        Key_F2_One_Push = false;

        //ボタンを押さないと見えない状態にする
        //  sampleText.gameObject.SetActive(false);
        sampleText.enabled = false;
    }

    // FPSの表示と計算
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
           // Debug.Log("キーが反応した");
            if (Key_F2_One_Push == true)
            {
                Key_F2_One_Push = false;
                Debug.Log("Key_F2_One_Push = false");
            }

            else if(Key_F2_One_Push == false)
            {
                Key_F2_One_Push = true;
                Debug.Log(" Key_F2_One_Push = true");
            }
            
        }
        if(Key_F2_One_Push == true)
        {
            //sampleText.gameObject.SetActive(true);
            sampleText.enabled = true;
        }
        else if(Key_F2_One_Push == false)
        {
           // sampleText.gameObject.SetActive(false);
            sampleText.enabled = false;
        }
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
