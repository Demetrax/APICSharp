using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEval.Models
{
    public class Publication
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public List<Commentaire> Comments { get; set; }

        public Publication()
        {
            Comments = new List<Commentaire>();
        }
    }
}
