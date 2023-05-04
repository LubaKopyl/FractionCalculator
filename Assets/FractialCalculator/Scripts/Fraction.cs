using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraction : MonoBehaviour
{
	private int _numerator;
	private int _denominator;

	public Fraction(int theNumerator, int theDenominator)
	{
		_numerator = theNumerator;
		_denominator = theDenominator;
	}

	public int Numerator
	{
		get
		{
			return _numerator;
		}
	}

	public int Denominator
	{
		get
		{
			return _denominator;
		}
	}
	
	private int GCD(int a, int b)
	{
		if (a == 0)
            return b;
 
        return GCD(b % a, a);
	}

	public Fraction Reduce(int numerator, int denominator)
	{
		if (numerator < 0 && denominator < 0)
		{
			numerator *= -1;
			denominator *= -1;

		}
		else if (numerator > 0 && denominator < 0)
		{
			numerator *= -1;
			denominator *= -1;
		}	

		int a = GCD(numerator, denominator);
		
		numerator = numerator / a;
		denominator = denominator / a;

		return new Fraction(numerator, denominator);
	}

	public Fraction Divide(Fraction fraction1, Fraction fraction2)
	{
		return new Fraction((fraction1.Numerator * fraction2.Denominator), (fraction2.Numerator * fraction1.Denominator));

	}

	public Fraction Multiply(Fraction fraction1, Fraction fraction2)
	{
		int newNum = fraction1.Numerator * fraction2.Numerator;
		int newDen = fraction1.Denominator * fraction2.Denominator;
		return new Fraction(newNum, newDen);
	}

	public Fraction Subtract(Fraction fraction1, Fraction fraction2)
	{
		return new Fraction(((fraction1.Numerator * fraction2.Denominator) - (fraction2.Numerator * fraction1.Denominator)),
			(fraction1.Denominator * fraction2.Denominator));
	}

	public Fraction Add(Fraction fraction1, Fraction fraction2)
	{
		Fraction result = new Fraction((fraction1.Numerator * fraction2.Denominator) + (fraction2.Numerator * fraction1.Denominator),
								fraction1.Denominator * fraction2.Denominator);
		
		return result;
	}
}