using System;

namespace State
{
    // Used to check stats and know where they are staying. For example, in which state in ORMs
    // After the information is learned, action is taken accordingly.
    class Program
    {
        static void Main(string[] args)
        {
            Context context=new Context();
            ModifiedState modifiedState=new ModifiedState();
            modifiedState.DoAction(context);
            DeletedState deletedState=new DeletedState();
            deletedState.DoAction(context); 

            Console.ReadLine();
        }
    }

    class ModifiedState:IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State modified");
            context.SetState(this);
        }
    }

    class DeletedState:IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State deleted");
            context.SetState(this);
        }
    }

    class AddState:IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State added");
            context.SetState(this);
        }
    }

    interface IState
    {
        void DoAction(Context context);
    }

    internal class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}
