using System.Diagnostics;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using CsVectorization;

// var b = new Normal();
// b.Setup();
// Console.WriteLine("Starting: ");
// var sw = Stopwatch.StartNew();
// Console.WriteLine(b.FindMin());
// Console.WriteLine(sw.Elapsed.TotalMilliseconds);
// sw.Restart();
// Console.WriteLine(b.FindMinVectorized());
// Console.WriteLine(sw.Elapsed.TotalMilliseconds);
// sw.Restart();
// Console.WriteLine(b._list.Min());
// Console.WriteLine(sw.Elapsed.TotalMilliseconds);
BenchmarkRunner.Run<Normal>(new ManualConfig(){});