using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxCtrl : MonoBehaviour {
    public Material sky1;
    public AudioClip scene1;
    public Material sky2;
    public AudioClip scene2;
    public Material sky3;
    public AudioClip scene3;
    public Material sky4;
    public AudioClip scene4;
    public AudioClip thunder;
    public Light flash;
    bool[] firstTime = {true,true,true,true};
    int scene;
    public GameObject camera;
    AudioSource source;
    Transform t;
    //public GameObject luce;
    public Light lt;
    // Use this for initialization
    void Start () {
        scene = 9 ;
        sky1 = RenderSettings.skybox;
        source = camera.GetComponent<AudioSource>();
        source.volume = 0.1f;
        
    }
	
	// Update is called once per frame
	void Update () {
        t = GetComponent<Transform>();
        if (t.position.x > 450)
        {  
            if (scene != 2)
            {
                scene = 2;
                StartCoroutine("changeToSkyTwo");
            }
        }
        if (t.position.x <= 450)
        {
            
            if (scene != 1)
            {
                scene = 1; 
                StartCoroutine("changeToSkyOne");
            }
        }
        Debug.Log(scene);
    }
    
          
    IEnumerator changeToSkyOne() {
        bool up = true;
        bool done = false;
       
        while (!done)
        {
            if (up)
            {
                if (flash.intensity < 100)
                {
                    flash.intensity += 15f;
                    lt.intensity = 0;
                }
                if (flash.intensity >= 100)
                {
                    source.clip = scene1;
                    source.Play();
                    RenderSettings.skybox = sky1;
                    up = false;
                }
            }
            else {
                if (flash.intensity > 0)
                {
                    flash.intensity -= 15f;
                    lt.intensity = 1;
                }
                else if (flash.intensity <= 0)
                {
                    done = true;
                }

            }
            yield return null;
        }
        
        
        
    }
    IEnumerator changeToSkyTwo()
    {
        bool up = true;
        bool done = false;
        
        while (!done)
        {
            if (up)
            {
                if (flash.intensity < 100)
                {
                    flash.intensity += 15f;
                    lt.intensity = 1;
                }
                if (flash.intensity >= 100)
                {
                    source.clip = scene2;
                    source.Play();
                    RenderSettings.skybox = sky2;
                    if (firstTime[1] == true)
                    {
                        source.PlayOneShot(thunder, 1f);
                        firstTime[1] = false;
                    }
                    up = false;
                }
            }
            else
            {
                if (flash.intensity > 0)
                {
                    flash.intensity -= 15f;
                    lt.intensity = 0;
                }
                else if(flash.intensity <= 0)
                {
                    done = true;
                }

            }
            yield return null;
        }

    }
}
