namespace DamkaLogic
{
    public class Move
    {
        private readonly int r_SourceRow;
        private readonly int r_SourceColumn;
        private readonly int r_DestinationRow;
        private readonly int r_DestinationColumn;
        private string m_InputString; 
        private bool m_IsCapture;

        public Move(int i_SourceRow, int i_SourceColumn, int i_DestinationRow, int i_DestinationColumn)
        {
            r_SourceRow = i_SourceRow;
            r_SourceColumn = i_SourceColumn;
            r_DestinationRow = i_DestinationRow;
            r_DestinationColumn = i_DestinationColumn;
        }

        public int SourceRow
        {
            get
            {
                return r_SourceRow;
            }
        }

        public int SourceColumn
        {
            get
            {
                return r_SourceColumn;
            }
        }

        public int DestinationRow
        {
            get
            {
                return r_DestinationRow;
            }
        }

        public int DestinationColumn
        {
            get
            {
                return r_DestinationColumn;
            }
        }

        public string InputString
        {
            get
            {
                return m_InputString;
            }
            set
            {
                m_InputString = value;
            }
        }

        public bool IsCapture
        {
            get
            {
                return m_IsCapture;
            }
            set
            {
                m_IsCapture = value;
            }
        }
    }
}