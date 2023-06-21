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
    /// 복잡한 형태의 작업 구현
    /// Receiver 객체
    /// </summary>
    class ComplexCommand : ICommand
    {
        Receiver m_Receiver;

        // Receiver 메소드 실행에 필요한 컨텍스트 테이터
        string m_strValue1;
        string m_strValue2;

        // Receiver의 객체 또는 컨텍스트 데이터를 받을 수 있다.
        public ComplexCommand(Receiver receiver, string strValue1, string strValue2)
        {
            m_Receiver = receiver;
            m_strValue1 = strValue1;
            m_strValue2 = strValue2;
        }

        // 명령을 Receiver의 모든 메서드에 위임
        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Receiver 개체에서 수행");
            this.m_Receiver.DoSomething(m_strValue1);
            this.m_Receiver.DoSomethingElse(m_strValue2);
        }
    }

    /// <summary>
    /// 수행과 관련된 모든 종류의 작업을 수행
    /// 수신기 역활을 하는 클래스
    /// </summary>
    class Receiver
    {
        public void DoSomething(string strValue1)
        {
            Console.WriteLine($"Receiver: DoSomething() ({strValue1}.)");
        }

        public void DoSomethingElse(string strValue2)
        {
            Console.WriteLine($"Receiver: DoSomethingElse() ({strValue2}.)");
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
            m_OnFinish = command;
        }

        public void DoSomethingImportant()
        {
            Console.WriteLine("Invoker: 이 행동 시작전에 일이 완료되야 할 사항이 있는가?");
            if (m_OnStart is ICommand)
            {
                m_OnStart.Execute();
            }

            Console.WriteLine("Invoker: ...중요한 작업이 진행중...");

            Console.WriteLine("Invoker: 이 행동이 끝난 후 진행해야 할 사항이 있는가?");
            if (m_OnFinish is ICommand)
            {
                m_OnFinish.Execute();
            }
        }
    }


}
