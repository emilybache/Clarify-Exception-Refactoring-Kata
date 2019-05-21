using System;

namespace codingdojo
{
    public class MessageEnricher
    {
        public ErrorResult EnrichError(SpreadsheetWorkbook spreadsheetWorkbook, Exception e)
        {
            var formulaName = spreadsheetWorkbook.GetFormulaName();

            if (e.GetType() == typeof(ExpressionParseException))
            {
                var error = "Invalid expression found in tax formula [" + formulaName +
                            "]. Check that separators and delimiters use the English locale.";
                return new ErrorResult(formulaName, error, spreadsheetWorkbook.GetPresentation());
            }

            if (e.Message.StartsWith("Circular Reference"))
            {
                var error = parseCircularReferenceException(e, formulaName);
                return new ErrorResult(formulaName, error, spreadsheetWorkbook.GetPresentation());
            }

            if ("Object reference not set to an instance of an object".Equals(e.Message)
                && StackTraceContains(e, "vLookup"))
                return new ErrorResult(formulaName, "Missing Lookup Table", spreadsheetWorkbook.GetPresentation());
            if ("No matches found".Equals(e.Message))
            {
                var error = parseNoMatchException(e, formulaName);
                return new ErrorResult(formulaName, error, spreadsheetWorkbook.GetPresentation());
            }

            return new ErrorResult(formulaName, e.Message, spreadsheetWorkbook.GetPresentation());
        }

        private bool StackTraceContains(Exception e, string message)
        {
            foreach (var ste in e.StackTrace)
                if (ste.ToString().Contains(message))
                    return true;
            return false;
        }

        private string parseNoMatchException(Exception e, string formulaName)
        {
            if (e.GetType() == typeof(SpreadsheetException))
            {
                var we = (SpreadsheetException) e;
                return "No match found for token [" + we.Token+ "] related to formula '" + formulaName + "'.";
            }

            return e.Message;
        }

        private string parseCircularReferenceException(Exception e, string formulaName)
        {
            if (e.GetType() == typeof(SpreadsheetException))
            {
                var we = (SpreadsheetException) e;
                return "Circular Reference in spreadsheet related to formula '" + formulaName + "'. Cells: " +
                       we.Cells;
            }

            return e.Message;
        }
    }
}