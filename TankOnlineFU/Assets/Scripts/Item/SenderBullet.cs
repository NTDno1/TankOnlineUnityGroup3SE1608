using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenderBullet : MonoBehaviour
{
    Timer timer;
    // public List<GameObject> items;
    // public AudioSource soundArmor;
    BulletController bu;
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 30f;
        timer.StartTime();
        bu = FindObjectOfType<BulletController>();
        // this.items = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.isFinish){
            Destroy(this.gameObject);
        }
    }
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            // soundArmor.Play();
            // BulletController bu = other.GetComponent<BulletController>();
            // bu.setBulletStatus(1);
            // bu.setBulletStatus(1);
            // Destroy(gameObject, 0.4f);
            ReviceItems ri = other.GetComponent<ReviceItems>();
            ri.ReciveItemBullet(true); 
            Destroy(gameObject, 0.4f);
        }
    }
}
