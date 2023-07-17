using DefaultNamespace;
using Entity;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển của enemy
    public Tank _tank;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _tank = new Tank
        {
            Name = "Enemy",
            Direction = Direction.Down,
            Hp = 10,
            Point = 1,
            Position = gameObject.transform.position,
            Guid = GUID.Generate()
        };
    }

    void Update()
    {
        // Di chuyển enemy theo hướng ngang (trục x)
        rb.velocity = new Vector2(speed, rb.velocity.y);
        _tank.Position = gameObject.transform.position;
        Fire();
    }

    private void Fire()
    {
        var b = new Bullet
        {
            Direction = Direction.Down,
            Tank = _tank,
            InitialPosition = _tank.Position
        };
        GetComponent<TankFirer>().Fire(b);
    }

}
