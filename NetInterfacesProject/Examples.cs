using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInterfacesProject
{
    static class Examples
    {
        public static void InterfacesWelcomeExample()
        {
            Documnet documnet = new();
            (documnet as IPrintable)?.PrintFull("Hello world");
        }
    }

    class Documnet : IPrintable
    {
        public string Title { get; set; }

        public event IPrintable.PrintHandler PrintEvent;
        public void Print()
        {
            Console.WriteLine($"Document print");
        }

        public void PrintFull(string text)
        {
            Console.WriteLine($"Document print full: {text}");
        }
    }

    interface IPrintable
    {
        const int MinPages = 3;
        const int MaxPages = 100;
        void Print();
        string Title { set; get; }

        delegate void PrintHandler(string text);
        event PrintHandler PrintEvent;

        void PrintFull(string text)
        {
            Console.WriteLine($"Full print: {text}");
        }
    }

    class Car : GroundTransport
    {
        public override void Move()
        {
            Console.WriteLine("Car moved");
        }
    }
    class GroundTransport : IMovable
    {
        public virtual void Move()
        {
            Console.WriteLine("Ground transport moved");
        }
    }

    //class Car : Transport
    //{
    //    public override void Move()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //abstract class Transport : IMovable
    //{
    //    public abstract void Move();
    //}

    interface IMovable
    {
        void Move();
    }


    class MfuCanon : IMfu
    {
        public void Copy()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void Scan()
        {
            throw new NotImplementedException();
        }
    }

    interface IPrinter
    {
        void Print();
    }

    interface IScanner
    {
        void Scan();
    }

    interface IMfu : IPrinter, IScanner
    {
        void Copy();
    }

    interface IMessage
    {

    }

    interface INote
    {

    }

    class Communicator<T> where T : IMessage, INote
    {
        public void Send(T message)
        {

        }
    }

    interface IMessanger<T>
    {
        void Send(T message);
    }

    class EmailMessage
    {

    }

    interface IEmailMessanger : IMessanger<EmailMessage>
    {

    }
}
