using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Utils;
using System.IO;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetFilenamesRequest : Request
    {
        private String path;

        public GetFilenamesRequest(String path)
            : base(typeof(String[]))
        {
            this.path = path;
        }

        public override Object Attend()
        {
            String[] files = Directory.GetFiles(this.path + "/");

            return files;
        }

    }
}
