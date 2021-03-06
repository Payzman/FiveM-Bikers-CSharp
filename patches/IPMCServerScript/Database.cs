﻿using System.Collections.Generic;

namespace Server.CouchDB
{
    public class Database
    {
        public int total_rows { get; set; }
        public int offset { get; set; }
        public List<DatabaseRows> rows { get; set; }
        public Database(dynamic obj)
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
