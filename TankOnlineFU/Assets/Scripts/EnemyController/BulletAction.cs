using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 2f;
    public float attackSpeed = 10f;
    public AudioSource soundGun1;

    private Timer timers;

    void Start()
    {
        timers = GetComponent<Timer>();
        timers.alarmTime = 1f;
        timers.StartTime();
    }

    void Update()
    {
        if (timers.isFinish)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // Apply force to the bullet in the forward direction
            bulletRigidbody.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);

            timers.alarmTime = 2f;
            timers.StartTime();
        }
    }
}
