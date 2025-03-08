namespace syntple.core.consolecommon.helptext
{
    public interface IHelpTextParser
    {
        string GetUsage(ParamsObject InputParams);
        string GetSwitchHelp(ParamsObject InputParams);
        string GetHelp(ParamsObject InputParams);
        string GetHelpIfNeeded(string[] args, ParamsObject InputParams);
    }
}
