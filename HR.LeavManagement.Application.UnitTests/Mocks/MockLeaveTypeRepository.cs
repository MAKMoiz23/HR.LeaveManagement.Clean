using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeavManagement.Application.UnitTests.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetMockLeaveTypes()
        {
            List<LeaveType> leaveTypes = new List<LeaveType> {
                new LeaveType {
                    Id = 1,
                    Name = "Test Vacations",
                    DefaultDays = 10,
                },new LeaveType {
                    Id = 2,
                    Name = "Test Sick",
                    DefaultDays = 6,
                },new LeaveType {
                    Id = 1,
                    Name = "Test Casual",
                    DefaultDays = 18,
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo
                .Setup(r => r.GetAsync())
                .ReturnsAsync(leaveTypes);

            mockRepo
                .Setup(r => r.CreateAsync(It.IsAny<LeaveType>()))
                .Returns((LeaveType leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
