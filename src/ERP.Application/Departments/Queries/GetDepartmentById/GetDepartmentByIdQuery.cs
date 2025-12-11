using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery(Guid id) : IQuery<DepartmentByIdReponse>
    {
        public Guid Id { get; } = id;
    }
}