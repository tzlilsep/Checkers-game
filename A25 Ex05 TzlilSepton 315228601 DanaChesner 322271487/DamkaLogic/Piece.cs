namespace DamkaLogic
{
    public class Piece
    {
        private bool m_IsKing;
        private char m_Symbol;
        private readonly Player r_Owner;
        private eMovementDirection m_MovementDirection;

        public Piece(char i_Symbol, Player i_Owner)
        {
            m_Symbol = i_Symbol;
            r_Owner = i_Owner;
            m_IsKing = false;
            m_MovementDirection = i_Symbol == 'X' ? eMovementDirection.Backward : eMovementDirection.Forward;
        }

        public enum eMovementDirection
        {
            Forward,
            Backward,
            Both,
        }

        public Player Owner
        {
            get
            {
                return r_Owner;
            }
        }

        public char Symbol
        {
            get
            {
                return m_Symbol;
            }
        }

        public bool IsKing
        {
            get
            {
                return m_IsKing;
            }
            set
            {
                if (m_IsKing != value)
                {
                    m_IsKing = value;
                    m_Symbol = m_Symbol == 'X' ? 'K' : 'U';
                    m_MovementDirection = eMovementDirection.Both;
                }
            }
        }

        public eMovementDirection MovementDirection
        {
            get
            {
                return m_MovementDirection;
            }
        }
    }
}