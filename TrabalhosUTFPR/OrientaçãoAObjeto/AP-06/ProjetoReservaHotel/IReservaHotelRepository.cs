using System.Collections.Generic;

public interface IReservaHotelRepository : IRepository<ReservaHotel>
{
    IEnumerable<ReservaHotel> ObterPorStatus(StatusReserva status);
}
