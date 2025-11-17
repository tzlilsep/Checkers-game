using System;
using System.Drawing;
using System.Windows.Forms;
using DamkaLogic;
using DamkaUI.Properties;

namespace DamkaUI
{
    public partial class DamkaForm : Form
    {
        private readonly int r_BoardSize;
        private Game m_Game;
        private (int X, int Y)? m_LastClickedCell = null;
        public event Action<int, int> BoardCellClicked;
        public event Action ComputerLabelClicked;

        public DamkaForm(int i_BoardSize, Game i_Game)
        {
            r_BoardSize = i_BoardSize;
            m_Game = i_Game;
            InitializeComponent();
            createBoard();
            m_Game.TurnSwitched += game_TurnSwitched;
            m_Game.AITurn += game_AITurn;
            m_Game.Board.MoveMade += board_MoveMade;
            m_Game.Board.PieceBecameKing += board_PieceBecameKing;
            labelsPlayers[m_Game.CurrentTurnPlayerIndex].BackColor = Color.CornflowerBlue;
        }

        void labelPlayer2_Click(object sender, EventArgs e)
        {
            OnComputerLabelClicked();
            enableWhiteCells();
        }

        void game_TurnSwitched(int i_CurrentPlayerTurn)
        {
            labelsPlayers[1 - i_CurrentPlayerTurn].BackColor = Color.Transparent;
            labelsPlayers[i_CurrentPlayerTurn].BackColor = Color.CornflowerBlue;
        }

        void board_PieceBecameKing(int i_Row, int i_Col)
        {
            m_BoardButtons[i_Row, i_Col].BackgroundImage = getImageBasedOnPiece(i_Row, i_Col);
        }

        void game_AITurn()
        {
            labelsPlayers[1].Enabled = true;
            disableAllCells();
        }

        public void ChangeTotalScores()
        {
            for (int i = 0; i < m_Game.Players.Length; i++)
            {
                labelsPlayersTotalScore[i].Text = m_Game.Players[i].TotalScore.ToString();
            }
        }

        void button_Click(object sender, EventArgs e)
        {
            Button buttonClicked = sender as Button;

            int row = (buttonClicked.Top - 60) / 50;
            int col = (buttonClicked.Left - (this.ClientSize.Width - r_BoardSize * 50) / 2) / 50;

            OnBoardCellClicked(row, col);
        }

        public void ClearPressedButtons(Move i_Move)
        {
            int sourceRow = i_Move.SourceRow;
            int sourceColumn = i_Move.SourceColumn;
            int destinationRow = i_Move.DestinationRow;
            int destinationColumn = i_Move.DestinationColumn;

            m_BoardButtons[sourceRow, sourceColumn].BackColor = Color.White;
            m_BoardButtons[destinationRow, destinationColumn].BackColor = Color.White;
        }

        protected virtual void OnBoardCellClicked(int i_Row, int i_Col)
        {
            BoardCellClicked?.Invoke(i_Row, i_Col);
        }

        protected virtual void OnComputerLabelClicked()
        {
            ComputerLabelClicked?.Invoke();
        }

        void board_MoveMade(Move i_MoveMade)
        {
            int sourceRow = i_MoveMade.SourceRow;
            int sourceColumn = i_MoveMade.SourceColumn;
            int destinationRow = i_MoveMade.DestinationRow;
            int destinationColumn = i_MoveMade.DestinationColumn;

            if (i_MoveMade.IsCapture)
            {
                int middleRow = (sourceRow + destinationRow) / 2;
                int middleCol = (sourceColumn + destinationColumn) / 2;

                m_BoardButtons[middleRow, middleCol].BackgroundImage = null;
            }

            ClearPressedButtons(i_MoveMade);
            m_BoardButtons[sourceRow, sourceColumn].BackgroundImage = null;
            m_BoardButtons[destinationRow, destinationColumn].BackgroundImage = getImageBasedOnPiece(sourceRow, sourceColumn);
        }

        public void ResetBoard()
        {
            foreach (Button button in m_BoardButtons)
            {
                this.Controls.Remove(button);
            }

            createBoard();
            labelsPlayers[m_Game.CurrentTurnPlayerIndex].BackColor = Color.CornflowerBlue;
            labelsPlayers[1 - m_Game.CurrentTurnPlayerIndex].BackColor = Color.Transparent;
        }

        private void enableWhiteCells()
        {
            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    if ((row + col) % 2 != 0)
                    {
                        m_BoardButtons[row, col].Enabled = true;
                    }
                }
            }
        }

        private Image getImageBasedOnPiece(int i_X, int i_Y)
        {
            char pieceSymbol = m_Game.Board.GetPieceAt(i_X, i_Y).Symbol;
            Image image = null;

            if (pieceSymbol == 'X')
            {
                image = Properties.Resources.white;
            }
            else if (pieceSymbol == 'O')
            {
                image = Properties.Resources.black;
            }
            else if (pieceSymbol == 'K')
            {
                image = Properties.Resources.whiteKing;
            }
            else if (pieceSymbol == 'U')
            {
                image = Properties.Resources.blackKing;
            }

            return image;
        }

        public void disableAllCells() 
        {
            foreach (Button button in m_BoardButtons)
            {
                button.Enabled = false;
            }
        }

        public void HighlightButton(int i_X, int i_Y, Color i_Color)
        {
            if (m_BoardButtons != null && i_X >= 0 && i_X < r_BoardSize && i_Y >= 0 && i_Y < r_BoardSize)
            {
                m_BoardButtons[i_X, i_Y].BackColor = i_Color;
            }
        }

        private void createBoard()
        {
            m_BoardButtons = new Button[r_BoardSize, r_BoardSize];
            int cellSize = 50;
            int boardWidth = r_BoardSize * cellSize;
            int startX = (this.ClientSize.Width - boardWidth) / 2;
            int startY = 60;

            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    Button cell = new Button
                    {
                        Size = new Size(cellSize, cellSize),
                        Location = new Point(startX + col * cellSize, startY + row * cellSize),
                        BackColor = (row + col) % 2 == 0 ? Color.Gray : Color.White,
                        Enabled = (row + col) % 2 != 0,
                        FlatStyle = FlatStyle.Flat
                    };

                    cell.Click += button_Click;

                    if (row < (r_BoardSize / 2) - 1 && (row + col) % 2 != 0)
                    {
                        cell.BackgroundImage = Properties.Resources.black;
                    }
                    else if (row > (r_BoardSize / 2) && (row + col) % 2 != 0)
                    {
                        cell.BackgroundImage = Properties.Resources.white;
                    }
                    else
                    {
                        cell.BackgroundImage = null;
                    }

                    cell.BackgroundImageLayout = ImageLayout.Stretch;
                    m_BoardButtons[row, col] = cell;
                    this.Controls.Add(cell);
                }
            }

            m_LastClickedCell = null;
        }

        public (int X, int Y)? LastClickedCell
        {
            get
            {
                return m_LastClickedCell;
            }
            set
            {
                m_LastClickedCell = value;
            }
        }
    }
}
