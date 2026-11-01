using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    //移動

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("敵：プレイヤーと接触");
        }
    }
}
