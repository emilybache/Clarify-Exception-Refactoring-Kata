using ApprovalTests;
using System;
using ApprovalTests.Reporters;
using Xunit;

namespace codingdojo
{
    [UseReporter(typeof(DiffReporter))]
    public class MessageEnricherTest
    {
        [Fact]
        public void SampleTest()
        {
            var enricher = new MessageEnricher();

            var worksheet = new SpreadsheetWorkbook();

            var e = new Exception("Terrible problem");

            var actual = enricher.EnrichError(worksheet, e);

            Approvals.Verify(actual);
        }
    }
}