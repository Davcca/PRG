using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random(); //instance tridy Random pro generovani nahodnych cisel
            int PCpick = 0;
            int USRpick = 0;
            int PCpoints = 0;
            int USRpoints = 0;
            string userInput = "";
            Console.WriteLine("napiš kámen, nůžky, papír a začni hrát\nhru ukončíš slovem konec");


            while (true)
            {
                userInput = Console.ReadLine();
                if (userInput == "konec")
                {
                    break;
                }
                if (userInput == "kámen")
                {
                    USRpick = 0;
                }
                if (userInput == "nůžky")
                {
                    USRpick = 1;
                }
                if (userInput == "papír")
                {
                    USRpick = 2;
                }

                PCpick = rng.Next(3);
                if (PCpick == USRpick)
                {
                    Console.WriteLine("Remíza");
                }
                if (PCpick == 0)
                {
                    if (USRpick == 1)
                    {
                        PCpoints++;
                        Console.WriteLine("Prohrál jsi, počítač zvolil kámen\n" + "Počítač má " + PCpoints + " bodů" + "  Ty máš " + USRpoints + " bodů");
                    }
                    if (USRpick == 2)
                    {
                        USRpoints++;
                        Console.WriteLine("Vyhárl jsi, počítač zvolil kámen\n" + "Počítač má " + PCpoints + " bodů" + "  Ty máš " + USRpoints + " bodů");
                    }

                }

                else if (PCpick == 1)
                {
                    if (USRpick == 2)
                    {
                        PCpoints++;
                        Console.WriteLine("Prohrál jsi, počítač zvolil nůžky\n" + "Počítač má " + PCpoints + " bodů" + "  Ty máš " + USRpoints + " bodů");
                    }
                    if (USRpick == 0)
                    {
                        USRpoints++;
                        Console.WriteLine("Vyhrál jsi, počítač zvolil nůžky\n" + "Počítač má " + PCpoints + " bodů" + "  Ty máš " + USRpoints + " bodů");
                    }

                }

                else if (PCpick == 2)
                {
                    if (USRpick == 0)
                    {
                        PCpoints++;
                        Console.WriteLine("Prohrál jsi, počítač zvolil papír\n" + "Počítač má " + PCpoints + " bodů" + "  Ty máš " + USRpoints + " bodů");
                    }
                    if (USRpick == 1)
                    {
                        USRpoints++;
                        Console.WriteLine("Vyhrál jsi, počítač zvolil papír\n" + "Počítač má " + PCpoints + " bodů" + "  Ty máš " + USRpoints + " bodů");
                    }

                }
                }

                    Console.WriteLine("Konec hry");
                    Console.ReadKey();
        }





                    /*
                  * Jednoduchy program na procviceni podminek a cyklu.
                  * 
                  * Vytvor program, kde bude uzivatel hrat s pocitacem kamen-nuzky-papir.
                  * 
                  * Struktura:
                  * 
                  * - nadefinuj promenne, ktere budes potrebovat po celou dobu hry, tedy skore obou
                  *
                  * Opakuj tolikrat, kolik kol chces hrat:
                  * {
                  *      Dokud uzivatel nezada vstup spravne:
                  *      {
                  *          - nacitej vstup od uzivatele
                  *      }
                  *      
                  *      - vygeneruj s pomoci rng.Next() nahodny vstup pocitace
                  *      
                  *      Pokud vyhral uzivatel:
                  *      {
                  *          - informuj uzivatele, ze vyhral kolo
                  *          - zvys skore uzivateli o 1
                  *      }
                  *      Pokud vyhral pocitac:
                  *      {
                  *          - informuj uzivatele, ze prohral kolo
                  *          - zvys skore pocitaci o 1
                  *      }
                  *      Pokud byla remiza:
                  *      {
                  *          - informuj uzivatele, ze doslo k remize
                  *      }
                  * }
                  * 
                  * - informuj uzivatele, jake mel skore on/a a pocitac a kdo vyhral.
                  */

                    //instance tridy Random pro generovani nahodnych cisel



                     //Aby se nam to hnedka neukoncilo
                }
            }
        
