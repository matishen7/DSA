using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.LeetcodeMarch
{
    public class SQL
    {
        private Dictionary<string, Dictionary<int, List<string>>> tables;
        private Dictionary<string, (int colNum, int lastCol)> colNums;
        public SQL(IList<string> names, IList<int> columns)
        {
            tables = new Dictionary<string, Dictionary<int, List<string>>>();
            colNums = new Dictionary<string, (int colNum, int lastCol)>();
            for (int i = 0; i < names.Count; i++)
            {
                string name = names[i];
                int col = columns[i];
                colNums.Add(name, (col, 1));
                var values = new Dictionary<int, List<string>>();
                tables.Add(name, values);
            }
        }

        public bool Ins(string name, IList<string> row)
        {
            if (tables.ContainsKey(name))
            {
                var lastColumn = colNums[name];
                if (lastColumn.colNum != row.Count) return false;
                var rows = tables[name];
                var newRow = new List<string>();
                for (int i = 0; i < row.Count; i++)
                {
                    newRow.Add(row[i]);
                }
                rows.Add(lastColumn.lastCol, newRow);
                tables[name] = rows;
                lastColumn.lastCol += 1;
                colNums[name] = lastColumn;
                return true;
            }
            else return false;
        }

        public void Rmv(string name, int rowId)
        {
            if (!tables.ContainsKey(name)) return;
            if (!tables[name].ContainsKey(rowId)) return;
            tables[name].Remove(rowId);

        }

        public string Sel(string name, int rowId, int columnId)
        {
            if (!tables.ContainsKey(name)) return null;
            if (!tables[name].ContainsKey(rowId)) return null;
            var row = tables[name][rowId];
            if (row.Count < columnId) return "<null>"; return row[columnId - 1];
        }

        public IList<string> Exp(string name)
        {
            if (!tables.ContainsKey(name)) return new List<string>() { "<null>"};

            var values = new List<string>();

            foreach (var row in tables[name])
            {
                var id = row.Key.ToString();
                var cols = row.Value.Select(col => col.Trim('"')); // Remove extra quotes

                // Join ID and columns into a single comma-separated string
                values.Add($"{id},{string.Join(",", cols)}");
            }

            return values;

        }
    }

    /**
     * Your SQL object will be instantiated and called as such:
     * SQL obj = new SQL(names, columns);
     * bool param_1 = obj.Ins(name,row);
     * obj.Rmv(name,rowId);
     * string param_3 = obj.Sel(name,rowId,columnId);
     * IList<string> param_4 = obj.Exp(name);
     */
}
