# A test task: a calculator.

This is a test task for one of the .net developer vacancies.
I don't publish the task definition as I think they wouldn't be happy with that.

## Solution structure

+ Test.Calculator - a library
+ Test.Calculator.Tests - the unit tests (MSTest)
+ Test.Calculator.App - a test app

## Design Decisions

### Lazy calculation

I've decided to go with the lazy calculation, because otherwise I would have to do CPU-heavy work in the constructors, which is generally not recommended.

### Different naming

Although you the required names method names were `.toResult()`, `.print()`, `.printSentence()`, I've decided to go with `.ToResult()`, `.Print()`, `.PrintSentence()` to align with the recommended naming conventions for .net.

### Not handling division by zero in the `.ToResult()` and `.Print()`

It was required to use the `double` type. In this type, the division by zero and other is a valid operation that returns `double.PositiveInfinity`. So I thought since the return type is a `double`, returning the `double.PositiveInfinity` would be valid.

### Handling various maths corner cases in the `.PrintSentence()`

However, I do handle the subnormal results and other corner cases in the `.PrintSentence()` correctly, since that operation returns a readable message intended for people.
The cases handled are:
- positive infinity
- negative infinity
- not a number (NaN)
- too small number (less than the `double.Epsilon`)
- too large number (larger than the `double` range)

The `.PrintSentence()` returns a meaningful message for them.

### `Fraction` accepts only doubles

Since the `Fraction` is printed in the `.PrintSentence()` as x/y, it would not be possible to do print it correctly if it accepted other Operations as parameters. And it would make it almost indistinguishable from the `Division`.

So I assumed the goal of the `Fraction` is to represent a numeric constant in a fraction format, mainly to display it on printing in a readable way.

Which led me to a decision to not accept other operations in the `Fraction` operation.

### A `Constant` operation

I introduced a `Constant` operation for one reason:
- It is convenient for other operations to process their operands regardless whether they are numerics or nodes. It allowed me to save lots of code lines.

It also allowed me to have a nice bonus:
- `Sum` and `Multiplication` operations now support more than two operands.

However, there is one drawback to that:
- I had to introduce the `OperationBase.AddParenthesesOnPrinting` virtual property that is `true` for all operations but overriden to `false` in the `Constant`.

### The library is extensible

I've taken care of the consumers to allow them extend the library, and I have provided an example of that: `Test.Calculator.App.Logarithm`.

### Passing the `appendChild` action parameter to the abstract `OperationBase.AppendSentence` and `OperationBase.AppendMath` methods

Passing it as a parameter is not a beautiful way. 
However I did not want to make `AppendMathWithParentheses` and `AppendSentence` public (those are right now private), since they are only needed for the internal use in the library.
And since I intended to make the library extensible, I could not make those methods `protected` or `protected internal` either (it would not work: since the `OperationBase` is a universal type for the arguments, the children wouldn't be able to call those).
So I decided to hide the implementation details from the users of the library and pass this recursive action as a delegate.

### General design approach

- All public methods of the library are documented
- Null safety checked correctly
- Exceptions are handled
- Unit tests are written
- Negative tests exist
- Edge values of `double` are handled
- Exceptions thrown have meaningful messages
- A user is able to extend the library, an example provided

## Output example

The output of the Test.Calculator.App:

```
A normal expression example:
(2 + (((6 / 2) * 2)!)) = 722
sum of 2 and faculty of multiplication of division of 6 by 2 and 2 is 722

A subnormal result example:
(2 + (3 / 0)) = ∞
sum of 2 and division of 3 by 0 could not be calculated precisely, the result value is too high. A division by zero is probable.

An exception example:
(((5 / 2) * 2)!) = 120
faculty of multiplication of division of 5 by 2 and 2 is 120

A known bug example:
((5.6 + 5.8) - 0.4) = 10.999999999999998
sum of 5.6 and 5.8 minus 0.4 is 10.999999999999998

A custom operation example:
(3 + (9 log (6/2))) = 5
sum of 3 and logarithm of 9 to the base 6/2 is 5
```

## Usage

### Testing the code

- Clone the repository
- Open it in the Visual Studio
- Run the tests or run the `Test.Calculator.App` app
- Extend those to check your own expressions

### Using the code if you ever need to

Normally, I would publish the library as a nuget package, but it's just a test task, so:

- Copy the `Test.Calculator` and `Test.Calculator.Tests` to your solution
- Reference and use them

## Thanks
Thank you for taking your time reading this and have a good day :)
