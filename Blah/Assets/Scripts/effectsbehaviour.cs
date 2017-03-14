using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectsbehaviour : MonoBehaviour {
    public static effectsbehaviour Instance;

    private bool timespeedslow;
    private bool timenormal;
    private bool instanteffect;
    private float insteffectcount = 0.05f;

    private float timeslowspeed = 0.1f;

    public GameObject Camera1;
    public GameObject target;
    private float zoomSpeed = 5f;
    private float minZoomFOV = 45f;
    private float maxZoomFOV = 85;

    private GameObject cameratarget;
    public GameObject pointer;
    public GameObject camerasaved;


    void Start ()
    {
        
        Instance = this;
	}
	
	void Update ()
    {
        if (cameratarget != null)
        {
            pointer.transform.LookAt(cameratarget.transform);
        }


        if (timespeedslow)
        {
            Camera1.GetComponent<Camera>().fieldOfView -= zoomSpeed / 8;
            if (Camera1.GetComponent<Camera>().fieldOfView < minZoomFOV)
            {
                Camera1.GetComponent<Camera>().fieldOfView = minZoomFOV;
            }

           // Camera1.transform.rotation = Quaternion.Lerp(Camera1.transform.rotation, pointer.transform.rotation, 0.1f);

            if (Time.timeScale >= timeslowspeed)
            {
                Time.timeScale -= 0.05f;
            }

            if (Camera1.GetComponent<Kino.Vignette>()._falloff < 0.4f)
            {
                Camera1.GetComponent<Kino.Vignette>()._falloff += 0.02f;

            }

            if (Camera1.GetComponent<Kino.Bokeh>().fNumber >= 0.1f)
            {
                Camera1.GetComponent<Kino.Bokeh>().fNumber -= 0.08f;
            }
            if (Camera1.GetComponent<Kino.DigitalGlitch>().intensity <= 0.015f)
            {
                Camera1.GetComponent<Kino.DigitalGlitch>().intensity += 0.005f;

            }

        }

        if (!timespeedslow)
        {
           
                Camera1.GetComponent<Camera>().fieldOfView += zoomSpeed /8;

                if (Camera1.GetComponent<Camera>().fieldOfView > maxZoomFOV)
                {
                    Camera1.GetComponent<Camera>().fieldOfView = maxZoomFOV;
                    this.GetComponent<FPSPlayer>().cameracontrol = true;
                }
            
            if (Time.timeScale <= 1)
            {
                Time.timeScale += 0.025f;
                if (Time.timeScale > 1)
                {
                    Time.timeScale = 1;
                    timenormal = true;
                }
            }
           if (Camera1.GetComponent<Kino.Vignette>()._falloff > 0.05f)
            {
                Camera1.GetComponent<Kino.Vignette>()._falloff -= 0.010f;

            }
            if (Camera1.GetComponent<Kino.Bokeh>().fNumber <= 2.4f)
            {
                Camera1.GetComponent<Kino.Bokeh>().fNumber += 0.1f;
            }
          Camera1.GetComponent<Kino.DigitalGlitch>().intensity = 0;

        }

        if (instanteffect)
        {
            insteffectcount -= Time.deltaTime;
            Camera1.GetComponent<Kino.AnalogGlitch>().scanLineJitter = 0.3f;
          //  Camera1.GetComponent<Kino.DigitalGlitch>().intensity = 0.05f;
            if (insteffectcount <= 0)
            {
                Camera1.GetComponent<Kino.AnalogGlitch>().scanLineJitter = 0f;
                //Camera1.GetComponent<Kino.DigitalGlitch>().intensity = 0;
                instanteffect = false;
                insteffectcount = 0.05f;
            }
        }

      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        

    }

    public void BulletFired(GameObject _bullet)
    {
        SoundManager.Instance.slomo();
        this.GetComponent<FPSPlayer>().cameracontrol = false;
        timespeedslow = true;
        Camera1.GetComponent<Kino.Bokeh>().pointOfFocus = _bullet.transform;
        cameratarget = _bullet;
    }


    public void bulletexploded()
    {
        SoundManager.Instance.explode();
        cameratarget = null;
        instanteffect = true;
        timespeedslow = false;
        Camera1.GetComponent<Kino.Bokeh>().pointOfFocus = null;
        this.GetComponent<FPSPlayer>().cameracontrol = true;

    }




}



