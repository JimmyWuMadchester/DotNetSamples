/* 
 * Fast doubling Fibonacci algorithm (C#)
 * 
 * Copyright (c) 2016 Project Nayuki
 * All rights reserved. Contact Nayuki for licensing.
 * https://www.nayuki.io/page/fast-fibonacci-algorithms
 */

using System;
using System.Numerics;


/*
 * Run with a single number argument. Example:
 *   Command: fastfibonacci.exe 7
 *   Output: "fibonacci(7) = 13"
 */
public sealed class Fibonacci {
	
	public static int Main(string[] args) {
		if (args.Length != 1) {
			Console.WriteLine("Usage: fastfibonacci.exe N");
			return 1;
		}
		int n = int.Parse(args[0]);
		if (n < 0) {
			Console.WriteLine("Number must be non-negative");
			return 1;
		}
		Console.WriteLine("fibonacci({0}) = {1}", n, FibonacciFastDoubling(n));
		return 0;
	}
	
	
	// Fast doubling algorithm
	private static BigInteger FibonacciFastDoubling(int n) {
		BigInteger a = BigInteger.Zero;
		BigInteger b = BigInteger.One;
		for (int i = 31; i >= 0; i--) {
			BigInteger d = a * (b * 2 - a);
			BigInteger e = a * a + b * b;
			a = d;
			b = e;
			Console.WriteLine($"i = {i}");
			Console.WriteLine($"a = {a}");
			Console.WriteLine($"b = {b}");
			Console.WriteLine($"c = {a+b}");			
			Console.WriteLine($"d = {d}");
			Console.WriteLine($"e = {e}");
			Console.WriteLine($"a = {b}");
			Console.WriteLine($"b = {a+b}");
			Console.WriteLine($"(uint)n >> i = {(uint)n >> i}");
			if ((((uint)n >> i) & 1) != 0) {	// If n is odd number
				BigInteger c = a + b;
				a = b;
				b = c;
			}
		}
		return a;
	}
	
	// Recursive fast doubling
	// converted from Nayuki's Python code
	private static Tuple<BigInteger, BigInteger> FibonacciFastDoublingRecursive(int n) {
		if (n == 0){
			return Tuple.Create(BigInteger.Zero, BigInteger.One);
		}
		else{
			var fibHalfN = FibonacciFastDoublingRecursive(n/2);

			var fibN = fibHalfN.Item1 * (fibHalfN.Item2 * 2 - fibHalfN.Item1);
			var fibNPlusOne = fibHalfN.Item1 * fibHalfN.Item1 + fibHalfN.Item2 * fibHalfN.Item2;
			if (n%2 == 0){
				return Tuple.Create(fibN, fibNPlusOne);
			}
			else{
				return Tuple.Create(fibNPlusOne, fibN + fibNPlusOne);
			}
		}
	}
}