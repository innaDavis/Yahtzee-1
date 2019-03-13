using System;
using System.Collections.Generic;

namespace Yahtzee
{
    class Program
    {
        static void Main(string[] args)
        {

            //Print the winner with the tie going to the player.

            Console.WriteLine("Players's Turn");
            int playersRound = playersTurn(); //call the method to start players turn

            Console.WriteLine(); // Put blank line of space to make it look nicer

            Console.WriteLine("Computer's Turn");
            int computerRound = computersTurn();//call the method to start computers turn
            Console.WriteLine($"The computer's best score was: {computerRound}."); // print the returned computer score to console


            Console.WriteLine(); // Put blank line of space to make it look nicer

            //Print if the player or computer won
            if (playersRound >= computerRound)
            {
                Console.WriteLine("Player Won!");
            }
            else
            {
                Console.WriteLine("Computer Won! Better luck next time.");
            }

            Console.ReadLine();

        }

        // players turn method: 
        public static int playersTurn()
        {
            //place holder variables to initialize using list
            var finalDiceSetToScore = new List<int>();
            int scoreOfAllRolls = 0; 

            //first roll of 5 dice
            int[] firstRoll = rollDice(5);// call rollDice method with 5 dice
            Console.WriteLine("[{0}]", string.Join(", ", firstRoll)); //print random dice values

            Console.WriteLine("Enter a number for the dice that you want to keep. Enter 0 for none.");
            int diceNumberRound1 = int.Parse(Console.ReadLine());

            int diceInRoll2 = diceSelection(firstRoll, diceNumberRound1); // call the method that lets player make a selection  
            int firstScore = 5 - diceInRoll2; //calculate the score 5 total dice minus dice saved

            // add the dice the user kept to the finalDiceSetToScore List
            for (int i = 0; i < firstScore; i++)
            {
                finalDiceSetToScore.Add(diceNumberRound1);
            }

            Console.WriteLine($"Your first rounds score is: {firstScore}");
            Console.WriteLine($"The number of dice you can still roll is: {diceInRoll2}");

            Console.WriteLine(); // Put blank line of space to make it look nicer

            //second roll 
            int[] secondRoll = rollDice(diceInRoll2);// call rollDice method with the number of dice not kept in round 1
            Console.WriteLine("[{0}]", string.Join(", ", secondRoll)); //print random dice values

            Console.WriteLine("Enter a number for the dice that you want to keep. Enter 0 for none.");
            int diceNumberRound2 = int.Parse(Console.ReadLine());

            int diceInRoll3 = diceSelection(secondRoll, diceNumberRound2); // call the method that lets player make a selection  

            int secondScore = diceInRoll2 - diceInRoll3;

            // add the dice the user kept to the finalDiceSetToScore List
            for (int i = 0; i < secondScore; i++)
            {
                finalDiceSetToScore.Add(diceNumberRound2);
            }

            Console.WriteLine($"Your second rounds score is: {secondScore}");
            Console.WriteLine($"The number of dice you can still roll is: {diceInRoll3}");

            Console.WriteLine(); // Put blank line of space to make it look nicer

            //third roll
            int[] thirdRoll = rollDice(diceInRoll3);// call rollDice method with the number of dice not kept in round 2

            Console.WriteLine("Your third roll is...");
            Console.WriteLine("[{0}]", string.Join(", ", thirdRoll)); //print random dice values

            Console.WriteLine(); // Put blank line of space to make it look nicer

            // add the dice the user kept to the finalDiceSetToScore List
            for (int i = 0; i < thirdRoll.Length; i++)
            {
                finalDiceSetToScore.Add(thirdRoll[i]);
            }

            //score the finalDiceSetToScore by sending it to the scoreDice method
            scoreOfAllRolls = scoreDice(finalDiceSetToScore.ToArray());

            Console.WriteLine("Your final set of dice is...");
            Console.WriteLine("[{0}]", string.Join(", ", finalDiceSetToScore)); //print random dice values

            Console.WriteLine($"Your final score is : {scoreOfAllRolls}");
            
            return scoreOfAllRolls;
        }


        public static int diceSelection(int[] diceRoll, int diceFaceToKeep)
        {
            int totalNumberOfDice = diceRoll.Length; //count the total number of dice in the diceRoll array

            if (totalNumberOfDice < 0)
            {
                return 0;
            }

            //loop through each dice in the array to see if it matches the number the user wants to keep (diceFaceToKeep)
            foreach (var dice in diceRoll)
            {
                if (dice.Equals(diceFaceToKeep))
                {
                    totalNumberOfDice = totalNumberOfDice - 1; //if matched, the user wants to keep that dice. Subtract that di from the total available for next roll
                }
            }

            return totalNumberOfDice;
        }

        // Method to generate random dice rolls. Takes number of dice to roll as parameter. 
        public static int[] rollDice(int numberOfDiceToRoll)
        { 
            // initialize int array with a total number of dice to roll based on the numberOfDiceToRoll that was passed in
            int[] diceValue = new int[numberOfDiceToRoll];

            // for loop that goes from 0 to the numberOfDice you want rolled
            for (int i = 0; i < numberOfDiceToRoll; i++)
            {
                Random rnd = new Random();
                int single = rnd.Next(1, 7); //store the random number for each dice roll 
                diceValue[i] = single; // and set that random number to the int array index
            }

            // return the int array of dice
            return diceValue;
        }



        // method to count & score the computer
        public static int scoreDice(int[] computersDiceRoll)
        {
            int thisRoundsScore = 0;//initialize a place holder for the score

            //create an int array that stores a count of the number each dice
            // there are 6 faces to a di, so diceFaceCount[0] would be the 1 face
            // diceFaceCount[5] would be the 6 face
            int[] diceFaceCount = new int[6] {0,0,0,0,0,0};

            // for loop that goes from 0 to the numberOfDice you want rolled
            for (int i = 0; i < computersDiceRoll.Length; i++)
            { 
                //if-else statements to tally up the occurance of dice
                if(computersDiceRoll[i] == 1)
                {
                    // count the total number of dice that are a value of 1. 
                    diceFaceCount[0] = diceFaceCount[0] + 1;
                }
                else if (computersDiceRoll[i] == 2)
                {
                    diceFaceCount[1] = diceFaceCount[1] + 1;
                }
                else if (computersDiceRoll[i] == 3)
                {
                    diceFaceCount[2] = diceFaceCount[2] + 1;
                }
                else if (computersDiceRoll[i] == 4)
                {
                    diceFaceCount[3] = diceFaceCount[3] + 1;
                }
                else if (computersDiceRoll[i] == 5)
                {
                    diceFaceCount[4] = diceFaceCount[4] + 1;
                }
                else
                {
                    diceFaceCount[5] = diceFaceCount[5] + 1;
                }
            }

            foreach (var count in diceFaceCount)
            {
                if (count > thisRoundsScore)
                {
                    thisRoundsScore = count;
                }
                    
            }

            // return the score 
            return thisRoundsScore;
        }


        // method to call computer's turn
        public static int computersTurn()
        {
            int bestRoundScore = 0; //initialize BestRoundScore 

            int[] firstRoll = rollDice(5);// call rollDice method with 5 dice
            Console.WriteLine("[{0}]", string.Join(", ", firstRoll)); //print random dice values
            int firstScore = scoreDice(firstRoll);//call the computerScore method on the dice values
            Console.WriteLine("Your Score is: " + firstScore);// print the computers score the first round

            int[] secondRoll = rollDice(5);
            Console.WriteLine("[{0}]", string.Join(", ", secondRoll));
            int secondScore = scoreDice(secondRoll);
            Console.WriteLine("Your Score is: " + secondScore);

            int[] thirdRoll = rollDice(5);
            Console.WriteLine("[{0}]", string.Join(", ", thirdRoll));
            int thirdScore = scoreDice(thirdRoll);
            Console.WriteLine("Your Score is: " + thirdScore);

            if(firstScore > secondScore && firstScore > thirdScore )
            {
                bestRoundScore = firstScore;
            }
            else if(secondScore > firstScore && secondScore > thirdScore)
            {
                bestRoundScore = secondScore;
            }
            else
            {
                bestRoundScore = thirdScore;
            }

            return bestRoundScore;
        }

    }
}
