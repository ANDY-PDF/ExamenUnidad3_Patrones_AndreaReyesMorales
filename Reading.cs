using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AppLectura
{
    class Reading
    {
        private Documento _documento;
        private FabricaTextoFormato _formatFactory;

        public Reading()
        {
            _formatFactory = FabricaTextoFormato.Instance;
            InitializeDocument();
        }

        private void InitializeDocument()
        {
            _documento = new Documento("El Principito - Antoine de Saint-Exupéry");

            string sampleText = @"Cuando yo tenía seis años vi una vez una lámina magnífica
                                en un libro sobre el Bosque Virgen que se llamaba 'Historias Vividas'.
                                Representaba una serpiente boa que se tragaba a una fiera.
                                He aquí la copia del dibujo.
                                En el libro decía: 'Las serpientes boas tragan su presa entera'.
                                Reflexioné mucho entonces sobre las aventuras de la jungla.
                                Lo esencial es invisible a los ojos.
                                Esta es una de las frases más importantes del libro.
                                El zorro le enseña al principito sobre la amistad y el amor.
                                Viví solo, sin nadie con quien hablar verdaderamente.";

            _documento.LoadText(sampleText);
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                _documento.DisplayDocument();
                ShowMenu();

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ChangeFontSize();
                        break;
                    case "2":
                        ChangeColor();
                        break;
                    case "3":
                        HighlightText();
                        break;
                    case "4":
                        AddComment();
                        break;
                    case "5":
                        AddBookmark();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("\n¡Gracias por usar la aplicación! \n");
                        break;
                    default:
                        Console.WriteLine("\n Opción inválida");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n MENÚ DE OPCIONES:");
            Console.ResetColor();
            Console.WriteLine("1. Cambiar tamaño de fuente");
            Console.WriteLine("2. Cambiar color de texto");
            Console.WriteLine("3. Resaltar línea");
            Console.WriteLine("4. Añadir comentario");
            Console.WriteLine("5. Crear marcador");
            Console.WriteLine("6. Ver marcadores");
            Console.WriteLine("7. Salir");
            Console.Write("\n➤ Selecciona una opción: ");
        }

        private void ChangeFontSize()
        {
            Console.Write("\n Ingresa el número de línea: ");
            if (int.TryParse(Console.ReadLine(), out int line) && line > 0 && line <= _documento.GetTotalLines())
            {
                Console.Write("Tamaño de fuente (10/12/14/16/18/20): ");
                if (int.TryParse(Console.ReadLine(), out int size))
                {
                    string text = _documento.GetLine(line - 1);
                    var format = _formatFactory.GetFormat("Consolas", size, ConsoleColor.White, false);
                    var segment = new SegmentoTextoBasico(text, format);

                    _documento.ApplyDecorator(line - 1, segment);
                    Console.WriteLine($"\n Tamaño {size} aplicado a línea {line}");
                }
            }
            Console.ReadKey();
        }

        private void ChangeColor()
        {
            Console.Write("\n Ingresa el número de línea: ");
            if (int.TryParse(Console.ReadLine(), out int line) && line > 0 && line <= _documento.GetTotalLines())
            {
                Console.WriteLine("\nColores disponibles:");
                Console.WriteLine("1-Blanco, 2-Amarillo, 3-Verde, 4-Cyan, 5-Rojo, 6-Magenta");
                Console.Write("Selecciona color: ");

                if (int.TryParse(Console.ReadLine(), out int colorChoice))
                {
                    ConsoleColor color = colorChoice switch
                    {
                        1 => ConsoleColor.White,
                        2 => ConsoleColor.Yellow,
                        3 => ConsoleColor.Green,
                        4 => ConsoleColor.Cyan,
                        5 => ConsoleColor.Red,
                        6 => ConsoleColor.Magenta,
                        _ => ConsoleColor.White
                    };

                    string text = _documento.GetLine(line - 1);
                    var format = _formatFactory.GetFormat("Consolas", 14, color, false);
                    var segment = new SegmentoTextoBasico(text, format);

                    _documento.ApplyDecorator(line - 1, segment);
                    Console.WriteLine($"\n Color aplicado a línea {line}");
                }
            }
            Console.ReadKey();
        }

        private void HighlightText()
        {
            Console.Write("\n Ingresa el número de línea a resaltar: ");
            if (int.TryParse(Console.ReadLine(), out int line) && line > 0 && line <= _documento.GetTotalLines())
            {
                Console.WriteLine("\nColores de resaltado:");
                Console.WriteLine("1-Amarillo, 2-Verde, 3-Cyan, 4-Rojo, 5-Magenta");
                Console.Write("Selecciona color: ");

                if (int.TryParse(Console.ReadLine(), out int colorChoice))
                {
                    ConsoleColor highlight = colorChoice switch
                    {
                        1 => ConsoleColor.DarkYellow,
                        2 => ConsoleColor.DarkGreen,
                        3 => ConsoleColor.DarkCyan,
                        4 => ConsoleColor.DarkRed,
                        5 => ConsoleColor.DarkMagenta,
                        _ => ConsoleColor.DarkYellow
                    };

                    string text = _documento.GetLine(line - 1);
                    var format = _formatFactory.GetFormat("Consolas", 14, ConsoleColor.White, false);
                    ISegmentoTexto segment = new SegmentoTextoBasico(text, format);
                    segment = new ResaltadorTextocs(segment, highlight);

                        _documento.ApplyDecorator(line - 1, segment);
                    Console.WriteLine($"\n Línea {line} resaltada");
                }
            }
            Console.ReadKey();
        }

        private void AddComment()
        {
            Console.Write("\n Ingresa el número de línea: ");
            if (int.TryParse(Console.ReadLine(), out int line) && line > 0 && line <=  _documento.GetTotalLines())
            {
                Console.Write("Escribe tu comentario: ");
                string comment = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(comment))
                {
                    string text = _documento.GetLine(line - 1);
                    var format = _formatFactory.GetFormat("Consolas", 14, ConsoleColor.White, false);
                    ISegmentoTexto segment = new SegmentoTextoBasico(text, format);
                    segment = new CommentDecorator(segment, comment);

                    _documento.ApplyDecorator(line - 1, segment);
                    Console.WriteLine($"\n Comentario añadido a línea {line}");
                }
            }
            Console.ReadKey();
        }

        private void AddBookmark()
        {
            Console.Write("\n Ingresa el número de línea: ");
            if (int.TryParse(Console.ReadLine(), out int line) && line > 0 && line <= _documento.GetTotalLines())
            {
                Console.Write("Nombre del marcador: ");
                string name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    string text = _documento.GetLine(line - 1);
                    var format = _formatFactory.GetFormat("Consolas", 14, ConsoleColor.White, false);
                    ISegmentoTexto segment = new SegmentoTextoBasico(text, format);
                    segment = new BookMark(segment, name);

                    _documento.ApplyDecorator(line - 1, segment);
                    Console.WriteLine($"\n Marcador '{name}' creado en línea {line}");
                }
            }
            Console.ReadKey();
        }
    }
}
