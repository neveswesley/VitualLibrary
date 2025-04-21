using System.Threading.Channels;
using Course.Entities;

namespace Course.UI;

public class UserMenu
{
    private Biblioteca biblioteca;
    private List<Material> list;

    public UserMenu()
    {
        biblioteca = new Biblioteca();
    }

    public void MainMenu()
    {
        Console.WriteLine("MENU INICIAL");
        Console.Write(
            "Qual operação deseja realizar? (1) Adicionar material / (2) Buscar material / (3) Remover material / (4) Atualizar material / (0) Sair: ");
        var opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1: AdicionarMateriais(); break;
            case 2: BuscarMateriais(); break;
            case 3: RemoverMateriais(); break;
            case 4: AtualizarMateriais(); break;
            case 0: break;
        }
    }

    public void AdicionarMateriais()
    {
        Console.Write("(1) Adicionar livro / (2) Adicionar revista / (0) Voltar ao Menu principal: ");
        var opcao = int.Parse(Console.ReadLine());

        if (opcao == 1)
        {
            Console.Write("Informe o Id do livro: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Informe o nome do livro: ");
            var nome = Console.ReadLine();
            Console.Write("Informe o ano de lançamento do livro: ");
            var ano = int.Parse(Console.ReadLine());
            Console.Write("Informe o autor do livro: ");
            var autor = Console.ReadLine();
            Console.Write("Informe o número de páginas do livro: ");
            var paginas = int.Parse(Console.ReadLine());
            biblioteca.AdicionarMaterial(new Livro(id, nome, ano, autor, paginas));
            Console.WriteLine();
            MainMenu();
        }

        else if (opcao == 2)
        {
            Console.Write("Informe o Id da revista: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Informe o nome da revista: ");
            var nome = Console.ReadLine();
            Console.Write("Informe o ano da revista: ");
            var ano = int.Parse(Console.ReadLine());
            Console.Write("Informe o número da edição da revista: ");
            var edicao = int.Parse(Console.ReadLine());
            Console.Write("Informe o mês de lançamento da revista: ");
            var mes = Console.ReadLine();
            biblioteca.AdicionarMaterial(new Revista(id, nome, ano, edicao, mes));
            Console.WriteLine();
            MainMenu();
        }

        else if (opcao == 0)
        {
            Console.WriteLine();
            MainMenu();
        }
    }

    public void BuscarMateriais()
    {
        Console.Write(
            "(1) Buscar livro / (2) Buscar revista / (3) Exibir todos os materiais / (0) Voltar ao Menu principal: ");
        var opcao = int.Parse(Console.ReadLine());
        if (opcao == 1)
        {
            Console.Write("(1) Buscar por titulo / (2) Exibir todos os livros / (0) Voltar ao Menu Principal: ");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.Write("Informe o nome do livro: ");
                    var palavra = Console.ReadLine();
                    var livros = biblioteca.ObterLivros(palavra);
                    var totalLivros = 0;
                    Console.WriteLine();
                    foreach (var livro in livros)
                    {
                        totalLivros++;
                    }

                    Console.WriteLine($"------ Livros encontrados: {totalLivros} ------ ");
                    foreach (var livro in livros)
                    {
                        livro.ExibirDetalhes();
                    }

                    break;

                case 2:
                    livros = biblioteca.ObterTodosOsLivros();
                    Console.WriteLine();
                    var count = 0;
                    foreach (var livro in livros)
                    {
                        count++;
                    }

                    Console.WriteLine($"------ Livros encontrados: {count} ------ ");
                    foreach (var livro in livros)
                    {
                        livro.ExibirDetalhes();
                    }

                    break;
            }

            Console.WriteLine();
            MainMenu();
        }

        else if (opcao == 2)
        {
            Console.Write("(1) Buscar por titulo / (2) Exibir todas as revistas / (0) Menu Principal: ");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.Write("Informe o nome da revista: ");
                    var palavra = Console.ReadLine();
                    var revistas = biblioteca.ObterRevistas(palavra);
                    var totalRevistas = 0;
                    Console.WriteLine();
                    foreach (var revista in revistas)
                    {
                        totalRevistas++;
                    }

                    Console.WriteLine($"------ Revistas encontradas: {totalRevistas} ------ ");
                    foreach (var revista in revistas)
                    {
                        revista.ExibirDetalhes();
                    }

                    break;

                case 2:
                    revistas = biblioteca.ObterTodasAsRevistas();
                    Console.WriteLine();
                    var count = 0;
                    foreach (var revista in revistas)
                    {
                        count++;
                    }

                    Console.WriteLine($"------ Revistas encontradas: {count} ------ ");
                    foreach (var revista in revistas)
                    {
                        revista.ExibirDetalhes();
                    }

                    break;
            }

            Console.WriteLine();
            MainMenu();
        }


        else if (opcao == 3)

        {
            var materiais = biblioteca.ObterTodos();
            var livros = materiais.OfType<Livro>().ToList();
            var contagem = 0;

            foreach (var livro in livros)
            {
                contagem++;
            }

            Console.WriteLine($"\n----- LIVROS ENCONTRADOS: {contagem} -----");

            if (livros.Any())
            {
                foreach (var livro in livros)
                {
                    livro.ExibirDetalhes();
                }
            }

            else
            {
                Console.WriteLine("Nenhum livro encontrado");
            }

            var revistas = materiais.OfType<Revista>().ToList();
            if (revistas.Any())
            {
                var count = 0;

                foreach (var revista in revistas)
                {
                    count++;
                }

                Console.WriteLine($"\n----- REVISTAS ENCONTRADAS: {count} -----");


                foreach (var revista in revistas)
                {
                    revista.ExibirDetalhes();
                }
            }

            else
            {
                Console.WriteLine("Nenhum revista encontrada");
            }

            Console.WriteLine();
            MainMenu();
        }

        else if (opcao == 0)
        {
            Console.WriteLine();
            MainMenu();
        }
    }

    public void RemoverMateriais()
    {
        var materiais = new List<Biblioteca>();
        
        Console.Write("Informe o Id do material: ");
        var input = Console.ReadLine();

        if (!int.TryParse(input, out int id))
        {
            Console.WriteLine("Id invalido! Por favor, insira um número inteiro.");
            MainMenu();
            return;
        }

        var itens = biblioteca.ObterTodos();
        var remover = itens.FirstOrDefault(x => x.Id == id);

        if (remover != null)
        {
            Console.WriteLine($"Material encontrado: ");
            remover.ExibirDetalhes();
            Console.WriteLine();

            Console.Write("Deseja remover esse material? (1) Sim / (2) Não: ");
            var resposta = int.Parse(Console.ReadLine());
            if (resposta == 1)
            {
                biblioteca.RemoverMaterial(id);
                Console.WriteLine("Material removido com sucesso!");
            }
            else if (resposta == 2)
            {
                Console.WriteLine("Material não removido!");
            }
        }
        else
        {
            Console.WriteLine("Nenhum material encontrado com esse Id.");
        }


        
        MainMenu();
        
    }

    public void AtualizarMateriais()
    {
    }
}