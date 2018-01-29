using CommunalServices.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunalServices.Data.EntityConfigurations
{
    public class ProvidedUtilityConfiguration : IEntityTypeConfiguration<ProvidedUtility>
    {
        public void Configure(EntityTypeBuilder<ProvidedUtility> builder)
        {
            builder.HasKey(k => new { k.ProviderId, k.UtilityId });
        }
    }
}
