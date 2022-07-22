// See https://aka.ms/new-console-template for more information
using _3_1_b;

NovaPessa pessoa = new();

Console.Write("Insira o seu nome: ");
pessoa.Nome = Console.ReadLine();

Console.Write("INsira o seu apelido: ");
pessoa.Apelido = Console.ReadLine();

Console.Write("Insira a sua idade: ");
pessoa.Idade = Console.ReadLine();

Console.WriteLine("Prazer, "+pessoa.Nome+" "+pessoa.Apelido+", com "+pessoa.Idade+" de idade.");
