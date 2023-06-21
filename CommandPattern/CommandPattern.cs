using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 명령 실행 방법을 선언한다.
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }

    /// <summary>
    /// 간단한 작업 구현
    /// </summary>
    class SimpleCommand : ICommand
    {
        string m_payload = string.Empty;

        public SimpleCommand(string payload)
        {
            m_payload = payload;
        }

        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: Excute() ({this.m_payload})");
        }
    }

    /// <summary>
    /// 수행과 관련된 모든 종류의 작업을 수행
    /// 수신기 역활을 하는 클래스
    /// </summary>
    class Receiver
    {
        public void DoSomething(string strValue)
        {
            Console.WriteLine($"Receiver: DoSomething() ({strValue}.)");
        }

        public void DoSomethingElse(string strValue)
        {
            Console.WriteLine($"Receiver: DoSomethingElse() ({strValue}.)");
        }
    }

    class Invoker
    {
        private ICommand m_OnStart;
        private ICommand m_OnFinish;

        public void SetOnStart(ICommand command)
        {
            m_OnStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            m_OnFinish=command;
        }

        public void DoSomethingImportant()
        {
            Console.WriteLine("Invoker: 이 행동 시작전에 일이 완료되야 할 사항이 있는가?");
            if(m_OnStart is ICommand)
            {
                m_OnStart.Execute();
            }

            Console.WriteLine("Invoker: ...중요한 작업이 진행중...");

            Console.WriteLine("Invoker: 이 행동이 끝난 후 진행해야 할 사항이 있는가?");
            if( m_OnFinish is ICommand)
            {
                m_OnFinish.Execute(); 
            }
        }
    }


}
