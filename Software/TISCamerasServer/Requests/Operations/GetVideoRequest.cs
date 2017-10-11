using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Utils;
using System.IO;
using Ciclope.Devices.DriverEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetVideoRequest : Request
    {
        private String file;
        private String path = null;

        public GetVideoRequest(String video)
            : base(typeof(MemoryStream))
        {
            if (ServerConfig.VideosPathSet)
            {
                this.path = ServerConfig.VideosPath;
                this.file = video;
            }
        }

        public override Object Attend()
        {
            if (path != null)
            {
                String[] filterExtensions = new string[] { "*.avi" };
                List<String> allFiles = new List<String>();

                foreach (String filter in filterExtensions)
                {
                    allFiles.AddRange(Directory.GetFiles(this.path + "/", filter));
                }

                String existingFile = allFiles.ToArray().FirstOrDefault<String>(e => e.Contains(this.file));

                if (existingFile != null)
                {
                    byte[] bytes;

                    lock (DriverOperation.WriteSync)
                    {
                        bytes = File.ReadAllBytes(existingFile);
                    }

                    MemoryStream stream = new MemoryStream(bytes);

                    return stream;
                }
                else
                    throw new Exception("The video does not exist.");
            }
            else
                throw new Exception("The path is not defined.");
        }

    }
}
