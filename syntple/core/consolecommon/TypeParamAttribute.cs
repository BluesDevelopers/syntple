namespace syntple.core.consolecommon
{
    public class TypeParamAttribute : Attribute
    {
        public string FriendlyName { get; set; }
        public bool Ignore { get; set; }
        public TypeParamAttribute() { }
        public TypeParamAttribute(string FriendlyName)
        {
            this.FriendlyName = FriendlyName;
        }
    }
}
