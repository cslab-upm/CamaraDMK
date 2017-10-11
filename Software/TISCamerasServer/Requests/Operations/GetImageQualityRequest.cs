using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.Camera;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Properties;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetImageQualityRequest : Request
    {
        private String camera;

        public GetImageQualityRequest(String camera)
            : base(typeof(int))
        {
            this.camera = camera;
        }

        public override Object Attend()
        {
            if (this.camera != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
                return driver.ImageQuality;
            }
            else
                throw new Exception("A problem has occurred while trying to get the driver image quality.");
        }

    }
}
