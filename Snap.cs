using SnapProblem.Enum;
using System.Collections.Generic;

namespace SnapProblem
{
    public class Snap
	{
		// Last two cards for match
		private readonly Card[] _topCards = new Card[2];

		// Object of deck.
		private readonly Deck _deck;

		/// <summary>
		/// Collection of cards that need to be assigned to the winner who will say SNAP first
		/// </summary>
		private List<Card> _lstCard = new List<Card>();

		/// <summary>
		/// Create a new game of Snap!
		/// </summary>
		public Snap(int numberOfDeck)
		{
			_deck = new Deck(numberOfDeck);
		}

		/// <summary>
		/// Gets the card on the top of the "flip" stack. This card will be face up.
		/// </summary>
		public Card TopCard
		{
			get
			{
				return _topCards[1];
			}
		}

		/// <summary>
		/// Indicates if there are cards remaining in Deck.
		/// The game is over when there are no cards remaining.
		/// </summary>
		public bool IsCardsRemain
		{
			get { return _deck.CardsRemaining > 0; }
		}

		/// <summary>
		/// Return card collection to assign the player who told SNAP first
		/// </summary>
		public List<Card> GetCardCollection
        {
            get
            {
				return _lstCard;
            }
        }

		/// <summary>
		/// Reset this collection as , as on every SNAP this should be filled with fresh cards
		/// </summary>
		public void ResetCardColletion()
        {
			_lstCard = new List<Card>();
        }

		public void FlipNextCard()
		{
			if (_deck.CardsRemaining > 0)           
			{
				_lstCard.Add(_topCards[0]);		// Add old card to the collection
				_topCards[0] = _topCards[1];         
				_topCards[1] = _deck.Draw();    // get a new top card
				_topCards[1].Show();            // show card
			}
		}

		/// <summary>
		/// Match criteria check
		/// </summary>
		/// <param name="matchCriteria"></param>
		/// <returns></returns>
		public bool IsCardMatchedWithCriteria(MatchCriteria matchCriteria)
        {
			bool flag = false;
			if (_topCards[0] != null)
			{
				if (matchCriteria == MatchCriteria.RANK && _topCards[0].Rank == _topCards[1].Rank)
					flag = true;
				else if (matchCriteria == MatchCriteria.SUIT && _topCards[0].Suit == _topCards[1].Suit)
					flag = true;
				else if(matchCriteria == MatchCriteria.RANKANDSUIT && _topCards[0].Rank == _topCards[1].Rank && _topCards[0].Suit == _topCards[1].Suit)
					flag = true;
			}

			return flag;
		}
	}
}
