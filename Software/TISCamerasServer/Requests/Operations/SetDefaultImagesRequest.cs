using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class SetDefaultImagesPathRequest : Request
    {
        private String path;

        public SetDefaultImagesPathRequest(String path)
            : base(typeof(void))
        {
            this.path = path;
        }

        public override Object Attend()
        {
            ServerConfig.ImagesPath = this.path;

            return null;
        }

    }
}
