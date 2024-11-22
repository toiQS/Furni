namespace furni.Infrastructure.Helpers
{
    public class PriceRangesConverter
    {
        public static List<(float Min, float Max)> Parse(string prices)
        {
            var priceRanges = prices.Split(',');
            var rangeList = new List<(float Min, float Max)>();

            foreach (var range in priceRanges)
            {
                var parts = range.Split(':');
                if (parts.Length == 2 && float.TryParse(parts[0], out float min) && float.TryParse(parts[1], out float max))
                {
                    rangeList.Add((min, max));
                }
            }

            return rangeList;
        }

        public static List<(float Min, float Max)> Parse(string[] prices)
        {
            var rangeList = new List<(float Min, float Max)>();

            foreach (var range in prices)
            {
                var parts = range.Split(':');
                if (parts.Length == 2 && float.TryParse(parts[0], out float min) && float.TryParse(parts[1], out float max))
                {
                    rangeList.Add((min, max));
                }
            }

            return rangeList;
        }
    }
}
