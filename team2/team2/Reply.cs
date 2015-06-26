﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team2
{

    public class Reply 
    {
        public Dictionary<int, List<string>> articleComments = new Dictionary<int, List<string>>();

        public void AddComment(int titleNum, string comment)
        {
            if (!articleComments.ContainsKey(titleNum))
            {
                articleComments.Add(titleNum, new List<string>());
            }
            articleComments[titleNum].Add(comment);
        }

        public List<string> GetComment(int titleNum)
        {
            if (articleComments.ContainsKey(titleNum))
            {
                return articleComments[titleNum];
            }
            return null;
        }
    }


}

