using UnityEngine;
using UnityEngine.UI;


public class ChangeColorOnClick : MonoBehaviour
{
    public Color newColor = Color.red;
    public int stressImpact;
    private bool alreadyClicked = false;
    
    public Vector3 newScale = new Vector3(2f, 2f, 2f); 
    void OnMouseDown()
    {
        if (alreadyClicked)
        {
            return;
        }

        alreadyClicked = true;

        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = newColor;
            Debug.Log("color changed"); 
        }

        transform.localScale = newScale;
        Debug.Log("scale changed"); 

        GlobalValues.stress += stressImpact;

    }
}
