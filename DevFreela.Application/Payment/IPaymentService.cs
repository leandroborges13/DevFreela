﻿using DevFreela.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Payment
{
    public interface IPaymentService
    {
        Task<bool> ProcessPayment(PaymentInfoDto paymentInfoDto);
    }
}
