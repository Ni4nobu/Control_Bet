using UnityEngine;

using UnityEngine.UI;
public class My_Mouse_Display_Script : MonoBehaviour
{
    //Canvasの参照
    public Canvas Canvas_obj;

    public RectTransform Canvas_objTransform;

    public RectTransform _cursorTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //// オブジェクトの取得
        //GameObject image_object = GameObject.Find("Image");
        //// コンポーネントの取得
        //Image image_component = image_object.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //マウスの位置
        Vector3 mousePos = Input.mousePosition;
        {
            Debug.Log(mousePos.x);
            Debug.Log(mousePos.y);
        }
        // CanvasのRectTransform内にあるマウスの座標をローカル座標に変換する
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            Canvas_objTransform,
            Input.mousePosition,
            Canvas_obj.worldCamera,
            out var mousePosition);

        // ポインターをマウスの座標に移動する
        _cursorTransform.anchoredPosition = new Vector2(mousePosition.x, mousePosition.y);

    }
}
