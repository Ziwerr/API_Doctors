using API_Doctors.Extensions;
using HotChocolate;

namespace API_Doctors.Filters
{
    public class MedicineNotFoundExceptionFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is MedicineNotFoundException ex)
                return error.WithMessage($"Nie znaleziono leku o id {ex.Id}");
            return error;
        }
    }
}