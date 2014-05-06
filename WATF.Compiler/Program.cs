using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATF.Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\huanchao\Desktop\WATF_1.0.0.1\WATF.Compiler\WATF.Files.xml";
            if (args.Length > 1&& System.IO.File.Exists(args[1]))
            {
                path = args[1];
            }
            App app = App.GetInstance(path);
            if (0 != app.Init())
            {
                throw new Exception.CompilerException("Init Error!");
            }
            else if (!(bool)app.Run())
            {
                throw new Exception.CompilerException("Run Error!");
            }
            else 
            {
                app.UnInit();
            }
        }
    }
}
