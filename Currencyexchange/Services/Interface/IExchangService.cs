using Currencyexchange.Models;

namespace Currencyexchange.Services.Interface
{
    public interface IExchangService
    {
      
        ValueTask<float> Exchang(ExchangRequest model);
      
    }
}
