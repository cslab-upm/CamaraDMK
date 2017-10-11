using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class EchoRequest : Request
    {
        private String echo;

        public EchoRequest(String echo)
            : base(typeof(String))
        {
            this.echo = echo;
        }

        public override Object Attend()
        {
            return this.echo;
        }

    }
}
