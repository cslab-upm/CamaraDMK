using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetFrameRateRequest : Request
    {
        private String camera;

        public GetFrameRateRequest(String camera)
            : base(typeof(Double))
        {
            this.camera = camera;
        }

        public override Object Attend()
        {
            TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
            return (Double)(double)driver.FrameRate;
        }

    }
}
