using UnityEngine;
using UnityEngine.UI;

public class StressBlock : MonoBehaviour
{
    public Slider stressProgress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Boss")) {
            stressProgress.value += 5;
            Destroy(gameObject);
        }
    }
}
