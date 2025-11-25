using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLectura
{
    public class ResaltadorTextocs : DecoradorSegmentoTexto
    {
        private ConsoleColor _resaltador;

        public ResaltadorTextocs(ISegmentoTexto segment, ConsoleColor resaltador) : base(segment)
        {
            _resaltador = resaltador;
            if (_segment is SegmentoTextoBasico basic)
            {
                basic.HighlightColor = _resaltador;
            }
        }

        public override ConsoleColor? HighlightColor => _resaltador;
    }
}
    

