using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace noteApp
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }

        [Ignore]
        public bool IsChecked { get; set; }

    }
}
