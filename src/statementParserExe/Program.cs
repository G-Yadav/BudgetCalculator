using com.gaurav.main;
using com.gaurav.main.infrastructure;
using com.gaurav.main.infrastructure.Model;
using com.gaurav.main.infrastructure.Repository;
using com.gaurav.parser;
using Microsoft.Extensions.DependencyInjection;

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Startup obj = Startup.createInstance();
// obj.init();

var services = new ServiceCollection();
// services.AddDbContext<BloggingContext>(options => options.UseSqlServer("Server=localhost,1433;Database=ApplicationDB;User=sa;Password=P@ssw0rd;TrustServerCertificate=True;MultipleActiveResultSets=true"));
services.AddDbContext<BloggingContext>();
services.AddTransient<IParser, CsvParser>();
services.AddSingleton<Startup>();
// services.AddTransient<typeof(IRepository<>), FinancialStatementRepository>();

var serviceProvider = services.BuildServiceProvider();

using (var startup = serviceProvider.GetRequiredService<Startup>()) {
    startup.Init();
}

// using(var db = serviceProvider.GetRequiredService<BloggingContext>())
// {
//     Console.WriteLine("Enter blog name");
//     var name = Console.ReadLine();

//     var blog = new Blog() { Name = name };
//     if(db == null)
//         return;
//     db.Blogs?.Add(blog);
//     db.SaveChanges();

//     var query = from b in db.Blogs
//                 orderby b.Name
//                 select b;

//     Console.WriteLine("All blogs in the database");
//     foreach(var item in query) {
//         Console.WriteLine(item.Name);
//     }

//     Console.WriteLine("Press any key to exit");
//     Console.ReadKey();
// }