package codingdojo;

public class ErrorResult {
    private final String formulaName;
    private final String message;
    private final String presentation;

    public ErrorResult(String formulaName, String message, String presentation) {

        this.formulaName = formulaName;
        this.message = message;
        this.presentation = presentation;
    }

    @Override
    public String toString() {
        return "ErrorResult{" +
                "formulaName='" + formulaName + '\'' +
                ", message='" + message + '\'' +
                ", presentation='" + presentation + '\'' +
                '}';
    }

    public String getFormulaName() {
        return formulaName;
    }

    public String getMessage() {
        return message;
    }

    public String getPresentation() {
        return presentation;
    }
}
