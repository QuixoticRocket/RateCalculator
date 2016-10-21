
Initial thoughts, ideas and assumptions approaching this task:

We will want to have things separated out and extensible. So we'll have the calulation and file handlers split off behind interfaces & projects,
 just in case we want to change our datasource in future or add a different calculation into the mix in the future.
We will want some logging and will split this off behind an interface too, but it will be a simple file logging for now (very optimistic file logging not wasting time with permission checks etc)

If we use a factory method to return the 36 month loan calculation we can always add other calculations easily in the future. 
 Will we need an abstract base calculation class? Perhaps. Would all calculations share some inheret base logic? It's likely.
 We could have each calulation a separate project to the calulator and leave the calculator simply to organise the creation and return of the calculations, 
  but this would only really be useful if we had to switch calulations out based on different environments (or different country deployments etc). 
  While this might be the case in your real business, I'm going to assume for this project that we won't need to do that.

We're going to need to handle files without headings and files with missing / null data and empty lines / negative amounts or rates
We will also need to handle bad input and the following edge cases:
  negative amount requested / amount requested greater than we can accomodate with the input we have
  negative rates / negative availability / missing rates / missing availability

I'm assuming the available column is the amount of money available from the particular lender and that we will be building up a loan made from multiple lenders.
I also assume that we can part loan on this amount and don't need to take the full amount from the lender (if for example the best rate is from someone with an available of 1000 and we only want 200 we can still use them)
We are not recording if the user takes the loan or not and so are not updating the file (reducing the available amounts)

Responsibility for clean data from the file should rest with the file handler. We will read the file, scrub the data and create a collection of lender objects which will be the return.
The rest of the program doesn't care where the data comes from so we will handle this as a lender data source (other than passing a filename in no other file specific references should be made)
If we discover bad data with a lender (negative or missing rates or availability) then we will not include that lender (we will log the issue to an error log)
I will be reading the entire file into memory and dealing with it there as I'm assuming we will not be feeding in huge files,
 and any real adaption of this would be pulling in the data from a db based on a subselection query to keep the number of in-memory objects low and performant. 

We will want unit tests and a mocking framework.
Depending on the size of the project, unit tests would normally be broken out into tests for each major section, but for this soution we'll use one project for all unit tests.

Interfaces and utilities will live in a shared dll.

Any configuration values required (although none stand out at first read) will go into a public static class. 
We would normally use ConfigurationManager & config files, or a db query to retreive them (and possiblt caching) but for simplicity and time's sake I'll go with the simpler option for now.

We would usually be using something like Autofac to create IoC containers, but we're keeping things simple and manual for this. 
 If this were production code we'd have config variable for environments setting things such as which lender loader to use and the appropriate settings for that loader.

I assume we calculate the total amount required to be paid back by the end of the loan and then divide by the number of months to get the monthly repayments,
 and we're not providing information about early repayment etc.

--

The happy path through the code will be: 
  Console app receives arguments. 
  Creates a LoanCalculator with those arguments. 
  The calculator will create a filereader and then uses the factory to get back the appropriate calculation, and then uses the calculation to compute the result, which it returns.
  A logger will dump any errors to an error txt log file (this is simplistic and error prone, but keeping things simple for the test. we could use something like log4net or nlog to do this)