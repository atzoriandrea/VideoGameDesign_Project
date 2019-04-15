using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxCtrl : MonoBehaviour {
    public Material sky1;
    public Material sky2;
    public Material sky3;
    public Material sky4;
    Transform t;
    public Light lt;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        t = GetComponent<Transform>();
        if (t.position.x > 450)
        {
            RenderSettings.skybox = sky2;
            lt.intensity = 0f;
        }
        else
        {
            RenderSettings.skybox = sky1;
            lt.intensity = 1f;
        }

    }
}
