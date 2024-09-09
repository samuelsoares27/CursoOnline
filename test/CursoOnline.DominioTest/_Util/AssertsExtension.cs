using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.DominioTest._Util
{
    public static class AssertsExtension
    {
        public static void WithMessage(this ArgumentException exception, string message)
        {
            if(exception.Message == message)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"Mensagem Esperada: {message}");
            }
        }
    }
}
