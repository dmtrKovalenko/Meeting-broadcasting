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

        public static async Task<bool> CheckInternetConnectionAsync(string URL = "http://www.google.com")
        {
            Ping myPing = new Ping();
            try
            {
                var pingReply = await myPing.SendPingAsync("google.com", 3000, new byte[32], new PingOptions(64, true));
                if (pingReply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
    
}