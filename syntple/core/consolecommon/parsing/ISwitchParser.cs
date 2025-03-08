namespace syntple.core.consolecommon.parsing
{
    public interface ISwitchParser
    {
        ParamsObject ParseSwitches(string[] args);
        IEnumerable<Exception> ExceptionList { get; }
    }
}
