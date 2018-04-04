namespace UIConsole.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UIConsole.DbProduto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        /*
         METODO QUE SERVE PARA SEMEAR OS DADOS NA BD. OU SEJA, POVOAR A BD.
         */
        protected override void Seed(UIConsole.DbProduto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
