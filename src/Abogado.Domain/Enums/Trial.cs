using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Enums
{
    public enum Trial
    {
        Inicio_del_divorcio = 0,
        Introduccion_demanda = 1,
        Aviso_conyuge = 2,
        Respuesta_conyuge_notificado= 3,
        Intercambio_documentos =4,
        Proceso_mediacion = 5,
        Aceptacion_acuerdo = 6,
        Acta_divorcio=7,
        Juicio_divorcio=8,
        Apelacion=9
    }
}
