
// ковариантность
interface IMessanger<T>
{
    T WriteMessage(string text);
}

class EmailMessanger : IMessanger<EmailMessage>
{
    public EmailMessage WriteMessage(string text)
    {
        return new EmailMessage($"Email: {text}");
    }
}

class Message
{
    public string Text {  set; get; }
    public Message(string text) => Text = text;
}

class EmailMessage : Message
{
    public EmailMessage(string text) : base(text) {}
}
