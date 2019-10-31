using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace ContactBook.DependencyResolution
{
    public class StructureMapDependencyResolver : StructuremapApiScope, IDependencyResolver
    {
        private readonly IContainer _container;

        public StructureMapDependencyResolver(IContainer container) : base(container)
        {
            _container = container;
        }
        public IDependencyScope BeginScope()
        {
            var childContainer = _container.GetNestedContainer();
            return new StructuremapApiScope(childContainer);
        }
    }
}