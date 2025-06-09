using System;

public class ReservaHotel : IEntidade
{
    public Guid Id { get; set; }
    public string NomeCliente { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataSaida { get; set; }
    public StatusReserva Status { get; set; }

    public ReservaHotel()
    {
        Id = Guid.NewGuid();
    }
}
