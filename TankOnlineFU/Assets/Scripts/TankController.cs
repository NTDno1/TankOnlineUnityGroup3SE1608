using DefaultNamespace;
using Entity;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TankController : MonoBehaviour
{
    // Start is called before the first frame update
    private Tank _tank;

    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;
    private TankMover _tankMover;
    private CameraController _cameraController;
    private SpriteRenderer _renderer;
    public new GameObject camera;
    public bool armor = false;
    public bool bullets; 

    private void Start()
    {
        _tank = new Tank
        {
            Name = "Player",
            Direction = Direction.Down,
            Hp = 1,
            Point = 0,
            Position = new Vector3(-0.933f,-4.305f, 0),
            IsHaveArmor = false,
            IsUpgradeBullet = false,
            Guid = GUID.Generate()
        };
        gameObject.transform.position = _tank.Position;
        _tankMover = gameObject.GetComponent<TankMover>();
        _cameraController = camera.GetComponent<CameraController>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        Move(Direction.Down);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Move(Direction.Down);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move(Direction.Right);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Move(Direction.Up);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
 
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
            InitialPosition = _tank.Position,
            bulletLv = _tank.IsUpgradeBullet ? 2 : 1
        };
        GetComponent<TankFirer>().Fire(b, _tank);
    }

    public void BeFired()
    {
        // if (_tank.IsHaveArmor)
        // {
        //     _tank.IsHaveArmor = false;
        // }
        // else
        // {
            if(armor == false){
            _tank.Hp -= 1;
            if (_tank.Hp < 1)
            {
                Destroy(gameObject);
            }
            }
        // }
    }

    public void UpgradeBullet()
    {
        _tank.IsUpgradeBullet = true;
    }

    public void GainArmor()
    {
        _tank.IsHaveArmor = true;
    }

    private void OnDestroy()
    {
        Time.timeScale = 0;
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
}