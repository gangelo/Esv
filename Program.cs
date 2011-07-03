using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esv {
	class Program {
		static private string Prompt { get { return "Enter a passage to look up ('exit' to quit): "; } }

		static void Main(string[] args) {

			Console.Write(Program.Prompt);
			string reference = Console.ReadLine();

			while (!reference.Trim().Equals("exit", StringComparison.CurrentCultureIgnoreCase)) {
				string passage;
				string errorMessage;

				if (!string.IsNullOrEmpty(reference)) {
					if (Esv.EsvServer.GetReference(reference, out passage, out errorMessage)) {
						Console.WriteLine(passage);
					} else {
						Console.WriteLine("An error occurred:");
						Console.WriteLine(errorMessage);
					}
				}

				Console.WriteLine();
				Console.Write(Program.Prompt);
				reference = Console.ReadLine();
			}

			//Console.WriteLine("Press any key to exit...");
			//Console.ReadKey();
		}
	};
};
