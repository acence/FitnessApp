﻿using FitnessApp.Domain.Base;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Database
{
	public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        #region Overrides 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
			base.OnModelCreating(modelBuilder);
        }

        #endregion Overrides

        #region Methods 

        public new DbSet<T> Set<T>() where T : BaseModel
        {
            return base.Set<T>();
        }

        #endregion Methods

        #region Entity Sets


        #endregion Entity Sets
    }
}

