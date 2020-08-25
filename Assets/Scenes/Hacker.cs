using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        print("Hello Console");
        ShowMainMenu("Hello Rachael");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Displays game entry screen
    void ShowMainMenu (string greeting) {
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);

        //Terminal.WriteLine("Welcome Captain. Infiltrate the");
        Terminal.WriteLine("following federation systems.");
        Terminal.WriteLine("Refuse and we will detonate the red");
        Terminal.WriteLine("matter at your planet's core.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the Kobayashi Maru");
        Terminal.WriteLine("Press 2 for the USS Enterprise");
        Terminal.WriteLine("Press 3 for the Starfleet Mainframe");
        Terminal.WriteLine("");
        Terminal.WriteLine("Resistance is futile.");
        Terminal.WriteLine("Choose wisely: ");
    }
}
