using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Client.Services
{
    public interface IAlertService
    {
        void ShowAlert();
        void HideAlert();
    }
}
