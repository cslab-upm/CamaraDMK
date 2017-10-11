using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.DriverEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetCurrentOperationRequest : Request
    {
        private String camera;

        public GetCurrentOperationRequest(String camera)
            : base(typeof(DriverOperation))
        {
            this.camera = camera;
        }

        public override Object Attend()
        {
            TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
            DriverOperation operation = driver.GetCurrentOperation();

            return operation;
        }
    }
}
