namespace Pictulr.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pictulr.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pictulr.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Nodes.AddOrUpdate(n => n.NodeNameId, new Node { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"), ModelNumber = "0000001", NodeNameId = "seedData", ClassificationTechnique = "preclassified", CreatedUtc = DateTimeOffset.Now });
            
            context.Subjects.AddOrUpdate(n => n.SubjectName, new Subject { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"), SubjectName = "Cat1", CreatedUtc = DateTimeOffset.Now });
            context.Subjects.AddOrUpdate(n => n.SubjectName, new Subject { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"), SubjectName = "Dog1", CreatedUtc = DateTimeOffset.Now });

            context.Pictures.AddOrUpdate(n => n.PictureTitle, new Picture
            {
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                SubjectId = 1,
                PictureTitle = "In-Bread Cat",
                NodeNameId = 1,
                ImageLocation = "\\Assets\\SeedContent\\Inbread cat.jpg",
                Base64EncodedImage = "",
                CreatedUtc = DateTimeOffset.Now,
                RecievedUtc = DateTimeOffset.Now,
                OptionalMetadata = "Taken from the internet."
            });

            context.Pictures.AddOrUpdate(n => n.PictureTitle, new Picture
            {
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                SubjectId = 2,
                PictureTitle = "Golden Puppy",
                NodeNameId = 1,
                ImageLocation = "\\Assets\\SeedContent\\golden puppy.jpg",
                Base64EncodedImage = "",
                CreatedUtc = DateTimeOffset.Now,
                RecievedUtc = DateTimeOffset.Now,
                OptionalMetadata = "Taken from the internet."
            });

            context.Pictures.AddOrUpdate(n => n.PictureTitle, new Picture
            {
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                SubjectId = 1,
                PictureTitle = "Adorablke Kitty",
                NodeNameId = 1,
                ImageLocation = "\\Assets\\SeedContent\\Adorable-animal-cat-20787.jpg",
                Base64EncodedImage = "",
                CreatedUtc = DateTimeOffset.Now,
                RecievedUtc = DateTimeOffset.Now,
                OptionalMetadata = "Taken from the internet."
            });

            context.Pictures.AddOrUpdate(n => n.PictureTitle, new Picture
            {
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                SubjectId = 2,
                PictureTitle = "Mountain Doggo",
                NodeNameId = 1,
                ImageLocation = "\\Assets\\SeedContent\\Bernese-mountain-dog-grass.jpg",
                Base64EncodedImage = "",
                CreatedUtc = DateTimeOffset.Now,
                RecievedUtc = DateTimeOffset.Now,
                OptionalMetadata = "Taken from the internet."
            });

            //context.PictureClassifications.AddOrUpdate(n => n.ClassificationMethod, new PictureClassification { PictureID = 1, Classification = "Yep thats a cat in bread", NodeNameId = 1, ClassificationMethod = "Manual Seed", ReportTimeDuration = TimeSpan.FromMilliseconds(42069), ReportTimeUtc = DateTimeOffset.Now });
            //context.PictureClassifications.AddOrUpdate(n => n.ClassificationMethod, new PictureClassification { PictureID = 2, Classification = "Golden lil floof", NodeNameId = 1, ClassificationMethod = "Manual Seed", ReportTimeDuration = TimeSpan.FromMilliseconds(42069), ReportTimeUtc = DateTimeOffset.Now });
            //context.PictureClassifications.AddOrUpdate(n => n.ClassificationMethod, new PictureClassification { PictureID = 3, Classification = "Such an adorable kitty", NodeNameId = 1, ClassificationMethod = "Manual Seed", ReportTimeDuration = TimeSpan.FromMilliseconds(42069), ReportTimeUtc = DateTimeOffset.Now });
            //context.PictureClassifications.AddOrUpdate(n => n.ClassificationMethod, new PictureClassification { PictureID = 4, Classification = "Whose a good mountain doggo??", NodeNameId = 1, ClassificationMethod = "Manual Seed", ReportTimeDuration = TimeSpan.FromMilliseconds(42069), ReportTimeUtc = DateTimeOffset.Now });

            //context.SubjectClassifications.AddOrUpdate(n => n.Classification, new SubjectClassification { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"), SubjectId = 1, NodeNameId = 1, Classification = "Looks well-fed...", CreatedUtc = DateTimeOffset.Now});
            //context.SubjectClassifications.AddOrUpdate(n => n.Classification, new SubjectClassification { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"), SubjectId = 2, NodeNameId = 1, Classification = "a youngster", CreatedUtc = DateTimeOffset.Now});
            //context.SubjectClassifications.AddOrUpdate(n => n.Classification, new SubjectClassification { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"), SubjectId = 3, NodeNameId = 1, Classification = "curiosity...", CreatedUtc = DateTimeOffset.Now});
            //context.SubjectClassifications.AddOrUpdate(n => n.Classification, new SubjectClassification { OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"), SubjectId = 4, NodeNameId = 1, Classification = "do they always sit on that hill?", CreatedUtc = DateTimeOffset.Now});


        }
    }
}
