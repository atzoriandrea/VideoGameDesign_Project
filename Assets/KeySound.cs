using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySound : MonoBehaviour {
    public GameObject player;
    AudioSource source;
    public AudioClip sound;
    float distance;
    float distVolume;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.clip = sound;
        source.Play();
    }
	
	// Update is called once per frame
	void Update () { //Gestioone volume del suono delle chiavi in base alla distanza
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 6)
            distVolume = 1;
        else if (distance > 6 && distance <= 12)
            distVolume = 0.7f;
        else if (distance > 12 && distance <= 18)
            distVolume = 0.3f;
        else if (distance > 18)
            distVolume = 0;
        source.volume = distVolume;
    }
}
