using System;

namespace DamkaLogic
{
    public class Game
    {
        private Board m_Board;
        private Player[] m_Players;
        private int m_CurrentTurnPlayerIndex = 0;
        private bool m_IsPlaying;
        private Player m_RoundWinner = null;
        public event Action<int> TurnSwitched;
        public event Action AITurn;

        public Game(Board i_Board, Player[] i_Players)
        {
            m_Board = i_Board;
            m_Players = i_Players;
            m_IsPlaying = true;
            updateNumberOfPiecesLeftForPlayers();
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }
        }

        public Player[] Players
        {
            get
            {
                return m_Players;
            }
        }

        public int CurrentTurnPlayerIndex
        {
            get
            {
                return m_CurrentTurnPlayerIndex;
            }
        }

        public Player RoundWinner
        {
            get
            {
                return m_RoundWinner;
            }
        }

        public bool MakeMove(Move i_Move)
        {
            bool turnSwitchNeeded = true;

            if (i_Move != null)
            {
                m_Board.MakeMove(i_Move, GetCurrentPlayersOpponent());
                if (i_Move.IsCapture)
                {
                    Piece movedPiece = m_Board.GetPieceAt(i_Move.DestinationRow, i_Move.DestinationColumn);
                    if (m_Board.HasCaptureMovesForPiece(movedPiece, i_Move.DestinationRow, i_Move.DestinationColumn))
                    {
                        turnSwitchNeeded = false;
                    }
                }

                if (turnSwitchNeeded)
                {
                    switchTurn();
                }
                else if (GetCurrentPlayersTurn().IsAi)
                {
                    OnAITurn();
                }
            }

            return checkIfRoundOverAndHandle();
        }

        private void updateNumberOfPiecesLeftForPlayers()
        {
            int rowsPerSide = m_Board.Size == 10 ? 4 : m_Board.Size == 8 ? 3 : 2;
            foreach (Player player in m_Players)
            {
                player.NumberOfPiecesLeft = rowsPerSide * (m_Board.Size / 2);
            }
        }

        public Player GetCurrentPlayersTurn()
        {
            return m_Players[m_CurrentTurnPlayerIndex];
        }

        public Player GetCurrentPlayersOpponent()
        {
            return m_Players[1 - m_CurrentTurnPlayerIndex];
        }

        public void StartNewRound()
        {
            m_IsPlaying = true;
            m_Board.ClearBoard();
            m_Board.InitializeBoard(m_Players);
            m_CurrentTurnPlayerIndex = 0;
            m_RoundWinner = null;
            updateNumberOfPiecesLeftForPlayers();
        }

        private void switchTurn()
        {
            m_CurrentTurnPlayerIndex = 1 - m_CurrentTurnPlayerIndex;
            OnTurnSwitched();
            if (m_Players[m_CurrentTurnPlayerIndex].IsAi)
            {
                OnAITurn();
            }
        }

        protected virtual void OnTurnSwitched()
        {
            TurnSwitched?.Invoke(m_CurrentTurnPlayerIndex);
        }

        protected virtual void OnAITurn()
        {
            AITurn?.Invoke();
        }

        private bool checkIfRoundOverAndHandle()
        {
            bool gameOver = true;
            Player currentPlayer = GetCurrentPlayersTurn();
            Player otherPlayer = GetCurrentPlayersOpponent();
            int otherPlayerIndex = 1 - CurrentTurnPlayerIndex;
            bool noMovesForCurrentPlayer = !m_Board.HasLegalMoves(currentPlayer);
            bool noMovesForOtherPlayer = !m_Board.HasLegalMoves(otherPlayer);

            if (noMovesForCurrentPlayer && noMovesForOtherPlayer)
            {
                calculateScores();
                if (currentPlayer.Score > otherPlayer.Score)
                {
                    SetWinnerAndCalculateTotalScores(CurrentTurnPlayerIndex);
                }
                else if (currentPlayer.Score < otherPlayer.Score)
                {

                    SetWinnerAndCalculateTotalScores(otherPlayerIndex);
                }
            }
            else if (noMovesForCurrentPlayer)
            {
                SetWinnerAndCalculateTotalScores(otherPlayerIndex);
            }
            else if (currentPlayer.LostGame())
            {
                SetWinnerAndCalculateTotalScores(otherPlayerIndex);
            }
            else if (otherPlayer.LostGame())
            {
                SetWinnerAndCalculateTotalScores(CurrentTurnPlayerIndex);
            }
            else if (m_IsPlaying)
            {
                gameOver = false;
            }

            return gameOver;
        }

        public void SetWinnerAndCalculateTotalScores(int i_winnerIndex)
        {
            m_RoundWinner = m_Players[i_winnerIndex];
            int loser = 1 - i_winnerIndex;
            calculateScores();
            int scoreDifference = Math.Abs(m_Players[i_winnerIndex].Score - m_Players[loser].Score);
            m_Players[i_winnerIndex].TotalScore += scoreDifference;
        }

        private void calculateScores()
        {
            m_Players[0].Score = 0;
            m_Players[1].Score = 0;
            for (int row = 0; row < m_Board.Size; row++)
            {
                for (int col = 0; col < m_Board.Size; col++)
                {
                    Piece piece = m_Board.Grid[row, col];
                    if (piece != null)
                    {
                        int scoreIncrement = piece.IsKing ? 4 : 1;
                        piece.Owner.Score += scoreIncrement;
                    }
                }
            }
        }
    }
}
