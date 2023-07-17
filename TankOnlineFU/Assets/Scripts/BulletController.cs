using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Bullet Bullet { get; set; }

    public int MaxRange { get; set; }
    public GameObject anim;

    // Start is called before the first frame update
    private void Start()
    {
        // anim = GetComponent<Animator>();
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }

    // Update is called once per frame
    private void Update()
    {
        DestroyAfterRange();
    }

    private void DestroyAfterRange()
    {
        var currentPos = gameObject.transform.position;
        var initPos = Bullet.InitialPosition;

        switch (Bullet.Direction)
        {
            case Direction.Down:
                if (initPos.y - MaxRange >= currentPos.y)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Up:
                if (initPos.y + MaxRange <= currentPos.y)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Left:
                if (initPos.x - MaxRange >= currentPos.x)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Right:
                if (initPos.x + MaxRange <= currentPos.x)
                {
                    Destroy(gameObject);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //bullet1
        switch (collision.tag)
        {
            case "wall_brick":
                GameObject wallBrick = Instantiate(anim, transform.position, Quaternion.identity) as GameObject;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                Destroy(wallBrick, 0.3f);
                break;
            case "wall_steel":
                Destroy(this.gameObject);
                GameObject wallSteel = Instantiate(anim, transform.position, Quaternion.identity) as GameObject;
                Destroy(wallSteel, 0.3f);
                break;
            case "Enermy":
                Debug.Log("vacham enermy");
                Destroy(gameObject);
                collision.GetComponent<EnemyController>().BeFired();
                break;
            case "Player":
                if (gameObject.CompareTag("bulletEnemy"))
                {
                    Debug.Log("vacham player");
                    Destroy(gameObject);
                    collision.GetComponent<TankController>().BeFired();
                }
                break;
        }
    }
}