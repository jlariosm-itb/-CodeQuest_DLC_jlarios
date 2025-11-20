using System;
using System.Runtime.InteropServices;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //Exercice 1
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Increase LVL";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 3.";
        const string NameMessage = "Please tell me your name:";
        const string TrainingMessage = "Do you want to start training, Sir {0}? (Write YES or NO)";
        const string FinalTrain = "After all that hard work you achieved the rank {0}";
        const string FirstRank = "Repeteixes a 2a convocatòria, has obtingut el rang de: Raoden Elantrí";
        const string SecondRank = "Encara confons la vareta amb una cullera, has obtingut el rang de: Zyn el Bugejat";
        const string ThirdRank = "Ets un Invocador de Brises Màgiques. Has obtingut el rang de: Arka Nullpointer";
        const string FourdRank = "Uau! Pots invocar dracs sense cremar el laboratori! Has obtingut el rang de: Elarion de les Brases.";
        const string FifthRank = "Has assolit el rang de Mestre dels Arcans! Has obtinut el rang ITB-Wizard el Gris";
        const string EasterEgg = "LOOK WHAT U HAVE DONE!!! YOU UNLOCK THE SECRET RANK: THE JUNE SAVIOR OF THE ITB. Now you are able to save your team from the evil June";
        const string DayFinished = "A day of exhausting training has finished successfully. You archved {0} of training hours and you gained {1} points of power.";
        const string TrainingFinished = "You has completed your training and you earned {0} of training hours and {1} of power points. ";
        const string CurrentLvl = "Congratulations you archive the level {0}!!!";
       
        
        //Exercice 1
        int op = 0;
        bool validInput;
        string Wizardname = "", rank = "Uknown";
        int wizardlvl = 1, hourstraining = 0, wizardpower = 0, totalpower = 0, totalhours = 0;
        int day = 0;
        var random = new Random();
        string starttraining = "";

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

                        if (starttraining.Equals("YES", StringComparison.OrdinalIgnoreCase)) //Ignore capital letters, convert in NoCaseSensitive
                        {
                            for (day = 1; day <= 5; day++)
                            {
                                Console.WriteLine($"Wellcome {Wizardname}, you are on your training arc...");
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
                            Console.WriteLine("Well we wake up a little bit lazy today...");
                        }
                        Console.WriteLine(CurrentLvl, wizardlvl);
                    } while (!starttraining.Equals("YES", StringComparison.OrdinalIgnoreCase));
                    break;
            }


        } while (op != 0);
    }

}
