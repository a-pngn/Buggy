﻿using System;

namespace FEEESample1
{
    // |Method Table (4 byte)|Size (4 byte)|data[0]|data[1]|data[2]|data[3]|...
    // Fatal Execution Engine Error caused by array size corruption
    class Program
    {
        static void Main(string[] args)
        {
            var buf = new uint[4] { 0xAAAAAAAA, 0xBBBBBBBB, 0xCCCCCCCC, 0xDDDDDDDD };
            Foo(buf);
            GC.Collect();
        }

        unsafe static void Foo(uint [] buf)
        {
            fixed (uint* p = &buf[0])
            {
                *(p - 1) = 0xEEEEEEEE;
            }
        }
    }
}
