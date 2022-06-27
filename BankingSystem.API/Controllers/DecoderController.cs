using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecoderController : ControllerBase
    {
        [HttpGet]
        public String Decode(int number)
        {

            string result = "";
            int count = 0;

            string numberstr = number.ToString();

            if (numberstr.Length % 2 == 0 && numberstr.Length >= 6 && numberstr.Length <= 20)
                for (int i = 0; i < numberstr.Length; i += 2)
                {
                    char c = numberstr[i];
                    count = int.Parse(c.ToString());

                    while (count > 0)
                    {
                        result = result + numberstr[i + 1];
                        count--;
                    }
                }
            return result;

        }
    }
}
