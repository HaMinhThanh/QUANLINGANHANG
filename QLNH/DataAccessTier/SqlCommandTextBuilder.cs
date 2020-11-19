using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessTier
{
    public class SqlCommandTextBuilder
    {
        public string commandText { get; set; } = "";
        private int colCount = 0;
        public SqlCommandTextBuilder(string input)
        {
            commandText = input;
        }
        public void AppendColumn(string colName)
        {
            if (colCount == 0) { commandText += " WHERE " + colName + " = @" + colName; }
            else { commandText += " AND " + colName + " = @" + colName; }
            colCount++;
        }
        public void AppendColumnInRange(string colName) { 
            if (colCount == 0) { commandText += " WHERE " + colName + " >= @" + colName + "_low AND " + colName + " <= @" + colName + "_high"; }
            else { commandText += " AND " + colName + " >= @" + colName + "_low AND " + colName + " <= @" + colName + "_high"; }
            colCount++;
        }
    }
}
