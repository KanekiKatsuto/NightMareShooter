using UnityEngine;
using System.Collections;

public class InstructionButton : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height*2 / 3, 100, 35), "Start Game"))
        {
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height*2 / 3, 100, 35), "Main Menu"))
        {
            Application.LoadLevel(0);
        }
        if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height*2 / 3, 100, 35), "Exit Game"))
        {
            Application.Quit();
        }
    }
}
