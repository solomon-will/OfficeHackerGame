using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseClick : MonoBehaviour
{
    public TextMeshPro computerText;
    public Slider stressProgress;
    public int stressImpact;
    public GameObject[] puzzle;

    void OnMouseDown() {
        computerText.text = "Login Successful.";
        stressProgress.value += stressImpact;
        foreach (GameObject block in puzzle) {
            block.transform.position += new Vector3(0, 0, 0.03f);
        }

    }
}
