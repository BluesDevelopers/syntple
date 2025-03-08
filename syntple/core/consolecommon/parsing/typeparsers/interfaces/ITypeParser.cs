namespace syntple.core.consolecommon.parsing.typeparsers.interfaces
{
    public interface ITypeParser
    {
        Type GetTypeToParse(params Type[] genericTypeParams);
        object Parse(string toParse, Type typeToParse, ITypeParserContainer parserContainer);
        string[] GetAcceptedValues(Type typeToParse);
    }
}
