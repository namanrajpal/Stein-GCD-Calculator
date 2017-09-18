using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GCDCalculator : MonoBehaviour
{

    public InputField setAField;
    public InputField setBField;
    public Text errortxt;
    public Text answertxt;
    string setA;
    string setB;
    int[] _setA;
    int[] _setB;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CalculateGCD()
    {
        setA = setAField.text;
        setB = setBField.text;
        errortxt.text = "";
        answertxt.text = "";

        Debug.Log("Found:" + setA + " " + setB);
        string[] setAchar = setA.Split(null);
        string[] setBchar = setB.Split(null);

        if (setAchar.Length != setBchar.Length)
        {
            //Error
            errortxt.text = "Size of both the sets should be equal";
            return;
        }
        else
        {
            _setA = new int[setAchar.Length];
            _setB = new int[setBchar.Length];
        }

        for (int i = 0; i < setAchar.Length; i++)
        {
            _setA[i] = 0;
            if (int.TryParse(setAchar[i], out _setA[i]))
            {
                // Code for if the string was valid
            }
            else
            {
                errortxt.text = "Set A has invalid number";
            }

            _setB[i] = 0;
            if (int.TryParse(setBchar[i], out _setB[i]))
            {
                // Code for if the string was valid
            }
            else
            {
                errortxt.text = "Set B has invalid number";
            }
        }
        string answer;
        answer = "Answer : \n";

        for (int j = 0; j < setAchar.Length; j++)
        {
            answer += "GCD for " + _setA[j] + " and " + _setB[j] + "is: " + Gcd(_setA[j], _setB[j]) + "\n";
        }

        answertxt.text = answer;

    }

    public int Gcd(int a, int b)
    {
        int shift;

        if (a == 0) return b;
        if (b == 0) return a;

        for (shift = 0; ((a | b) & 1) == 0; ++shift)
        {
            a >>= 1;
            b >>= 1;
        }

        while ((a & 1) == 0)
            a >>= 1;

        do
        {
            while ((b & 1) == 0) /* Loop X */
                b >>= 1;

            if (a > b)
            {
                var t = b;
                b = a;
                a = t;
            }
            b = b - a;
        } while (b != 0);

        return a << shift;
    }


}









