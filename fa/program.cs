namespace fans;
public class State
{
    public string Name { get; set; } = string.Empty;
    public Dictionary<char, State> Transitions { get; set; } = new();
    public bool IsAcceptState { get; set; }
}

public class FA1
{
    private readonly State _start, _hasZero, _accept, _reject;
    private readonly State _initialState;

    public FA1()
    {
        _start = new State { Name = "start", IsAcceptState = false, Transitions = new() };
        _hasZero = new State { Name = "hasZero", IsAcceptState = false, Transitions = new() };
        _accept = new State { Name = "accept", IsAcceptState = true, Transitions = new() };
        _reject = new State { Name = "reject", IsAcceptState = false, Transitions = new() };

        _start.Transitions['0'] = _hasZero; 
        _start.Transitions['1'] = _start;  

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