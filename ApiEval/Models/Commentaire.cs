using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEval.Models
{
    public class Commentaire
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Commentaire()
        {

        }
    }
}
