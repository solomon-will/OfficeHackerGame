using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;

    private AudioListener audio1;
    private AudioListener audio2;
    private AudioListener audio3;

    void Start() {
        audio1 = Camera1.GetComponent<AudioListener>();
        audio2 = Camera2.GetComponent<AudioListener>();
        audio3 = Camera3.GetComponent<AudioListener>();
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            CameraOne();
        }

        if (Input.GetKeyDown("2"))
        {
            CameraTwo();
        }

        if (Input.GetKeyDown("3")) {
            CameraThree();
        }

       
    }

    void CameraOne()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        audio1.enabled = true;
        audio2.enabled = false;
        audio3.enabled = false;
    }

    void CameraTwo()
    {
        Camera2.SetActive(true);
        Camera1.SetActive(false);  
        Camera3.SetActive(false);
        audio1.enabled = false;
        audio2.enabled = true;
        audio3.enabled = false;
    }

    void CameraThree() {
        Camera3.SetActive(true);
        Camera2.SetActive(false);
        Camera1.SetActive(false);
        audio1.enabled = false;
        audio2.enabled = false;
        audio3.enabled = true;
    }
}