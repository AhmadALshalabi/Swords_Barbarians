using System;

bool isRunning = true;
bool isPlaying = true;

int initialized = 20;

int TotalAIDamage = 0;
int TotalPlayerDamage = 0;

var PlayerAttackAttempt = 0;
var AIAttackAttempt = 0;
var NormalAttack = 1;

var userName = " ";
var checkInput = " ";
int Choosing = 0;


Random Random = new Random();
var PlayermoreDamage = Random.Next(0, 3);
var AImoreDamage = Random.Next(0, 3);
var autoAttack = Random.Next(1, 2);

while (isRunning)
{
    Console.WriteLine("Welcome to the Battle");
    Console.WriteLine("Do you want to play? (Y/N)");
    var playing = Console.ReadKey(true).KeyChar;
    if (playing == 'y')
    {
        Console.Clear();
        Console.Write("Provide your name in order to decorate your grave stone ^_^ > ");
        userName = Console.ReadLine();
        Console.Clear();
        isPlaying = true;
    }
    else
    {
        Console.WriteLine("\nCoward ^_^");
        Console.ReadKey(true);
        isRunning = false;
        isPlaying = false;  
    }

    while (isPlaying)
    {
        int player = initialized - TotalPlayerDamage;
        int ai = initialized - TotalAIDamage;
        Console.WriteLine(string.Format("{0, -6} (HP: {1}) {4, -15} {2,-3} (HP: {3})\n", userName, player, "AI", ai, ""));
        Console.WriteLine(string.Format("Its {0, -2} turn! {2 , 15} {0, -2} last attack {1, -3}", userName, Choosing, ""));

        if (TotalPlayerDamage == initialized)
        {
            Console.Clear();
            Console.WriteLine("Game over {0}, AI won!", userName);
            Console.ReadKey(true);
            isPlaying = false;
        }
        else if (TotalAIDamage == initialized)
        {
            Console.Clear();
            Console.WriteLine("Game over AI, {0}  won!", userName);
            Console.ReadKey(true);
            isPlaying = false;
        }
        else
        {
            bool playerBool = true;
            while (playerBool)
            {
                if (PlayerAttackAttempt == AIAttackAttempt) // Player Turn
                {
                    Console.WriteLine($"\nPlease {userName} Choose between different Attacks:\n");
                    Console.WriteLine("1. Normal Attack");
                    Console.WriteLine("2. Big Attack");
                    Console.WriteLine("=================\n");

                    checkInput = Console.ReadLine();

                    Console.Clear();
                    if (!string.IsNullOrEmpty(checkInput))
                    {
                        Console.WriteLine(string.Format("{0, -6} (HP: {1}) {4, -15} {2,-3} (HP: {3})\n", userName, player, "AI", ai, ""));
                        Console.WriteLine(string.Format("Its {0, -2} turn! {2 , 15} {0, -2} last attack {1, -3}", userName, Choosing, ""));
                        Choosing = Convert.ToInt32(checkInput);
                        if (Choosing == 1)
                        {
                            TotalAIDamage += NormalAttack;
                            PlayerAttackAttempt++;
                            playerBool = false;

                        }
                        else if (Choosing == 2 && PlayerAttackAttempt > 0)
                        {
                            //Deal more damage but it's not guaranteed
                            TotalAIDamage += PlayermoreDamage;
                            PlayerAttackAttempt++;
                            playerBool = false;
                        }
                        else
                        {
                            Console.WriteLine("\nYOU ARE NOT ALLOWED TO INTILIZE BIG ATTACK BEFORE NORMAL ONE!");
                            Console.ReadKey(true);
                            Console.Clear();
                        }  
                    }
                }
            }
        }

        if (autoAttack > 0) // AI turn
        {
            Console.Clear();
            Console.WriteLine(string.Format("{0, -6} (HP: {1}) {4, -15} {2,-3} (HP: {3})\n", userName, player, "AI", ai, ""));
            Console.WriteLine(string.Format("Its {0, -2} turn! {2 , 15} {0, -2} last attack {1, -3}", "AI", autoAttack, ""));
            Console.WriteLine("\nAI Auto Normal Attack");
            Console.WriteLine("AI Auto Big Attack");
            Console.WriteLine("\n*** AI will Choose one of the listed Attacks, (Press enter to procced)");

            if (PlayerAttackAttempt > AIAttackAttempt)
            {
                if (autoAttack == 1)
                {
                    TotalPlayerDamage += NormalAttack;
                    AIAttackAttempt++;
                }
                else if (autoAttack == 2 && AIAttackAttempt > 0)
                {
                    //Deal more damage but it's not guaranteed               
                    TotalPlayerDamage += AImoreDamage;
                    Console.WriteLine($"AI Big attack damaged {userName}");
                    AIAttackAttempt++;
                }

                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}





