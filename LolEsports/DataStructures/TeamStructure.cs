using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolEsports.DataStructures
{
    public class TeamStructure
    {
        public int error;
        public String message;

        public String TeamName;
        public int RegionID;
        public String TeamLogo;
        public String TeamPicture;
        public String CoachIgn;
        public String CoachName;
        public List<int> ids;
    }
}
