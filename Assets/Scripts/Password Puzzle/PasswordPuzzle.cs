using UnityEngine;

public class PasswordPuzzle : MonoBehaviour
{
    public static string userInput = "";
    public string password;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraScript.currentCameraName = "Hallway Computer") {
            if (Input.inputString.Length > 0) {
                if (Input.GetKeyDown(KeyCode.Backspace)) {
                    if (userInput.Length > 0) {
                        userInput = BackspaceString(userInput);
                    }
                } else if (Input.GetKeyDown(KeyCode.Return)) {

                    userInput = "";
                } else {
                    userInput += Input.inputString;
                }
            }
        }
        Debug.Log("Active Camera: " + CameraScript.currentCameraName);

    }

    bool isCorrectPassword() {
        string sortedInput = SortInput(userInput);
        return sortedInput == password;
    }

    string SortInput(string str) {
        char[] inputChars = str.ToCharArray();
        Array.Sort(inputChars);
        return new string(inputChars);
    }

    string BackspaceString(string str) {
        return str.Substring(0, str.Length - 1);
        
    }


}
