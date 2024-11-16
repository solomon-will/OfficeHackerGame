using UnityEngine;
using UnityEngine.UI;


public class KeyboardMaterial : MonoBehaviour
{
    public GameObject targetObject;

    public Material newMaterial;
    public Slider stressProgress;
    public int stressImpact;


    void OnMouseDown()
    {
        
        if (targetObject != null)
        {
            Renderer targetRenderer = targetObject.GetComponent<Renderer>();
            
            if (targetRenderer != null && newMaterial != null)
            {
                if (targetRenderer.materials.Length > 1)
                {
                    Material[] materials = targetRenderer.materials;

                    materials[1] = newMaterial;

                    targetRenderer.materials = materials;

                    Debug.Log("Second material changed!");
                }
                else
                {
                    Debug.Log("Target object does not have a second material!");
                }
            }
        }
        stressProgress.value += stressImpact;
    }
}
