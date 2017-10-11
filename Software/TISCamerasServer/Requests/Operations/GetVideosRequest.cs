using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Utils;
using System.IO;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetVideosRequest : Request
    {
        public GetVideosRequest()
            : base(typeof(String[]))
        {
        }

        public override Object Attend()
        {
            if (ServerConfig.VideosPathSet)
            {
                String[] files = Directory.GetFiles(ServerConfig.VideosPath + "/");

                return files;
            }
            else
                throw new Exception("The path is not defined.");
        }

    }
}
