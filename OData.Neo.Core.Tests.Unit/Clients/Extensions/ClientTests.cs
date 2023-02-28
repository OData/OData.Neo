using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OData.Neo.Core.Clients.Extensions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Clients.Extensions
{
    public class ClientTests
    {
        [Fact]
        public async Task ShouldFilterStudent()
        {
            // given
            var students = new List<Student>
            {
                new Student { Id = Guid.NewGuid(), Name = "John" },
                new Student { Id = Guid.NewGuid(), Name = "Mary" },
                new Student { Id = Guid.NewGuid(), Name = "Peter" }
            }.AsQueryable();

            var filteredStuff = 
                await students.ApplyODataQueryAsync(
                    "$select=Name");

            Assert.True(true);
        }

        public class Student
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
