using UnityEngine;
using UnityEngine.UI;

public class PaintingClick : MonoBehaviour
{
    public GameObject painting;
    public GameObject paintingBorder;
    public int stressImpact;

    void OnMouseDown() {
        GlobalValues.stress += stressImpact;
        Destroy(painting);
        Destroy(paintingBorder);
    }
}
