﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFrequencia.Infra.Utils.Interfaces
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile formFile, string imageDirectory);
    }
}
