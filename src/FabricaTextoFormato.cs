using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLectura
{
    public class FabricaTextoFormato
    {
        private static FabricaTextoFormato _instance;
        private Dictionary<int, TextoFormato> _formats = new Dictionary<int, TextoFormato>();

        private FabricaTextoFormato() { }

        public static FabricaTextoFormato Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FabricaTextoFormato();
                return _instance;
            }
        }

        public TextoFormato GetFormat(string fontFamily, int fontSize, ConsoleColor textColor, bool isBold)
        {
            var format = new TextoFormato(fontFamily, fontSize, textColor, isBold);
            int hash = format.GetHashCode();

            if (!_formats.ContainsKey(hash))
            {
                _formats[hash] = format;
            }

            return _formats[hash];
        }
    }
}
