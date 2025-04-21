namespace Course.Entities;

public abstract class Material
{

    public int Id { get; set; }
    public string Titulo { get; set; }
    public int Ano { get; set; }

    public Material()
    {
        
    }
    public Material(int id, string titulo, int ano)
    {
        Id = id;
        Titulo = titulo;
        Ano = ano;
    }
    public abstract void ExibirDetalhes();

}