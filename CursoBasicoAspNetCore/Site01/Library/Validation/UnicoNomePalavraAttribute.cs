using Site01.DataBase;
using Site01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Validation
{
    public class UnicoNomePalavraAttribute :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Palavra palavra = validationContext.ObjectInstance as Palavra;

            var _db = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));//instancia com tudo configurado do banco de dados.

            var palavraBanco = _db.Palavras.Where(a => a.Nome == palavra.Nome && a.Id != palavra.Id).FirstOrDefault();

            if(palavraBanco == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"A palavra {palavra.Nome} já existe no banco!");
            }
        }

    }
}
