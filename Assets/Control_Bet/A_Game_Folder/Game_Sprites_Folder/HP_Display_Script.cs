using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HP_Display_Script : MonoBehaviour
{
    public TMP_Text HP_text;
    public Player_Script Player_Script;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        HP_text.text = "HP:"+ Player_Script.Player_Hp;
    }
}
