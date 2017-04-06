﻿namespace Prodavalnik.Data
{
    using Contracts;
    using Models.EntityModels;
    using Repositories;

    public class ProdavalnikData : IProdavalnikData
    {
        private readonly IProdavalnikContext context;
        public ProdavalnikData(IProdavalnikContext context)
        {
            this.context = context;
        }

        public IRepository<ApplicationUser> Users => new Repository<ApplicationUser>(this.context);
        public IRepository<Ad> Ads => new Repository<Ad>(this.context);
        public IRepository<Category> Categories => new Repository<Category>(this.context);
        public IProdavalnikContext Context => this.context;
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}