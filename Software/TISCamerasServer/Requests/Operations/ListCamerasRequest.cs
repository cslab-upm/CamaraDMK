using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class ListCamerasRequest : Request
    {
        public ListCamerasRequest()
            : base(typeof(String[]))
        {
        }

        public override Object Attend()
        {
            List<String> cameras = TISCameraManager.GetReference().AvailableCameras;

            if (cameras == null) return new String[] { };
            
            return cameras.ToArray();
        }

    }
}
