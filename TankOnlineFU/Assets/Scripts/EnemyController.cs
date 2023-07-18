using DefaultNamespace;
using Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển của enemy
    public Tank _tank;
    private float time = 1;
    private TankMover _tankMover;
    private SpriteRenderer _renderer;
    private Rigidbody2D rb;
    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;

    void Start()
    {
        _tank = new Tank
        {
            Name = "Enemy",
            Direction = Direction.Down,
            Hp = 1,
            Point = 1,
            Position = gameObject.transform.position,
            Guid = GUID.Generate()
        };
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _tankMover = gameObject.GetComponent<TankMover>();
    }

    void Update()
    {
        // Di chuyển enemy theo hướng ngang (trục x)
        Move(_tank.Direction);
        Fire();
    }

    public void Spawn(Vector3 position)
    {

    }

    private void Move(Direction direction)
    {
        _tank.Position = _tankMover.Move(direction);
        _tank.Direction = direction;
        _renderer.sprite = direction switch
        {
            Direction.Down => tankDown,
            Direction.Up => tankUp,
            Direction.Left => tankLeft,
            Direction.Right => tankRight,
            _ => _renderer.sprite
        };
    }

    private void Fire()
    {
        var b = new Bullet
        {
            Direction = _tank.Direction,
            Tank = _tank,
            InitialPosition = _tank.Position
        };
        GetComponent<TankFirer>().Fire(b, _tank);
    }


    public void BeFired()
    {
        _tank.Hp -= 1;
        if (_tank.Hp < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("wall_steel") || collision.CompareTag("wall_brick") || collision.CompareTag("water") || collision.CompareTag("Enemy"))
        {
            _tank.Direction += 1;
            if (_tank.Direction > Direction.Right)
            {
                _tank.Direction = Direction.Up;
            }
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<TankController>().BeFired();
        }
    }

}
