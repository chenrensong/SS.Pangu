using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SS.Pangu.Dict
{
    class StopWord
    {
        Dictionary<string, string> _StopwordTbl = new Dictionary<string, string>();

        public bool IsStopWord(string word, bool filterEnglish, int filterEnglishLength, 
            bool filterNumeric, int filterNumericLength) 
        {
            if (word == null || word == "")
            {
                return false;
            }

            string key;

            if (word[0] < 128)
            {
                if (filterEnglish)
                {
                    if (word.Length > filterEnglishLength && (word[0] < '0' || word[0] > '9'))
                    {
                        return true;
                    }
                }

                if (filterNumeric)
                {
                    if (word.Length > filterNumericLength && (word[0] >= '0' && word[0] <= '9'))
                    {
                        return true;
                    }
                }


                key = word.ToLower();
            }
            else
            {
                key = word;
            }

            return _StopwordTbl.ContainsKey(key);
        }

        public void LoadStopwordsDict(String fileName)
        {
            _StopwordTbl = new Dictionary<string, string>();

            using (StreamReader sw = new StreamReader(fileName, Encoding.GetEncoding("UTF-8")))
            {
                //加载中文停用词
                while (!sw.EndOfStream)
                {
                    //按行读取中文停用词
                    string stopWord = sw.ReadLine();

                    if (string.IsNullOrEmpty(stopWord))
                    {
                        continue;
                    }

                    string key;

                    if (stopWord[0] < 128)
                    {
                        key = stopWord.ToLower();
                    }
                    else
                    {
                        key = stopWord;
                    }

                    //如果哈希表中不包括该停用词则添加到哈希表中
                    if (!_StopwordTbl.ContainsKey(key))
                    {
                        _StopwordTbl.Add(key, stopWord);
                    }
                }

            }
        }
    }
}
