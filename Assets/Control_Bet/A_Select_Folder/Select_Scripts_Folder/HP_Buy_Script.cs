using UnityEngine;
using TMPro;
using System.Drawing;
public class HP_Buy_Script : MonoBehaviour
{
    public TMP_Text HP_Buy_text;
    public Player_Script Player_Script;

    public Point_Script Point_Script_obj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player_Script.Player_Hp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HP_Buy_text.text = "HP:" + Player_Script.Player_Hp;
    }
    public void OnClick_HP_Buy()
    {
        if(Point_Script_obj.Point >= 100)
        {
            Player_Script.Player_Hp++;

            Point_Script_obj.Point -= 100;
        }
        
    }
}
