using System;
using System.Collections.Generic;
using System.Text;
using System;

namespace CleanArc.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MapServiceDependency : Attribute
    {
        protected string _name;
        public string Name => _name;
        public MapServiceDependency(string Name)
        {
            this._name = Name;
        }
    }
}
