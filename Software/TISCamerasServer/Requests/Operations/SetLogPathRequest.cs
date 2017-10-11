using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Utils;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class SetLogPathRequest : Request
    {
        private String path;

        public SetLogPathRequest(String path)
            : base(typeof(void))
        {
            this.path = path;
        }

        public override Object Attend()
        {
            Log.LogPath = this.path;

            return null;
        }

    }
}
