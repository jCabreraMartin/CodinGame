using System;
using System.Collections;
using System.Collections.Generic;

namespace War
{
    class Program
    {
        #region INPUT
        //const int c_n = 26;
        //public static string[] c_cardp1 = { "6H", "7H", "6C", "QS", "7S", "8D", "6D", "5S", "6S", "QH", "4D", "3S", "7C", "3C", "4S", "5H", "QD", "5C", "3H", "3D", "8C", "4H", "4C", "QC", "5D", "7D" };
        //const int c_m = 26;
        //public static string[] c_cardp2 = { "JH", "AH", "KD", "AD", "9C", "2D", "2H", "JC", "10C", "KC", "10D", "JS", "JD", "9D", "9S", "KS", "AS", "KH", "10S", "8S", "2S", "10H", "8H", "AC", "2C", "9H" };

        const int c_n = 26;
        public static string[] c_cardp1 = { "5S", "8D", "10H", "9S", "4S", "6H", "QC", "6C", "6D", "9H", "2C", "7S", "AC", "5C", "7D", "9D", "QS", "4D", "3C", "JS", "2D", "KD", "10S", "QD", "3H", "8H" };
        const int c_m = 26;
        public static string[] c_cardp2 = { "4C", "JC", "8S", "10C", "5H", "7H", "3D", "AH", "KS", "10D", "JH", "6S", "2S", "KC", "8C", "9C", "KH", "3S", "AD", "JD", "4H", "7C", "2H", "QH", "5D", "AS" };
        #endregion

        public static string[] CardsPoints = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public static Queue cardp1List = new Queue();
        public static Queue cardp2List = new Queue();

        public static List<string> listTmpP1 = new List<string>();
        public static List<string> listTmpP2 = new List<string>();

        static void Main(string[] args)
        {
            int n = c_n; // int.Parse(Console.ReadLine()); // the number of cards for player 1
            for (int i = 0; i < n; i++)
            {
                string cardp1 = c_cardp1[i]; // Console.ReadLine(); // the n cards of player 1
                saveCardList(cardp1, "player1");
            }

            int m = c_m; // int.Parse(Console.ReadLine()); // the number of cards for player 2
            for (int i = 0; i < m; i++)
            {
                string cardp2 = c_cardp2[i]; // Console.ReadLine(); // the m cards of player 2
                saveCardList(cardp2, "player2");
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            int NumRound = 0;
            bool EndGame = false;
            string WinerBattle = string.Empty;

            while (!EndGame)
            {
                NumRound++;
                string cardP1 = cardp1List.Dequeue().ToString();
                string cardP2 = cardp2List.Dequeue().ToString();

                WinerBattle = GetWinBattle(cardP1, cardP2);

                if (WinerBattle.Equals("PAT"))
                {
                    //War
                    NumRound--;
                    listTmpP1.Add(cardP1);
                    listTmpP2.Add(cardP2);

                    for (int i = 0; i < 3; i++)
                    {
                        if (cardp1List.Count > 0)
                        {
                            cardP1 = cardp1List.Dequeue().ToString();
                            listTmpP1.Add(cardP1);
                        }
                        else
                        {
                            break;
                        }
                        if (cardp2List.Count > 0)
                        { 
                            cardP2 = cardp2List.Dequeue().ToString();
                            listTmpP2.Add(cardP2);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (WinerBattle.Equals("P1"))
                {
                    listTmpP1.Add(cardP1);
                    listTmpP2.Add(cardP2);
                    WarWin("L1", "P1");
                    WarWin("L2", "P1");
                }
                else if (WinerBattle.Equals("P2"))
                {
                    listTmpP1.Add(cardP1);
                    listTmpP2.Add(cardP2);
                    WarWin("L1", "P2");
                    WarWin("L2", "P2");
                }

                n = cardp1List.Count;
                m = cardp2List.Count;
                EndGame = (n == 0 || m == 0);
            }

            string output = string.Empty;
            if (WinerBattle.Equals("PAT"))
            {
                output = "PAT";              
            }
            else
            {
                output = (m == 0) ? "1" : "2";
                output += " " + NumRound;
            }

            Console.WriteLine(output);
        }

        private static void WarWin(string tmpList, string playerWin)
        {
            if (tmpList.Equals("L1"))
            {
                foreach (string card in listTmpP1)
                {
                    if (playerWin.Equals("P1"))
                        cardp1List.Enqueue(card);
                    else
                        cardp2List.Enqueue(card); 
                }
                listTmpP1.Clear();
            }
            else if (tmpList.Equals("L2"))
            {
                foreach (string card in listTmpP2)
                {
                    if (playerWin.Equals("P1"))
                        cardp1List.Enqueue(card);
                    else
                        cardp2List.Enqueue(card);
                }
                listTmpP2.Clear();
            }
        }

        private static string GetWinBattle(string dequeue1, string dequeue2)
        {
            int pointP1 = 0;
            int pointP2 = 0;
            for (int i = 0; i < CardsPoints.Length; i++)
            {
                if (CardsPoints[i].Equals(dequeue1))
                {
                    pointP1 = i;
                }
                if (CardsPoints[i].Equals(dequeue2))
                {
                    pointP2 = i;
                }
            }

            if (pointP1 > pointP2)
            {
                return "P1";
            }
            else if (pointP2 > pointP1)
            {
                return "P2";
            }
            else
            {
                return "PAT";
            }
        }

        private static void saveCardList(string card, string player)
        {
            if (player.Equals("player1"))
            {
                if (card.Length == 3)
                {
                    cardp1List.Enqueue(card.Substring(0, 2));
                }
                else
                {
                    cardp1List.Enqueue(card.Substring(0, 1));
                }
            }
            else if (player.Equals("player2"))
            {
                if (card.Length == 3)
                {
                    cardp2List.Enqueue(card.Substring(0, 2));
                }
                else
                {
                    cardp2List.Enqueue(card.Substring(0, 1));
                }
            }
        }
    }
}
