using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.Camera.Properties;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class GetCameraPropertiesRequest : Request
    {
        private String camera;

        public GetCameraPropertiesRequest(String camera)
            : base(typeof(String[]))
        {
            this.camera = camera;
        }

        public override Object Attend()
        {
            TISCameraDriver driver = TISCameraManager.GetReference().getDriver(camera);
            List<PropertyType> properties = driver.GetAvailableProperties();
            List<String> strings = new List<string>();

            foreach (PropertyType property in properties)
            {
                strings.Add(property.ToString());
            }

            return strings.ToArray();
        }
    }
}
