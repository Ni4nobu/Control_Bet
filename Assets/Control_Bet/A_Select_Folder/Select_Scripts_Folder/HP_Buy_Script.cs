using UnityEngine;
using TMPro;
public class HP_Buy_Script : MonoBehaviour
{
    public TMP_Text HP_Buy_text;
    public Player_Script Player_Script;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP_Buy_text.text = "HP:" + Player_Script.Player_Hp;
    }
    public void OnClick_HP_Buy()
    {
        Player_Script.Player_Hp++;
    }
}
