using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team2
{
    class Article
    {
        private string contents;
        private string author;
        private DateTime publishDate;

        public Article() {}
        public Article(string _contents, string _author, DateTime _publishDate)
        {
            contents = _contents;
            author = _author;
            publishDate = _publishDate;
        }

        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }

        public Boolean checkArticle()
        {
            String checkStr = contents;
            if (checkStr.Length < 20 || checkStr.Length > 500)
                return false;
            else
                return true;
        }
       
    }
}
