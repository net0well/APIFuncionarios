using APIFuncionarios.Models;

namespace APIFuncionarios.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios(); // retorna todos os funcionarios do banco
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario); // cria um novo funcionario e retorna uma nova lista
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id); // retorna o funcionario por ID
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario); // atualiza o funconario e retorna uma lista com todos os funcionarios
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id); // deleta e retorna uma lista sem o funcionario deletado
        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id); // inativa e retorna uma lista com o funcionario inativo


    }
}
