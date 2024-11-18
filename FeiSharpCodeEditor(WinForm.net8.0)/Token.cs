namespace FeiSharpStudio
{
    public class Token
    {
        public TokenTypes Type { get; }
        public string Value { get; }

        public Token(TokenTypes type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    
}
