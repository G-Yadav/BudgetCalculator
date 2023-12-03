using Excel = Microsoft.Office.Interop.Excel;
using static System.IO.File;
using com.gaurav.main.infrastructure.Model;
using System.Globalization;


namespace com.gaurav.parser {
    public class CsvParser : IParser 
    {
        public IList<FinancialStatement> Parse(string path, string delimiter)
        {
            string [] rows = File.ReadAllLines(path);

            //read configuration from database about the file

            // read file using the configuration
            IList<FinancialStatement> result = new List<FinancialStatement>();
            // int index = 0;
            foreach(string row in rows) {
                // Console.WriteLine(row);
                string [] data = row.Split(delimiter);
                // Console.WriteLine(data.Length);
                if(data.Length < 7)
                    continue;
                FinancialStatement extract;
                var dtbool = DateOnly.TryParseExact(data[0].Trim(), "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt);
                var valueDtbool = DateOnly.TryParseExact(data[2].Trim(), "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var valueDt); //     && 
                var debtbool = double.TryParse(data[3].Trim(), out var debt); //     && 
                var credtbool = double.TryParse(data[4].Trim(), out var credt) ;//     && 
                var cBalancebool = double.TryParse(data[6].Trim(), out var cBalance); //     && 
                var rNumberbool = long.TryParse(data[5].Trim(), out var rNumber); //     && 

                // Console.WriteLine($"{dtbool}  {valueDtbool}  {debtbool}  {credtbool}  {cBalancebool}  {rNumberbool}");
                if(dtbool && valueDtbool && debtbool && credtbool && cBalancebool && rNumberbool
                    ) {
                    
                
                    extract = new (){
                        StatementDate = dt.ToDateTime(TimeOnly.MinValue),
                        Narration = data[1].Trim(),
                        ValueDate = valueDt.ToDateTime(TimeOnly.MinValue),
                        DebitAmount = debt,
                        CreditAmount = credt,
                        ReferenceNumber = rNumber,
                        ClosingBalance = cBalance
                    };
                    // Console.WriteLine(@extract);
                    result.Add(extract);
                };
                // index++;
                
                // foreach (string value in data) {
                    
                // }
                
                
            }
            return result;
        }

        public void ReadCsv(String path="./static/sample.txt")  {
            // DataFlow dataFlow = Reader.ReadCSV(path);
            // dataFlow.GetProfile();
        }

        public void ReadCsv1(string path="./static/sample.txt") {
            
        }

    }
}