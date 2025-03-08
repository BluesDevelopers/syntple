using syntple.core.consolecommon.parsing.typeparsers.interfaces;


namespace syntple.core.consolecommon.parsing
{
    public interface ITypeParserContainer
    {
        object Parse(string toParse, Type type);
        string[] GetAcceptedValues(Type type);
        ITypeParser GetParser(Type typeToParse);
    }
}
