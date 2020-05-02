using System;

namespace MommyDayCare.Shared.ViewModels
{

    public class LoginResponse : ResponseBase
    {
      
        public string Token { get; set; }

        public DateTime TokenExpiry { get; set; }
  
    }
}
