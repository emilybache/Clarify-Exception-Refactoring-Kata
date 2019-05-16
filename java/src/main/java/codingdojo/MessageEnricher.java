package codingdojo;


public class MessageEnricher {

    public ErrorResult enrichError(SpreadsheetWorkbook spreadsheetWorkbook, Exception e) {

        String formulaName = spreadsheetWorkbook.getFormulaName();

        if (e instanceof ExpressionParseException) {
            String error = "Invalid expression found in tax formula [" + formulaName + "]. Check that separators and delimiters use the English locale.";
            return new ErrorResult(formulaName, error, spreadsheetWorkbook.getPresentation());
        }
        if (e.getMessage().startsWith("Circular Reference")) {
            String error = parseCircularReferenceException(e, formulaName);
            return new ErrorResult(formulaName, error, spreadsheetWorkbook.getPresentation());
        }
        if ("Object reference not set to an instance of an object".equals(e.getMessage())
                && stackTraceContains(e,"vLookup")) {
            return new ErrorResult(formulaName, "Missing Lookup Table", spreadsheetWorkbook.getPresentation());
        }
        if ("No matches found".equals(e.getMessage())) {
            String error = parseNoMatchException(e, formulaName);
            return new ErrorResult(formulaName, error, spreadsheetWorkbook.getPresentation());

        }


        return new ErrorResult(formulaName, e.getMessage(), spreadsheetWorkbook.getPresentation());
    }

    private boolean stackTraceContains(Exception e, String message) {
        for (StackTraceElement ste : e.getStackTrace()) {
            if (ste.getMethodName().contains(message)) {
                return true;
            }
        }
        return false;
    }

    private String parseNoMatchException(Exception e, String formulaName) {
        if (e instanceof SpreadsheetException) {
            SpreadsheetException we = (SpreadsheetException) e;
            return "No match found for token [" + we.getToken() + "] related to formula '" + formulaName + "'.";
        }
        return e.getMessage();
    }

    private String parseCircularReferenceException(Exception e, String formulaName) {
        if (e instanceof SpreadsheetException) {
            SpreadsheetException we = (SpreadsheetException) e;
            return "Circular Reference in spreadsheet related to formula '" + formulaName + "'. Cells: " + we.getCells();
        }
        return e.getMessage();
    }
}
