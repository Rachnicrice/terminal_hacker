using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start() {
        print("Hello Console");
        ShowMainMenu();
    }

    void OnUserInput(string input) {
        if (input == "007") {
            Terminal.WriteLine("Welcome Mr.Bond. Choose a level.");
        } else if (input == "1") {
            level = 1;
            currentScreen = Screen.Password;
            StartGame();
        } else if (input == "2") {
            level = 2;
            currentScreen = Screen.Password;
            StartGame();
        } else if (input == "3") {
            level = 3;
            currentScreen = Screen.Password;
            StartGame();
        } else if (input == "menu") {
            ShowMainMenu();
        } else {
            Terminal.WriteLine("Please choose a valid level!");
        }
    }

    //Displays game entry screen
    void ShowMainMenu () {
        Terminal.ClearScreen();

        Terminal.WriteLine("Welcome Captain. Infiltrate the");
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

    void StartGame () {
        Terminal.WriteLine("You have chosen level " + level);
    }
}
