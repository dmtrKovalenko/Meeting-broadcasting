using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace thurst_media_player
{
    public static class InternetConnection
    {
        public static bool IsInternetConnection(string URL)
        {
            WebRequest request = WebRequest.Create(URL);
            WebResponse response;
            try
            {
                response = request.GetResponse();
                request.Timeout = 1000;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
