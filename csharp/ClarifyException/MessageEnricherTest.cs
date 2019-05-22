using System;
using System.Collections.Generic;
using Xunit;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace codingdojo
{
    [UseReporter(typeof(DiffReporter))]
    public class MessageEnricherTest
    {
        private Exception VLookup()
        {
            throw new Exception("Object reference not set to an instance of an object");
        }

        [Fact]
        private void CircularReference()
        {
            var enricher = new MessageEnricher();
            var worksheet = new SpreadsheetWorkbook();

            Exception e = new SpreadsheetException("Circular Reference", new List<string> { "C4", "C5" }, null);

            Approvals.Verify(enricher.EnrichError(worksheet, e));
        }

        [Fact]
        private void CircularReferenceWrongException()
        {
            var enricher = new MessageEnricher();
            var worksheet = new SpreadsheetWorkbook();

            var e = new Exception("Circular Reference");

            Approvals.Verify(enricher.EnrichError(worksheet, e));
        }

        [Fact]
        private void ExpressionParseException()
        {
            var enricher = new MessageEnricher();
            var worksheet = new SpreadsheetWorkbook();

            Exception e = new ExpressionParseException();

            Approvals.Verify(enricher.EnrichError(worksheet, e));
        }


        [Fact]
        private void NoEnrichmentNeeded()
        {
            var enricher = new MessageEnricher();
            var worksheet = new SpreadsheetWorkbook();

            var e = new Exception("Terrible problem");

            Approvals.Verify(enricher.EnrichError(worksheet, e));
        }

        [Fact]
        private void NoMatchesFound()
        {
            var enricher = new MessageEnricher();
            var worksheet = new SpreadsheetWorkbook();

            Exception e = new SpreadsheetException("No matches found", null, "Missing Token");

            Approvals.Verify(enricher.EnrichError(worksheet, e));
        }

        [Fact]
        private void NoMatchesFoundWrongException()
        {
            var enricher = new MessageEnricher();
            var worksheet = new SpreadsheetWorkbook();

            var e = new Exception("No matches found");

            Approvals.Verify(enricher.EnrichError(worksheet, e));
        }

        [Fact]
        private void ObjectReferenceNotSet()
        {
            var enricher = new MessageEnricher();
            var worksheet = new SpreadsheetWorkbook();

            try
            {
                VLookup();
            }
            catch (Exception e)
            {
                Approvals.Verify(enricher.EnrichError(worksheet, e));
            }            
        }

        [Fact]
        private void ObjectReferenceNotSetButStacktraceNotLookupTableProblem()
        {
            var enricher = new MessageEnricher();
            var worksheet = new SpreadsheetWorkbook();

            try
            {
                throw new Exception("Object reference not set to an instance of an object");
            }
            catch (Exception e)
            {
                Approvals.Verify(enricher.EnrichError(worksheet, e));
            }
        }
    }
}