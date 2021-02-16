using API_Doctors.Extensions;
using HotChocolate;

namespace API_Doctors.Filters
{
    public class PrescriptionNotFoundExceptionFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is PrescriptionNotFoundException ex)
                return error.WithMessage($"Nie znaleziono recepty o id {ex.Id}");
            return error;
        }
    }
}