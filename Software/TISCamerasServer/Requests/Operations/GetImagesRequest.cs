using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Utils;
using System.IO;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetImagesRequest : Request
    {
        public GetImagesRequest()
            : base(typeof(String[]))
        {
        }

        public override Object Attend()
        {
            if (ServerConfig.ImagesPathSet)
            {
                String[] files = Directory.GetFiles(ServerConfig.ImagesPath + "/");

                return files;
            }
            else
                throw new Exception("The path is not defined.");
        }

    }
}
