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
    public class GetFileTimeRequest : Request
    {
        private String completePath;
        private String path;
        private String file;

        public GetFileTimeRequest(String path, String file)
            : base(typeof(DateTime))
        {
            this.path = path;
            this.file = file;
            this.completePath = path + "/" + file;
        }

        public GetFileTimeRequest(String completePath)
            : base(typeof(DateTime))
        {
            this.completePath = completePath;
        }

        public override Object Attend()
        {
            try
            {
                if (File.Exists(completePath))
                {
                    FileInfo fileInfo = new FileInfo(completePath);

                    if (fileInfo.Length > 0)
                    {
                        DateTime creationTime = File.GetCreationTime(completePath);
                        DateTime writeTime = File.GetLastWriteTime(completePath);

                        if (writeTime > creationTime)
                        {
                            return writeTime;
                        }

                        return creationTime;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            throw new Exception("The file does not exist.");
        }

    }
}
