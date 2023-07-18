using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update

    public float speed;
    public bool armor = false;
    public bool bullets; 
    public Bullet bullet ;
    void Start()
    {
        speed = 1;
        bullets = false;

    }

    // Update is called once per frame
    void Update()
    {
    }


    public Vector3 Move(Direction direction)
    {
        var currentPos = gameObject.transform.position;
        switch (direction)
        {
            case Direction.Down:
                currentPos.y -= speed * Time.deltaTime;
                break;
            case Direction.Left:
                currentPos.x -= speed * Time.deltaTime;
                break;
            case Direction.Right:
                currentPos.x += speed * Time.deltaTime;
                break;
            case Direction.Up:
                currentPos.y += speed * Time.deltaTime;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        gameObject.transform.position = currentPos;
        return currentPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trees"))
        {
        }
    }
    public void setBu(){
        bullets = true;
    }
    public bool getArmor()
    {
        return armor;
    }
    public bool setArmor(bool value)
    {
        armor = value;
        return armor;
    }
        public bool getBullets()
    {
        return bullets;
    }
    public bool setBullets(bool value)
    {
        bullets = value;
        return bullets;
    }
}