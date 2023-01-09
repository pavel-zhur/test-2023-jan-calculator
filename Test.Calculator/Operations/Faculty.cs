﻿using Test.Calculator.Exceptions;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

public class Faculty : OperationBase
{
    private readonly OperationBase _operand;

    public Faculty(OperationBase operand)
    {
        _operand = operand;
    }

    protected override double Calculate()
    {
        var doubleOperand = _operand.ToResult();

        if (doubleOperand < 0)
        {
            throw new NegativeFactorialException(doubleOperand);
        }

        if (doubleOperand is double.PositiveInfinity)
        {
            return doubleOperand;
        }

        if (double.IsNaN(doubleOperand))
        {
            return doubleOperand;
        }

        ushort intOperand;

        try
        {
            intOperand = Convert.ToUInt16(doubleOperand);
        }
        catch (OverflowException) // the value is greater than the Int16.MaxValue
        {
            // this case is exception-handled later
            return double.PositiveInfinity;
        }

        if (intOperand != doubleOperand) // not an integer
        {
            throw new NonIntegerFactorialException(doubleOperand);
        }

        return Enumerable.Range(1, intOperand).Aggregate(1d, (x, y) => x * y);
    }
}