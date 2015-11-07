using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Validators
{
    class ErrorMessages
    {
        public static string[] multipleAttributeErrorMessages = new string[]
        {
            "Não pode ficar em branco",
            "Data não é válida",
            "Número não é valido",
            "Não existe registro com este código",
            "Não contém @",
            "É diferente do outro valor"
        };
        public static string[] passwordValidatorErrorMessages = new string[]
        {
            "Senha muito curta (mínimo 6 caracteres)",
            "Senha muito longa (maximo 10 caracteres)",
            "Não pode conter espaços",
            "São permitidas apenas letras e números",
            "Não contém letras máiúsculas e minúsculas",
            "Deve conter pelo menos 2 números",
            "Deve conter pelo menos 2 letras",
            "Contém letras repetidas",
            "Contém números repetidos",
            "Não pode ser igual a senha antiga",
            "Não pode ser igual a o código",
            "É muito fraca"
        };

        public static string[] passwordValidatorWarningMessages = new string[]
        {
            "Contém números em sequencia",
            "Contém menos de 2 letras",
            "Contém menos de 2 números",
            "Contém código do usuário",
            "Contém o primeiro nome",
            "Contém as iniciais do nome",
            "Contém a data de nascimento",
            "Contém o dia e o mes do nascimento",
            "Contém a data de nascimento inversa",
            "Contém o mes e o dia do nascimento"
        };
    }
}
