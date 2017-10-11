using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Server.Requests;

namespace Ciclope.Devices.Camera.Server
{
    public class CameraSocketServer : SocketServer
    {
        public CameraSocketServer()
            : base(typeof(ICameraServer), GetTypesInNamespace(Assembly.GetExecutingAssembly(), "Ciclope.Devices.Camera.Server.Requests"))
        {
        }

        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }
    }
}
