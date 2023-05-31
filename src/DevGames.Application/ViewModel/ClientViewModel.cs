using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevGames.Application.ViewModel
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O Número de telefone é obrigatório")]
        [RegularExpression("\\+\\d+[ ]?\\(?\\d+\\)?[ ]?\\d+[-. ]?\\d+", ErrorMessage = "Informe um número de telefone válido")]
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
