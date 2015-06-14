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
        private int threadNumber;

        public Article() {}
        public Article(string _contents, string _author, int _threadNumber)
        {
            if (checkArticle(_contents))
                contents = _contents;
            else
                throw new FormatException("文章內容不符規定(長度需為21~499)");
            author = _author;
            publishDate = new DateTime();
            publishDate = DateTime.Now;
            threadNumber = _threadNumber;
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

        public Boolean checkArticle(string contentsToCheck)
        {
            if (contentsToCheck.Length < 20 || contentsToCheck.Length > 500)
                return false;
            else
                return true;
        }

        public int ThreadNumber
        {
            get { return threadNumber; }
            set { threadNumber = value; }
        }
       
    }
}
