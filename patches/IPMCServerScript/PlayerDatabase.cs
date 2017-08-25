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
        public List<Row> rows { get; set; }

        public PlayerDatabase(dynamic obj)
        {
            total_rows = obj.total_rows;
            offset = obj.offset;
            rows = new List<Row>();
            foreach (dynamic row in obj.rows)
            {
                rows.Add(new Row(row));
            }
        }
    }
}
