﻿namespace ClinicaDentaria.Api.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public double ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}