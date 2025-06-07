using DAL.Models;
using WebAPI_Printer.Models;

namespace WebAPI_Printer.Extensions
{
    public static class ConverterExtensions
    {
      
        public static UserBalanceDto ToUserBalanceDto(this User user)
        {
            return new UserBalanceDto
            {
                Uid = user.Uid,
                Username = user.Username,
                Balance = user.QuotaChf
            };
        }

      
        public static FacultyDto ToFacultyDto(this Faculty faculty)
        {
            return new FacultyDto
            {
                FacultyId = faculty.FacultyId,
                Name = faculty.Name
            };
        }

      
        public static FormatPagesDto ToFormatPagesDto(this PrintPrice price, decimal quotaChf)
        {
            return new FormatPagesDto
            {
                TypeCode = price.TypeCode,
                PagesAvailable = (int)System.Math.Floor(quotaChf / price.PricePerPage)
            };
        }

        
        public static PrintQuotaResultDto ToPrintQuotaResultDto(this User user, List<PrintPrice> prices)
        {
            var formats = prices
                .Select(p => p.ToFormatPagesDto(user.QuotaChf))
                .ToList();

            return new PrintQuotaResultDto
            {
                UserId = user.Uid,
                QuotaChf = user.QuotaChf,
                Formats = formats
            };
        }
    }
}
