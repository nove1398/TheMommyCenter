using MommyDayCare.Shared.Models;
using MommyDayCare.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MommyDayCare.Shared.ApiModels
{
    public class ProfileResponse : ResponseBase
    {
        public ProfileViewModel Profile { get; set; }
    }
}
