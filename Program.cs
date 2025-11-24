using System;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //Exercice 1 - Menu Constants
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard - Entrenar el mag";
        const string MenuOption2 = "2. Increase LVL - Combatre i pujar de nivell";
        const string MenuOption3 = "3. Loot the mine - Minar per aconseguir bits (moneda del joc)";
        const string MenuOption4 = "4. Show inventory - Mostrar inventari";
        const string MenuOption5 = "5. Buy items - Comprar objectes";
        const string MenuOption6 = "6. Show attacks by LVL - Veure atacs disponibles segons el nivell";
        const string MenuOption7 = "7. Decode ancient Scroll - Desxifrar pergamins màgics";
        const string MenuOptionExit = "0. Exit game - Sortir";
        const string MenuPrompt = "Choose an option (1-7) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 7.";

        //Exercice 1 - Training Messages
        const string NameMessage = "Please tell me your name:";
        const string TrainingMessage = "Do you want to start training, Sir {0}? (Write YES or NO)";
        const string FinalTrain = "After all that hard work you achieved the rank {0}";
        const string FirstRank = "Repeteixes a 2a convocatòria, has obtingut el rang de: Raoden Elantrí";
        const string SecondRank = "Encara confons la vareta amb una cullera, has obtingut el rang de: Zyn el Bugejat";
        const string ThirdRank = "Ets un Invocador de Brises Màgiques. Has obtingut el rang de: Arka Nullpointer";
        const string FourdRank = "Uau! Pots invocar dracs sense cremar el laboratori! Has obtingut el rang de: Elarion de les Brases.";
        const string FifthRank = "Has assolit el rang de Mestre dels Arcans! Has obtinut el rang ITB-Wizard el Gris";
        const string EasterEgg = "LOOK WHAT U HAVE DONE!!! YOU UNLOCK THE SECRET RANK: THE JUNE SAVIOR OF THE ITB. Now you are able to save your team from the evil June";
        const string DayFinished = "A day of exhausting training has finished successfully. You achieved {0} of training hours and you gained {1} points of power.";
        const string TrainingFinished = "You have completed your training and you earned {0} of training hours and {1} of power points. ";
        const string CurrentLvl = "Congratulations you achieved the level {0}!!!";

        //Exercice 2 - Dice Roll Constants
        const string StartMesagLvl = "Dear Sir {0}, you have your rank but you need level so now it's time to level up, let's go to farm some monsters...";
        const string MonsterAppears = "Oh no, a monster appears! You need to roll the dice to defeat it:";
        const string DiceOne =
            $"   ________ \n" +
            $"  /       /|  \n " +
            $"/_______/ |\n" +
            $" |       | |\n" +
            $" |   o   | /\n" +
            $" |       |/ \n" +
            $" '-------'";
        const string DiceTwo =
            $"   ________ \n" +
            $"  /       /|  \n " +
            $"/_______/ |\n" +
            $" | o     | |\n" +
            $" |       | /\n" +
            $" |     o |/ \n" +
            $" '-------'";
        const string DiceThree =
            $"   ________ \n" +
            $"  /       /|  \n " +
            $"/_______/ |\n" +
            $" | o     | |\n" +
            $" |   o   | /\n" +
            $" |     o |/ \n" +
            $" '-------'";
        const string DiceFour =
            $"   ________ \n" +
            $"  /       /|  \n " +
            $"/_______/ |\n" +
            $" | o   o | |\n" +
            $" |       | /\n" +
            $" | o   o |/ \n" +
            $" '-------'";
        const string DiceFive =
            $"   ________ \n" +
            $"  /       /|  \n " +
            $"/_______/ |\n" +
            $" | o   o | |\n" +
            $" |   o   | /\n" +
            $" | o   o |/ \n" +
            $" '-------'";
        const string DiceSix =
            $"   ________ \n" +
            $"  /       /|  \n " +
            $"/_______/ |\n" +
            $" | o   o | |\n" +
            $" | o   o | /\n" +
            $" | o   o |/ \n" +
            $" '-------'";
        const string MonsterSpawn = "A savage {0} appears with {1} HP!";
        const string AttackMessage = "Press ENTER to attack the objective";
        const string ThrowDice = "You attack with {0} of power!";
        const string LifeRest = "The objective has {0} HP left...";
        const string LvlUp = "Congratulations, your level increased by +1!!!";

        // Exercice 3 - Loot the mine Constants
        const string MineStartMessage = "You enter the mine. You have 5 attempts to find coins!";
        const string EnterXCoordinatesMessage = "Enter coordinates (X between 0 and 4): ";
        const string EnterYCoordinatesMessage = "Enter coordinates (Y between 0 and 4): ";
        const string FoundCoinMessage = "Congratulations! You found a coin and earned {0} bits!";
        const string NoCoinMessage = "Sorry, no coin here. Try again!";
        const string InvalidCoordinatesMessage = "Invalid coordinates! Please enter values between 0 and 4.";
        const string MineDisplayMessage = "Current Mine Map:";
        const string MineAttemps = "You have {0} attempts left.";
        const string Mined = "This cell has already been mined.";
        const string MineUploaded = "Updated mine grid:";
        const string GameOverMine = "Game over! You found a total of {0} bits.";
        const string ExitGame = "Exiting game...";
        const int GridSize = 5;
        const int MaxAttempts = 5;

        // Exercice 4 - Show inventory
        const string ShowInventory = "Your inventory contains:";
        const string EmptyInventory = "Your inventory is empty...";

        // Exercice 5 - Buy Items Constants
        const string AmegoSegarro = 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠌⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠤⣜⡧⠄⠀⠀⠀⢀⣀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠚⠒⠒⠒⠂⠀⠤⠬⠥⠤⢍⡉⣁⣒⣒⣒⠒⣠⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠀⠀⢰⡀⠈⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n" +
            "⠀⣀⣀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n" +
            "⠀⠹⠉⠉⠉⠉⠉⠉⠉⠛⠛⠛⠒⠒⠒⠒⠲⠲⠶⠤⠤⠤⠤⢤⣤⠤⣄⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⠤⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⠉⠙⠙⠓⠓⠒⠒⠒⠞⠲⠖⠤⠄⠤⠄⢰⡄⢀⣀⠀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠈⠉⠉⠀⠀⠒⠒⠒⠂⠒⠀⠀⠀⠤⢤⡄⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡇⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⡇⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣠⣄⣠⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣶⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠇⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⡿⣿⢿⣿⠿⡿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣤⣤⣀⡤⣄⠀⠀⠀⢀⣴⣿⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⡿⣋⠟⡛⠩⢄⠓⡰⢽⣿⠛⢿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠤⠛⠛⠲⠷⢶⣼⢳⣤⣁⣙⠀⣚⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣟⡣⡗⢭⢚⡰⢁⠎⠠⢁⠒⠀⠢⢈⠻⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠈⡃⠛⠛⠀⠉⢹⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣽⣿⢳⣬⣷⣾⣶⣧⣼⡢⢌⣡⣶⣾⣿⣷⡶⠆⢻⠗⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⢸⣿⢾⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⢣⣟⣽⣿⣿⣛⣿⣿⠋⢉⣿⣿⡿⠟⠛⠀⢹⣷⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣇⠀⠀⢸⣿⣾⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣷⣬⣶⣽⣶⣯⣭⣧⣋⣀⣈⣍⣹⣈⣍⣀⣸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⡆⠀⠀⠁⢸⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⢀⡎⠈⣁⣠⣤⣤⢬⡀⠀⠀⠀⠀\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⣷⣾⣵⣿⣿⣽⣾⣮⣷⣷⣶⣶⣾⢾\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣨⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⡽⢯⢿⡿⠿⠿⢻⠟⣿⠟⣿⣿⣯⠟\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣤⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣶⣤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢌⣿⣿⣿⣧⣿⣿⣿⣷⣾⣿⣶⣿⣶⣿⣿⣯⠟\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢻⣿⣿⣿⣿⣿⢿⣟⣯⢷⡀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣠⣤⣤⣤⣤⣼⣿⣿⡿⠭⠿⠿⠶⠾⠷⠾⠶⡿⣱⢾⣿⣿⡳\r\n" +
            "⠀⠀⠀⢀⣿⣷⣄⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣼⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡛⢯⠋⡍⠈⢸⣿⣿⣿⣿⣿⣟⣯⣿⡿⣽⣫⡉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡞⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠀⢸⣿⣿⡇\r\n" +
            "⠀⠀⠀⣽⣿⣿⣿⣯⠉⠉⠉⠁⠀⠀⠀⠀⠀⢸⣿⣯⣿⢷⣻⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⠜⠂⠁⠀⠀⠈⣿⣯⣿⣿⣿⣿⣾⣟⣿⣿⣳⢿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠃⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣯⠀⢸⣿⣿⣗\r\n" +
            "⠀⠀⢰⣿⣿⣿⣿⣿⣷⣄⡀⠀⠀⠀⠀⠀⠀⣾⣟⣿⢿⣿⣽⡾⣿⣿⣿⣿⣻⣷⣿⢿⣿⣿⣿⣿⣿⣯⣷⣤⣀⠀⠀⢸⣿⣿⣿⣽⣿⣟⡿⣝⣻⣿⣽⣟⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣎⠀⠰⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⢸⣿⣿⣿\r\n" +
            "⠀⠀⣼⣿⣿⣿⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⣿⣿⡽⣟⣿⣻⣿⣷⣯⢿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣦⣼⣟⣷⣿⣿⡿⣾⡽⣞⡷⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⡘⢸⠀⠀⣿⡅⠀⠀⠀⠀⠀⠀⠀⠀⠰⠀⣸⣿⣿⣿\r\n" +
            "⠀⠀⠻⢿⣿⣿⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⣿⡷⣿⢯⣷⣻⢾⣽⣟⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⡿⣟⣷⣻⢿⣝⡾⣿⣹⣿⣿⣿⣾⡄⠀⠀⠀⠀⠀⠀⠀⢸⠃⠸⠀⠀⣿⣇⣀⣠⣤⣤⡤⣤⣤⠤⠷⢶⣿⣿⣿⣿\r\n" +
            "⠀⠀⠀⠀⠙⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⡽⣯⢷⣯⣟⣾⣻⢿⣾⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣽⡞⣷⢯⡞⣽⣳⠽⣯⣿⣿⣟⣷⡀⠀⠀⠀⠀⠀⢠⠇⠀⠀⠀⢸⣿⣿⣿⣿⣾⣶⣽⣷⣋⣋⡉⣼⣿⣿⣿⣿\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡿⣞⣿⣽⣻⢾⡽⣶⢯⣿⣻⣿⣿⣿⣿⣿⣿⣿⣟⣿⣿⣿⣻⣿⣿⣿⣿⡿⣾⣹⢿⣯⣯⣟⣳⢯⣛⣷⣻⣿⣿⣯⣧⠀⠀⠀⠀⠀⢸⠂⠀⠀⠀⢈⣿⣿⢯⡛⣟⠻⠻⠿⣿⣿⣿⣿⣿⣿⣿⣿\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣳⣯⣟⣯⣿⣷⣻⡾⣽⣾⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣯⣿⣿⣿⣿⣿⣿⣯⣟⣷⣯⣟⣯⡽⣶⣻⣿⣿⣿⣽⠆⠀⠀⠀⠠⠃⠀⠀⠀⠀⠈⣿⣿⢀⠱⢈⠂⠁⠀⠀⢈⣿⣿⣿⣿⣿⣿\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⢿⣿⣿⣿⣿⣿⣷⣿⣷⣿⣟⡿⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣾⣽⣞⣷⣟⣯⣿⣿⣿⣿⣿⣻⡄⠀⢀⠇⠀⠀⠀⠀⠀⠀⢿⣿⠀⠀⠂⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣟⣿⣿⣿⣿⣿⣯⣿⣽⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣻⣳⠀⠌⠀⡀⠀⠀⠀⠀⠀⢹⣿⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⣿\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⡿⣿⣳⣟⣾⣿⣿⣿⣿⣯⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⠿⠋⠛⠒⠚⠿⣀⠤⠤⣀⠀⢹⣿⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣟⡿⣞⣧⣟⣷⠿⡿⣿⢿⡿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣽⣿⡿⠿⠿⠿⢛⠡⠀⡄⢁⠂⠌⣀⠠⢀⣶⡼⠂⢸⣿⠀⣀⣀⣀⣀⣀⣤⣤⣾⣿⣿⣿⣿⣿\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣻⣾⠿⠛⠉⠁⡀⠰⠐⡀⠆⡐⠄⠂⠄⠠⠀⠂⠄⠉⠌⠉⠉⡉⠉⡉⢉⠉⠌⡈⠡⢀⠂⠄⢃⡘⠐⣂⠡⢂⠰⡀⢎⠰⣄⠣⢎⣹⣆⣠⣾⣿⡿⣛⢭⡒⢶⡘⡴⢪⡝⡭⣟⡽⣻⣿\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⡿⠟⠉⠀⠀⠀⠀⠀⠠⠁⠂⠐⠀⡀⠐⠈⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⢀⠀⠂⢀⠠⠐⢀⠂⡌⠐⢂⠄⠣⡄⢎⡰⢡⠞⣬⢳⣬⣿⣶⣿⡿⣟⢫⡒⡱⣉⢏⣛⢳⡛⣼⣓⠾⣵⢯⣿⣿⣿\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡟⡱⢌⡱⢠⠐⠀⠀⠁⠀⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠀⢀⠀⢀⠀⢀⡀⠀⢄⠢⢀⠢⡘⢠⠒⣌⠱⣊⢌⠳⡘⢦⣑⣷⣾⣣⣿⣿⣿⣿⣿⡿⣜⢦⠳⡱⢎⡖⣎⢷⡹⢲⣍⣾⢿⣛⣽⣟⣻\r\n" +
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣠⣤⡤⠼⣧⠳⡌⠴⡁⠎⡐⠀⢂⠀⡀⠄⠂⢁⠐⠁⡐⢈⡐⢈⡐⠢⢈⠢⠌⡂⡔⢩⢐⡸⢄⡓⣌⢣⡝⣰⢋⣶⣩⣷⣿⣾⣿⣿⣿⣿⣿⣿⢿⣻⢷⡻⣜⢎⡳⣙⢮⡼⣝⣾⣽⠿⣿⣻⢿⣛⣯⣽⣿\r\n" +
            "⡲⢶⣲⣶⠾⠛⠋⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣧⡝⡲⡉⠖⡡⢉⠔⢂⠡⡀⠆⢂⠌⢂⠌⢠⠈⡄⢄⠣⢌⠢⣑⠲⡘⣆⣣⣜⣦⣳⣮⠷⠾⠷⠛⠫⢉⠃⠅⠣⠜⣿⣿⣿⣾⣽⣯⣳⣏⡳⡜⢮⣵⣿⣽⣻⠿⣛⢿⣽⡿⡽⣿⢿⣛⣳⣿\r\n" +
            "⣿⣷⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡼⣅⢣⠓⣄⠣⡘⣄⠣⡰⢈⣆⣜⣠⣎⣤⣣⣼⠦⠷⠾⠳⠛⠛⠛⠉⠉⠉⠀⠀⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠛⠿⢿⣿⣿⣿⣷⣾⣧⣯⣗⣾⡿⣽⣞⣽⣿⢽⣟⡾⣿⣛\r\n" +
            "⠛⣇⣹⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠃⠛⠺⠳⠛⠚⠛⠛⠉⠙⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠛⠛⠿⢿⣿⣿⣿⣷⣿⣾⣯⣿⣛⡿⣦⢿\r\n" +
            "⠀⢻⡰⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠛⠛⠿⢿⣿⣿⣿⣿⣿\r\n" +
            "⠀⠸⣷⢸⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠙⠛\r\n" +
            "⠀⠀⣿⢜⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n" +
            "⠀⠀⢸⣏⣾⠀⢀⣴⢶⣻⢻⣟⢾⣛⣟⣻⣟⣻⡟⣟⣟⣻⡷⣶⣞⣾⣶⣶⣶⣶⡶⣶⢶⡶⣶⢶⡶⣶⢶⣶⣶⢶⣶⢶⡶⣦⢶⣴⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣄⣤⣠⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⢀\r\n" +
            "⠀⠀⠸⣿⣼⣧⣾⣿⣾⣷⣿⣾⣿⣷⣾⣷⣾⣷⣿⣿⣿⣷⣿⣿⣽⣾⣷⣿⣾⣷⣿⣿⣯⣿⣽⣯⣿⣽⣿⣾⣽⣿⣾⣿⣽⣯⣿⣽⣯⣟⣾⣳⣯⣞⣶⣳⣞⣶⣳⣞⣶⣳⣞⣶⣳⣞⣶⣹⢎⡷⣭⣺⣱⡝⣬⢳⡬⣝⣬⠳⣜⣣⢭⡽⣸⠝⣎\r\n" +
            "⠀⠀⠀⣿⣯⣛⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n" +
            "⠀⠀⠀⢹⣷⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n" +
            "⢦⣄⠀⠸⣿⢾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n" +
            "⠈⢿⣿⡄⣷⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿";

        const string TenehSegearro = "Ola amego cuanto tempo!!! Amego tene segarro?";
        const string BuyItems = "Wellcome to the shop, here you can buy items with your bits, please tell me if you need something...";
        const string ShowItems = "Here you have our current stock:\r\n" +
            "{0}\r\n" +
            "This is your credit {1}";
        const string TimeToBuy = "Select what do you want to buy: ";
        const string NoMoney = "Ma friendo, you dont have enough money to buy that... Pls do JobAplications or something...";
        const string ShowBuy = "You bought {0}, you left {1} bits, 0 to exit.";
        const string InvalidBuy = "Invalid number try again...";
        const string ContinueBuy = "Would you like to try buying another item? (yes to continue, 0 to exit)";
        const string ReChooseItem = "Choose an item to buy or enter 0 to exit.";

        // Exercice 6
        const string ShowAtkMsg = "This is your level and your attaks:";
        const string AtkLvl1 = "Level 1 - Magic Spark 💫";
        const string AtkLvl2 = "Level 2 - Fireball 🔥, Ice Ray 🧊, Arcane Shield ⚕️";
        const string AtkLvl3 = "Level 3 - Meteor ☄️, Pure Energy Explosion 💥, Minor Charm 🎭, Air Strike 🍃";
        const string AtkLvl4 = "Level 4 - Wave of Light ⚜️, Storm of Wings 🐦";
        const string AtkLvl5 = "Level 5 - Cataclysm 🌋, Portal of Chaos 🌀, Arcane Blood Pact 🩸, Elemental Storm ⛈️";
        const string OverLvl = "Your level is bigger than 5 so you have all the attaks and you are overlevel...";

        // Exercice 7
        const string PerPresentation = "You found an ancient scroll with encrypted messages!";
        const string Scroll1 = "The 🐲 sleeps in the mountain of fire 🔥";
        const string Scroll2 = "Ancient magic flows through the crystal caves";
        const string Scroll3 = "Spell: Ignis 5 🔥, Aqua 6 💧, Terra 3 🌍, Ventus 8 🌪️";

        const string Ex7MenuMessage = "Choose an option:";
        const string Ex7Option1Message = "1. Remove spaces from the first scroll";
        const string Ex7Option2Message = "2. Count vowels from the second scroll";
        const string Ex7Option3Message = "3. Extract numbers from the third scroll";
        const string Ex7Option4Message = "4. Exit";
        const string Ex7InvalidOptionMessage = "Invalid option. Please try again.";
        const string Ex7SuccessMessage = "Success! Task completed.";

        //Exercice 1 - Variables
        int op = 0;
        bool validInput;
        string Wizardname = "", rank = "Unknown";
        int wizardlvl = 1, hourstraining = 0, wizardpower = 0, totalpower = 0, totalhours = 0;
        int day = 0;
        var random = new Random();
        string starttraining = "";

        //Exercice 2 - Arrays for Dice Faces and Monsters
        string[] diceFaces = { DiceOne, DiceTwo, DiceThree, DiceFour, DiceFive, DiceSix };
        string[] monsters = { "Wandering Skeleton 💀", "Forest Goblin 👹", "Green Slime 🦠", "Ember Wolf 🐺", "Giant Spider 🕷️", "Iron Golem 🤖", "Lost Necromancer 🧝‍", "Ancient Dragon 🐉" };
        int[] hpMonsters = { 3, 5, 10, 11, 18, 15, 20, 50 };

        // Exercice 3 - Variables
        int totalCoins = 0;
        string[,] visibleGrid = new string[GridSize, GridSize]; // Visible grid for the player
        int[,] hiddenGrid = new int[GridSize, GridSize]; // Hidden grid with coin values (0 = no coin, 1 = coin)
        Random rand = new Random();

        // Exercice 4 - Variables

        // Sources:
        // Source of the empty array - https://stackoverflow.com/a
        // Posted by Oded, modified by community. See post 'Timeline' for change history
        // Retrieved 2025-11-22, License - CC BY-SA 4.0

        string[] emptyStringArray = new string[100];
        int purchaseCount = 0;

        //Exercice 5
        string[] itemsshop = { "Iron Dagger 🗡️", "Healing Potion ⚗️", "Ancient Key 🗝️", "Crossbow 🏹", "Metal Shield 🛡️" };
        int[] itemsprice = { 30, 10, 50, 40, 20 };
        int itemBits = 0;

        // Exercice 6
        string[][] attackLevels = new string[][]
        {
            new string[] { AtkLvl1 }, // Nivel 1
            new string[] { AtkLvl2 }, // Nivel 2
            new string[] { AtkLvl3 }, // Nivel 3
            new string[] { AtkLvl4 }, // Nivel 4
            new string[] { AtkLvl5 }  // Nivel 5
        };


        do
        {
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOption4);
            Console.WriteLine(MenuOption5);
            Console.WriteLine(MenuOption6);
            Console.WriteLine(MenuOption7);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);

            validInput = true;
            try
            {
                op = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }
            catch (Exception)
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }

            if (validInput)
            {
                Console.WriteLine(op);
            }

            switch (op)
            {
                case 1:
                    // Exercise 1: Train Wizard
                    if (Wizardname.Equals(""))
                    {
                        Console.WriteLine(NameMessage);
                        Wizardname = Console.ReadLine();
                        Wizardname = Wizardname.ToLower();                  // All in lower case
                        Wizardname = char.ToUpper(Wizardname[0]) + Wizardname.Substring(1);
                    }

                    do
                    {
                        Console.WriteLine(TrainingMessage, Wizardname);
                        starttraining = Console.ReadLine();

                        if (starttraining.Equals("YES", StringComparison.OrdinalIgnoreCase))
                        {
                            for (day = 1; day <= 5; day++)
                            {
                                Console.WriteLine($"Welcome {Wizardname}, you are on your training arc...");
                                hourstraining = random.Next(1, 25);
                                wizardpower = random.Next(1, 11);
                                totalhours += hourstraining;
                                totalpower += wizardpower;

                                Console.WriteLine(DayFinished, hourstraining, wizardpower);
                            }

                            Console.WriteLine(TrainingFinished, totalhours, totalpower);

                            if (totalpower < 20)
                            {
                                Console.WriteLine(FirstRank);
                                rank = "Raoden el Elantrí";
                            }
                            else if (totalpower >= 20 && totalpower < 30)
                            {
                                Console.WriteLine(SecondRank);
                                rank = "Zyn el Buguejat";
                            }
                            else if (totalpower >= 30 && totalpower < 35)
                            {
                                Console.WriteLine(ThirdRank);
                                rank = "Arka Nullpointer";
                            }
                            else if (totalpower >= 35 && totalpower < 40)
                            {
                                Console.WriteLine(FourdRank);
                                rank = "Elarion de les Brases";
                            }
                            else if (totalpower >= 40 && totalpower < 80)
                            {
                                Console.WriteLine(FifthRank);
                                rank = "ITB-Wizard el Gris";
                            }
                            else if (totalpower >= 80)
                            {
                                Console.WriteLine(EasterEgg);
                                rank = "The June Savior of the ITB";
                            }

                            Console.WriteLine(FinalTrain, rank);
                        }
                        else
                        {
                            Console.WriteLine("Well, we woke up a little bit lazy today...");
                        }
                        Console.WriteLine(CurrentLvl, wizardlvl);
                    } while (!starttraining.Equals("YES", StringComparison.OrdinalIgnoreCase));
                    break;

                case 2:
                    // Exercise 2: Level up
                    Random rnd = new Random();

                    int index = rnd.Next(monsters.Length);

                    string monster = monsters[index];
                    int hp = hpMonsters[index];

                    Console.WriteLine(StartMesagLvl, Wizardname);
                    Console.WriteLine(MonsterAppears);
                    Console.WriteLine(MonsterSpawn, monster, hp);
                    while (hp > 0)
                    {
                        Console.WriteLine(AttackMessage);
                        Console.ReadLine();

                        int roll = rnd.Next(1, 7);
                        Console.WriteLine(ThrowDice, roll);

                        Console.WriteLine(diceFaces[roll - 1]);

                        hp = hp - roll;

                        Console.WriteLine(LifeRest, hp);
                    }
                    wizardlvl++;
                    Console.WriteLine(LvlUp);
                    Console.WriteLine(CurrentLvl, wizardlvl);
                    break;

                case 3:
                    // Initialize the grids
                    for (int i = 0; i < GridSize; i++)
                    {
                        for (int j = 0; j < GridSize; j++)
                        {
                            visibleGrid[i, j] = "➖"; // Empty symbol
                            hiddenGrid[i, j] = rand.Next(0, 2); // Random mines (0 = no mine, 1 = mine)
                        }
                    }

                    Console.WriteLine(MineStartMessage);
                    int attempts = MaxAttempts;

                    while (attempts > 0)
                    {
                        Console.WriteLine(MineAttemps, attempts);
                        Console.WriteLine(MineDisplayMessage);

                        // Display the current visible grid
                        for (int i = 0; i < GridSize; i++)
                        {
                            for (int j = 0; j < GridSize; j++)
                            {
                                Console.Write(visibleGrid[i, j] + " ");
                            }
                            Console.WriteLine();
                        }

                        // X Cordinates 
                        int x = -1;
                        while (x < 0 || x >= GridSize)
                        {
                            Console.WriteLine(EnterXCoordinatesMessage);
                            if (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= GridSize)
                            {
                                Console.WriteLine(InvalidCoordinatesMessage);
                            }
                        }

                        // Y Cordinates
                        int y = -1;
                        while (y < 0 || y >= GridSize)
                        {
                            Console.WriteLine(EnterYCoordinatesMessage);
                            if (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= GridSize)
                            {
                                Console.WriteLine(InvalidCoordinatesMessage);
                            }
                        }

                        // Check if the cell has already been excavated
                        if (visibleGrid[x, y] != "➖")
                        {
                            Console.WriteLine(Mined);
                            continue;
                        }

                        // Check if the player found a coin
                        if (hiddenGrid[x, y] == 1)
                        {
                            visibleGrid[x, y] = "🪙"; // Coin found
                            itemBits += rand.Next(5, 51);
                            Console.WriteLine(FoundCoinMessage, itemBits);
                        }
                        else
                        {
                            visibleGrid[x, y] = "❌"; // No coin found
                            Console.WriteLine(NoCoinMessage);
                        }

                        attempts--;
                    }

                    Console.WriteLine(GameOverMine, itemBits);

                    break;

                case 4:

                    if (purchaseCount == 0) 
                    { 
                        Console.WriteLine(EmptyInventory);
                    }
                    else 
                    {
                        Console.WriteLine(ShowInventory);
                        for (int i = 0; i < purchaseCount; i++)  
                        {
                            Console.WriteLine(emptyStringArray[i]);
                        }
                    }
                    break;

                case 5:
                    Console.WriteLine(AmegoSegarro);
                    Console.WriteLine(TenehSegearro);
                    Console.WriteLine(BuyItems);
                    var itemsWithPrices = new StringBuilder(); //Object created for contain data
                    for (int i = 0; i < itemsshop.Length; i++)
                    {
                        itemsWithPrices.AppendLine($"{i + 1}. {itemsshop[i]} - {itemsprice[i]}");
                    }
                    Console.WriteLine(ShowItems, itemsWithPrices, itemBits);

                    Console.WriteLine(TimeToBuy);
                    string itemInput;
                    bool continueBuying = true; // Flag to control the buying loop

                    do
                    {
                        itemInput = Console.ReadLine();

                        if (int.TryParse(itemInput, out int seleccion))
                        {
                            // Subtract 1 because arrays are 0-indexed
                            int itemBought = seleccion - 1;

                            if (itemBought >= 0 && itemBought < itemsshop.Length)
                            {
                                if (itemsprice[itemBought] > itemBits)
                                {
                                    Console.WriteLine(NoMoney);

                                    Console.WriteLine(ContinueBuy);

                                    string tryAgain = Console.ReadLine().ToLower();
                                    if (tryAgain == "0")
                                    {
                                        continueBuying = false; // Set the flag to false to stop the loop
                                    }
                                    else
                                    {
                                        Console.WriteLine(ReChooseItem);
                                        continue; // Continue the loop
                                    }
                                }
                                else
                                {
                                    itemBits -= itemsprice[itemBought];

                                    Console.WriteLine(ShowBuy, itemsshop[itemBought], itemBits);

                                    emptyStringArray[purchaseCount] = itemsshop[itemBought]; 
                                    purchaseCount++;
                                }
                            }
                            else
                            {
                                Console.WriteLine(InvalidBuy);
                            }
                        }
                    } while (continueBuying && itemInput != "0");

                    break;

                case 6:
                    Console.WriteLine(ShowAtkMsg);
                    if (wizardlvl >= 1 && wizardlvl <= 5)
                    {
                        Console.WriteLine(attackLevels[wizardlvl - 1][0]); 
                    }
                    else
                    {
                        Console.WriteLine(OverLvl);
                    }
                    break;

                case 7:
                    Console.WriteLine(PerPresentation);
                    Console.WriteLine("1. " + Scroll1);
                    Console.WriteLine("2. " + Scroll2);
                    Console.WriteLine("3. " + Scroll3);

                    // Menú interactivo
                    while (true)
                    {
                        Console.WriteLine("\n" + Ex7MenuMessage);
                        Console.WriteLine(Ex7Option1Message);
                        Console.WriteLine(Ex7Option2Message);
                        Console.WriteLine(Ex7Option3Message);
                        Console.WriteLine(Ex7Option4Message);
                        Console.Write("Option: ");

                        string input = Console.ReadLine();

                        if (input == "1")
                        {
                            string scrollWithoutSpaces = Scroll1.Replace(" ", ""); // Remove spaces
                            Console.WriteLine("1. Scroll without spaces: " + scrollWithoutSpaces);
                            Console.WriteLine(Ex7SuccessMessage);
                        }
                        else if (input == "2")
                        {
                            string vowels = "aeiouáéíóúàèìòù";
                            int countVowels = 0;
                            foreach (char c in Scroll2.ToLower()) 
                            {
                                if (vowels.Contains(c))
                                {
                                    countVowels++; //increment the count
                                }
                            }
                            Console.WriteLine("2. Number of vowels: " + countVowels);
                            Console.WriteLine(Ex7SuccessMessage);
                        }
                        else if (input == "3")
                        {
                            var matches = Regex.Matches(Scroll3, @"\d+");
                            Console.Write("3. Extracted numbers: ");
                            foreach (var match in matches)
                            {
                                Console.Write(match + " "); // Print each extracted number
                            }
                            Console.WriteLine();
                            Console.WriteLine(Ex7SuccessMessage);
                        }
                        else if (input == "4")
                        {
                            Console.WriteLine("Goodbye!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine(Ex7InvalidOptionMessage);
                        }
                    }
                    break;

                case 0:
                    Console.WriteLine(ExitGame);
                    break;

                default:
                    Console.WriteLine(InputErrorMessage);
                    break;
            }

        } while (op != 0);
    }
}

//CODE BY JOEL LARIOS MUÑOZ
