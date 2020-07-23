namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Background",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SkillProficiencies = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CharacterClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HitDie = c.String(nullable: false),
                        SavingThrows = c.String(nullable: false),
                        NumberOfSkillProficiencies = c.Int(nullable: false),
                        SkillChoices = c.String(nullable: false),
                        Features = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subclass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Features = c.String(),
                        CharacterClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CharacterClass", t => t.CharacterClassId, cascadeDelete: true)
                .Index(t => t.CharacterClassId);
            
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        RaceId = c.Int(nullable: false),
                        SubraceId = c.Int(),
                        CharacterClassId = c.Int(nullable: false),
                        SubclassId = c.Int(),
                        MulticlassId = c.Int(),
                        MulticlassSubclassId = c.Int(),
                        SecondMulticlassId = c.Int(),
                        SecondMulticlassSubclassId = c.Int(),
                        BackgroundId = c.Int(),
                        Level = c.Int(nullable: false),
                        ArmorClass = c.Int(nullable: false),
                        HitPoints = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        Constitution = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        Wisdom = c.Int(nullable: false),
                        Charisma = c.Int(nullable: false),
                        SavingThrows = c.String(nullable: false),
                        Skills = c.String(nullable: false),
                        NotableInventory = c.String(name: "Notable Inventory"),
                        Appearance = c.String(),
                        Backstory = c.String(),
                        Description = c.String(),
                        Notes = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Background", t => t.BackgroundId)
                .ForeignKey("dbo.CharacterClass", t => t.CharacterClassId, cascadeDelete: true)
                .ForeignKey("dbo.CharacterClass", t => t.MulticlassId)
                .ForeignKey("dbo.Subclass", t => t.MulticlassSubclassId)
                .ForeignKey("dbo.Race", t => t.RaceId, cascadeDelete: true)
                .ForeignKey("dbo.CharacterClass", t => t.SecondMulticlassId)
                .ForeignKey("dbo.Subclass", t => t.SecondMulticlassSubclassId)
                .ForeignKey("dbo.Subclass", t => t.SubclassId)
                .ForeignKey("dbo.Subrace", t => t.SubraceId)
                .Index(t => t.RaceId)
                .Index(t => t.SubraceId)
                .Index(t => t.CharacterClassId)
                .Index(t => t.SubclassId)
                .Index(t => t.MulticlassId)
                .Index(t => t.MulticlassSubclassId)
                .Index(t => t.SecondMulticlassId)
                .Index(t => t.SecondMulticlassSubclassId)
                .Index(t => t.BackgroundId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        CharacterId = c.Int(),
                        MonsterId = c.Int(),
                        SpellId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Character", t => t.CharacterId)
                .ForeignKey("dbo.Monster", t => t.MonsterId)
                .ForeignKey("dbo.Spell", t => t.SpellId)
                .Index(t => t.CharacterId)
                .Index(t => t.MonsterId)
                .Index(t => t.SpellId);
            
            CreateTable(
                "dbo.Monster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Size = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Alignment = c.Int(nullable: false),
                        ArmorClass = c.Int(nullable: false),
                        ArmorType = c.String(),
                        HitPoints = c.Int(nullable: false),
                        HitPointEquation = c.String(),
                        Speed = c.String(nullable: false),
                        Strength = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        Constitution = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        Wisdom = c.Int(nullable: false),
                        Charisma = c.Int(nullable: false),
                        SavingThrows = c.String(),
                        Skills = c.String(),
                        Vulnerabilities = c.String(),
                        Resistances = c.String(),
                        Immunities = c.String(),
                        Senses = c.String(),
                        Languages = c.String(),
                        ChallengeRating = c.String(nullable: false),
                        Traits = c.String(),
                        Actions = c.String(),
                        Reactions = c.String(),
                        NumberOfLegendaryActions = c.Int(nullable: false),
                        LegendaryActions = c.String(),
                        LairActions = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        CommentId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Spell",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        SpellLevel = c.Int(nullable: false),
                        School = c.Int(nullable: false),
                        IsRitual = c.Boolean(nullable: false),
                        Range = c.String(nullable: false),
                        RequiresConcentration = c.Boolean(nullable: false),
                        CastingTime = c.String(nullable: false),
                        Components = c.String(nullable: false),
                        MaterialComponent = c.String(),
                        Duration = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ClassIds = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Race",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AbilityScoreIncrease = c.String(nullable: false),
                        Size = c.Int(nullable: false),
                        Speed = c.String(nullable: false),
                        HasDarkvision = c.Boolean(nullable: false),
                        Traits = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subrace",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AbilityScoreIncrease = c.String(nullable: false),
                        Traits = c.String(),
                        RaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Race", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.RaceId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Character", "SubraceId", "dbo.Subrace");
            DropForeignKey("dbo.Character", "SubclassId", "dbo.Subclass");
            DropForeignKey("dbo.Character", "SecondMulticlassSubclassId", "dbo.Subclass");
            DropForeignKey("dbo.Character", "SecondMulticlassId", "dbo.CharacterClass");
            DropForeignKey("dbo.Character", "RaceId", "dbo.Race");
            DropForeignKey("dbo.Subrace", "RaceId", "dbo.Race");
            DropForeignKey("dbo.Character", "MulticlassSubclassId", "dbo.Subclass");
            DropForeignKey("dbo.Character", "MulticlassId", "dbo.CharacterClass");
            DropForeignKey("dbo.Comment", "SpellId", "dbo.Spell");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "MonsterId", "dbo.Monster");
            DropForeignKey("dbo.Comment", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.Character", "CharacterClassId", "dbo.CharacterClass");
            DropForeignKey("dbo.Character", "BackgroundId", "dbo.Background");
            DropForeignKey("dbo.Subclass", "CharacterClassId", "dbo.CharacterClass");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Subrace", new[] { "RaceId" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "SpellId" });
            DropIndex("dbo.Comment", new[] { "MonsterId" });
            DropIndex("dbo.Comment", new[] { "CharacterId" });
            DropIndex("dbo.Character", new[] { "BackgroundId" });
            DropIndex("dbo.Character", new[] { "SecondMulticlassSubclassId" });
            DropIndex("dbo.Character", new[] { "SecondMulticlassId" });
            DropIndex("dbo.Character", new[] { "MulticlassSubclassId" });
            DropIndex("dbo.Character", new[] { "MulticlassId" });
            DropIndex("dbo.Character", new[] { "SubclassId" });
            DropIndex("dbo.Character", new[] { "CharacterClassId" });
            DropIndex("dbo.Character", new[] { "SubraceId" });
            DropIndex("dbo.Character", new[] { "RaceId" });
            DropIndex("dbo.Subclass", new[] { "CharacterClassId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Subrace");
            DropTable("dbo.Race");
            DropTable("dbo.Spell");
            DropTable("dbo.Reply");
            DropTable("dbo.Monster");
            DropTable("dbo.Comment");
            DropTable("dbo.Character");
            DropTable("dbo.Subclass");
            DropTable("dbo.CharacterClass");
            DropTable("dbo.Background");
        }
    }
}
