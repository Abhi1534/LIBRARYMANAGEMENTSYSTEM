using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Web;

namespace LIBRARYMANAGEMENTSYSTEM.admin.admin
{
    public class Savedocs
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool LogonUser(
string prinicipal,
string authority,
string password,
LogonSessionType logonType,
LogonProvider logonProvider,
out IntPtr token);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);
        [Serializable]
        enum LogonSessionType : uint
        {
            Interactive = 2,
            Network,
            Batch,
            Service,
            NetworkCleartext = 8,
            NewCredentials
        }
        [Serializable]
        enum LogonProvider : uint
        {
            Default = 0, // default for platform (use this!)
            WinNT35,     // sends smoke signals to authority
            WinNT40,     // uses NTLM
            WinNT50      // negotiates Kerb or NTLM
        }

        //string domain = ConfigurationManager.AppSettings["DocServerip"].ToString();
        //string userName = ConfigurationManager.AppSettings["DocServerName"].ToString();
        //string password = ConfigurationManager.AppSettings["DocServerPassword"].ToString();
        string domain = "";
        string userName = "";
        string password = "";
        WindowsImpersonationContext impersonatedUser = null;
        public string Impersonate(string empCode)
        {
            IntPtr token = IntPtr.Zero;
            string mailpath = string.Empty;

            try
            {

                string stremprcode = empCode;


                //string domain = "esic.local";
                //string userNmae = "insuser";
                //string password = "Cr!t!c@1#2";

                LogonSessionType sessionType;
                // Note: Credentials should be encrypted in configuration file
                if (domain == ".")
                {
                    sessionType = LogonSessionType.NewCredentials;
                }
                else
                {
                    sessionType = LogonSessionType.NewCredentials;
                }
                // advapi32.dll
                bool result = LogonUser(userName, domain, password,
                                         sessionType,
                                         LogonProvider.Default,
                                         out token);
                if (result)
                {

                    WindowsIdentity id = new WindowsIdentity(token);

                    impersonatedUser = id.Impersonate();


                    try
                    {
                        // Models.Logger.Log("GetUploadFolderPath API :: in Impersonate b 4 genc11methodcall", folderpath.ToString());
                        mailpath = "";// GenerateC11(stremprcode, con1);
                        // Models.Logger.Log("GetUploadFolderPath API :: in Impersonate after genc11methodcall", folderpath.ToString());

                    }
                    catch (Exception ex)
                    {
                        //Logger.Write("CreateFolder " + ex.StackTrace, "2", 4, 1, System.Diagnostics.TraceEventType.Verbose);
                        //Models.Logger.Log("GenEmployerCode API :: Impersonate", ex.StackTrace);
                        // Models.Logger.Log("GenEmployerCode API :: CreateFolder", ex.StackTrace);


                        throw ex;
                    }
                }
                else
                {
                    //Models.Logger.Log("</p>LogonUser failed:", Marshal.GetLastWin32Error().ToString());
                }
            }
            catch (Exception ex)
            {
                // throw ex;
                //Models.Logger.Log("GetUploadFolderPath API :: Impersonate", ex.StackTrace);

            }

            return mailpath;
        }
    }
}