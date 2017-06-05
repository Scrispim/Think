using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakanasDigital.Think.Web.Util
{
    public class Genero
    {
        public int GeneroID = 0;
        public string Descricao = string.Empty;

        public Genero(int p_GeneroID, string p_Descricao)
        {
            GeneroID = p_GeneroID;
            Descricao = p_Descricao;
        }
    }
}