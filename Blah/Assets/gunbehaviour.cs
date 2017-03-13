using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunbehaviour : MonoBehaviour {


    public GameObject bullet;
    public Transform muzzle;

    public Camera MainCam;

    private bool chambered;
    private float reloadtime = 1;
    private bool reloading;


    private Vector3 target;

    void Start ()
    {

        chambered = true;
	}



    void Update ()
    {
        selecttarget();


        if (Input.GetMouseButtonDown(0))
        {
            if (chambered)
            Fire();
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!chambered)
            Reload();
        }

        if (reloading == true)
        {
            reloadtime -= Time.deltaTime;
        }
        if (reloadtime <= 0 )
        {
            reloadcomplete();
            reloading = false;
            reloadtime = 1;
        }
	}


    void selecttarget()
    {
        RaycastHit hit;
        Ray ray = MainCam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
        if (Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }

        //muz
    }



    void Fire()
    {
        GameObject _bullet = Instantiate(bullet, muzzle.position, muzzle.rotation);

        _bullet.GetComponent<Rigidbody>().velocity = _bullet.transform.forward * 9;

       // effectsbehaviour.Instance.BulletFired(_bullet);
        chambered = false;

    }

    void Reload()
    {
        this.GetComponent<Animator>().SetTrigger("reload");
        reloading = true;
       
    }
    void reloadcomplete()
    {
        chambered = true;
    }

}
