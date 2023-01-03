using SnapProblem.Enum;

namespace SnapProblem
{
    public class Card
    {
        private readonly Rank _rank;
        private readonly Suit _suit;
        private bool _faceUp;

        public Card(Rank r, Suit s)
        {
            _rank = r;
            _suit = s;
            _faceUp = false;
        }

        /// <summary>
        /// Get rank
        /// </summary>
        public Rank Rank
        {
            get { return _rank; }
        }

        /// <summary>
        /// Get suit
        /// </summary>
        public Suit Suit
        {
            get { return _suit; }
        }

        /// <summary>
        /// Allows you to check if the card is fact up, or face down.
        /// </summary>
        public bool FaceUp
        {
            get { return _faceUp; }
        }

        /// <summary>
        ///  This is for showing the card. As of now it's not much use. 
        ///  Later, for further enhancement this property could be useful
        /// </summary>
        public void Show()
        {
            _faceUp = !_faceUp;
        }

        public override string ToString()
        {
            return $" Rank : {_rank}, Suit: {_suit}, FaceUp: {_faceUp}";
        }
    }
}
