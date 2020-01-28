using System;

public class Prestamo
{
    public int PrestamoId { get; set; }
    public DateTime Fecha { get; set; }
    public int Monto { get; set; }
    public int Semanas { get; set; }

    public Prestamo()
	{
        PrestamoId = 0;
        Fecha = DateTime.Now;
        Monto = 0;
        Semanas = 0;

    }   
}
