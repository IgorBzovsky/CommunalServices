﻿using CommunalServices.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Persistance
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            SeedUtilities(context);
            SeedLocations(context);
        }

        private static void SeedLocations(ApplicationDbContext context)
        {
            if (!context.Locations.Any())
            {
                context.Locations.Add(new Location
                {
                    Name = "Вінницька область"
                });
                context.Locations.Add(new Location
                {
                    Name = "Київська область"
                });
                context.Locations.Add(new Location
                {
                    Name = "Одеська область"
                });
                context.SaveChanges();
            }
        }

        private static void SeedUtilities(ApplicationDbContext context)
        {
            if (!context.Utilities.Any())
            {
                MeasureUnit electricityUnit = new MeasureUnit { Name = "кВт" };
                MeasureUnit heatingUnit = new MeasureUnit { Name = "Гкал" };
                MeasureUnit cubicMeter = new MeasureUnit { Name = "м\u00B3" };

                context.Utilities.Add(new Utility
                {
                    Name = "Електроенергія",
                    MeasureUnit = electricityUnit
                });
                context.Utilities.Add(new Utility
                {
                    Name = "Газ",
                    MeasureUnit = cubicMeter
                });
                context.Utilities.Add(new Utility
                {
                    Name = "Тепло",
                    MeasureUnit = heatingUnit
                });
                context.Utilities.Add(new Utility
                {
                    Name = "Гаряча вода",
                    MeasureUnit = cubicMeter
                });
                context.Utilities.Add(new Utility
                {
                    Name = "Холодна вода",
                    MeasureUnit = cubicMeter
                });
                context.Utilities.Add(new Utility
                {
                    Name = "Водовідведення",
                    MeasureUnit = cubicMeter
                });
                context.SaveChanges();
            }
        }
    }
}