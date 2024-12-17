using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using furni.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace furni.Infrastructure.IServices
{
    public interface IPayPalService
    {
        Task<string> CreatePaymentUrl(Order model, HttpContext context);
        PaymentResponse PaymentExecute(IQueryCollection collections);
    }
}
