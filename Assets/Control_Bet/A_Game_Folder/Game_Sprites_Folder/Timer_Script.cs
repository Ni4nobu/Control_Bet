using UnityEngine;
using TMPro;


public class Timer_Script : MonoBehaviour
{
    public TMP_Text Timer_text;

    public float elapsedTime;

    public float remainingTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        remainingTime = 5+1;
    }

    // Update is called once per frame
    void Update()
    {
        //カウントUP
        //elapsedTime += Time.deltaTime;
        //int minutes = Mathf.FloorToInt(elapsedTime / 60);
        //int seconds = Mathf.FloorToInt(elapsedTime % 60);
        //Timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //カウントDown
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                remainingTime = 0;

                // タイマーが0になったら赤にする
                Timer_text.color = Color.red;
            }
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        Timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
