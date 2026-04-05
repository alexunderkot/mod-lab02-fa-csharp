namespace fans;
public class State
{
    public string Name { get; set; } = string.Empty;
    public Dictionary<char, State> Transitions { get; set; } = new();
    public bool IsAcceptState { get; set; }
}

public class FA1
{
    private readonly State _q0, _q1, _q2, _q3;
    private readonly State _initialState;

    public FA1()
    {
        _q0 = new State { Name = "q0", IsAcceptState = false, Transitions = new() };
        _q1 = new State { Name = "q1", IsAcceptState = false, Transitions = new() };
        _q2 = new State { Name = "q2", IsAcceptState = true, Transitions = new() };
        _q3 = new State { Name = "q3", IsAcceptState = false, Transitions = new() };

        _q0.Transitions['0'] = _q1;
        _q0.Transitions['1'] = _q0; 

        _q1.Transitions['0'] = _q3;  
        _q1.Transitions['1'] = _q2;  

        _q2.Transitions['0'] = _q3;  
        _q2.Transitions['1'] = _q2;  

        _q3.Transitions['0'] = _q3;
        _q3.Transitions['1'] = _q3;

        _initialState = _q0;
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
    private readonly State _q00, _q01, _q10, _q11;
    private readonly State _initialState;

    public FA2()
    {
        _q00 = new State { Name = "q00", IsAcceptState = false, Transitions = new() };
        _q01 = new State { Name = "q01", IsAcceptState = false, Transitions = new() };
        _q10 = new State { Name = "q10", IsAcceptState = false, Transitions = new() };
        _q11 = new State { Name = "q11", IsAcceptState = true, Transitions = new() };

        _q00.Transitions['0'] = _q10;
        _q01.Transitions['0'] = _q11;
        _q10.Transitions['0'] = _q00;
        _q11.Transitions['0'] = _q01;

        _q00.Transitions['1'] = _q01;
        _q01.Transitions['1'] = _q00;
        _q10.Transitions['1'] = _q11;
        _q11.Transitions['1'] = _q10;

        _initialState = _q00;
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