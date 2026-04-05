namespace fans;
public class State
{
    public string Name { get; set; } = string.Empty;
    public Dictionary<char, State> Transitions { get; set; } = new();
    public bool IsAcceptState { get; set; }
}

public class FA1
{
    private readonly State _start, _hasOne, _hasZero, _accept, _reject;
    private readonly State _initialState;

    public FA1()
    {
        _start = new State { Name = "start", IsAcceptState = false, Transitions = new() };
        _hasZero = new State { Name = "hasZero", IsAcceptState = false, Transitions = new() };
        _hasOne = new State { Name = "hasOne", IsAcceptState = false, Transitions = new() };
        _accept = new State { Name = "accept", IsAcceptState = true, Transitions = new() };
        _reject = new State { Name = "reject", IsAcceptState = false, Transitions = new() };

        _start.Transitions['0'] = _hasZero; 
        _start.Transitions['1'] = _hasOne;  

        _hasOne.Transitions['0'] = _accept;
        _hasOne.Transitions['1'] = _hasOne;

        _hasZero.Transitions['0'] = _reject;
        _hasZero.Transitions['1'] = _accept; 

        _accept.Transitions['0'] = _reject; 
        _accept.Transitions['1'] = _accept; 

        _reject.Transitions['0'] = _reject;
        _reject.Transitions['1'] = _reject;

        _initialState = _start;
    }

    public bool? Run(IEnumerable<char> s)
    {
        var current = _initialState;
        foreach (var c in s)
        {
            if (!current.Transitions.TryGetValue(c, out var next))
                return null;
            current = next;
        }
        return current.IsAcceptState;
    }
}

public class FA2
{
    private readonly State _even0_even1, _even0_odd1, _odd0_even1, _odd0_odd1;
    private readonly State _initialState;

    public FA2()
    {
        _even0_even1 = new State { Name = "00", IsAcceptState = false, Transitions = new() }; 
        _even0_odd1 = new State { Name = "01", IsAcceptState = true, Transitions = new() };  
        _odd0_even1 = new State { Name = "10", IsAcceptState = true, Transitions = new() }; 
        _odd0_odd1 = new State { Name = "11", IsAcceptState = true, Transitions = new() };   

        _even0_even1.Transitions['0'] = _odd0_even1;
        _even0_odd1.Transitions['0'] = _odd0_odd1;
        _odd0_even1.Transitions['0'] = _even0_even1;
        _odd0_odd1.Transitions['0'] = _even0_odd1;

        _even0_even1.Transitions['1'] = _even0_odd1;
        _even0_odd1.Transitions['1'] = _even0_even1;
        _odd0_even1.Transitions['1'] = _odd0_odd1;
        _odd0_odd1.Transitions['1'] = _odd0_even1;

        _initialState = _even0_even1; 
    }

    public bool? Run(IEnumerable<char> s)
    {
        var current = _initialState;
        foreach (var c in s)
        {
            if (!current.Transitions.TryGetValue(c, out var next))
                return null;
            current = next;
        }
        return current.IsAcceptState;
    }
}
public class FA3
{
    private readonly State _s0, _s1, _s2;
    private readonly State _initialState;

    public FA3()
    {
        _s0 = new State { Name = "s0", IsAcceptState = false, Transitions = new() };
        _s1 = new State { Name = "s1", IsAcceptState = false, Transitions = new() };
        _s2 = new State { Name = "s2", IsAcceptState = true, Transitions = new() };

        _s0.Transitions['0'] = _s0;
        _s0.Transitions['1'] = _s1;  

        _s1.Transitions['0'] = _s0;  
        _s1.Transitions['1'] = _s2;  

        _s2.Transitions['0'] = _s2;
        _s2.Transitions['1'] = _s2;

        _initialState = _s0;
    }

    public bool? Run(IEnumerable<char> s)
    {
        var current = _initialState;
        foreach (var c in s)
        {
            if (!current.Transitions.TryGetValue(c, out var next))
                return null;
            current = next;
        }
        return current.IsAcceptState;
    }
}

class Program
{
    static void Main(string[] args)
    {
         var fa1 = new FA1();
        var fa2 = new FA2();
        var fa3 = new FA3();

        Console.WriteLine("FA1:");
        Console.WriteLine($"01 -> {fa1.Run("01")}");
        Console.WriteLine($"10 -> {fa1.Run("10")}");
        Console.WriteLine($"011 -> {fa1.Run("011")}");
        Console.WriteLine($"001 -> {fa1.Run("001")}");
        Console.WriteLine($"0 -> {fa1.Run("0")}");
        Console.WriteLine($"1 -> {fa1.Run("1")}");
        Console.WriteLine($"111 -> {fa1.Run("111")}");
        Console.WriteLine($"010 -> {fa1.Run("010")}");
        Console.WriteLine($"0111 -> {fa1.Run("0111")}");
        Console.WriteLine($"\"\" -> {fa1.Run("")}");
        Console.WriteLine($"101 -> {fa1.Run("101")}");

        Console.WriteLine("\nFA2:");
        Console.WriteLine($"01 -> {fa2.Run("01")}");
        Console.WriteLine($"10 -> {fa2.Run("10")}");
        Console.WriteLine($"0011 -> {fa2.Run("0011")}");
        Console.WriteLine($"0 -> {fa2.Run("0")}");
        Console.WriteLine($"1 -> {fa2.Run("1")}");
        Console.WriteLine($"00 -> {fa2.Run("00")}");
        Console.WriteLine($"11 -> {fa2.Run("11")}");
        Console.WriteLine($"000111 -> {fa2.Run("000111")}");

        Console.WriteLine("\nFA3:");
        Console.WriteLine($"11 -> {fa3.Run("11")}");
        Console.WriteLine($"011 -> {fa3.Run("011")}");
        Console.WriteLine($"110 -> {fa3.Run("110")}");
        Console.WriteLine($"10 -> {fa3.Run("10")}");
        Console.WriteLine($"01 -> {fa3.Run("01")}");
        Console.WriteLine($"101 -> {fa3.Run("101")}");
        Console.WriteLine($"111 -> {fa3.Run("111")}");
        Console.WriteLine($"000 -> {fa3.Run("000")}");
    }
}