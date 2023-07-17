using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class LoadSaveGame : MonoBehaviour
{
    public Button saveButton;
    public Button playButton;
    public Button exitButton;
    public GameObject Tree;
    public GameObject Wall_brick;
    public GameObject Wall_steel;
    public GameObject Water;
    
    private string filePath1 = "C:\\Users\\congg\\OneDrive\\Desktop\\SaveLoad1.txt";
    private string filePath2 = "C:\\Users\\congg\\OneDrive\\Desktop\\SaveLoad2.txt";
    private string filePath3 = "C:\\Users\\congg\\OneDrive\\Desktop\\SaveLoad3.txt";

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        /*saveButton.onClick.AddListener(SaveMap);
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(BackMenu);*/

        createFile(filePath1);
        createFile(filePath2);
        createFile(filePath3);

    }

    public void createFile(string filePath)
    {
        if (CheckFileExist(filePath))
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length > 0)
            {
                saveButton.enabled = true;
                playButton.enabled = true;

            }
            else
            {
                playButton.enabled = false;
            }
        }
        else
        {
            Debug.Log("File does not exist.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SaveMap(string filePath)
    {
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

            // Ghi dữ liệu mới vào tệp tin
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(text);
                Debug.Log("Map saved successfully.");
            }
        }
        else
        {
            Debug.Log("File does not exist.");
        }

    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            LoadDataAndCreateObjects(filePath1);
        }
    }

    private void LoadDataAndCreateObjects(string filePath)
    {
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
