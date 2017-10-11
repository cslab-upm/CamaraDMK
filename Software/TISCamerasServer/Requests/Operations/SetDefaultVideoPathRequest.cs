using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class SetDefaultVideoPathRequest : Request
    {
        private String path;

        public SetDefaultVideoPathRequest(String path)
            : base(typeof(void))
        {
            this.path = path;
        }

        public override Object Attend()
        {
            ServerConfig.VideosPath = this.path;

            return null;
        }

    }
}
