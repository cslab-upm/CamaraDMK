using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.Camera.Properties;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class SetPropertyValueRequest : Request
    {
        private String camera;
        private PropertyType property;
        private double value;

        public SetPropertyValueRequest(String camera, String type, Double value)
            : base(typeof(void))
        {
            this.camera = camera;
            try
            {
                this.property = (PropertyType)Enum.Parse(typeof(PropertyType), type.ToUpper());
            }
            catch (Exception)
            {
                this.camera = null;
            }
            this.value = value;
        }

        public override Object Attend()
        {
            if (this.camera != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
                driver.GetProperty(this.property).Value = value;

                Console.WriteLine("Property " + this.property + " value modified: " + value);

                return null;
            }
            else
                throw new Exception("The property does not exist.");
        }

    }
}
