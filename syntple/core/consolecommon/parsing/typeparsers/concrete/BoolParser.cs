using syntple.core.consolecommon.parsing.typeparsers.interfaces;

namespace syntple.core.consolecommon.parsing.typeparsers
{
    public class BoolParser : TypeParserBase<bool>
    {
        public override object Parse(string toParse, Type typeToParse, ITypeParserContainer parserContainer)
        {
            if (BoolFalseValues.Contains(toParse?.ToLower().Trim()))
            {
                return false;
            }
            else if (BoolTrueValues.Contains(toParse?.ToLower().Trim()))
            {
                return true;
            }
            else throw new Exception("Boolean value invalid");
        }
        private string[] BoolFalseValues => new string[] { "n", "no", "false", "f", "off" };
        private string[] BoolTrueValues => new string[] { "y", "yes", "true", "t", "on", null, "" };
        public override string[] GetAcceptedValues(Type typeToParse)
        {
            return BoolFalseValues.Where(s => s != null).Concat(BoolTrueValues.Where(s => s != null)).ToArray();
        }
    }
}
