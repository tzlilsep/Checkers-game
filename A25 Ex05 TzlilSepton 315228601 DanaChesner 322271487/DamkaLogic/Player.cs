using System;
using System.Collections.Generic;

namespace DamkaLogic
{
    public class Player
    {
        private readonly string r_Name;
        private readonly char r_Symbol;
        private int m_Score = 0;
        private int m_TotalScore = 0;
        private int m_NumberOfPiecesLeft;
        private readonly bool r_IsAi;
        private Random m_Random = new Random();

        public Player(string i_Name, char i_Symbol, bool i_IsAi)
        {
            r_Name = i_Name;
            r_Symbol = i_Symbol;
            r_IsAi = i_IsAi;
        }

        public bool IsAi
        {
            get
            {
                return r_IsAi;
            }
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public char Symbol
        {
            get
            {
                return r_Symbol;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        public int TotalScore
        {
            get
            {
                return m_TotalScore;
            }
            set
            {
                m_TotalScore = value;
            }
        }

        public int NumberOfPiecesLeft
        {
            get
            {
                return m_NumberOfPiecesLeft;
            }
            set
            {
                m_NumberOfPiecesLeft = value;
            }
        }

        public bool LostGame()
        {
            return m_NumberOfPiecesLeft == 0;
        }

        public Move GetRandomMove(Board i_Board)
        {
            List<Move> possibleMoves = i_Board.GetAllPossibleMoves(this);
            Move randomMove = null;

            if (possibleMoves.Count > 0)
            {
                int randomIndex = m_Random.Next(possibleMoves.Count);

                randomMove = possibleMoves[randomIndex];
            }

            return randomMove;
        }
    }
}