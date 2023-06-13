using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ColourConverterInElasticBeanstalk.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel>
            logger)
        {
            _logger = logger;
        }

        public string Result { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(string? rgb = null, string? hex = null)
        {
            try
            {
                if (rgb != null)
                {
                    Result = ConvertRgbToHex(rgb);
                }
                else if (hex != null)
                {
                    Result = ConvertHexToRgb(hex);
                }

                else
                {
                    Result = "No Data Submitted";
                }
            }

            catch
            {
                throw;
            }
        }

        private string ConvertHexToRgb(string hex)
        {
            try
            {
                // remove the # from the start of the string
                hex = hex.Substring(1);

                // split the string into 3 parts, each representing a colour value
                string red = hex.Substring(0, 2);
                string green = hex.Substring(2, 2);
                string blue = hex.Substring(4, 2);

                // convert each colour value from hex to decimal
                int redDecimal = Convert.ToInt32(red, 16);
                int greenDecimal = Convert.ToInt32(green, 16);
                int blueDecimal = Convert.ToInt32(blue, 16);

                // return the rgb value as a string
                return $"{redDecimal},{greenDecimal},{blueDecimal}";
            }

            catch
            {
                throw;
            }
        }

        private string ConvertRgbToHex(string rgb)
        {
            // receive string in format "255,255,255" and convert from rgb colour value to hex value in the format "#a1a1a1"

            try
            {
                // split the string into 3 parts, each representing a colour value
                string[] rgbArray = rgb.Split(',');

                // convert each colour value from decimal to hex
                string redHex = Convert.ToString(Convert.ToInt32(rgbArray[0]), 16);
                string greenHex = Convert.ToString(Convert.ToInt32(rgbArray[1]), 16);
                string blueHex = Convert.ToString(Convert.ToInt32(rgbArray[2]), 16);

                // return the hex value as a string
                return $"#{redHex}{greenHex}{blueHex}";
            }

            catch
            {
                throw;
            }
        }
    }
}
