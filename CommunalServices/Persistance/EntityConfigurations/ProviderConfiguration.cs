using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommunalServices.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunalServices.Persistance.EntityConfigurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");
        }
    }
}
