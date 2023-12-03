
using com.gaurav.main.infrastructure;
using com.gaurav.main.infrastructure.Model;
using com.gaurav.parser;

namespace com.gaurav.main
{
    public class Startup : IDisposable
    {
        private readonly IParser _parser;
        private readonly BloggingContext _db;

        public Startup(IParser parser, BloggingContext db)
        {
            _parser = parser;
            _db = db;
        }

        public void Init()
        {
            Console.WriteLine("Dikh gya hoag bhai");
            var result = _parser.Parse("./static/sample.txt", ",");
            foreach (FinancialStatement statement in result)
            {
                _db.FinancialStatements?.Add(statement);
            }
            _db.SaveChanges();

            var query = from b in _db.FinancialStatements
                        select b;

            Console.WriteLine("All blogs in the database");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("tumse na ho pyega");
        }

        // public static Startup CreateInstance() {
        //     if(_instance == null)
        //         _instance = new Startup();
        //     return _instance;
        // }

        public void Dispose()
        {
            Console.WriteLine("Dispose is called for Startup class");
        }
    }
}