using com.gaurav.main.infrastructure.Model;

namespace com.gaurav.parser 
{
    public interface IParser 
    {
        IList<FinancialStatement> Parse(string path, string delimiter);
    }
}