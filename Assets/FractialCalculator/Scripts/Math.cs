using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Math : MonoBehaviour
{
    public int numerator1 = 0;
	public TMP_InputField InputNumerator1;
	public int denominator1 = 0;
	public TMP_InputField InputDenominator1;
	public int numerator2 = 0;
	public TMP_InputField InputNumerator2;
	public int denominator2 = 0;
	public TMP_InputField InputDenominator2;
	public TMP_InputField ResultNumerator;
	public TMP_InputField ResultDenominator;
	Fraction result;
	public Fraction fraction1;
	public Fraction fraction2;
	public Fraction _Fraction;
	private string _operation;


	public void ClickEquals()
	{

		CreateFractions();

		if (NullCheck(fraction1, fraction2) == false)
		{
			switch (_operation)
            {
                case "+":
                    result = _Fraction.Add(fraction1, fraction2);
					result = _Fraction.Reduce(result.Numerator, result.Denominator);
					ResultNumerator.text = result.Numerator.ToString();
					ResultDenominator.text = result.Denominator.ToString();
                    break;

                case "-":
                    result = _Fraction.Subtract(fraction1, fraction2);
					result = _Fraction.Reduce(result.Numerator, result.Denominator);
					ResultNumerator.text = result.Numerator.ToString();
					ResultDenominator.text = result.Denominator.ToString();
                    break;

                case "*":
                    result = _Fraction.Multiply(fraction1, fraction2);
					result = _Fraction.Reduce(result.Numerator, result.Denominator);
					ResultNumerator.text = result.Numerator.ToString();
					ResultDenominator.text = result.Denominator.ToString();
                    break;

                case "/":
                    result = _Fraction.Divide(fraction1, fraction2);
					result = _Fraction.Reduce(result.Numerator, result.Denominator);
					ResultNumerator.text = result.Numerator.ToString();
					ResultDenominator.text = result.Denominator.ToString();
                    break;
            } 
		}
		else
		{
			Debug.Log($" The numerator or denominator cannot be zero!");
		}
	}

	public void CreateFractions()
	{
		numerator1 = int.Parse(InputNumerator1.text);
		denominator1 = int.Parse(InputDenominator1.text);
		fraction1 = new Fraction(numerator1, denominator1);

		numerator2 = int.Parse(InputNumerator2.text);
		denominator2 = int.Parse(InputDenominator2.text);
		fraction2 = new Fraction(numerator2, denominator2);
	}

	private bool NullCheck(Fraction fraction1, Fraction fraction2)
	{
		if (fraction1.Numerator == 0 || fraction1.Denominator == 0 || fraction2.Numerator == 0 || fraction2.Denominator == 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void clickOperation(string val){
		Debug.Log($" ClickOperation val: {val}");
		_operation=val;
	}
}