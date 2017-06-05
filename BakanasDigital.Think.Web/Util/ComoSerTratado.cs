using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakanasDigital.Think.Web.Util
{
    public class ComoSerTratado
    {
        public int ID = 0;
        public string Descricao = string.Empty;

        public ComoSerTratado(int p_ID, string p_Descricao)
        {
            ID = p_ID;
            Descricao = p_Descricao;
        }
    }
}