using UnityEngine;

using UnityEngine.UI;
public class My_Mouse_Display_Script : MonoBehaviour
{
    //Canvasの参照
    public Canvas Canvas_obj;

    public RectTransform Canvas_obj_Transform;//キャンバスの位置

    public GameObject Mouse_Image;//マウスの位置に表示する画像obj

    public RectTransform Mouse_Image_Transform;//マウス画像の位置

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Mouse_Image_Transform = Mouse_Image.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        // CanvasのRectTransform内にあるマウスの座標をローカル座標に変換する
        RectTransformUtility.ScreenPointToLocalPointInRectangle
        (
            Canvas_obj_Transform,
            Input.mousePosition,
            Canvas_obj.worldCamera,
            out var mousePosition
        );

        Mouse_Image_Transform.anchoredPosition = new Vector2(mousePosition.x, mousePosition.y);
    }
}
