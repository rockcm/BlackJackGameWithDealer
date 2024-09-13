using Project2;


        Deck deck = new Deck();
        deck.Shuffle();

        List<Card> playerHand = new List<Card>();
        List<Card> computerHand = new List<Card>();

        // deal two cards to player and computer
        playerHand.Add(deck.DealACard());
        playerHand.Add(deck.DealACard());
        computerHand.Add(deck.DealACard()); // dealer's first card (hidden)
        computerHand.Add(deck.DealACard()); // dealer's second card (visible)

        // Display player's hand and hand value
        Console.WriteLine("Player's Hand:");
        foreach (Card card in playerHand)
        {
            Console.WriteLine(card);
        }
        int playerValue = Rank.CalculateHandValue(playerHand);
        Console.WriteLine($"Player's Hand Value: {playerValue}");

        // display one dealer card
        Console.WriteLine("\nDealer's Hand:");
        Console.WriteLine(computerHand[1]); // show only the first card
        Console.WriteLine("Hidden card"); // hide the second card

        // player's turn
        string action = "";
        while (playerValue < 21 && action.ToLower() != "stand")
        {
            Console.WriteLine("\nDo you want to 'hit' or 'stand'?");
            action = Console.ReadLine();

            if (action.ToLower() == "hit")
            {
                playerHand.Add(deck.DealACard());
                playerValue = Rank.CalculateHandValue(playerHand);

                // display updated player's hand and hand value
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
                return;
            }
        }

        // dealer's turn
        Console.WriteLine("\nRevealing Dealer's Hand:");
        foreach (Card card in computerHand)
        {
            Console.WriteLine(card);
        }
        int computerValue = Rank.CalculateHandValue(computerHand);
        Console.WriteLine($"Dealer's Hand Value: {computerValue}");

        // dealer must "hit" until hand value is 17 or higher
        while (computerValue < 17)
        {
            Console.WriteLine("\nDealer hits.");
            computerHand.Add(deck.DealACard());
            computerValue = Rank.CalculateHandValue(computerHand);

            // Display updated dealer's hand and hand value
            Console.WriteLine("\nDealer's Updated Hand:");
            foreach (Card card in computerHand)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine($"Dealer's Hand Value: {computerValue}");
        }

        // determine the outcome
        if (computerValue > 21)
        {
            Console.WriteLine("\nDealer Busted! You win!");
        }
        else if (computerValue > playerValue)
        {
            Console.WriteLine("\nDealer wins!");
        }
        else if (computerValue == playerValue)
        {
            Console.WriteLine("\nPush");
        }
        else
        {
            Console.WriteLine("\nYou win!");
        }
