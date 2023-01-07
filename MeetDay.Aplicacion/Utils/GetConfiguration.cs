using MeetDay.Dominio.Core.Interfaces;

namespace MeetDay.Aplicacion.Utils
{
    public class GetConfiguration : IGetConfiguration
    {
        private readonly string _acselConnectionString;
        public GetConfiguration(string acselConnectionString)
        {
            _acselConnectionString = acselConnectionString;
        }
        public string GetConnectionString()
        {
            return _acselConnectionString;
        }

    }
}