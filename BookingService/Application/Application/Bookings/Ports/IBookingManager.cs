using Application.Bookings.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Ports
{
    public interface IBookingManager: IBaseManager<BookingDto, PostBookingDto, PutBookingDto>
    {

    }
}
