using System;
using System.Collections.Generic;
using System.Text;
using AdvancedApprovalTests.Domain;

namespace AdvancedApprovalTests.UnitTests.SampleData
{
    public static class TestEmployeeIncomeRecordFactory
    {
        public static List<IncomeRecord> GetTestIncomeRecords()
        {
            return new List<IncomeRecord>()
            {
                new IncomeRecord() { Id = 1 , EmployeeId = 1, Date = DateTime.Parse("2020-01-05"), Amount = 450   },
                new IncomeRecord() { Id = 2 , EmployeeId = 1, Date = DateTime.Parse("2020-01-25"), Amount = 3000  },
                new IncomeRecord() { Id = 3 , EmployeeId = 1, Date = DateTime.Parse("2020-02-05"), Amount = 450   },
                new IncomeRecord() { Id = 4 , EmployeeId = 1, Date = DateTime.Parse("2020-02-25"), Amount = 3000  },
                new IncomeRecord() { Id = 5 , EmployeeId = 1, Date = DateTime.Parse("2020-03-05"), Amount = 450   },
                new IncomeRecord() { Id = 6 , EmployeeId = 1, Date = DateTime.Parse("2020-03-25"), Amount = 3000  },
                new IncomeRecord() { Id = 7 , EmployeeId = 1, Date = DateTime.Parse("2020-04-05"), Amount = 450   },
                new IncomeRecord() { Id = 8 , EmployeeId = 1, Date = DateTime.Parse("2020-04-25"), Amount = 3000  },
                new IncomeRecord() { Id = 9 , EmployeeId = 1, Date = DateTime.Parse("2020-05-05"), Amount = 450   },
                new IncomeRecord() { Id = 10, EmployeeId = 1, Date = DateTime.Parse("2020-05-25"), Amount = 3000  },
                new IncomeRecord() { Id = 11, EmployeeId = 1, Date = DateTime.Parse("2020-06-05"), Amount = 450   },
                new IncomeRecord() { Id = 12, EmployeeId = 1, Date = DateTime.Parse("2020-06-25"), Amount = 3000  },
                new IncomeRecord() { Id = 13, EmployeeId = 1, Date = DateTime.Parse("2020-07-05"), Amount = 450   },
                new IncomeRecord() { Id = 14, EmployeeId = 1, Date = DateTime.Parse("2020-07-25"), Amount = 3000  },
                new IncomeRecord() { Id = 15, EmployeeId = 1, Date = DateTime.Parse("2020-08-05"), Amount = 450   },
                new IncomeRecord() { Id = 16, EmployeeId = 1, Date = DateTime.Parse("2020-08-25"), Amount = 3000  },
                new IncomeRecord() { Id = 17, EmployeeId = 1, Date = DateTime.Parse("2020-09-05"), Amount = 900   },
                new IncomeRecord() { Id = 18, EmployeeId = 1, Date = DateTime.Parse("2020-09-25"), Amount = 5500  },
                new IncomeRecord() { Id = 19, EmployeeId = 1, Date = DateTime.Parse("2020-10-05"), Amount = 900   },
                new IncomeRecord() { Id = 20, EmployeeId = 1, Date = DateTime.Parse("2020-10-25"), Amount = 5500  },
                new IncomeRecord() { Id = 21, EmployeeId = 1, Date = DateTime.Parse("2020-11-05"), Amount = 900   },
                new IncomeRecord() { Id = 22, EmployeeId = 1, Date = DateTime.Parse("2020-11-25"), Amount = 5500  },
                new IncomeRecord() { Id = 23, EmployeeId = 1, Date = DateTime.Parse("2020-12-05"), Amount = 900   },
                new IncomeRecord() { Id = 24, EmployeeId = 1, Date = DateTime.Parse("2020-12-25"), Amount = 5500  },
                new IncomeRecord() { Id = 25, EmployeeId = 1, Date = DateTime.Parse("2020-12-31"), Amount = 15000 },
            };
        }
    }
}
