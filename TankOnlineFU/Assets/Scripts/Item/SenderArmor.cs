using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenderArmor : MonoBehaviour
{
    Timer timer;
    // public List<GameObject> items;
    // public AudioSource soundArmor;
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 30f;
        timer.StartTime();
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
            other.GetComponent<TankController>().GainArmor();
            Destroy(gameObject, 0.4f);
        }
    }
}
