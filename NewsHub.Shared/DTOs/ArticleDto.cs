using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsHub.Shared.DTOs
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
