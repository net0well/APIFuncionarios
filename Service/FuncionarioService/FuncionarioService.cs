using Microsoft.EntityFrameworkCore;
using System.Linq;
using APIFuncionarios.DataContext;
using APIFuncionarios.Models;

namespace APIFuncionarios.Service.FuncionarioService
{

    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;

        // criando a conexão com o banco
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context; // recebe o banco de dados
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoFuncionario); // adiciona no banco
                await _context.SaveChangesAsync(); // salva as alterações no banco

                serviceResponse.Dados = _context.Funcionarios.ToList(); // retorna os dados cadastrados no banco.


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message; // retorna uma msg com o erro
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>(); //retorna uma lista de FuncionarioModek

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar usuário a ser deletado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();                

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message; // retorna uma msg com o erro
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                // x recebe todas as caracteristicas do funcionario e verifica se o Id é igual ao id vindo pelo parametro
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                    serviceResponse.Sucesso = false;

                }

                serviceResponse.Dados = funcionario;

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            // serviceResponse é do tipo ServiceResponse<List<FuncionarioModel>> e recebe a lista dos dados dos funcionários.
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList(); // recebe a lista de funcionarios do banco 

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message; // retorna uma msg com o erro
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id); // pega o funcionario de acordo com o id

                if(funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar usuário a ser inativado!";
                    serviceResponse.Sucesso = false;
                }

                funcionario.Ativo = false; // inativa o funcionario
                funcionario.DateDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario); // atualiza no banco a alteração
                await _context.SaveChangesAsync(); // salva as alterações

                serviceResponse.Dados = _context.Funcionarios.ToList(); //retorna os dados atualizados

            } catch (Exception ex)
            {
                serviceResponse.Mensagem = $"ops, deu errado, seu funcionário continua ativo. {ex.Message}";
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }

                funcionario.DateDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(editadoFuncionario);

                await _context.SaveChangesAsync();

                serviceResponse.Dados.ToList();
            }
            catch (Exception ex) { 
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
