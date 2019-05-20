using System;
using Xunit;

namespace StarterProject
{
    public class MessageEnricherTest
    {
        [Fact]
        public void SampleTest()
        {
            var enricher = new MessageEnricher();

            var worksheet = new SpreadsheetWorkbook();

            var e = new Exception("Terrible problem");

            var actual = enricher.EnrichError(worksheet, e);

            Assert.Equal("Fixme", actual.GetMessage());
        }
    }
}