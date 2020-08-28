using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level;
    string password;
    string[] passOne = { "star", "trek", "crew", "live", "long" };
    string[] passTwo = { "prosper", "hijinks", "captain", "mission", "klingon" };
    string[] passThree = { "resistance", "intergalactic", "telepathic", "fascinating", "assimilated" };

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
            AskForPassword();
        } else {
            Terminal.WriteLine("Please choose a valid level!");
        }
    }

    //Ask the player for the code and give them a hint
    void AskForPassword () {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter password, hint: " + password.Anagram());
    }

    //Set a random password based on level
    void SetRandomPassword () {
        switch(level) {
            case 1: 
                password = passOne[Random.Range(0, passOne.Length)];
                break;
            case 2:
                password = passTwo[Random.Range(0, passTwo.Length)];
                break;
            case 3:
                password = passThree[Random.Range(0, passThree.Length)];
                break;
            default:
                Debug.LogError("Not a valid level!");
                break;
        }
    }

    // Checks to see if the user input matches password
    void CheckPassword (string input) {
        if (input == password) {
            DisplayWinScreen();
        } else {
            AskForPassword();           
        }
    }

    void DisplayWinScreen () {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward () {
        switch(level) {
            case 1:
                Terminal.WriteLine("You've hacked the Kobayashi Maru!");
                Terminal.WriteLine(@"
     .--.
    (    )       
   (_)  /
       (_,      
");
                //Ascii art based on art found on:
                Terminal.WriteLine("Credit for ascii art to https://www.asciiart.eu/space/other");
                break;
            case 2:
                Terminal.WriteLine("You've hacked the USS Enterprise!");
                Terminal.WriteLine(@"
       .-.      _______  
      {}``; |==|_______D  
      / ('        /|\  
  (  /  |        / | \  
   \(_)_]]      /  |  \          
");
                //Ascii art based on art found on:
                Terminal.WriteLine("Credit for ascii art to https://www.asciiart.eu/space/telescopes");
                break;
            case 3:
                Terminal.WriteLine("You've hacked the Starfleet!");
                Terminal.WriteLine(@"
     ___
 ___/   \___
/   '---'   \
'--_______--'
     / \
    /   \           
");
                //Ascii art found on:
                Terminal.WriteLine("Credit for ascii art to https://www.asciiart.eu/space/aliens");
                break;
            default:
                Terminal.WriteLine("Wow you hacked the hacking game. Well done.");
                break;
        }
        Terminal.WriteLine("Type 'menu' to return home");
    }


}
