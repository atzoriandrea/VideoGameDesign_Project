using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxCtrl : MonoBehaviour {
    public Material sky1;
    public Material sky2;
    public Material sky3;
    public Material sky4;
    public Light flash;
    int scene;
    Transform t;
    //public GameObject luce;
    public Light lt;
    // Use this for initialization
    void Start () {
        scene = 1 ;
        sky1 = RenderSettings.skybox;

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
        while (flash.intensity <= 100)
        {
            flash.intensity += 15f;
            lt.intensity = 0;
            yield return null;
        }
        yield return null;
        while (flash.intensity >= 0)
        {
            RenderSettings.skybox = sky1;
            flash.intensity -= 15f; 
            lt.intensity = 1;
            yield return null;
        }
        
    }
    IEnumerator changeToSkyTwo()
    {
        while (flash.intensity <= 100)
        {
            flash.intensity += 15f;
            lt.intensity = 1;
            yield return null;
        }
        yield return null;
        while (flash.intensity >= 0)
        {
            RenderSettings.skybox = sky2;
            flash.intensity -= 15f;
            lt.intensity = 0;
            yield return null;
        }

    }
}
