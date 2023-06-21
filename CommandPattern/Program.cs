using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandPattern
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            //Invoker invoker = new Invoker();
            //invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            //invoker.SetOnFinish(new SimpleCommand("Say Bye!"));
            //invoker.DoSomethingImportant();

            Invoker invoker2 = new Invoker();
            Receiver receiver = new Receiver();
            invoker2.SetOnStart(new ComplexCommand(receiver, "Val1", "Val2"));
            invoker2.SetOnFinish(new ComplexCommand(receiver, "Val3", "Val4"));
            invoker2.DoSomethingImportant();
        }
    }
}
