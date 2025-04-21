namespace Course.Entities;

public class Livro : Material
{

    public string Autor { get; set; }
    public int Paginas { get; set; }

    public Livro()
    {
        
    }
    public Livro(int id, string titulo, int ano, string autor, int paginas) :base(id, titulo, ano)
    {
    Autor = autor;
    Paginas = paginas;
    }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"Titulo: {Titulo}. Ano: {Ano}. Autor: {Autor}. Páginas: {Paginas}.");
    }
}