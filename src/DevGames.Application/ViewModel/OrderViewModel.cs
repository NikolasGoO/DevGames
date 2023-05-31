using DevGames.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevGames.Application.ViewModel
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo ClientId é obrigatório")]
        public Guid ClientId { get; set; }
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Quantidade de caracteres inválidos")]
        public string? Code { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
