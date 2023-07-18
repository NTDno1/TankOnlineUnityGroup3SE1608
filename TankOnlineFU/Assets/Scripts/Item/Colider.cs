using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wall_steel"))
        {
        Debug.Log("đã va chạm");
            gameObject.transform.position = new Vector2(-30,30);
        }
        if (other.gameObject.CompareTag("wall_brick"))
        {
        Debug.Log("đã va chạm");
        gameObject.transform.position = new Vector2(-30,30);
        }
        if (other.gameObject.CompareTag("water"))
        {
        Debug.Log("đã va chạm");
        gameObject.transform.position = new Vector2(-30,30);
        }
        if (other.gameObject.CompareTag("trees"))
        {
        Debug.Log("đã va chạm");
        gameObject.transform.position = new Vector2(-30,30);
        }
    }
}
