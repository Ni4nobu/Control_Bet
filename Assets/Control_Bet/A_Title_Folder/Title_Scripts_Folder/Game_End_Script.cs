using UnityEngine;

public class Game_End_Script : MonoBehaviour
{

    public GameObject EndPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //確認パネルを非表示
         EndPanel.SetActive(false);
        Debug.Log("パネルoff");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Confirmation()
    {
        EndPanel.SetActive(true);
        Debug.Log("パネルon");
    }
    public void ContinueGame1()
    {
        EndPanel.SetActive(false);
        Debug.Log("No_パネルoff");
    }
    public void EndGame()
    {
        //ゲーム終了
        Cursor.lockState = CursorLockMode.None;//好きなように動かせる
        Application.Quit();
        Debug.Log("Yes_ゲーム終了");
    }
}
