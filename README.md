Clarify Exception Refactoring Kata
==================================

This is a refactoring exercise starting point. Focus on improving the code in the MessageEnricher class.

Note there is a branch 'with_tests' if you'd like to go straight to doing the refactoring and skip writing tests yourself.

The Scenario
------------

You are working on an application for tax calculations. Your users upload a spreadsheet containing some formulas, lookup tables, and raw data. Your software reads the spreadsheet and processes it using a proprietary library. If the user has made any mistakes in their spreadsheet, the proprietary library produces an exception. These exceptions are quite hard for the user to interpret. This piece of code that you have here, is designed to clarify the exception. The 'enrichError' method is responsible for doing this. It will take the exception produced by the proprietary library, and return it to the user as an "ErrorResult" with an enriched message that they will hopefully understand.

You can change the code and improve it, but don't change the signature of the 'enrichError' method. The rest of the system (not included here) relies on it.

The New Feature
---------------

The users have come to you complaining they don't understand when they get the message "Missing Formula", when they are sure the formula is not missing. You identify that this happens when the proprietary spreadsheet library has thrown a SpreadsheetException because some cells are merged that shouldn't be merged. The clarified message the user would like to see is:

	"Invalid expression found in tax formula [" + formulaName +
                            "]. Check for merged cells near " + cells;

(The formulaName in the above message is one of the input parameters to the method for enriching the error message, and the cells are the ones held as a datamember in the SpreadsheetException.)

Your task is to refactor the code to make adding this new feature as easy as possible. The finished code including the new feature should be easy to maintain for subsequent developers, and contain minimal duplication.
