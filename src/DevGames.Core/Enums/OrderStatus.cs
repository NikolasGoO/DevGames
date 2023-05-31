using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevGames.Core.Enums
{
    public enum OrderStatus
    {
        Criado = 1,
        Autorizado = 2,
        EmProcessamento = 3,
        Pago = 4,
        Recusado = 5,
        Entregue = 6,
        Cancelado = 7
    }
}
