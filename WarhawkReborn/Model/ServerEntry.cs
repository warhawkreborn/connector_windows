using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WarhawkReborn.Model
{
    class ServerEntry
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("hostname")]
        public string Hostname { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("response")]
        public string Response { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("ping")]
        public int Ping { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public bool IsOnline
        {
            get { return State == "online"; }
        }

        public int PlayersMax
        {
            get
            {
                return HexToDec(Response, 239);
            }
        }

        public int PlayersIn
        {
            get
            {
                return HexToDec(Response, 242);
            }
        }

        public int ModeId
        {
            get
            {
                return HexToDec(Response, 237);
            }
        }

        public string Mode
        {
            get
            {
                int modeId = ModeId;
                if (modeId == 0) return "DM";
                if (modeId == 1) return "TDM";
                if (modeId == 2) return "CTF";
                if (modeId == 3) return "ZNS";
                if (modeId == 4) return "HRO";
                if (modeId == 5) return "COL";
                return "UNK";
            }
        }

        public int MapId
        {
            get
            {
                return HexToDec(Response, 241);
            }
        }

        public string Map
        {
            get
            {
                int mapId = MapId;
                if (mapId == 1) return "North Town"; //Unused (TGS 2006 trailer)
                if (mapId == 2) return "VanguardBay"; //Unused (E3 2006 build)
                if (mapId == 3) return "Country Side"; //Unused (TGS 2006 trailer?)
                if (mapId == 4) return "Eucadia";
                if (mapId == 6) return "Island Outpost";
                if (mapId == 8) return "The Badlands";
                if (mapId == 9) return "Sequoia 04"; //Unused
                if (mapId == 10) return "Omega Factory";
                if (mapId == 11) return "Destroyed Capitol";
                if (mapId == 12) return "Archipelago";
                if (mapId == 13) return "Vaporfield Glacier";
                if (mapId == 14) return "Tau Crater";
                return "Unknown";
            }
        }

        public int LayoutId
        {
            get
            {
                return HexStrToDec(Response, 256, 6);
            }
        }

        public string Layout
        {
            get
            {
                int mapId = MapId;
                int layoutId = LayoutId;
                if (mapId == 4) //Eucadia
                {
                    if (layoutId == 1) return "Battle for Eucadia";
                    if (layoutId == 2) return "Valley Battle";
                    if (layoutId == 3) return "Battle for Eucadia*";
                    if (layoutId == 4) return "High City";
                    if (layoutId == 5) return "Urban Strike";
                    if (layoutId == 6) return "Northern Bridge";
                    if (layoutId == 7) return "Battle for Eucadia**";
                    if (layoutId == 8) return "Valley Battle**";
                    if (layoutId == 9) return "High vs Low";
                    if (layoutId == 10) return "Dogfight";
                    if (layoutId == 12) return "Summit Command";
                    if (layoutId == 14) return "Battle for Eucadia***";
                    if (layoutId == 15) return "Valley Battle***";
                    if (layoutId == 16) return "Urban Strike***";
                    if (layoutId == 17) return "Northern Bridge***";
                    if (layoutId == 18) return "High vs Low***";
                    if (layoutId == 19) return "Summit Command***";
                    if (layoutId == 20) return "High City***";
                }
                if (mapId == 6) //Island Outpost
                {
                    if (layoutId == 1) return "Island Battle";
                    if (layoutId == 2) return "Installation";
                    if (layoutId == 3) return "Bridge Out";
                    if (layoutId == 4) return "Main Base";
                    if (layoutId == 5) return "Over the Bridges";
                    if (layoutId == 6) return "Standoff";
                    if (layoutId == 7) return "Island Battle**";
                    if (layoutId == 8) return "Island Battle*";
                    if (layoutId == 9) return "Installation**";
                    if (layoutId == 10) return "Dogfight";
                    if (layoutId == 14) return "Island Battle***";
                    if (layoutId == 15) return "Installation***";
                    if (layoutId == 16) return "Bridge Out***";
                    if (layoutId == 17) return "Main Base***";
                    if (layoutId == 18) return "Over the Bridges***";
                    if (layoutId == 19) return "Standoff***";
                }
                if (mapId == 8) //The Badlands
                {
                    if (layoutId == 1) return "Desert Warfare";
                    if (layoutId == 2) return "Northern Front";
                    if (layoutId == 3) return "Desert Warfare**";
                    if (layoutId == 4) return "Fortress";
                    if (layoutId == 5) return "Dogfight";
                    if (layoutId == 6) return "Supply Chain";
                    if (layoutId == 7) return "Skirmish";
                    if (layoutId == 8) return "South City";
                    if (layoutId == 9) return "Desert Warfare*";
                    if (layoutId == 10) return "Supply Chain**";
                    if (layoutId == 14) return "Desert Warfare***";
                    if (layoutId == 15) return "Supply Chain***";
                    if (layoutId == 16) return "Fortress***";
                    if (layoutId == 17) return "Skirmish***";
                    if (layoutId == 18) return "Northern Front***";
                    if (layoutId == 19) return "South City***";
                }
                if (mapId == 11) //Destroyed Capitol
                {
                    if (layoutId == 1) return "High Rise Hop";
                    if (layoutId == 2) return "Spire Shut-In";
                    if (layoutId == 3) return "Road to Ruin";
                    if (layoutId == 4) return "Garden Showdown";
                    if (layoutId == 5) return "Dogfight";
                    if (layoutId == 6) return "High Rise Hop*";
                    if (layoutId == 7) return "King of the Hill";
                    if (layoutId == 8) return "The Six Boroughs";
                    if (layoutId == 9) return "Spire Shut-In**";
                    if (layoutId == 10) return "Road to Ruin**";
                    if (layoutId == 15) return "Spire Shut-In***";
                    if (layoutId == 16) return "Road to Ruin***";
                    if (layoutId == 17) return "King of the Hill***";
                    if (layoutId == 18) return "The Six Boroughs***";
                    if (layoutId == 19) return "Garden Showdown***";
                }
                if (mapId == 12) //Archipelago
                {
                    if (layoutId == 1) return "Island Warfare";
                    if (layoutId == 2) return "Acropolis Assault";
                    if (layoutId == 3) return "Castle Tug-O-War";
                    if (layoutId == 4) return "Castle Solitaire";
                    if (layoutId == 5) return "Dogfight";
                    if (layoutId == 6) return "Southern Islands";
                    if (layoutId == 7) return "Close Corridors";
                    if (layoutId == 8) return "Island Warfare*";
                    if (layoutId == 9) return "Acropolis Assault**";
                    if (layoutId == 10) return "Island Warfare**";
                    if (layoutId == 14) return "Island Warfare***";
                    if (layoutId == 15) return "Acropolis Assault***";
                    if (layoutId == 16) return "Castle Tug-O-War***";
                    if (layoutId == 17) return "Castle Solitaire***";
                    if (layoutId == 18) return "Southern Islands***";
                    if (layoutId == 19) return "Close Corridors***";
                }
                if (mapId == 10) //Omega Factory
                {
                    if (layoutId == 1) return "Attrition";
                    if (layoutId == 2) return "Pipeline";
                    if (layoutId == 3) return "Hot Zone";
                    if (layoutId == 4) return "North Run";
                    if (layoutId == 5) return "Dogfight";
                    if (layoutId == 7) return "Inversion";
                    if (layoutId == 8) return "Rumble Dome";
                }
                if (mapId == 13) //Vaporfield Glacier
                {
                    if (layoutId == 1) return "Tundra Assault";
                    if (layoutId == 2) return "Olsavik Village";
                    if (layoutId == 3) return "Battle Line";
                    if (layoutId == 4) return "Espionage";
                    if (layoutId == 5) return "Western Waste";
                    if (layoutId == 6) return "Spearhead";
                    if (layoutId == 7) return "Grinder";
                    if (layoutId == 8) return "Dogfight";
                    if (layoutId == 9) return "Express Lane";
                    if (layoutId == 10) return "Communique";
                }
                if (mapId == 14) //Tau Crater
                {
                    if (layoutId == 1) return "Mission Critical";
                    if (layoutId == 2) return "Direct Assault";
                    if (layoutId == 3) return "Eastern Shore";
                    if (layoutId == 4) return "West Coast";
                    if (layoutId == 5) return "Under Fire";
                    if (layoutId == 6) return "Tug of War";
                    if (layoutId == 7) return "Heavy Lifting";
                    if (layoutId == 8) return "Crater Clash";
                    if (layoutId == 9) return "On the Deck";
                    if (layoutId == 10) return "Holed Up";
                    if (layoutId == 11) return "Dogfight";
                }
                return "Unknown";
            }
        }

        private int HexToDec(string response, int offset)
        {
            if (response == "") return -1;
            string text = response.Substring(offset * 2, 2);
            bool success = Int32.TryParse(text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out int number);
            if (success) { return number; }
            return -2;
        }

        private int HexStrToDec(string response, int offset, int length)
        {
            if (response == "") return -1;
            string text = "";
            for (int i = 0; i < length; i++)
            {
                text += (char)Convert.ToInt32(response.Substring((offset + i) * 2, 2), 16);
            }
            text = new String(text.Where(Char.IsDigit).ToArray());
            bool success = Int32.TryParse(text, out int number);
            if (success) { return number; }
            return -2;
        }
    }
}
