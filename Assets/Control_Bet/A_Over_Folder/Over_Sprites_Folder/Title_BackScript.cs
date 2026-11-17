using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_BackScript : MonoBehaviour
{
    [SerializeField] private string Titlele_Scene_name;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_Game_Title_Go_Button()
    {
        //シーンを移動する
        SceneManager.LoadScene(Titlele_Scene_name);
        Debug.Log("シーン移動");
    }
}
