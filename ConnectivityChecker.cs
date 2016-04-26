using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace thurst_media_player
{
    public static class ConnectivityChecker
    {
        public enum ConnectionStatus
        {
            NotConnected,
            LimitedAccess,
            Connected
        }

        public static async Task<ConnectionStatus> CheckInternet(string URL = "dns.msftncsi.com")
        {
            try
            {
                IPHostEntry entry = await Dns.GetHostEntryAsync(URL);
                if (entry.AddressList.Length == 0)
                {
                    return ConnectionStatus.NotConnected;
                }
                else
                {
                    if (!entry.AddressList[0].ToString().Equals("131.107.255.255"))
                    {
                        return ConnectionStatus.LimitedAccess;
                    }
                }
            }
            catch
            {
                return ConnectionStatus.NotConnected;
            }
            return ConnectionStatus.Connected;
        }
    }
}