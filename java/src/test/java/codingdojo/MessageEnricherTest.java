package codingdojo;

import org.approvaltests.Approvals;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.Arrays;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class MessageEnricherTest {

    @Test
    void sampleTest() {
        MessageEnricher enricher = new MessageEnricher();
        SpreadsheetWorkbook worksheet = new SpreadsheetWorkbook();
        Exception e = new RuntimeException("Terrible problem");
        ErrorResult actual = enricher.enrichError(worksheet, e);
        assertEquals("Fixme", actual.getMessage());
    }

}
