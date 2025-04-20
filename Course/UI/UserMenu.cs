using Course.Entities;

namespace Course.UI;

public class UserMenu
{
    private Biblioteca biblioteca;
    private List<Biblioteca> materiais = new List<Biblioteca>();

    public UserMenu()
    {
        biblioteca = new Biblioteca();
    }

    public void MainMenu()
    {
        Console.WriteLine("MENU INICIAL");
        Console.WriteLine(
            "Qual operação deseja realizar? (1 - Adicionar material / 2 - Buscar material / 3 - Remover material / 4 - Atualizar material / 0 - Sair");
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
        Console.WriteLine("1 - Adicionar livro / 2 - Adicionar revista / 0 - Menu principal");
        var opcao = int.Parse(Console.ReadLine());

        if (opcao == 1)
        {
            Console.WriteLine("Informe o nome do livro: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Informe o ano de lançamento do livro: ");
            var ano = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o autor do livro: ");
            var autor = Console.ReadLine();
            Console.WriteLine("Informe o número de páginas do livro: ");
            var paginas = int.Parse(Console.ReadLine());
            biblioteca.AdicionarMaterial(new Livro(nome, ano, autor, paginas));
            Console.WriteLine();
            MainMenu();
        }

        else if (opcao == 2)
        {
            Console.WriteLine("Informe o nome da revista: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Informe o ano da revista: ");
            var ano = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o número da edição da revista: ");
            var edicao = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o mês de lançamento da revista: ");
            var mes = Console.ReadLine();
            biblioteca.AdicionarMaterial(new Revista(nome, ano, edicao, mes));
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
        Console.WriteLine("1 - Buscar livro / 2 - Buscar revista / 3 - Exibir todos os materiais / 0 - Menu principal");
        var opcao = int.Parse(Console.ReadLine());
        if (opcao == 1)
        {
            Console.WriteLine("1 - Buscar por titulo / 2 - Exibir todos os livros / 0 - Menu Principal");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o nome do livro: ");
                    var palavras = Console.ReadLine();
                    var livros = biblioteca.ObterTodos()
                        .OfType<Livro>()
                        .Where(x => x.Titulo.ToLower().Contains(palavras.ToLower()))
                        .ToList();
                    Console.WriteLine();
                    if (livros.Any())
                    {
                        var count = 0;
                        foreach (var livro in livros)
                        {
                            count++;
                        }

                        Console.WriteLine($"Livros encontradas: {count}");
                        foreach (var livro in livros)
                        {
                            livro.ExibirDetalhes();
                        }
                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Nenhum livro encontrado");
                        Console.WriteLine();
                    }

                    break;

                case 2:
                    Console.WriteLine();
                    var lista = biblioteca.ObterTodos().OfType<Livro>().ToList();

                    var contagem = 0;
                    foreach (var item in lista)
                    {
                        contagem++;
                    }

                    Console.WriteLine($"Livros encontrados: {contagem}");
                    
                    foreach (var item in lista)
                    {
                        item.ExibirDetalhes();
                    }

                    break;

                case 0:
                    MainMenu();
                    break;
            }

            Console.WriteLine();
            MainMenu();
        }

        else if (opcao == 2)
        {
            Console.WriteLine("1 - Buscar por titulo / 2 - Exibir todas as revistas / 0 - Menu Principal");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o nome da revista: ");
                    var palavras = Console.ReadLine();
                    var revistas = biblioteca.ObterTodos()
                        .OfType<Revista>()
                        .Where(x => x.Titulo.ToLower().Contains(palavras.ToLower()))
                        .ToList();
                    Console.WriteLine();
                    if (revistas.Any())
                    {
                        var count = 0;
                        foreach (var revista in revistas)
                        {
                            count++;
                        }

                        Console.WriteLine($"Revistas encontradas: {count}");
                        foreach (var revista in revistas)
                        {
                            revista.ExibirDetalhes();
                        }
                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Nenhuma revista encontrado");
                        Console.WriteLine();
                    }

                    break;

                case 2:

                    Console.WriteLine();
                    var lista = biblioteca.ObterTodos().OfType<Revista>().ToList();
                    
                    var contagem = 0;
                    foreach (var item in lista)
                    {
                        contagem++;
                    }

                    Console.WriteLine($"Revistas encontradas: {contagem}");
                    foreach (var item in lista)
                    {
                        item.ExibirDetalhes();
                    }

                    break;

                case 0:
                    MainMenu();
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
                Console.WriteLine($"\n----- REVISTAS ENCONTRADAS: {count}-----");

                
                
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
    }

    public void AtualizarMateriais()
    {
    }
}