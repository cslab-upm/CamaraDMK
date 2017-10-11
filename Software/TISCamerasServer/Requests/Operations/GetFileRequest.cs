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
    public class GetFileRequest : Request
    {
        private String completePath;
        private String path;
        private String file;

        public GetFileRequest(String path, String file)
            : base(typeof(MemoryStream))
        {
            this.path = path;
            this.file = file;
            this.completePath = path + "/" + file;
        }

        public GetFileRequest(String completePath)
            : base(typeof(MemoryStream))
        {
            this.completePath = completePath;
        }

        public override Object Attend()
        {
            try
            {
                byte[] bytes;

                FileInfo fileInfo = new FileInfo(completePath);

                if (fileInfo.Length > 0)
                {

                    lock (DriverOperation.WriteSync)
                    {
                        bytes = File.ReadAllBytes(completePath);
                    }

                    MemoryStream stream = new MemoryStream(bytes);

                    return stream;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            throw new Exception("The file is empty");
        }

    }
}
