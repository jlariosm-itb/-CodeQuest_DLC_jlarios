using System;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //Exercice 1 - Menu Constants
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Increase LVL";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 3.";

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
        const string EnterCoordinatesMessage = "Enter coordinates (X and Y between 0 and 4): ";
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
        int attempts = MaxAttempts;
        int totalCoins = 0;
        string[,] visibleGrid = new string[GridSize, GridSize]; // Visible grid for the player
        int[,] hiddenGrid = new int[GridSize, GridSize]; // Hidden grid with coin values (0 = no coin, 1 = coin)
        Random rand = new Random();


        do
        {
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
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
                            hiddenGrid[i, j] = rand.Next(0, 2);
                        }
                    }
                    Console.WriteLine(MineStartMessage);
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

                        Console.Write(EnterCoordinatesMessage);
                        string[] input = Console.ReadLine().Split();

                        // Validate the coordinates input
                        if (input.Length != 2 || !int.TryParse(input[0], out int x) || !int.TryParse(input[1], out int y) || x < 0 || x >= GridSize || y < 0 || y >= GridSize)
                        {
                            Console.WriteLine(InvalidCoordinatesMessage);
                            continue;
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
                            totalCoins += rand.Next(5, 51); 
                            Console.WriteLine(FoundCoinMessage, totalCoins);
                        }
                        else
                        {
                            visibleGrid[x, y] = "❌"; // No coin found
                            Console.WriteLine(NoCoinMessage);
                        }

                        attempts--;
                    }

                    // Game Over, show total coins found
                    Console.WriteLine(GameOverMine, totalCoins);
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
