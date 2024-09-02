//Cadastro do Aluno;
//Edição do Aluno;
//Exclusão do Aluno;
//Fazer uma busca do aluno, com as suas notas, sua média e situação,


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace ConsoleCRUD
{
    class MainClass
    {
        public static void printMenu(String[] options)
        {
            foreach (String option in options)
            {
                WriteLine(option);
            }
            WriteLine("Escolha a sua opção:");
        }

        public static void Main(String[] args)
        {
            WriteLine(">>>> CADASTRO DE PESSOAS >>>>");
            String[] options = {
                "1 - Cadastrar",
                "2 - Editar",
                "3 - Excluir",
                "4 - Listar",
                "5 - Listar Aprovados",
                "6 - Listar Reprovados",
                "7 - Listar Recuperação",
                "8 - Buscar",
                "9 - Salvar",
                "10 - Ler",
                "11 - Sair"
            };

            int option = 0;
            while (true)
            {
                printMenu(options);
                try
                {
                    option = Convert.ToInt32(ReadLine());
                }
                catch (System.FormatException)
                {
                    WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                    continue;
                }
                catch (Exception)
                {
                    WriteLine("Um erro aconteceu!");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Editar();
                        break;
                    case 3:
                        Excluir();
                        break;
                    case 4:
                        Listar();
                        break;
                    case 5:
                        Listar_Aprovados();
                        break;
                    case 6:
                        Listar_Reprovados();
                        break;
                    case 7:
                        Listar_Recuperação();
                        break;
                    case 8:
                        Buscar();
                        break;
                    case 9:
                        Salvar();
                        break;
                    case 10:
                        Ler();
                        break;
                    case 11:
                        Sair();
                        break;
                    default:
                        WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                        break;
                }
            }
        }

        static List<string> nomes = new List<string>();
        static List<int> nota0 = new List<int>();
        static List<int> nota1 = new List<int>();
        static List<int> nota2 = new List<int>();
        static List<int> nota3 = new List<int>();
        static List<double> medias = new List<double>();
        static List<string> aprovados = new List<string>();
        static List<string> reprovados = new List<string>();
        static List<string> recupercoes = new List<string>();


        private static int LerNota()
        {
            while (true)
            {
                if (int.TryParse(ReadLine(), out int nota) && nota >= 0 && nota <= 10)
                {
                    return nota;
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Nota inválida. Digite uma nota entre 0 e 10.");
                    ResetColor();
                }
            }
        }

       private static void Cadastrar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Blue;
            WriteLine(">>>> CADASTRO DE PESSOAS <<<<");
            ResetColor();
            WriteLine();
            WriteLine("Digite o nome da pessoa:");
            string nome = ReadLine();
            var repetido = nomes.Any(x => x.Contains(nome));
            if (repetido)
            {
                WriteLine("Este Aluno já foi registrado no sistema de notas!\n");
                return;
            }
            else
            {
                nomes.Add(nome);
            }

            WriteLine("Digite a 1ª nota do Aluno:");
            int n0 = LerNota();
            nota0.Add(n0);

            WriteLine("Digite a 2ª nota do Aluno:");
            int n1 = LerNota();
            nota1.Add(n1);

            WriteLine("Digite a 3ª nota do Aluno:");
            int n2 = LerNota();
            nota2.Add(n2);

            WriteLine("Digite a 4ª nota do Aluno:");
            int n3 = LerNota();
            nota3.Add(n3);
            Clear();

            double media = (n0 + n1 + n2 + n3) / 4.0;
            medias.Add(media);
           }
        

       
        
   private static void Listar()
{
    Clear();
    WriteLine();
    ForegroundColor = ConsoleColor.Blue;
    WriteLine("             >>>> LISTAGEM DAS PESSOAS <<<<");
    ResetColor();

    WriteLine();
  


    if (nomes.Count == 0)
    {
        ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("Nenhum usuário encontrado!");
        ResetColor();
    }
    else
    {
        WriteLine("Nome\tNota 1\tNota 2\tNota 3\tNota 4\tMédia\tSituação");
        WriteLine(new string('-', 60));
        for (int pos = 0; pos < nomes.Count; pos++)
        {
            string situacao;
            ConsoleColor corSituacao;

            if (medias[pos] >= 7)
            {
                situacao = "Aprovado";
                corSituacao = ConsoleColor.Green;
            }
            else if (medias[pos] <= 4)
            {
                situacao = "Reprovado";
                corSituacao = ConsoleColor.Red;
            }
            else
            {
                situacao = "Recuperação";
                corSituacao = ConsoleColor.Yellow;
            }

            Write($"{nomes[pos]}\t{nota0[pos]}\t{nota1[pos]}\t{nota2[pos]}\t{nota3[pos]}\t{medias[pos]:F2}\t");
            ForegroundColor = corSituacao;
            WriteLine(situacao);
            ResetColor();
        }
    }

    WriteLine();
}

    private static void Listar_Aprovados()
    {
        Clear();
        ForegroundColor = ConsoleColor.Green;
        WriteLine("             >>>> LISTAGEM DE APROVADOS <<<<");
        ResetColor();
        WriteLine();
        WriteLine("Nome\tNota 1\tNota 2\tNota 3\tNota 4\tMédia");
        WriteLine(new string('-', 50));

        bool encontrouAprovado = false;

        for (int i = 0; i < medias.Count; i++)
        {
            if (medias[i] >= 7)
            {
                WriteLine($"{nomes[i]}\t{nota0[i]}\t{nota1[i]}\t{nota2[i]}\t{nota3[i]}\t{medias[i]:F2}");
                encontrouAprovado = true;
            }
            
        }

        if (!encontrouAprovado)
        {
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("Nenhum aluno encontrado!");
            encontrouAprovado = false;
            ResetColor();
        }

        WriteLine();
    }

    private static void Listar_Reprovados()
    {
        Clear();
        ForegroundColor = ConsoleColor.Red;
        WriteLine("             >>>> LISTAGEM DE REPROVADOS <<<<");
        ResetColor();
        WriteLine();
        WriteLine("Nome\tNota 1\tNota 2\tNota 3\tNota 4\tMédia");
        WriteLine(new string('-', 50));

        bool encontrouReprovado = false;
        for (int i = 0; i < medias.Count; i++)
        {
            if (medias[i] <= 4)
            {
                WriteLine($"{nomes[i]}\t{nota0[i]}\t{nota1[i]}\t{nota2[i]}\t{nota3[i]}\t{medias[i]:F2}");
                encontrouReprovado = true;
            }
        }

        if (!encontrouReprovado)
        {
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("Nenhum aluno encontrado!");
            ResetColor();
        }

        WriteLine();
    }

    private static void Listar_Recuperação()
    {
        Clear();
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("             >>>> LISTAGEM DE RECUPERAÇÃO <<<<");
        ResetColor();
        WriteLine();
        WriteLine("Nome\tNota 1\tNota 2\tNota 3\tNota 4\tMédia");
        WriteLine(new string('-', 50));

        bool encontrouRecuperacao = false;

        for (int i = 0; i < medias.Count; i++)
        {
            if (medias[i] > 4 && medias[i] < 7)
            {
                WriteLine($"{nomes[i]}\t{nota0[i]}\t{nota1[i]}\t{nota2[i]}\t{nota3[i]}\t{medias[i]:F2}");
                encontrouRecuperacao = true;
            }
        }

        if (!encontrouRecuperacao)
        {
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("Nenhum aluno encontrado!");
            ResetColor();
        }

        WriteLine();
    }

    private static void Editar()
    {
        Clear();
        WriteLine();
        ForegroundColor = ConsoleColor.Green;
        WriteLine(">>>> EDIÇÃO DE PESSOAS <<<<");
        WriteLine();
        ResetColor();
        WriteLine("Digite o nome que você deseja editar:");
        string nome = ReadLine();
        int index = nomes.IndexOf(nome);
        if (index >= 0)
        {
            Clear();
            WriteLine(">>>> REGISTRO QUE SERÁ EDITADO <<<<");
            WriteLine($"Nome: {nomes[index]}");
            WriteLine($"Nota 1º: {nota0[index]}");
            WriteLine($"Nota 2º: {nota1[index]}");
            WriteLine($"Nota 3º: {nota2[index]}");
            WriteLine($"Nota 4º: {nota3[index]}");
            WriteLine("Digite o novo nome da pessoa:");
            nomes[index] = ReadLine();
            WriteLine("Atualize a 1º nota do aluno:");
            nota0[index] = LerNota();
            WriteLine("Atualize a 2º nota do aluno:");
            nota1[index] = LerNota();
            WriteLine("Atualize a 3º nota do aluno:");
            nota2[index] = LerNota();
            WriteLine("Atualize a 4º nota do aluno:");
            nota3[index] = LerNota();
            double media = (nota0[index] + nota1[index] + nota2[index] + nota3[index]) / 4.0;
            medias[index] = media;
            Clear();
            WriteLine();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Registro editado com sucesso!");
            ResetColor();
            
        }
        else
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Pessoa não encontrada!!!");
            ResetColor();
        }
    }
    private static void Excluir()
    {
        Clear();
        WriteLine();
        ForegroundColor = ConsoleColor.Green;
        WriteLine(">>>> EXCLUSÃO DE PESSOAS <<<<");
        WriteLine();
        ResetColor();
        WriteLine("Digite o nome que você deseja excluir:");

        string nome = ReadLine();
        int index = nomes.IndexOf(nome);
        if (index >= 0)
        {       
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(">>>> REGISTRO QUE SERÁ EXCLUÍDO <<<<");
            ResetColor();
            WriteLine($"Nome: {nomes[index]}");
            WriteLine($"Nota 1º: {nota0[index]}");
            WriteLine($"Nota 2º: {nota1[index]}");
            WriteLine($"Nota 3º: {nota2[index]}");
            WriteLine($"Nota 4º: {nota3[index]}");
            if (medias[index] >= 7)
            {
                WriteLine($"Situação: Aprovados");
            }
            if (medias[index] <= 4 )
            {
                WriteLine($"Situação: Reprovado");
            }
            if (medias[index] > 4 && medias[index] < 7)
            {
                WriteLine($"Situação: Recuperação");
            }
            WriteLine();
            while (true)
            {
                WriteLine("Certeza que deseja excluir o registro do aluno (S/N)");
                string confirmacao = ReadLine().ToUpper();
                if (confirmacao == "S")
                {
                    nomes.RemoveAt(index);
                    nota0.RemoveAt(index);
                    nota1.RemoveAt(index);
                    nota2.RemoveAt(index);
                    nota3.RemoveAt(index);
                    medias.RemoveAt(index);

                    WriteLine();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("Pessoa excluída com sucesso!");
                    ResetColor();
                    break;
                }
                else if (confirmacao == "N")
                {
                    WriteLine("Exclusão cancelada!");
                    break;
                }
                else
                {
                    WriteLine("(S/N)!");
                }
            }
        } 
        else
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Pessoa não encontrada!!!");
            ResetColor();
        }   
    } 
  private static void Buscar()
{
    Clear();
    WriteLine();
    ForegroundColor = ConsoleColor.Blue;
    WriteLine(">>>> BUSCAR ALUNO <<<<");
    WriteLine();
    ResetColor();
    WriteLine("Digite o nome do aluno que deseja buscar:");
    string nomeBusca = ReadLine();
    int index = nomes.IndexOf(nomeBusca);
    if (index >= 0)
    {
        Clear();
        ForegroundColor = ConsoleColor.Blue;
        WriteLine(">>>> ALUNO ENCONTRADO <<<<");
        ResetColor();
        WriteLine($"Nome: {nomes[index]}");
        WriteLine($"Nota 1: {nota0[index]}");
        WriteLine($"Nota 2: {nota1[index]}");
        WriteLine($"Nota 3: {nota2[index]}");
        WriteLine($"Nota 4: {nota3[index]}");
        WriteLine($"Média: {medias[index]:F2}");

        string situacao;
        ConsoleColor corSituacao;

        if (medias[index] >= 7)
        {
            situacao = "Aprovado";
            corSituacao = ConsoleColor.Green;
        }
        else if (medias[index] <= 4)
        {
            situacao = "Reprovado";
            corSituacao = ConsoleColor.Red;
        }
        else
        {
            situacao = "Recuperação";
            corSituacao = ConsoleColor.Yellow;
        }

        Write("Situação: ");
        ForegroundColor = corSituacao;
        WriteLine(situacao);
        ResetColor();
    }
    else
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine("Aluno não encontrado!!!");
        ResetColor();
    }
}


    private static void Salvar()
    {
        Clear();
        WriteLine();
        WriteLine(">>>> GRAVAR OS DADOS <<<<");
        try
        {
            string path = @"C:\testecode\dados.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < nomes.Count; i++)
                {
                    writer.WriteLine($"{nomes[i]},{nota0[i]},{nota1[i]},{nota2[i]},{nota3[i]},{medias[i]:F2}");
                }
            }
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Dados salvos com sucesso!");
            ResetColor();
        }
        catch (Exception erro)
        {
            WriteLine(erro.Message);
        }
    }
    private static void Ler()
   {
    Clear();
    WriteLine();
    WriteLine(">>>> LER O ARQUIVO <<<<");
    WriteLine();
    try
    {
      string arq = @"C:\testecode\dados.txt";
      string[] linhas = File.ReadAllLines(arq);

    
      nomes.Clear();
      nota0.Clear();
      nota1.Clear();
      nota2.Clear();
      nota3.Clear();
      medias.Clear();

      for (int i = 0; i < linhas.Length; i++)
      {
        string[] dados = linhas[i].Split(',');
        nomes.Add(dados[0]);
        nota0.Add(int.Parse(dados[1]));
        nota1.Add(int.Parse(dados[2]));
        nota2.Add(int.Parse(dados[3]));
        nota3.Add(int.Parse(dados[4]));
        medias.Add(double.Parse(dados[5]));
       }

       WriteLine("Leitura de dados concluída com sucesso!");
    }
    catch (Exception erro)
    {
       WriteLine($"Erro ao ler o arquivo: {erro.Message}");

    }

  }
  private static void Sair()
  {
    Clear();
    ForegroundColor = ConsoleColor.Blue;
    WriteLine("Sistema Encerrado!");
    ResetColor();
    Environment.Exit(0);
  }
 }
}
