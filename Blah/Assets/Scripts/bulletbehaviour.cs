using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletbehaviour : MonoBehaviour {


    private float phase2timer;
    private float timetillphase2 = 0.25f;
    private bool usedphase2;
    private bool canexpand = false;
    private bool hasshot;


    private float phase3timer;
    private float timetillphase3 = 2f;

    public GameObject haloobject;


    void Start ()
    {

        
        this.GetComponent<SphereCollider>().enabled = true;

        phase2timer = timetillphase2;
        phase3timer = timetillphase3;
    }
	
	void Update ()
    {
        phase2timer -= Time.deltaTime;
        phase3timer -= Time.deltaTime;

        if (phase2timer <= 0 && !usedphase2)
        {
            phase2();
            usedphase2 = true;
        }

        if (phase3timer <= 0)
        {
            phase3();
        }


        if (Input.GetMouseButtonDown(0) && canexpand)
        {
            Expand();
        }

    }



    void Expand()
    {
        if (!hasshot)
        {
            this.GetComponent<ParticleSystem>().Play();
            Destroy(haloobject);
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<SphereCollider>().enabled = false;
            effectsbehaviour.Instance.bulletexploded();
            hasshot = true;
        }
      
    }


    void phase2()
    {
        SoundManager.Instance.phase2();
        canexpand = true;
        haloobject.SetActive(true);
        
    }

    void phase3()
    {
        
        Destroy(this.gameObject);
    }


    
       
   
}
