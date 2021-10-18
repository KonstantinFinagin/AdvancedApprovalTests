namespace AdvancedApprovalTests.UnitTestDataHelper

module CsvDataHelper =
    
    open System
    open FSharp.Data
    open AdvancedApprovalTests.Domain

    // TAX RATE DATA

    [<Literal>]
    let private taxRatePath = __SOURCE_DIRECTORY__ + "\TestData\TaxRateHeaders.csv"

    type TaxRateData = CsvProvider<taxRatePath, Schema = "int64, decimal?, decimal?, decimal">
                                                        //id     min       max      rate
    let private taxRateItems (data: TaxRateData) = 
        data.Rows |> Seq.map(fun row -> 
            (
                TaxRate(
                    Id = row.Id,
                    MinAmount = (decimal) (if row.MinAmount.HasValue then row.MinAmount.Value else Decimal.Zero),
                    MaxAmount = (decimal) (if row.MaxAmount.HasValue then row.MaxAmount.Value else Decimal.MaxValue),
                    Rate = row.Rate
                )
            )
        )

    let GetTaxRateItems (path: string) = 
        let dataSet = TaxRateData.Load(path)
        taxRateItems dataSet |> Seq.toArray 


    // EMPLOYEE INCOME RECORD DATA

    [<Literal>]
    let private employeePath = __SOURCE_DIRECTORY__ + "\TestData\EmployeeIncomeRecordHeaders.csv"

    type EmployeeIncomeRecordData = CsvProvider<employeePath, Schema = "int64, int64, date, decimal">
                                                                        //id   emp.   date  amount

    let private employeeIncomeRecords (data: EmployeeIncomeRecordData) = 
        data.Rows |> Seq.map(fun row -> 
            (
                IncomeRecord(
                    Id = row.Id,
                    EmployeeId = row.EmployeeId,
                    Date = row.Date,
                    Amount = row.Amount
                )
            )
        )

    let GetEmployeeIncomeRecords (path: string) = 
        let dataSet = EmployeeIncomeRecordData.Load(path)
        employeeIncomeRecords dataSet |> Seq.toArray 