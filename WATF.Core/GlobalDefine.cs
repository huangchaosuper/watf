using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Core
{
    public struct GlobalDefine
    {
        public struct WebKey
        {
            public const string Type = "TYPE";
            public const string Id = "ID";
            public const string Name = "NAME";
            public const string Tag = "TAG";
            public const string Class = "CLASS";
            public const string Number = "NUMBER";
        }
        public struct Page
        {
            public const string Html = "HTML";
            public const string Flash = "FALSH";
            public const string Sliverlight = "SLIVERLIGHT";
            public struct HTML
            {
                public const string Complete = "complete";
            }
            public struct Separator
            {
                public const char Semicolon = ';';
                public const char Equal = '=';
            }
        }
        public struct HtmlControls
        {
            public struct Event
            { 
            
            }
            public struct Attribute
            { 
                
            }
        }
    }
}
