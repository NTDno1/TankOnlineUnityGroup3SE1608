using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    Timer timer;
    private EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 2f;
        timer.StartTime();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isFinish)
        {
            StarSpawn();
            timer.arlarmTime = 3f;
            timer.StartTime();

        }

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

    public void StarSpawn()
    {
        Vector2 spawnPos;

        if (Random.Range(0, 2) == 0)
        {
            spawnPos = new Vector2(-3f, 4);
        }
        else
        {
            spawnPos = new Vector2(3f, 4);
        }

        GameObject obj = Instantiate(Enemy, spawnPos, Quaternion.identity);
    }
}
