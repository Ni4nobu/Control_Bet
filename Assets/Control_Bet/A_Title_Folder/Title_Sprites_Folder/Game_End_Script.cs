using UnityEngine;

public class Game_End_Script : MonoBehaviour
{

    public GameObject confirmationPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //確認パネルを非表示
        confirmationPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void confirmation()
    {
        confirmationPanel.SetActive(true);
    }

    public void EndGame()
    {
        //ゲーム終了
        Application.Quit();
    }
}
