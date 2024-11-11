using UnityEngine;
using UnityEngine.UI;

public class PaintingClick : MonoBehaviour
{
    public GameObject painting;
    public GameObject paintingBorder;
    public Slider stressProgress;

    void OnMouseDown() {
        stressProgress.value += 2;
        Destroy(painting);
        Destroy(paintingBorder);
    }
}
