namespace TelephoneDirectory.Core.ExceptionHandling
{
    public class BusinessRuleException : Exception
    {
        public List<string> Codes {  get; set; }

        public BusinessRuleException(List<string> code) 
        {
            Codes = code;
        }
    }
}
