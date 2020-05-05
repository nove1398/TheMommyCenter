using MommyDayCare.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MommyDayCare.Shared.ApiModels
{
    public class RegisterResponse : ResponseBase
    {
        public bool IsRegistered { get; set; }
    }
}
