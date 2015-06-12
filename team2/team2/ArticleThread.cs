using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace team2
{
    class ArticleThread
    {
        private String ArticleTile;
        private String ArticleContents;

        public ArticleThread()
        {
            ArticleTile = null;
            ArticleContents = null;
        }

        public ArticleThread(String _ArticleTile, String _ArticleContents)
        {
            ArticleTile = _ArticleTile;
            ArticleContents = _ArticleContents;
        }

        public String GetArticleTile()
        {
            return this.ArticleTile;
        }

        public String GetArticleContents()
        {
            return this.ArticleContents;
        }

        public void SetArticle(String _ArticleTile, String _ArticleContents)
        {
            ArticleTile = _ArticleTile;
            ArticleContents = _ArticleContents;
        }

        public void SetArticleTile(String _ArticleTile)
        {
            this.ArticleTile = _ArticleTile;
        }

        public void SetArticleContents(String _ArticleContents)
        {
            this.ArticleContents = _ArticleContents;
        }

        public void StoreArticle(String _ArticleTile, String _ArticleContents)
        {
            StreamWriter sw = new StreamWriter("Article.txt");
            sw.WriteLine(_ArticleTile);
            sw.WriteLine(_ArticleContents);
            sw.Close();
        }

        public String ReadArticle()
        {
            //StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader("Article.txt");
            String line = null;
            while (!sr.EndOfStream)
            {
                if (line == null)
                    line = sr.ReadLine();
                else
                    line += "\n" + sr.ReadLine();
                //sb.AppendLine(line);
            }
  
            //String result = sb.ToString();
            return line;
        }

        public String ReadArticle_byTile(String _ArticleTile)
        {
            StreamReader sr = new StreamReader("Article.txt");
            while(!sr.EndOfStream)
            {
                String line = sr.ReadLine();
                if(line.Equals(_ArticleTile))
                {
                    String Contents = sr.ReadLine();
                    return Contents;
                }
            }
            return "No Article!";
        }

    }
}
