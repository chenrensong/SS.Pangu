using System;
using System.Diagnostics;

namespace SS.Pangu.Framework
{
    public class Path
    {
        static public string GetAssemblyPath()
        {
            const string _PREFIX = @"file:///";
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            codeBase = codeBase.Substring(_PREFIX.Length, codeBase.Length - _PREFIX.Length).Replace("/", "\\");
            return System.IO.Path.GetDirectoryName(codeBase) + @"\";
        }

        static public string ProcessDirectory
        {
            get
            {
                string curFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

                return System.IO.Path.GetDirectoryName(curFileName);
            }
        }

        static public String AppendDivision(String path, char division)
        {
            Debug.Assert(path != null);

            if (path == "")
            {
                return path + division;
            }

            if (path[path.Length - 1] != '\\' &&
                path[path.Length - 1] != '/')
            {
                return path + division;
            }
            else
            {
                if (path[path.Length - 1] != division)
                {
                    return path.Substring(0, path.Length - 1) + division;
                }
            }

            return path;
        }


        static public String GetFolderName(String path)
        {
            path = System.IO.Path.GetFullPath(path);

            int len = path.Length - 1;
            while (path[len] == System.IO.Path.DirectorySeparatorChar && len >= 0)
            {
                len--;
            }

            String ret = "";
            for (int i = len; i >= 0; i--)
            {
                if (path[i] == System.IO.Path.DirectorySeparatorChar)
                {
                    break;
                }

                ret = path[i] + ret;
            }

            return ret;
        }
    }
}
