﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Empleado
{
    public int IdEmpledo { get; set; }

    public string? NumeroNomina { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public int? IdEstado { get; set; }

    public virtual CatEntidadFederativa? IdEstadoNavigation { get; set; }

    public string Estado { get; set; }
}
