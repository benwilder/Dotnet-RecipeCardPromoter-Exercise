# Dotnet-RecipeCardPromoter-Exercise

Here at Food-Tech-API Ltd we've got a problem, and we need your help! 

We're building a demo to present to a small supermarket chain, that can show recommended recipe cards to shoppers, at the checkout, based on what they have purchased in their basket. It's early stages, but we've lost our senior software engineer during product research - they we're last seen in the confectionary isle...

The repo is in a bit of a state, there are bugs, code smells, failing tests and a few features we really need to fix up before we can show a basic working example...

## How to help

The project is a .net webapi (6.0) in C# with an Xunit testing project. Coverlet is used to produce code coverage reports.

Coverage reports will need to be available in the following location:
```sh
Dotnet-RecipeCardPromoter-Solution/RecipeCardPromoter.Tests/coverage.opencover.xml
```

### You'll need to:
* clone this repo
* make sure you can build and test
* undertake the tasks in the next section
* push the repo up to a public repo in your account and share the location with us

### What we need from the MVP:

The MVP for demo needs to:

* When the "Search" GET endpoint is called with a number of ingredients:
    * Return a list of recipe cards that have >0 matching ingredients
    * Make sure that the ingredients are dealt with in a case insensitive fashion
    * Return the list of recipe cards in order of number of matching ingredients, with cards that have more matches, coming first (num of matches, descending)

We need you to do the following on the codebase:
* please identify and fix any code smells you see 
* please fix any bugs and or duplication you can spot
* please fix the unit test(s) that are failing
* please add functionality in for case insensitive searching
* please add functionality in for ordering returned recipe cards
* Add a unit test in to check case insensitve searches
* Add a unit test in to check ordered results
* Attempt to get to as close to 100% code test coverage as you can

### How to submit

Please push the repo up to a public repo, add the project to your showcode profile and click "submit for checking"

### What we'll do next

We'll run a number of checks and get back to you with our report - thanks very much in advance for your help!