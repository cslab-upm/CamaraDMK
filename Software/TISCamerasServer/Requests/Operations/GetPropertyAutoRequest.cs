using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Properties;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetPropertyAutoRequest : Request
    {
        private String camera;
        private PropertyType property;

        public GetPropertyAutoRequest(String camera, String property)
            : base(typeof(Boolean))
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
            if (camera != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
                bool value = driver.GetProperty(this.property).Auto;

                return value;
            }
            else
                throw new Exception("The property does not exist.");
        }

    }
}
