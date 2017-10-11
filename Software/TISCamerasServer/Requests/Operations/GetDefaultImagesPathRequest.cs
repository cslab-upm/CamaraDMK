using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetDefaultImagesPathRequest : Request
    {

        public GetDefaultImagesPathRequest()
            : base(typeof(String))
        {
        }

        public override Object Attend()
        {
            if (ServerConfig.ImagesPathSet)
                return ServerConfig.ImagesPath;
            else
                throw new Exception("No default images path defined yet.");
        }

    }
}
