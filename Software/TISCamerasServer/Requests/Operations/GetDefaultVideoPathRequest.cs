using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetDefaultVideoPathRequest : Request
    {

        public GetDefaultVideoPathRequest()
            : base(typeof(String))
        {
        }

        public override Object Attend()
        {
            if (ServerConfig.VideosPathSet)
                return ServerConfig.VideosPath;
            else
                throw new Exception("No default videos path defined yet.");
        }

    }
}
