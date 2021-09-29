# FizzBuzz

A .NET Core web application which populates a table in a database with the numbers 1 to 100 but substitutes some numbers as per the rules below:

- Where any number is a multiple of 3, replace the number with the word "Fizz".
- Where any number is a multiple of 5, replace the number with the word "Buzz". 
- For numbers which are multiples of both 3 and 5, replace with the word "FizzBuzz". 

It then displays this data on a webpage Using the Razor Pages framework.


----

### How to run (Visual Studio)
1. Once you have cloned the rep on your local machine, open Visual Studio
2. In the welcome page, click on `Open a project or solution`
3. Then navigate to the root folder, `FizzBuzz` and open it.
4. Select and open the solution file, `FizzBuzz.sln`.
5. On the right, in the solution explorer, navigate to the packages inside the dependecies for the project and ensure you have all of them installed and up to date
6. Once installed, press F5 to run the solution or click on `IIS Express` next to the green play button on top
7. A webpage will open up, navigate to the `Custom Numbers` tab using the navigation bar to view all the customised numbers


--- 

### Data Model
For the database, I have created a model schema, `Custom Number`. This has 2 fields, a number field and a value field (+ the ID). 

Number(int):    The original numbers from 1-100 \
Value(string):  The customised numbers using the rules stated above

On the `Custom Numbers` page, both of these values are displayed.

` Note: The number field is used to sort the table in ascending order before displaying `



