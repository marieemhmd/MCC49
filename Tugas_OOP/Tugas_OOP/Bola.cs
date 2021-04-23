using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_OOP
{
    class Bola
    {
        public int JariJari { get; set; }
        
        public Bola()
        {
        }
        public Bola(int jariJari)
        {
            this.JariJari = jariJari;
        }

        public double Volume(int r)
        {
            return 3.14 * r * r * r * 4 / 3;
        }

    }
}
