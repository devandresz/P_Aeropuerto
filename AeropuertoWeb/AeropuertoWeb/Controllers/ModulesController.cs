using AeropuertoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AeropuertoWeb.Controllers;

public class ModulesController : Controller
{
    private static readonly HashSet<string> ClientModules = new(StringComparer.OrdinalIgnoreCase)
    {
        "Vuelos", "Asientos", "Equipaje", "Migracion", "Factura", "ObjetosPerdidos"
    };

    public IActionResult Dashboard()
    {
        if (!IsAuthenticated())
        {
            return RedirectToAction("Login", "Auth");
        }

        var isAdmin = IsAdmin();
        var cards = GetCards().Where(card => isAdmin || ClientModules.Contains(card.Action)).ToList();

        return View(new ModuleDashboardViewModel
        {
            IsAdmin = isAdmin,
            Cards = cards
        });
    }

    public IActionResult Vuelos() => Module("Vuelos");
    public IActionResult Usuarios() => Module("Usuarios");
    public IActionResult Aerolineas() => Module("Aerolineas");
    public IActionResult Aeropuertos() => Module("Aeropuertos");
    public IActionResult Aviones() => Module("Aviones");
    public IActionResult Asientos() => Module("Asientos");
    public IActionResult Equipaje() => Module("Equipaje");
    public IActionResult Migracion() => Module("Migracion");
    public IActionResult Factura() => Module("Factura");
    public IActionResult ObjetosPerdidos() => Module("ObjetosPerdidos");
    public IActionResult Tarifas() => Module("Tarifas");
    public IActionResult Tripulacion() => Module("Tripulacion");
    public IActionResult HistorialVuelos() => Module("HistorialVuelos");

    private IActionResult Module(string key)
    {
        if (!IsAuthenticated())
        {
            return RedirectToAction("Login", "Auth");
        }

        if (!IsAdmin() && !ClientModules.Contains(key))
        {
            return RedirectToAction("Dashboard", "Cliente");
        }

        var page = BuildModule(key);
        page.IsAdmin = IsAdmin();
        page.IsClient = !page.IsAdmin;
        return View("Module", page);
    }

    private ModulePageViewModel BuildModule(string key)
    {
        return key switch
        {
            "Vuelos" => Page("Vuelos", "AER_VUELO", "Programacion de vuelos con origen, destino, salida, llegada, estado, usuario y avion.",
                Metrics(("Vuelos", "30"), ("Activos", "30"), ("Aviones", "30"), ("Usuarios vinculados", "30")),
                Fields(("Origen", "origen", "Ori 1"), ("Destino", "destino", "Des 1")),
                Headers("ID", "Ruta", "Salida", "Llegada", "Estado", "Usuario", "Avion"),
                Rows(Row("1", "Ori 1 - Des 1", "2026-05-15 10:00", "2026-05-15 12:00", Status("Activo"), "1", "1"),
                     Row("2", "Ori 2 - Des 2", "2026-05-15 10:00", "2026-05-15 12:00", Status("Activo"), "2", "2"),
                     Row("3", "Ori 3 - Des 3", "2026-05-15 10:00", "2026-05-15 12:00", Status("Activo"), "3", "3")),
                Form("vueloForm", "Nuevo vuelo", "Nuevo vuelo", "Formulario preparado para enviar al endpoint de AER_VUELO cuando el API este listo.",
                    Fields(("ID vuelo", "ID_vuelo", "31"), ("Origen", "Origen", "Ori 31"), ("Destino", "Destino", "Des 31"), ("Estado", "estado", "Activo"),
                        ("Fecha salida", "fecha_salida", "", "date"), ("Hora salida", "hora_salida", "", "time"), ("Fecha llegada", "fecha_llegada", "", "date"), ("Hora llegada", "hora_llegada", "", "time"),
                        ("ID usuario", "ID_Usuario", "1"), ("ID avion", "ID_avion", "1"))),
                Form("vueloForm", "Comprar boleto", "Comprar boleto", "Formulario conectado al endpoint temporal del backend.",
                    new[]
                    {
                        Field("ID vuelo", "idVuelo", "IB-6342"),
                        Field("Nombre", "nombre", "Nombre del pasajero"),
                        Field("Pasaporte", "pasaporte", "PAS1")
                    }, "Comprar boleto", "/Vuelo/TEMP_ComprarBoleto"),
                "/Vuelo/TEMP_BuscarVuelo"),

            "Usuarios" => Page("Usuarios", "AER_USUARIO", "Catalogo de usuarios con nombre, apellido, correo, contrasena y rol.",
                Metrics(("Usuarios", "30"), ("Admins", "1"), ("Roles de prueba", "29"), ("Clientes vinculables", "30")),
                Fields(("Buscar", "buscar", "Nombre, apellido o correo"), ("Rol", "Rol", "Admin"), ("ID usuario", "ID_Usuario", "1"), ("Correo", "Correo", "mcano@mail.com")),
                Headers("ID", "Nombre", "Apellido", "Correo", "Rol"),
                Rows(Row("1", "Maria Fernanda", "Cano Gonzalez", "mcano@mail.com", Status("Admin")),
                     Row("2", "Nom2", "Ape2", "c2@mail.com", Status("Rol 2", "neutral")),
                     Row("3", "Nom3", "Ape3", "c3@mail.com", Status("Rol 3", "neutral"))),
                Form("usuarioForm", "Nuevo usuario", "Nuevo usuario", "Formulario preparado para AER_USUARIO.",
                    Fields(("ID usuario", "ID_Usuario", "31"), ("Nombre", "Nombre", "Nombre"), ("Apellido", "Apellido", "Apellido"), ("Correo", "Correo", "correo@mail.com", "email"), ("Contrasena", "Contrasena", "Contrasena", "password"), ("Rol", "Rol", "Cliente o Admin")))),

            "Aerolineas" => Simple("Aerolineas", "AER_AEROLINEA", "Catalogo de aerolineas con codigo AITA, ciudad y pais.", "Nueva aerolinea", "aerolineaForm",
                Headers("ID", "Codigo AITA", "Ciudad", "Pais"),
                Rows(Row("1", "A1", "Ciudad 1", "Pais 1"), Row("2", "A2", "Ciudad 2", "Pais 2"), Row("3", "A3", "Ciudad 3", "Pais 3")),
                Fields(("ID aerolinea", "ID_AEROLINEA", "31"), ("Codigo AITA", "Codigo_AITA", "A31"), ("Ciudad", "Ciudad", "Ciudad 31"), ("Pais", "Pais", "Pais 31"))),

            "Aeropuertos" => Simple("Aeropuertos", "AER_AEROPUERTO", "Aeropuertos por nombre, ciudad, pais y aerolinea asociada.", "Agregar aeropuerto", "aeropuertoForm",
                Headers("ID", "Nombre", "Ciudad", "Pais", "ID aerolinea"),
                Rows(Row("1", "Aero 1", "Ciudad 1", "Pais 1", "1"), Row("2", "Aero 2", "Ciudad 2", "Pais 2", "2"), Row("3", "Aero 3", "Ciudad 3", "Pais 3", "3")),
                Fields(("ID aeropuerto", "ID_aeropuerto", "31"), ("Nombre", "Nombre", "Aero 31"), ("Ciudad", "Ciudad", "Ciudad 31"), ("Pais", "Pais", "Pais 31"), ("ID aerolinea", "ID_AEROLINEA", "1"))),

            "Aviones" => Simple("Aviones", "AER_AVION", "Inventario de aviones con modelo, capacidad y aeropuerto asociado.", "Registrar avion", "avionForm",
                Headers("ID", "Modelo", "Capacidad", "ID aeropuerto"),
                Rows(Row("1", "Modelo 1", "150", "1"), Row("2", "Modelo 2", "150", "2"), Row("3", "Modelo 3", "150", "3")),
                Fields(("ID avion", "ID_avion", "31"), ("Modelo", "Modelo", "Modelo 31"), ("Capacidad", "Capacidad", "150", "number"), ("ID aeropuerto", "AER_aeropuerto", "1"))),

            "Asientos" => SharedClient("Asientos", "AER_ASIENTO", "Reservas de asiento por cliente, fecha y estado.", "Asignar asiento", "asientoForm",
                Headers("ID asiento", "ID cliente", "Fecha reserva", "Estado reserva"),
                Rows(Row("1", "1", "2026-05-15", Status("Reservado")), Row("2", "2", "2026-05-15", Status("Reservado")), Row("3", "3", "2026-05-15", Status("Reservado"))),
                Fields(("ID asiento", "ID_asiento", "31"), ("ID cliente", "ID_cliente", "1"), ("Fecha reserva", "fecha_reserva", "", "date"), ("Estado reserva", "estado_reserva", "Reservado"))),

            "Equipaje" => SharedClient("Equipaje", "AER_EQUIPAJE", "Equipaje registrado por cliente y peso.", "Registrar equipaje", "equipajeForm",
                Headers("ID equipaje", "ID cliente", "Peso"),
                Rows(Row("1", "1", "20.50 kg"), Row("2", "2", "20.50 kg"), Row("3", "3", "20.50 kg")),
                Fields(("ID equipaje", "ID_equipaje", "31"), ("ID cliente", "ID_cliente", "1"), ("Peso", "Peso", "20.50", "number"))),

            "Migracion" => SharedClient("Migracion", "AER_MIGRACION", "Registro migratorio por cliente, destino, fecha y hora de salida.", "Nuevo registro", "migracionForm",
                Headers("ID migracion", "ID cliente", "Destino", "Fecha salida", "Hora salida"),
                Rows(Row("1", "1", "Des1", "2026-05-15", "10:00"), Row("2", "2", "Des2", "2026-05-15", "10:00"), Row("3", "3", "Des3", "2026-05-15", "10:00")),
                Fields(("ID migracion", "ID_migracion", "31"), ("ID cliente", "ID_cliente", "1"), ("Destino", "Destino", "Des31"), ("Fecha salida", "fecha_salida", "", "date"), ("Hora salida", "hora_salida", "", "time"))),

            "Factura" => SharedClient("Factura", "AER_FACTURA", "Facturas con total, numero, serie, cliente, fecha y hora.", "Emitir factura", "facturaForm",
                Headers("ID factura", "Numero", "Serie", "ID cliente", "Total", "Fecha y hora"),
                Rows(Row("1", "N1", "S1", "1", "150.00", "2026-05-15 10:00"), Row("2", "N2", "S2", "2", "150.00", "2026-05-15 10:00"), Row("3", "N3", "S3", "3", "150.00", "2026-05-15 10:00")),
                Fields(("ID factura", "ID_Factura", "31"), ("Total", "Total", "150.00", "number"), ("Numero", "Numero", "N31"), ("Serie", "Serie", "S31"), ("ID cliente", "ID_cliente", "1"), ("Fecha", "fecha", "", "date"), ("Hora", "hora", "", "time"))),

            "ObjetosPerdidos" => SharedClient("Objetos perdidos", "AER_OBJETPERDIDOS", "Reportes ligados a vuelo con descripcion, lugar de perdida, fecha, hora y estado.", "Nuevo reporte", "objetoForm",
                Headers("ID objeto", "ID vuelo", "Descripcion", "Lugar perdida", "Fecha y hora", "Estado"),
                Rows(Row("1", "1", "Objeto 1", "Lugar 1", "2026-05-15 11:00", Status("Perdido", "warning")), Row("2", "2", "Objeto 2", "Lugar 2", "2026-05-15 11:00", Status("Perdido", "warning")), Row("3", "3", "Objeto 3", "Lugar 3", "2026-05-15 11:00", Status("Perdido", "warning"))),
                Fields(("ID objeto perdido", "ID_objetperdidos", "31"), ("ID vuelo", "ID_vuelo", "1"), ("Descripcion", "Descripcion", "Objeto 31"), ("Lugar perdida", "Lugar_perdida", "Lugar 31"), ("Fecha", "Fecha", "", "date"), ("Hora", "Hora", "", "time"), ("Estado", "Estado", "Perdido"))),

            "Tarifas" => Simple("Tarifas", "AER_TARIFA / AER_CLASE", "Precios de tarifa y clases asociadas a vuelos.", "Nueva tarifa", "tarifaForm",
                Headers("ID tarifa", "Precio", "ID clase", "Clase", "ID vuelo"),
                Rows(Row("1", "100.00", "1", "Clase 1", "1"), Row("2", "105.00", "2", "Clase 2", "2"), Row("3", "110.00", "3", "Clase 3", "3")),
                Fields(("ID tarifa", "ID_tarifa", "31"), ("Precio", "Precio", "250.00", "number"), ("ID clase", "ID_clase", "31"), ("Clase", "Clase", "Clase 31"), ("ID vuelo", "ID_vuelo", "1"))),

            "Tripulacion" => Simple("Tripulacion", "AER_TRIPULACION", "Personal de tripulacion con nombre, apellido y rol.", "Nuevo tripulante", "tripulacionForm",
                Headers("ID", "Nombre", "Apellido", "Rol"),
                Rows(Row("1", "Trip1", "Ape1", "Rol1"), Row("2", "Trip2", "Ape2", "Rol2"), Row("3", "Trip3", "Ape3", "Rol3")),
                Fields(("ID tripulacion", "ID_tripulacion", "31"), ("Nombre", "Nombre", "Trip31"), ("Apellido", "Apellido", "Ape31"), ("Rol", "Rol", "Rol31"))),

            _ => Simple("Historial de vuelos", "AER_HISTORIALVUELO", "Historial por tripulacion, avion y fecha de salida.", "Nuevo historial", "historialForm",
                Headers("ID historial", "ID tripulacion", "ID avion", "Fecha salida"),
                Rows(Row("1", "1", "1", "2026-05-15"), Row("2", "2", "2", "2026-05-15"), Row("3", "3", "3", "2026-05-15")),
                Fields(("ID historial", "ID_historialvuelos", "31"), ("ID tripulacion", "ID_tripulacion", "1"), ("ID avion", "AVI_avion", "1"), ("Fecha salida", "FechaSalida", "", "date")))
        };
    }

    private ModulePageViewModel Simple(string title, string eyebrow, string description, string buttonText, string anchor, IReadOnlyList<string> headers, IReadOnlyList<IReadOnlyList<CellViewModel>> rows, IReadOnlyList<FieldViewModel> formFields)
    {
        return Page(title, eyebrow, description, Metrics(("Registros", "30"), ("Tabla", eyebrow), ("Campos", headers.Count.ToString()), ("API", "Pendiente")), formFields.Take(4).ToList(), headers, rows, Form(anchor, buttonText, buttonText, $"Formulario preparado para {eyebrow}.", formFields));
    }

    private ModulePageViewModel SharedClient(string title, string eyebrow, string description, string buttonText, string anchor, IReadOnlyList<string> headers, IReadOnlyList<IReadOnlyList<CellViewModel>> rows, IReadOnlyList<FieldViewModel> formFields)
    {
        return Page(title, eyebrow, description, Metrics(("Registros", "30"), ("Clientes", "30"), ("Tabla", eyebrow), ("API", "Pendiente")), formFields.Take(4).ToList(), headers, rows, Form(anchor, buttonText, buttonText, $"Formulario preparado para {eyebrow}.", formFields));
    }

    private static ModulePageViewModel Page(string title, string eyebrow, string description, IReadOnlyList<MetricViewModel> metrics, IReadOnlyList<FieldViewModel> filters, IReadOnlyList<string> headers, IReadOnlyList<IReadOnlyList<CellViewModel>> rows, FormViewModel? adminForm, FormViewModel? clientForm = null, string? searchAction = null)
    {
        return new ModulePageViewModel { Title = title, Eyebrow = eyebrow, Description = description, Metrics = metrics, Filters = filters, Headers = headers, Rows = rows, AdminForm = adminForm, ClientForm = clientForm, SearchAction = searchAction };
    }

    private static FormViewModel Form(string anchor, string buttonText, string title, string description, IReadOnlyList<FieldViewModel> fields, string submitText = "Guardar cuando exista API", string? action = null)
    {
        return new FormViewModel { Anchor = anchor, ButtonText = buttonText, Title = title, Description = description, Fields = fields, SubmitText = submitText, Action = action };
    }

    private static IReadOnlyList<MetricViewModel> Metrics(params (string Label, string Value)[] metrics) => metrics.Select(m => new MetricViewModel { Label = m.Label, Value = m.Value }).ToList();
    private static IReadOnlyList<string> Headers(params string[] headers) => headers;
    private static IReadOnlyList<FieldViewModel> Fields(params object[] fields)
    {
        return fields.Select(field =>
        {
            if (field is ValueTuple<string, string, string, string> typed)
            {
                return Field(typed.Item1, typed.Item2, typed.Item3, typed.Item4);
            }

            var simple = (ValueTuple<string, string, string>)field;
            return Field(simple.Item1, simple.Item2, simple.Item3);
        }).ToList();
    }

    private static FieldViewModel Field(string label, string name, string placeholder, string type = "text", string? value = null, bool readOnly = false, string spanClass = "", string? helpText = null)
    {
        return new FieldViewModel { Label = label, Name = name, Placeholder = placeholder, Type = type, Value = value, ReadOnly = readOnly, SpanClass = spanClass, HelpText = helpText };
    }

    private static IReadOnlyList<IReadOnlyList<CellViewModel>> Rows(params IReadOnlyList<CellViewModel>[] rows) => rows;
    private static IReadOnlyList<CellViewModel> Row(params object[] cells) => cells.Select(cell => cell as CellViewModel ?? new CellViewModel { Text = Convert.ToString(cell) ?? string.Empty }).ToList();
    private static CellViewModel Status(string text, string status = "") => new() { Text = text, Status = status };

    private IReadOnlyList<ModuleCardViewModel> GetCards()
    {
        return new[]
        {
            Card("Operaciones", "Tripulacion", "Asignacion de tripulantes por nombre, apellido y rol.", "Tripulacion"),
            Card("Bitacora", "Historial de vuelos", "Registro por tripulacion, avion y fecha de salida.", "HistorialVuelos"),
            Card("Flota", "Aviones", "Modelo, capacidad y aeropuerto asociado.", "Aviones"),
            Card("Socios", "Aerolineas", "Codigo AITA, ciudad y pais.", "Aerolineas"),
            Card("Red", "Aeropuertos", "Nombre, ciudad, pais y aerolinea relacionada.", "Aeropuertos"),
            Card("Comercial", "Tarifas", "Precios y clases asociadas a vuelos.", "Tarifas"),
            Card("Acceso", "Usuarios", "Nombre, apellido, correo, contrasena y rol.", "Usuarios"),
            Card("Programacion", "Vuelos", "Origen, destino, salida, llegada, estado, usuario y avion.", "Vuelos"),
            Card("Reservas", "Asientos", "Reservas por cliente, fecha y estado.", "Asientos"),
            Card("Equipaje", "Equipaje", "Equipaje por cliente y peso registrado.", "Equipaje"),
            Card("Control", "Migracion", "Destino, fecha y hora de salida por cliente.", "Migracion"),
            Card("Finanzas", "Factura", "Total, numero, serie, fecha y hora de facturacion.", "Factura"),
            Card("Atencion", "Objetos perdidos", "Descripcion, lugar de perdida, fecha, hora y estado.", "ObjetosPerdidos")
        };
    }

    private static ModuleCardViewModel Card(string area, string title, string description, string action) => new() { Area = area, Title = title, Description = description, Action = action };

    private bool IsAuthenticated() => !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("UserRole"));

    private bool IsAdmin()
    {
        var role = HttpContext.Session.GetString("UserRole");
        return string.Equals(role, "Administrador", StringComparison.OrdinalIgnoreCase) || string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);
    }
}
