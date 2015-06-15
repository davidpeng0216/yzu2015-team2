using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;


namespace team2
{
    class ArticleThread
    {
        private String title;
        private List<Article> thread;
        private int threadNumber;
        //private bool isTitleVerify;

        public ArticleThread() {}

        public ArticleThread(String _title, Article _article, int _threadNumber)
        {
            if (titleVerify(_title) == true)
                title = _title;
            else
                throw new ArgumentException("標題不符合規定(長度需為2~9之英文或數字)");
            thread = new List<Article>();
            thread.Add(_article);
            threadNumber = _threadNumber;
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public int ThreadNumber
        {
            get { return threadNumber; }
            set { threadNumber = value; }
        }
        
        public List<Article> Thread
        {
            get { return thread; }
        }

        public void addArticle(Article _article)
        {
            thread.Add(_article);
        }

       /* public void StoreArticle(String _ArticleTile, String _ArticleContents, String _Author)
        {
            StreamWriter sw = new StreamWriter("..\\..\\Article.txt", true);
            string toWrite = "{" + _ArticleTile + "\t" + _Author + "\t" + _ArticleContents + "}";
            //sw.WriteLine(_ArticleTile);
            //sw.WriteLine(_ArticleContents);
            sw.WriteLine(toWrite);
            sw.Close();
        }*/

       /* static internal string[,] ReadArticle()
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
        }*/

        /*static internal string ReadArticle_byTitle(String _ArticleTitle)
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
        }*/


        public Boolean titleVerify(string titleToCheck)
        {
            if (titleToCheck.Length < 2 || titleToCheck.Length > 10)
                return false;
            //只能輸入數字和英文
            string pattern = @"^[a-zA-Z0-9]+$";
            Regex regex = new Regex(pattern);
            // Compare a string against the regular expression
            return regex.IsMatch(titleToCheck);
        }
    }
}
