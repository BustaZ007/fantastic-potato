using FluentMigrator;


namespace FantasticPotato.Controllers.DataBaseControllers
{
    [Migration(1)]
    public class StartUpMigrationsController : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Surname").AsString().NotNullable()
                .WithColumn("Mail").AsString().NotNullable()
                .WithColumn("DateOfBirth").AsString().NotNullable();
            Create.Table("Authors")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Surname").AsString().NotNullable()
                .WithColumn("Country").AsString()
                .WithColumn("DateOfBirth").AsString().NotNullable();
            Create.Table("Books")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("OrigLan").AsString()
                .WithColumn("Genre").AsString()
                .WithColumn("AuthorId").AsInt64().NotNullable();
            Create.Table("FeedBacks")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt64().NotNullable()
                .WithColumn("BookId").AsInt64().NotNullable()
                .WithColumn("Text").AsString()
                .WithColumn("Rating").AsInt64().NotNullable();

            Create.ForeignKey() // You can give the FK a name or just let Fluent Migrator default to one
                .FromTable("Books").ForeignColumn("AuthorId")
                .ToTable("Authors").PrimaryColumn("Id");
            Create.ForeignKey() // You can give the FK a name or just let Fluent Migrator default to one
                .FromTable("FeedBacks").ForeignColumn("UserId")
                .ToTable("Users").PrimaryColumn("Id");
            Create.ForeignKey() // You can give the FK a name or just let Fluent Migrator default to one
                .FromTable("FeedBacks").ForeignColumn("BookId")
                .ToTable("Books").PrimaryColumn("Id");
        }

        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}