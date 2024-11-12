using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using System.ComponentModel.DataAnnotations;

namespace RS1_2024_25.API.Endpoints.PaymentEndpoints
{
    [Route("payments")]
    [ApiController]
    public class PaymentAddEndpoint(ApplicationDbContext dbContext) : MyEndpointBaseAsync.WithRequest<AddPaymentRequest>.WithActionResult<AddPaymentResponse>
    {
        [HttpPost("add")]
        public override async Task<ActionResult<AddPaymentResponse>> HandleAsync([FromBody] AddPaymentRequest request, CancellationToken cancellationToken = default)
        {
            int coinsEarned = (int)(request.Amount * 10);

            var payment = new Payment
            {
                UserId = request.UserId,
                Amount = request.Amount,
                PaymentMethodId = request.PaymentMethodId,
                PaymentDate = DateTime.Now,
                CoinAmount = request.CoinAmount,
                ExpGained = request.ExpGained
            };

            dbContext.Payments.Add(payment);

            var user = await dbContext.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            //Add coins to user
            var userCoin = dbContext.UserCoins.FirstOrDefault(x => x.UserId == user.UserId && x.CoinId == 1);
            if (userCoin != null)
            {
                userCoin.Amount += payment.CoinAmount;
            }
            else
            {
                dbContext.UserCoins.Add(new UserCoin
                {
                    UserId = user.UserId,
                    CoinId = 1,
                    Amount = payment.CoinAmount
                });
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            var response = new AddPaymentResponse
            {
                PaymentId = payment.PaymentId,
                UserId = payment.UserId,
                Amount = payment.Amount,
                PaymentMethod = (await dbContext.PaymentMethods.FindAsync(payment.PaymentMethodId))?.MethodName,
                PaymentDate = payment.PaymentDate,
                CoinAmount = payment.CoinAmount,
                ExpGained = payment.ExpGained
            };

            return Ok(response);


        }
    }

    public class AddPaymentResponse
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CoinAmount { get; set; }
        public int ExpGained { get; set; }

    }

    public class AddPaymentRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int PaymentMethodId { get; set; }
        [Required]
        public int CoinAmount { get; set; }
        [Required]
        public int ExpGained { get; set; }
    }
}
