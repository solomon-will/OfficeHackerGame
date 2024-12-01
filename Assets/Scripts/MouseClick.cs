using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseClick : MonoBehaviour
{
    public TextMeshPro computerText;
    public int stressImpact;
    public GameObject[] puzzle;
    private bool alreadyClicked = false;

    void OnMouseDown() {
        if (alreadyClicked)
        {
            return;
        }

        alreadyClicked = true;

        computerText.text = "Enter Password";
        GlobalValues.stress += stressImpact;

    }
}
