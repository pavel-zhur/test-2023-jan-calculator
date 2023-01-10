﻿using System.Text;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

/// <summary>
/// A division operation.
/// </summary>
public class Division : OperationBase
{
    private readonly OperationBase _operand1;
    private readonly OperationBase _operand2;

    /// <summary>
    /// Creates a new <see cref="Division"/> operation instance.
    /// </summary>
    /// <param name="operand1">The left operand.</param>
    /// <param name="operand2">The right operand.</param>
    public Division(OperationBase operand1, OperationBase operand2)
    {
        _operand1 = operand1 ?? throw new ArgumentNullException(nameof(operand1));
        _operand2 = operand2 ?? throw new ArgumentNullException(nameof(operand2));
    }

    protected override double Calculate() => _operand1.ToResult() / _operand2.ToResult();

    protected override void AppendSentence(StringBuilder stringBuilder)
    {
        stringBuilder.Append("division of ");
        AppendSentence(stringBuilder, _operand1);
        stringBuilder.Append(" by ");
        AppendSentence(stringBuilder, _operand2);
    }

    protected override void AppendMath(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        appendChild(_operand1);
        stringBuilder.Append(" / ");
        appendChild(_operand2);
    }
}