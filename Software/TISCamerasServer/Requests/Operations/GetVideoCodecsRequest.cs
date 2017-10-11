using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetVideoCodecsRequest : Request
    {
        private String camera;

        public GetVideoCodecsRequest(String camera)
            : base(typeof(String[]))
        {
            this.camera = camera;
        }

        public override Object Attend()
        {
            TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
            List<String> codecs = driver.GetAvailableVideoCodecs();

            return codecs.ToArray();
        }
    }
}
