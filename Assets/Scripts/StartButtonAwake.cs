using UnityEngine;
using System.Collections;

public class StartButtonAwake : MonoBehaviour {

    void OnGUI(){
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 3, 100, 35), "Start Game"))
        {
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 3+70, 100, 35), "Instruction"))
        {
            Application.LoadLevel(2);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 3+140, 100, 35), "Exit Game"))
        {
            Application.Quit();
        }
    }
}
