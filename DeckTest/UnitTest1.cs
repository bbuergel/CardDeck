namespace DeckTest;
using PokerDeck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class DeckUnitTests
{
    // Deck should contain 52 cards when constructed
    [TestMethod]
    public void TestDeckConstructor()
    {
        Deck deck = new Deck();
        int numberOfCards = deck.cards.Count;
        Assert.AreEqual(numberOfCards, 52);
    }

    // Deck order should be random when shuffled, first card should not be 2 of hearts
    [TestMethod]
    public void TestDeckShuffle()
    {
        Deck deck = new Deck();
        deck.shuffle();
        // if by chance 2 of hearts is the first card, keep shuffling
        while(deck.cards[0].suit == Suit.Hearts && deck.cards[0].rank == Rank.Two){
            deck.shuffle();
        }
        bool sameCard = deck.cards[0].suit == Suit.Hearts && deck.cards[0].rank == Rank.Two;
        Assert.IsFalse(sameCard);
    }

    // Fresh deck should deal Two of Hearts on first call and Three of Hearts on second
    [TestMethod]
    public void TestDealOneCard()
    {
        Deck deck = new Deck();
        Card? firstCard = deck.deal_one_card();
        Card? secondCard = deck.deal_one_card();
        bool isFirstCardTwoOfHearts = firstCard?.suit == Suit.Hearts && firstCard.rank == Rank.Two;
        bool isSecondCardThreeOfHearts = secondCard?.suit == Suit.Hearts && secondCard.rank == Rank.Three;
        Assert.IsTrue(isFirstCardTwoOfHearts);
        Assert.IsTrue(isSecondCardThreeOfHearts);
    }

    // Deck should not deal a card when there are no cards left
    [TestMethod]
    public void TestDealNoCardWhenEmpty()
    {
        Deck deck = new Deck();
        deck.cards.Clear();
        Card? nonCard = deck.deal_one_card();
        Assert.IsNull(nonCard);
    }
}