namespace Course.Entities;

public class Biblioteca
{
    private List<Material> materiais = new List<Material>();
    public Biblioteca()
    {

        // Lista de Livros
        materiais.Add(new Livro
        {
            Id = 1,
            Titulo = "Programação Estruturada",
            Ano = 2017,
            Autor = "Aline Marques",
            Paginas = 320
        });

        materiais.Add(new Livro
        {
            Id = 2,
            Titulo = "C# Profissional",
            Ano = 2020,
            Autor = "João Pedro Lima",
            Paginas = 410
        });

        materiais.Add(new Livro
        {
            Id = 3,
            Titulo = "Desenvolvimento Ágil com .NET",
            Ano = 2023,
            Autor = "Camila Barbosa",
            Paginas = 365
        });

        materiais.Add(new Livro
        {
            Id = 4,
            Titulo = "Introdução ao LINQ",
            Ano = 2019,
            Autor = "Rafael Gonçalves",
            Paginas = 290
        });

        materiais.Add(new Livro
        {
            Id = 5,
            Titulo = "Arquitetura de Software Moderna",
            Ano = 2022,
            Autor = "Patrícia Leal",
            Paginas = 450
        });

        // Lista de Revistas
        materiais.Add(new Revista
        {
            Id = 6,
            Titulo = "TechCode",
            Ano = 2021,
            Edicao = 38,
            MesPublicacao = "Julho"
        });

        materiais.Add(new Revista
        {
            Id = 7,
            Titulo = "Programadores BR",
            Ano = 2022,
            Edicao = 52,
            MesPublicacao = "Março"
        });

        materiais.Add(new Revista
        {
            Id = 8,
            Titulo = "Revista .NET",
            Ano = 2020,
            Edicao = 29,
            MesPublicacao = "Outubro"
        });

        materiais.Add(new Revista
        {
            Id = 9,
            Titulo = "Dev Trends",
            Ano = 2023,
            Edicao = 61,
            MesPublicacao = "Janeiro"
        });

        materiais.Add(new Revista
        {
            Id = 10,
            Titulo = "Código & Café",
            Ano = 2024,
            Edicao = 75,
            MesPublicacao = "Maio"
        });
    }

    public List<Material> ObterTodos()
    {
        return materiais;
    }
    public List<Livro> ObterLivros(string palavra)
    {
        var material = ObterTodos().OfType<Livro>().Where(x => x.Titulo.ToLower().Contains(palavra.ToLower())).ToList();
        return material;
    }
    
    public List<Livro> ObterTodosOsLivros()
    {
        return materiais.OfType<Livro>().ToList();
    }


    public List<Revista> ObterRevistas(string palavra)
    {
        var material = ObterTodos().OfType<Revista>().Where(x => x.Titulo.ToLower().Contains(palavra.ToLower())).ToList();
        return material;
    }
    
    public List<Revista> ObterTodasAsRevistas()
    {
        return materiais.OfType<Revista>().ToList();
    }

    public void AdicionarMaterial(Material material)
    {
        materiais.Add(material);
    }

    public void RemoverMaterial(int requestId)
    {
       materiais.RemoveAll(x => x.Id == requestId);
    }
    
}