namespace Course.Entities;

public class Administrador : IUsuario
{
    public string Nome { get; set; }

    public Administrador(string nome)
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