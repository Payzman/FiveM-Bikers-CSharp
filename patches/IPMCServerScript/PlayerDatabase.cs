using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class PlayerDatabase
    {
        public int total_rows { get; set; }
        public int offset { get; set; }
        public List<DatabaseRows> rows { get; set; }

        public PlayerDatabase(dynamic obj)
        {
            total_rows = obj.total_rows;
            offset = obj.offset;
            rows = new List<DatabaseRows>();
            foreach (dynamic row in obj.rows)
            {
                rows.Add(new DatabaseRows(row));
            }
        }
    }
}
