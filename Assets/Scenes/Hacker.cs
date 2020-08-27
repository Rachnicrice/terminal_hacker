using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level;
    string password;
    string[] passOne = { "Star", "Trek", "Crew", "Live", "Long" };
    string[] passTwo = { "Prosper", "Hijinks", "Captain", "Mission", "Klingon" };
    string[] passThree = { "Resistance", "Intergalactic", "Telepathic", "Fascinating", "Assimilated" };

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start() {
        print("Hello Console");
        ShowMainMenu();
    }

    void OnUserInput(string input) {
        if (input == "menu") {
            ShowMainMenu();
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
    }

    //Displays game entry screen
    void ShowMainMenu () {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        //Set up screen
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

    //Handles input on the game entry screen
    void RunMainMenu (string input) {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");

        if (input == "007") {
            Terminal.WriteLine("Welcome Mr.Bond. Choose a level.");
        } else if (isValidLevel) {
            level = int.Parse(input);
            StartGame();
        } else {
            Terminal.WriteLine("Please choose a valid level!");
        }
    }

    void StartGame () {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level) {
            case 1: 
                password = passOne[0];
                break;
            case 2:
                password = passTwo[0];
                break;
            case 3:
                password = passThree[0];
                break;
            default:
                Debug.LogError("Not a valid level!");
                break;
        }
        Terminal.WriteLine("Please enter your password: ");
    }

    // Checks to see if the user input matches password
    void CheckPassword (string input) {
        if (input == password) {
            Terminal.WriteLine("Good job. You're in.");
        } else {
            Terminal.WriteLine("You've just made a huge mistake");            
        }
    }


}
