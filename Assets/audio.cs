using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       AudioSource audioSource = gameObject.AddComponent<AudioSource>();

    }
    //aud.play();
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // audioSource.Play();  
        GetComponent<AudioSource>().Play();
        Debug.Log("crash");
    }
}
