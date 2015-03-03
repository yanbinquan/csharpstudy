using System;

namespace 抽象类
{
    public class IncandescentLamp : Light
    {
        public IncandescentLamp()
            : base()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public override void TurnOn()
        {
            Console.WriteLine("On");
        }

        public override void TurnOff()
        {
            Console.WriteLine("Off");
        }
    }
}