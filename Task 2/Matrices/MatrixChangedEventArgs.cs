using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Matrices
{
    public class MatrixChangedEventArgs : EventArgs
    {
        public int i;
        public int j;

        public MatrixChangedEventArgs(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }
}
