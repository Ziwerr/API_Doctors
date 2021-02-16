using API_Doctors.Extensions;
using HotChocolate;

namespace API_Doctors.Filters
{
    public class DoctorNotFoundExceptionFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is DoctorNotFoundException ex)
                return error.WithMessage($"Nie znaleziono doktora o id {ex.Id}");
            return error;
        }
    }
}