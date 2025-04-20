namespace Course.Entities;

public class Leitor : IUsuario
{
    public string Nome { get; set; }

    public Leitor(string nome)
    {
        Nome = nome;
    }


    public void ExibirInfo()
    {
        throw new NotImplementedException();
    }

    public void BuscarMaterialPorTitulo(string titulo)
    {
        throw new NotImplementedException();
    }
}