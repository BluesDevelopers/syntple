namespace syntple.core.consolecommon.parsing.typeparsers
{
    public class DefaultTypeContainer : TypeParserContainer
    {
        public DefaultTypeContainer() : base(true,
            new ArrayParser(), new BoolParser(), new EnumParser(),
            new KeyValueParser(), new ObjectParser(),
            new NullableParser(),
            new SecureStringParser(), new TypeTypeParser())
        { }
    }
}
