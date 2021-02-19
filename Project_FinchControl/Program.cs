using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control Talent Show
    // Description: The Finch Robot will show off its talents
    // Application Type: Console
    // Author: Witt, Stephanie
    // Dated Created: 2/12/2021
    // Last Modified: 2/15/2021
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMainMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMainMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        AlarmSystemDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Show Off All Talents");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMotors(finchRobot);
                        break;

                    case "c":
                        TalentShowDisplayShowOffAll(finchRobot);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glow and beeps!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 180; lightSoundLevel += 60)
            {
                finchRobot.setLED(lightSoundLevel + 10, lightSoundLevel + 40, lightSoundLevel + 50);
                finchRobot.noteOn(lightSoundLevel * 50);
                finchRobot.wait(500);
            }

            for (int lightSoundLevel = 255; lightSoundLevel > 0; lightSoundLevel -= 50)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 50);
                finchRobot.wait(500);
            }

            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            TalentShowDisplayLightAndSoundAerithTheme(finchRobot);

            DisplayMenuPrompt("Talent Show Menu");
        }

        static void TalentShowDisplayLightAndSoundAerithTheme(Finch finchRobot)
        {
            bool validResponse;

            DisplayScreenHeader("Aerith's Theme Bonus");

            do
            {
                validResponse = true;

                Console.Write("\tWould you like to hear \"Aerith's Theme\" without movement? ");
                string userResponse = Console.ReadLine();

                if (userResponse == "yes")
                {
                    validResponse = true;

                    Console.Write("\tNow playing \"Aerith's Theme\"");

                    //rise
                    finchRobot.setLED(234, 54, 179); //pink
                    finchRobot.noteOn(698);
                    finchRobot.wait(500);
                    finchRobot.noteOn(880);
                    finchRobot.wait(500);
                    finchRobot.setLED(115, 239, 159); //seafoam
                    finchRobot.noteOn(1175);
                    finchRobot.wait(750);
                    finchRobot.noteOff();
                    finchRobot.wait(500);
                    //fall
                    finchRobot.setLED(115, 239, 200); //blue seafoam
                    finchRobot.noteOn(1046);
                    finchRobot.wait(500);
                    finchRobot.noteOn(880);
                    finchRobot.wait(500);
                    finchRobot.setLED(255, 54, 179); //reddish pink
                    finchRobot.noteOn(659);
                    finchRobot.wait(750);
                    finchRobot.noteOff();
                    finchRobot.wait(500);
                    //first staff
                    finchRobot.setLED(234, 54, 179); //pink
                    finchRobot.noteOn(698);
                    finchRobot.wait(300);
                    finchRobot.setLED(115, 239, 159); //seafoam
                    finchRobot.noteOn(880);
                    finchRobot.wait(300);
                    finchRobot.setLED(115, 239, 200); //blue seafoam
                    finchRobot.noteOn(1175);
                    finchRobot.wait(300);
                    finchRobot.setLED(255, 54, 179); //reddish pink
                    finchRobot.noteOn(1109);
                    finchRobot.wait(300);
                    //second staff
                    finchRobot.setLED(115, 239, 200); //blue seafoam
                    finchRobot.noteOn(1319);
                    finchRobot.wait(300);
                    finchRobot.setLED(234, 54, 179); //pink
                    finchRobot.noteOn(1175);
                    finchRobot.wait(300);
                    finchRobot.setLED(115, 239, 159); //seafoam
                    finchRobot.noteOn(784);
                    finchRobot.wait(300);
                    finchRobot.setLED(255, 54, 179); //reddish pink
                    finchRobot.noteOn(1047);
                    finchRobot.wait(300);
                    //final two
                    finchRobot.setLED(255, 255, 255); //white
                    finchRobot.noteOn(880);
                    finchRobot.wait(1000);
                    finchRobot.noteOff();
                    finchRobot.wait(250);
                    finchRobot.setLED(100, 100, 100); //gray
                    finchRobot.noteOn(659);
                    finchRobot.wait(1000);
                    finchRobot.noteOff();
                    finchRobot.wait(250);
                    finchRobot.setLED(0, 255, 0);
                    //off
                    finchRobot.setLED(0, 0, 0);
                }
                else if (userResponse == "no")
                {
                    validResponse = true;
                    Console.WriteLine("\tNo problem! I'll return you to the menu.");
                }
                else
                {
                    validResponse = false;

                    Console.WriteLine("Sorry, I didn't understand that. Please try again.");
                }

            } while (!validResponse);
        }
        static void TalentShowDisplayShowOffAll(Finch finchRobot)
        {
            Console.CursorVisible = false;
            DisplayScreenHeader("Showing off all talents");
            DisplayContinuePrompt();
            Console.WriteLine("\tThe finch will now sing \"Aerith's Theme\" and dance");

            //rise
            finchRobot.setMotors(100, 40);
            finchRobot.setLED(234, 54, 179); //pink
            finchRobot.noteOn(698);
            finchRobot.wait(500);
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.setLED(115, 239, 159); //seafoam
            finchRobot.noteOn(1175);
            finchRobot.wait(750);
            finchRobot.noteOff();
            finchRobot.setMotors(0, 0);
            finchRobot.wait(500);
            //fall
            finchRobot.setMotors(-100, -40);
            finchRobot.setLED(115, 239, 200); //blue seafoam
            finchRobot.noteOn(1046);
            finchRobot.wait(500);
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.setLED(255, 54, 179); //reddish pink
            finchRobot.noteOn(659);
            finchRobot.wait(750);
            finchRobot.noteOff();
            finchRobot.setMotors(0, 0);
            finchRobot.wait(500);
            //first staff
            finchRobot.setMotors(-70, -70);
            finchRobot.setLED(234, 54, 179); //pink
            finchRobot.noteOn(698);
            finchRobot.wait(300);
            finchRobot.setLED(115, 239, 159); //seafoam
            finchRobot.noteOn(880);
            finchRobot.wait(300);
            finchRobot.setLED(115, 239, 200); //blue seafoam
            finchRobot.noteOn(1175);
            finchRobot.wait(300);
            finchRobot.setLED(255, 54, 179); //reddish pink
            finchRobot.noteOn(1109);
            finchRobot.wait(300);
            //second staff
            finchRobot.setMotors(70, 70);
            finchRobot.setLED(115, 239, 200); //blue seafoam
            finchRobot.noteOn(1319);
            finchRobot.wait(300);
            finchRobot.setLED(234, 54, 179); //pink
            finchRobot.noteOn(1175);
            finchRobot.wait(300);
            finchRobot.setLED(115, 239, 159); //seafoam
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.setLED(255, 54, 179); //reddish pink
            finchRobot.noteOn(1047);
            finchRobot.wait(300);
            //final two
            finchRobot.setMotors(150, 0);
            finchRobot.setLED(255, 255, 255); //white
            finchRobot.noteOn(880);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.wait(250);
            finchRobot.setLED(100, 100, 100); //gray
            finchRobot.setMotors(0, 150);
            finchRobot.noteOn(659);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.setMotors(0, 0);
            finchRobot.wait(250);
            finchRobot.setLED(0, 255, 0);
            //off
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(0, 0);
            DisplayMenuPrompt("Talent Show Menu");
        }
        static void TalentShowDisplayMotors(Finch finchRobot)
        {
            Console.CursorVisible = false;
            DisplayScreenHeader("A Talent Show for Dance");
            DisplayContinuePrompt();
            Console.WriteLine("\tThe Finch will now show off its moves.");

            finchRobot.setMotors(100, 40);
            finchRobot.wait(1000);
            finchRobot.setMotors(-100, -40);
            finchRobot.wait(1000);
            finchRobot.setMotors(100, 100);
            finchRobot.wait(500);
            finchRobot.setMotors(-100, -100);
            finchRobot.wait(500);
            finchRobot.setMotors(0, 0);

            TalentShowDisplayMotorsRepeat(finchRobot);

            DisplayMenuPrompt("Talent Show Menu");

        }

        static void TalentShowDisplayMotorsRepeat(Finch finchRobot)
        {
            bool validResponse;

            do
            {
                validResponse = true;
                string userResponse;
                int repeatMotors;

                Console.WriteLine("\tThat was short! How many times would you like to repeat it?");
                Console.Write("\t0 is an option! ");
                userResponse = Console.ReadLine();

                if (!int.TryParse(userResponse, out repeatMotors))
                {
                    validResponse = false;

                    Console.WriteLine("\tPlease give me a real number.");
                    DisplayContinuePrompt();
                }

                else if (repeatMotors >= 0)
                {
                    validResponse = true;

                    Console.WriteLine("\tAlright! I'll repeat it {0} times.", repeatMotors);

                    for (int i = 0; i < repeatMotors; i++)
                    {
                        finchRobot.setMotors(100, 40);
                        finchRobot.wait(1000);
                        finchRobot.setMotors(-100, -40);
                        finchRobot.wait(1000);
                        finchRobot.setMotors(100, 100);
                        finchRobot.wait(500);
                        finchRobot.setMotors(-100, -100);
                        finchRobot.wait(500);
                        finchRobot.setMotors(0, 0);
                    }
                }
            } while (!validResponse);
        }
        #endregion

        #region DATA RECORDER

        /// <summary>
        /// *****************************************************************
        /// *                     Data Recorder Menu                          *
        /// *****************************************************************
        /// </summary>

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            DisplayScreenHeader("Data Recorder Menu");
            Console.WriteLine("\tThis module is currently under development.");
            DisplayContinuePrompt();
        }
        #endregion

        #region ALARM SYSTEM

        /// <summary>
        /// *****************************************************************
        /// *                     Alarm System Menu                          *
        /// *****************************************************************
        /// </summary>

        static void AlarmSystemDisplayMenuScreen(Finch finchRobot)
        {
            DisplayScreenHeader("Alarm System Menu");
            Console.WriteLine("\tThis module is currently under development.");
            DisplayContinuePrompt();
        }
        #endregion

        #region User Programming

        /// <summary>
        /// *****************************************************************
        /// *                     User Programming Menu                          *
        /// *****************************************************************
        /// </summary>

        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            DisplayScreenHeader("User Programming Menu");
            Console.WriteLine("\tThis module is currently under development.");
            DisplayContinuePrompt();
        }
        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnected.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            do
            {
                robotConnected = true;

                Console.WriteLine();
                Console.WriteLine("\tTesting lights, sounds, movement...");

                if (robotConnected == true)
                { 
                    for (int i = 0; i < 250; i += 50)
                    {
                        finchRobot.setLED(100 + i, 100 + i, 0 + i);
                        finchRobot.noteOn(680 + i);
                        finchRobot.setMotors(70 + (i / 2), 70 + (i / 2));
                        finchRobot.wait(500);
                        finchRobot.setLED(0, 0, 0);
                        finchRobot.noteOff();
                        finchRobot.setMotors(0, 0);
                    }
                }
                else // if (robotConnected == false)
                {
                    robotConnected = false;

                    Console.WriteLine("\tCannot connect to the Finch Robot. Please check the connection and try again.");
                    DisplayContinuePrompt();
                }

            } while (!robotConnected);

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //

            return robotConnected; 
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName}.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
