using System;

namespace codingdojo
{
    public class ExpressionParseException : Exception
    {
        public ExpressionParseException() : this("Expression parsing problem")
        {
        }

        public ExpressionParseException(string message) : base(message)
        {
        }
    }
}