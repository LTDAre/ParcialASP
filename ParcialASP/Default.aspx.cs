using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : Page
{

    static List<Departamento> departamentos = new List<Departamento>();
    static List<Mediciones> mediciones = new List<Mediciones>();
    static List<Presentacion> presentacions = new List<Presentacion>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carga();
        }
    }

    protected void Carga()
    {
        var lecturas = Server.MapPath("~/Mediciones.txt");

        FileStream stream = new FileStream(lecturas, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);

        while (reader.Peek() > -1)
        {
            Mediciones medida = new Mediciones();

            medida.Id = reader.ReadLine();
            medida.Medicion = Convert.ToDouble(reader.ReadLine());
            medida.Fecha = Convert.ToDateTime(reader.ReadLine());

            mediciones.Add(medida);

        }

        reader.Close();

        var lugares = Server.MapPath("~/Departamentos.txt");

        stream = new FileStream(lugares, FileMode.Open, FileAccess.Read);
        reader = new StreamReader(stream);

        while (reader.Peek() > -1)
        {
            Departamento places = new Departamento();
            places.Cod = reader.ReadLine();
            places.Nombre = reader.ReadLine();

            departamentos.Add(places);
        }

        reader.Close();

        DropDownList1.DataValueField = "Cod";
        DropDownList1.DataTextField = "Nombre";
        DropDownList1.DataSource = departamentos;
        DropDownList1.DataBind();
    }

    protected void Escritura()
    {
        var archivo = Server.MapPath("~/Mediciones.txt");

        FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);

        StreamWriter writer = new StreamWriter(stream);

        foreach (var p in mediciones)
        {
            writer.WriteLine(DropDownList1.SelectedValue);
            writer.WriteLine(TextBox1.Text);
            writer.WriteLine(DateTime.Now.Date);
        }
       
        writer.Close();
    }

    protected void refrescar()
    {
        mediciones.Clear();
        GridView1.DataSource = null;
        presentacions.Clear();
        Carga();

        double promedio = mediciones.Average(m => m.Medicion);
        Label1.Text = promedio.ToString();

        foreach (var m in mediciones)
        {
            Departamento depto = departamentos.Find(d => d.Cod == m.Id);

            Presentacion repo = new Presentacion();

            repo.Medicion = m.Medicion;
            repo.Nombre = depto.Nombre;

            presentacions.Add(repo);

        }

        GridView1.DataSource = presentacions;
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        refrescar();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        mediciones.Clear();
        Escritura();
        TextBox1.Text = "";
    }
}