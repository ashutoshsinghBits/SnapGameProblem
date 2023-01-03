using SnapProblem.Enum;
using System;

namespace SnapProblem
{
    class Deck
    {
		/// <summary>
		/// Cards in each deck
		/// </summary>
		const int CARDS_IN_EACH_DECK = 52;

		/// <summary>
		/// Cards collection based on the number of decks
		/// </summary>
		private readonly Card[] _cards;

		/// <summary>
		/// Top of the card
		/// </summary>
		private int _topCard;

		/// <summary>
		/// Required number of decks
		/// </summary>
		private readonly int _requiredNoOfDeck;

		/// <summary>
		/// Indicates how many Cards remain in the Deck.
		/// </summary>
		public int CardsRemaining
		{
			get
			{
				return (_requiredNoOfDeck * CARDS_IN_EACH_DECK) - _topCard;
			}
		}

		/// <summary>
		/// Creates Deck with Cards. The first card will be the top of the Deck.
		/// </summary>
		public Deck(int numberOfDeck)
		{
			_requiredNoOfDeck = numberOfDeck;
			_cards = new Card[CARDS_IN_EACH_DECK * numberOfDeck];

			int i = 0;
			for (int deckCounter = 0; deckCounter < numberOfDeck; deckCounter++)
			{
				for (Suit s = Suit.CLUB; s <= Suit.SPADE; s++)
				{
					for (Rank r = Rank.ACE; r <= Rank.KING; r++)
					{
						Card c = new Card(r, s);
						_cards[i] = c;
						i++;
					}
				}
			}
			_topCard = 0;
			Shuffle();
		}

		/// <summary>
		/// Returns all of the cards to the Deck, and shuffles their order.
		/// </summary>
		private void Shuffle()
		{
			var random = new Random();
			random.Shuffle(_cards);
		}

		/// <summary>
		/// Takes a card from the top of the Deck.It will return null when there are no cards remaining in the Deck.
		/// </summary>
		public Card Draw()
		{
			if (_topCard < (_requiredNoOfDeck * CARDS_IN_EACH_DECK))
			{
				Card result = _cards[_topCard];
				_topCard++;
				return result;
			}
			else
			{
				return null;
			}

		}
	}

}
