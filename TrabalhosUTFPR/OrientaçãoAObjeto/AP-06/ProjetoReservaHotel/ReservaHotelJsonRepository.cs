using System.Collections.Generic;
using System.Linq;

public class ReservaHotelJsonRepository : GenericJsonRepository<ReservaHotel>, IReservaHotelRepository
{
    public IEnumerable<ReservaHotel> ObterPorStatus(StatusReserva status)
    {
        return ObterTodos().Where(r => r.Status == status);
    }
}
