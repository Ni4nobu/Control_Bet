using UnityEngine;
using TMPro;
using System.Drawing;

public class HP_Buy_Script : MonoBehaviour
{
    public TMP_Text HP_Buy_text;
    public Player_Script Player_Script;

    public Point_Script Point_Script_obj;

    public int Select_HP_num = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player_Script.Player_Hp = Select_HP_num;
        Select_HP_num++;
    }

    // Update is called once per frame
    void Update()
    {
        HP_Buy_text.text = "HP:" + Player_Script.Player_Hp;
        Player_Script.Player_Hp = Select_HP_num;
    }
    public void OnClick_HP_Buy()
    {
        if(Point_Script_obj.Point >= 100)
        {
            Select_HP_num++;
            Point_Script_obj.Point -= 100;
        }
        
    }
}
