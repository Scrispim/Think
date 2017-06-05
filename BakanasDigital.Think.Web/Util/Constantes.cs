using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakanasDigital.Think.Web.Util
{
    public static class Constantes
    {
        public static class Genero
        {
            public static class GeneroID
            {
                public const int MASCULINO = 1;
                public const int FEMININO = 2;
                public const int OUTRO = 2;
            }
            public static class GeneroDescricao
            {
                public const string MASCULINO = "Masculino";
                public const string FEMININO = "Feminino";
                public const string OUTRO = "Outro";
            }
        }

        public static class ComoSerTratado
        {
            public static class ComoSerTratadoID
            {
                public const int SR = 1;
                public const int SRA = 2;
                public const int DR = 3;
                public const int DRA = 4;
                public const int INFORMAL = 5;
                public const int APELIDO = 6;
                public const int OUTRO = 7;
            }
            public static class ComoSerTratadoDescricao
            {
                public const string SR = "Sr.";
                public const string SRA = "Sra.";
                public const string DR = "Dr.";
                public const string DRA = "Dra.";
                public const string INFORMAL = "Informalmente";
                public const string APELIDO = "Apelido";
                public const string OUTRO = "Outro";
            }
        }

        public static class Complemento
        {
            public static class ComplementoID
            {
                public const int CASA = 1;
                public const int APARTAMENTO = 2;
            }
            public static class ComplementoDescricao
            {
                public const string CASA = "Casa";
                public const string APARTAMENTO = "Apartamento";
            }
        }

    }
}