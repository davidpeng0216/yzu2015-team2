using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace team2
{
    enum ArticleInfo { Title, Contents, Author};
    class ArticleThread
    {
        private String ArticleTitle;
        private String ArticleContents;
        private String Author;

        public ArticleThread()
        {
            ArticleTitle = null;
            ArticleContents = null;
            Author = null;
        }

        public ArticleThread(String _ArticleTitle, String _ArticleContents, String _Author)
        {
            ArticleTitle = _ArticleTitle;
            ArticleContents = _ArticleContents;
            Author = _Author;
        }

        public String GetArticleTitle()
        {
            return this.ArticleTitle;
        }

        public String GetArticleContents()
        {
            return this.ArticleContents;
        }

        public String GetAuthor()
        {
            return this.Author;
        }

        public void SetArticle(String _ArticleTitle, String _ArticleContents, String _Author)
        {
            ArticleTitle = _ArticleTitle;
            ArticleContents = _ArticleContents;
            Author = _Author;
        }

        public void SetArticleTile(String _ArticleTitle)
        {
            this.ArticleTitle = _ArticleTitle;
        }

        public void SetArticleContents(String _ArticleContents)
        {
            this.ArticleContents = _ArticleContents;
        }

        public void SetAuthor(String _Author)
        {
            this.Author = _Author;
        }

        public void StoreArticle(String _ArticleTile, String _ArticleContents, String _Author)
        {
            StreamWriter sw = new StreamWriter("..\\..\\Article.txt", true);
            string toWrite = "{" + _ArticleTile + "\t" + _Author + "\t" + _ArticleContents + "}";
            //sw.WriteLine(_ArticleTile);
            //sw.WriteLine(_ArticleContents);
            sw.WriteLine(toWrite);
            sw.Close();
        }

        static internal string[,] ReadArticle()
        {
            StreamReader sr = new StreamReader("..\\..\\Article.txt");
            string content = sr.ReadToEnd();
            string[] tmp = Regex.Matches(content, @"\{.*?\}", RegexOptions.Singleline).Cast<Match>().Select(m => m.Value).ToArray();
            string[,] article = new string[tmp.Length, 3];  //to store title, author, contents
            int nowPos = 0, firstTemp = -1, secondTemp = -1;
            for (int i = 0; i < tmp.Length; i++)
            {
                while (secondTemp == -1)
                {
                    if (tmp[i][nowPos] == '\t' && firstTemp == -1)
                    {
                        firstTemp = nowPos;
                    }
                    nowPos++;
                    if (tmp[i][nowPos] == '\t' && firstTemp != -1)
                    {
                        secondTemp = nowPos;
                        break;
                    }

                }

                for (int j = 1; j < firstTemp; j++)
                    article[i, (int)ArticleInfo.Title] += tmp[i][j];
                for (int j = firstTemp + 1; j < secondTemp; j++)
                    article[i, (int)ArticleInfo.Author] += tmp[i][j];
                for (int j = secondTemp + 1; j < tmp[i].Length - 1; j++)
                    article[i, (int)ArticleInfo.Contents] += tmp[i][j];
                firstTemp = -1;
                secondTemp = -1;
                nowPos = 0;
            }
            return article;
        }

        static internal string ReadArticle_byTitle(String _ArticleTitle)
        {
            string[,] content = ReadArticle();
            for (int i = 0; i < content.Length; i++ )
            {
                if (content[i, (int)ArticleInfo.Title].Equals(_ArticleTitle))
                {
                    
                    return content[i, (int)ArticleInfo.Contents];
                }
            }
                return "No Article!";
        }

    }
}
