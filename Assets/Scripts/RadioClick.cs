using UnityEngine;

public class RadioClick : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}