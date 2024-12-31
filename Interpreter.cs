using System.Text;

namespace BrainfInterpreter
{
	public class Interpreter
	{
		public int[] Memory { get; private set; }
		public int Pointer { get; private set; }
		public StringBuilder Output { get; private set; }

		public Interpreter()
		{
			Memory = new int[30000];
			Pointer = 0;
			Output = new StringBuilder();
		}

		// Wykonanie komendy dla Brainfuck
		public void Execute(char command)
		{
			switch (command)
			{
				case '>': Pointer = (Pointer + 1) % Memory.Length; break;
				case '<': Pointer = (Pointer - 1 + Memory.Length) % Memory.Length; break;
				case '+': Memory[Pointer]++; break;
				case '-': Memory[Pointer]--; break;
				case '.': Output.Append((char)Memory[Pointer]); break; // Zbiera wyjściowe dane
				case ',': break; // Ignorujemy ',' dla uproszczenia
			}
		}

		// Uruchomienie pełnego kodu Brainfuck
		public void Run(string code)
		{
			Output.Clear(); // Czyszczenie poprzednich wyników
			foreach (char command in code)
			{
				Execute(command);
			}
		}
	}
}
