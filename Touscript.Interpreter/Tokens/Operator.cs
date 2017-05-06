using System;

namespace Touscript.Interpreter
{
    public abstract class Operator : Token
    {
        public Operator()
        {
        }

        public virtual int Priority { get; } = -1;

        public abstract int Evaluate(Number left, Number right);

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Operator)
            {
                return this.GetType() == obj.GetType();
            }
            return false;
        }
    }
}
