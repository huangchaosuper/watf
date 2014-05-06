using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Core.Common
{
    public class Common
    {
        public static System.Collections.Hashtable LexicalAnalysis(string key)
        {
            string[] keys = key.Split(new char[] { GlobalDefine.Page.Separator.Semicolon });
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            for (int i = 0; i < keys.Length; i++)
            {
                string[] words = keys[i].Split(new char[] { GlobalDefine.Page.Separator.Equal });
                ht.Add(words[0].Trim(), words[1].Trim());
            }
            return ht;
        }
    }
}
