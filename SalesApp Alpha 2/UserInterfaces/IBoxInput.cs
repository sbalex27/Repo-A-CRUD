using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Net.Http.Headers;

namespace SalesApp_Alpha_2
{
    public delegate void InputBoxEventHandler(object sender, EventArgs e);

    public interface IBoxInput<T>
    {
        event InputBoxEventHandler InputChanged;

        T InputValue { get; set; }
        string Title { get; set; }
        Image Picture { get; set; }
        bool InputEnabled { get; set; }
        bool VisualError { get; set; }
        void ResetInputValue();
    }

    public static class BoxErrorState
    {
        public static void VisualError(ref Label L, bool ErrorIsTrue)
        {
            L.ForeColor = ErrorIsTrue ? Color.DarkRed : Color.FromKnownColor(KnownColor.ControlText);
            L.Font = ErrorIsTrue ? new Font(L.Font, FontStyle.Bold) : new Font(L.Font, FontStyle.Regular);
        }
    }

    public enum InputBoxState { Regular, Disabled, Error}
    public class IBS<TInput, TTitle>
    {
        public IBS(TInput input, TTitle title)
        {
            BoxState = InputBoxState.Regular;
            Input = input;
            Title = title;
        }

        public IBS(InputBoxState boxState, TInput input, TTitle title)
        {
            BoxState = boxState;
            Input = input;
            Title = title;
        }

        private InputBoxState PBoxState;
        public InputBoxState BoxState
        {
            get => PBoxState;
            set
            {
                PBoxState = value;
                switch (PBoxState)
                {
                    case InputBoxState.Regular:
                        
                        break;
                    case InputBoxState.Disabled:
                        break;
                    case InputBoxState.Error:
                        
                        break;
                    default:
                        break;
                }
            }
        }
        public TInput Input { get; private set; }
        public TTitle Title { get; private set; }
    }
}
