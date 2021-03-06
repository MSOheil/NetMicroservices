namespace PlatFormService.InterFaces.Services.ApplicationDbContext.PrepDb;
public static class PrepDb
{
    public static void PrepPopulation(IServiceCollection app)
    {
        using (var serviceScope = app.BuildServiceProvider().CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }
    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("---> Seding Data...");
            context.Platforms.AddRange(
                new Platform
                {
                    Name = "Dot Net",
                    Publisher = "Microsoft",
                    Cost = "Free",
                },
                 new Platform
                 {
                     Name = "Sql Server Express",
                     Publisher = "Microsoft",
                     Cost = "Free",
                 },
                 new Platform
                 {
                     Name = "Kubernetes",
                     Publisher = "Cloud Native Computing Foundation",
                     Cost = "Free",
                 }
            );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> we already have data");
        }
    }

}

