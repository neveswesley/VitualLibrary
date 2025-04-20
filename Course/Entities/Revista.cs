namespace Course.Entities;

public class Revista : Material
{
    public int Edicao { get; set; }
    public string MesPublicacao { get; set; }

    public Revista()
    {
        
    }
    public Revista(string titulo, int ano, int edicao, string mesPublicacao):base(titulo, ano)
    {
        Edicao = edicao;
        MesPublicacao = mesPublicacao;
    }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"Titulo: {Titulo}. Ano: {Ano}. Edição: {Edicao}. Mês Publicação: {MesPublicacao}.");
    }
}