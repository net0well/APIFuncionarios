
namespace APIFuncionarios.Models
{
    public class ServiceResponse<T> // recebe um valor genérico
    {
        public T? Dados { get; set; } // pode receber um valor numérico ou nulo (?)

        public string Mensagem { get; set; } = string.Empty;

        public bool Sucesso { get; set; } = true;

        public static implicit operator ServiceResponse<T>(ServiceResponse<List<FuncionarioModel>> v)
        {
            throw new NotImplementedException();
        }
    }
}
