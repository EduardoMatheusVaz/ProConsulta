using System.Text.RegularExpressions;

namespace ProConsulta.Extensions
{
    public static class StringExtensions
    {

        public static string CharactersOnly(this string input)
        {
            if (string.IsNullOrEmpty(input)) //verifica se o input é nulo ou vazio
                return input;               // no caso de ser vazio, ele retorna o próprio valor para evitar o erro

            string pattern = @"[-\.(\)\s]"; // aqui eu defini um padrão de caracteres a ser removido

            string result = Regex.Replace(input, pattern, string.Empty); // aqui vou aplicar o regexReplace para procurar o padrão na input
                                                                        // substituir cada ocorrencia por "", removendo os caracteres           

            return result;
        }
    }
}
