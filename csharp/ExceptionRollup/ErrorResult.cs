namespace codingdojo
{
    public class ErrorResult
    {
        private readonly string _formulaName;
        private readonly string _message;
        private readonly string _presentation;

        public ErrorResult(string formulaName, string message, string presentation)
        {
            _formulaName = formulaName;
            _message = message;
            _presentation = presentation;
        }


        public override string ToString()
        {
            return "ErrorResult{" +
                   "formulaName='" + _formulaName + '\'' +
                   ", message='" + _message + '\'' +
                   ", presentation='" + _presentation + '\'' +
                   '}';
        }

        public string GetFormulaName()
        {
            return _formulaName;
        }

        public string GetMessage()
        {
            return _message;
        }

        public string GetPresentation()
        {
            return _presentation;
        }
    }
}