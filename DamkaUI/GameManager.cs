using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DamkaLogic;

namespace DamkaUI
{
    public class GameManager
    {
        private Game m_Game;
        private Move m_CurrentMove;
        private DamkaForm m_DamkaGame;

        public void RunCheckersGame()
        {
            m_Game = configureGame();
            if (m_Game != null)
            {
                initDamkaForm();
                StartGame();
            }
        }

        private void initDamkaForm()
        {
            m_DamkaGame = new DamkaForm(m_Game.Board.Size, m_Game);
            m_DamkaGame.BoardCellClicked += damkaGame_CellClicked;
            m_DamkaGame.ComputerLabelClicked += damkaGame_ComputerLabelClicked;
            m_DamkaGame.FormClosing += damkaGame_FormClosing;
        }

        private Game configureGame()
        {
            Game game = null;
            GameSettings gameSettings = new GameSettings();

            gameSettings.ShowDialog();
            if (gameSettings.ClosedByDone)
            {
                string player1Name = gameSettings.Player1Name;
                string player2Name = gameSettings.Player2Name;
                int boardSize = gameSettings.BoardSize;
                bool isPlayer2Computer = gameSettings.IsPlayer2Computer;
                const bool v_IsPlayer1Computer = false;
                Player player1 = new Player(player1Name, 'X', v_IsPlayer1Computer);
                Player player2 = new Player(player2Name, 'O', isPlayer2Computer);
                Player[] players = { player1, player2 };

                game = new Game(new Board(boardSize, players), players);
            }

            return game;            
        }

        public void StartGame()
        {
            m_DamkaGame.ShowDialog();
        }

        void damkaGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = Display.ShowUserQuitDialog();

            if (result == DialogResult.Yes)
            {
                e.Cancel = true; // Cancel closing
                handleQuit();
                startNewRound();
            }
            else if (result == DialogResult.No)
            {
                m_DamkaGame.FormClosing -= damkaGame_FormClosing;
                m_DamkaGame.Close();
            }
            else
            {
                e.Cancel = true; // Cancel closing
            }
        }

        private void handleQuit()
        {
            int winnerIndex = m_Game.Players[1].IsAi ? 1 : 1 - m_Game.CurrentTurnPlayerIndex;
            
            m_Game.SetWinnerAndCalculateTotalScores(winnerIndex); 
            m_DamkaGame.ChangeTotalScores();
        }

        void damkaGame_CellClicked(int i_XClicked, int i_YClicked)
        {
            if (m_DamkaGame.LastClickedCell == null)
            {
                handleFirstClick(i_XClicked, i_YClicked);
            }
            else
            {
                handleSecondClick(i_XClicked, i_YClicked);
            }
        }

        private void handleFirstClick(int i_XClicked, int i_YClicked)
        {
            Player currentPlayer = m_Game.GetCurrentPlayersTurn();
            Piece clickedPiece = m_Game.Board.GetPieceAt(i_XClicked, i_YClicked);

            if (clickedPiece == null || clickedPiece.Owner != currentPlayer)
            {
                Display.ShowErrorMessageDialog("Invalid choice, You can only select your own pieces!");
            }
            else
            {
                m_DamkaGame.LastClickedCell = (i_XClicked, i_YClicked);
                m_DamkaGame.HighlightButton(i_XClicked, i_YClicked, Color.CornflowerBlue);
            }
        }

        private void handleSecondClick(int i_XClicked, int i_YClicked)
        {
            var source = m_DamkaGame.LastClickedCell.Value;

            if (source.X == i_XClicked && source.Y == i_YClicked)
            {
                m_DamkaGame.HighlightButton(source.X, source.Y, Color.White);
                m_DamkaGame.LastClickedCell = null;
            }
            else
            {
                List<Move> possibleMoves = m_Game.Board.GetAllPossibleMoves(m_Game.GetCurrentPlayersTurn());
                // Check if the selected move is valid
                Move selectedMove = possibleMoves.FirstOrDefault(m =>
                    m.SourceRow == source.X &&
                    m.SourceColumn == source.Y &&
                    m.DestinationRow == i_XClicked &&
                    m.DestinationColumn == i_YClicked);

                if (selectedMove != null)
                {
                    bool gameOver = m_Game.MakeMove(selectedMove);
                    checkIfGameOverAndHandle(gameOver);
                }
                else
                {
                    Display.ShowErrorMessageDialog("Invalid move!");
                }

                m_DamkaGame.HighlightButton(source.X, source.Y, Color.White);
                m_DamkaGame.LastClickedCell = null;
            }
        }

        void damkaGame_ComputerLabelClicked()
        {
            Player currentPlayersTurn = m_Game.GetCurrentPlayersTurn();

            while (currentPlayersTurn.IsAi) 
            {
                m_CurrentMove = currentPlayersTurn.GetRandomMove(m_Game.Board);
                m_CurrentMove.InputString = convertMoveToString(m_CurrentMove);

                bool gameOver = m_Game.MakeMove(m_CurrentMove);

                if (gameOver) 
                {
                    checkIfGameOverAndHandle(gameOver);
                    break;
                }

                currentPlayersTurn = m_Game.GetCurrentPlayersTurn();
                if (!currentPlayersTurn.IsAi)
                {
                    break; 
                }
            }
        }

        private void checkIfGameOverAndHandle(bool i_IsGameOver)
        {
            if (i_IsGameOver)
            {
                endOrStartAnotherRound();
            }
        }

        private void endOrStartAnotherRound()
        {
            DialogResult result;
            string announcement = m_Game.RoundWinner == null ? "Tie!" : $"{m_Game.RoundWinner.Name} Won!";

            m_DamkaGame.ChangeTotalScores();
            result = Display.ShowRoundOverDialog(announcement);
            if (result == DialogResult.Yes)
            {
                startNewRound();
            }
            else
            {
                m_DamkaGame.FormClosing -= damkaGame_FormClosing;
                m_DamkaGame.Close();
            }
        }

        private void startNewRound()
        {
            m_Game.StartNewRound();
            m_CurrentMove = null;
            m_DamkaGame.ResetBoard();
        }

        private string convertMoveToString(Move i_Move)
        {
            char sourceRow = (char)(i_Move.SourceRow + 'A');
            char sourceColumn = (char)(i_Move.SourceColumn + 'a');
            char destinationRow = (char)(i_Move.DestinationRow + 'A');
            char destinationColumn = (char)(i_Move.DestinationColumn + 'a');

            return $"{sourceRow}{sourceColumn}>{destinationRow}{destinationColumn}";
        }
    }
}