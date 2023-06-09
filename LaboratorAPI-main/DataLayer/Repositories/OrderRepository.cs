﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class OrderRepository: RepositoryBase<Order>
    {
        private readonly AppDbContext dbContext;

        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
