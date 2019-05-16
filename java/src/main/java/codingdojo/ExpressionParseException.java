package codingdojo;

public class ExpressionParseException extends Exception {
    public ExpressionParseException() {
        this("Expression parsing problem");
    }

    public ExpressionParseException(String message) {
        super(message);
    }
}
