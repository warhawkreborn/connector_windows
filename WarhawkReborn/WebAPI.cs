using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WarhawkReborn.Model;

namespace WarhawkReborn
{
    class WebAPI
    {
        private static readonly string API_BASE = "https://warhawk.thalhammer.it/api/";
        public List<ServerEntry> GetServers()
        {
            var client = new WebClient();
            var json = client.DownloadString(API_BASE + "server/");
            return JsonConvert.DeserializeObject<List<ServerEntry>>(json);
        }
    }
}
