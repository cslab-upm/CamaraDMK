using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.Camera;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Properties;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class SetPropertyAutoRequest : Request
    {
        private String camera;
        private PropertyType property;
        private Boolean mode;

        public SetPropertyAutoRequest(String camera, String property, Boolean mode)
            : base(typeof(void))
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
            this.mode = mode;
        }

        public override Object Attend()
        {
            if (this.camera != null)
            {
                TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
                driver.GetProperty(this.property).Auto = this.mode;

                return null;
            }
            else
                throw new Exception("The property does not exist.");
        }

    }
}
