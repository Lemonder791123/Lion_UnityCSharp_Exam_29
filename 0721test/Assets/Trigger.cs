using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(AudioSource))]

public class Trigger : MonoBehaviour
{


    public Text text;
    public AudioClip impact;
    AudioSource audiosource;




    private void OnTriggerEnter(Collider other)
    {
       text.text= "到達終點";
    }





    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        audiosource.PlayOneShot(impact);
    }

}