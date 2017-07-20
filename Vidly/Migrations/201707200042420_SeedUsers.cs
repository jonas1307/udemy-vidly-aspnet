namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'473b1916-90de-4271-9573-5e2489449bf8', N'admin@vidly.com', 0, N'AP/KvCxhaKoP3uBCFbv4xBMgvmGn6rUTqV4dOBU/Ua4TyzQ9aWTB/XAiHhqrakDkRg==', N'fcbf6d8f-71a5-44f9-9394-64d354fce50f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b8f610cb-fbf5-4991-b622-ac2b4dfd2db2', N'guest@vidly.com', 0, N'AIGl2pLj2um5ztuiHAC0Rpim+b07K8po+v7scg/MCGru3nFuE0/jKd2dQw/WQ338IA==', N'f1ca6e1a-64f5-4668-bc6f-01f3627f3fb5', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cfbc42dc-1525-48e4-84dd-3e7bcca11c6a', N'CanManageMovies')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'473b1916-90de-4271-9573-5e2489449bf8', N'cfbc42dc-1525-48e4-84dd-3e7bcca11c6a')
            ");
        }

        public override void Down()
        {
        }
    }
}
