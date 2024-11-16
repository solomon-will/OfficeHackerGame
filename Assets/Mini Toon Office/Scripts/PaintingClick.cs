using UnityEngine;
using UnityEngine.UI;

public class PaintingClick : MonoBehaviour
{
    public GameObject painting;
    public GameObject paintingBorder;
    public Slider stressProgress;
    public int stressImpact;

    void OnMouseDown() {
        stressProgress.value += stressImpact;
        Destroy(painting);
        Destroy(paintingBorder);
    }
}
