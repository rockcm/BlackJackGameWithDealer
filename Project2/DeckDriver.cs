////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Lab2
// File Name: DeckDriver.cs
// Description: Ceates a Card
// Course: CSCI 1260 – Introduction to Computer Science II
// Author: Christian Rock
// Created: 08/31/22
// Copyright: Christian Rock, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////


using Project2;

Deck deck;
List<Card> playerHand;
List<Card> computerHand;
string playAgain = "Y";  // Initialize to enter the loop

while (playAgain == "Y" || playAgain == "YES")  // Loop as long as the user enters "Y" or "YES"
{
    deck = new Deck();
    deck.Shuffle();
    Console.Clear();
    playerHand = new List<Card>();
    computerHand = new List<Card>();

    // Deal two cards to player and computer
    playerHand.Add(deck.DealACard());
    playerHand.Add(deck.DealACard());
    computerHand.Add(deck.DealACard()); // Dealer's first card (visible)
    computerHand.Add(deck.DealACard()); // Dealer's second card (hidden)

    // Display player's hand and hand value
    Console.WriteLine("Player's Hand:");
    foreach (Card card in playerHand)
    {
        Console.WriteLine(card);
    }
    int playerValue = Rank.CalculateHandValue(playerHand);
    Console.WriteLine($"Player's Hand Value: {playerValue}");

    // Display dealer's first card and hide the second card
    Console.WriteLine("\nDealer's Hand:");
    Console.WriteLine(computerHand[0]); // Show only the first card
    Console.WriteLine("Hidden card"); // Hide the second card

    // Player's turn
    string action = "";
    while (playerValue < 21 && action.ToLower() != "stand")
    {
        Console.WriteLine("\nDo you want to 'hit' or 'stand'?");
        action = Console.ReadLine().ToLower();

        if (action == "hit")
        {
            playerHand.Add(deck.DealACard());
            playerValue = Rank.CalculateHandValue(playerHand);

            // Display updated player's hand and hand value
            Console.WriteLine("\nPlayer's Updated Hand:");
            foreach (Card card in playerHand)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine($"Player's Hand Value: {playerValue}");
        }

        if (playerValue > 21)
        {
            Console.WriteLine("\nPlayer Busted! You lose.");
            break;
        }
    }

    if (playerValue <= 21)  // Dealer's turn if player didn't bust
    {
        // Reveal the hidden dealer's card
        Console.WriteLine("\nRevealing Dealer's Hand:");
        foreach (Card card in computerHand)
        {
            Console.WriteLine(card);
        }
        int dealerValue = Rank.CalculateHandValue(computerHand);
        Console.WriteLine($"Dealer's Hand Value: {dealerValue}");

        // Dealer must "hit" until hand value is 17 or higher
        while (dealerValue < 17)
        {
            Console.WriteLine("\nDealer hits.");
            computerHand.Add(deck.DealACard());
            dealerValue = Rank.CalculateHandValue(computerHand);

            // Display updated dealer's hand and hand value
            Console.WriteLine("\nDealer's Updated Hand:");
            foreach (Card card in computerHand)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine($"Dealer's Hand Value: {dealerValue}");
        }

        // Determine the outcome
        if (dealerValue > 21)
        {
            Console.WriteLine("\nDealer Busted! You win!");
        }
        else if (dealerValue > playerValue)
        {
            Console.WriteLine("\nDealer wins!");
        }
        else if (dealerValue == playerValue)
        {
            Console.WriteLine("\nIt's a push (tie)!");
        }
        else
        {
            Console.WriteLine("\nYou win!");
        }
    }

    // Ask to play again
    do
    {
        Console.WriteLine("\nDo you want to play again? (Y/N)");
        playAgain = Console.ReadLine().ToUpper().Trim();  // Accept input and convert to uppercase
        if (playAgain != "Y" && playAgain != "N")
        {
            Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
        }
    } while (playAgain != "Y" && playAgain != "N");
}

Console.WriteLine("Thanks for playing!");