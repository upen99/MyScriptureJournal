using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {

        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string Book { get; set; }
        public decimal Chapters { get; set; }
        public decimal Verses { get; set; }
        public string Note { get; set; }

    }
}
