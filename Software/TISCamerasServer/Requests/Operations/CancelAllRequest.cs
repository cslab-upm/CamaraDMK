using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class CancelAllRequest : Request
    {
        private String camera;

        public CancelAllRequest(String camera)
            : base(typeof(void))
        {
            this.camera = camera;
        }

        public override Object Attend()
        {            
            TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
            driver.CancelAll();

            return null;
        }
    }
}
