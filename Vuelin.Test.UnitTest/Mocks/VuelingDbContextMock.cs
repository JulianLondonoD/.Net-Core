using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vuelin.Test.UnitTest.Stubs;
using Vueling.Test.Data;
using Vueling.Test.Entities;

namespace Vuelin.Test.UnitTest.Mocks
{
    public class VuelingDbContextMock
    {
        public Mock<VuelingDbContext> _context { get; set; }

        public VuelingDbContextMock()
        {
            _context = new Mock<VuelingDbContext>();
        }
    }
}
