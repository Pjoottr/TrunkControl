﻿using Rage;
using System;
using System.Net;

namespace TrunkPlugin
{
    public class PluginCheck
    {
        public static bool isUpdateAvailable()
        {
            string curVersion = Settings.CalloutVersion;
            Uri latestVersionuri = new Uri("https://github.com/Lenny-del/TrunkPlugin");
            WebClient client = new WebClient();
            string receivedData = string.Empty;
            try
            {
                receivedData = client.DownloadString("https://github.com/Lenny-del/TrunkPlugin").Trim();
            }
            catch (WebException)
            {
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
                Game.Console.Print();
                Game.Console.Print("[WARNING] Failed to check for an update.");
                Game.Console.Print("[WARNING] Please make sure you are online or try to reload the plugin.");
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
                Game.Console.Print();
            }
            if (receivedData != Settings.CalloutVersion)
            {
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
                Game.Console.Print();
                Game.Console.Print("[WARNING] A new version of TrunkPlugin is available. Please update to the latest build.");
                Game.Console.Print();
                Game.Console.Print("------------------------------------- TrunkPlugin -------------------------------------");
                Game.Console.Print();
                return true;
            }
            else
            {
                Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "~w~TrunkPlugin", "", "Detected latest version of TrunkPlugin.<br>Installed Version: ~g~" + curVersion + "");
                return false;
            }
        }
    }
}