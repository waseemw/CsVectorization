using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace CsVectorization;

[MemoryDiagnoser(false)]
public class Normal
{
    public int[] _list;

    [GlobalSetup]
    public void Setup()
    {
        _list = Enumerable.Range(0, 100).ToArray();
    }
    
    
    public int FindMin()
    {
        var min = int.MaxValue;
        foreach (var i in _list)
            if (i < min)
                min = i;
        return min;
    }

    public int FindMinVectorized()
    {
        var _list = new ReadOnlySpan<int>(this._list);
        var minVector = new Vector<int>(_list);
        var n = 8;
        while (n + 8 <= _list.Length)
        {
            minVector = Vector.Min(minVector, new Vector<int>(_list.Slice(n)));
            n += 8;
        }

        var min = minVector[0];
        for (var i = 1; i < 8; i++)
            if (minVector[i] < min)
                min = minVector[i];

        for (var i = n - 8; i < _list.Length; i++)
            if (_list[i] < min)
                min = _list[i];

        return min;
    }
}