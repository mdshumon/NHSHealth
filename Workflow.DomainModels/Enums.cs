using System;

namespace Workflow.DomainModels
{
    public static class Enums
    {
        public enum ReportTypes
        {
            Daily = 1,
            Weekly = 2,
            Monthly = 3,
            Quarterly = 4,
            Yearly = 5
        }
        public enum GenderTypes
        {
            Unknown = -1,
            Male = 1,
            Female = 2,
            DontDisclose = 3
        }
    }
}
