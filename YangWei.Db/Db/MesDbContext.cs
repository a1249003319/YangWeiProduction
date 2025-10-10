using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangWei.Db.Entity;

namespace YangWei.Db.Db
{
    public class MesDbContext:DbContext
    {
       
        public MesDbContext() : base("Database=DbYangWei;User Id=sa;Password=123456;")
        {

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MesDbContext, Configuration>());


            //禁用初始化器
           // Database.SetInitializer<MesDbContext>(null);


           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<MesDbContext, Configuration>());
            // 开发环境使用（会丢失数据）
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MesDbContext>());
        }


        
        public DbSet<Users> Users { get; set; }
        public DbSet<Menus> Menus { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // 配置表名
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Menus>().ToTable("Menus");
            base.OnModelCreating(modelBuilder);
        }


        /// <summary>
        /// 通过代码创建表
        /// </summary>
        public static void InitializeDatabase()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MesDbContext>());

            using (var context = new MesDbContext())
            {
                // 这将触发数据库迁移
                context.Database.Initialize(false);
            }
        }

    }
    // 迁移配置
    //public sealed class Configuration : DbMigrationsConfiguration<MesDbContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = true;
    //        AutomaticMigrationDataLossAllowed = true;
    //    }
        
    //    protected override void Seed(MesDbContext context)
    //    {
    //        // 可选的种子数据
    //    }
    //}
}
