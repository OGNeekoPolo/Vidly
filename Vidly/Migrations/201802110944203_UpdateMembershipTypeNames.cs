namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.MembershipTypes SET MembershipName = 'Pay As You Go' WHERE MembershipTypeId = 1");
            Sql("UPDATE dbo.MembershipTypes SET MembershipName = 'Monthly' WHERE MembershipTypeId = 2");
            Sql("UPDATE dbo.MembershipTypes SET MembershipName = '3 Month' WHERE MembershipTypeId = 3");
            Sql("UPDATE dbo.MembershipTypes SET MembershipName = 'Annual' WHERE MembershipTypeId = 4");
        }

        public override void Down()
        {
        }
    }
}
