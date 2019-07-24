using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class Cidade 
    {
        public int Id;

        public string Nome;

        public int NumeroHabitantes;

        public int EstadoId;
        public Estado Estado;

    }
}
