using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Models
{
    public class Memo
    {
        public string Id { get; set; }

        public string Keynote { get; set; }

        public string Detail { get; set; }

        public override string ToString()
        {
            return "Memo: Id = " + Id + ", Keynote = " + Keynote + ".";
        }
    }
}
