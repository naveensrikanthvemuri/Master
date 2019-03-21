using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Infrastructure.Extensions
{
   public static  class AssemblyExtensions
    {
        private static readonly DateTime TestExecutionDate = DateTime.Now;

        public static string GetArtificatsFolder(this Assembly executingAssembly,string folderName = ".build")
        {
            var testArtifactsFolder = Path.Combine(
                executingAssembly.GetSolutionFolder(),
                folderName);
            Directory.CreateDirectory(testArtifactsFolder);
            return testArtifactsFolder;
        }
        
        public static string GetLocation(this Assembly executingAssembly)
        {
            executingAssembly = executingAssembly ?? Assembly.GetExecutingAssembly();
            var codeBase = executingAssembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var location = Path.GetDirectoryName(path);
            var message=$@"{executingAssembly.FullName}'s location is '{location}";
            Console.WriteLine(message);
            return location;

        }

        [SuppressMessage("Resharper","PossibleNullReferenceException")]
        public static string GetSolutionFolder(this Assembly executingAssembly)
        {
            var location = executingAssembly.GetLocation();
            var runningFromSource = new DirectoryInfo(location).Parent.Name.Equals("bin", StringComparison.InvariantCultureIgnoreCase);
            return runningFromSource ? new DirectoryInfo(location).Parent.Parent.Parent.FullName
                    : new DirectoryInfo(location).FullName;
        }

        [SuppressMessage("Resharper","PossibleNullReferenceException")]
        public static string GetRepositoryRootFolder(this Assembly executingAssembly)
        {
            var location = executingAssembly.GetLocation();
            var runningFromSource = new DirectoryInfo(location).Parent.Name.Equals("bin", StringComparison.InvariantCultureIgnoreCase);
            return runningFromSource ? new DirectoryInfo(location).Parent.Parent.Parent.FullName
                    : new DirectoryInfo(location).FullName;
        }
         public static string GetWorkingFilesFolder(this Assembly executingAssembly)
        {
            var assembly = executingAssembly ?? typeof(AssemblyExtensions).Assembly;
            var path = Path.Combine(assembly.GetRepositoryRootFolder(), "workingFiles");
            return new DirectoryInfo(path).FullName;
        }
    }
}
