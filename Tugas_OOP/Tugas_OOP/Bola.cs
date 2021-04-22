using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_OOP
{
    class Bola
    {
        public int jariJari { get; set; }
        
        public Bola()
        {
        }
        public Bola(int JariJari)
        {
            this.jariJari = JariJari;
        }

        public double volume(int r)
        {
            return 3.14 * r * r * r * 4 / 3;
        }

    }
}
