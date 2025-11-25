using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class CustomExeptionClass : Exception
    {
      

public class NumberFormatException : Exception
    {
        public NumberFormatException(string varName) : base($"Invalid number format for: {varName}") { }
    }

    public class StringFormatException : Exception
    {
        public StringFormatException(string varName) : base($"Invalid string format for: {varName}") { }
    }

    public class CurrencyFormatException : Exception
    {
        public CurrencyFormatException(string varName) : base($"Invalid currency format for: {varName}") { }
    }
        

        }


    }