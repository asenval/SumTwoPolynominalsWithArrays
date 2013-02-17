using System;
using System.Text;

public class SumTwoPolynominalsWithArrays
{
    static void Main()
    {
        SumTwoPolynominalsWithArrays SP = new SumTwoPolynominalsWithArrays();
        Console.WriteLine("Enter first polynomial for example 4x4-x2+3x-5:");
        string polynomial1 = Console.ReadLine();
        Console.WriteLine("Enter second polynomial:");
        string polynomial2 = Console.ReadLine();
        //
        //   OR
        //
        //string polynomial1 = "4x4-x2+3x-5";
        //string polynomial2 = "8x3-2x2+2x+3";
        //
        int[] pArray1 = SP.SeparatePolinomialToArray(polynomial1);
        int[] pArray2 = SP.SeparatePolinomialToArray(polynomial2);
        int[] result = new int[pArray1.Length];
        string str;
        result = SP.SumPolinomials(pArray1, pArray2);
        str = SP.TransvereArrayToPolinomial(result);
        Console.WriteLine(str);
    }

    public int[] SumPolinomials(int[] pArray1, int[] pArray2)
    {
        int[] result = new int[pArray1.Length];        
        for (int i = 0; i < pArray1.Length; i++)
        {
            result[i] = pArray1[i] + pArray2[i];
        }       

        return result;
    }
    public string TransvereArrayToPolinomial(int[] result)
    {
        string str = "";
        for (int i = result.Length - 1; i > 0; i--)
        {
            if (result[i] != 0)
            {
                if (result[i] > 0)
                {
                    str += "+";
                }
                if (str == "+")
                {
                    str = "";
                }
                if (result[i] != 1)
                {
                    str += result[i];
                }
                str += "x";
                if (i > 1)
                {
                    str += i;
                }
            }
        }
        str += result[0];
        return str;
    }

    public int[] SeparatePolinomialToArray(string polynomial)
    {
        int[] PArray = new int[10];
        string str;
        string[] strArray = new string[10];
        int count = 0;
        int i = 0;
        while (polynomial != "")
        {
            str = polynomial.Substring(i, 1);
            if (str == "+" || str == "-")
            {
                strArray[count] = polynomial.Substring(0, i);
                polynomial = polynomial.Substring(i);
                count++;
                i = 0;
            }
            if (i >= polynomial.Length -1)
            {
                strArray[count] = polynomial;
                polynomial = "";
            }
            i++;
        }
        Array.Reverse(strArray);
        for (int j = 0; j < strArray.Length; j++)
        {
            if (strArray[j] != null)
            {
                for (int k = 0; k < strArray[j].Length; k++)
                {
                    str = strArray[j].Substring(k, 1);
                    if (str == "x" || str == "X")
                    {
                        if (k == strArray[j].Length - 1)
                        {
                            PArray[1] = Convert.ToInt32(strArray[j].Substring(0, k));
                        }
                        else
                        {
                            if(strArray[j].Substring(0, k) == "-")
                            {
                            PArray[Convert.ToInt32(strArray[j].Substring(k+1))] = -1;
                            }
                            else if (strArray[j].Substring(0, k) == "+")
                            {
                                PArray[Convert.ToInt32(strArray[j].Substring(k + 1))] = 1;                                
                            }
                            else
                            {
                                PArray[Convert.ToInt32(strArray[j].Substring(k + 1))] = Convert.ToInt32(strArray[j].Substring(0, k));
                            }
                        }
                        break;
                    }
                    if (k == strArray[j].Length-1)
                    {
                        PArray[0] = Convert.ToInt32(strArray[j]);
                    }
                }
            }
        }
        return PArray;
    }
}
