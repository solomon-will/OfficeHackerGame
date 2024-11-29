using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseClick : MonoBehaviour
{
    public TextMeshPro computerText;
    public int stressImpact;
    public GameObject[] puzzle;

    void OnMouseDown() {
        computerText.text = "Login Successful.";
        GlobalValues.stress += stressImpact;

        foreach (GameObject block in puzzle) {
            block.transform.position += new Vector3(0.05f, 0, 0);
        }

    }
}
