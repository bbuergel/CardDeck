namespace PokerDeck;

public enum Suit {
    Hearts,
    Spades,
    Diamonds,
    Clubs
}

public enum Rank {
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13,
    Ace = 14
}

public class Card {
    public Suit suit;
    public Rank rank;
    public int position;
    public Card(Suit suit, Rank rank, int position){
        this.suit = suit;
        this.rank = rank;
        this.position = position;
    }
}

public class Deck {
    public List<Card> cards;
    
    // construct the deck
    public Deck() {
        this.cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
            foreach (Rank rank in Enum.GetValues(typeof(Rank))){
                Card card = new Card(suit, rank, 0);
                this.cards.Add(card);
            }
        } 
    }

    // shuffle
    public void shuffle() {
        Random num = new Random();
        List<Card> shuffled = new List<Card>();
        foreach (Card card in this.cards){
            card.position = num.Next(0, 52);
            shuffled.Add(card);
        }
        shuffled.Sort(delegate(Card a, Card b){
            return a.position.CompareTo(b.position);
        });
        this.cards = shuffled;
    }

    // deal one card. If empty, return null
    public Card? deal_one_card() { 
        if(this.cards.Count > 0){
            Card drawnCard = this.cards[0];
            this.cards.RemoveAt(0);
            return drawnCard;
        }
        else{
            return null;
        }
    }
}
