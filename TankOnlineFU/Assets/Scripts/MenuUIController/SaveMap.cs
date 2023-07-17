using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveMap : MonoBehaviour
{
    //public Button saveButton;
    //public Button exitButton;
    public GameObject gameManager;
    public GameObject Tree;
    public GameObject Wall_brick;
    public GameObject Wall_steel;
    public GameObject Water;

     string filePath = "C:\\Users\\congg\\OneDrive\\Desktop\\SaveLoad.txt";


    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveMapContructor()
    {
        //FileInfo fileInfo = new FileInfo(filePath);

        GameObject[] treeObjects = GameObject.FindGameObjectsWithTag("trees");
        GameObject[] wall_brickObjects = GameObject.FindGameObjectsWithTag("wall_brick");
        GameObject[] wall_steel = GameObject.FindGameObjectsWithTag("wall_steel");
        GameObject[] water = GameObject.FindGameObjectsWithTag("water");

        List<GameObject> finishObjects = new List<GameObject>();
        finishObjects.AddRange(treeObjects);
        finishObjects.AddRange(wall_brickObjects);
        finishObjects.AddRange(wall_steel);
        finishObjects.AddRange(water);

        string text = "";
        foreach (GameObject obj in finishObjects)
        {
            text += obj.transform.position.x + "|" + obj.transform.position.y + "|" + obj.tag + "\n";
        }

        if (CheckFileExist(filePath))
        {
            // Xóa nội dung hiện tại của tệp tin
            File.WriteAllText(filePath, string.Empty);


            // Mở tệp tin để ghi nội dung mới vào
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Ghi nội dung mới vào tệp tin
                writer.WriteLine(text);
                Debug.Log("Map saved successfully.");

            }

            // Đọc lại tệp tin để kiểm tra nội dung đã được ghi vào
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine(fileContent);
        }
        else
        {
            Debug.Log("File does not exist.");
        }

    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("PlayMapCreate");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "PlayMapCreate")
        {
            LoadDataAndCreateObjects(filePath);
        }
    }


    public void LoadDataAndCreateObjects(string filePath)
    {
        //FileInfo fileInfo = new FileInfo(filePath);
        if (CheckFileExist(filePath))
        {
            string content = File.ReadAllText(filePath);
            string[] lstCircle = content.Split('\n');
            for (int i = 0; i < lstCircle.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lstCircle[i]))
                {
                    string[] lstProperties = lstCircle[i].Split("|");
                    Vector2 position = new Vector2(float.Parse(lstProperties[0]), float.Parse(lstProperties[1]));
                    string tag = lstProperties[2];

                    GameObject prefab = null;
                    switch (tag)
                    {
                        case "trees":
                            prefab = Tree;
                            break;
                        case "wall_brick":
                            prefab = Wall_brick;
                            break;
                        case "wall_steel":
                            prefab = Wall_steel;
                            break;
                        case "water":
                            prefab = Water;
                            break;
                        default:
                            break;
                    }

                    if (prefab != null)
                    {
                        GameObject newObject = Instantiate(prefab, position, Quaternion.identity);
                        //newObject.transform.localScale = new Vector3(float.Parse(lstProperties[3]), float.Parse(lstProperties[3]), 1f);
                    }
                }
            }
        }
     
    }


    bool CheckFileExist(string path)
    {
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void BackMenu()
    {

        SceneManager.LoadScene("MenuSence");
    }

}
