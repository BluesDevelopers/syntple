using syntple.core.consolecommon.parsing.typeparsers.interfaces;


namespace syntple.core.consolecommon.parsing.typeparsers
{
    public class ObjectParser : TypeParserBase<object>
    {
        public override object Parse(string toParse, Type typeToParse, ITypeParserContainer parserContainer)
        {
            return Convert.ChangeType(toParse, typeToParse);
        }
    }
}
