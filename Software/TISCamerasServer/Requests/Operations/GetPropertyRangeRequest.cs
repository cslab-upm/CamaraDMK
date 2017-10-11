using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Properties;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetPropertyRangeRequest : Request
    {
        private String camera;
        private PropertyType property;

        public GetPropertyRangeRequest(String camera, String property)
            : base(typeof(Double[]))
        {
            this.camera = camera;
            try
            {
                this.property = (PropertyType)Enum.Parse(typeof(PropertyType), property.ToUpper());
            }
            catch (Exception)
            {
                this.camera = null;
            }
        }

        public override Object Attend()
        {
            if (this.camera != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
                double min = driver.GetProperty(this.property).MinValue;
                double max = driver.GetProperty(this.property).MaxValue;

                return new Double[] { min, max };
            }
            else
                throw new Exception("The property does not exist.");
        }
    }
}
