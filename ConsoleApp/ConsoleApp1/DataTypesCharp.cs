using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;
public class DataTypesCharp
{
    public Byte MinValue = 0;
    public Byte MaxValue = 255;

    // -128 to 127
    public SByte MinValueSByte = -128;
    public SByte MaxValueSByte = 127;
    public DataTypesCharp()
    {

         string s = "Hello World";

        short num1 = 123; // 16 bit
        int num2 = 123; // 32 bit
        long num3 = 123; // 64 bit

        Single a = 1.23f;  // 4 bytes
        float a2 = 1.23f;

        Double b = 1.233; // 8 bytes
        Decimal c = 1.23m; // 16 bytes


        var x1 = 10;
        var y1 = 20.5f;

    }
}

/*

1) UTF, or Unicode Transformation Format, a variable-length character encoding used to represent the characters in the Unicode character set
UTF-8, has become the standard character encoding 
ASCII compatibility: UTF-8 is fully backward-compatible with ASCII, meaning any plain ASCII text is also valid UTF-8

Value Types:
Integral Numeric Types:
        - byte, 8-Bit unsigned integer
        - sbyte,
        - short, ushort, int, uint, long, ulong.

    Floating-Point Numeric Types: 
        - decimal. 
        - decimal offers higher precision and is typically used for financial calculations.
    
    Boolean Type
    Character Type
    Struct Types: 
        - User-defined value types that can encapsulate data and related functionality.
    
    Enum Types: User-defined types consisting of a set of named constants.


2) 
Reference types: are allocated on the heap.
    String Type: unicode of characters
    Dynamic Type

    Interface Type
    Delegate Type
    Object typex : base type of all types in C#.
    Class Type : Blueprint for creating objects, encapsulating data and behavior.
    Array Types : Store a collection of elements of the same type.


3) 
Pointer Types:
int*, char*

 */