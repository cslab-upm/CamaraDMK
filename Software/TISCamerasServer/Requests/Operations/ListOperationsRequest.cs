using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Ciclope.Devices.ServerEngine;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public class ListOperationsRequest : Request
    {

        public ListOperationsRequest()
            : base(typeof(String[]))
        {
        }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        public override Object Attend()
        {
            Type[] typeList = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "Ciclope.Devices.Camera.Server.Requests");
            List<String> operationsList = new List<string>();

            if (typeList != null)
            {
                for (int i = 0; i < typeList.Length; i++)
                {
                    String typeName = typeList[i].Name;
                    if (typeName.EndsWith("Request"))
                    {
                        operationsList.Add(typeName.Replace("Request", String.Empty));
                    }
                }
            }

            return operationsList.ToArray();
        }
    }
}
