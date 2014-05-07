/***************************************************************
*  DO NOT EDIT THIS FILE!
*         
*  This file is automatically generated by HP Service Test.
*  Manually changing the contents of this file may result in 
*  loss of information.
*          
*  To edit the test, open the file ?{testName}.st? 
*  in HP Service Test.
 ***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Script
{
    using System.Reflection;
    using System.IO;
    using System.Linq;
    using Microsoft.Win32;
    using HP.ST.Shared.Utilities;
    using HP.ST.Fwk.SOAReplayAPI;//this reference is needed because of GetInstallPath() function
    
    public partial class VuserClass
    {
        private Dictionary<string, string> dllsLocation = new Dictionary<string, string>();

        /// <summary>
        /// Parse the installation directory, and the addins directories
        /// for all HP... dlls
        /// </summary>
        private void UpdateDllsLocation()
        {
            string installaiontDir = ReplayRegistryUtils.GetInstallPath();
            LookupInDir(Path.Combine(installaiontDir, "bin"));
            LookupInDir(Path.Combine(installaiontDir, "addins"));

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }


        private void LookupInDir(string lookupDir)
        {
            string[] files = Directory.GetFiles(lookupDir, "*.dll", SearchOption.AllDirectories);
            foreach (string dllFullName in files)
            {
                string[] splitedName = dllFullName.Split('\\');
                string dllName = splitedName[splitedName.Length - 1];
                if (!this.dllsLocation.ContainsKey(dllName))
                    this.dllsLocation[dllName] = dllFullName;
            }
        }


        /// <summary>
        /// Event handler for loading assemblies in ST instalation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly assembly = null;
            string[] assemblyInfo = args.Name.Split(',');
            string assemblyName = assemblyInfo[0] + ".dll";


            if (this.dllsLocation.ContainsKey(assemblyName))
            {
                assembly = Assembly.LoadFrom(this.dllsLocation[assemblyName]);
            }
            else
            {
                if (CommandLineArguments != null)
                    assembly = tryLoadFromScriptBin(assemblyName);
                else
                    assembly = null;
            }

            return assembly;
        }

        private Assembly tryLoadFromScriptBin(string assemblyName)
        {
            string testDirectory = string.Empty;

            for (int i = 0; i < CommandLineArguments.Length; i++)
            {
                if (CommandLineArguments[i].Equals("-test", StringComparison.OrdinalIgnoreCase))
                {
                    testDirectory = CommandLineArguments[i + 1];
                }
            }

            string scriptsBinfolder = Path.Combine(testDirectory, "bin");
            return Assembly.LoadFrom(Path.Combine(scriptsBinfolder, assemblyName));
        }
    }
}
