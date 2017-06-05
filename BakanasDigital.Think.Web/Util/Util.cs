
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.WebPages.Html;

namespace BakanasDigital.Think.Web.Util
{
    public static class Util
    {
        public static IList<SelectListItem> ListGenero()
        {
            IList<SelectListItem> v_List = new List<SelectListItem>();
            v_List.Add(new SelectListItem { Value = "0", Text = " " });
            v_List.Add(new SelectListItem { Value = Constantes.Genero.GeneroID.MASCULINO.ToString(), Text = Constantes.Genero.GeneroDescricao.MASCULINO });
            v_List.Add(new SelectListItem { Value = Constantes.Genero.GeneroID.FEMININO.ToString(), Text = Constantes.Genero.GeneroDescricao.FEMININO });
            v_List.Add(new SelectListItem { Value = Constantes.Genero.GeneroID.OUTRO.ToString(), Text = Constantes.Genero.GeneroDescricao.OUTRO });
         
            return v_List;
        }

        public static IList<SelectListItem> ListComoTratar()
        {
            IList<SelectListItem> v_List = new List<SelectListItem>();
            v_List.Add(new SelectListItem { Value = "0", Text = " " });
            v_List.Add(new SelectListItem { Value = Constantes.ComoSerTratado.ComoSerTratadoID.SR.ToString(), Text = Constantes.ComoSerTratado.ComoSerTratadoDescricao.SR });
            v_List.Add(new SelectListItem { Value = Constantes.ComoSerTratado.ComoSerTratadoID.SRA.ToString(), Text = Constantes.ComoSerTratado.ComoSerTratadoDescricao.SRA });
            v_List.Add(new SelectListItem { Value = Constantes.ComoSerTratado.ComoSerTratadoID.DR.ToString(), Text = Constantes.ComoSerTratado.ComoSerTratadoDescricao.DRA });
            v_List.Add(new SelectListItem { Value = Constantes.ComoSerTratado.ComoSerTratadoID.INFORMAL.ToString(), Text = Constantes.ComoSerTratado.ComoSerTratadoDescricao.INFORMAL });
            v_List.Add(new SelectListItem { Value = Constantes.ComoSerTratado.ComoSerTratadoID.APELIDO.ToString(), Text = Constantes.ComoSerTratado.ComoSerTratadoDescricao.APELIDO });
            v_List.Add(new SelectListItem { Value = Constantes.ComoSerTratado.ComoSerTratadoID.OUTRO.ToString(), Text = Constantes.ComoSerTratado.ComoSerTratadoDescricao.OUTRO });

            return v_List;
        }

        public static IList<SelectListItem> ListComplemento()
        {
            IList<SelectListItem> v_List = new List<SelectListItem>();
            v_List.Add(new SelectListItem { Value = "0", Text = " " });
            v_List.Add(new SelectListItem { Value = Constantes.Complemento.ComplementoID.CASA.ToString(), Text = Constantes.Complemento.ComplementoDescricao.CASA});
            v_List.Add(new SelectListItem { Value = Constantes.Complemento.ComplementoID.APARTAMENTO.ToString(), Text = Constantes.Complemento.ComplementoDescricao.APARTAMENTO });

            return v_List;
        }

    }
}