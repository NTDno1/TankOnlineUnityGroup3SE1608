using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    private float lastMove = 0f;
    private float delay = 1f;

    void Start()
    {
        speed = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
    }


    public Vector3 Move(Direction direction)
    {
        
        var currentPos = gameObject.transform.position;
        if (lastMove + delay > Time.time)
        {
            return currentPos;
        }
        switch (direction)
        {

            case Direction.Down:
                currentPos.y -= speed;
                break;
            case Direction.Left:
                currentPos.x -= speed;
                break;
            case Direction.Right:
                currentPos.x += speed;
                break;
            case Direction.Up:
                currentPos.y += speed;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        gameObject.transform.position = currentPos;
        lastMove = Time.time;

        return currentPos;
    }
}