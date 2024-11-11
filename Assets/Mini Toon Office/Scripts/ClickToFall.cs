using UnityEngine;

public class ClickToFall : MonoBehaviour
{
    public Rigidbody fallingBlockBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fallingBlockBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        fallingBlockBody.useGravity = true;
    }
}
