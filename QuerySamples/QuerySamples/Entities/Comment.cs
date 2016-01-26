using Cubido.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubido.Data.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Author { get; set; }

        public string Message { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
