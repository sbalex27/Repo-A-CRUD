using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp_Alpha_2
{
    //Father Class Custom Exception
    class CustomException : Exception
    {
        public CustomException() : base() { }

        public CustomException(string Message) : base(Message) { }

        public CustomException(string Message, string _Filename, int _LineNumber) :
            base($"{Message} en: {_Filename} línea: {_LineNumber}")
        {
            FileName = _Filename;
            LineNumber = _LineNumber;
        }
        
        public string FileName { get; private set; }
        public int LineNumber { get; private set; }
    }

    //Soon class
    class MultipleResultsException : CustomException
    {
        static readonly string CustomMessage = "Hay más de un resultado en la búsqueda";

        public MultipleResultsException() : base(CustomMessage) { }
        public MultipleResultsException(string _FileName, int _LineNumber) : base(CustomMessage, _FileName, _LineNumber) { }
    }

    class NoResultsException : CustomException
    {
        static readonly string CustomMessage = "No se han encontrado resultados";

        public NoResultsException() : base(CustomMessage) { }
        public NoResultsException(string _FileName, int _LineNumber) : base(CustomMessage, _FileName, _LineNumber) { }
    }

    class EmptyInputException : CustomException
    {
        static readonly string CustomMessage = "Valores de entrada vacíos";

        public EmptyInputException() : base(CustomMessage) { }
        public EmptyInputException(string _FileName, int _LineNumber) : base(CustomMessage, _FileName, _LineNumber) { }
    }

    class NoDatabaseConection: CustomException
    {
        static readonly string CustomMessage = "No se puede establecer conexión con la base de datos";

        public NoDatabaseConection() : base(CustomMessage) { }
        public NoDatabaseConection(string _FileName, int _LineNumber) : base(CustomMessage, _FileName, _LineNumber) { }
    }
}