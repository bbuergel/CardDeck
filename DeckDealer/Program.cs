using PokerDeck;

Boolean cardsLeft = true;

Deck deck = new Deck();
deck.shuffle();

while(cardsLeft){
    Console.WriteLine("Press space to draw a card: ");
    Console.ReadKey();
    Card? drawnCard = deck.deal_one_card();
    if(drawnCard != null){
        Console.WriteLine($"{drawnCard.rank} of {drawnCard.suit}");
    }
    else{
        Console.WriteLine("The deck is empty!");
        cardsLeft = false;
    }
}