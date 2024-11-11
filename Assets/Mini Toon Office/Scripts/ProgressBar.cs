using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    public Slider stressProgress;
    public float timeLimit;
    public TimerScript timer;
    private float timeElapsed = 0;
    private float timeRemain;
    private float deltaTimeSnapshot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeRemain = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTimeSnapshot = Time.deltaTime;
        timeElapsed += deltaTimeSnapshot;
        Debug.Log(timeElapsed);
        timeRemain -= deltaTimeSnapshot;

        timer.UpdateTimer(timeRemain.ToString("F2"));
        if (timeElapsed >= timeLimit) {
            SceneManager.LoadScene(3);
        }

        if (stressProgress.value >= 5) {
            SceneManager.LoadScene(2);
        }
    }
}
