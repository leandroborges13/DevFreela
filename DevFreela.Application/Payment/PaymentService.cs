﻿using DevFreela.Application.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Application.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _paymentsBaseUrl;
        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;
        }
        public async Task<bool> ProcessPayment(PaymentInfoDto paymentInfoDto)
        {
            var url = $"{_paymentsBaseUrl}/api/payments";
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);
            var paymentInfoContent = new StringContent(paymentInfoJson, Encoding.UTF8, "application/json");

            var httpClient = _httpClientFactory.CreateClient("Payments");

            var response = await httpClient.PostAsync(url, paymentInfoContent);
                
            return response.IsSuccessStatusCode;
        }
    }
}
