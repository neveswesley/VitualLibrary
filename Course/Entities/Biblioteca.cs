namespace Course.Entities;

public class Biblioteca
{
    private List<Material> materiais = new List<Material>();
    public Biblioteca()
    {

        // Lista de Livros
        materiais.Add(new Livro
        {
            Titulo = "Programação Estruturada",
            Ano = 2017,
            Autor = "Aline Marques",
            Paginas = 320
        });

        materiais.Add(new Livro
        {
            Titulo = "C# Profissional",
            Ano = 2020,
            Autor = "João Pedro Lima",
            Paginas = 410
        });

        materiais.Add(new Livro
        {
            Titulo = "Desenvolvimento Ágil com .NET",
            Ano = 2023,
            Autor = "Camila Barbosa",
            Paginas = 365
        });

        materiais.Add(new Livro
        {
            Titulo = "Introdução ao LINQ",
            Ano = 2019,
            Autor = "Rafael Gonçalves",
            Paginas = 290
        });

        materiais.Add(new Livro
        {
            Titulo = "Arquitetura de Software Moderna",
            Ano = 2022,
            Autor = "Patrícia Leal",
            Paginas = 450
        });

        // Lista de Revistas
        materiais.Add(new Revista
        {
            Titulo = "TechCode",
            Ano = 2021,
            Edicao = 38,
            MesPublicacao = "Julho"
        });

        materiais.Add(new Revista
        {
            Titulo = "Programadores BR",
            Ano = 2022,
            Edicao = 52,
            MesPublicacao = "Março"
        });

        materiais.Add(new Revista
        {
            Titulo = "Revista .NET",
            Ano = 2020,
            Edicao = 29,
            MesPublicacao = "Outubro"
        });

        materiais.Add(new Revista
        {
            Titulo = "Dev Trends",
            Ano = 2023,
            Edicao = 61,
            MesPublicacao = "Janeiro"
        });

        materiais.Add(new Revista
        {
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

    public void AdicionarMaterial(Material material)
    {
     materiais.Add(material);   
    }
    
}