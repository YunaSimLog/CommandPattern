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
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            invoker.SetOnFinish(new SimpleCommand("Say Bye!"));
            invoker.DoSomethingImportant();

        }
    }
}
