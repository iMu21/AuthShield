using AuthShield.Application.Model;
using AuthShield.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Application.Contracts.Infrastructure
{
    public interface IProductClient
    {
        Task<ApiResponse> GetProductByIdAsync(int productId);
    }
}
