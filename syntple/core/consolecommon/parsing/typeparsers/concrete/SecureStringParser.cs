using syntple.core.consolecommon.parsing.typeparsers.interfaces;


namespace syntple.core.consolecommon.parsing.typeparsers
{
    public class SecureStringParser : TypeParserBase<System.Security.SecureString>
    {
        public override object Parse(string toParse, Type typeToParse, ITypeParserContainer parserContainer)
        {
            var secure = new System.Security.SecureString();
            foreach (var v in toParse.ToCharArray())
            {
                secure.AppendChar(v);
            }
            return secure;
        }
    }
}
