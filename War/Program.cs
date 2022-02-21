using System;
using System.Collections.Generic;

namespace War
{
    class Program
    {
        #region INPUT
        const int c_n = 26;
        public static string[] c_cardp1 = { "6H", "7H", "6C", "QS", "7S", "8D", "6D", "5S", "6S", "QH", "4D", "3S", "7C", "3C", "4S", "5H", "QD", "5C", "3H", "3D", "8C", "4H", "4C", "QC", "5D", "7D" };
        const int c_m = 26;
        public static string[] c_cardp2 = { "JH", "AH", "KD", "AD", "9C", "2D", "2H", "JC", "10C", "KC", "10D", "JS", "JD", "9D", "9S", "KS", "AS", "KH", "10S", "8S", "2S", "10H", "8H", "AC", "2C", "9H" };
        #endregion

        public static string[] CardsPoints = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public static List<string> cardp1List = new List<string>();
        public static List<string> cardp2List = new List<string>();

        static void Main(string[] args)
        {
            int n = c_n; // int.Parse(Console.ReadLine()); // the number of cards for player 1
            for (int i = 0; i < n; i++)
            {
                string cardp1 = c_cardp1[i]; // Console.ReadLine(); // the n cards of player 1
                if (cardp1.Length == 3)
                {
                    cardp1List.Add(cardp1.Substring(0, 2));
                }
                else
                {
                    cardp1List.Add(cardp1.Substring(0, 1));
                }
            }

            int m = c_m; // int.Parse(Console.ReadLine()); // the number of cards for player 2
            for (int i = 0; i < m; i++)
            {
                string cardp2 = c_cardp2[i]; // Console.ReadLine(); // the m cards of player 2
                if (cardp2.Length == 3)
                {
                    cardp2List.Add(cardp2.Substring(0, 2));
                }
                else
                {
                    cardp2List.Add(cardp2.Substring(0, 1));
                }
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            int NumRound = 0;
            bool EndGame = false;
            string WinerBattle;
            int p1Wins = 0;
            int p2Wins = 0;

            List<string> tmpCardp1List = new List<string>();
            List<string> tmpCardp2List = new List<string>();

            while (!EndGame)
            {
                NumRound++;
                WinerBattle = GetWinBattle(cardp1List[0], cardp2List[0]);
                if (WinerBattle.Equals("P1"))
                {
                    p1Wins++;

                    tmpCardp1List.Add(cardp1List[0]);
                    cardp1List.RemoveAt(0);
                    UpdateCardList(ref cardp1List, tmpCardp1List);

                    tmpCardp2List.Add(cardp2List[0]);
                    cardp2List.RemoveAt(0);
                    UpdateCardList(ref cardp1List, tmpCardp2List);
                }
                else if (WinerBattle.Equals("P2"))
                {
                    p2Wins++;

                    tmpCardp2List.Add(cardp2List[0]);
                    cardp2List.RemoveAt(0);
                    UpdateCardList(ref cardp2List, tmpCardp2List);

                    tmpCardp1List.Add(cardp1List[0]);
                    cardp1List.RemoveAt(0);
                    UpdateCardList(ref cardp2List, tmpCardp1List);
                }
                else
                {
                    //War
                    NumRound--;
                    for (int i=0; i<4; i++)
                    {
                        tmpCardp1List.Add(cardp1List[0]);
                        cardp1List.RemoveAt(0);

                        tmpCardp2List.Add(cardp2List[0]);
                        cardp2List.RemoveAt(0);
                    }
                }
                n = cardp1List.Count;
                m = cardp2List.Count;
                EndGame = (n == 0 || m == 0);
            }

            string output = p1Wins > p2Wins ? "1" : "2";
            Console.WriteLine(output + " " + NumRound);
        }

        private static void UpdateCardList(ref List<string> cardList, List<string> tmpCardList)
        {
            foreach (string card in tmpCardList)
            {
                cardList.Add(card);
            }
            tmpCardList.Clear();
        }

        private static string GetWinBattle(string c1, string c2)
        {
            int pointP1 = 0;
            int pointP2 = 0;
            for (int i = 0; i < CardsPoints.Length; i++)
            {
                if (CardsPoints[i].Equals(c1))
                {
                    pointP1 = i;
                }
                if (CardsPoints[i].Equals(c2))
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
    }
}
