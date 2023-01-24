using System;
using System.Linq; // need Linq for the Where method

namespace PickAUniqueCardBlazor
{
    public class CardPicker
    {
        static Random random = new Random();
        static string[] cards = new string[52];

        static CardPicker()
        {
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };
            int cardCounter = 0;

            for (int cardVal = 1; cardVal <= 13; cardVal++)
            {
                foreach (string cardSuit in suits)
                {
                    string cardName;
                    switch (cardVal)
                    {
                        case 1:
                            cardName = "Ace";
                            break;
                        case 11:
                            cardName = "Jack";
                            break;
                        case 12:
                            cardName = "Queen";
                            break;
                        case 13:
                            cardName = "King";
                            break;
                        default:
                            cardName = cardVal.ToString();
                            break;
                    }
                            
                    cards[cardCounter] = cardName + " of " + cardSuit;
                    cardCounter++;
                }
            }

            // This just tests that we are getting all of our cards
            for (var i = 0; i < 52; i++)
            {
                Console.WriteLine(cards[i]);
            }

        }
        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];
            for (int i = 0; i < numberOfCards; i++)
            {
                // pickedCards[i] = RandomValue() + " of " + RandomSuit();
                pickedCards[i] = RandomCard();
            }
            return pickedCards;
        }

        private static string RandomSuit()
        {
            int value = random.Next(1, 5);
            if (value == 1) return "Spades";
            if (value == 2) return "Hearts";
            if (value == 3) return "Clubs";
            return "Diamonds";
        }

        private static string RandomValue()
        {
            int value = random.Next(1, 14);
            if (value == 1) return "Ace";
            if (value == 11) return "Jack";
            if (value == 12) return "Queen";
            if (value == 13) return "King";
            return value.ToString();
        }

        private static string RandomCard()
        {
            int cardNum = random.Next(0, cards.Length);
            string picked = cards[cardNum];
            cards = cards.Where(e => e != picked).ToArray();
            return picked;
        }
    }
}
