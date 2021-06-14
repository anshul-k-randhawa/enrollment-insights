using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CourseEnrollment.Infra
{
    public static class ContainersData
    {   
        public static readonly ReadOnlyDictionary<string, string> collectionNamesPartitionKey
        = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>(){
            { "StudentEnrollment", "/SubjectCode" },
            { "Staff", "/StaffDepartment" }
          }
        );
    }
}
