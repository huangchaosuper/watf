namespace WATF.Compiler
{
    public struct GlobalDefine
    {
        public struct Keyword
        {
            public struct Executive
            {
                public const string Root = "Executive";
                public const string Import = "Import";
                public const string Package = "Package";
                public const string Path = "PATH";
                public const string Prefix = "PREFIX";
                public const string Namespace = "NAMESPACE";

                public const string Test = "Test";
                public const string Step = "Step";
                public const string Var = "Var";
                public const string Name = "NAME";
                public const string Value = "VALUE";
                public const string Action = "Action";
                public const string Select = "SELECT";
                public const string Into = "INTO";
                public const string From = "FROM";
                public const string Where = "WHERE";
                public const string Compare = "COMPARE";
                public const string True = "TRUE";
                public const string False = "FALSE";
                public const string Set = "SET";
                public const string Print = "PRINT";
            }
            public struct ConfigFile
            {
                public const string Root = "ConfigFile";
                public const string Load = "Load";

                public const string Name = "NAME";
                public const string Path = "PATH";
            }
        }
    }
}