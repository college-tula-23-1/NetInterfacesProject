
// ковариантность
IMessanger<Message> outlook = new EmailMessanger();
Message message = outlook.WriteMessage("Hello world");
Console.WriteLine(message.Text);

IMessanger<EmailMessage> bat = new EmailMessanger();
IMessanger<Message> batClient = bat;
Message emailMessage = batClient.WriteMessage("Hello people");
Console.WriteLine(emailMessage.Text);

// контрвариантность
ISenderMessanger<EmailMessage> senderMessanger = new SimpleMessanger();
senderMessanger.SendMessage(new EmailMessage("Hello Tula!"));

ISenderMessanger<Message> telegram = new SimpleMessanger();
ISenderMessanger<EmailMessage> emailClient = telegram;
emailClient.SendMessage(new EmailMessage("Hello College!"));
telegram.SendMessage(new Message("Hello students!"));


// ковариантный интерфейс
interface IMessanger<out T>
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


// контрвариантный интерфейс
interface ISenderMessanger<in T>
{
    void SendMessage(T message);
}

class SimpleMessanger : ISenderMessanger<Message>
{
    public void SendMessage(Message message)
    {
        Console.WriteLine($"Send message: {message.Text}");
    }
}


// модель данных
class Message
{
    public string Text {  set; get; }
    public Message(string text) => Text = text;
}

class EmailMessage : Message
{
    public EmailMessage(string text) : base(text) {}
}
