using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Properties;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetPropertyValueRequest : Request
    {
        private String camera;
        private PropertyType property;

        public GetPropertyValueRequest(String camera, String property)
            : base(typeof(Double))
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
                Console.WriteLine("Property value requested: " + this.property);
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
                double value = driver.GetProperty(this.property).Value;

                return value;
            }
            else
                throw new Exception("The property does not exist.");
        }
    }
}
