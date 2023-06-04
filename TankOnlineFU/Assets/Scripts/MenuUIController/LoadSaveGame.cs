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
    
    private string filePath = "C:\\Users\\congg\\OneDrive\\Desktop\\SaveLoad.txt";

    // Start is called before the first frame update
    void Start()
    {
        saveButton.onClick.AddListener(SaveMap);
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(BackMenu);


        if (checkFileExist(filePath))
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length > 0)
            {
                saveButton.enabled = false;

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

    void SaveMap()
    {
        GameObject[] finishObjects = GameObject.FindGameObjectsWithTag("material");

        string text = "";
        foreach (GameObject obj in finishObjects)
        {
            text += obj.transform.position.x + "|" + obj.transform.position.y + "|" + obj.transform.localScale.x + "\n";
        }

        if (checkFileExist(filePath))
        {
            StreamWriter writer = File.AppendText(filePath);
            writer.WriteLine(text);
            writer.Close();
        }
        else
        {
            Debug.Log("File does not exist.");
        }

    }

    void PlayGame()
    {
        if (checkFileExist(filePath))
        {
            string content = File.ReadAllText(filePath);
            string[] lstCircle = content.Split('\n');
            for (int i = 0; i < lstCircle.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lstCircle[i]))
                {
                    string[] lstProperties = lstCircle[i].Split("|");
                    GameObject newObject = Instantiate(Wall_brick, new Vector2(float.Parse(lstProperties[0]), float.Parse(lstProperties[1])), Quaternion.identity);
                    newObject.transform.localScale = new Vector3(float.Parse(lstProperties[2]), float.Parse(lstProperties[2]), 1f);
                }
            }
        }
    }

    //void playBall()
    //{
    //    spawner.SetActive(true);
    //    {
    //        try
    //        {
    //            GameObject[] finishObjects = GameObject.FindGameObjectsWithTag("Finish");
    //            foreach (GameObject obj in finishObjects)
    //            {
    //                Destroy(obj);
    //            }

    //            using (StreamWriter writer = new StreamWriter(filePath, false))
    //            {
    //                writer.Write("");
    //            }
    //        }
    //        catch (FileNotFoundException)
    //        {
    //            Debug.LogWarning($"Khong tim thay file {filePath}");
    //        }
    //    }
    //}

    bool checkFileExist(string path)
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
