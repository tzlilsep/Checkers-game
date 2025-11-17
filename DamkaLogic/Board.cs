using System;
using System.Collections.Generic;

namespace DamkaLogic
{
    public class Board
    {
        private Piece[,] m_Grid;
        private readonly int r_Size;
        public event Action<Move> MoveMade;
        public event Action<int, int> PieceBecameKing;

        public Board(int i_Size, Player[] i_Players)
        {
            r_Size = i_Size;
            m_Grid = new Piece[i_Size, i_Size];
            InitializeBoard(i_Players);
        }

        public void InitializeBoard(Player[] i_Players)
        {
            int rowsPerSide = r_Size == 10 ? 4 : r_Size == 8 ? 3 : 2;
            for (int row = 0; row < rowsPerSide; row++)
            {
                for (int col = 0; col < r_Size; col++)
                {
                    if ((row + col) % 2 != 0)
                    {
                        m_Grid[row, col] = new Piece(i_Players[1].Symbol, i_Players[1]);
                    }
                }
            }

            for (int row = r_Size - rowsPerSide; row < r_Size; row++)
            {
                for (int col = 0; col < r_Size; col++)
                {
                    if ((row + col) % 2 != 0)
                    {
                        m_Grid[row, col] = new Piece(i_Players[0].Symbol, i_Players[0]);
                    }
                }
            }
        }

        public void ClearBoard()
        {
            for (int row = 0; row < r_Size; row++)
            {
                for (int col = 0; col < r_Size; col++)
                {
                    m_Grid[row, col] = null;
                }
            }
        }

        public Piece[,] Grid
        {
            get
            {
                return m_Grid;
            }
        }

        public int Size
        {
            get
            {
                return r_Size;
            }
        }

        public Piece GetPieceAt(int i_row, int i_col)
        {
            return m_Grid[i_row, i_col];
        }

        //Assuming the move is valid
        public void MakeMove(Move i_Move, Player i_OpponnentPlayer)
        {
            if (i_Move.IsCapture)
            {
                handleCapture(i_Move, i_OpponnentPlayer);
            }

            OnMoveMade(i_Move);

            m_Grid[i_Move.DestinationRow, i_Move.DestinationColumn] = m_Grid[i_Move.SourceRow, i_Move.SourceColumn];
            m_Grid[i_Move.SourceRow, i_Move.SourceColumn] = null;
            Piece movedPiece = m_Grid[i_Move.DestinationRow, i_Move.DestinationColumn];
            if (movedPiece != null && isLastRow(i_Move.DestinationRow))
            {
                movedPiece.IsKing = true;
                OnPieceBecameKing(i_Move.DestinationRow, i_Move.DestinationColumn);
            }
        }

        protected virtual void OnMoveMade(Move i_MoveMade)
        {
            MoveMade?.Invoke(i_MoveMade);
        }

        
        protected virtual void OnPieceBecameKing(int i_Row, int i_Col)
        {
            PieceBecameKing?.Invoke(i_Row, i_Col);
        }

        private void handleCapture(Move i_Move, Player io_OpponnentPlayer)
        {
            int middleRow = (i_Move.SourceRow + i_Move.DestinationRow) / 2;
            int middleCol = (i_Move.SourceColumn + i_Move.DestinationColumn) / 2;

            io_OpponnentPlayer.NumberOfPiecesLeft--;
            m_Grid[middleRow, middleCol] = null;
        }

        private bool isLastRow(int i_DestinationRow)
        {
            return i_DestinationRow == 0 || i_DestinationRow == r_Size - 1;
        }

        public bool HasLegalMoves(Player i_Player)
        {
            List<Move> possibleMoves = GetAllPossibleMoves(i_Player);

            return possibleMoves != null && possibleMoves.Count > 0;
        }

        public bool HasCaptureMovesForPiece(Piece i_Piece, int i_Row, int i_Col)
        {
            List<Move> capturingMoves = getCapturingMovesForPiece(i_Piece, i_Row, i_Col);

            return capturingMoves != null && capturingMoves.Count > 0;
        }

        public List<Move> GetAllPossibleMoves(Player i_Player)
        {
            List<Move> capturingMoves = new List<Move>();
            List<Move> regularMoves = new List<Move>();

            for (int row = 0; row < r_Size; row++)
            {
                for (int col = 0; col < r_Size; col++)
                {
                    Piece piece = m_Grid[row, col];
                    if (piece != null && piece.Owner == i_Player)
                    {
                        List<Move> pieceMoves = getPiecePossibleMoves(piece, row, col);
                        foreach (Move move in pieceMoves)
                        {
                            if (move.IsCapture)
                            {
                                capturingMoves.Add(move);
                            }
                            else
                            {
                                regularMoves.Add(move);
                            }
                        }
                    }
                }
            }

            return capturingMoves.Count > 0 ? capturingMoves : regularMoves;
        }

        private List<Move> getPiecePossibleMoves(Piece i_Piece, int i_Row, int i_Col)
        {
            List<Move> moves = new List<Move>();
            int[] rowOffsets = i_Piece.MovementDirection == Piece.eMovementDirection.Both
                ? new int[] { -1, 1 }
                : i_Piece.MovementDirection == Piece.eMovementDirection.Forward
                    ? new int[] { 1 }
                    : new int[] { -1 };
            int[] colOffsets = { -1, 1 };

            foreach (int rowOffset in rowOffsets)
            {
                foreach (int colOffset in colOffsets)
                {
                    int targetRow = i_Row + rowOffset;
                    int targetCol = i_Col + colOffset;

                    if (targetRow >= 0 && targetRow < r_Size && targetCol >= 0 && targetCol < r_Size)
                    {
                        if (m_Grid[targetRow, targetCol] == null) // Target cell is empty
                        {
                            Move regularMove = new Move(i_Row, i_Col, targetRow, targetCol);
                            regularMove.IsCapture = false;
                            moves.Add(regularMove);
                        }
                    }
                }
            }

            // Captures (jumps)
            List<Move> captureMoves = getCapturingMovesForPiece(i_Piece, i_Row, i_Col);
            moves.AddRange(captureMoves);

            return moves;
        }

        private List<Move> getCapturingMovesForPiece(Piece i_Piece, int i_Row, int i_Col)
        {
            List<Move> moves = new List<Move>();
            int[] rowOffsets = i_Piece.MovementDirection == Piece.eMovementDirection.Both
               ? new int[] { -2, 2 }
               : i_Piece.MovementDirection == Piece.eMovementDirection.Forward
                   ? new int[] { 2 }
                   : new int[] { -2 };
            int[] colOffsets = { -2, 2 };

            foreach (int rowOffset in rowOffsets)
            {
                foreach (int colOffset in colOffsets)
                {
                    int targetRow = i_Row + rowOffset;
                    int targetCol = i_Col + colOffset;
                    int middleRow = (i_Row + targetRow) / 2;
                    int middleCol = (i_Col + targetCol) / 2;

                    if (targetRow >= 0 && targetRow < r_Size && targetCol >= 0 && targetCol < r_Size)
                    {
                        Piece middlePiece = m_Grid[middleRow, middleCol];
                        if (m_Grid[targetRow, targetCol] == null && middlePiece != null && middlePiece.Owner != i_Piece.Owner) // Capturing an opponent's piece
                        {
                            Move captureMove = new Move(i_Row, i_Col, targetRow, targetCol);
                            captureMove.IsCapture = true;
                            moves.Add(captureMove);
                        }
                    }
                }
            }

            return moves;
        }
    }
}
