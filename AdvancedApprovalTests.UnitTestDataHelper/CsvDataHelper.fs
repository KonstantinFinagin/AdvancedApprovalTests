namespace AdvancedApprovalTests.UnitTestDataHelper

module UnitTestDataHelper =
    
    open System
    open FSharp.Data
    open AdvancedApprovalTests.Domain

    [<Literal>]
    let taxRatePath = __SOURCE_DIRECTORY__ + "\TestData\TaxRateHeaders.csv"

    type TaxRateData = CsvProvider<taxRatePath, Schema = "int64, decimal, decimal, decimal">
                                                        //id     min       max      rate

    let private taxRateItems (data: TaxRateData) = 
        data.Rows |> Seq.map(fun row -> 
            (
                TaxRate(
                    Id = row.Id,
                    MinAmount = row.MinAmount,
                    MaxAmount = row.MaxAmount,
                    Rate = row.Rate
                )
            )
        )

    let GetTaxRateItems (path: string) = 
        let dataSet = TaxRateData.Load(path)
        taxRateItems dataSet |> Seq.toArray 