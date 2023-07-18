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
        // Debug.Log("đã va chạm");
            gameObject.transform.position = new Vector2(Random.Range(-6.3f, 6.3f), Random.Range(-4.3f,4.3f));
        }
        if (other.gameObject.CompareTag("wall_brick"))
        {
        gameObject.transform.position = new Vector2(Random.Range(-6.3f, 6.3f), Random.Range(-4.3f,4.3f));
        }
        if (other.gameObject.CompareTag("water"))
        {
        gameObject.transform.position = new Vector2(Random.Range(-6.3f, 6.3f), Random.Range(-4.3f,4.3f));
        }
        if (other.gameObject.CompareTag("trees"))
        {
        gameObject.transform.position = new Vector2(Random.Range(-6.3f, 6.3f), Random.Range(-4.3f,4.3f));
        }
    }
}
