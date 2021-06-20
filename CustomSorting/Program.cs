using System;

namespace CustomSorting
{

    class Card
    {
        public string suit;
        public string value;

        public Card(string suitInput, string valueInput)
        {
            suit = suitInput;
            value = valueInput;
        }

        // assigns the cards simple, sort-able numbers 
        //  x100 by suit
        //  x1 by value so numeric values can't collide
        public int NumericValue()
        {
            int sum = 0;
            switch(suit){
                case "Hearts":
                    sum += 100;
                    break;
                case "Diamonds":
                    sum += 200;
                    break;
                case "Clubs":
                    sum += 300;
                    break;
                case "Spades":
                    sum += 400;
                    break;
            }
            switch(value){
                case "2":
                    sum += 2;
                    break;
                case "3":
                    sum += 3;
                    break;
                case "4":
                    sum += 4;
                    break;
                case "5":
                    sum += 5;
                    break;
                case "6":
                    sum += 6;
                    break;
                case "7":
                    sum += 7;
                    break;
                case "8":
                    sum += 8;
                    break;
                case "9":
                    sum += 9;
                    break;
                case "Jack":
                    sum += 10;
                    break;
                case "Queen":
                    sum += 11;
                    break;
                case "King":
                    sum += 12;
                    break;
                case "Ace":
                    sum += 13;
                    break;
            }
            return sum;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Card[] deck = new Card[48];
            InitDeck(deck);
            ShuffleDeck(deck);
            SortDeck(deck, false);
            PrintDeck(deck);
            
        }

        // uses bubble sort algorithm with Card.NumericValue()
        //  I chose bubble sort here because it was easy to 
        //  add the sort direction flag and there's a small 
        //  and known number of elements
        public static void SortDeck(Card[] deck, bool asc)
        {
            int n = deck.Length;
            for (int i = 0; i < n - 1; i++){
                for (int j = 0; j < n - 1 - i; j++){
                    if (asc){
                        if (deck[j].NumericValue() > deck[j+1].NumericValue()){
                            Card buffer = deck[j];
                            deck[j] = deck[j+1];
                            deck[j+1] = buffer;
                        }
                    } else {
                        if (deck[j].NumericValue() < deck[j+1].NumericValue()){
                            Card buffer = deck[j];
                            deck[j] = deck[j+1];
                            deck[j+1] = buffer;
                        }
                    }
                }
            }
        }

        // iterates over the card types to generate a Card[] array (deck)
        static void InitDeck(Card[] deck)
        {
            string[] suits = {"Hearts", "Diamonds", "Clubs", "Spades"};
            string[] values = {"2", "3", "4", "5", "6", "7", "8", "9", "Jack", "Queen", "King", "Ace"};
            int i = 0;
            foreach (string suit in suits){
                foreach (string value in values){
                    deck[i++] = new Card(suit, value);
                }
            }
        }

        // places the cards in a random order to be sorted
        static Random random = new Random();
        public static void ShuffleDeck(Card[] deck)
        {
            int len = deck.Length;
            for (int i = 0; i < len; i++)
            {
                int rand = i + random.Next(len - i);
                Card card = deck[rand];
                deck[rand] = deck[i];
                deck[i] = card;
            }
        }

        public static void PrintDeck(Card[] deck)
        {
            foreach (Card card in deck){
                Console.WriteLine(card.value + " of " + card.suit);
            }
        }
    }
}
