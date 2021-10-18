using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using AdvancedApprovalTests.Contracts;

namespace AdvancedApprovalTests.UnitTests.Extensions
{
    internal static class TaxCalculationResultFormatterExtensions
    {
        public static string ToStringTable(this IEnumerable<(decimal Basis, decimal Tax)> response)
        {
            var tableFormattedResponse = response.ToStringTable(
                ("Basis", r => r.Basis.ToString("F2", CultureInfo.InvariantCulture)),
                ("Tax", r => r.Tax.ToString("F2", CultureInfo.InvariantCulture))
            );

            return tableFormattedResponse;
        }

        public static string ToStringTable(this IEnumerable<TaxCalculationResponse> response)
        {
            var tableBuilder = new StringBuilder();

            foreach (var taxCalculationResponse in response)
            {
                tableBuilder.AppendLine($"Employee {taxCalculationResponse.EmployeeId}");
                tableBuilder.AppendLine($"Total tax {taxCalculationResponse.TotalTax.ToString("F2", CultureInfo.InvariantCulture)}");
                tableBuilder.AppendLine("Calculated tax:");
                tableBuilder.Append(taxCalculationResponse.CalculatedTax.ToStringTable());
            }

            return tableBuilder.ToString();
        }
    }
}
