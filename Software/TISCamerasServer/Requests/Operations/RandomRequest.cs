using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.ServerEngine;
using Ciclope.Utils;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class RandomRequest : Request
    {
        private int max;

        public RandomRequest(int max)
            : base(typeof(int))
        {
            this.max = max;
        }

        public override Object Attend()
        {
            Random random = new Random();
            int value = random.Next(max);

            return value;
        }

    }
}
