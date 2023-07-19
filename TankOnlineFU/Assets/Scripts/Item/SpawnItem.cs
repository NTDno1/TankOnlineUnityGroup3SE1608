using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
 // Start is called before the first frame update
    public GameObject itSpeedUp;
    public GameObject itArmor;
    GameObject getItem;
    // List<GameObject> items;

    Timer timer;

    // Update is called once per frame
    private void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 0;
        timer.StartTime();
    }
    void Update()
    {
        this.Spawn();
    }
    private void Spawn()
    {
        Bounds bounds = OrthographicBounds(Camera.main);
        float X = Random.Range(bounds.min.x, bounds.max.x);
        float Y = Random.Range(bounds.min.y, bounds.max.y);
        if (timer.isFinish)
        {
            int rand = Random.Range(1, 11);
            // if (rand < 5)
            // {
                getItem = itArmor;
            // }
            // else if (rand>5)
            // {
            //     getItem = itSpeedUp;
            // }
            // else
            // {
            //     return;
            // }
            GameObject item = Instantiate(this.getItem);
            item.transform.position = new Vector2(Random.Range(-6.3f, 6.3f), Random.Range(-4.3f,4.3f));
            timer.arlarmTime = 15;
            timer.StartTime();
        }
        else return;
    }
    private Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
        camera.transform.position,
        new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
