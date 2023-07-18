using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviceItems : MonoBehaviour
{
    // Start is called before the first frame update
    public int checkArmor = 1;
    private float timeArmorExit = 0;
    private float timeDlayArmorExit = 4;
    public new GameObject animation;
    private Color startColor = Color.red;
    private Color endColor = Color.black;
    [Range(0, 10)]
    float speedBlink = 9;
    Renderer ren;
    TankMover js;
    //  BulletCon2 bu;
    void Start()
    {
        js = FindObjectOfType<TankMover>();
        // bu = GetBulletCon2Instance();
    }
    // private BulletCon2 GetBulletCon2Instance()
    // {
    //     BulletCon2[] bulletCon2s = FindObjectsOfType<BulletCon2>();

    //     if (bulletCon2s.Length > 0)
    //     {
    //         return bulletCon2s[0];
    //     }

    //     return null;
    // }
    // public virtual void ReciveItemBullet(bool armor)
    // {
    //     if (bu != null)
    //     {
    //         bu.inBullet();
    //     }
    // }
    void Awake()
    {
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkArmor == 2)
        {
            GameObject ani = Instantiate(animation, transform.position, Quaternion.identity) as GameObject;
            Destroy(ani, 0.1f);
        }
        if (checkArmor == 3)
        {
            this.timeArmorExit += Time.deltaTime;
            if (this.timeArmorExit < this.timeDlayArmorExit)
            {
                ren.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speedBlink, 1));
                return;
            }
            else
            {
                //this.timeArmorExit = 0;
                //immortalTime();
            }
        }
        //Debug.Log("đây là js"+ js);
    }
/*    void immortalTime()
    {
        ReciveItemArmor(false);
        checkArmor = 1;
    }
    public virtual void ReciveItemArmor(bool armor)
    {
        js.setArmor(armor);
        checkArmor = 2;
    }
    public virtual void ReciveItemBullet(bool armor)
    {
        if(js != null){
        js.setBu();
        }
    }*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("bulletEnemy"))
        {
            if (checkArmor == 2 || checkArmor == 3)
            {
                checkArmor = 3;
            }
            else
            {
                //end game ở đây
                //Time.timeScale = 0;
            }
        }
        if (other.gameObject.CompareTag("powerup_grenade"))
        {

        }
    }

}
