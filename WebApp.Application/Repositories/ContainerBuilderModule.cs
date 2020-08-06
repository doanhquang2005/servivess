using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data.Entity.Billing;

namespace WebApp.Application.Repositories {

  public class ContainerBuilderModule : Module {
    protected override void Load(ContainerBuilder builder) {
      builder.RegisterType(typeof(BillingDbContext)).As(typeof(IDbContext))
        .InstancePerLifetimeScope();
    }
  }
}