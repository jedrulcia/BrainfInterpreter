using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BrainfInterpreter
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainViewModel(); // Ustawienie BindingContext na ViewModel
		}
	}

	// Właściwa ViewModel zawierająca komendę
	public class MainViewModel
	{
		public string Code { get; set; } = string.Empty; // Wprowadzony kod Brainfuck
		public ObservableCollection<int> Memory { get; set; } // Pamięć z interpreteru
		public int CurrentPointer { get; set; }
		public string OutputText { get; set; } = string.Empty; // Wynik wyjściowy
		public ICommand ExecuteCodeCommand { get; }

		private readonly Interpreter _interpreter;

		public MainViewModel()
		{
			_interpreter = new Interpreter();
			Memory = new ObservableCollection<int>(_interpreter.Memory);
			CurrentPointer = _interpreter.Pointer;

			// Komenda przypisująca akcję do wykonania kodu
			ExecuteCodeCommand = new RelayCommand(ExecuteCode, CanExecuteCode);
		}

		// Określa, czy komenda może zostać wywołana
		private bool CanExecuteCode() => !string.IsNullOrEmpty(Code);

		// Metoda uruchamiająca kod Brainfuck
		private void ExecuteCode()
		{
			_interpreter.Run(Code);  // Wykonaj kod

			// Aktualizuj pamięć
			for (int i = 0; i < Memory.Count; i++)
			{
				Memory[i] = _interpreter.Memory[i];
			}

			// Zaktualizuj wskaźnik
			CurrentPointer = _interpreter.Pointer;

			// Zaktualizuj wynik (dla Brainfuck, wyświetl wyniki opóźnienia ".")
			OutputText = _interpreter.Output.ToString();
		}
	}
}
