using UnityEngine;
using UnityEngine.UI;


public class ChangeColorOnClick : MonoBehaviour
{
    public Color newColor = Color.red;
    public Slider stressProgress;
    public int stressImpact;
    
    public Vector3 newScale = new Vector3(2f, 2f, 2f); 
    void OnMouseDown()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = newColor;
            Debug.Log("color changed"); 
        }

        transform.localScale = newScale;
        Debug.Log("scale changed"); 

        stressProgress.value += stressImpact;

    }
}
