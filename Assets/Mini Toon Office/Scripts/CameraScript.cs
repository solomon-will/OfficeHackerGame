using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject[] Cameras;


    private int currentCamera = 0;
    private int cameraCount;

    void Start() {
        cameraCount = Cameras.Length;
        foreach (GameObject cam in Cameras) {
            cam.SetActive(false);
            cam.GetComponent<AudioListener>().enabled = false;
        }
        Cameras[0].SetActive(true);
        Cameras[0].GetComponent<AudioListener>().enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown("1")) {
            CameraDown();
        }

        if (Input.GetKeyDown("2")) {
            CameraUp();
        }
    }

    void CameraDown() {
        int prev = currentCamera;
        currentCamera--;
        currentCamera = HandleEdges(currentCamera);
        SetCamera(currentCamera, prev);
    }

    void CameraUp() {
        int prev = currentCamera;
        currentCamera++;
        currentCamera = HandleEdges(currentCamera);
        SetCamera(currentCamera, prev);
    }

    int HandleEdges(int current) {
        if (current < 0) {
            current = cameraCount - 1;
        } else if (current > cameraCount - 1) {
            current = 0;
        }
        return current;
    }

    void SetCamera(int cam, int prev) {
        Debug.Log("SetCamera Running : " + cam);
        Cameras[cam].SetActive(true);
        Cameras[cam].GetComponent<AudioListener>().enabled = true;

        Cameras[prev].SetActive(false);
        Cameras[prev].GetComponent<AudioListener>().enabled = false;

    }
}
