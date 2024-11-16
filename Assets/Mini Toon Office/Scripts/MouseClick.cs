using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseClick : MonoBehaviour
{
    public TextMeshPro computerText;
    public Slider stressProgress;
    public int stressImpact;

    void OnMouseDown() {
        computerText.text = "Login Successful.";
        stressProgress.value += stressImpact;
    }
}
