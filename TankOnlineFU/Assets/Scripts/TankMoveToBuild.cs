﻿using Assets.Scripts.Entity;
using DefaultNamespace;
using Entity;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TankMoverToBuild : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    private float lastMove = 0f;
    private float delay = 0.2f;
    private float timeActive = 0.5f;
    private float timeActiveCount;
    private Tank _tank;

    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;
    private TankMover _tankMover;
    private CameraController _cameraController;
    private SpriteRenderer _renderer;
    private TankBuilder _tankBuilder;
    public new GameObject camera;
    public List<MaterialEnum> materialEnums;
    private int currentIndex;

    void Start()
    {
        timeActiveCount = 0f;
        speed = 0.3f;
        _tank = new Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
            Position = new Vector3(0, 0, 0),
            isActive = true,
            Guid = GUID.Generate()
        };
        gameObject.transform.position = _tank.Position;
        //_tankMover = gameObject.GetComponent<TankMover>();
        // _cameraController = camera.GetComponent<CameraController>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _tankBuilder = gameObject.GetComponent<TankBuilder>();
        currentIndex = 0;
        Move(Direction.Down);
        materialEnums.Add(MaterialEnum.Trees);
        materialEnums.Add(MaterialEnum.Water);
        materialEnums.Add(MaterialEnum.WallBrick);
        materialEnums.Add(MaterialEnum.WallSteel);
    }

    // Update is called once per frame
    void Update()
    {
        timeActiveCount += Time.deltaTime;
        if (timeActiveCount >= timeActive)
        {
            _tank.isActive = !_tank.isActive;
            _renderer.enabled = _tank.isActive;
            timeActiveCount -= timeActive;
        }
        Vector3 currentPosition = transform.position;
        currentPosition.z = 0f;
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Moves(Direction.Left);
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Moves(Direction.Down);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Moves(Direction.Right);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Moves(Direction.Up);
        }

        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
        {
            currentIndex = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2))
        {
            currentIndex = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3))
        {
            currentIndex = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4) || Input.GetKey(KeyCode.Keypad4))
        {
            currentIndex = 3;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Build(materialEnums[currentIndex]);
        }
    }
    private void Moves(Direction direction)
    {
        _tank.Position = Move(direction);
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

    private void Build(MaterialEnum materialEnum)
    {
        BuildingMaterial buildingMaterial = new(materialEnum);

        _tankBuilder.Build(buildingMaterial);
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