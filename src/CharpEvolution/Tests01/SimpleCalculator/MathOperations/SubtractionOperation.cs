﻿using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;

namespace CsharpEvolution.Tests01.SimpleCalculator.MathOperations;

public class SubtractionOperation : IOperation
{
    public long Calculate(long numOne, long numTwo)
    {
        return numOne - numTwo;
    }
}
