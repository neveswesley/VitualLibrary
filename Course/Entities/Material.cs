namespace Course.Entities;

public abstract class Material
{
    public string Titulo { get; set; }
    public int Ano { get; set; }

    public Material()
    {
        
    }
    public Material(string titulo, int ano)
    {
        Titulo = titulo;
        Ano = ano;
    }
    public abstract void ExibirDetalhes();

}