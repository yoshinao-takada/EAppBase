using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAppBase.Libs
{
    public class HSMMsg
    {
        public int ID { get; set; }
        public object Params { get; set; }
    }

    public enum HSMStateHandlerResult
    {
        Ignore, // do nothing
        Accept, // execute Doing handler
        Transit // execute Exit handler and then change state and execute new Enter handler
    }
    public struct HSMState
    {
        public Action<HSM> Enter { get; set; }
        public Action<HSM> Exit { get; set; }
        public Action<HSM> Doing { get; set; }
        public Func<HSM, HSMMsg, HSMStateHandlerResult> StateHandler { get; set; }
    }
    public class HSM
    {
        System.Collections.Generic.Stack<HSMState> StateStack; // storing states of super states.
        HSMMsg LatestMsg { get; set; }
        HSMState State { get; set; }
        object Context { get; set; }

        HSMStateHandlerResult Execute(HSMMsg msg)
        {
            HSMMsg LatestMsgSave = LatestMsg;
            HSMStateHandlerResult result = State.StateHandler(this, msg);
            return result;
        }

        void CallSubstate(HSMState substate, HSMMsg msg)
        {
            State.Exit(this);
            StateStack.Push(State);
            LatestMsg = msg;
            State = substate;
            State.Enter(this);
        }

        void ReturnFromSubstate(HSMMsg msg)
        {
            State.Exit(this);
            State = StateStack.Pop();
            LatestMsg = msg;
            State.Enter(this);
        }

        void Transit(HSMState newState, HSMMsg msg)
        {
            State.Exit(this);
            State = newState;
            LatestMsg = msg;
            State.Enter(this);
        }
    }
}
