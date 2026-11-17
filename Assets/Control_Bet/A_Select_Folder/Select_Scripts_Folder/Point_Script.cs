using TMPro;
using UnityEngine;

public class Point_Script : MonoBehaviour
{
    public TMP_Text Point_text;


    public int Point = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Point = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        Point_text.text = Point + "P";
    }
}
