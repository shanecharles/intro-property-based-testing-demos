using System;
using System.Collections.Generic;

namespace ComplexType
{
    public enum RiskFactor
    {
        None,
        Low,
        Average,
        High
    }

    public class Person 
    {
        public Person(string name, int age, RiskFactor risk)
        {
            Name = name;
            Age = age;
            RiskFactor = risk;
        }
        public string Name { get; }
        public int Age { get; }
        public RiskFactor RiskFactor { get; }
    }
}