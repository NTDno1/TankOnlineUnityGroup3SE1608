using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Entity;
using Entity;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TankBuilder : MonoBehaviour
{
    public GameObject Water;
    public GameObject Trees;
    public GameObject WallBrick;
    public GameObject WallSteel;
    public BuildingMaterial _material;
    public float lastBuild = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Build(BuildingMaterial material)
    {
        var currentPos = gameObject.transform.position;
        destroyMaterialByTagAndPositon("trees", currentPos);
        destroyMaterialByTagAndPositon("wall_brick", currentPos);
        destroyMaterialByTagAndPositon("wall_steel", currentPos);
        destroyMaterialByTagAndPositon("water", currentPos);
        GameObject spawnObject = null;
        switch (material.Name)
        {
            case MaterialEnum.Water:
                spawnObject = Instantiate(Water, new Vector3(currentPos.x, currentPos.y, 0), Quaternion.identity);
                break;
            case MaterialEnum.Trees:
                spawnObject = Instantiate(Trees, new Vector3(currentPos.x, currentPos.y, 0), Quaternion.identity);
                break;
            case MaterialEnum.WallBrick:
                spawnObject = Instantiate(WallBrick, new Vector3(currentPos.x, currentPos.y, 0), Quaternion.identity);
                break;
            case MaterialEnum.WallSteel:
                spawnObject = Instantiate(WallSteel, new Vector3(currentPos.x, currentPos.y, 0), Quaternion.identity);
                break;
        }
        lastBuild = Time.time;
        spawnObject.AddComponent<BuidingMaterialController>().buildingMaterial = new BuildingMaterial(material.Name);
    }

    public void destroyMaterialByTagAndPositon(string tag, Vector3 position)
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
        {
            Debug.Log(obj);
            Debug.Log(obj.transform.position);
            Debug.Log(position);
            if (obj.transform.position == position)
            {
                Destroy(obj);
            }
        }
    }
}