using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommunalServices.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunalServices.Persistance.EntityConfigurations
{
    public class ProvidedUtilityConfiguration : IEntityTypeConfiguration<ProvidedUtility>
    {
        public void Configure(EntityTypeBuilder<ProvidedUtility> builder)
        {
            builder.HasKey(k => new { k.ProviderId, k.UtilityId });
        }
    }
}
