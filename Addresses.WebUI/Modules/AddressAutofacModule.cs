using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Addresses.DAL;
using System.Data.Entity;
using Addresses.Repository;
using Addresses.BOL;

namespace Addresses.WebUI.Modules
{
    public class AddressAutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(AddressContext)).As(typeof(DbContext))
                .InstancePerLifetimeScope();
            builder.RegisterType(typeof(AddressRepository))
                .As(typeof(IGenericRepository<Address,AddressDTO>))
                .InstancePerRequest();
            builder.RegisterType(typeof(SubdivisionRepository))
                .As(typeof(IGenericRepository<Subdivision, SubdivisionDTO>))
                .InstancePerRequest();
            builder.RegisterType(typeof(StreetRepository))
                .As(typeof(IGenericRepository<Street, StreetDTO>))
                .InstancePerRequest();
            base.Load(builder);
        }
    }
}