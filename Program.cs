using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber;
            int totalScore = 0;
            int turn = 0;
            int turnScore = 0;
            while (totalScore < 20)
            {
                Console.WriteLine("========================");
                turn++;
                Console.WriteLine($"Turn {turn} :");
                randomNumber = random.Next(1, 7);
                turnScore = randomNumber;
                if (randomNumber == 1)
                {
                    ScoreOne(turn, randomNumber, ref totalScore);
                    continue;
                }
                InitiateGame(randomNumber, ref turnScore, ref totalScore, turn, random);
            }
            Console.WriteLine($"============**************************============\n" +
                $"You Win ! You finished in {turn} turns .\n" +
                $"Thank you for playing ! your total score is : {totalScore}");

        }
        //For Roll Action
        static void Roll(ref int totalScore, ref int turnScore, int randomNumber, int turn,
            Random random)
        {
            randomNumber = random.Next(1, 7);
            turnScore = turnScore + randomNumber;
            if (randomNumber == 1)
            {
                ScoreOne(turn, randomNumber, ref totalScore);
                return;
            }
            Console.WriteLine();
            InitiateGame(randomNumber, ref turnScore, ref totalScore, turn, random);
            return;
        }
        //For Hold action
        static void Hold(ref int totalScore, ref int turnScore, int randomNumber)
        {
            totalScore = totalScore + turnScore;
            Console.WriteLine($"\n Your turn Score : {turnScore}\n" +
                $"Your total score : {totalScore}");
            turnScore = 0;
        }
        //For 1 on the Dice
        static void ScoreOne(int turn, int randomNumber, ref int totalScore)
        {
            Console.WriteLine($"\n Score on Dice : {randomNumber}\n" +
                $"Your turn Score : 0\n" + $"Your total score : {totalScore}\n" +
                $"========================");
        }
        //To Initiate the Game
        static void InitiateGame(int randomNumber, ref int turnScore, ref int totalScore, int turn, Random random)
        {
            Console.WriteLine($"Score on Dice : {randomNumber}");
            Console.WriteLine($"Turn Score : {turnScore} ");
            Console.Write($"Do you want to roll or hold ? (roll(r)/hold(h)) : ");
            String userWise = Console.ReadLine().ToLower();
            if (userWise == "r")
                Roll(ref totalScore, ref turnScore, randomNumber, turn, random);
            else if (userWise == "h")
                Hold(ref totalScore, ref turnScore, randomNumber);

        }

    }
}
