using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Mediciones
{
    string id;
    Double medicion;
    DateTime fecha;

    public string Id { get => id; set => id = value; }
    public double Medicion { get => medicion; set => medicion = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
}